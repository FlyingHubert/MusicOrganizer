using MusicOrganizer.DataAccess;
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

        protected async override void OnExit(ExitEventArgs e)
        {
            await BackupTask.ConfigureAwait(false);

            Ninja.Get<Database>().Save();
            base.OnExit(e);
        }
    }
}
