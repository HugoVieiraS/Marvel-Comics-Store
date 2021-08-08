using MarvelComicsStore.Domain.Interface;
using MarvelComicsStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _mySqlContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _mySqlContext.FindAsync<TEntity>(id);
        }

        public async Task InsertAsync(params TEntity[] obj)
        {
            _mySqlContext.Set<TEntity>().AddRange(obj);
            await _mySqlContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(params TEntity[] obj)
        {
            _mySqlContext.Set<TEntity>().RemoveRange(obj);
            await _mySqlContext.SaveChangesAsync();
        }

        public async Task UpdateChangesAsync(TEntity obj)
        {
            _mySqlContext.Entry(obj).State = EntityState.Modified;
            _mySqlContext.Set<TEntity>().UpdateRange(obj);
            await _mySqlContext.SaveChangesAsync();
        }
        #endregion
    }
}
