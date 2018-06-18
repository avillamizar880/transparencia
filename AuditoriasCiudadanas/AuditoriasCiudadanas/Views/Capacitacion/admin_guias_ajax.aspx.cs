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
    public partial class admin_guias_ajax : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Request.HttpMethod == "POST")
                {
                    string tipo = "";
                    string id_usuario = "";
                    string titulo = "";
                    string descripcion = "";
                    string ruta = "";
                    string cod_error = "";
                    string msg_error = "";
                    int tipo_aux = 0;
                    int id_usuario_aux = 0;
                    string outTxt = "";
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd");
                    string opcion = "";
                    string id_recurso = "";
                    int id_recurso_aux = 0;

                    NameValueCollection pColl = Request.Params;
                    if (pColl.AllKeys.Contains("tipo"))
                    {
                        tipo = Request.Params.GetValues("tipo")[0].ToString();
                        if (!string.IsNullOrEmpty(tipo))
                        {
                            tipo_aux = Convert.ToInt16(tipo);
                        }
                    }
                    if (pColl.AllKeys.Contains("id_usuario"))
                    {
                        id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                        if (!string.IsNullOrEmpty(id_usuario))
                        {
                            id_usuario_aux = Convert.ToInt16(id_usuario);
                        }
                    }
                    if (pColl.AllKeys.Contains("titulo"))
                    {
                        titulo = Request.Params.GetValues("titulo")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("desc"))
                    {
                        descripcion = Request.Params.GetValues("desc")[0].ToString();
                    }

                    if (pColl.AllKeys.Contains("id_recurso"))
                    {
                        id_recurso = Request.Params.GetValues("id_recurso")[0].ToString();
                        if (!string.IsNullOrEmpty(id_recurso))
                        {
                            id_recurso_aux = Convert.ToInt16(id_recurso);
                        }
                    }
                    if (pColl.AllKeys.Contains("opc"))
                    {
                        opcion = Request.Params.GetValues("opc")[0].ToString();
                    }

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
                        file = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "_" + file;
                            if (File.Exists(fileDirectory + "\\" + file))
                            {
                                File.Delete(fileDirectory + "\\" + file);
                            }


                        string ext = Path.GetExtension(fileDirectory + "\\" + file);
                        //file = Guid.NewGuid() + ext; // Creating a unique name for the file 

                        fileDirectory = Serverpath + "\\" + file;

                        postedFile.SaveAs(fileDirectory);
                        if (File.Exists(fileDirectory))
                        {
                            //ruta = urlRedir + dir_upload + "/" + file;
                            ruta = dir_upload + "/" + file;
                            if (opcion.ToUpper().Equals("ADD"))
                            {
                                Controllers.CapacitacionController datos = new Controllers.CapacitacionController();
                                outTxt = datos.addRecursoMultimedia(tipo_aux, titulo, descripcion, ruta, id_usuario_aux);

                                string[] separador = new string[] { "<||>" };
                                var result = outTxt.Split(separador, StringSplitOptions.None);
                                cod_error = result[0];
                                msg_error = result[1];

                            }
                            else {
                                if (id_recurso_aux > 0)
                                {
                                    //borrar anterior archivo
                                    Controllers.CapacitacionController datos = new Controllers.CapacitacionController();
                                    List<DataTable> lstdtInfo = datos.dtRecursoMultimediaById(id_recurso_aux);
                                    string ruta_old = lstdtInfo[0].Rows[0]["rutaUrl"].ToString();
                                    string Serverpath_old = HttpContext.Current.Server.MapPath("~" + ruta_old);

                                    if (File.Exists(Serverpath_old))
                                    {
                                        File.Delete(Serverpath_old);
                                    }

                                    outTxt = datos.modRecursoMultimedia(id_recurso_aux,titulo, descripcion, ruta, id_usuario_aux);

                                    string[] separador = new string[] { "<||>" };
                                    var result = outTxt.Split(separador, StringSplitOptions.None);
                                    cod_error = result[0];
                                    msg_error = result[1];

                                }
                                else {
                                    cod_error = "-1";
                                    msg_error = "Error al modificar, registro no válido";
                                }
                                
                            }

                            

                        }
                        else
                        {
                            cod_error = "-1";
                            msg_error = "Error al guardar archivo pdf";

                        }
                    }

                    DataTable dt_errores = new DataTable();
                    dt_errores.Columns.Add("cod_error", typeof(string));
                    dt_errores.Columns.Add("msg_error", typeof(string));
                    dt_errores.Rows.Add(cod_error, msg_error);
                    AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
                    outTxt = datos_func.convertToJson(dt_errores);

                    Response.Write(outTxt);

                }


            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }

        }
    }
}