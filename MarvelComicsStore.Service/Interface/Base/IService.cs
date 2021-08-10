using System.Collections.Generic;

namespace MarvelComicsStore.Service.Interface.Base
{
    public interface IService <T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T model);
        void Update(T model);
        void Remove(int id);
    }
}
