using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using HandPass.Business.Abstraction;
using HandPass.Business.ConditionRules;
using HandPass.Business.Manager;
using HandPass.Core.Utilities.Interceptors;
using HandPass.Core.Utilities.Security.Jwt;
using HandPass.DataAccess.Abstraction;
using HandPass.DataAccess.EntitiesDal;

namespace HandPass.Business.Constants.DependencyResolver.Autofac
{
    public class AutofacBusinessModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();

            builder.RegisterType<UserPasswordManager>().As<IUserPasswordService>();
            builder.RegisterType<UserPasswordDal>().As<IUserPasswordDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CategoryDal>().As<ICategoryDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserBusinessRules>().As<IUserBusinessRules>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
