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
            if (Request.Url.IsDefaultPort)
            {
                urlRedir = "http://" + Request.Url.Host; //+ ConfigurationManager.AppSettings("urlSession").ToString;
            }
            else
            {
                urlRedir = "http://" + Request.Url.Host + ":" + Request.Url.Port; //+ ConfigurationManager.AppSettings("urlSession").ToString;
            }
            return urlRedir;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //if (Session(clsValoresGlobales.prefijoSession + ".menuUsu") != null)
            //{
            //    //Ok usuario Validado

            //}
            //else
            //{
            //    //Response.Write("if (typeof fu_logOut_mesg  == 'function') {fu_logOut_mesg('Sesi&oacute;n vencida','" & urlRedireccion() & "');}else{alert('Session vencida');window.top.location.href=""" & urlRedireccion() & """;}")
            //    //Response.Write("<script id=""ajax"">if (typeof fu_logOut_mesg  == 'function') {fu_logOut_mesg('Sesi&oacute;n vencida','" & urlRedireccion() & "');}else{alert('Sesión vencida');window.top.location.href=""" & urlRedireccion() & """;}</script>")
            //    Response.Clear();
            //    Response.Write("&nbsp;<script id=\"ajax\">alert('Sesión vencida');window.top.location.href=\"" + urlRedireccion() + "\";</script>");
            //    Response.End();
            //    //---
            //    //Response.Write("<script id=""ajax"">var objF = new JSYCFrames(); objF.mostrarAlert({mensaje: mensajeAlert,cerrar: function () { window.top.location.href = '" & urlRedireccion() & "'; }});</script>")
            //    //Response.End()
            //}
        }

        protected void cerrarSesion()
        {
            Session.Clear();
            Session.Abandon();
            //Response.Write("<script id=""ajax"">window.top.location.href=""" & urlRedireccion() & """;</script>")
            Response.Write("window.top.location.href=\"" + urlRedireccion() + "\";");
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