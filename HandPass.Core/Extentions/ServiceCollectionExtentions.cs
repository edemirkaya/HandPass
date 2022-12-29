using HandPass.Core.Abstraction.Utility;
using HandPass.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace HandPass.Core.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
