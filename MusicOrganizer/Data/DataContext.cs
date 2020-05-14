using Microsoft.EntityFrameworkCore;
using MusicOrganizer.Entities;

namespace MusicOrganizer.Data
{
    class DataContext : DbContext
    {
        public DataContext() : base()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=SqliteSongs.db");
        }

        public DbSet<Song> Songs { get; set; }
    }
}
