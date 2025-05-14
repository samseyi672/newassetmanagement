
namespace NewAsset.Infrastructure.Services
{
    public class HttpService : IHttpService
    {
        private readonly ILogger<HttpService> _logger;
        private readonly AppSettings _appSettings;

        public HttpService(ILogger<HttpService> logger,IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
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
        public async Task<T> CallServiceAsync<T>(Method method, string url, object requestobject, bool log = false, IDictionary<string, string> header = null) where T : class
        {
            try
            {
                Console.WriteLine("enters CallServiceAsync " + url);
                // Console.WriteLine($"API Request - url {url}");
                var client = new RestClient(url);
                var request = new RestRequest(method);
                if (method == Method.POST)
                {
                    request.AddParameter("application/json", JsonConvert.SerializeObject(requestobject), ParameterType.RequestBody);
                    request.AddHeader("Content-Type", "application/json");
                }

                if (header != null)
                    foreach (var item in header)
                        request.AddHeader(item.Key, item.Value);
                _logger.LogInformation("header added");

                ServicePointManager
                .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;

                _logger.LogInformation("API Call - " + url);
                // Console.WriteLine("API Call - " + url);
                if (requestobject != null)
                {
                    _logger.LogInformation("API Request - " + JsonConvert.SerializeObject(requestobject));
                }
                IRestResponse response = await client.ExecuteAsync(request);
                if (log)
                {
                    _logger.LogInformation("API Response - " + JsonConvert.SerializeObject(response.Content));
                }
                object resObj = null;
                // JsonStringProcessor.processError(JsonConvert.SerializeObject(response.Content));
                var token = JToken.Parse(response.Content);
                if (token is JObject)
                {
                    var json = (JObject)token;
                    // _logger.LogInformation("json " + json + " status " + json.ContainsKey("status"));

                    if (json.ContainsKey("trustBancRef") && json.ContainsKey("resp"))
                    {
                        _logger.LogInformation(" trustBancRef " + json.ContainsKey("trustBancRef"));
                        resObj = new
                        {
                            processingID = json["resp"] != null && json["resp"].Type != JTokenType.Null ? json["resp"]["requestID"].ToString() : "",
                            success = json["success"] != null && json["success"].Type != JTokenType.Null ? bool.Parse(json["success"].ToString()) : false,
                            message = json["resp"] != null && json["resp"].Type != JTokenType.Null ? json["resp"]["retmsg"].ToString() : ""
                        };
                        var model2 = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(resObj));
                        return model2;
                    }
                    if (json.ContainsKey("transactioResponse"))
                    {
                        _logger.LogInformation("sending model out ....");

                        resObj = new
                        {
                            processingID = json["transactioResponse"] != null && json["transactioResponse"].Type != JTokenType.Null ? json["transactioResponse"]["requestID"].ToString() : "",
                            success = json["status"] != null && json["status"].Type != JTokenType.Null ? bool.Parse(json["status"].ToString()) : false,
                            message = json["transactioResponse"] != null && json["transactioResponse"].Type != JTokenType.Null ? json["transactioResponse"]["retMsg"].ToString() : "",
                            tranAmt = json["transactioResponse"] != null && json["transactioResponse"].Type != JTokenType.Null ? json["transactioResponse"]["tranAmt"].ToString() : "",
                            postDate = json["transactioResponse"] != null && json["transactioResponse"].Type != JTokenType.Null ? json["transactioResponse"]["postdate"].ToString() : "",
                        };
                        // _logger.LogInformation("sending model out ....");
                        var model2 = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(resObj));
                        //Console.WriteLine("model2 .. " + JsonConvert.SerializeObject(model2));
                        _logger.LogInformation("transactionResponse model2 .. " + JsonConvert.SerializeObject(model2));
                        return model2;
                    }
                }
                else if (token is JArray)
                {
                    JArray jsonArray = (JArray)token;
                    var jsonObject = jsonArray.Children<JObject>().First();
                    if (jsonObject.ContainsKey("transactioResponse"))
                    {
                        resObj = new
                        {
                            processingID = jsonObject["transactioResponse"] != null && jsonObject["transactioResponse"].Type != JTokenType.Null ? jsonObject["transactioResponse"]["requestID"].ToString() : "",
                            success = jsonObject["status"] != null && jsonObject["status"].Type != JTokenType.Null ? bool.Parse(jsonObject["status"].ToString()) : false,
                            message = jsonObject["transactioResponse"] != null && jsonObject["transactioResponse"].Type != JTokenType.Null ? jsonObject["transactioResponse"]["retMsg"].ToString() : "",
                            TranAmt = jsonObject["transactioResponse"] != null && jsonObject["transactioResponse"].Type != JTokenType.Null ? jsonObject["transactioResponse"]["tranAmt"].ToString() : ""
                        };
                        var model2 = JsonConvert.DeserializeObject<T>(System.Text.Json.JsonSerializer.Serialize(resObj, new JsonSerializerOptions { WriteIndented = true }));
                        // _logger.LogInformation("json array model2 .. " + JsonConvert.SerializeObject(model2));
                        model2 = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(model2));
                        return model2;
                    }

                }
                var model = JsonConvert.DeserializeObject<T>(response.Content);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
                throw new NetworkRequestException(ex.Message);
            }
        }
    }
}
