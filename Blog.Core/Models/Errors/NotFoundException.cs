using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models.Errors
{
    public class NotFoundException : Exception
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;

        public NotFoundException(string message) : base(message) { }
    }
}
