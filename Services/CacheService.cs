using InventoryTrackApi.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace InventoryTrackApi.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        private readonly List<string> _keys = new();
        private readonly object _lock = new();

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiration = null)
        {
            if (_memoryCache.TryGetValue(key, out T? value))
            {
                return value;
            }

            value = await factory();

            var options = new MemoryCacheEntryOptions
            {
                SlidingExpiration = expiration ?? TimeSpan.FromMinutes(10)
            };

            _memoryCache.Set(key, value, options);

            lock (_lock)
            {
                if (!_keys.Contains(key))
                    _keys.Add(key);
            }

            return value;
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
            lock (_lock)
            {
                _keys.Remove(key);
            }
        }

        public void RemoveByPrefix(string prefix)
        {
            lock (_lock)
            {
                var keysToRemove = _keys.Where(k => k.StartsWith(prefix)).ToList();
                foreach (var key in keysToRemove)
                {
                    _memoryCache.Remove(key);
                    _keys.Remove(key);
                }
            }
        }
    }
}
