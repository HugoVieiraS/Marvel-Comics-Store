using System.Threading.Tasks;

namespace MarvelComicsStore.Infrastructure.ApiCaller.Interface
{
    public interface IApiCaller
    {
        Task<T> CallWebApiByGet<T>(string controller);
    }
}
