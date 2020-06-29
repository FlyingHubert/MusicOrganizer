using Microsoft.EntityFrameworkCore;

using MusicOrganizer.DataAccess;
using MusicOrganizer.DI;
using MusicOrganizer.Entities;
using MusicOrganizer.Entry;

using Ninject;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.BusinessLogic
{
    public class SongManager
    {
        public string Name { get; set; } = "undefiniert";

        public SongManager()
        {
            songs = new List<Song>(Ninja.Get<SongProvider>().Songs);
        }

        public SongModel PreviousEditableSong { get; set; }

        private Database Database { get; }

        public event EventHandler<SongModel> SongAdded;
        public event EventHandler<SongModel> SongRemoved;
        public IEnumerable<SongModel> Songs => Database.Songs.Select(s => new SongModel(s));

        public void AddSongToDatabase()
        {
            Database.Insert(EditableSong.Song);
            SongAdded.Invoke(this, EditableSong);
            EditableSong = new SongModel(new Song());
            StateChanged?.Invoke(this,State.Adding);
        }

        private ICollection<Song> songs;

        public void Remove(SongModel songModel)
        {
            Database.Delete(songModel.Song);
            SongRemoved.Invoke(this, songModel);
        }

        internal void Add(Song current)
        {
            songs.Add(current);
        }
    }
}
