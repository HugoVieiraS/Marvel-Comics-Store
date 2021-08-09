using MarvelComicsStore.Domain.Interface.Base;
using MarvelComicsStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MarvelComicsStore.Infrastructure.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        #region Fields
        private readonly MySqlContext _mySqlContext;
        #endregion

        #region Constructor
        public BaseRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }
        #endregion

        #region Methods
        public IEnumerable<TEntity> GetAll() 
        {
            return _mySqlContext.Set<TEntity>().ToList();
        } 
        
        public TEntity Get(int id)
        {
            return _mySqlContext.Find<TEntity>(id);
        }

        public TEntity[] Insert(params TEntity[] obj)
        {
            _mySqlContext.Set<TEntity>().AddRange(obj);
            _mySqlContext.SaveChanges();
            return obj;
        }

        public void Remove(params TEntity[] obj)
        {
            _mySqlContext.Set<TEntity>().RemoveRange(obj);
            _mySqlContext.SaveChanges();
        }

        public void UpdateChanges(TEntity obj)
        {
            _mySqlContext.Entry(obj).State = EntityState.Modified;
            _mySqlContext.Set<TEntity>().UpdateRange(obj);
            _mySqlContext.SaveChanges();
        }
        #endregion
    }
}
