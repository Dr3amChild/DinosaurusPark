using DinosaursPark.Contracts.Models;
using System.Threading.Tasks;

namespace DinosaursPark.Contracts.Services
{
    public interface IDinosaursService
    {
        Task<TItem> Get<TItem>(int id);

        Task<PagingResult<TItem>> Get<TItem>(int pageNumber, int pageSize);
    }
}