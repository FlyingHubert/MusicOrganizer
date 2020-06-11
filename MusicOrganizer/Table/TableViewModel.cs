using MusicOrganizer.BusinessLogic;
using MusicOrganizer.DataAccess;
using MusicOrganizer.Entities;
using MusicOrganizer.Entry;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Threading;

namespace MusicOrganizer.Table
{
    public class TableViewModel : ViewModelBase
    {
        public TableViewModel(SongManager manager)
        {
            Manager = manager;
            Manager.FilteredSongsChanged += (_, __) => Notify(nameof(Songs));
        }

        public Song SelectedSong
        { 
            set => Manager.Current = value;
        }
        public SongManager Manager { get; }


        public IEnumerable<Song> Songs
        {
            get
            {
                return Manager.FilteredSongs;
            }
        }
    }
}
