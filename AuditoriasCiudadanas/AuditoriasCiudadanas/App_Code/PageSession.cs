using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.App_Code
{
    public class PageSession : System.Web.UI.Page
    {

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        private string urlRedireccion()
        {
            string urlRedir = "";
            //if (Request.Url.IsDefaultPort)
            //{
            //    urlRedir = "http://" + Request.Url.Host + ConfigurationManager.AppSettings["urlSession"].ToString();
            //}
            //else
            //{
            //    urlRedir = "http://" + Request.Url.Host + ":" + Request.Url.Port + ConfigurationManager.AppSettings["urlSession"].ToString();
            //}
            urlRedir = ConfigurationManager.AppSettings["dominio_app"] + ConfigurationManager.AppSettings["urlSession"].ToString();
            return urlRedir;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session["idRol"] == null)
            {
                Response.Clear();
                Response.Write("&nbsp;<script id=\"ajax\">alert('Sesión vencida');window.top.location.href=\"" + urlRedireccion() + "\";</script>");
                Response.End();

            }
        }

        protected void cerrarSesion()
        {
            Session.Clear();
            Session.Abandon();
            //Response.Write("<script id=""ajax"">window.top.location.href=""" & urlRedireccion() & """;</script>")
            Response.Write(" &nbsp;<script id =\"ajax\">window.top.location.href=\"" + urlRedireccion() + "\";</script>");
            Response.End();
        }
        /// <summary>
        /// Metodo para manejar los errores
        /// </summary>
        /// <param name="ex"></param>
        /// <remarks></remarks>
        protected void reportaError(System.Exception ex)
        {
            if (ex != null)
            {
                HttpContext.Current.Response.Write("Error ocurrido: " + ex.Message);
            }

        }


    }
}