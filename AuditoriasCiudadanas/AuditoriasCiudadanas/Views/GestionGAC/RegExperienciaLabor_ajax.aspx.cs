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

namespace AuditoriasCiudadanas.Views.GestionGAC
{
    public partial class RegExperienciaLabor_ajax : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string descripcion = string.Empty;
            string grupoGacId = string.Empty;
            string idUsuario = string.Empty;
            string cod_error = string.Empty;
            string msg_error = string.Empty;
            string bpin_proyecto =string.Empty;
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
                    NameValueCollection pColl = Request.Params;
                    HttpFileCollection hfc = Request.Files;
                    string pathrefer = Request.UrlReferrer.ToString();
                    string dirupload = ConfigurationManager.AppSettings["ruta_expereriencias_gac"];
                    string Serverpath = HttpContext.Current.Server.MapPath("~/" + dirupload);

                    if (pColl.AllKeys.Contains("cod_bpin"))
                    {
                        bpin_proyecto = Request.Params.GetValues("cod_bpin")[0].ToString();
                    }

                    if (pColl.AllKeys.Contains("descripcion"))
                    {
                        descripcion = Request.Params.GetValues("descripcion")[0].ToString();

                    }
                    if (pColl.AllKeys.Contains("grupoGacId"))
                    {
                        grupoGacId = Request.Params.GetValues("grupoGacId")[0].ToString();
                        if (!string.IsNullOrEmpty(grupoGacId))
                        {
                            grupoGacId_aux = Convert.ToInt16(grupoGacId);
                        }

                    }
                    if (pColl.AllKeys.Contains("idUsuario"))
                    {
                        idUsuario = Request.Params.GetValues("idUsuario")[0].ToString();
                        if (!string.IsNullOrEmpty(idUsuario))
                        {
                            idUsuario_aux = Convert.ToInt16(idUsuario);
                        }

                    }

                    cant_adjuntos = hfc.Count;
                    //por cada archivo adjunto guarda y agrega a xml_adjuntos
                    for (int i = 0; i < hfc.Count; i++)
                    {
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
                        file = "reg_experiencia_" + cont.ToString() + ext;


                        if (File.Exists(fileDirectory + "\\" + file))
                        {
                            File.Delete(fileDirectory + "\\" + file);
                        }
                        fileDirectory = Serverpath + "\\" + file;

                        try
                        {
                                postedFile.SaveAs(fileDirectory);
                                if (File.Exists(fileDirectory))
                                {
                                    cant_adjuntos_guardados += 1;

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

                                }
                                else
                                {
                                    cod_error = "-1";
                                    msg_error = "El archivo " + nom_old + " NO se guardó exitosamente";
                                }



                        }
                        catch (Exception ex)
                        {
                            cod_error = "-1";
                            msg_error = "El archivo NO se guardó exitosamente, se presentó un problema con la imagen puede ser el tipo de imagen o el tamaño de esta.\nDetalles del error\n" + ex.Message;

                        }


                    }

                    if (cant_adjuntos > 0 && (cant_adjuntos != cant_adjuntos_guardados))
                    {
                        cod_error = "-1";
                        string msg_aux = "Error al agregar la totalidad de adjuntos: ";
                        msg_error = msg_aux + msg_error;
                    }
                    else
                    {

                            AuditoriasCiudadanas.Controllers.GestionGruposController datos_exp = new Controllers.GestionGruposController();
                            outTxt = datos_exp.addExperienciasGac(bpin_proyecto, descripcion, ruta, idUsuario_aux, grupoGacId_aux);
                            string[] separador = new string[] { "<||>" };
                            var result = outTxt.Split(separador, StringSplitOptions.None);
                            cod_error = result[0];
                            msg_error = result[1];
  
                        
                    }


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