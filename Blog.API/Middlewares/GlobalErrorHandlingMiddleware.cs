using Blog.Core.Models.Errors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace Blog.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
               await _next(httpContext);
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Error" ,ex.ToString());
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex) 
        {
            string message;
            int status;

            switch(ex)
            {
                case NotFoundException notfound:
                    message = notfound.Message;
                    status = notfound.StatusCode;
                    break;
                case BadRequestException badRequest:
                    message = badRequest.Message;
                    status = badRequest.StatusCode;
                    break;
                case InternalServerException internalServer:
                    message = internalServer.Message;
                    status = internalServer.StatusCode;
                    break;
                default:
                    message = ex.Message ?? "Something Went Wrong";
                    status = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.StatusCode = status;
            context.Response.ContentType = "application/json";

            var returnedObject = new
            {
                errorId = Guid.NewGuid(),
                message,
                innerMessage = ex.InnerException?.Message,
            };

            var result = JsonConvert.SerializeObject(returnedObject);
            await context.Response.WriteAsync(result);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalErrorHandlingMiddleware>();
        }
    }
}
