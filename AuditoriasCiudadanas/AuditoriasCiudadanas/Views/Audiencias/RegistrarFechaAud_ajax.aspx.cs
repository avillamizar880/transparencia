using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class RegistrarFechaAud_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string outTxt = "";
            string fecha = "";
            string cod_bpin = "";
            int id_usuario_aux = 0;
            string id_usuario = "";
            string id_municipio = "";
            string tipo_audiencia = "";
            int tipo_audiencia_aux = 0;
            string direccion = "";


            DateTime fecha_aux = DateTime.Now;
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("codigo_bpin"))
                {
                    cod_bpin = Request.Params.GetValues("codigo_bpin")[0].ToString();
                }
                if (pColl.AllKeys.Contains("tipo_audiencia"))
                {
                    tipo_audiencia = Request.Params.GetValues("tipo_audiencia")[0].ToString();
                    if (!string.IsNullOrEmpty(tipo_audiencia))
                    {
                        tipo_audiencia_aux = Convert.ToInt16(tipo_audiencia);
                    }
                }

                if (pColl.AllKeys.Contains("id_municipio"))
                {
                    id_municipio = Request.Params.GetValues("id_municipio")[0].ToString();
                }
                if (pColl.AllKeys.Contains("direccion"))
                {
                    direccion = Request.Params.GetValues("direccion")[0].ToString();
                }

                if (pColl.AllKeys.Contains("fecha"))
                {
                    fecha = Request.Params.GetValues("fecha")[0].ToString();
                    if (!string.IsNullOrEmpty(fecha))
                    {
                        fecha_aux = DateTime.ParseExact(fecha, "yyyy-MM-dd - HH:mm", null);
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
            }
            if (!string.IsNullOrEmpty(fecha) && !string.IsNullOrEmpty(cod_bpin))
            {
                AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
                outTxt = datos.insFechaAudiencias(cod_bpin, tipo_audiencia_aux, id_municipio, fecha_aux, id_usuario_aux, direccion);
            }
            else
            {
                outTxt = "-1<||>Datos incompletos";
            }
            Response.Write(outTxt);

        }
    }
}