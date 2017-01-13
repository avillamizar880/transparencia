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
    public partial class configuraEncuestas_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string outTxt = "";
            string id_tipo = "";
            string titulo = "";
            string descripcion = "";
            string id_usuario = "";
            int id_usuario_aux = 0;
            int id_tipo_aux=0;
            string opcion = "";

            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_tipo"))
            {
                id_tipo = Request.Params.GetValues("id_tipo")[0].ToString();
                if(!string.IsNullOrEmpty(id_tipo)){
                  id_tipo_aux=Convert.ToInt16(id_tipo);
                }
            }
            if (pColl.AllKeys.Contains("titulo"))
            {
                titulo = Request.Params.GetValues("titulo")[0].ToString();
            }
            if (pColl.AllKeys.Contains("opc"))
            {
                opcion = Request.Params.GetValues("opc")[0].ToString();
            }
            if (pColl.AllKeys.Contains("descripcion"))
            {
                descripcion = Request.Params.GetValues("descripcion")[0].ToString();
            }
            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                if (!string.IsNullOrEmpty(id_usuario))
                {
                    id_usuario_aux = Convert.ToInt16(id_usuario);
                }
            }
            if (opcion.ToUpper().Equals("CREAR")) { 
              AuditoriasCiudadanas.Controllers.ValoracionController datos = new AuditoriasCiudadanas.Controllers.ValoracionController();
              outTxt = datos.CrearCuestionario(id_tipo_aux, titulo, descripcion, id_usuario_aux);
            }
            else {
                var stream = HttpContext.Current.Request.InputStream;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                string xml_txt = Encoding.UTF8.GetString(buffer);
                ////separa nodo de otros
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.LoadXml(xml_txt);
                //remover nodo asistentes
                AuditoriasCiudadanas.Controllers.ValoracionController datos = new AuditoriasCiudadanas.Controllers.ValoracionController();
                outTxt = datos.insPregunta(xml_txt);
            }
            
            Response.Write(outTxt);
            Response.End();
        }
    }
}