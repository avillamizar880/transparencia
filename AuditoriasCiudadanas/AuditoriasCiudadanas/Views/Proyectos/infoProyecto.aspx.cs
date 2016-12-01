using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class infoProyecto : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
 
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_proyecto = "0000";
            string outTxt = "";
            //AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
            //outTxt = datos.obtInfoProyecto(id_proyecto);
            //Response.Write(outTxt);
        }
    }
}