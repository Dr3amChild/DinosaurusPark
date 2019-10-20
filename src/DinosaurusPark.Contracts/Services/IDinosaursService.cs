using DinosaurusPark.Contracts.Models;
using System.Threading.Tasks;

namespace DinosaurusPark.Contracts.Services
{
    public interface IDinosaursService
    {
        Task<PagingResult<TItem>> Get<TItem>(int pageNumber, int pageSize);
    }
}