using Common.Data.Interfaces;
using System.Net;

namespace Common.Data.Exceptions
{
    public class NotFoundException : Exception, ICustomException
    {
        public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public NotFoundException() { }

        public NotFoundException(string name, object key)
        {
            this.StatusCode = HttpStatusCode.NotFound;
            this.ErrorMessage = $"Entity \"{name}\" ({key}) was not found.";
        }
    }
}
