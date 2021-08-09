using System.Collections.Generic;

namespace MarvelComicsStore.Domain.Interface.Base
{
    public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        TEntity[] Insert(params TEntity[] obj);
        void UpdateChanges(TEntity obj);
        void Remove(params TEntity[] obj);
    }
}
