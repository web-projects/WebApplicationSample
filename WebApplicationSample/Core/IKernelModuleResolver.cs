using Ninject;
using Ninject.Modules;

namespace WebApplicationSample.Core
{
    public interface IKernelModuleResolver
    {
        IKernel ResolveKernel(params NinjectModule[] modules);
    }
}
