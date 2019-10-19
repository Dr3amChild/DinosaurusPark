using DinosaurusPark.Contracts.Models;
using System.Threading.Tasks;

namespace DinosaurusPark.Contracts.Services
{
    public interface IDinosaursService
    {
        Task<PagingResult<Dinosaur>> Get(int pageNumber, int pageSize);
    }
}