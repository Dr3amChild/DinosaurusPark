using Refit;
using System.Threading.Tasks;

namespace DinosaurusPark.IntegrationTests.Apis
{
    [Headers("Content-Type: application/json")]
    internal interface IDinosaurusControllerApi
    {
        [Get("/all?offset=${offset}&count=${count}")]
        Task<ApiResponse<T>> GetAll<T>(int count, int offset);
    }
}
