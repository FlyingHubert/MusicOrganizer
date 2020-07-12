using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MusicOrganizer.DataAccess;
using MusicOrganizer.UserInterface.Entry;
using MusicOrganizer.UserInterface.TopBar;
using MusicOrganizer.UserInterface.Table;

namespace MusicOrganizer
{
    class MainViewModel : ViewModelBase
    {
        private string filter;

        public TableViewModel TableViewModel { get; }

        public EntryViewModel EntryViewModel { get; }

        public TopBarViewModel TopBarViewModel { get; }

        public MainViewModel(TableViewModel tableViewModel, EntryViewModel entryViewModel, TopBarViewModel topBarViewModel)
        {
            TopBarViewModel = topBarViewModel;
            TableViewModel = tableViewModel;
            TopBarViewModel.PropertyChanged += OnTopBarPropertyChanged;
            EntryViewModel = entryViewModel;
        }

        private void OnTopBarPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(TopBarViewModel.SearchString))
            {
                TableViewModel.Filter = TopBarViewModel.SearchString;
            }
        }

        public string Filter
        {
            get => filter;
            set
            {
                filter = value;
                Notify();
            }
        }
    }
}
