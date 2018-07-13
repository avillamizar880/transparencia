using Hangfire;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(AuditoriasCiudadanas.Startup))]
namespace AuditoriasCiudadanas
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            app.MapSignalR();

            GlobalConfiguration.Configuration.UseSqlServerStorage("Transparencia");
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate("ReportesXLS", () => Console.Write("Powerful!"), "00 23 * * *", TimeZoneInfo.Local);
        }
    }
}
