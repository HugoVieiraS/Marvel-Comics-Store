using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComicsStore.Service.Interface.Base
{
    public interface IService <T>
    {
        #region Methods
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T model);
        void Update(T model);
        void Remove(int id);
        #endregion
    }
}
