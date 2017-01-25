using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Valoracion
{
    public partial class envioEncuesta : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string outTxt = "";
            string id_usuario = "4";
            int id_usuario_aux = 0;
            int id_cuestionario_aux = 0;
            string id_cuestionario = "";

            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_cuestionario"))
            {
                id_cuestionario = Request.Params.GetValues("id_cuestionario")[0].ToString();
                if (!string.IsNullOrEmpty(id_cuestionario))
                {
                    id_cuestionario_aux = Convert.ToInt16(id_cuestionario);
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
            hdIdCuestionario.Value = id_cuestionario;
            hdIdUsuario.Value = id_usuario;
        }
    }
}