using System.Net;

namespace WebApplication1.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
