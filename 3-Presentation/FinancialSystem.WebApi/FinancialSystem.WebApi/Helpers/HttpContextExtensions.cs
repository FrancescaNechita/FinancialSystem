using System.Text;
using System.Threading.Tasks;
using FinancialSystem.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FinancialSystem.WebApi.Helpers
{
    public static class HttpContextExtensions
    {
        internal static async Task<HttpContext> SetResponse(this HttpContext httpContext, int statusCode, string message)
        {
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = @"application/json";

            var response = new ExceptionDto(message);

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var jsonResponse = JsonConvert.SerializeObject(response, serializerSettings);
            await httpContext.Response.WriteAsync(jsonResponse, Encoding.UTF8);

            return httpContext;
        }

    }
}