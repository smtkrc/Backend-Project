using GeneralClass.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Linq;

namespace GeneralClass.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter pattern : var olan bir sistemi kendi sistemimize uyarladık.
        //Direk microsoft ürünlerini adapte etmedik çünkü ileride farklı ürün kullanmak isteyebiliriz.

        IMemoryCache _memorycache;

        public MemoryCacheManager()
        {
            _memorycache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            _memorycache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memorycache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memorycache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memorycache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memorycache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).
                GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memorycache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memorycache.Remove(key);
            }
        }
    }
}
