using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class listarProyectos : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt_proyectos = new DataTable();
            string outTxt = "";
            string texto = "";

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("texto"))
                {
                    texto = Request.Params.GetValues("texto")[0].ToString().ToUpper();
                }
            }

            AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
            dt_proyectos = datos.listarProyectos();
            AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
            //outTxt = datos_func.convertToJson(dt_proyectos);

            if (!string.IsNullOrEmpty(texto))
            {
                var filas = dt_proyectos.AsEnumerable().Where(x => x.Field<string>("id").ToUpper().StartsWith(texto));
                if (filas.Count() > 0)
                {
                    DataTable dt_aux = filas.CopyToDataTable<DataRow>();
                    outTxt = datos_func.convertToJson(dt_aux);
                }
            }
            else
            {
                outTxt = datos_func.convertToJson(dt_proyectos);
            }

            Response.Write(outTxt);
        }
    }
}