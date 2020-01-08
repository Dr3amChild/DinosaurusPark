using System.Threading.Tasks;

namespace DinosaursPark.Contracts.Services
{
    public interface IInformationService
    {
        Task<TItem> GetParkInfo<TItem>();

        Task<TItem> GetSpeciesInfo<TItem>();
    }
}