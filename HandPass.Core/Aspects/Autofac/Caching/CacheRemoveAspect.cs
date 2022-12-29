using Castle.DynamicProxy;
using HandPass.Core.Abstraction.Abstract;
using HandPass.Core.Utilities.Interceptors;
using HandPass.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace HandPass.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
