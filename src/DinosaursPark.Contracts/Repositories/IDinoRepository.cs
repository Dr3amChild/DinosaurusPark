using System.Collections.Generic;
using System.Threading.Tasks;
using DinosaursPark.Contracts.Models;

namespace DinosaursPark.Contracts.Repositories
{
    public interface IDinoRepository
    {
        Task<Dinosaur> GetById(int id);
        Task<IReadOnlyCollection<Dinosaur>> GetAll(int count, int offset);
        Task<int> GetCount();
        Task AddSpecies(params Species[] species);
        Task AddDinosaurs(params Dinosaur[] dinosaurs);
        Task Commit();
    }
}