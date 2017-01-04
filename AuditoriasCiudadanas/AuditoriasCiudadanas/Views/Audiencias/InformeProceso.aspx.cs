using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class InformeProceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_usuario = "";
            string id_proyecto = "";
            string idtipoaud = "";
            string idaud = "";
            NameValueCollection pColl = Request.Params;

            if (Session["idUsuario"] != null)
            {
                id_usuario = Session["idUsuario"].ToString();
            }
            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
            }
            if (pColl.AllKeys.Contains("cod_bpin"))
            {
                id_proyecto = Request.Params.GetValues("cod_bpin")[0].ToString();
            }
            if (pColl.AllKeys.Contains("idtipoaud"))
            {
                idtipoaud = Request.Params.GetValues("idtipoaud")[0].ToString();
            }
            if (pColl.AllKeys.Contains("idaud"))
            {
                idaud = Request.Params.GetValues("idaud")[0].ToString();
            }

            hfidproyecto.Value = id_proyecto;
            hdIdUsuario.Value = id_usuario;
            hdIdidtipoaud.Value = idtipoaud;
            hdidaud.Value = idaud;
        }
    }
}