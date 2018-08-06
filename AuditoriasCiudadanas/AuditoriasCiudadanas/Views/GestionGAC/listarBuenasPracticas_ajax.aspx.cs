using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.GestionGAC
{
    public partial class listarBuenasPracticas_ajax : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string opcion = "";
            string id_recurso = "";
            int id_recurso_aux = 0;
            string outTxt = "";
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("opc"))
                {
                    opcion = Request.Params.GetValues("opc")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_recurso"))
                {
                    id_recurso = Request.Params.GetValues("id_recurso")[0].ToString();
                }
                if (!string.IsNullOrEmpty(id_recurso))
                {
                    id_recurso_aux = Convert.ToInt16(id_recurso);
                }

                if (opcion.ToUpper().Equals("OBT"))
                {
                    if (id_recurso_aux > 0)
                    {

                    }
                }
                else if (opcion.ToUpper().Equals("LIST")) {
                    AuditoriasCiudadanas.Controllers.GestionGruposController datos_func = new Controllers.GestionGruposController();
                    outTxt=datos_func.obtBuenasPracticas();
                }

                }
               
            Response.Write(outTxt);

        }
    }
}