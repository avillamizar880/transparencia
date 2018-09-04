using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
namespace AuditoriasCiudadanas.Views.GrupoAuditor
{
  public partial class InformeHallazgo_ajax : App_Code.PageSession
  {
    protected void Page_Load(object sender, EventArgs e)
    {
              string hallazgo = string.Empty;
              string grupoGacId = string.Empty;
              string idUsuario = string.Empty;
              string rutaImagen = string.Empty;
              string cod_error = string.Empty;
              string msg_error = string.Empty;
              string sal = string.Empty;
              string outTxt = "";
              string ruta = "";
              int grupoGacId_aux = 0;
              int idUsuario_aux = 0;

      try
      {
        if (HttpContext.Current.Request.HttpMethod == "POST")
        {

          
          int cant_adjuntos = 0;
          int cant_adjuntos_guardados = 0;
          string xml_adjuntos = "";
          NameValueCollection pColl = Request.Params;
          HttpFileCollection hfc = Request.Files;
          string pathrefer = Request.UrlReferrer.ToString();
          string dirupload = ConfigurationManager.AppSettings["ruta_reporte_hallazgo"];
          string Serverpath = HttpContext.Current.Server.MapPath("~/" + dirupload);

            if (pColl.AllKeys.Contains("hallazgo")) {
                hallazgo = Request.Params.GetValues("hallazgo")[0].ToString();

            }
            if (pColl.AllKeys.Contains("grupoGacId")) {
                grupoGacId = Request.Params.GetValues("grupoGacId")[0].ToString();
                if (!string.IsNullOrEmpty(grupoGacId)) {
                    grupoGacId_aux = Convert.ToInt16(grupoGacId);
                }
                            
            }
            if (pColl.AllKeys.Contains("idUsuario")) {
                idUsuario = Request.Params.GetValues("idUsuario")[0].ToString();
                if (!string.IsNullOrEmpty(idUsuario)) {
                    idUsuario_aux = Convert.ToInt16(idUsuario);
                }

            }

              cant_adjuntos = hfc.Count;
            //por cada archivo adjunto guarda y agrega a xml_adjuntos
                for (int i = 0; i < hfc.Count; i++)
                {
                        xml_adjuntos += "<adjuntos>";
                        HttpPostedFile postedFile = hfc[i];
                        string file;
                        string nom_old = "";
                        if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                        {
                            string[] files = postedFile.FileName.Split(new char[] { '\\' });
                            file = files[files.Length - 1];
                        }
                        else // In case of other browsers
                        {
                            file = postedFile.FileName;
                        }
                        nom_old = file;
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

                        string cont = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                
                        string ext = Path.GetExtension(fileDirectory + "\\" + file);
                        file = "reg_hallazgo_" + cont.ToString() + ext;
                        string ruta_aux= DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "_" + Request.Params.GetValues("rutaImagen")[0].ToString();


                        if (File.Exists(fileDirectory + "\\" + file))
                        {
                            File.Delete(fileDirectory + "\\" + file);
                        }
                        fileDirectory = Serverpath + "\\" + file;

                        try
                        {
                            if (!ext.ToUpper().Equals(".PDF"))
                            {
                                string ancho_new = System.Configuration.ConfigurationManager.AppSettings["sizeFotosUsuario"];
                                if (!string.IsNullOrEmpty(ancho_new))
                                {
                                    AuditoriasCiudadanas.Controllers.AudienciasController datosfunc = new Controllers.AudienciasController();
                                    datosfunc.CambiarTamanoImagen(Convert.ToInt16(ancho_new), postedFile.InputStream, Path.Combine(Serverpath, file));
                                    cod_error = "0";
                                    msg_error = "";
                                    if (File.Exists(fileDirectory))
                                    {
                                        cant_adjuntos_guardados += 1;

                                        ruta = file;
                                        xml_adjuntos += "<url_img>" + ruta + "</url_img>";
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

                                    }
                                    else
                                    {
                                        cod_error = "-1";
                                        msg_error = "El archivo " + nom_old + " NO se guardó exitosamente";
                                    }

                                }
                                else
                                {
                                    cod_error = "-1";
                                    msg_error = "El archivo NO se guardó exitosamente,falta configuracion de tamaño máximo ";
                                }
                            }
                            else {
                                postedFile.SaveAs(fileDirectory);
                                if (File.Exists(fileDirectory))
                                {
                                    cant_adjuntos_guardados += 1;

                                    ruta = file;
                                    xml_adjuntos += "<url_img>" + ruta + "</url_img>";
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

                                }
                                else
                                {
                                    cod_error = "-1";
                                    msg_error = "El archivo " + nom_old + " NO se guardó exitosamente";
                                }


                            }

                        }
                        catch (Exception ex)
                        {
                            cod_error = "-1";
                            msg_error = "El archivo NO se guardó exitosamente, se presentó un problema con la imagen puede ser el tipo de imagen o el tamaño de esta.\nDetalles del error\n" + ex.Message;
  
                        }

                        xml_adjuntos += "</adjuntos>";

                    }

                    if (cant_adjuntos > 0 && (cant_adjuntos != cant_adjuntos_guardados))
                    {
                        cod_error = "-1";
                        string msg_aux = "Error al agregar la totalidad de adjuntos: ";
                        msg_error = msg_aux + msg_error;
                    }
                    else {
                        string xml_info = "<hallazgos>";
                        xml_info += xml_adjuntos;
                        xml_info += "</hallazgos>";


                        if (!string.IsNullOrEmpty(xml_info))
                        {
                            Controllers.InformeHallazgoController reporteHallazgo = new Controllers.InformeHallazgoController();
                              outTxt = reporteHallazgo.GuardarInformeHallazgo(hallazgo,grupoGacId_aux,idUsuario_aux,xml_info);
                            string[] separador = new string[] { "<||>" };
                            var result = outTxt.Split(separador, StringSplitOptions.None);
                            cod_error = result[0];
                            msg_error = result[1];
                        }
                        else
                        {

                            cod_error = "-1";
                            msg_error = "Error al crear registro: @xml invalido";
                        }

                    }



                    //if (pColl.AllKeys.Contains("rutaImagen")) rutaImagen = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "_" + Request.Params.GetValues("rutaImagen")[0].ToString();

                    //var postedFile = Request.Files[0];
                    //string file;
                    //if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")//Para versiones de IE inferiores a 11
                    //{
                    //  string[] files = postedFile.FileName.Split(new char[] { '\\' });
                    //  file = files[files.Length - 1];
                    //}
                    //else file = postedFile.FileName;// In case of other browsers
                    //if (!Directory.Exists(Serverpath)) Directory.CreateDirectory(Serverpath);
                    //string fileDirectory = Serverpath;
                    //if (File.Exists(fileDirectory + "\\" + rutaImagen)) File.Delete(fileDirectory + "\\" + rutaImagen);
                    //fileDirectory = Serverpath + "\\" + rutaImagen;
                    //postedFile.SaveAs(fileDirectory);
                    //if (File.Exists(fileDirectory))
                    //{
                    //  Response.AddHeader("Vary", "Accept");
                    //  try
                    //  {
                    //    if (Request["HTTP_ACCEPT"].Contains("application/json")) Response.ContentType = "application/json";
                    //    else Response.ContentType = "text/plain";
                    //  }
                    //  catch
                    //  {
                    //    Response.ContentType = "text/plain";
                    //  }
                    //  Controllers.InformeHallazgoController reporteHallazgo = new Controllers.InformeHallazgoController();
                    //  sal = reporteHallazgo.GuardarInformeHallazgo(hallazgo + '*' + grupoGacId);
                    //  if (sal == "<||>") sal = reporteHallazgo.GuardarAdjuntoReporteHallazgo(rutaImagen + "*" + idUsuario);
                    //  string[] separador = new string[] { "<||>" };
                    //  var result = sal.Split(separador, StringSplitOptions.None);
                    //  cod_error = result[0];
                    //  msg_error = result[1];
                    //}
                    //else
                    //{
                    //  sal = "-1<||>Error al subir archivo";
                    //  cod_error = "-1";
                    //  msg_error = "Error al subir al archivo";
                    //}

                    DataTable dt_errores = new DataTable();
                    dt_errores.Columns.Add("cod_error", typeof(string));
                    dt_errores.Columns.Add("msg_error", typeof(string));
                    dt_errores.Rows.Add(cod_error, msg_error);
                    AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
                    outTxt = datos_func.convertToJsonObj(dt_errores);

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