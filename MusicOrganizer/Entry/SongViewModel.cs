using MusicOrganizer.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.Entry
{
    public class SongViewModel : ViewModelBase
    {
        public event EventHandler<Song> SongChanged;
        private bool isDirty = false;

        public SongViewModel(Song song)
        {
            Song = song ?? new Song();

            PropertyChanged += (_, __) =>
            {
                if (!isDirty)
                {
                    SongChanged?.Invoke(this, Song);
                    isDirty = true;
                }
            };
        }

        public Song Song { get; }


        public string Title
        {
            get => Song.Title;
            set
            {
                Song.Title = value;
                Notify();
            }
        }

        public string Interpret
        {
            get => Song.Interpret;
            set
            {
                Song.Interpret = value;
                Notify();
            }
        }

        public string Album
        {
            get => Song.Album;
            set
            {
                Song.Album = value;
                Notify();
            }
        }

        public int? LP
        {
            get => Song.LP;
            set
            {
                Song.LP = value;
                Notify();
            }
        }

        public int? single
        {
            get => Song.single;
            set
            {
                Song.single = value;
                Notify();
            }
        }

        public string Art
        {
            get => Song.Art;
            set
            {
                Song.Art = value;
                Notify();
            }
        }


        public int? CD
        {
            get => Song.CD;
            set
            {
                Song.CD = value;
                Notify();
            }
        }

        public int? Jahr
        {
            get => Song.Jahr;
            set
            {
                Song.Jahr = value;
                Notify();
            }
        }

        public string Komponist
        {
            get => Song.Komponist;
            set
            {
                Song.Komponist = value;
                Notify();
            }
        }

        public string Bemerkungen
        {
            get => Song.Bemerkungen;
            set
            {
                Song.Bemerkungen = value;
                Notify();
            }
        }

    }
}
