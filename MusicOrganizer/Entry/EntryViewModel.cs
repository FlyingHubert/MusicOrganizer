using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicOrganizer.Entry
{
    public class EntryViewModel : ViewModelBase, ICachedSongContainer
    {
        public EntryViewModel()
        {
            SaveSongCommand = new SaveSongCommand(this, Get<ISongSaver>());
        }

        public Song Song { get; set; } = new Song();

        public Song LastSong { get; set; } = new Song();

        public Song ReplaceCurrentSongWith(Song newSong)
        {
            LastSong = Song;
            Song = newSong;
            return LastSong;
        }

        public ISaveSongCommand SaveSongCommand { get; }
    }
}
