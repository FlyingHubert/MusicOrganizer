using MusicOrganizer.Entities;
using MusicOrganizer.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.DataAccess
{
    public class SongSaver
    {
        public async Task Save(Song toBeSaved)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.Add(toBeSaved);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
