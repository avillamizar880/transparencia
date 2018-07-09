using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas
{
    public partial class login : System.Web.UI.Page
    {

        public string strParam = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strParam = Request.QueryString["params"];
                if (String.IsNullOrEmpty(strParam))
                {
                    strParam = "";
                }
            }
        }
    }
}