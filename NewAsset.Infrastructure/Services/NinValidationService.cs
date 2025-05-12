

using NewAsset.Application.Common.Constants;

namespace NewAsset.Infrastructure.Services
{
    public class NinValidationService : INinValidationService
    {
        private readonly ILogger<NinValidationService> _logger;
        private readonly IHttpService _httpService;

        public NinValidationService(ILogger<NinValidationService> logger, IHttpService httpService)
        {
            _logger = logger;
            _httpService = httpService;
        }

        public async Task<GenericApiResponse<string>> ValidateNinAsync(string nin, string inputBvn)
        {
            try
            {
                var token = await GetAccessTokenAsync();
                if (string.IsNullOrEmpty(token))
                    return GenericApiResponse<string>.FailureResponse(CustomerEnumResponse.NotSuccessful.ToString());

                var ninData = await GetNinDataAsync(nin, token);
                if (ninData?.response_code != "00" || ninData.ninData.residence_address?.ToLower().Contains("suspended") == true)
                    return GenericApiResponse<string>.FailureResponse(CustomerEnumResponse.InvalidNin.GetDescription());

                string ninFullName = $"{ninData.ninData.firstname} {ninData.ninData.surname} {ninData.ninData.middlename}";
                string ninDob = ninData.ninData.birthdate;

                var bvnData = await GetBvnDataAsync(inputBvn, token);
                if (bvnData == null)
                    return GenericApiResponse<string>.FailureResponse(CustomerEnumResponse.InvalidNin.GetDescription());

                bool nameMatch = AtLeastTwoNamesPresent(ninFullName, bvnData.data.firstName, bvnData.data.lastName, bvnData.data.middleName);

                if (!nameMatch)
                    return GenericApiResponse<string>.FailureResponse(CustomerEnumResponse.NameMisMatch.ToString());

                if (TryParseDate(bvnData.data.dateOfBirth, out var bvnDob) && TryParseDate(ninDob, out var ninParsedDob))
                {
                    if (bvnDob.Date == ninParsedDob.Date)
                        return GenericApiResponse<string>.SuccessResponse(CustomerEnumResponse.Successful.ToString());

                    return GenericApiResponse<string>.FailureResponse(CustomerEnumResponse.DateMismatch.GetDescription());
                }

                return GenericApiResponse<string>.FailureResponse(CustomerEnumResponse.InValidNin.GetDescription());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating NIN");
                return GenericApiResponse<string>.FailureResponse(CustomerEnumResponse.SystemError.GetDescription());
            }
        }
        private async Task<string> GetAccessTokenAsync()
        {
            var loginObj = new { username = "itservices@trustbancgroup.com", password = "trust@banc" };
            // string response = await _httpService.CallAsync(Method.POST, "http://localhost:8080/MFB_USSD/api/v1/user/login", loginObj);
            string response = await _httpService.CallServiceAsyncToString(Method.POST,Constant.TOKENACCESS, loginObj, true);
            var json = JObject.Parse(response);
            return json["response"]?["accessToken"]?.ToString() ?? string.Empty;
        }

        private async Task<NinValidationResponse> GetNinDataAsync(string nin, string token)
        {
            var request = new { number_nin = nin };
            var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };
            string response = await _httpService.CallServiceAsyncToString(Method.POST,Constant.NINVERFICATIONURL,request,true,headers);
            return JsonConvert.DeserializeObject<NinValidationResponse>(response);
        }

        private async Task<CustomerBvn> GetBvnDataAsync(string bvn, string token)
        {
            var request = new { bvn };
            var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };
            string response = await _httpService.CallServiceAsyncToString(Method.POST,Constant.BVNVERFICATIONURL, request,true, headers);
            return JsonConvert.DeserializeObject<CustomerBvn>(response);
        }

        private bool AtLeastTwoNamesPresent(string fullName, params string[] names)
        {
            var lowerFullName = fullName.ToLower();
            return names.Count(n => !string.IsNullOrWhiteSpace(n) && lowerFullName.Contains(n.ToLower())) >= 2;
        }

        private bool TryParseDate(string dateString, out DateTime date)
        {
            var formats = new[] { "dd-MMM-yyyy", "dd-MM-yyyy" };
            return DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
    }
}
