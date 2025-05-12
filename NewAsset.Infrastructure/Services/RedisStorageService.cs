﻿

namespace NewAsset.Infrastructure.Services
{

    public class RedisStorageService : IRedisStorageService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<RedisStorageService> _logger;
        public RedisStorageService(IDistributedCache distributedCache, ILogger<RedisStorageService> logger)
        {
            _distributedCache = distributedCache;
            _logger = logger;
        }
        public async Task<T> GetCacheDataAsync<T>(string key)
        {
            try
            {
                var jsonData = await _distributedCache.GetStringAsync(key);
                if (jsonData == null)
                {
                    _logger.LogInformation("Cache miss");
                    return default;
                }

                _logger.LogInformation("Cache hit, data: " + jsonData);

                // Ensure proper deserialization
                var deserializedObject = JsonConvert.DeserializeObject<T>(jsonData);
                _logger.LogInformation("Deserialized object: " + deserializedObject);

                return deserializedObject;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error during cache retrieval: " + ex.Message);
                throw;
            }
        }

        public async Task<string> GetCustomerAsync(string key)
        {
            var jsonData = await _distributedCache.GetStringAsync(key);
            _logger.LogInformation($"jsonData {jsonData}");
            if (jsonData == null)
            {
                _logger.LogInformation("Cache miss for key: " + key);
                return null;
            }
            try
            {
                // var customer = JsonConvert.DeserializeObject<MigratedCustomer>(jsonData);
                _logger.LogInformation("Successfully retrieved and deserialized customer for key: " + jsonData);
                return jsonData;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error during deserialization: " + ex.Message);
                throw;
            }
        }


        public async Task SetCacheDataAsync(string key, object value)
        {
            var jsonData = JsonConvert.SerializeObject(value);
            _logger.LogInformation("Serialized data: " + jsonData);
            var options = new DistributedCacheEntryOptions
            { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) };
            await _distributedCache.SetStringAsync(key, jsonData, options);
            /*  
            var jsonData = JsonConvert.SerializeObject(value); 
            var options = new DistributedCacheEntryOptions
            { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) };
            await _distributedCache.SetStringAsync(key, jsonData, options);
            */
        }

        public async Task SetTokenAndRefreshTokenCacheDataAsync(string key, object value, int time)
        {
            var jsonData = JsonConvert.SerializeObject(value);
            _logger.LogInformation("Serialized data: " + jsonData);
            var options = new DistributedCacheEntryOptions
            { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(time) };
            await _distributedCache.SetStringAsync(key, jsonData, options);
        }

        public async Task RemoveCustomerAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }
    }
}
