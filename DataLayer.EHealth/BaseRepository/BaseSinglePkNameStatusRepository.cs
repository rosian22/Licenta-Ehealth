using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EHealth.DataLayer.Interfaces;
using EHealth.DataLayer.Models;

namespace EHealth.DataLayer.Repositories
{
    public class BaseSinglePkNameStatusRepository<T> : BaseSinglePkRepository<T> where T : class, IDataAccessObjectWithNameStatus, new()
    {
        public async Task<IList<T>> GetListByNames(IList<string> names)
        {
            for (var i = 0; i < names.Count; i++)
            {
                names[i] = names[i];
            }
            return await GetListAsync(entity => (names.Contains(entity.Name) && entity.Status == (int)EntityStatus.ACTIVE)).ConfigureAwait(false);
        }

        public async Task<T> GetSingleByNameAsync(string name)
        {
            return await GetSingleAsync(entity => (entity.Name == name && entity.Status == (int)EntityStatus.ACTIVE)).ConfigureAwait(false);
        }
    }
}
