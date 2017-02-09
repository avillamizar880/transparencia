using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace AuditoriasCiudadanas.Views.Estadisticas
{
    public partial class infoEstadisticas : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
 
        protected void Page_Load(object sender, EventArgs e)
        {
            string outTxt = "";
            if (Session["idUsuario"] != null)
            {
                hdIdUsuario.Value = Session["idUsuario"].ToString();
            }
            AuditoriasCiudadanas.Controllers.EstadisticasController datos = new AuditoriasCiudadanas.Controllers.EstadisticasController();
            outTxt = "<script>" + datos.obtEstadisticas("all") + "</script>";
            Response.Write(outTxt);
        }
    }
}