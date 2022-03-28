using System.Net;

namespace Common.Data.Interfaces
{
    public interface ICustomException
    {
        public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
