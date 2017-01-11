using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class cerrarSesion : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cerrarSesion();
        }
    }
}