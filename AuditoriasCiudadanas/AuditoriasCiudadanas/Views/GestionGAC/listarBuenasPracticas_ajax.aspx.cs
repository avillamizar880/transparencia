using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.GestionGAC
{
    public partial class listarBuenasPracticas_ajax : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuditoriasCiudadanas.Controllers.GestionGruposController datos_func = new Controllers.GestionGruposController();
            string outTxt=datos_func.obtBuenasPracticas();
            Response.Write(outTxt);

        }
    }
}