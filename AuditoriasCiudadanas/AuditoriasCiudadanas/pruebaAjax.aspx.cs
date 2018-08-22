using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class pruebaAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //proponeFechaCorreo
            AuditoriasCiudadanas.Controllers.NotificacionesProgramadas datos = new AuditoriasCiudadanas.Controllers.NotificacionesProgramadas();
            string outTxt = datos.RankingAuditores("villamizardiana@gmail.com",145);
        }
    }
}