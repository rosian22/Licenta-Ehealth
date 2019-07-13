using DataLayer.EHealth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHealth.DataLayer.Repositories
{
    public class AspNetUserRepository : BaseRepository<AspNetUser>
    {
        public async Task<AspNetUser> GetAsync(string id, IList<string> navigationProperties = null)
        {
            return await GetSingleAsync(aspNetUser => aspNetUser.Id == id, navigationProperties).ConfigureAwait(false);
        }

        public async Task<AspNetUser> GetByEmailAsync(string email, IList<string> navigationProperties = null)
        {
            var user = await GetSingleAsync(aspNetUser => aspNetUser.UserName.ToLower() == email.ToLower(), navigationProperties).ConfigureAwait(false);

            return user;
        }

        public async Task<bool> ChangeStatusAsync(string aspNetUserId, int status)
        {
            var user = await GetSingleAsync(aspNetUser => aspNetUser.Id == aspNetUserId).ConfigureAwait(false);
            if (user == null)
            {
                return false;
            }

            //user.Status = status;
            user = await UpdateAsync(user).ConfigureAwait(false);

            return user != null;
        }

        #region Overrides

        protected override async Task<AspNetUser> FetchFromDbAsync(AspNetUser entity, IList<string> navigationProperties = null)
        {
            return await GetAsync(entity.Id, navigationProperties).ConfigureAwait(false);
        }

        protected override bool ValidateEntity(AspNetUser entity)
        {
            if (!string.IsNullOrEmpty(entity?.Id) && entity.Id != Guid.Empty.ToString())
            {
                return true;
            }

            //LogHelper.LogException<BaseDataRepository>("Invalid entity: null or empty primary keys");
            return false;
        }

        protected override AspNetUser FetchFromDb(AspNetUser entity, IList<string> navigationProperties = null)
        {
            return GetSingle(e => e.Id == entity.Id, navigationProperties);
        }

        #endregion
    }
}