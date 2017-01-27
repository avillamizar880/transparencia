using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Data;


namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class agregarInfoTecnica_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string bpin_proyecto = "";
            string titulo="";
            string descripcion="";
            string[] rutas={"",""};
            int id_usuario_aux = 0;
            string outTxt = "";
            string ruta = "";
            string cod_error = "";
            string msg_error = "";
            string id_usuario = "";
            string opcion = "";
            string idInfo = "";
         
                if (HttpContext.Current.Request.HttpMethod == "POST")
                {
                    NameValueCollection pColl = Request.Params;
                    if (pColl.AllKeys.Contains("cod_bpin"))
                    {
                        bpin_proyecto = Request.Params.GetValues("cod_bpin")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("titulo")){
                        titulo = Request.Params.GetValues("titulo")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("descripcion")){
                        descripcion = Request.Params.GetValues("descripcion")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("id_usuario")){
                        id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                        if (!string.IsNullOrEmpty(id_usuario)) { 
                        id_usuario_aux = Convert.ToInt16(id_usuario);
                        }
                    }
                    if (pColl.AllKeys.Contains("opcion"))
                    {
                        opcion = Request.Params.GetValues("opcion")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("id_info"))
                    {
                        idInfo = Request.Params.GetValues("id_info")[0].ToString();
                    }
                   
                    string pathrefer = Request.UrlReferrer.ToString();
                    string dir_upload = ConfigurationManager.AppSettings["ruta_infoTecnica"];
                    string Serverpath = HttpContext.Current.Server.MapPath("~/" + dir_upload);
                    var postedFile = Request.Files[0];
                    string file;
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
                        file = Request.QueryString["fileName"];
                        if (File.Exists(fileDirectory + "\\" + file))
                        {
                            File.Delete(fileDirectory + "\\" + file);
                        }
                    }
                    string ext = Path.GetExtension(fileDirectory + "\\" + file);
                    fileDirectory = Serverpath + "\\" + file;
                    postedFile.SaveAs(fileDirectory);
                    if (File.Exists(fileDirectory))
                    {
                        ruta = dir_upload + "/" + file;
                        rutas[0] = ruta;
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

                        if (opcion.Equals("new") || string.IsNullOrEmpty(idInfo))
                        {
                            //add info tecnica
                            AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
                            outTxt = datos.addInfoTecnica(bpin_proyecto, titulo, descripcion, rutas, id_usuario_aux);
                            string[] separador = new string[] { "<||>" };
                            var result = outTxt.Split(separador, StringSplitOptions.None);
                            cod_error = result[0];
                            msg_error = result[1];
                        }
                        else { 
                            //editar info tecnica
                            if (!string.IsNullOrEmpty(idInfo)) {
                                AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
                                int idInfo_aux = Convert.ToInt16(idInfo);
                                outTxt = datos.modifInfoTecnica(idInfo_aux,titulo,descripcion,rutas,id_usuario_aux);
                                string[] separador = new string[] { "<||>" };
                                var result = outTxt.Split(separador, StringSplitOptions.None);
                                cod_error = result[0];
                                msg_error = result[1];
                            }

                        }
                        

                    }
                    else
                    {
                        cod_error = "-1";
                        msg_error = "Error al subir al archivo";
                    }

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
    }
}