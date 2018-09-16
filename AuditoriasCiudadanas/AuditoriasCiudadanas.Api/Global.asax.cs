using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using AuditoriasCiudadanas.Core.Data.DbModel;
using System.Data.Entity;
using AuditoriasCiudadanas.Core.Data.ContextFactory;
using AuditoriasCiudadanas.Core.Data.Repository;
using AuditoriasCiudadanas.Core.Data.UoW;
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

            container.Register(typeof(IGenericRepository<,>), typeof(GenericRepository<,>).Assembly);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            //End: SimpleInjector definitions
        }
    }
}
