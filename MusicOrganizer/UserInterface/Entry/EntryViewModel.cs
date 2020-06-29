using MusicOrganizer.BusinessLogic;
using MusicOrganizer.Entities;
using MusicOrganizer.UserInterface.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MusicOrganizer.UserInterface.Entry
{
    public partial class EntryViewModel : ViewModelBase
    {
        private SongModel current;
        private bool firstItemHasFocus;
        private Visibility editVisible;
        private readonly SongManager manager;

        public ICollection<Song> ChangedSongs { get; } = new List<Song>();

        public Visibility EditVisible
        {
            get => editVisible;
            set
            {
                editVisible = value;
                Notify();
                Notify(nameof(AddVisible));
            }
        }

        public Visibility AddVisible => EditVisible == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

        public EntryViewModel(SongManager manager)
        {
            this.manager = manager;
            F5Command = Get<LoadFromPreviousCommand>();
            manager.EditableSongChanged += (_, s) => Current = manager.EditableSong;
            manager.StateChanged += (_, s) => EditVisible = s == State.Editing ? Visibility.Visible : Visibility.Collapsed; 
            Current = manager.EditableSong;
        }

        public SongModel Current
        {
            get => current;
            private set
            {
                current = value;
                Notify();
            }
        }

        public ICommand F5Command { get; }

        public ICommand F10Command => Get<SaveSongCommand>();

        public bool FirstItemHasFocus
        {
            get => firstItemHasFocus;
            set
            {
                firstItemHasFocus = value;
                Notify();
            }
        }
    }
}
