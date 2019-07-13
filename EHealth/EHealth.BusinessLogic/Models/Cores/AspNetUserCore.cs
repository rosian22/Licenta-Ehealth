using DataLayer.EHealth;
using EHealth.BusinessLogic.Workflow;
using EHealth.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpWorky.BusinessLogic.ModelCore.Base;

namespace EHealth.BusinessLogic.Models.Cores
{
    public partial class AspNetUserCore : BaseCore<AspNetUserRepository, AspNetUser>
    {
        public static async Task<bool> IsEmailNotUsedAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            using (var aspNetUsersRepository = RepoUnitOfWork.CreateRepository<AspNetUserRepository>())
            {
                var user = await aspNetUsersRepository.GetByEmailAsync(email).ConfigureAwait(false);

                return user == null;
            }
        }

        public static AspNetUser GetByEmail(string emailAddress, IList<string> navigationProperties = null)
        {
            using (var aspNetUsersRepository = RepoUnitOfWork.CreateRepository<AspNetUserRepository>())
            {
                var aspNetUser = aspNetUsersRepository.GetSingle(t => t.UserName == emailAddress, navigationProperties);

                return aspNetUser;
            }
        }

        public static async Task<Response<AspNetUser>> CreateAspNetUserAsync(RepoUnitOfWork repoUnitOfWork, CreateUserModel model)
        {
            var response = ResponseFactory.Error<AspNetUser>();
            if (repoUnitOfWork == null)
            {
                repoUnitOfWork = RepoUnitOfWork.New();
            }
            var aspNetUserRepository = repoUnitOfWork.TrackingRepository<AspNetUserRepository>();
            if (!await IsEmailNotUsedAsync(model.Email).ConfigureAwait(false))
            {
                return response;
            }
            var aspNetUser = new AspNetUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Email,
                PasswordHash = model.PasswordHash,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            var createdAspNetUser = await aspNetUserRepository.CreateAsync(aspNetUser, navigationProperties: new[]
                                    {
                                            nameof(AspNetRole)
                                    }).ConfigureAwait(false);
            if (createdAspNetUser == null)
            {
                return response;
            }
            return ResponseFactory.Success(createdAspNetUser);
        }


        public static async Task<bool> IsUserIdAuthorizedAsync(string aspNetUserId, List<string> roleIdList)
        {
            if (string.IsNullOrWhiteSpace(aspNetUserId))
            {
                return false;
            }

            using (var aspNetUsersRepository = RepoUnitOfWork.CreateRepository<AspNetUserRepository>())
            {
                var user = await aspNetUsersRepository.GetAsync(aspNetUserId, new[]
                            {
                                nameof(AspNetUser.AspNetRoles)
                            }).ConfigureAwait(false);
                if (user == null)
                {
                    return false;
                }

                var isApproved = user.Status == (int)UserStatus.ACTIVE;
                if (!isApproved)
                {
                    return false;
                }

                if (user.AspNetRoles == null)
                {
                    return false;
                }

                //if at least one role is found
                return roleIdList.Any(roleId => user.AspNetRoles.Any(role => role.Id == roleId));
            }
        }

        public static async Task<AspNetUser> GetAsync(string userId, IList<string> navigationProperties = null)
        {
            using (var aspNetUsersRepository = RepoUnitOfWork.CreateRepository<AspNetUserRepository>())
            {
                var aspNetUser = await aspNetUsersRepository.GetAsync(userId, navigationProperties);

                return aspNetUser;
            }
        }

        public static async Task<Response> Register(RegisterViewModel registerModel, string passwordHash)
        {
            using (var repoUnitOfWork = RepoUnitOfWork.New())
            {

                var aspNetUser = new AspNetUser
                {
                    Id = registerModel.Id.ToString(),
                    Email = registerModel.Email,
                    UserName = registerModel.Email,
                    UserType = (int)registerModel.userType,
                    Status = (int)UserStatus.ACTIVE,
                    PhoneNumber = registerModel.PhoneNumber,
                    CreatedAt = DateTime.UtcNow,
                    PasswordHash = passwordHash,
                };

                var aspNetUserRepo = repoUnitOfWork.TrackingRepository<AspNetUserRepository>();

                var createdUser = await aspNetUserRepo.CreateAsync(aspNetUser).ConfigureAwait(false);
                if (createdUser != null)
                {
                    repoUnitOfWork.CommitTransaction();
                    return ResponseFactory.Success<AspNetUser>();

                }
                repoUnitOfWork.RollbackTransaction();
                return ResponseFactory.Error<AspNetUser>();
            }
        }
    }
}