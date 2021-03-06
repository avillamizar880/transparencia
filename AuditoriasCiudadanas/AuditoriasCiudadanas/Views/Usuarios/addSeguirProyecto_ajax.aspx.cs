﻿using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class addSeguirProyecto_ajax : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                string id_usuario = "";
                string bpin_proyecto = "";
                int id_usuario_aux = 0;
                string outTxt = "";
                string opcion = "";

                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                    if (!string.IsNullOrEmpty(id_usuario))
                    {
                        id_usuario_aux = Convert.ToInt16(id_usuario);
                    }
                }
                if (pColl.AllKeys.Contains("bpin_proyecto"))
                {
                    bpin_proyecto = Request.Params.GetValues("bpin_proyecto")[0].ToString();
                }
                if (pColl.AllKeys.Contains("opcion"))
                {
                    opcion = Request.Params.GetValues("opcion")[0].ToString();
                }

                if (opcion.Equals("ELIMINAR"))
                {
                    AuditoriasCiudadanas.Controllers.UsuariosController datosUsuario = new AuditoriasCiudadanas.Controllers.UsuariosController();
                    outTxt = datosUsuario.delSeguirProyecto(id_usuario_aux, bpin_proyecto);
                }
                else {
                    AuditoriasCiudadanas.Controllers.UsuariosController datosUsuario = new AuditoriasCiudadanas.Controllers.UsuariosController();
                    outTxt = datosUsuario.addSeguirProyecto(id_usuario_aux, bpin_proyecto);
                }
                

                
               
                Response.Write(outTxt);
                Response.End();

            }
        }
    }
}