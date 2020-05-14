using MusicOrganizer.Data;
using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MusicOrganizer.Table;
using MusicOrganizer.Entry;
using MusicOrganizer.Mixed;

namespace MusicOrganizer
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            


        }

        public TableViewModel TableViewModel { get; }
        public EntryViewModel EntryViewModel { get; }
        public MixedViewModel MixedViewModel { get; }
    }
}
