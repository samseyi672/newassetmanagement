using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Application.Common.dtos.response
{

    /// <summary>
    /// Generic Response class to return Response from Endpoints
    /// </summary>
    public class GenericApiResponse<T>
    {
        public bool Success { get; set; }
        public string ResponseMessage { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static GenericApiResponse<T> SuccessResponse(T data, string message = "Success")
        {
            return new GenericApiResponse<T>
            {
                Success = true,
                ResponseMessage = message,
                Data = data
            };
        }

        public static GenericApiResponse<T> FailureResponse(string message = "Something went wrong")
        {
            return new GenericApiResponse<T>
            {
                Success = false,
                ResponseMessage = message,
                Data = default
            };
        }
    }

}
