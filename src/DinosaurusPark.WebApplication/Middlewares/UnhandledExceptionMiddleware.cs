using DinosaurusPark.WebApplication.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DinosaurusPark.WebApplication.Middlewares
{
    public class UnhandledExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<UnhandledExceptionMiddleware> _logger;

        public UnhandledExceptionMiddleware(RequestDelegate next, ILogger<UnhandledExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new { error = ErrorCodes.InternalServerError });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            _logger.LogError(ex, "Unhandled error occured");
            return context.Response.WriteAsync(result);
        }
    }
}
