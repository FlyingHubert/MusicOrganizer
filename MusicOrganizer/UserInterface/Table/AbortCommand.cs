using MusicOrganizer.DI;
using MusicOrganizer.Entry;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.Table
{
    public class AbortCommand : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged { add {} remove{} }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var table = Ninja.Get<TableViewModel>();
            table.SelectedSong = null;

            var entry = Ninja.Get<EntryViewModel>();
            entry.AddNewSong();
        }
    }
}
