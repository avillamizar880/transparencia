using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AuditoriasCiudadanas.Views.General
{
    public partial class listarMunicipios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt_municipios = new DataTable();
            string outTxt="";
            AuditoriasCiudadanas.Controllers.GeneralController datos = new AuditoriasCiudadanas.Controllers.GeneralController();
            dt_municipios = datos.obtMunicipiosByDep(1);
            AuditoriasCiudadanas.Controllers.funciones datos_func = new AuditoriasCiudadanas.Controllers.funciones();
            outTxt = datos_func.convertToJson(dt_municipios);
        }
    }
}