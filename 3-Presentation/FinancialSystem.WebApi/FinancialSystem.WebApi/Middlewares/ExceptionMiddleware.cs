using System;
using System.Threading.Tasks;
using FinancialSystem.Common.Exceptions;
using FinancialSystem.WebApi.Helpers;
using Microsoft.AspNetCore.Http;

namespace FinancialSystem.WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (UnauthorizedAccessException e)
            {
                await _next(await httpContext.SetResponse(StatusCodes.Status401Unauthorized, e.Message));
            }
            catch (ForbiddenException e)
            {
                await _next(await httpContext.SetResponse(StatusCodes.Status403Forbidden, e.Message));
            }
            catch (BadRequestException e)
            {
                await _next(await httpContext.SetResponse(StatusCodes.Status400BadRequest, e.Message));
            }
            catch (NotFoundException)
            {
                await _next(await httpContext.SetResponse(StatusCodes.Status404NotFound, ExceptionMessageKeys.NotFound));
            }
            catch (Exception)
            {
                await _next(await httpContext.SetResponse(StatusCodes.Status500InternalServerError, ExceptionMessageKeys.GeneralException));
            }
        }
    }
}