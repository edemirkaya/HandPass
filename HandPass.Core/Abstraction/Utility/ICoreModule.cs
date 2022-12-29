using Microsoft.Extensions.DependencyInjection;

namespace HandPass.Core.Abstraction.Utility
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
