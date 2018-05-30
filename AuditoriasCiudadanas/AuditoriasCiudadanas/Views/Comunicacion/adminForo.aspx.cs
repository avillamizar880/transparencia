using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AuditoriasCiudadanas.Views.Comunicacion
{
    public partial class adminForo : System.Web.UI.Page //: App_Code.PageSession
    {

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idUsuario"] != null)
                {
                    NoSession.Visible = false;
                    hdIdUsuario.Value = Session["idUsuario"].ToString();
                }
                else
                {
                    divInfoForo.Visible = false;
                }
            }
        }
    }
}