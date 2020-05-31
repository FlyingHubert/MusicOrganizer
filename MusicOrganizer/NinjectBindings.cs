using MusicOrganizer.DataAccess;
using MusicOrganizer.Entry;
using MusicOrganizer.Table;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ISongQuery>().To<SongFinder>();
            Bind<ISongProvider>().To<SongProvider>();
            Bind<ISongSaver>().To<SongSaver>();
            Bind<ISaveSongCommand>().To<SaveSongCommand>();
            Bind<MainViewModel>().ToSelf();
            Bind<TableViewModel>().ToSelf();
            Bind<EntryViewModel>().ToSelf();
        }
    }
}
