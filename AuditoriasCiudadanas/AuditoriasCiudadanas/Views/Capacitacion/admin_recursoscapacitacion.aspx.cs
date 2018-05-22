using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Capacitacion
{
    public partial class admin_recursoscapacitacion : App_Code.PageSession
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] != null)
            {
                hdIdUsuario.Value = Session["idUsuario"].ToString();
            }
            string id_cap = "";
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_cap"))
            {
                id_cap = Request.Params.GetValues("id_cap")[0].ToString();
            }
            hdIdCap.Value = id_cap;

        }
    }
}