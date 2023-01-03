using HandPass.Core.Abstraction.Abstract;
using HandPass.Core.Abstraction.Utility;
using HandPass.Core.Aspects.Caching.Microsoft;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HandPass.Core.DependencyResolver
{
    public class CoreModules : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<Stopwatch>();
        }
    }
}
