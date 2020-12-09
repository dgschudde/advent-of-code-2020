using System.Threading.Tasks;

namespace Shared
{
    public interface IPuzzleInputReader
    {
        Task<T> ReadPuzzleInputAsync<T>();
    }
}