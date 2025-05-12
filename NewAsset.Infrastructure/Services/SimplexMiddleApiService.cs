
namespace NewAsset.Infrastructure.Services
{

    /// <summary>
    ///  Implmentation to get credentials that validate api call
    ///  to simplex service
    /// </summary>
    public class SimplexMiddleApiService : ISimplexMiddleApiService
    {
        private readonly IRedisStorageService _redisStorageService;
        public async Task<string> GetToken()
        {
            // get token from redis
            string token = null;
            if ((await _redisStorageService.GetCacheDataAsync<string>("TokenAndRefreshToken")) != null)
            {
                token = await _redisStorageService.GetCacheDataAsync<string>("TokenAndRefreshToken");
            }
            return token;
        }

        public Task<string> SetAPIToken()
        {
            throw new NotImplementedException();
        }
    }
}
