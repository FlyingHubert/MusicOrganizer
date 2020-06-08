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
        public string Name { get; set; } = "undefiniert";
        public static T Get<T>()
        {
            IKernel kernel = new StandardKernel(new NinjectBindings());
            return kernel.Get<T>();
        }

        public SongManager()
        {
            Songs = new ObservableCollection<Song>(Get<SongProvider>().Songs);
        }

        public ObservableCollection<Song> Songs { get; } 

        public Song Current { get; set; }

        internal void Add(Song current)
        {
            Songs.Add(current);
        }
    }
}
