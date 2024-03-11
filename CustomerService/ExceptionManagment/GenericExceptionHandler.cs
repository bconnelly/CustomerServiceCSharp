using Microsoft.AspNetCore.Diagnostics;

namespace CustomersService.ExceptionManagment
{
    public class GenericExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse()
            {
                statusCode = httpContext.Response.StatusCode,
                message = exception.Message
            };

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
