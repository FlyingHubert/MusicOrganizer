using MusicOrganizer.Entities;

using System.Collections.Generic;

namespace MusicOrganizer.DataAccess
{
    public interface IDatabase
    {
        IEnumerable<Song> Songs { get; }

        void Add(Song song);
        void Remove(Song song);
        void Save();
        void Update(Song song);
    }
}