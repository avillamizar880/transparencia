using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace AuditoriasCiudadanas.Views.Valoracion
{
    public partial class envioEncuesta_ajax : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection pColl = Request.Params;
            string id_usuario = "";
            int id_usuario_aux = 0;
            string tipo_cuestionario = "";
            string cod_error = "";
            string msg_error = "";

            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
            }
            string outTxt = "";
            var stream = HttpContext.Current.Request.InputStream;
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            string xml_txt = Encoding.UTF8.GetString(buffer);
            //separa nodo de otros
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml_txt);
            //remover nodo asistentes
            XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/respuestas/id_usuario");
            if (el != null)
            {
                el.ParentNode.RemoveChild(el);

                foreach (XmlNode nodo in el)
                {
                    id_usuario = nodo.InnerText;
                }
            }
            XmlElement el_tipo = (XmlElement)xmlDoc.SelectSingleNode("/respuestas/tipo_cuestionario");
            if (el_tipo != null)
            {
                el_tipo.ParentNode.RemoveChild(el_tipo);

                foreach (XmlNode nodo in el_tipo)
                {
                    tipo_cuestionario = nodo.InnerText;
                }
            }

            if (!string.IsNullOrEmpty(id_usuario))
            {
                id_usuario_aux = Convert.ToInt16(id_usuario);
            }

            if (!string.IsNullOrEmpty(xml_txt))
            {
                if (!string.IsNullOrEmpty(tipo_cuestionario) && tipo_cuestionario == "2")
                {
                    //ayuda preg frencuentes
                    AuditoriasCiudadanas.Controllers.ValoracionController datos = new AuditoriasCiudadanas.Controllers.ValoracionController();
                    outTxt = datos.modifRespuestas(xml_txt, id_usuario_aux);
                }
                else { 
                  //cuestionario cualquiera
                        AuditoriasCiudadanas.Controllers.ValoracionController datos = new AuditoriasCiudadanas.Controllers.ValoracionController();
                        outTxt = datos.insRespuestas(xml_txt, id_usuario_aux);
                }
                
            }

            outTxt += "<||>" + tipo_cuestionario;
            Response.Write(outTxt);
            Response.End();

        }
    }
}