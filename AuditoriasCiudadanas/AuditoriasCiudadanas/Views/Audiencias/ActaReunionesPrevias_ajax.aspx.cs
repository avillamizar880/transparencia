using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class ActaReuniones_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Crear usuario en bd
            string outTxt = "";
            string tema = "";
            string id_lugar = "";
            string fecha = "";
            string cod_bpin = "";
            string id_usuario = "";
            int id_usuario_aux = 0;
            int id_lugar_aux = 0;
            string ruta = "";
            string cod_error="";
            string msg_error="";
            DateTime fecha_aux = DateTime.Now;
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();

            try
            {
                if (HttpContext.Current.Request.HttpMethod == "POST")
                {
                    NameValueCollection pColl = Request.Params;
                    if (pColl.AllKeys.Contains("id_usuario"))
                    {
                        id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                        if (!string.IsNullOrEmpty(id_usuario))
                        {
                            id_usuario_aux = Convert.ToInt16(id_usuario);
                        }
                    }
                    if (pColl.AllKeys.Contains("tema"))
                    {
                        tema = Request.Params.GetValues("tema")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("id_lugar"))
                    {
                        id_lugar = Request.Params.GetValues("id_lugar")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("fecha"))
                    {
                        fecha = Request.Params.GetValues("fecha")[0].ToString();
                        if (!string.IsNullOrEmpty(fecha))
                        {
                            fecha_aux = DateTime.Parse(fecha);
                        }
                    }
                    if (pColl.AllKeys.Contains("cod_bpin"))
                    {
                        cod_bpin = Request.Params.GetValues("cod_bpin")[0].ToString();
                    }

                    string pathrefer = Request.UrlReferrer.ToString();
                    string dir_upload= ConfigurationManager.AppSettings["ruta_actas"];
                    string Serverpath = HttpContext.Current.Server.MapPath("~/"+ dir_upload);
                    var postedFile = Request.Files[0];
                    string file;
                    string nom_arch = "";
                    if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                    {
                        string[] files = postedFile.FileName.Split(new char[] { '\\' });
                        file = files[files.Length - 1];
                    }
                    else // In case of other browsers
                    {
                        file = postedFile.FileName;
                    }

                    if (!Directory.Exists(Serverpath))
                        Directory.CreateDirectory(Serverpath);

                    string fileDirectory = Serverpath;
                    if (Request.QueryString["fileName"] != null)
                    {
                        Random rnd = new Random();
                        int cont = rnd.Next(1000, 1000001);
                        //file = Request.QueryString["fileName"];
                        string ext = Path.GetExtension(fileDirectory + "\\" + file);
                        file = "asistenciareuprevias_" + cod_bpin + cont.ToString() + ext;
                        if (File.Exists(fileDirectory + "\\" + file))
                        {
                            File.Delete(fileDirectory + "\\" + file);
                        }
                    }

                    fileDirectory = Serverpath + "\\" + file;

                    postedFile.SaveAs(fileDirectory);
                    if (File.Exists(fileDirectory))
                    {
                       
                        ruta = file;
                        Response.AddHeader("Vary", "Accept");
                        try
                        {
                            if (Request["HTTP_ACCEPT"].Contains("application/json"))
                                Response.ContentType = "application/json";
                            else
                                Response.ContentType = "text/plain";
                        }
                        catch
                        {
                            Response.ContentType = "text/plain";
                        }

                        AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
                        outTxt = datos.insActaReuniones(cod_bpin, fecha_aux, tema, ruta, id_usuario_aux, id_lugar);
                        string[] separador = new string[] { "<||>" };
                        var result = outTxt.Split(separador, StringSplitOptions.None);
                        cod_error = result[0];
                        msg_error = result[1];
                        
                    }
                    else {
                        outTxt = "-1<||>Error al subir archivo";
                        cod_error="-1";
                        msg_error="Error al subir al archivo";
                    }

                    cod_error = "-1";
                    msg_error = "Error al subir al archivo";

                    DataTable dt_errores = new DataTable();
                    dt_errores.Columns.Add("cod_error", typeof(string));
                    dt_errores.Columns.Add("msg_error", typeof(string));
                    dt_errores.Rows.Add(cod_error, msg_error);
                    AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
                    outTxt = datos_func.convertToJson(dt_errores);

                    Response.Write(outTxt);
                    //Response.End();
                }

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }

        }
    }
}
