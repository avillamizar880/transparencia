using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.GestionGAC
{
    public partial class RegExperienciaLabor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_proyecto = "";
            string id_grupo = "";
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_proyecto"))
            {
                id_proyecto = Request.Params.GetValues("id_proyecto")[0].ToString();
            }
            if (pColl.AllKeys.Contains("id_gac"))
            {
                id_grupo = Request.Params.GetValues("id_gac")[0].ToString();
            }

            if (Session["idUsuario"] != null)
            {
                hdIdUsuario.Value = Session["idUsuario"].ToString();
            }

            hfIdProyecto.Value = id_proyecto;
            hfIdGrupoGac.Value = id_grupo;
        }
    }
}