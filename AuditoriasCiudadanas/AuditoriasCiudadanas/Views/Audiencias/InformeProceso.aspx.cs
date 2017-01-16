using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class InformeProceso : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_usuario = "";
            string id_proyecto = "";
            string idtipoaud = "";
            string idaud = "";
            string id_GAC = "";
            int idgac_aux = 0;
            int idaud_aux = 0;
            int idtipoaud_aux = 0; 

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
            if (pColl.AllKeys.Contains("id_GAC"))
            {
                id_GAC = Request.Params.GetValues("id_GAC")[0].ToString();
                if (!string.IsNullOrEmpty(id_GAC))
                {
                    idgac_aux = Convert.ToInt16(id_GAC);
                }
            }
            if (pColl.AllKeys.Contains("idtipoaud"))
            {
                idtipoaud = Request.Params.GetValues("idtipoaud")[0].ToString();
                if (!string.IsNullOrEmpty(idtipoaud))
                {
                    idtipoaud_aux = Convert.ToInt16(idtipoaud);
                }
            }
            if (pColl.AllKeys.Contains("idaud"))
            {
                idaud = Request.Params.GetValues("idaud")[0].ToString();
                if (!string.IsNullOrEmpty(idaud))
                {
                    idaud_aux = Convert.ToInt16(idaud);
                }
            }

            hfidproyecto.Value = id_proyecto;
            hdIdUsuario.Value = id_usuario;
            hdIdidtipoaud.Value = idtipoaud;
            hdIdGAC.Value = id_GAC;
            hdidaud.Value = idaud;

            string outTxt = "";
            AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
            outTxt = "<script>" + datos.obtInformeProceso(id_proyecto, idgac_aux, idtipoaud_aux, idaud_aux) + "</script>";
            Response.Write(outTxt);
            //Response.End();
        }
    }
}