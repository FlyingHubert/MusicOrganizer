using MusicOrganizer.BusinessLogic;
using MusicOrganizer.UserInterface.Entry;
using MusicOrganizer.UserInterface.Table;
using MusicOrganizer.UserInterface.TopBar;
using MusicOrganizer.DataAccess;
using Ninject.Modules;
using MusicOrganizer.UserInterface.Commands;

namespace MusicOrganizer.Utils
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<Database>().ToSelf().InSingletonScope();
            Bind<SongManager>().ToSelf().InSingletonScope();
            Bind<TableViewModel>().ToSelf().InSingletonScope();
            Bind<EntryViewModel>().ToSelf().InSingletonScope();
            Bind<MainViewModel>().ToSelf().InSingletonScope();
            Bind<TopBarViewModel>().ToSelf().InSingletonScope();
            Bind<SaveSongCommand>().ToSelf();
        }
    }
}
