using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;

namespace AuditoriasCiudadanas.Views.General
{
    public partial class listarMunicipiosDep : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt_municipios = new DataTable();
            string outTxt = "";
            string texto = "BUCARA";
            AuditoriasCiudadanas.Controllers.GeneralController datos = new AuditoriasCiudadanas.Controllers.GeneralController();
            dt_municipios = datos.obtMunicipios();
            AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();

            var dataRow = dt_municipios.AsEnumerable().Where(x => x.Field<string>("municipio").ToUpper().StartsWith(texto));
            DataTable dt_aux = dataRow.CopyToDataTable<DataRow>();
            outTxt = datos_func.convertToJson(dt_aux);
            


            Response.Write(outTxt);
        }    
    }
}