using DinosaursPark.Contracts.Models;
using System.Threading.Tasks;

namespace DinosaursPark.Contracts.Repositories
{
    public interface IInformationRepository
    {
        Task<ParkInformation> Get();

        Task Add(ParkInformation info);
    }
}