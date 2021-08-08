using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelComicsStore.Domain.Interface
{
    public interface IBaseRepository<TEntity>
    {
        #region Async methods   
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Insert(params TEntity[] obj);
        void UpdateChanges(TEntity obj);
        void Remove(params TEntity[] obj);
        #endregion
    }
}
