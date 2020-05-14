using MusicOrganizer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.DataAccess
{
    public interface ISongQuery
    {
        IEnumerable<Song> SearchFor(Song incompleteSong);
    }
}
