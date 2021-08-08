using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComicsStore.Domain.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        #region Async methods   
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task InsertAsync(params TEntity[] obj);
        Task UpdateChangesAsync(TEntity obj);
        Task RemoveAsync(params TEntity[] obj);
        #endregion
    }
}
