using System.Web.Http;
using System.Data.Entity;
using System.Net.Http.Formatting;
using AuditoriasCiudadanas.Api.Core.Data.ContextFactory;
using AuditoriasCiudadanas.Api.Core.Data.DbModel;
using AuditoriasCiudadanas.Api.Core.Data.Repository;
using AuditoriasCiudadanas.Api.Core.Data.UoW;
using AuditoriasCiudadanas.Api.Core.Services;
using Newtonsoft.Json.Serialization;
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

            var config = GlobalConfiguration.Configuration;

            //Begin: SimpleInjector definitions
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<DbContext>(() => new TransparenciaDbModel(), Lifestyle.Scoped);
            container.Register<IDatabaseContextFactory, DatabaseContextFactory>(Lifestyle.Singleton);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IAuthService, AuthService>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            //End: SimpleInjector definitions

            //Always return JSON
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            //Always return JSON in camelCase notation
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }
    }
}
