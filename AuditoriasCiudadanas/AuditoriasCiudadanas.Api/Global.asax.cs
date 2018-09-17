using System.Web.Http;
using System.Data.Entity;
using AuditoriasCiudadanas.Api.Core.Data.ContextFactory;
using AuditoriasCiudadanas.Api.Core.Data.DbModel;
using AuditoriasCiudadanas.Api.Core.Data.Repository;
using AuditoriasCiudadanas.Api.Core.Data.UoW;
using AuditoriasCiudadanas.Api.Core.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace AuditoriasCiudadanas.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Begin: SimpleInjector definitions
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<DbContext>(() => new TransparenciaDbModel(), Lifestyle.Scoped);
            container.Register<IDatabaseContextFactory, DatabaseContextFactory>(Lifestyle.Singleton);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            //container.Register(typeof(IGenericRepository<,>), typeof(GenericRepository<,>).Assembly);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IAuthService, AuthService>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            //End: SimpleInjector definitions
        }
    }
}
