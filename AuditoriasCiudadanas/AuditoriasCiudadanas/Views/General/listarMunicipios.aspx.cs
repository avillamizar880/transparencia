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
    public partial class listarMunicipios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_departamento="";

            string metodo = HttpContext.Current.Request.HttpMethod;
            //{
            //    NameValueCollection pColl = Request.Form;
            //    id_departamento = Request.Form["id_departamento"];
            //}
            //else {
            //    NameValueCollection pColl = Request.Params;
            //    id_departamento = Request.QueryString["id_departamento"];
            //}
            string[] valor = Request.QueryString.GetValues("age");

            DataTable dt_municipios = new DataTable();
            string outTxt="";
            AuditoriasCiudadanas.Controllers.GeneralController datos = new AuditoriasCiudadanas.Controllers.GeneralController();
            dt_municipios = datos.obtMunicipiosByDep(id_departamento);
            AuditoriasCiudadanas.Controllers.funciones datos_func = new AuditoriasCiudadanas.Controllers.funciones();
            outTxt = datos_func.convertToJson(dt_municipios);
            Response.Write(outTxt);

        }
    }
}