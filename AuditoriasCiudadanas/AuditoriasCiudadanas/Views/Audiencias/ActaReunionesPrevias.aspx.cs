﻿using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class ActaReuniones : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string id_usuario = "";
            string id_proyecto = "";
            string id_gac = "";

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                
                               
                if (pColl.AllKeys.Contains("cod_bpin"))
                {
                    id_proyecto = Request.Params.GetValues("cod_bpin")[0].ToString();
                }
                else { 
                    if (Session["bpinProyecto"] != null){
                        id_proyecto = Session["bpinProyecto"].ToString();
                    }
                }
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                }
                else { 
                    if (Session["idUsuario"] != null)
                    {
                        id_usuario = Session["idUsuario"].ToString();
                    }
                }

                if (pColl.AllKeys.Contains("id_gac"))
                {
                    id_gac = Request.Params.GetValues("id_gac")[0].ToString();
                }

                hfidproyecto.Value = id_proyecto;
                hdIdUsuario.Value = id_usuario;
                hdIdGac.Value = id_gac;
            }
        }
    }
}