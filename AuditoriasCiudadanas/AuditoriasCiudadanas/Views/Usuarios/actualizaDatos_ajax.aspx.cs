using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class actualizaDatos_ajax : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string outTxt = "";
            string id_usuario = "";
            string nombre = "";
            string celular = "";
            string id_divipola = "";
            int id_usuario_aux=0;

            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = pColl.GetValues("id_usuario")[0].ToString();
                if(!string.IsNullOrEmpty(id_usuario)){
                   id_usuario_aux=Convert.ToInt16(id_usuario);
                }
            }
            if (pColl.AllKeys.Contains("nombre"))
            {
                nombre = pColl.GetValues("nombre")[0].ToString();
            }
            if (pColl.AllKeys.Contains("celular"))
            {
                celular = pColl.GetValues("celular")[0].ToString();
            }
            if (pColl.AllKeys.Contains("id_divipola"))
            {
                id_divipola = pColl.GetValues("id_divipola")[0].ToString();
            }

            AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();
            outTxt = datos.actualizarDatosUsu(id_usuario_aux, nombre, id_divipola, celular);
            Response.Write(outTxt);

        }
    }
}