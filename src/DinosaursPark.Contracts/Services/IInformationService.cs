using System.Threading.Tasks;

namespace DinosaursPark.Contracts.Services
{
    public interface IInformationService
    {
        Task<TItem> Get<TItem>();
    }
}