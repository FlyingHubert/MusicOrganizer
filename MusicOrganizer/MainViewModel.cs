using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MusicOrganizer.Table;
using MusicOrganizer.Entry;
using MusicOrganizer.Mixed;
using MusicOrganizer.DataAccess;
using MusicOrganizer.TopBar;

namespace MusicOrganizer
{
    class MainViewModel : ViewModelBase
    {
        public TableViewModel TableViewModel { get; }

        public EntryViewModel EntryViewModel { get; }

        public TopBarViewModel TopBarViewModel { get; }

        public MainViewModel(TableViewModel tableViewModel, EntryViewModel entryViewModel, TopBarViewModel topBarViewModel)
        {
            TableViewModel = tableViewModel;
            EntryViewModel = entryViewModel;
            TopBarViewModel = topBarViewModel;
        }
    }
}
