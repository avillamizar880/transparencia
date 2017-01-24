using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;


namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class listarMunicipios : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_departamento="";
            if (HttpContext.Current.Request.HttpMethod=="POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("id_departamento")) {
                    id_departamento = Request.Params.GetValues("id_departamento")[0].ToString();
                }
            }
            
            DataTable dt_municipios = new DataTable();
            string outTxt="";
            AuditoriasCiudadanas.Controllers.GeneralController datos = new AuditoriasCiudadanas.Controllers.GeneralController();
            dt_municipios = datos.obtMunicipiosByDep(id_departamento);
            AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
            outTxt = datos_func.convertToJson(dt_municipios);
            Response.Write(outTxt);

        }
    }
}