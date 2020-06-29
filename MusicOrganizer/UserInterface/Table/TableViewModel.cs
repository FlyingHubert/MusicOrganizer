using MusicOrganizer.BusinessLogic;
using MusicOrganizer.UserInterface.Commands;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MusicOrganizer.UserInterface.Table
{
    public class TableViewModel : ViewModelBase
    {
        private string filter;

        public ICommand RemoveCommand { get; } = new RemoveCommand();

        public TableViewModel(SongManager manager)
        {
            Manager = manager;
            Manager.SongAdded += (_, addedSong) =>
            {
                Songs.Add(addedSong);
            };
            Manager.SongRemoved += (_, removedSong) =>
            {
                var SongModel = Songs.First(songModel => songModel == removedSong);
                Songs.Remove(SongModel);
            };

            Songs = new ObservableCollection<SongModel>(manager.Songs);
        }

        private SongModel selectedSongModel;

        public SongModel SelectedSongModel
        {
            set
            {
                selectedSongModel = value;
                Manager.EditThisSong(selectedSongModel);
                Notify();
            }

            get => selectedSongModel;
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

        public ObservableCollection<SongModel> Songs { get; } 
    }
}
