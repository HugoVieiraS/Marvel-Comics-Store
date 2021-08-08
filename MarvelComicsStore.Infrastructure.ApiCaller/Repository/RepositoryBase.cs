using MarvelComicsStore.Infrastructure.ApiCaller.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsStore.Infrastructure.ApiCaller.Repository
{
    public class RepositoryBase
    {
        protected IApiCaller ApiCaller;

        protected RepositoryBase(IApiCaller apiCaller)
        {
            ApiCaller = apiCaller;
        }
    }
}
