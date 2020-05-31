using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MusicOrganizer.Table;
using MusicOrganizer.Entry;
using MusicOrganizer.Mixed;
using MusicOrganizer.DataAccess;

namespace MusicOrganizer
{
    class MainViewModel : ViewModelBase
    {
        public TableViewModel TableViewModel { get; }

        public EntryViewModel EntryViewModel { get; }

        public MainViewModel(TableViewModel tableViewModel, EntryViewModel entryViewModel)
        {
            TableViewModel = tableViewModel;
            EntryViewModel = entryViewModel;
        }    
    }
}
