﻿using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class crearUsuarios_ajax : System.Web.UI.Page
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
                string hash_clave = "auditorias123";
                string id_perfil = ""; 
                string hash_aux = "";
            if (HttpContext.Current.Request.HttpMethod == "POST")
                {
                    NameValueCollection pColl = Request.Params;
                    if (pColl.AllKeys.Contains("id_perfil"))
                    {
                        id_perfil = Request.Params.GetValues("id_perfil")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("nombre"))
                    {
                        nombre = Request.Params.GetValues("nombre")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("email"))
                    {
                        email = Request.Params.GetValues("email")[0].ToString();
                    }
                    if (pColl.AllKeys.Contains("celular"))
                    {
                        celular = Request.Params.GetValues("celular")[0].ToString();
                    }
                }
                AuditoriasCiudadanas.App_Code.funciones func = new App_Code.funciones();
                hash_aux = func.SHA256Encripta(hash_clave);

                AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();
                outTxt = datos.insercionOtros(nombre, email, celular, hash_aux, Convert.ToInt16(id_perfil));
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
