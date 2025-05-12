
namespace NewAsset.Application.Common.Interfaces.iservices
{
    public interface IRedisStorageService
    {
        Task SetCacheDataAsync(string key, object value);
        Task<T> GetCacheDataAsync<T>(string key);
        Task<string> GetCustomerAsync(string key);
        Task SetTokenAndRefreshTokenCacheDataAsync(string key, object value, int time);
        Task RemoveCustomerAsync(string key);
    }
}
