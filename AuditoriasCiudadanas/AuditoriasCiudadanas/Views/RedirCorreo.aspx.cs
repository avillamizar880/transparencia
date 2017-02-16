using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views
{
    public partial class RedirCorreo : System.Web.UI.Page
    {
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "GET")
            {
                NameValueCollection pColl = Request.Params;

                if (pColl.AllKeys.Contains("CodigoBPIN"))
                {
                    hCodigoBPIN.Value= pColl.Get("CodigoBPIN").ToString();
                }
                if (pColl.AllKeys.Contains("tipoCorreo"))
                {
                    hTipoCorreo.Value = pColl.Get("tipoCorreo").ToString();
                }

                if (HttpContext.Current.Request.Url.IsDefaultPort)
                {
                    form1.Action = "../principal";
                }
                else
                {
                    form1.Action = "../principal";
                }

            }
        }
    }
}
   