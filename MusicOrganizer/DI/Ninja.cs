
using MusicOrganizer.Utils;

using Ninject;

namespace MusicOrganizer.DI
{
    public static class Ninja
    {
        private static IKernel Kernel { get; }

        static Ninja()
        {
            Kernel = new StandardKernel();
            Kernel.Load(new NinjectBindings());
        }

        public static T Get<T>() => Kernel.Get<T>();
    }
}
