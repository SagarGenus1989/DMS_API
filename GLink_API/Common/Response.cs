namespace GLink_API.Common
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(int statusCode, string? message, T? result)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }
}
