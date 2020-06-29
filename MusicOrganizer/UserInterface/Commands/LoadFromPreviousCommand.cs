using MusicOrganizer.BusinessLogic;
using MusicOrganizer.DI;
using MusicOrganizer.Entities;
using MusicOrganizer.UserInterface.Entry;
using MusicOrganizer.Utils;

using System;
using System.Windows.Input;

namespace MusicOrganizer.UserInterface.Commands
{

    public class LoadFromPreviousCommand : ICommand
    {
        private readonly SongManager manager;

        public LoadFromPreviousCommand(SongManager manager)
        {
            this.manager = manager;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return manager.PreviousEditableSong != null;
        }

        public void Execute(object parameter)
        {
            var type = typeof(Song);
            var property = type.GetProperty(parameter as string);
            var entry = Ninja.Get<EntryViewModel>();

            property.SetValue(entry.Current, property.GetValue(manager.PreviousEditableSong));
            entry.Notify(nameof(entry.Current));
        }
    }

}
