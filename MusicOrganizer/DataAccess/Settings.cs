using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.DataAccess
{
    public static class Settings
    {
        public static string DatabaseName { get; } = "SqliteSongs.db";
        public static string BackupFolder { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                                            "MusicOrganizer", "backups");
    }
}
