using MusicOrganizer.BusinessLogic;
using MusicOrganizer.DataAccess;
using MusicOrganizer.Entities;
using MusicOrganizer.Table;
using MusicOrganizer.Utils;
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
        public SaveSongCommand()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var source = Ninja.Get<EntryViewModel>();
            Ninja.Get<TableViewModel>().Add(source.Current);
            source.AddNewSong();

            source.FirstItemHasFocus = true;
        }
    }
}
