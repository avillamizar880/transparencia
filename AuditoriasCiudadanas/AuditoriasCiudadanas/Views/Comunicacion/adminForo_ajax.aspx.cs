﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Comunicacion
{
    public partial class adminForo_ajax : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string opcion = "";
            string id_usuario = "";
            string tema = "";
            string descripcion = "";
            string mensaje = "";
            string outTxt = "";
            int id_usuario_aux = 0;



            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;



                if (pColl.AllKeys.Contains("opc"))
                {
                    opcion = Request.Params.GetValues("opc")[0].ToString();
                }

                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                }
                if (pColl.AllKeys.Contains("tema"))
                {
                    tema = Request.Params.GetValues("tema")[0].ToString();
                }
                if (pColl.AllKeys.Contains("desc"))
                {
                    descripcion = Request.Params.GetValues("desc")[0].ToString();
                }
                if (pColl.AllKeys.Contains("mensaje"))
                {
                    mensaje = Request.Params.GetValues("mensaje")[0].ToString();
                }
                if (!string.IsNullOrEmpty(id_usuario))
                {
                    id_usuario_aux = Convert.ToInt16(id_usuario);
                }


                if (opcion.ToUpper().Equals("ADD"))
                {
                    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    //outTxt = datosUsuario.addRecursoMultimedia(tipo_recurso_aux, titulo, descripcion, enlace_url, id_usuario_aux);
                }
                else if (opcion.ToUpper().Equals("DEL"))
                {
                    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    //outTxt = datosUsuario.delRecursoMultimedia(id_recurso_aux, id_usuario_aux);
                }
                else if (opcion.ToUpper().Equals("MOD"))
                {
                    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    //outTxt = datosUsuario.modRecursoMultimedia(id_recurso_aux, titulo, descripcion, enlace_url, id_usuario_aux);
                }


                Response.Write(outTxt);
                Response.End();
            }
        }
    }
}