
namespace EHealth.BusinessLogic.Models
{
    public class Response
    {
        public Response()
        {
        }

        private Response(bool success)
        {
            Success = success;
        }

        internal Response(bool success, int statusCode) : this(success)
        {
            StatusCode = statusCode;
        }

        internal Response(bool success, ResponseCode statusCode) : this(success)
        {
            StatusCode = (int)statusCode;
        }

        public bool Success { get; set; }

        public int StatusCode { get; set; }

        public static bool IsSuccessful(Response response)
        {
            return response != null && response.Success;
        }
    }

    public class Response<T> : Response
        where T : class
    {
        public Response()
        {
        }

        internal Response(bool success, int statusCode, T data) : base(success, statusCode)
        {
            StatusCode = statusCode;
            Data = data;
        }

        internal Response(bool success, ResponseCode statusCode, T data) : base(success, statusCode)
        {
            StatusCode = (int)statusCode;
            Data = data;
        }

        public T Data { get; set; }
    }
}