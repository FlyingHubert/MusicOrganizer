using MusicOrganizer.DataAccess;
using MusicOrganizer.Entry;
using MusicOrganizer.Table;
using MusicOrganizer.Utils;

using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MusicOrganizer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Task BackupTask;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            BackupTask = Task.Run(() =>
            {
                BackupService.CreateBackup();
                BackupService.CleanupBackupFolder();
            });
        }

        protected override void OnExit(ExitEventArgs e)
        {
            BackupTask.GetAwaiter().GetResult();

            using (var context = new DataContext())
            {
                var table = Ninja.Get<TableViewModel>();
                context.Songs.AddRange(table.AddedSongs);
                context.Songs.RemoveRange(table.RemovedSongs);

                var entry = Ninja.Get<EntryViewModel>();
                context.Songs.UpdateRange(entry.ChangedSongs);

                context.SaveChanges();
            }

            Ninja.Get<Database>().Commit();
            base.OnExit(e);
        }
    }
}
