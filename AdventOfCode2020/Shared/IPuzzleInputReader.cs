using System.Threading.Tasks;

namespace Shared
{
    public interface IPuzzleInputReader
    {
        Task<int[]> ReadPuzzleInputAsync();
    }
}