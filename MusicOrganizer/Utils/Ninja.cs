﻿using Microsoft.EntityFrameworkCore.Migrations.Operations;

using Ninject;
using Ninject.Modules;
using Ninject.Planning.Bindings;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicOrganizer.Utils
{
    public static class Ninja
    {
        private static IKernel Kernel { get; }

        static Ninja()
        {
            Kernel = new StandardKernel();

            Load(new NinjectBindings());
        }

        public static void Load(INinjectModule module) => Kernel.Load(module);

        public static T Get<T>() => Kernel.Get<T>();
    }
}