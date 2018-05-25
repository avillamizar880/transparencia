using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Data;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class RegistrarCompromisos_ajax : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
                {
                if (HttpContext.Current.Request.HttpMethod == "POST")
                {
                    string opcion = "";
                    var nodo_principal = false;
                    string outTxt = "";
                    string ruta = "";
                    string num_asistentes = "";
                    int num_asistentes_aux = 0;
                    string cod_error = "";
                    string msg_error = "";
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd");
                

                    string xml_txt = "";
                    string xml_adjuntos = "";
                    NameValueCollection pColl = Request.Params;
                    if (pColl.AllKeys.Contains("opcion"))
                    {
                        opcion = Request.Params.GetValues("opcion")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("xml"))
                    {
                        xml_txt = HttpUtility.UrlDecode(Request.Params.GetValues("xml")[0].ToString());
                    }
              
                    if (opcion.Equals("img"))
                    {
                        string pathrefer = Request.UrlReferrer.ToString();
                        string dir_upload = ConfigurationManager.AppSettings["ruta_audiencias"];
                        string Serverpath = HttpContext.Current.Server.MapPath("~/" + dir_upload);

                        HttpFileCollection hfc = Request.Files;
                    
                        for (int i=0;i<hfc.Count;i++){
                            xml_adjuntos += "<adjuntos>";
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

                                ruta = fileDirectory;
                                xml_adjuntos += "<id_tipo_adjunto>7</id_tipo_adjunto>";
                                xml_adjuntos += "<url_img>" + ruta + "</url_img>";
                                xml_adjuntos += "<fecha>" + fecha + "</fecha>";

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
                            else {
                                outTxt = "-1<||>Error al subir archivo";
                                cod_error = "-1";
                                msg_error = "Error al subir al archivo";

                            }
                            xml_adjuntos += "</adjuntos>";


                        }


                    }
                    else {
                        
                        var stream = HttpContext.Current.Request.InputStream;
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        xml_txt = Encoding.UTF8.GetString(buffer);
                        //separa nodo de otros
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xml_txt);
                        //remover nodo asistentes
                        XmlElement el_principal = (XmlElement)xmlDoc.SelectSingleNode("/compromisos");
                        if (el_principal != null)
                        {
                            nodo_principal = true;
                            xml_txt = el_principal.InnerXml;
                        }


                        XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/compromisos/num_asistentes");
                        if (el != null)
                        {
                            el.ParentNode.RemoveChild(el);

                            foreach (XmlNode nodo in el)
                            {
                                num_asistentes = nodo.InnerText;
                            }
                        }

                        if (!string.IsNullOrEmpty(num_asistentes))
                        {
                            num_asistentes_aux = Convert.ToInt16(num_asistentes);
                        }




                    }


                    if (!string.IsNullOrEmpty(xml_txt))
                    {
                            string xml_info = "<compromisos>";
                            xml_info += xml_txt;
                            xml_info += xml_adjuntos;
                            xml_info += "</compromisos>";
 
                          
                        AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
                        outTxt = datos.insCompromisos(xml_info, num_asistentes_aux);
                        string[] separador = new string[] { "<||>" };
                        var result = outTxt.Split(separador, StringSplitOptions.None);
                        cod_error = result[0];
                        msg_error = result[1];
                    }
                    else {

                        cod_error = "-1";
                        msg_error = "Error al crear registro: @xml invalido";
                    }

                    DataTable dt_errores = new DataTable();
                    dt_errores.Columns.Add("cod_error", typeof(string));
                    dt_errores.Columns.Add("msg_error", typeof(string));
                    dt_errores.Rows.Add(cod_error, msg_error);
                    AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
                    outTxt = datos_func.convertToJsonObj(dt_errores);

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