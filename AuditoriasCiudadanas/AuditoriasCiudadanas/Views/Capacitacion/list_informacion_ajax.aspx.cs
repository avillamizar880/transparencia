using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriasCiudadanas.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace AuditoriasCiudadanas.Views.Capacitacion
{
    public partial class list_informacion_ajax : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string tipo = "";
            string page = "";
            int page_aux = 0;
            ModelDataRecurso objReturn = new ModelDataRecurso();
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;

                if (pColl.AllKeys.Contains("tipo"))
                {
                    tipo = Request.Params.GetValues("tipo")[0].ToString();
                }
                if (pColl.AllKeys.Contains("pagina"))
                {
                    page = Request.Params.GetValues("pagina")[0].ToString();
                }

                if (!string.IsNullOrEmpty(page))
                {
                    page_aux = Convert.ToInt16(page);
                }

                AuditoriasCiudadanas.Controllers.CapacitacionController datos = new Controllers.CapacitacionController();
                objReturn = datos.ObtListadoRecursoMutimediaByPag(page_aux, tipo);

            }

            AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
            string outTxt = string.Empty;
            outTxt = datos_func.convertToJsonObj(objReturn);
            Response.Write(outTxt);
        }
    }
}