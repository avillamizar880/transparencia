using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Capacitacion
{
	public partial class admin_enlaces_ajax : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            string opcion = "";
            string id_usuario = "";
            string titulo = "";
            string descripcion = "";
            string enlace_url = "";
            string outTxt = "";
            int id_usuario_aux = 0;
            string id_recurso = "";
            int id_recurso_aux = 0;
            string tipo_recurso = "";
            int tipo_recurso_aux = 0;


            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;

                if (pColl.AllKeys.Contains("tipo_recurso"))
                {
                    tipo_recurso = Request.Params.GetValues("tipo_recurso")[0].ToString();
                }

                if (pColl.AllKeys.Contains("opc"))
                {
                    opcion = Request.Params.GetValues("opc")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_recurso"))
                {
                    id_recurso = Request.Params.GetValues("id_recurso")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                }
                if (pColl.AllKeys.Contains("titulo"))
                {
                    titulo = Request.Params.GetValues("titulo")[0].ToString();
                }
                if (pColl.AllKeys.Contains("desc"))
                {
                    descripcion = Request.Params.GetValues("desc")[0].ToString();
                }
                if (pColl.AllKeys.Contains("enlace_url"))
                {
                    enlace_url = Request.Params.GetValues("enlace_url")[0].ToString();
                }
                if (!string.IsNullOrEmpty(id_usuario))
                {
                    id_usuario_aux = Convert.ToInt16(id_usuario);
                }
                if (!string.IsNullOrEmpty(id_recurso))
                {
                    id_recurso_aux = Convert.ToInt16(id_recurso);
                }
                if (!string.IsNullOrEmpty(tipo_recurso))
                {
                    tipo_recurso_aux = Convert.ToInt16(tipo_recurso);
                }

                if (opcion.ToUpper().Equals("ADD"))
                {
                    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    outTxt = datosUsuario.addRecursoMultimedia(tipo_recurso_aux, titulo, descripcion, enlace_url, id_usuario_aux);
                }
                else if (opcion.ToUpper().Equals("DEL"))
                {
                    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    outTxt = datosUsuario.delRecursoMultimedia(id_recurso_aux, id_usuario_aux);
                }
                else if (opcion.ToUpper().Equals("MOD"))
                {
                    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    outTxt = datosUsuario.modRecursoMultimedia(id_recurso_aux, titulo, descripcion, enlace_url, id_usuario_aux);
                }


                Response.Write(outTxt);
                Response.End();

            }
        }
	}
}