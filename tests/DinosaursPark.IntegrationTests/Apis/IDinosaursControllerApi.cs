using Refit;
using System.Threading.Tasks;

namespace DinosaursPark.IntegrationTests.Apis
{
    [Headers("Content-Type: application/json")]
    internal interface IDinosaursControllerApi
    {
        [Get("/all?pageNumber={pageNumber}&pageSize={pageSize}")]
        Task<ApiResponse<T>> GetAll<T>(int pageNumber, int pageSize);

        [Get("/get?id={id}")]
        Task<ApiResponse<T>> GetById<T>(int? id);
    }
}
