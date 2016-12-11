using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class detalleInfoTecnica_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_infotecnica = 0;
            string outTxt = "";
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_info"))
            {
                string id_info_aux=Request.Params.GetValues("id_info")[0].ToString();
                if(!string.IsNullOrEmpty(id_info_aux)){
                    id_infotecnica = Convert.ToInt16(id_info_aux);
                }
            }
            AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
            outTxt = datos.obtInfoTecnica(id_infotecnica);
            Response.Write(outTxt);
            Response.End();
        }

    }
}