using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class detalleInfoTecnica_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_infotecnica = 0;
            string outTxt = "";
            string opcion = "";
            string bpin_proyecto = "";
            string id_usuario = "";
            int id_usuario_aux = 0;

            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_info"))
            {
                string id_info_aux=Request.Params.GetValues("id_info")[0].ToString();
                if(!string.IsNullOrEmpty(id_info_aux)){
                    id_infotecnica = Convert.ToInt16(id_info_aux);
                }
            }
            if (pColl.AllKeys.Contains("opcion"))
            {
                opcion = Request.Params.GetValues("opcion")[0].ToString();
            }
            if (pColl.AllKeys.Contains("id_proyecto"))
            {
                bpin_proyecto = Request.Params.GetValues("id_proyecto")[0].ToString();
            }
            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                if (!string.IsNullOrEmpty(id_usuario))
                {
                    id_usuario_aux = Convert.ToInt16(id_usuario);
                }
            }
            if (opcion.Equals("edit"))
            {
                //carga datos para edicion
                AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
                outTxt = datos.obtInfoTecnicaById(id_infotecnica);
            }
            else {
                if (id_infotecnica>0){ 
                    //carga datos para ver detalle
                    AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
                    outTxt = datos.obtInfoTecnica(id_infotecnica);
                }
                else if (!string.IsNullOrEmpty(bpin_proyecto)) {
                    //carga toda la informacion tecnica del proyecto
                    AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
                    outTxt = datos.obtInfoTecnicaProyecto(bpin_proyecto, id_usuario_aux);
                }
              
            }
            
            Response.Write(outTxt);
            Response.End();
        }

    }
}