
namespace NewAsset.Application.Common.Interfaces.iservices
{
    public interface IHttpService
    {
        Task<string> CallServiceAsyncToString(Method method, string url, object requestobject, bool log = false, IDictionary<string, string> header = null);
        Task<T> CallServiceAsync<T>(Method method, string url, object requestobject, bool log = false, IDictionary<string, string> header = null) where T : class;
    }
}
