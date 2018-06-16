using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Capacitacion
{
    public partial class list_informacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_tab = "";
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_tab"))
            {
                id_tab = Request.Params.GetValues("id_tab")[0].ToString();
            }
            hdIdTab.Value = id_tab;


        }
    }
}