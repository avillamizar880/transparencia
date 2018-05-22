using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Capacitacion
{
    public partial class admin_recursoscapacitacion_ajax : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string opcion = "";
            string id_usuario = "";
            string tituloRec = "";
            string tipoRec = "";
            string url = "";
            string modulo = "";
            string outTxt = "";
            string id_cap = "";
            string id_reccap = "";

            int id_usuario_aux = 0;
            int id_cap_aux = 0;
            int tipo_aux = 0;
            int modulo_aux = 0;
            int id_reccap_aux = 0;

            DataTable objReturn = new DataTable();


            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;

                if (pColl.AllKeys.Contains("opc"))
                {
                    opcion = Request.Params.GetValues("opc")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_cap"))
                {
                    id_cap = Request.Params.GetValues("id_cap")[0].ToString();
                }
                if (!string.IsNullOrEmpty(id_cap))
                {
                    id_cap_aux = Convert.ToInt16(id_cap);
                }
                if (opcion.ToUpper().Equals("LIST"))
                {
                    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    outTxt = datosUsuario.ObtListadoRecCapacitacion(id_cap_aux);
                }
                else
                {
                    if (pColl.AllKeys.Contains("id_usuario"))
                    {
                        id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("titulo"))
                    {
                        tituloRec = Request.Params.GetValues("titulo")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("tipo"))
                    {
                        tipoRec = Request.Params.GetValues("tipo")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("url"))
                    {
                        url = Request.Params.GetValues("url")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("modulo"))
                    {
                        modulo = Request.Params.GetValues("modulo")[0].ToString();
                    }
                    if (!string.IsNullOrEmpty(modulo))
                    {
                        modulo_aux = Convert.ToInt16(modulo);
                    }
                    if (pColl.AllKeys.Contains("tipo"))
                    {
                        tipoRec = Request.Params.GetValues("tipo")[0].ToString();
                    }
                    if (!string.IsNullOrEmpty(tipoRec))
                    {
                        tipo_aux = Convert.ToInt16(tipoRec);
                    }
                    if (!string.IsNullOrEmpty(id_usuario))
                    {
                        id_usuario_aux = Convert.ToInt16(id_usuario);
                    }
                    
                    if (opcion.ToUpper().Equals("ADD"))
                    {
                        AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                        outTxt = datosUsuario.addRecCapacitacion(tituloRec, tipo_aux, modulo_aux, id_cap_aux, url, id_usuario_aux);
                    }

                    else if (opcion.ToUpper().Equals("DEL"))
                    {
                        AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                        outTxt = datosUsuario.delRecCapacitacion(id_cap_aux, id_usuario_aux);
                    }
                    else if (opcion.ToUpper().Equals("MOD"))
                    {
                        AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                        outTxt = datosUsuario.updTemaCapacitacion(id_cap_aux, tituloRec, tipoRec, id_usuario_aux);
                    }

                }
                Response.Write(outTxt);
                Response.End();

            }
        }
    }
}