using DinosaurusPark.Contracts.Models;
using System.Threading.Tasks;

namespace DinosaurusPark.Contracts
{
    /// <summary>
    /// Генератор, заполняющий БД данными.
    /// </summary>
    public interface IDataGenerator
    {
        Task<GenerationResult> Generate(int speciesCount, int dinosaursCount);
    }
}
