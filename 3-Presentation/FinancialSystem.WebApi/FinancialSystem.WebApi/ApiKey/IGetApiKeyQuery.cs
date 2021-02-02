using System.Threading.Tasks;

namespace FinancialSystem.WebApi.ApiKey
{
    public interface IGetApiKeyQuery
    {
        Task<ApiKey> Execute(string providedApiKey);
    }
}