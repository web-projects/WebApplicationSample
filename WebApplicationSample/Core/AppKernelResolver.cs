
using Ninject.Modules;
using WebApplicationSample.Core.Modules;

namespace WebApplicationSample.Core
{
    public sealed class AppKernelResolver : KernelResolverBase
    {
        public override NinjectModule[] NinjectModules => new NinjectModule[]
        {
            new CoreModule()
        };
    }
}