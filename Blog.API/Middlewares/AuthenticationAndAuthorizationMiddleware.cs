using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Blog.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticationAndAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationAndAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);

            if (httpContext.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                // Handle authentication error (e.g., return a custom 401 response)
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                httpContext.Response.ContentType = "application/json";

                var returnedObject = new
                {
                    errorId = Guid.NewGuid(),
                    message = $"Please Login Or Sign Up To Get Access",
                    innerMessage = "",
                };

                var result = JsonConvert.SerializeObject(returnedObject);
                await httpContext.Response.WriteAsync(result);
            }
            else if(httpContext.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                // Handle authorization error (e.g., return a custom 403 response)
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                httpContext.Response.ContentType = "application/json";

                var returnedObject = new
                {
                    errorId = Guid.NewGuid(),
                    message = $"You Don't Have Permission to Access this Route",
                    innerMessage = "",
                };

                var result = JsonConvert.SerializeObject(returnedObject);
                await httpContext.Response.WriteAsync(result);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticationAndAuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationAndAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationAndAuthorizationMiddleware>();
        }
    }
}
