using MusicOrganizer.BusinessLogic;
using MusicOrganizer.UserInterface.Entry;
using MusicOrganizer.UserInterface.Table;
using MusicOrganizer.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.UserInterface.Commands
{
    public class AbortCommand : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var table = Ninja.Get<TableViewModel>();
            table.SelectedSongModel = null;

            var manager = Ninja.Get<SongManager>();
            manager.Remove(manager.EditableSong);
            manager.AddSongToDatabase();
        }
    }
}
