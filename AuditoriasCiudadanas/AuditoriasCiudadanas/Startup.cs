using Hangfire;
using Hangfire.Console;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
using System;
using AuditoriasCiudadanas.Models;

[assembly: OwinStartupAttribute(typeof(AuditoriasCiudadanas.Startup))]
namespace AuditoriasCiudadanas
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            app.MapSignalR();

            //HangFire - Scheduled Jobs - vramirez
            var options = new SqlServerStorageOptions
            {
                PrepareSchemaIfNecessary = false
            };

            GlobalConfiguration.Configuration.UseSqlServerStorage("Transparencia", options).UseConsole();
            app.UseHangfireDashboard();
            app.UseHangfireServer();


            RecurringJob.AddOrUpdate("ReportesXLS",
                () => new App_Code.ReportesETLS().createReport("Reporte diario de Autoevaluacion auditores", "pa_obt_reporte_etl_sal12", 1, null)
                , "40 23 * * *"
                , TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));
            RecurringJob.AddOrUpdate("ReportesXLS1",
                () => new App_Code.ReportesETLS().createReport("Reporte diario de Evaluacion experiencia", "pa_obt_reporte_etl_sal13", 2, null)
                , "40 23 * * *"
                , TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));
            RecurringJob.AddOrUpdate("ReportesXLS2",
                () => new App_Code.ReportesETLS().createReport("Reporte diario de Valoracion proyecto", "pa_obt_reporte_etl_sal14", 3, null)
                , "40 23 * * *"
                , TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));
            RecurringJob.AddOrUpdate("ReportesXLS3",
                () => new App_Code.ReportesETLS().createReport("Reporte de Evaluacion posterior de proyectos", "pa_obt_reporte_etl_sal15", 4, null)
                , "40 23 * * *"
                , TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));
            RecurringJob.AddOrUpdate("JobPuntajesIncentivos",
                () => new App_Code.PuntajesIncentivos().execute(null)
                , "40 23 * * *"
                , TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));
            RecurringJob.AddOrUpdate("RankingAuditores",
                () => clsNotificacionesProgramadas.RankingAuditores()
                , "55 23 * * *", TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));
            RecurringJob.AddOrUpdate("ExperienciasGac",
                () => clsNotificacionesProgramadas.experienciasGac()
                , "1 1 * * 6"
                , TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));
            RecurringJob.AddOrUpdate("BuenasPracticas",
                () => clsNotificacionesProgramadas.BuenasPracticas()
                , "1 1 * * 6"

                , TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time"));
        }
    }
}
