using MusicOrganizer.BusinessLogic;
using MusicOrganizer.DataAccess;
using MusicOrganizer.Entities;
using MusicOrganizer.UserInterface.Entry;
using MusicOrganizer.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicOrganizer.UserInterface.Commands
{
    public class SaveSongCommand : ICommand
    {
        private readonly SongManager manager;

        public SaveSongCommand(SongManager manager)
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            this.manager = manager;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var source = Ninja.Get<EntryViewModel>();
            manager.AddSongToDatabase();
            source.FirstItemHasFocus = true;
        }
    }
}
