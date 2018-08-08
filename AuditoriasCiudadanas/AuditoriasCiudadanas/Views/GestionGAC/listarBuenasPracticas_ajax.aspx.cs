using AuditoriasCiudadanas.Models;
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
            string id_usuario = "";
            int id_usuario_aux = 0;
            string page = "";
            int page_aux = 0;
            ModelDataRecurso objReturn = new ModelDataRecurso();

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("opc"))
                {
                    opcion = Request.Params.GetValues("opc")[0].ToString();
                }
                if (pColl.AllKeys.Contains("pagina"))
                {
                    page = Request.Params.GetValues("pagina")[0].ToString();
                }
                if (!string.IsNullOrEmpty(page))
                {
                    page_aux = Convert.ToInt16(page);
                }

                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                   
                }
                if (pColl.AllKeys.Contains("id_recurso"))
                {
                    id_recurso = Request.Params.GetValues("id_recurso")[0].ToString();
                }
                if (!string.IsNullOrEmpty(id_recurso))
                {
                    id_recurso_aux = Convert.ToInt16(id_recurso);
                }
                if (string.IsNullOrEmpty(id_usuario))
                {
                    id_usuario = Session["idUsuario"].ToString();
                }
                if (!string.IsNullOrEmpty(id_usuario))
                {
                    id_usuario_aux = Convert.ToInt16(id_usuario);
                }
                if (opcion.ToUpper().Equals("OBT"))
                {
                    if (id_recurso_aux > 0)
                    {
                        AuditoriasCiudadanas.Controllers.GestionGruposController datos_func = new Controllers.GestionGruposController();
                        outTxt = datos_func.obtBuenasPracticasById(id_recurso_aux);
                    }
                }
                else if (opcion.ToUpper().Equals("LIST"))
                {
                    AuditoriasCiudadanas.Controllers.GestionGruposController datos_func = new Controllers.GestionGruposController();
                    objReturn = datos_func.obtBuenasPracticas(page_aux);
                    AuditoriasCiudadanas.App_Code.funciones datos_func_aux = new AuditoriasCiudadanas.App_Code.funciones();
                    outTxt = datos_func_aux.convertToJsonObj(objReturn);
                }
                else if (opcion.ToUpper().Equals("APRO")) {
                    AuditoriasCiudadanas.Controllers.GestionGruposController datos_func = new Controllers.GestionGruposController();
                    outTxt = datos_func.aprobarBuenasPracticas(id_recurso_aux, id_usuario_aux);
                }

                }
               
            Response.Write(outTxt);

        }
    }
}