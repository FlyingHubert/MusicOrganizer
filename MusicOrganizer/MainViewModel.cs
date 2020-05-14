using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MusicOrganizer.Table;
using MusicOrganizer.Entry;
using MusicOrganizer.Mixed;
using MusicOrganizer.DataAccess;

namespace MusicOrganizer
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            // AddTestData();
        }

        private static void AddTestData()
        {
            using (var db = new DataContext())
            {
                db.Songs.Add(new Song()
                {
                    Album = "Reise, Reise",
                    Art = "Hardrock",
                    Bemerkungen = "Guter Song",
                    CD = 23,
                    Interpret = "Rammstein",
                    Jahr = 1998,
                    LP = 1234,
                    Title = "Dalei Lama"
                });
                db.Songs.Add(new Song()
                {
                    Album = "Reise, Reise",
                    Art = "Hardrock",
                    Bemerkungen = "Geht tief unter die Haut",
                    CD = 23,
                    Interpret = "Rammstein",
                    Jahr = 1998,
                    LP = 1234,
                    Title = "Morgenstern"
                });
                db.Songs.Add(new Song()
                {
                    Album = "Reise, Reise",
                    Art = "Hardrock",
                    Bemerkungen = "Geil",
                    CD = 23,
                    Interpret = "Rammstein",
                    Jahr = 1998,
                    LP = 1234,
                    Title = "Reise, Reise"
                });
                db.Songs.Add(new Song()
                {
                    Album = "Monster",
                    Art = "Funk",
                    Bemerkungen = "Feier ich voll",
                    CD = 23,
                    Interpret = "jodie (Youtube)",
                    Jahr = 2017,
                    LP = 1234,
                    Title = "Monster"
                });
                db.SaveChanges();
            }
        }
    }
}
