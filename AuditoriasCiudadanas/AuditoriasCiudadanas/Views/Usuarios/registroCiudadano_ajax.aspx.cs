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
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Crear usuario en bd
            string outTxt = "";
            string nombre = "";
            string email = "";
            string celular = "";
            string hash_clave ="";
            string id_perfil = "2"; //CIUDADANO
            string id_departamento = "";
            string id_municipio = "";
            string hash_aux = "";

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                //string nombre,string email,string celular,string hash_clave,int idperfil,int id_departamento,int id_municipio
                NameValueCollection pColl = Request.Form;
                if (pColl.AllKeys.Contains("nombre")){
                    nombre = Request.Params.GetValues("nombre")[0].ToString();
                }
                if (pColl.AllKeys.Contains("email")){
                    email = Request.Params.GetValues("email")[0].ToString();
                }
                if (pColl.AllKeys.Contains("celular")){
                    celular = Request.Params.GetValues("celular")[0].ToString();
                }
                if (pColl.AllKeys.Contains("hash_clave")){
                    hash_clave = Request.Params.GetValues("hash_clave")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_departamento")){
                    id_departamento = Request.Params.GetValues("id_departamento")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_municipio")){
                    id_municipio = Request.Params.GetValues("id_municipio")[0].ToString();
                }

                AuditoriasCiudadanas.App_Code.funciones func = new App_Code.funciones();
                hash_aux = func.SHA256Encripta(hash_clave);
            }

            AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();
            outTxt = datos.DatosInsercion(nombre, email, celular, hash_aux, Convert.ToInt16(id_perfil), id_departamento, id_municipio);
            string[] separador = new string[] { "<||>" };
            var result = outTxt.Split(separador, StringSplitOptions.None);
            if (result[0].Equals("0"))
            {
                //usuario creado, enviar correo de verificacion
                
            }


            Response.Write(outTxt);
            Response.End();
        }
    }
}