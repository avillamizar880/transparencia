using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class ActaReuniones : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                string tipo_audiencia = "0";
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("tipo_audiencia"))
                {
                    tipo_audiencia = Request.Params.GetValues("tipo_audiencia")[0].ToString();
                }
                hfTipoAudiencia.Value = tipo_audiencia;
            }
        }
    }
}