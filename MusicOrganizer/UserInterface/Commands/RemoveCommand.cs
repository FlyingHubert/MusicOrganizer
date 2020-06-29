using MusicOrganizer.BusinessLogic;
using MusicOrganizer.DI;
using MusicOrganizer.Entities;
using MusicOrganizer.UserInterface.Table;
using MusicOrganizer.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicOrganizer.UserInterface.Commands
{
    public class RemoveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var table = Ninja.Get<TableViewModel>();
            var manager = Ninja.Get<SongManager>();

            manager.Remove(table.SelectedSongModel);
        }
    }
}
