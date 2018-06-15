using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class solicInfoAdicional_ajax : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string bpin_proyecto = "";
            string id_usuario = "";
            string id_gac = "";
            string detalle = "";
            int id_usuario_aux = 0;
            int id_gac_aux = 0;
            string outTxt = "";


            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("cod_bpin"))
                {
                    bpin_proyecto = Request.Params.GetValues("cod_bpin")[0].ToString();
                }
                if (pColl.AllKeys.Contains("detalle"))
                {
                    detalle = Request.Params.GetValues("detalle")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_gac"))
                {
                    id_gac = Request.Params.GetValues("id_gac")[0].ToString();
                    if (!string.IsNullOrEmpty(id_gac))
                    {
                        id_gac_aux = Convert.ToInt16(id_gac);
                    }
                }
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                    if (!string.IsNullOrEmpty(id_usuario))
                    {
                        id_usuario_aux = Convert.ToInt16(id_usuario);
                    }
                }

                //add registro
                AuditoriasCiudadanas.Controllers.ProyectosController datos_func = new Controllers.ProyectosController();
                outTxt = datos_func.addSolicInfoAdicional(bpin_proyecto, detalle, id_usuario_aux, id_gac_aux);
                Response.Write(outTxt);

            }

            }
    }
}