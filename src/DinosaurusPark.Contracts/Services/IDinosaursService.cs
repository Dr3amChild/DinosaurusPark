using DinosaurusPark.Contracts.Models;
using System.Threading.Tasks;

namespace DinosaurusPark.Contracts.Services
{
    public interface IDinosaursService
    {
        Task<TItem> Get<TItem>(int id);

        Task<PagingResult<TItem>> Get<TItem>(int pageNumber, int pageSize);
    }
}