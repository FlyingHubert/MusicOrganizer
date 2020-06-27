using MusicOrganizer.Entities;
using MusicOrganizer.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicOrganizer.Table
{
    public class RemoveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add{} remove{} }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var table = Ninja.Get<TableViewModel>();

            table.Remove(table.SelectedSong);
        }
    }
}
