using MusicOrganizer.Entities;
using System.Threading.Tasks;

namespace MusicOrganizer.Entry
{
    public interface ISongSaver
    {
        Task Save(Song toBeSaved);
    }
}