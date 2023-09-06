using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Blog.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class UnhandledRouteMiddleware
    {
        private readonly RequestDelegate _next;

        public UnhandledRouteMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            await _next(httpContext);

            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                // Handle the case when no route or action matches
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                httpContext.Response.ContentType = "application/json";

                var returnedObject = new
                {
                    errorId = Guid.NewGuid(),
                    message = $"{httpContext.Request.Path} does not exist",
                    innerMessage = "",
                };

                var result = JsonConvert.SerializeObject(returnedObject);
                await httpContext.Response.WriteAsync(result);
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UnhandledRouteMiddlewareExtensions
    {
        public static IApplicationBuilder UseUnhandledRouteMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UnhandledRouteMiddleware>();
        }
    }
}
