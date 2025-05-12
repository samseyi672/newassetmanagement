

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NewAsset.Application.fliters
{

    /// <summary>
    /// The Middleware to manage validation erros globally instead of 
    /// handling per controller 
    /// </summary>
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(kvp => kvp.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                var response = GenericApiResponse<object>.FailureResponse("Validation failed");
                response.Data = errors;

                //context.Result = new BadRequestObjectResult(response);
                context.Result = new ObjectResult(response)
                {
                    StatusCode = StatusCodes.Status422UnprocessableEntity
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }

}
