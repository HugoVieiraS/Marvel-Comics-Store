using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsStore.Domain.Interface
{
    public interface IRepository<T>
    {
        string ControllerName { get; }
        T Get(int id);
        T GetAll();
    }
}
