using System.Net;

namespace Services.Shared.Models
{
    public class ApiResult
    {
        public ApiResult()
        {

        }

        public ApiResult(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            Data = "";
        }

        public ApiResult(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public ApiResult(HttpStatusCode statusCode, int totalDataCount = 0)
        {
            StatusCode = statusCode;
            TotalDataCount = totalDataCount;
        }

        public ApiResult(HttpStatusCode statusCode, object data, string message = "", int totalDataCount = 0)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
            TotalDataCount = totalDataCount;
        }

        public HttpStatusCode StatusCode { get; }
        public object Data { get; }
        public string Message { get; set; }
        public int TotalDataCount { get; set; }
    }
}