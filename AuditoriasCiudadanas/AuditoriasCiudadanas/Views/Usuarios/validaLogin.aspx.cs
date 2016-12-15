using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class validaLogin : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = "";
            string clave = "";
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("email"))
                {
                    email = Request.Params.GetValues("email")[0].ToString();
                }
                if (pColl.AllKeys.Contains("clave"))
                {
                    clave = Request.Params.GetValues("clave")[0].ToString();
                }


            }
        }
    }
}