using MusicOrganizer.Entities;

using System.Collections.Generic;

namespace MusicOrganizer.DataAccess
{
    public interface IDatabase
    {
        IEnumerable<Song> Songs { get; }

        void Insert(Song song);
        void Delete(Song song);
        void Commit();
        void Update(Song song);
    }
}