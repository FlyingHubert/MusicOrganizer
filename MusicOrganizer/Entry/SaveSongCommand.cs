using MusicOrganizer.BusinessLogic;
using MusicOrganizer.DataAccess;
using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicOrganizer.Entry
{
    public class SaveSongCommand : ISaveSongCommand
    {
        private EntryViewModel entryViewModel;
        private SongManager songManager;

        public SaveSongCommand(EntryViewModel entryViewModel, SongManager songManager)
        {
            this.entryViewModel = entryViewModel;
            this.songManager = songManager;

            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            // TODO: ggf. Bedinungen definieren unter denen er nicht ausgeführt werden kann.
            return true;
        }

        public void Execute(object parameter)
        {           
            songManager.Add(entryViewModel.Current);
            entryViewModel.Current = new Song();
        }
    }
}
