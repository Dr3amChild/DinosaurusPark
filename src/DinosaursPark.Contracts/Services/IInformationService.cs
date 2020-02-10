using DinosaursPark.Contracts.Models;
using System.Threading.Tasks;

namespace DinosaursPark.Contracts.Services
{
    public interface IInformationService
    {
        Task<TItem> GetParkInfo<TItem>();

        Task<PagingResult<TItem>> GetSpeciesInfo<TItem>(int pageNumber, int pageSize);

        Task DeleteAll();
    }
}