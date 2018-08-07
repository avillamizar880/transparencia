using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class Ranking : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_usuario = "";

            NameValueCollection pColl = Request.Params;

            if (Session["idUsuario"] != null)
            {
                id_usuario = Session["idUsuario"].ToString();
            }
            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
            }

            hdIdUsuario.Value = id_usuario;
            int idusuario = Convert.ToInt16(id_usuario);

            string outTxt = "";
            AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();
            outTxt = "<script>" + datos.obtRanking(idusuario) + "</script>";
            Response.Write(outTxt);
        }
    }
}