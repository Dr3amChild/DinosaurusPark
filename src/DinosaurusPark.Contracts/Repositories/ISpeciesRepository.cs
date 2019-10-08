using DinosaurusPark.Contracts.Models;
using System.Threading.Tasks;

namespace DinosaurusPark.Contracts.Repositories
{
    public interface ISpeciesRepository
    {
        Task<Species> GetById(int id);
        Task Save(params Species[] species);
    }
}