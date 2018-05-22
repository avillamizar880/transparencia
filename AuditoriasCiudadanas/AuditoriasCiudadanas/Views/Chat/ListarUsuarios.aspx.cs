using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Chat
{
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idUsuario"] != null)
                {
                    NoSession.Visible = false;
                    //if (Session["ListarUsuariosScript"] == null)
                    //{
                        string script = @"<script src=""Scripts/ComunicacionVirtual/ListarUsuarios.js"" type=""text/javascript""></script>";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ListarUsuarios", script);
                        //Session["ListarUsuariosScript"] = true;
                    //}
                }
                else {
                    contentDiv.Visible = false;
                }
            }
        }
    }
}