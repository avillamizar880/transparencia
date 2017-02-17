using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class RegistrarObservaciones_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                string cod_bpin = "";
                string info_clara = "";
                string info_faltante = "";
                string info_completa = "";
                string comunidad_benef = "";
                string dudas = "";
                string fecha_posterior_1 = "";
                string fecha_posterior_2 = "";
                string id_usuario = "";
                int id_usuario_aux = 0;
                string id_grupo = "";
                int id_grupo_aux = 0;
                DateTime fecha_aux_1 = DateTime.Now;
                DateTime fecha_aux_2 = DateTime.Now;

                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("id_grupo"))
                {
                    id_grupo = Request.Params.GetValues("id_grupo")[0].ToString();
                    if (!string.IsNullOrEmpty(id_grupo)) {
                        id_grupo_aux = Convert.ToInt16(id_grupo);
                    }
                }
                if (pColl.AllKeys.Contains("cod_bpin"))
                {
                    cod_bpin = Request.Params.GetValues("cod_bpin")[0].ToString();
                }
                if (pColl.AllKeys.Contains("info_faltante"))
                {
                    info_faltante = Request.Params.GetValues("info_faltante")[0].ToString();
                }

                if (pColl.AllKeys.Contains("info_clara"))
                { 
                    info_clara = Request.Params.GetValues("info_clara")[0].ToString();
                }
                if (pColl.AllKeys.Contains("info_completa"))
                {
                    info_completa = Request.Params.GetValues("info_completa")[0].ToString();
                }
                if (pColl.AllKeys.Contains("comunidad_benef"))
                {
                    comunidad_benef = Request.Params.GetValues("comunidad_benef")[0].ToString();
                }
                if (pColl.AllKeys.Contains("dudas"))
                {
                    dudas = Request.Params.GetValues("dudas")[0].ToString();
                }
                if (pColl.AllKeys.Contains("fecha_posterior_1"))
                {
                    fecha_posterior_1 = Request.Params.GetValues("fecha_posterior_1")[0].ToString();
                    fecha_aux_1 = DateTime.Parse(fecha_posterior_1);
                }
                if (pColl.AllKeys.Contains("fecha_posterior_2"))
                {
                    fecha_posterior_2 = Request.Params.GetValues("fecha_posterior_2")[0].ToString();
                    fecha_aux_2 = DateTime.Parse(fecha_posterior_2);
                }
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                    if (!string.IsNullOrEmpty(id_usuario)) { 
                      id_usuario_aux=Convert.ToInt16(id_usuario);
                    }
                }

                string outTxt = "";
                AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
                outTxt = datos.insRegObservaciones(cod_bpin,info_faltante, info_clara, info_completa, comunidad_benef, dudas, fecha_aux_1, fecha_aux_2, id_usuario_aux,id_grupo_aux);
                Response.Write(outTxt);
                Response.End();
            }
        }
    }
}