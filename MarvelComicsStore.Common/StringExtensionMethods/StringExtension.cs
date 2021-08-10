using System;
using System.Security.Cryptography;
using System.Text;

namespace MarvelComicsStore.Common.StringExtensionMethods
{
    public static class StringExtension
    {
        #region Methods
        public static string GetTimestamp(DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMddHHmmssffff");
        }

        public static string GerarHashMd5(string token)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(token);
            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash).ToLower().Replace("-", String.Empty);
        }

        public static string RemoveQuotes(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            if (value.StartsWith("\""))
                value = value.Remove(0, 1);

            if (value.EndsWith("\""))
                value = value.Remove(value.Length - 1);

            return value;
        }
        #endregion
    }
}
