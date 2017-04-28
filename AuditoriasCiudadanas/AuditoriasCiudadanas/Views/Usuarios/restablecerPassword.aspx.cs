using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class restablecerPassword : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection pColl = Request.Form;
            string id_usuario = "";
            if (pColl.AllKeys.Contains("id_usuario") && !string.IsNullOrEmpty(Request.Params.GetValues("id_usuario")[0].ToString()))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
            }
            hdIdUsuario.Value = id_usuario;

        }
    }
}
    
