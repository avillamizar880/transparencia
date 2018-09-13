using AuditoriasCiudadanas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Comunicacion
{
    public partial class ForoDetalle : System.Web.UI.Page
    {
        public int idDelForo;
        public int ForoConfig;

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idUsuario"] != null)
                {
                    NoSession.Visible = false;
                    hdIdUsuario.Value = Session["idUsuario"].ToString();

                    if (Request.Form != null)
                    {
                        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
                            if (Request.Form.AllKeys[i] != null)
                                switch (Request.Form.AllKeys[i].ToString().ToUpper())
                                {
                                    case "PARAMETROINICIO":
                                        string[] parametrosInicio = Request.Form[i].ToString().Split('@');
                                        idDelForo = int.Parse(parametrosInicio[0]);
                                        ForoConfig = int.Parse(parametrosInicio[1]);
                                        hdIdForoConfig.Value = parametrosInicio[1];
                                        loadForo(idDelForo, ForoConfig);
                                        break;
                                }
                    }


                }
            }
            else
            {
                divInfoForoDetalle.Visible = false;
            }
        }

        private void loadForo(int IdForo, int foroConfig)
        {
            Controllers.ForoController Datos = new Controllers.ForoController();
            List<EntityForo> rta = Datos.GetForo(IdForo, foroConfig);

            StringBuilder cadenaForos = new StringBuilder();

            rta.ForEach(m =>
            {
                cadenaForos.AppendLine(@"<div class=""questionsBox row"">");
                cadenaForos.AppendLine(@"<div class=""col-md-1"">");
                cadenaForos.AppendLine(@"<div class=""imgUser"">");
                cadenaForos.AppendLine(@"<img class=""img-responsive"" src=""Content/img/imagUser.jpg"" />");
                cadenaForos.AppendLine(@"</div>");
                cadenaForos.AppendLine(@"<div class=""text-center"">" + m.Nombre + "</div>");
                cadenaForos.AppendLine(@"</div>");
                cadenaForos.AppendLine("<div class=\"col-md-11\" id=\"foro" + m.IdForo + "\">");
                cadenaForos.AppendLine(@"<div class=""label simple-label"">" + m.FechaCreacion.ToString("yyyy-MM-dd hh:mm tt") + "</div>");
                cadenaForos.AppendLine(@"<div class=""label simple-label"">Tema</div>");
                cadenaForos.AppendLine(@"<a href=""#"" >");
                cadenaForos.AppendLine(@"<h3 class=""titQuestion"">" + m.Tema + "</h3>");
                cadenaForos.AppendLine(@"</a>");
                cadenaForos.AppendLine(@"<p class=""descQuestion"">" + m.Descripcion + "</p>");
                cadenaForos.AppendLine(@"<div class=""optionsBtn"">");
                cadenaForos.AppendLine("<div class=\"btn btn-primary\" data-toggle=\"collapse\" data-target=\"#newComent" + m.IdForo + "\" ><span class=\"glyphicon glyphicon-share-alt\"></span> Responder</div>");
                //cadenaForos.AppendLine("<div class=\"btn btn-default\" id=\"btnRespuestas" + m.IdForo + "\" onclick=\"verRespuestas(" + m.IdForo + ")\"><span class=\"glyphicon glyphicon-plus\"></span> Ver Respuestas</div>");
                cadenaForos.AppendLine(@"</div>");
                cadenaForos.AppendLine("<div class=\"collapse\" id=\"newComent" + m.IdForo + "\" > ");
                cadenaForos.AppendLine("<div class=\"comentBox\" > ");
                cadenaForos.AppendLine("<label>Escriba aqui su respuesta</label>");
                cadenaForos.AppendLine("<textarea rows=\"4\" class=\"form-control\" id=\"txtMensaje" + m.IdForo + "\"></textarea>");
                cadenaForos.AppendLine("<button class=\"btn btn-primary\" onclick=\"guardarRespuesta(" + m.IdForo + ");\" ><span class=\"glyphicon glyphicon-send\" ></span> Enviar</button>");
                cadenaForos.AppendLine("</div>");
                cadenaForos.AppendLine("</div>");
                cadenaForos.AppendLine(@"</div>");
                cadenaForos.AppendLine(@"</div>");
            });

            divInfoForoDetalle.InnerHtml += cadenaForos.ToString();


        }
    }
}