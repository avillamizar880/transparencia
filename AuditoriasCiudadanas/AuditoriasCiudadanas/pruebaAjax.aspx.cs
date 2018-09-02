using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriasCiudadanas.Models;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class pruebaAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //proponeFechaCorreo
            Models.clsNotificacionesProgramadas datos = new AuditoriasCiudadanas.Models.clsNotificacionesProgramadas();
            //string respuesta = clsNotificacionesProgramadas.RankingAuditores();
            
        }
    }
}