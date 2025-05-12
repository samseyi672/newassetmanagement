


using NewAsset.Application.Common.Utilities;

namespace NewAsset.Application.fliters
{


    /// <summary>
    /// A filter class to centrally validate usertype if passed a query or path
    /// </summary>
    public class ValidateUserTypeAttribute : ActionFilterAttribute
    {
        /*
        private static readonly HashSet<string> Allowed = new(StringComparer.OrdinalIgnoreCase)
        {
            "asset",
            "capital",
            "insurance"
        };
        */

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("userType", out var value))
            {
                var userType = value?.ToString()?.Trim();

               // if (string.IsNullOrWhiteSpace(userType) || !Allowed.Contains(userType))
                 if(UserTypes.IsValid(userType))
                {
                    var response = GenericApiResponse<object>.FailureResponse("Invalid user type. Allowed: asset, capital, insurance.");
                    context.Result = new BadRequestObjectResult(response);
                }
            }
        }
    }

}
