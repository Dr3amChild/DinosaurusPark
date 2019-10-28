using Refit;
using System.Threading.Tasks;

namespace DinosaurusPark.IntegrationTests.Apis
{
    [Headers("Content-Type: application/json")]
    internal interface IDinosaurusControllerApi
    {
        [Get("/all?pageNumber={pageNumber}&pageSize={pageSize}")]
        Task<ApiResponse<T>> GetAll<T>(int pageNumber, int pageSize);

        [Get("/get?id={id}")]
        Task<ApiResponse<T>> GetById<T>(int? id);
    }
}
