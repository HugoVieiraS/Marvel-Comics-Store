using MarvelComicsStore.Domain.Entities;
using MarvelComicsStore.Domain.Interface;
using MarvelComicsStore.Infrastructure.ApiCaller.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarvelComicsStore.Infrastructure.ApiCaller.Repository
{
    public class ComicsRepository : RepositoryBase, IComicsRepository
    {
        #region Properties
        public string ControllerName => "comics";
        #endregion

        #region Constructor
        public ComicsRepository(IApiCaller apiCaller)
            : base(apiCaller) { }
        #endregion

        #region Methods
        public Comics Get(int id)
        {
            return ApiCaller.CallWebApiByGet<Comics>($"{ControllerName}/{id}").Result;
        }

        public Comics GetAll()
        {
            return ApiCaller.CallWebApiByGet<Comics>(ControllerName).Result;
        }

        #endregion
    }
}
