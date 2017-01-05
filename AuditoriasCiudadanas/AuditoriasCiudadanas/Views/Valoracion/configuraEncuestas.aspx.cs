using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Valoracion
{
    public partial class configuraEncuestas : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string outTxt = "";
            string id_usuario = "";
            string id_tipo = "";
            int id_usuario_aux = 0;
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_tipo"))
            {
                id_tipo = Request.Params.GetValues("id_tipo")[0].ToString();
            }
            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                if (!string.IsNullOrEmpty(id_usuario))
                {
                    id_usuario_aux = Convert.ToInt16(id_usuario);
                }
            }
            
            
            
            //Response.Write(outTxt);
            //Response.End();
        }
    }
}