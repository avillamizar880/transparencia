using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["idRol"] != null)// && Session["idRol"].ToString() == "1")
            {
                //adminMenu.Visible = true;
                btnSes.Attributes["menu"] = Session["idRol"].ToString();
            }
            else
            {
                //adminMenu.Visible = false;
                btnSes.Attributes["menu"] = "X";
            }


            if (Session["nombre"] != null)// && Session["idRol"].ToString() == "1")
            {
                //adminMenu.Visible = true;
                btnSes.Attributes["nombre"] = Session["nombre"].ToString();
            }
            else
            {
                //adminMenu.Visible = false;
                btnSes.Attributes["nombre"] = "CUENTA";
            }
        }
    }
}