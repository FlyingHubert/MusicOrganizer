using Microsoft.EntityFrameworkCore;

using MusicOrganizer.DataAccess;
using MusicOrganizer.Entities;
using MusicOrganizer.Entry;
using MusicOrganizer.Utils;

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
        private bool songsChanged = false;

        public string Name { get; set; } = "undefiniert";
        public static T Get<T>()
        {
            IKernel kernel = new StandardKernel(new NinjectBindings());
            return kernel.Get<T>();
        }

        public event EventHandler FilteredSongsChanged;

        public SongManager()
        {
            songs = new List<Song>(Get<SongProvider>().Songs);
        }

        internal void FilterForThis(string searchString)
        {
            SearchString = searchString;
        }

        private string SearchString
        {
            get => searchString;
            set
            {
                searchString = value;
                FilteredSongsChanged.Invoke(this, EventArgs.Empty);
            }
        }

        public IEnumerable<Song> FilteredSongs
        {
            get
            {
                if (string.IsNullOrEmpty(SearchString))
                    return Songs;

                return from song in Songs
                       where (song.Album != null && song.Album.ToLower().Contains(searchString))
                          || (song.Art != null && song.Art.ToLower().Contains(searchString))
                          || (song.Bemerkungen != null && song.Bemerkungen.ToLower().Contains(searchString))
                          || (song.Interpret != null && song.Interpret.ToLower().Contains(searchString))
                          || (song.Komponist != null && song.Komponist.ToLower().Contains(searchString))
                          || (song.Title != null && song.Title.ToLower().Contains(searchString))
                          || (song.single != null && song.single.ToString().Contains(searchString))
                          || (song.LP != null && song.LP.ToString().ToLower().Contains(searchString))
                          || (song.Jahr != null && song.Jahr.ToString().ToLower().Contains(searchString))
                          || (song.CD != null && song.CD.ToString().ToLower().Contains(searchString))
                       select song;
            }
        }

        public IEnumerable<Song> Songs => songs;

        private ICollection<Song> songs;
        private string searchString;

        public Song Current { get; set; }

        internal void Add(Song current)
        {
            songs.Add(current);
            FilteredSongsChanged.Invoke(this, EventArgs.Empty);
            songsChanged = true;
        }
    }
}
