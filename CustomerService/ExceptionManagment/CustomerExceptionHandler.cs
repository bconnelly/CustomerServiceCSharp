using Microsoft.AspNetCore.Diagnostics;
using System.Data;
using System.Data.Entity.Core;

namespace CustomersService.ExceptionManagment
{
    public class CustomerExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse()
            {
                statusCode = httpContext.Response.StatusCode,
                message = exception.Message
            };

            if(exception is ObjectNotFoundException || (exception is InvalidOperationException && exception.Message == "Sequence contains no elements"))
            {
                response.title = "customer not found";

                await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

                return true;

            } else if(exception is DuplicateNameException)
            {
                response.title = "customer already present. names must be unique";

                await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

                return true;
            }

            return false;
        }
    }
}
