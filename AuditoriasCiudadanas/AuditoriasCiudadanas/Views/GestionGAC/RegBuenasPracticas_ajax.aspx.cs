using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.GestionGAC
{
    public partial class RegBuenasPracticas_ajax : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string bpin_proyecto = "";
            string id_usuario = "";
            string id_gac = "";
            string descripcion = "";
            string hecho = "";
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
                if (pColl.AllKeys.Contains("descripcion"))
                {
                    descripcion = Request.Params.GetValues("descripcion")[0].ToString();
                }
                if (pColl.AllKeys.Contains("hecho"))
                {
                    hecho = Request.Params.GetValues("hecho")[0].ToString();
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
                AuditoriasCiudadanas.Controllers.GestionGruposController datos_func = new Controllers.GestionGruposController();
                outTxt = datos_func.addBuenasPracticas(bpin_proyecto, hecho, descripcion, id_usuario_aux, id_gac_aux);
                Response.Write(outTxt);

            }
        }
    }
}