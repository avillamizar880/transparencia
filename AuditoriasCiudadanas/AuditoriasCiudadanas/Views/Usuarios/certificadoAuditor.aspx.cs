using AuditoriasCiudadanas.App_Code;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class certificadoAuditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string idUsuarioStr = "";
                idUsuarioStr = Request["key"];
                int idUsuario = 0;

                if (int.TryParse(SafeParams.decode(idUsuarioStr), out idUsuario))
                {
                    AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();

                    List<DataTable> rta = datos.obtCertificadoAuditor(idUsuario);

                    if (rta[0].Rows.Count == 0)
                    {
                        Response.Clear();
                        Response.ClearHeaders();
                        Response.Write("No es posible generar Certificado: No tienes suficientes puntos.");
                        dvContenido.InnerHtml = "";
                    }
                    else
                    {
                        lblNombre.Text = rta[1].Rows[0]["nombre"].ToString();
                        lblCategoria.Text = rta[1].Rows[0]["categoria"].ToString();

                        //dgProyectos.DataSource = rta[0];
                        //dgProyectos.DataBind();

                        string contenido = "<table class=\"table\">"
                            + "<tr>"
                                + "<th>CodigoBPIN</th>"
                                + "<th>Nombre</th>"
                                + "<th>Municipio</th>"
                                + "<th>Puntaje</th>"
                            + "</tr>";

                        foreach (DataRow row in rta[0].Rows)
                        {
                            contenido += "<tr>"
                                +"<td>" + row["CodigoBPIN"].ToString() + "</td>"
                                + "<td>" + row["Nombre"].ToString() + "</td>"
                                + "<td>" + row["Municipio"].ToString() + "</td>"
                                + "<td>" + row["Puntaje"].ToString() + "</td>"
                            + "</tr>";
                        }

                        dvTabla.InnerHtml = contenido + "</table>";
                    }
                }
                else
                {
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.Write("No es posible generar Certificado: No tienes permisos o la sesión ha vencido.");
                    dvContenido.InnerHtml = "";
                }
            }
            catch (Exception ex)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.Write("No es posible generar Certificado: No tienes permisos o la sesión ha vencido.");
                dvContenido.InnerHtml = "";
            }
            

            
        }
    }
}