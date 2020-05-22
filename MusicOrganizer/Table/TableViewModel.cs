using MusicOrganizer.DataAccess;
using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.Table
{
    public class TableViewModel : ViewModelBase
    {
        public IEnumerable<Song> Songs { get; } = Get<ISongProvider>().Songs;

        public Song SelectedSong { get; set; }
    }
}
