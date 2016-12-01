using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class cambioClave_ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string clave_ant = "";
            string clave_new = "";
            string id_usuario = "";
            string outTxt = "";
            App_Code.funciones func =new App_Code.funciones();
            string hash_clave_new=func.SHA256Encripta(clave_new);
            string hash_clave_ant = func.SHA256Encripta(clave_ant);
            AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();
            outTxt = datos.CambiarClave(id_usuario, hash_clave_ant,hash_clave_new);
            Response.Write(outTxt);
        }
    }
}