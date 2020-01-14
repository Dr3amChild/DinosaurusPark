using DinosaursPark.IntegrationTests.Requests;
using Refit;
using System.Threading.Tasks;

namespace DinosaursPark.IntegrationTests.Apis
{
    [Headers("Content-Type: application/json")]
    internal interface IInformationControllerApi
    {
        [Get("/information/park")]
        Task<ApiResponse<T>> GetParkInfo<T>();

        [Get("/information/species")]
        Task<ApiResponse<T>> GetSpeciesInfo<T>();
    }
}