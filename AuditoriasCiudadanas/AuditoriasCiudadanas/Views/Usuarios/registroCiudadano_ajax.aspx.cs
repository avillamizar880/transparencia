using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class registroCiudadano_ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Crear usuario en bd
            string outTxt = String.Empty;
            string nombre = String.Empty;
            string email = String.Empty;
            string celular = string.Empty;
            string hash_clave = string.Empty;
            int id_perfil = 1;
            int id_departamento = 1;
            int id_municipio = 1;
            
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                //string nombre,string email,string celular,string hash_clave,int idperfil,int id_departamento,int id_municipio
                if (pColl.AllKeys.Contains("nombre")) {
                    nombre = pColl.Get("nombre").ToString();
                }
                if (pColl.AllKeys.Contains("nombre")) {
                    nombre = pColl.Get("nombre").ToString();
                    nombre = pColl.GetValues("nombre")[0].ToString();
                }

            }


            AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();
            outTxt = datos.DatosInsercion(nombre,email,celular,hash_clave,id_perfil,id_departamento,id_municipio);
            Response.Write(outTxt);
        }
    }
}