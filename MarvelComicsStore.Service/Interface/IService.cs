using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComicsStore.Service.Interface
{
    public interface IService <T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T model);
        void Update(T model);
        void Remove(int? id);
    }
}
