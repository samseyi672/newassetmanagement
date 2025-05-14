

namespace NewAsset.Infrastructure.Services
{
    public class CoreBankingService : ICoreBankingService
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpService _httpService;
        private readonly ILogger<CoreBankingService> _logger;

        public CoreBankingService(IOptions<AppSettings> appSettings, IHttpService httpService, ILogger<CoreBankingService> logger)
        {
            _appSettings = appSettings.Value;
            _httpService = httpService;
            _logger = logger;
        }

        public async Task<FinedgeSearchBvn> AssetCapitalInsuranceCheckCbaByBvn(string Bvn)
        {
            try
            {
                var header = new Dictionary<string, string>
                    {
                        { "ClientKey",_appSettings.FinedgeKey }
                    };
                var resp = await _httpService.CallServiceAsync<FinedgeSearchBvn>(Method.GET, $"{_appSettings.FinedgeUrl}api/enquiry/SearchCustomerbyBvn/{Bvn}", null, true, header);
                Console.WriteLine($" resp.success {resp}");
                return resp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
                 throw new NetworkRequestException(ex.Message);
            }
        }
        public async Task<ValidateBvn> ValidateAssetCapitalInsuranceBvn(string Bvn,IUnitOfWork unitOfWork)
        {
            try
            {
                var bvn = unitOfWork.GetRepository<IBvnValidationRepository>().GetBvnValidationByBvn(Bvn);
                if (bvn != null)
                {
                    var bvndetails = new BvnResp()
                    {
                        Firstname = bvn.FIRSTNAME,
                        Middlename = bvn.MIDDLENAME,
                        Lastname = bvn.LASTNAME,
                        Email = bvn.EMAIL,
                        PhoneNumber = bvn.PHONENUMBER
                    };

                    return new ValidateBvn()
                    {
                        BvnDetails = bvndetails,
                        Response = CustomerEnumResponse.Successful,
                        Success = true
                    };
                }

                var header = new Dictionary<string, string>
                {
                    { "ClientKey", _appSettings.BvnKey }
                };
                _logger.LogInformation("going to call raw bvn endpoint ..");
                var resp = await _httpService.CallServiceAsync<BvnResponse>(Method.GET, $"{_appSettings.BvnUrl}api/bvn/ValidateBvnFull/{Bvn}", null, true, header);

                if (resp.ResponseCode != "00")
                    return new ValidateBvn() { Response = CustomerEnumResponse.NotSuccessful };
                _logger.LogInformation("bvn inserted ..");
                //await InsertAssetCapitalInsuranceBvn(resp, con);
                unitOfWork.GetRepository<IBvnValidationRepository>().AddBvnValidation(new BvnValidation()
                {
                    BVN = resp.bvn,
                    PHONENUMBER = resp.phoneNumber,
                    PHONENUMBER2 = resp.secondaryPhoneNumber,
                    EMAIL = resp.email,
                    GENDER = resp.gender,
                    LgaResidence = resp.lgaOfResidence,
                    LgaOrigin = resp.lgaOfOrigin,
                    MARITALSTATUS = resp.maritalStatus,
                    NATIONALITY = resp.nationality,
                    RESIDENTIALADDRESS = resp.residentialAddress,
                    STATEORIGIN = resp.stateOfOrigin,
                    StateResidence = resp.stateOfResidence,
                    DOB = ConvertDatetime(resp.dateOfBirth),
                    FIRSTNAME = resp.firstName,
                    MIDDLENAME = resp.middleName,
                    LASTNAME = resp.lastName
                });
                return new ValidateBvn()
                {
                    Response = CustomerEnumResponse.Successful,
                    Success = true,
                    BvnDetails = new BvnResp()
                    {
                        Firstname = resp.firstName,
                        Middlename = resp.middleName,
                        Lastname = resp.lastName,
                        Email = resp.email,
                        PhoneNumber = resp.phoneNumber
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
                return new ValidateBvn() { Response = CustomerEnumResponse.Successful };
            }
        }
        public DateTime ConvertDatetime(string dtstring)
        {
            try
            {
                if (string.IsNullOrEmpty(dtstring))
                    return DateTime.Now;

                string[] format = new string[] { "yyyy-MM-dd", "yyyy-MM-dd HH-mm-ss", "yyyy-MM-dd hh-mm-ss tt", "MM/dd/yyyy", "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy", "dd-MMM-yyyy", "dd/MMM/yyyy", "dd/MM/yyyy", "ddMMMyyyy", "dd-MM-yyyy", "yyyy-MM-ddThh:mm:ss.fff", "dd/MM/yyyy hh:mm:ss tt" };
                foreach (string s in format)
                    try
                    {
                        DateTime dt = DateTime.ParseExact(dtstring.Trim().ToUpper(), s, CultureInfo.InvariantCulture);
                        return dt;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                return DateTime.Now;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace);
                return DateTime.Now;
            }
        }
    }
}

