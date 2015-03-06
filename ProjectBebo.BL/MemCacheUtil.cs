using System;
using System.Runtime.Caching;

namespace ProjectBebo.BL
{
    public static class MemCacheUtil
    {
        public static object GetCachedObject(string key)
        {
            object cachedObj;
            try
            {
                MemoryCache memoryCache = MemoryCache.Default;
                cachedObj = memoryCache.Get(key);
            }
            catch
            {
                cachedObj = null;
                throw;
            }

            return cachedObj;
        }

        public static bool Add(string key, object value, DateTimeOffset absExpiration)
        {
            bool status = false;

            try
            {
                MemoryCache memoryCache = MemoryCache.Default;
                status = memoryCache.Add(key, value, absExpiration);
            }
            catch
            {
                status = false;
                throw;
            }

            return status;
        }

        public static bool Delete(string key)
        {
            bool status = false;
            try
            {
                MemoryCache memoryCache = MemoryCache.Default;
                if (memoryCache.Contains(key))
                {
                    memoryCache.Remove(key);
                    status = true;
                }
            }
            catch
            {
                throw;
            }

            return status;
        }
    }
}
