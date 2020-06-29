using MusicOrganizer.DataAccess;
using MusicOrganizer.DI;

using System.Threading.Tasks;
using System.Windows;

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

            Ninja.Get<Database>().Commit();
            base.OnExit(e);
        }
    }
}
