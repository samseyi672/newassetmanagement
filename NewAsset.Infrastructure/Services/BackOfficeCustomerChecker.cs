

using Microsoft.Extensions.Options;
using NewAsset.Infrastructure.Common;

namespace NewAsset.Infrastructure.Services
{

    /// <summary>
    ///  The implementation service is used if a customer exists in the assetmanagement back office
    ///  with the vendor
    /// </summary>
    public class BackOfficeCustomerChecker : IBackOfficeCustomerChecker
    {
        private readonly IHttpService _httpService;
        private readonly ISimplexMiddleApiService _simplexMiddleService;
        private readonly ILogger<BackOfficeCustomerChecker> _logger;
        private readonly AssetSimplexConfig _settings;
        public BackOfficeCustomerChecker(IOptions<AssetSimplexConfig> settings,IHttpService httpService, ISimplexMiddleApiService simplexMiddleService)
        {
            _httpService = httpService;
            _simplexMiddleService = simplexMiddleService;
            _settings = settings.Value;
        }

        public async Task<GenericApiResponse<SimplexCustomerCheckerResponse>> IsCustomerExistInBackOffice(string Email, string UserType)
        {
            string token2 = await _simplexMiddleService.GetToken();
            if (string.IsNullOrEmpty(token2))
            {
                token2 = await _simplexMiddleService.SetAPIToken();
            }
            if (string.IsNullOrEmpty(token2))
            {
                return GenericApiResponse<SimplexCustomerCheckerResponse>.FailureResponse(CustomerEnumResponse.RedisError.GetDescription());
            }
            IDictionary<string, string> header = new Dictionary<string, string>();
            header.Add("token", token2.Split(':')[0]);
            header.Add("xibsapisecret", "");
            var CustomerChecker = new SimplexCustomerChecker();
            CustomerChecker.email = Email;
            CustomerChecker.UserType = UserType;
            string response = await _httpService.CallServiceAsyncToString(Method.POST, _settings.middlewarecustomerurl + "api/Customer/CheckIfCustomerExist", CustomerChecker, true, header);
            _logger.LogInformation("response from customer checker " + response);
            if (string.IsNullOrEmpty(response))
            {
                return GenericApiResponse<SimplexCustomerCheckerResponse>.FailureResponse(CustomerEnumResponse.CustomerValidationUnSuccessful.GetDescription());
            }
            // SimplexCustomerCheckerResponse simplexCustomerCheckerResponse4 = JsonConvert.DeserializeObject<SimplexCustomerCheckerResponse>(response);
            var genericResponse2 = JsonConvert.DeserializeObject<GenericResponse2>(response);
            SimplexCustomerCheckerResponse simplexCustomerCheckerResponse4 = JsonConvert.DeserializeObject<SimplexCustomerCheckerResponse>((string)genericResponse2.data);
            if (!simplexCustomerCheckerResponse4.data.exists && simplexCustomerCheckerResponse4.message.ToLower().Contains("Customer has multiple account with this email address".ToLower()))
            {
                return GenericApiResponse<SimplexCustomerCheckerResponse>.FailureResponse(CustomerEnumResponse.CustomerValidationUnSuccessful.GetDescription());
            }
            if (genericResponse2 == null)
            {
                return GenericApiResponse<SimplexCustomerCheckerResponse>.FailureResponse(CustomerEnumResponse.CustomerValidationUnSuccessful.GetDescription());
            }
            if (!genericResponse2.Success)
            {
                return GenericApiResponse<SimplexCustomerCheckerResponse>.FailureResponse(CustomerEnumResponse.CustomerValidationUnSuccessful.GetDescription());
            }
            return GenericApiResponse<SimplexCustomerCheckerResponse>.SuccessResponse(simplexCustomerCheckerResponse4, CustomerEnumResponse.CustomerValidationUnSuccessful.GetDescription());
        }
    }
}













