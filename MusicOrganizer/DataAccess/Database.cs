using MusicOrganizer.Entities;
using System.Collections.Generic;

namespace MusicOrganizer.DataAccess
{
    public class Database : IDatabase
    {
        private DataContext SongContext { get; set; } = new DataContext();

        public IEnumerable<Song> Songs => SongContext.Songs;

        public void Commit()
        {
            SongContext.SaveChanges();
        }

        public void Insert(Song song)
        {
            SongContext.Add(song);
        }

        public void Delete(Song song)
        {
            SongContext.Remove(song);
        }

        public void Update(Song song)
        {
            SongContext.Update(song);
        }
    }
}
