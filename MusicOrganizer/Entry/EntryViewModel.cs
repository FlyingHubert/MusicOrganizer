using MusicOrganizer.BusinessLogic;
using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MusicOrganizer.Entry
{
    public class EntryViewModel : ViewModelBase
    {
        private Song currentSong = new Song();
        private SongViewModel current;
        private bool firstItemHasFocus;
        private Visibility editVisible;

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

        internal void AddNewSong()
        {
            currentSong = new Song();
            Current = new SongViewModel(currentSong);
            EditVisible = Visibility.Collapsed;
        }

        public EntryViewModel()
        {
            AddNewSong();
            SaveSongCommand = Get<SaveSongCommand>();
            F5Command = new LoadFromLast(this);
        }

        public void EditThisSong(Song song)
        {
            currentSong = song;
            Current = new SongViewModel(currentSong);
            EditVisible = Visibility.Visible;
        }

        private void OnSongChanged(object sender, Song e)
        {
            ChangedSongs.Add(e);
        }

        public SongViewModel Current
        {
            get => current;
            private set
            {

                if (Current != null)
                    Current.SongChanged -= OnSongChanged;
                current = value;
                Current.SongChanged += OnSongChanged;
                Notify();
            }
        }

        private Song Last { get; set; }

        public ISaveSongCommand SaveSongCommand { get; }


        public class LoadFromLast : ICommand
        {
            private readonly EntryViewModel parent;

            public LoadFromLast(EntryViewModel parent)
            {
                this.parent = parent;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return parent.Last != null;
            }

            public void Execute(object parameter)
            {
                var type = typeof(Song);
                var property = type.GetProperty(parameter as string);
                property.SetValue(parent.Current, property.GetValue(parent.Last));
                parent.Notify(nameof(Current));
            }
        }

        public ICommand F5Command { get; }
        public ICommand F10Command => SaveSongCommand;

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
