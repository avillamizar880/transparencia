using AuditoriasCiudadanas.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
                    //NoSession.Visible = false;
                    //string script = @"<script src=""Scripts/Usuarios/Notificaciones.js"" type=""text/javascript""></script>";
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Notificaciones", script);

                    idUsuario = (string)Session["idUsuario"];
                    cargarNotifaciones(int.Parse(idUsuario));



                    AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();

                    DataTable rta = datos.obtPerfilUsuarioTabla(int.Parse(idUsuario));
                    NombreUsuario.Text = rta.Rows[0]["Nombre"].ToString();
                }
                else
                {
                    //contentDiv.Visible = false;
                }
            }
        }

        private void cargarNotifaciones(int idUsuario)
        {
            divNoNotificaciones.Visible = false;
            AuditoriasCiudadanas.Controllers.NotificacionController Datos = new AuditoriasCiudadanas.Controllers.NotificacionController();
            List<EntityNotificacion> rta = Datos.GetNotificaciones(idUsuario, '0');

            StringBuilder cadenaMensajes = new StringBuilder();

            int cantidadNot = 0;
            rta.ForEach(m =>
            {
                cadenaMensajes.AppendLine("<div class=\"list-group-item newsProfile\" > ");
                cadenaMensajes.AppendLine("	<div class=\"col-md-2 blueBg text-center\" >" + m.TipoDescripcion + "</div>");
                cadenaMensajes.AppendLine("	<div class=\"col-md-7\" > <a href = \"#\" onclick=\"AccionNotificacion(\'" + m.IdNotificacion.ToString() + "\',\'" + m.Tipo + "\', " + m.Parametros.Replace("\"", "'") + ");\" >" + m.Mensaje + "</a></div>");
                cadenaMensajes.AppendLine("	<div class=\"col-md-2 text-center\" >" + m.FechaCreacion.ToString("yyyy/MM/dd hh:mm tt") + "</div>");
                cadenaMensajes.AppendLine("	<div class=\"col-md-1 text-center\" ><a onclick=\"eliminarNotificacion(\'" + m.IdNotificacion.ToString() + "\');\" role=\"button\"> <span class=\"glyphicon glyphicon-trash\"></span></a></div>");
                cadenaMensajes.AppendLine("</div>");


                /*cadenaMensajes.AppendLine("<div class=\"panel panel-notificacion\">");
                cadenaMensajes.AppendLine("<div class=\"panel-body row\">");
                cadenaMensajes.AppendLine("<div class=\"col-md-10\">");
                cadenaMensajes.AppendLine("<span class=\"label label-default\">" + m.FechaCreacion.ToString("yyyy/MM/dd hh:mm tt") + "</span>");
                cadenaMensajes.AppendLine("<a href = \"#\" onclick=\"AccionNotificacion(\'" + m.IdNotificacion.ToString() + "\',\'" + m.Tipo + "\', " + m.Parametros.Replace("\"", "'") + ");\" >" + m.Mensaje + "</a>");
                cadenaMensajes.AppendLine("</div>");
                cadenaMensajes.AppendLine("<div class=\"col-md-2 text-right\">");
                cadenaMensajes.AppendLine("<a onclick=\"eliminarNotificacion(\'" + m.IdNotificacion.ToString() + "\');\" class=\"btn btn-link\"> <span class=\"glyphicon glyphicon-trash\"></span></a>");
                cadenaMensajes.AppendLine("</div>");
                cadenaMensajes.AppendLine("</div>");
                cadenaMensajes.AppendLine("</div>");*/
                cantidadNot++;
            });

            if (cantidadNot == 0)
            {
                divNoNotificaciones.Visible = true;
                pNotificaciones.Visible = false;
                tbNotificaciones.Visible = false;
            }
            lblCantNot.Text = cantidadNot.ToString();
            tbNotificaciones.InnerHtml = cadenaMensajes.ToString();

        }
    }
}