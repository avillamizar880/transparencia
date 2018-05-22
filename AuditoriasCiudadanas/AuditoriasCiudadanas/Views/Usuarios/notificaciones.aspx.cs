using AuditoriasCiudadanas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class notificaciones : System.Web.UI.Page
    {
        private string idUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idUsuario"] != null)
                {
                    NoSession.Visible = false;
                    string script = @"<script src=""Scripts/Usuarios/Notificaciones.js"" type=""text/javascript""></script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Notificaciones", script);
                    
                    idUsuario = (string)Session["idUsuario"];
                    cargarNotifaciones(int.Parse(idUsuario));


                }
                else
                {
                    contentDiv.Visible = false;
                }
            }
        }

        private void cargarNotifaciones(int idUsuario)
        {
            AuditoriasCiudadanas.Controllers.NotificacionController Datos = new AuditoriasCiudadanas.Controllers.NotificacionController();
            List<EntityNotificacion> rta = Datos.GetNotificaciones(idUsuario, '0');

            StringBuilder cadenaMensajes = new StringBuilder();

            rta.ForEach(m => {
                cadenaMensajes.AppendLine(@"<tr>");
                cadenaMensajes.AppendLine(@"<td>" + m.Mensaje + "</td>");
                cadenaMensajes.AppendLine(@"<td>" + m.FechaCreacion.ToString("yyyy/MM/dd hh:mm tt") + "</td>");
                cadenaMensajes.AppendLine(@"<td>");
                cadenaMensajes.AppendLine("<a class=\"btn btn-info btn-sm\" onclick=\"AccionNotificacion(\'" + m.IdNotificacion.ToString() + "\',\'" + m.Tipo + "\', " + m.Parametros.Replace("\"","'") + ");\" >Ver</a>");
                cadenaMensajes.AppendLine(@"</td>");
                cadenaMensajes.AppendLine(@"</tr>");
            });

            tbNotificaciones.InnerHtml = cadenaMensajes.ToString();

        }
    }
}