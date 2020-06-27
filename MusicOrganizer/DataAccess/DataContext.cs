using Microsoft.EntityFrameworkCore;
using MusicOrganizer.Entities;

using System.Collections.Generic;

namespace MusicOrganizer.DataAccess
{
    class DataContext : DbContext
    {
        public DataContext() : base()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={Settings.DatabaseName}");
        }

        public DbSet<Song> Songs { get; set; }
    }
}
