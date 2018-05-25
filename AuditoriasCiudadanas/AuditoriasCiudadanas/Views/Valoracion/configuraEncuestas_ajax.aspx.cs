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
    public partial class configuraEncuestas_ajax : App_Code.PageSession
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
            int id_cuestionario_aux = 0;
            string id_cuestionario = "";
            string id_pregunta = "";
            int id_pregunta_aux = 0;
            string bpin_proyecto = "";
            string cod_error = "";
            string msg_error = "";

            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_cuestionario"))
            {
                id_cuestionario = Request.Params.GetValues("id_cuestionario")[0].ToString();
                if (!string.IsNullOrEmpty(id_cuestionario))
                {
                    id_cuestionario_aux = Convert.ToInt16(id_cuestionario);
                }
            }

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

            if (pColl.AllKeys.Contains("bpin_proyecto"))
            {
                bpin_proyecto = Request.Params.GetValues("bpin_proyecto")[0].ToString();
            }

            if (opcion.ToUpper().Equals("CREAR")) {
                if (id_usuario_aux <= 0)
                {
                    outTxt = "-1<||>Debe estar registrado para realizar esta acción";
                }
                else { 
                    AuditoriasCiudadanas.Controllers.ValoracionController datos = new AuditoriasCiudadanas.Controllers.ValoracionController();
                    outTxt = datos.CrearCuestionario(id_tipo_aux, titulo, descripcion, id_usuario_aux,bpin_proyecto);
                    string[] separador = new string[] { "<||>" };
                    var result = outTxt.Split(separador, StringSplitOptions.None);
                    cod_error = result[0];
                    msg_error = result[1];
                    if (!cod_error.Equals("0")) {
                        if (msg_error.IndexOf("uk_cuestionario_bpin") > -1) {
                            //uk_cuestionario_bpin
                            if (id_tipo_aux == 2)
                            {
                                //ayuda
                                outTxt = "-2<||>Ya existe un cuestionario de ayuda configurado";
                            }
                            else {
                                if (!string.IsNullOrEmpty(bpin_proyecto)) {
                                    //evaluacion
                                    outTxt = "-3<||>Ya existe un cuestionario de evaluación para el bpin" + bpin_proyecto;
                                }
                            }
                            
                        }
                    }
                }
            }
            else if (opcion.ToUpper().Equals("MODIF")) {
                AuditoriasCiudadanas.Controllers.ValoracionController datos = new AuditoriasCiudadanas.Controllers.ValoracionController();
                outTxt = datos.ModificarCuestionario(id_cuestionario_aux, id_tipo_aux, titulo, descripcion, id_usuario_aux);
            }
            else if(opcion.ToUpper().Equals("PREG"))
            {
                var stream = HttpContext.Current.Request.InputStream;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                string xml_txt = Encoding.UTF8.GetString(buffer);
                AuditoriasCiudadanas.Controllers.ValoracionController datos = new AuditoriasCiudadanas.Controllers.ValoracionController();
                outTxt = datos.insPregunta(xml_txt);
            }
            else if (opcion.ToUpper().Equals("PREG_MODIF"))
            {
                var stream = HttpContext.Current.Request.InputStream;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                string xml_txt = Encoding.UTF8.GetString(buffer);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml_txt);
                XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/pregunta/id_pregunta");
                if (el != null)
                {
                    el.ParentNode.RemoveChild(el);

                    foreach (XmlNode nodo in el)
                    {
                        id_pregunta = nodo.InnerText;
                    }
                }

                if (!string.IsNullOrEmpty(id_pregunta))
                {
                    id_pregunta_aux = Convert.ToInt16(id_pregunta);
                }

                if (!string.IsNullOrEmpty(xml_txt))
                {
                    AuditoriasCiudadanas.Controllers.ValoracionController datos = new AuditoriasCiudadanas.Controllers.ValoracionController();
                outTxt = datos.modifPregunta(xml_txt,id_pregunta_aux);
                }
               
            }
            
            Response.Write(outTxt);
            Response.End();
        }
    }
}