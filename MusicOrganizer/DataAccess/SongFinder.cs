using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.DataAccess
{
    public class SongFinder
    {
        public IEnumerable<Song> SearchFor(Song incompleteSong)
        {
            var songComparer = new SongComparer(incompleteSong);

            using (var context = new DataContext())
            {
                var query = context.Songs.Where(song => songComparer.IsLike(song)); 
                return query.ToList();
            }                
        }
    }
}
