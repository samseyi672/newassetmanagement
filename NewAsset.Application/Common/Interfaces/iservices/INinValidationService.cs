

namespace NewAsset.Application.Common.Interfaces.iservices
{
    public interface INinValidationService
    {
        Task<GenericApiResponse<string>> ValidateNinAsync(string nin, string inputBvn);
    }
}
