using AuditoriasCiudadanas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Chat
{
    public partial class Principal : System.Web.UI.Page
    {
        private string idDestinatario;
        private string idUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idUsuario"] != null)
                {
                    NoSessionP.Visible = false;
                    //if (Session["ListarUsuariosScript"] == null)
                    //{
                    string script = @"<script src=""Scripts/ComunicacionVirtual/ChatPrincipal.js"" type=""text/javascript""></script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ChatPrincipal", script);
                    //Session["ListarUsuariosScript"] = true;
                    //}

                    if (Request.Form != null)
                    {
                        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
                            if (Request.Form.AllKeys[i] != null)
                                switch (Request.Form.AllKeys[i].ToString().ToUpper())
                                {
                                    case "PARAMETROINICIO":
                                        var parametrosInicio = Request.Form[i].ToString().Split('*');
                                        lblDestinatario.Text = parametrosInicio[1].ToString();
                                        idDestinatario = parametrosInicio[0].ToString();
                                        idUsuario = (string)Session["idUsuario"];
                                        hdnIdRemitente.Value = idUsuario;
                                        hdnIdDestinatario.Value = idDestinatario;
                                        cargarHistorial(int.Parse(idUsuario), int.Parse(idDestinatario), parametrosInicio[1].ToString());
                                        break;
                                }
                    }


                }
                else
                {
                    contentDivP.Visible = false;
                }
            }
        }

        private void cargarHistorial(int idUsuario, int idDestinatario, string nombreDestinatario)
        {
            AuditoriasCiudadanas.Controllers.ChatController Datos = new AuditoriasCiudadanas.Controllers.ChatController();
            List<EntityMensaje> rta = Datos.GetMensajes(idUsuario, idDestinatario);

            StringBuilder cadenaMensajes = new StringBuilder();

            rta.ForEach(m => {
                string dice = "";
                if(m.IdRemitente == idUsuario)
                {
                    cadenaMensajes.AppendLine(@"<div class=""msgContainer dirLrtl usermsg"">");
                    //dice = @"<span style=""color:gray;font-size:9px; font-style:italic;"">" + m.FechaCreacion.ToString("yyyy/MM/dd hh:mm tt") + " - Yo digo:</span><br />";
                    dice = "right";
                }
                else
                {
                    cadenaMensajes.AppendLine(@"<div class=""msgContainer"">");
                    //dice = @"<span style=""color:gray;font-size:9px; font-style:italic;"">" + m.FechaCreacion.ToString("yyyy/MM/dd hh:mm tt") + " - " + nombreDestinatario + " dice:</span><br />";
                    dice = "left";
                }

                cadenaMensajes.AppendLine(@"<div class=""media"">");
                cadenaMensajes.AppendLine(@"<div class=""media-" + dice + @" media-middle"">");
                cadenaMensajes.AppendLine(@"<a href=""#"">");
                cadenaMensajes.AppendLine(@"<span class=""glyphicon glyphicon-user""></span>");
                cadenaMensajes.AppendLine(@"</a>");
                cadenaMensajes.AppendLine(@"</div>");
                cadenaMensajes.AppendLine(@"<div class=""media-body"">");
                cadenaMensajes.AppendLine("<small>" + m.FechaCreacion.ToString("yyyy-MM-dd hh:mm tt") + "</small>");
                cadenaMensajes.AppendLine("<p>" + m.Mensaje + "</p>");
                cadenaMensajes.AppendLine(@"</div>");
                cadenaMensajes.AppendLine(@"</div>");
                cadenaMensajes.AppendLine(@"</div>");
                
            });

            divMessageHistory.InnerHtml = cadenaMensajes.ToString();

        }
    }
}