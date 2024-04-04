using Microsoft.AspNetCore.Http;
using System.Net;

namespace APIController
{
    public class ExceptionUsingMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionUsingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsync(new GlobalErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = "Something went wrong !Internal Server Error"
                }.ToString());
            }
        }

        
    }
}
