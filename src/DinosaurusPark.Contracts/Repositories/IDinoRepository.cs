using System.Collections.Generic;
using System.Threading.Tasks;
using DinosaurusPark.Contracts.Models;

namespace DinosaurusPark.Contracts.Repositories
{
    public interface IDinoRepository
    {
        Task<Dinosaur> GetById(int id);
        Task<IReadOnlyCollection<Dinosaur>> GetAll(int count, int offset);
    }
}