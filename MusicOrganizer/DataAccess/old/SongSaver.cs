using MusicOrganizer.Entities;

using System;
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
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
