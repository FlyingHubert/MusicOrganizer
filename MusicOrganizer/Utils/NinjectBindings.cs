using MusicOrganizer.BusinessLogic;
using MusicOrganizer.Entry;
using MusicOrganizer.Table;
using MusicOrganizer.TopBar;

using Ninject.Modules;

namespace MusicOrganizer.Utils
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<SongManager>().ToSelf().InSingletonScope();
            Bind<TableViewModel>().ToSelf().InSingletonScope();
            Bind<EntryViewModel>().ToSelf().InSingletonScope();
            Bind<MainViewModel>().ToSelf().InSingletonScope();
            Bind<TopBarViewModel>().ToSelf().InSingletonScope();

            Bind<ISaveSongCommand>().To<SaveSongCommand>();
        }
    }
}
