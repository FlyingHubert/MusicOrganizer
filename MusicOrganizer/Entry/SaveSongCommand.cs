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
        public SaveSongCommand(ICachedSongContainer songContainer, ISongSaver saver)
        {
            SongContainer = songContainer;
            Saver = saver;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public ICachedSongContainer SongContainer { get; }
        public ISongSaver Saver { get; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            // TODO: ggf. Bedinungen definieren unter denen er nicht ausgeführt werden kann.
            return true;
        }

        public void Execute(object parameter)
        {
            var toBeSaved = SongContainer.ReplaceCurrentSongWith(new Song());
            Saver.Save(toBeSaved);
        }
    }
}
