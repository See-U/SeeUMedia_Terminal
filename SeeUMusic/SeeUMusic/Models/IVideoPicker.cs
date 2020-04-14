using System.Threading.Tasks;

namespace SeeUMusic.Models
{
    public interface IVideoPicker
    {
        Task<string> GetVideoFileAsync();
    }
}
