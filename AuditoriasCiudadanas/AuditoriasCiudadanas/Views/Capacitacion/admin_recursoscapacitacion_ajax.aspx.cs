using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Capacitacion
{
    public partial class admin_recursoscapacitacion_ajax : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string opcion = "";
            string id_usuario = "";
            string tituloRec = "";
            string tipoRec = "";
            string url = "";
            string modulo = "";
            string outTxt = "";
            string id_cap = "";
            string id_reccap = "";
            string ruta = "";
            string cod_error = "";
            string msg_error = "";
            string datos_result = "";

            int id_usuario_aux = 0;
            int id_cap_aux = 0;
            int tipo_aux = 0;
            int modulo_aux = 0;
            int id_reccap_aux = 0;

            DataTable objReturn = new DataTable();


            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;

                if (pColl.AllKeys.Contains("opc"))
                {
                    opcion = Request.Params.GetValues("opc")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_cap"))
                {
                    id_cap = Request.Params.GetValues("id_cap")[0].ToString();
                }
                if (!string.IsNullOrEmpty(id_cap))
                {
                    id_cap_aux = Convert.ToInt16(id_cap);
                }
                if (pColl.AllKeys.Contains("id_Rcap"))
                {
                    id_reccap = Request.Params.GetValues("id_Rcap")[0].ToString();
                }
                if (!string.IsNullOrEmpty(id_reccap))
                {
                    id_reccap_aux = Convert.ToInt16(id_reccap);
                }
                if (opcion.ToUpper().Equals("LIST"))
                {
                    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    outTxt = datosUsuario.ObtListadoRecCapacitacion(id_cap_aux);
                }
                
                else
                {
                    if (pColl.AllKeys.Contains("id_usuario"))
                    {
                        id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("titulo"))
                    {
                        tituloRec = Request.Params.GetValues("titulo")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("tipo"))
                    {
                        tipoRec = Request.Params.GetValues("tipo")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("url"))
                    {
                        url = Request.Params.GetValues("url")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("modulo"))
                    {
                        modulo = Request.Params.GetValues("modulo")[0].ToString();
                    }
                    if (!string.IsNullOrEmpty(modulo))
                    {
                        modulo_aux = Convert.ToInt16(modulo);
                    }
                    if (pColl.AllKeys.Contains("tipo"))
                    {
                        tipoRec = Request.Params.GetValues("tipo")[0].ToString();
                    }
                    if (!string.IsNullOrEmpty(tipoRec))
                    {
                        tipo_aux = Convert.ToInt16(tipoRec);
                    }
                    if (!string.IsNullOrEmpty(id_usuario))
                    {
                        id_usuario_aux = Convert.ToInt16(id_usuario);
                    }
                    
                    if (opcion.ToUpper().Equals("ADD"))
                    {
                        //si el tipo de archivo es pdf
                        if (tipo_aux==2)
                        {
                            string pathrefer = Request.UrlReferrer.ToString();
                            string dir_upload = ConfigurationManager.AppSettings["ruta_audiencias"];
                            string urlRedir = ConfigurationManager.AppSettings["dominio_app"];
                            string Serverpath = HttpContext.Current.Server.MapPath("~/" + dir_upload);

                            HttpFileCollection hfc = Request.Files;

                            for (int i = 0; i < hfc.Count; i++)
                            {
                                HttpPostedFile postedFile = hfc[i];
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
                                //file = Guid.NewGuid() + ext; // Creating a unique name for the file 

                                fileDirectory = Serverpath + "\\" + file;

                                postedFile.SaveAs(fileDirectory);
                                if (File.Exists(fileDirectory))
                                {
                                    url = urlRedir + dir_upload + "/" + file;
                                }
                                else
                                {
                                    outTxt = "-1<||>" + "Error al guardar archivo pdf";

                                }
                            }
                        }

                        AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                        outTxt = datosUsuario.addRecCapacitacion(tituloRec, tipo_aux, modulo_aux, id_cap_aux, url, id_usuario_aux);
                    }

                    else if (opcion.ToUpper().Equals("DEL"))
                    {
                        AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                        outTxt = datosUsuario.delRecCapacitacion(id_reccap_aux, id_usuario_aux);
                    }
                    else if (opcion.ToUpper().Equals("MOD"))
                    {
                        AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                        outTxt = datosUsuario.updTemaCapacitacion(id_cap_aux, tituloRec, tipoRec, id_usuario_aux);
                    }

                }

                string out_result = "";
                if (!opcion.ToUpper().Equals("LIST") && outTxt.IndexOf("<||>") > -1)
                {
                    string[] separador = new string[] { "<||>" };
                    var result = outTxt.Split(separador, StringSplitOptions.None);
                    cod_error = result[0];
                    msg_error = result[1];
                    DataTable dt_errores = new DataTable();
                    dt_errores.Columns.Add("cod_error", typeof(string));
                    dt_errores.Columns.Add("msg_error", typeof(string));
                    dt_errores.Columns.Add("datos_result", typeof(string));

                    dt_errores.Rows.Add(cod_error, msg_error,datos_result);
                    AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
                    out_result = datos_func.convertToJson(dt_errores);

                }
                else {
                    out_result = outTxt;
                }
               

                Response.Write(out_result);
                

            }
        }
    }
}