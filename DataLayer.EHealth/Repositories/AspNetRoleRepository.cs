using EHealth.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EHealth.Repositories
{
    public class AspNetRoleRepository : BaseRepository<AspNetRole>
    {
        public async Task<AspNetRole> GetAsync(string id, IList<string> navigationProperties = null)
        {
            return await GetSingleAsync(aspNetRole => aspNetRole.Id == id, navigationProperties).ConfigureAwait(false);
        }

        protected override AspNetRole FetchFromDb(AspNetRole entity, IList<string> navigationProperties = null)
        {
            return GetSingle(aspNetRole => aspNetRole.Id == entity.Id, navigationProperties);
        }

        #region Overrides

        protected override async Task<AspNetRole> FetchFromDbAsync(AspNetRole entity, IList<string> navigationProperties = null)
        {
            return await GetAsync(entity.Id, navigationProperties).ConfigureAwait(false);
        }

        protected override bool ValidateEntity(AspNetRole entity)
        {
            if (!string.IsNullOrEmpty(entity?.Id) && entity.Id != Guid.Empty.ToString())
            {
                return true;
            }

            //LogHelper.LogException<BaseDataRepository>("Invalid entity: null or empty primary keys");
            return false;
        }

        #endregion
    }
}
