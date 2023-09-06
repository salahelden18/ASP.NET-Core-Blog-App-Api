using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models.Errors
{
    public class InternalServerException : Exception
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.InternalServerError;

        public InternalServerException(string message) : base(message) { }
    }
}
