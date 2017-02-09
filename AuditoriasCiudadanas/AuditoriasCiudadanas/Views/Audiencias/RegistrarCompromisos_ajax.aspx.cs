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
    public partial class RegistrarCompromisos_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                string opcion = "";
                string xml_txt = "";
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("opcion"))
                {
                    opcion = Request.Params.GetValues("opcion")[0].ToString();
                }

                string outTxt = "";
                string ruta = "";
                string num_asistentes = "";
                int num_asistentes_aux = 0;
                if (opcion.Equals("img"))
                {
                    string pathrefer = Request.UrlReferrer.ToString();
                    string dir_upload = ConfigurationManager.AppSettings["ruta_audiencias"];
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
                    //file = Guid.NewGuid() + ext; // Creating a unique name for the file 

                    fileDirectory = Serverpath + "\\" + file;

                    postedFile.SaveAs(fileDirectory);
                    if (File.Exists(fileDirectory))
                    {

                        ruta = fileDirectory;
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
                }
                else { 
                    var stream = HttpContext.Current.Request.InputStream;
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    xml_txt = Encoding.UTF8.GetString(buffer);
                    string xml_asistentes = "";
                    //separa nodo de otros
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml_txt);
                    //remover nodo asistentes
                    XmlElement el_asistencia = (XmlElement)xmlDoc.SelectSingleNode("/asistencia");
                    if (el_asistencia != null)
                    {
                        el_asistencia.ParentNode.RemoveChild(el_asistencia);

                        foreach (XmlNode nodo in el_asistencia)
                        {
                            xml_asistentes += nodo.InnerText;
                        }
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
                    AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
                    outTxt = datos.insCompromisos(xml_txt, num_asistentes_aux);
                }

                Response.Write(outTxt);
                Response.End();


            }
        }
    }
}