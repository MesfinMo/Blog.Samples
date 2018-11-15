using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DNC.Core.Domain.Common
{
    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }
    }
}
