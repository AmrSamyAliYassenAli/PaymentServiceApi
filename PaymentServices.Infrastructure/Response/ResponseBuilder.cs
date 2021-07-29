using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Infrastructure.Response
{
    public class ResponseBuilder
    {
        public static ResponseBuilder Create(HttpStatusCode statusCode, object result = null, object errorMessage = null)
        {
            return new ResponseBuilder(statusCode, result, errorMessage);
        }

        public string requestId { get; }

        public object error { get; set; }

        public object data { get; set; }

        public object success { get; set; }

        protected ResponseBuilder(HttpStatusCode statusCode, object result = null, object errorMessage = null)
        {
            requestId = Guid.NewGuid().ToString();
            success = ((int)statusCode) == 200 ? 1 : 0;
            data = result;
            error = errorMessage != null ? errorMessage : new string[] { };
        }
    }
}
