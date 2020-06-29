using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicOrganizer.DataAccess
{
    public class BackupService
    {
        public static void CreateBackup()
        {
            var targetFolder = Settings.BackupFolder;

            Directory.CreateDirectory(targetFolder);

            var file = Settings.DatabaseName;
            var sourceFile = Path.Combine(@".\", file);

            var targetFileName = file.Replace(".db", $"{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.db");
            var targetFilePath = Path.Combine(targetFolder, targetFileName);

            if(File.Exists(sourceFile))
                File.Copy(sourceFile, targetFilePath);
        }

        public static void CleanupBackupFolder()
        {
            var filesToDelete = (from file in Directory.EnumerateFiles(Settings.BackupFolder).Skip(100)
                                select Path.Combine(Settings.BackupFolder, file)).ToList();

            foreach (var file in filesToDelete)
            {
                File.Delete(file);
            }
        }
    }
}
