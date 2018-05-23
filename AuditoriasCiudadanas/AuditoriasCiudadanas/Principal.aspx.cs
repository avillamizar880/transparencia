using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "GET")
            {
                //string nombre,string email,string celular,string hash_clave,int idperfil,int id_departamento,int id_municipio
                string opc = "";
                NameValueCollection pColl = Request.Params;

                if (pColl.AllKeys.Contains("opc"))
                {
                    opc = Request.Params.GetValues("opc")[0].ToString();
                    hdOpc.Value = opc;
                }
            }
            
            
            if (Session["idPerfil"] != null)// && Session["idRol"].ToString() == "1")
            {
                //adminMenu.Visible = true;
                btnSes.Attributes["menu"] = Session["idPerfil"].ToString();
            }
            else
            {
                //adminMenu.Visible = false;
                btnSes.Attributes["menu"] = "X";
            }


            if (Session["nombre"] != null)// && Session["idRol"].ToString() == "1")
            {
                //adminMenu.Visible = true;
                btnSes.Attributes["nombre"] = Session["nombre"].ToString();
            }
            else
            {
                //adminMenu.Visible = false;
                btnSes.Attributes["nombre"] = "CUENTA";
            }

            if (Session["cantNotificaciones"] != null)// && Session["idRol"].ToString() == "1")
            {
                //adminMenu.Visible = true;
                btnSes.Attributes["cantnotificaciones"] = Session["cantNotificaciones"].ToString();
            }
            else
            {
                //adminMenu.Visible = false;
                btnSes.Attributes["cantnotificaciones"] = "0";
            }

            if (Session["idUsuario"] != null)
            {
                hdIdUsuario.Attributes["value"] = Session["idUsuario"].ToString();
            }
            else {
                hdIdUsuario.Attributes["value"] = "";
            }
        }
    }
}