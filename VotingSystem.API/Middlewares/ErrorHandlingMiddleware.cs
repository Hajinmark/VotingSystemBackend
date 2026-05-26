using System.Net;
using System.Text.Json;
using VotingSystem.Application.Exceptions;

namespace VotingSystem.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (exception)
            {
                case NotFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;

                case CustomValidationException customValidationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(customValidationException);
                    break;

                case AlreadyExistsException alreadyExistsException:
                    httpStatusCode = HttpStatusCode.Conflict;
                    result = JsonSerializer.Serialize(new
                    {
                        message = exception.Message
                    });
                    break;

            }
            context.Response.StatusCode = (int)httpStatusCode;

            return context.Response.WriteAsync(result);
        }
    }

    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}

