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

        public SongManager()
        {
            songs = new List<Song>(Get<SongProvider>().Songs);
        }

        public IEnumerable<Song> Songs => songs;

        private ICollection<Song> songs;

        public Song Current { get; set; }

        internal void Add(Song current)
        {
            songs.Add(current);
            songsChanged = true;
        }
    }
}
