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

            GlobalConfiguration.Configuration.UseSqlServerStorage("Transparencia");
            app.UseHangfireDashboard();
            app.UseHangfireServer();


            RecurringJob.AddOrUpdate("ReportesXLS",
                () => App_Code.ReportesETLS.createReport("Reporte diario de Autoevaluacion auditores", "pa_obt_reporte_etl_sal12")
                , "40 23 * * *"
                , TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate("ReportesXLS1",
                () => App_Code.ReportesETLS.createReport("Reporte diario de Evaluacion experiencia", "pa_obt_reporte_etl_sal13")
                , "40 23 * * *"
                , TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate("ReportesXLS2",
                () => App_Code.ReportesETLS.createReport("Reporte diario de Valoracion proyecto", "pa_obt_reporte_etl_sal14")
                , "40 23 * * *"
                , TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate("ReportesXLS3",
                () => App_Code.ReportesETLS.createReport("Reporte de Evaluacion posterior de proyectos", "pa_obt_reporte_etl_sal15")
                , "40 23 * * *"
                , TimeZoneInfo.Local);
        }
    }
}
