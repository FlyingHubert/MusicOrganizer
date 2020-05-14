using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.DataAccess
{
    public class SongProvider : ISongProvider
    {
        public IEnumerable<Song> Songs
        { 
            get
            {
                using (var db = new DataContext()) 
                {
                    return db.Songs.ToList();
                }
            }
        }
    }
}
