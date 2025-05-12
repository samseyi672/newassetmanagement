

namespace NewAsset.Application.Common.Interfaces.iservices
{

    /// <summary>
    ///  The abstraction service is used if a customer exists in the assetmanagement back office
    ///  with the vendor
    /// </summary>
    public interface IBackOfficeCustomerChecker
    {
        Task<GenericApiResponse<SimplexCustomerCheckerResponse>> IsCustomerExistInBackOffice(string Email, string UserType);
    }
}
