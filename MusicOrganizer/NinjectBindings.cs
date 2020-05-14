using MusicOrganizer.DataAccess;
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
        }
    }
}
