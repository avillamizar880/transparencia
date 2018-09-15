using AuditoriasCiudadanas.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public int idUsuario;

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
                    idUsuario = int.Parse(Session["idUsuario"].ToString());

                    if (Request.Form != null)
                    {
                        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
                            if (Request.Form.AllKeys[i] != null)
                                switch (Request.Form.AllKeys[i].ToString().ToUpper())
                                {
                                    case "PARAMETROINICIO":
                                        string parametrosInicio = Request.Form[i].ToString();
                                        idDelForo = int.Parse(parametrosInicio);
                                        loadForo(idDelForo);
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

        private void loadForo(int IdForo)
        {
            Controllers.ForoController Datos = new Controllers.ForoController();
            List<EntityForo> rta = Datos.GetForo(IdForo);

            StringBuilder cadenaForos = new StringBuilder();

            Controllers.UsuariosController DatosUsu = new Controllers.UsuariosController();
            List<DataTable> rtaUsu = DatosUsu.obtPerfilUsuarioTablas(idUsuario);

            List<String> idPerfil = new List<string>();

            idPerfil.Add(rtaUsu[0].Rows[0]["id_perfil"].ToString());

            if (rtaUsu[4].Rows.Count > 0)
            {
                idPerfil.Add("99");
            }

            Controllers.ForoController DatosC = new Controllers.ForoController();


            ForoConfig = rta[0].IdForoConfig;
            hdIdForoConfig.Value = ForoConfig.ToString();

            DataTable configTable = DatosC.GetForoConfig(ForoConfig);
            string idPerfilVer = "";
            string idPerfilPublicar = "";
            string idPerfilResponder = "";
            bool flagView = false;
            bool flagPublish = false;
            bool flagComment = false;
            h1Titulo.InnerText = configTable.Rows[0]["NombreForo"].ToString();
            if (configTable.Rows[0]["idPerfilVer"] != null)
                idPerfilVer = configTable.Rows[0]["idPerfilVer"].ToString();
            if (configTable.Rows[0]["idPerfilPublicar"] != null)
                idPerfilPublicar = configTable.Rows[0]["idPerfilPublicar"].ToString();
            if (configTable.Rows[0]["idPerfilResponder"] != null)
                idPerfilResponder = configTable.Rows[0]["idPerfilResponder"].ToString();

            foreach (string x in idPerfil)
            {
                if (String.IsNullOrEmpty(idPerfilVer) || idPerfilVer.Contains("|" + x + "|"))
                    flagView = true;
                if (String.IsNullOrEmpty(idPerfilPublicar) || idPerfilPublicar.Contains("|" + x + "|"))
                    flagPublish = true;
                if (String.IsNullOrEmpty(idPerfilResponder) || idPerfilResponder.Contains("|" + x + "|"))
                {
                    flagComment = true;
                    hdFA.Value = idUsuario.ToString();
                }
            }

            if (flagView)
            {
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
                    if (flagComment)
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
            }
                

            divInfoForoDetalle.InnerHtml += cadenaForos.ToString();


        }
    }
}