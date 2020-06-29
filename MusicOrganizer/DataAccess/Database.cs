using MusicOrganizer.Entities;
using System.Collections.Generic;

namespace MusicOrganizer.DataAccess
{
    public class Database : IDatabase
    {
        private DataContext SongContext { get; set; } = new DataContext();

        public IEnumerable<Song> Songs => SongContext.Songs;

        public void Save()
        {
            SongContext.SaveChanges();
        }

        public void Add(Song song)
        {
            SongContext.Add(song);
        }

        public void Remove(Song song)
        {
            SongContext.Remove(song);
        }

        public void Update(Song song)
        {
            SongContext.Update(song);
        }
    }
}
