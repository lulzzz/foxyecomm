using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FoxyEcomm.Common.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            
        }
        public ApiResponse(HttpStatusCode statusCode, T result, List<string> errors = null)
        {
            StatusCode = (int)statusCode;
            Data = result;
            Errors = errors;
        }
        public List<string> Errors { get; set; }
        public string Version => "1.0";

        public int StatusCode { get; set; }
        

        public T Data { get; set; }

        public bool HasError => Errors != null && Errors.Any();
    }
}
