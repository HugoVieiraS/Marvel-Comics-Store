using MarvelComicsStore.Common.StringExtensionMethods;
using MarvelComicsStore.Infrastructure.ApiCaller.Interface;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MarvelComicsStore.Infrastructure.ApiCaller.Api
{
    public class ApiCaller : IApiCaller
    {
        #region Constants
        private const string PUBLIC_KEY = "291e49bc2b597a65cc9a0c3c49c9b8aa";
        private const string PRIVATE_KEY = "f4ae25d82355a61fe7018c490331c5f2bb8bc423";
        private const string BASE_ADRESS = @"http://gateway.marvel.com/v1/public/";
        #endregion

        #region Fields
        protected static bool _alreadyTried = false;
        #endregion

        #region Methods
        public async Task<T> CallWebApiByGet<T>(string controller)
        {
            using var handler = new HttpClientHandler();
            using var client = new HttpClient(handler) { BaseAddress = new Uri(BASE_ADRESS) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("APIKEY", GetAuthentication(PRIVATE_KEY, PUBLIC_KEY));

            var result = await client.GetAsync($"{controller}{ GetAuthentication(PRIVATE_KEY, PUBLIC_KEY) }");

            var resultContent = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(resultContent);
            }
            else
            {
                if (result.StatusCode == HttpStatusCode.InternalServerError && string.IsNullOrWhiteSpace(resultContent))
                {
                    if (!_alreadyTried)
                    {
                        _alreadyTried = true;
                        return await CallWebApiByGet<T>(controller);
                    }
                }
                else if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new HttpRequestException($"{ resultContent.RemoveQuotes() }");
                }
                else if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    return default;
                }

                throw new HttpRequestException($"Status code: { (int)HttpStatusCode.InternalServerError }. { resultContent }");
            }
        }
        #endregion

        #region PrivateMethods
        private string GetAuthentication(string privateKey, string publicKey)
        {
            var timeStamp = StringExtension.GetTimestamp(DateTime.Now);
            var token = timeStamp + privateKey + publicKey;
            var hash = StringExtension.GerarHashMd5(token);
            return $"?ts={timeStamp}&apikey={publicKey}&hash={hash}";
        }
        #endregion
    }
}
