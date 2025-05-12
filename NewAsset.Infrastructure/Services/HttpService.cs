
namespace NewAsset.Infrastructure.Services
{
    public class HttpService : IHttpService
    {
        private readonly ILogger<NinValidationService> _logger;

        public HttpService(ILogger<NinValidationService> logger)
        {
            _logger = logger;
        }

        public async Task<string> CallServiceAsyncToString(Method method, string url, object requestobject, bool log = false, IDictionary<string, string> header = null)
        {

                try
                {
                    _logger.LogInformation("Enters CallServiceAsync: " + url);
                    _logger.LogInformation("API Request: " + (requestobject != null ? JsonConvert.SerializeObject(requestobject) : requestobject));
                    var client = new RestClient(url);
                    var request = new RestRequest(method);

                    if (method == Method.POST)
                    {
                        if (requestobject != null)
                        {
                            request.AddParameter("application/json", JsonConvert.SerializeObject(requestobject), ParameterType.RequestBody);
                            request.AddHeader("Content-Type", "application/json");
                        }
                    }

                    if (header != null)
                    {
                        foreach (var item in header)
                        {
                            request.AddHeader(item.Key, item.Value);
                        }
                        _logger.LogInformation("Header added.");
                    }
                    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                    IRestResponse response = await client.ExecuteAsync(request);
                    if (log)
                    {
                        _logger.LogInformation("API Response: " + response.Content);
                    }
                    return response.Content;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error calling service.");
                     throw new NetworkRequestException("Service is not reachable");
                }
            }
        }
}
