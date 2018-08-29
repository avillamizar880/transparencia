using Hangfire.Server;
using Hangfire.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.App_Code
{
    public class PuntajesIncentivos
    {
        public void execute(PerformContext context)
        {
            string rta = Models.clsPuntajesIncentivos.executeSP();
            context.WriteLine(rta);
        }
    }
}