using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Valoracion
{
    public partial class eliminarPregunta_ajax : AuditoriasCiudadanas.App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection pColl = Request.Params;
            int id_pregunta_aux = 0;
            string id_pregunta = "";
            string outTxt = "";
            if (pColl.AllKeys.Contains("id_pregunta"))
            {
                id_pregunta = Request.Params.GetValues("id_pregunta")[0].ToString();
                if (!string.IsNullOrEmpty(id_pregunta))
                {
                    id_pregunta_aux = Convert.ToInt16(id_pregunta);
                }
            }

            AuditoriasCiudadanas.Controllers.ValoracionController datos = new AuditoriasCiudadanas.Controllers.ValoracionController();
            outTxt = datos.eliminarPregunta(id_pregunta_aux);
            Response.Write(outTxt);
            Response.End();
            

        }
    }
}