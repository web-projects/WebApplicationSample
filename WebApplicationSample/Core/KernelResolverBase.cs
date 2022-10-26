using Ninject;
using Ninject.Modules;

namespace WebApplicationSample.Core
{
    public abstract class KernelResolverBase : IKernelModuleResolver
    {
        public abstract NinjectModule[] NinjectModules { get; }

        public IKernel ResolveKernel(params NinjectModule[] modules)
        {
            List<NinjectModule> moduleList = new List<NinjectModule>();
            moduleList.AddRange(NinjectModules);
            moduleList.AddRange(modules);

            IKernel kernel = new StandardKernel(moduleList.ToArray());
            kernel.Settings.InjectNonPublic = true;
            kernel.Settings.InjectParentPrivateProperties = true;

            return kernel;
        }
    }
}
