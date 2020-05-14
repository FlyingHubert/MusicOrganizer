using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.DataAccess
{
    public class SongFinder : ISongQuery
    {
        public IEnumerable<Song> SearchFor(Song incompleteSong)
        {
            using (var context = new DataContext())
            {
                context.Songs.Find();
                return context.Songs.Where(s => s.Title ==  "%" + incompleteSong.Title + "%").ToList(); //TODO: Incomplete search
            }
        }
    }
}
