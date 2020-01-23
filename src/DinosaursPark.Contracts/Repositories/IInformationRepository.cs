using DinosaursPark.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinosaursPark.Contracts.Repositories
{
    public interface IInformationRepository
    {
        Task<ParkInformation> GetParkInfo();

        Task<IReadOnlyCollection<SpeciesInformation>> GetSpeciesInfo();

        Task Add(ParkInformation info);

        Task DeleteAll();
    }
}