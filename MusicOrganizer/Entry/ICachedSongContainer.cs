using MusicOrganizer.Entities;

namespace MusicOrganizer.Entry
{
    public interface ICachedSongContainer
    {
        Song Song { get; }

        Song ReplaceCurrentSongWith(Song song);
    }
}