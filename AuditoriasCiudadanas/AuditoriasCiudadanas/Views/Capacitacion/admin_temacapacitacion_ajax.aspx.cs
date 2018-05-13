﻿using AuditoriasCiudadanas.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Capacitacion
{
	public partial class admin_temacapacitacion_ajax : App_Code.PageSession
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            string opcion = "";
            string id_usuario = "";
            string titulo = "";
            string detalle = "";
            string outTxt = "";
            int id_usuario_aux = 0;
            ModelTemaCapacitacion objReturn = new ModelTemaCapacitacion();


            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;

                if (pColl.AllKeys.Contains("opc"))
                {
                    opcion = Request.Params.GetValues("opc")[0].ToString();
                }
                if (opcion.ToUpper().Equals("LIST"))
                {
                    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    objReturn = datosUsuario.ObtListadoTemaCapacitacion();
                    AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
                    outTxt = string.Empty;
                    outTxt = datos_func.convertToJsonObj(objReturn);
                }
                else
                {
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
                        detalle = Request.Params.GetValues("desc")[0].ToString();
                    }
                
                    if (!string.IsNullOrEmpty(id_usuario)) {
                        id_usuario_aux = Convert.ToInt16(id_usuario);
                    }
         
                    if (opcion.ToUpper().Equals("ADD"))
                    {
                        AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                        outTxt = datosUsuario.addTemaCapacitacion(titulo, detalle, id_usuario_aux);
                    }

                    //else if (opcion.ToUpper().Equals("DEL"))
                    //{
                    //    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    //    outTxt = datosUsuario.delRecursoMultimedia(id_usuario_aux);
                    //}
                    //else if (opcion.ToUpper().Equals("MOD"))
                    //{
                    //    AuditoriasCiudadanas.Controllers.CapacitacionController datosUsuario = new AuditoriasCiudadanas.Controllers.CapacitacionController();
                    //    outTxt = datosUsuario.modRecursoMultimedia(id_recurso_aux,titulo, descripcion, enlace_url, id_usuario_aux);
                    //}

                }
                Response.Write(outTxt);
                Response.End();
                
            }

        }
	}
}