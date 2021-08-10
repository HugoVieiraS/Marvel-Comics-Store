using System;

namespace MarvelComicsStore.Common.IntExtensionsMethods
{
    public static class IntExtensions
    {
        #region Methods
        public static int TryToIntOrDefault(this object? value)
        {
            if (value == null)
            {
                return default(int);
            }
            return Convert.ToInt32(value);
        }
        #endregion
    }
}
