using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

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
           // Session["idUsuario"] = "4";
           // Session["bpinProyecto"] = "002";
            string accion = "";

            if (Session["idUsuario"] != null)
            {
                hdIdUsuario.Value = Session["idUsuario"].ToString();
            }
            if (Session["idPerfil"] != null)
            {
                hdperfil.Value = Session["idPerfil"].ToString();
            }
            if (Session["idRol"] != null)
            {
                hdrol.Value = Session["idRol"].ToString();
            }
            string id_proyecto = "";
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_proyecto"))
            {
                id_proyecto = Request.Params.GetValues("id_proyecto")[0].ToString();
            }
            if (pColl.AllKeys.Contains("accion"))
            {
                accion = Request.Params.GetValues("accion")[0].ToString();
            }
            hfidproyecto.Value = id_proyecto;
            hdAccion.Value = accion;
        }
    }
}