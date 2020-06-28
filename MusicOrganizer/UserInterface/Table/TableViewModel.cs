using MusicOrganizer.BusinessLogic;
using MusicOrganizer.DataAccess;
using MusicOrganizer.Entities;
using MusicOrganizer.Entry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace MusicOrganizer.Table
{
    public class TableViewModel : ViewModelBase, ICollection<SongViewModel>
    {
        private string filter;

        public ICollection<Song> AddedSongs { get; } =  new List<Song>();
        public ICollection<Song> RemovedSongs { get; } = new List<Song>();

        public ICommand RemoveCommand { get; } = new RemoveCommand();

        public TableViewModel(SongManager manager)
        {
            Manager = manager;
            Songs = new ObservableCollection<SongViewModel>(Manager.Songs.Select(s => new SongViewModel(s)));
            Songs.CollectionChanged += Songs_CollectionChanged;
        }

        private void Songs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                    {
                        if(item is SongViewModel songViewModel)
                            AddedSongs.Add(songViewModel.Song);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems)
                    {
                        if(item is SongViewModel songViewModel)
                            RemovedSongs.Add(songViewModel.Song);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
            }
        }

        private SongViewModel selectedSongViewModel;

        public SongViewModel SelectedSong
        {
            set
            {
                selectedSongViewModel = value;
                Notify();
            }

            get => selectedSongViewModel;
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

        public SongManager Manager { get; }

        public ObservableCollection<SongViewModel> Songs { get; }

        public int Count => ((ICollection<Song>)Songs).Count;

        public bool IsReadOnly => ((ICollection<Song>)Songs).IsReadOnly;

        public void Add(SongViewModel item)
        {
            ((ICollection<SongViewModel>)Songs).Add(item);
        }

        public bool Contains(SongViewModel item)
        {
            return ((ICollection<SongViewModel>)Songs).Contains(item);
        }

        public void CopyTo(SongViewModel[] array, int arrayIndex)
        {
            ((ICollection<SongViewModel>)Songs).CopyTo(array, arrayIndex);
        }

        public bool Remove(SongViewModel item)
        {
            return ((ICollection<SongViewModel>)Songs).Remove(item);
        }

        IEnumerator<SongViewModel> IEnumerable<SongViewModel>.GetEnumerator()
        {
            return ((IEnumerable<SongViewModel>)Songs).GetEnumerator();
        }

        public void Clear()
        {
            ((ICollection<SongViewModel>)Songs).Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Songs).GetEnumerator();
        }
    }
}
