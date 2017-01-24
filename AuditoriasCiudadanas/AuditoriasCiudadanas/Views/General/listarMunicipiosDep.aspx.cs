using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace AuditoriasCiudadanas.Views.Proyectos
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
            string texto = "";

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                //string nombre,string email,string celular,string hash_clave,int idperfil,int id_departamento,int id_municipio
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("texto"))
                {
                    texto = Request.Params.GetValues("texto")[0].ToString().ToUpper();
                }
            }

            AuditoriasCiudadanas.Controllers.GeneralController datos = new AuditoriasCiudadanas.Controllers.GeneralController();
            dt_municipios = datos.obtMunicipios();
            AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
            if (!string.IsNullOrEmpty(texto))
            {
                var filas = dt_municipios.AsEnumerable().Where(x => x.Field<string>("municipio").ToUpper().StartsWith(texto));
                if (filas.Count() > 0)
                {
                    DataTable dt_aux = filas.CopyToDataTable<DataRow>();
                    outTxt = datos_func.convertToJson(dt_aux);
                }
            }
            else {
                outTxt = datos_func.convertToJson(dt_municipios);
            }
            

            Response.Write(outTxt);
        }    
    }
}