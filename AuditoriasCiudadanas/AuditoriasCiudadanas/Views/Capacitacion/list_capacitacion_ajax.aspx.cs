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
    public partial class list_capacitacion_ajax : App_Code.PageSession
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
            string ruta = "";
            string cod_error = "";
            string msg_error = "";


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
                if (pColl.AllKeys.Contains("id_Rcap"))
                {
                    id_reccap = Request.Params.GetValues("id_Rcap")[0].ToString();
                }
                if (!string.IsNullOrEmpty(id_reccap))
                {
                    id_reccap_aux = Convert.ToInt16(id_reccap);
                }
                if (pColl.AllKeys.Contains("modulo"))
                {
                    modulo = Request.Params.GetValues("modulo")[0].ToString();
                }
                if (!string.IsNullOrEmpty(modulo))
                {
                    modulo_aux = Convert.ToInt16(modulo);
                }
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                }
                if (!string.IsNullOrEmpty(id_usuario))
                {
                    id_usuario_aux = Convert.ToInt16(id_usuario);
                }
                if (opcion.ToUpper().Equals("LIST"))
                {
                    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    //outTxt = datosUsuario.ObtListadoCapacitacion(id_cap_aux);
                    outTxt = datosUsuario.ObtModulosCapacitacionUsuJson(id_cap_aux,id_usuario_aux);
                }
                else if (opcion.ToUpper().Equals("RECMOD")) {
                    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    outTxt = datosUsuario.ObtRecursosModuloJson(id_cap_aux, modulo_aux, id_usuario_aux);
                } else if (opcion.ToUpper().Equals("EVALUA")) {
                    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                     outTxt = datosUsuario.obtCuestionarioCapacitacionJson(id_cap_aux);

                }

                else
                {
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

                    if (pColl.AllKeys.Contains("tipo"))
                    {
                        tipoRec = Request.Params.GetValues("tipo")[0].ToString();
                    }
                    if (!string.IsNullOrEmpty(tipoRec))
                    {
                        tipo_aux = Convert.ToInt16(tipoRec);
                    }
                    

                    if (opcion.ToUpper().Equals("ADD"))
                    {
                        AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                        outTxt = datosUsuario.registrarRCaptVista(id_reccap_aux, id_usuario_aux);
                    }

                }
                Response.Write(outTxt);
                Response.End();

            }
        }
    }
}