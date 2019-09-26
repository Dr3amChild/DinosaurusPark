using System.Threading.Tasks;

namespace DinosaurusPark.Contracts
{
    /// <summary>
    /// Генератор, заполняющий БД данными.
    /// </summary>
    public interface IDataGenerator
    {
        Task Generate(int speciesCount, int disnosaursCount);
    }
}
