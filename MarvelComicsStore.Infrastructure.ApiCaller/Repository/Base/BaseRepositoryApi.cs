using MarvelComicsStore.Infrastructure.ApiCaller.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelComicsStore.Infrastructure.ApiCaller.Repository
{
    public class BaseRepositoryApi
    {
        protected IApiCaller ApiCaller;

        protected BaseRepositoryApi(IApiCaller apiCaller)
        {
            ApiCaller = apiCaller;
        }
    }
}
