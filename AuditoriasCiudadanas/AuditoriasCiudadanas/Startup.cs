using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuditoriasCiudadanas.Startup))]
namespace AuditoriasCiudadanas
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
