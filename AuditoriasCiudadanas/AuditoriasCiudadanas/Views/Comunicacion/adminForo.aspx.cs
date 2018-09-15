using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AuditoriasCiudadanas.Models;
using System.Text;
using System.Collections.Specialized;

namespace AuditoriasCiudadanas.Views.Comunicacion
{
    public partial class adminForo : System.Web.UI.Page //: App_Code.PageSession
    {

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
                    int idUsuario = int.Parse(Session["idUsuario"].ToString());
                    string config = "0";
                    bool flagView = false;
                    bool flagPublish = false;
                    bool flagComment = false;
                    NameValueCollection pColl = Request.Params;

                    if (pColl.AllKeys.Contains("config"))
                    {
                        config = Request.Params.GetValues("config")[0].ToString();
                    }

                    hdIdUsuario.Value = idUsuario.ToString();
                    hdIdForoConfig.Value = config;

                    Controllers.UsuariosController DatosUsu = new Controllers.UsuariosController();
                    List<DataTable> rtaUsu = DatosUsu.obtPerfilUsuarioTablas(idUsuario);

                    List<String> idPerfil = new List<string>();

                    idPerfil.Add(rtaUsu[0].Rows[0]["id_perfil"].ToString());

                    if (rtaUsu[4].Rows.Count > 0)
                    {
                        idPerfil.Add("99");
                    }

                    Controllers.ForoController Datos = new Controllers.ForoController();

                    DataTable configTable = Datos.GetForoConfig(int.Parse(config));
                    string idPerfilVer = "";
                    string idPerfilPublicar = "";
                    string idPerfilResponder = "";
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
                        NoSession.Visible = false;

                        List<EntityForo> rta = Datos.GetForos(int.Parse(config));

                        StringBuilder cadenaForos = new StringBuilder();

                        cadenaForos.AppendLine("<div class=\"sendBox well\">");
                        cadenaForos.AppendLine("<div class=\"form-group\">");
                        cadenaForos.AppendLine("<div class=\"row\">");
                        cadenaForos.AppendLine("<div class=\"col-md-8\">");
                        cadenaForos.AppendLine("<input type=\"text\" id =\"txtBuscarTema\" class=\"form-control\" placeholder=\"Buscar por tema o descripcion\">");
                        cadenaForos.AppendLine("</div>");
                        cadenaForos.AppendLine("<div class=\"col-md-2\" ><a class=\"btn btn-primary\" role =\"button\" id=\"btnBuscarTema\" ><span class=\"glyphicon glyphicon-search\" ></span> Buscar</a></div>");
                        if (flagPublish)
                            cadenaForos.AppendLine("<div class=\"col-md-2\" ><a class=\"btn btn-default pull-right\" role =\"button\" id=\"btnNuevoTema\" ><span class=\"glyphicon glyphicon-plus\" ></span> Nuevo Tema</a></div>");
                        cadenaForos.AppendLine("</div>");

                        cadenaForos.AppendLine("</div>");
                        cadenaForos.AppendLine("</div>");
                        cadenaForos.AppendLine("<div class=\"sendBox well\" style=\"display: none;\" id=\"divNuevoTema\">");
                        cadenaForos.AppendLine("<form>");
                        cadenaForos.AppendLine("<div class=\"form-group\">");
                        cadenaForos.AppendLine("<div class=\"row\">");
                        cadenaForos.AppendLine("<div class=\"col-md-10\">");
                        cadenaForos.AppendLine("<input type=\"text\" class=\"form-control\" id=\"txtTemaForo\" placeholder=\"Añade un nuevo tema\">");
                        cadenaForos.AppendLine("</div>");
                        cadenaForos.AppendLine("</div>");
                        cadenaForos.AppendLine("</div>");
                        cadenaForos.AppendLine("<div class=\"form-group\">");
                        cadenaForos.AppendLine("<textarea class=\"form-control\" rows=\"4\" id=\"txtDescripcionForo\" placeholder=\"Comparte un comentario\"></textarea>");
                        cadenaForos.AppendLine("</div>");
                        cadenaForos.AppendLine("<div class=\"form-group\">");
                        cadenaForos.AppendLine("<button class=\"btn btn-primary\" onclick=\"guardarTema(); return false;\" ><span class=\"glyphicon glyphicon-send\"></span> COMENTAR</button>");
                        cadenaForos.AppendLine("</div>");
                        cadenaForos.AppendLine("</form>");
                        cadenaForos.AppendLine("</div>");


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
                            cadenaForos.AppendLine("<a onclick=\"cargaMenuParams('Comunicacion/ForoDetalle', 'dvPrincipal', " + m.IdForo + ")\" >");
                            cadenaForos.AppendLine(@"<h3 class=""titQuestion"">" + m.Tema + "</h3>");
                            cadenaForos.AppendLine(@"</a>");
                            cadenaForos.AppendLine(@"<p class=""descQuestion"">" + m.Descripcion + "</p>");
                            cadenaForos.AppendLine(@"<div class=""optionsBtn"">");
                            if (flagComment)
                                cadenaForos.AppendLine("<div class=\"btn btn-primary\" data-toggle=\"collapse\" data-target=\"#newComent" + m.IdForo + "\" ><span class=\"glyphicon glyphicon-share-alt\"></span> Responder</div>");
                            cadenaForos.AppendLine("<div class=\"btn btn-default\" id=\"btnRespuestas" + m.IdForo + "\" onclick=\"verRespuestas(" + m.IdForo + ")\"><span class=\"glyphicon glyphicon-plus\"></span> Ver Respuestas</div>");
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

                        divInfoForo.InnerHtml += cadenaForos.ToString();
                    }
                    else
                        divInfoForo.Visible = false;

                }
                else
                    divInfoForo.Visible = false;
            }
        }
    }
}