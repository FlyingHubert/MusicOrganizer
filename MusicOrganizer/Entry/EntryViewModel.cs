using MusicOrganizer.BusinessLogic;
using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicOrganizer.Entry
{
    public class EntryViewModel : ViewModelBase
    {
        private Song current = new Song();

        public EntryViewModel()
        {
            SaveSongCommand = new SaveSongCommand(this, Get<SongManager>());
            F5Command = new LoadFromLast(this);
        }

        public Song Current
        {
            get => current;
            set
            {
                Last = current;
                current = value;
                Notify();
            }
        }

        private Song Last { get; set; }

        public ISaveSongCommand SaveSongCommand { get; }


        public class LoadFromLast : ICommand
        {
            private readonly EntryViewModel parent;

            public LoadFromLast(EntryViewModel parent)
            {
                this.parent = parent;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return parent.Last != null;
            }

            public void Execute(object parameter)
            {
                var type = typeof(Song);
                var property = type.GetProperty(parameter as string);
                property.SetValue(parent.Current, property.GetValue(parent.Last));
                parent.Notify(nameof(Current));
            }
        }

        public ICommand F5Command { get; }
        public ICommand F10Command => SaveSongCommand;
    }
}
