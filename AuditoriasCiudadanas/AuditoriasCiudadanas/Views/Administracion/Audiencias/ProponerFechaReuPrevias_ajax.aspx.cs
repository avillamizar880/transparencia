using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class ProponerFechaReuPrevias_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string outTxt = "";
            string fecha ="";
            string cod_bpin="";
            int id_usuario_aux=0;
            string id_usuario = "";
            DateTime fecha_aux = DateTime.Now;
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("fecha"))
                {
                    fecha = Request.Params.GetValues("fecha")[0].ToString();
                    if (!string.IsNullOrEmpty(fecha))
                    {
                        fecha_aux = DateTime.Parse(fecha);
                    }
                }
                if (pColl.AllKeys.Contains("codigo_bpin"))
                {
                    cod_bpin = Request.Params.GetValues("codigo_bpin")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                    if (!string.IsNullOrEmpty(id_usuario)) {
                        id_usuario_aux = Convert.ToInt16(id_usuario);
                    }
                }
            }
            if (!string.IsNullOrEmpty(fecha) && !string.IsNullOrEmpty(id_usuario) && !string.IsNullOrEmpty(cod_bpin))
            {
                AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
                outTxt = datos.insProponerFechaReuPrevias(cod_bpin, fecha_aux, id_usuario_aux);
            }
            else {
                outTxt = "-1<||>Datos incompletos";
            }
            Response.Write(outTxt);

            }
        }
    }
