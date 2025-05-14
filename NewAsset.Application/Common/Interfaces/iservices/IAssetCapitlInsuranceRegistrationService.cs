

namespace NewAsset.Application.Common.Interfaces.iservices
{
    public interface IAssetCapitlInsuranceRegistrationService
    {
        Task<GenericApiResponse<string>> ValidateUserName(string username, string UserType);
        Task<GenericApiResponse<string>> CreateUserName(SetRegristationCredential Request, string UserType);
        Task<GenericApiResponse<string>> CreatePassword(SavePasswordRequest Request, string UserType);
        Task<GenericApiResponse<string>> CreateTransPin(SavePasswordRequest Request, string UserType);
        Task<GenericApiResponse<RegistrationResponse>> StartRegistration(AssetCapitalInsuranceRegistrationRequest Request);
        Task<GenericApiResponse<RegistrationResponse>> GetByReferenceAsync(string reference);
    }
}
