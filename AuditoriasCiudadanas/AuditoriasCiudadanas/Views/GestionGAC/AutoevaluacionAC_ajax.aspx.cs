﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.GestionGAC
{
  public partial class AutoevaluacionAC_ajax : App_Code.PageSession
    {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.AutoevaluacionController autoevaluacionAc = new Controllers.AutoevaluacionController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "GUARDARAUTOEVALUACION":
                Response.Write(autoevaluacionAc.GuardarAutoevaluacion(Request.Form[i].ToString()));
                break;
            }
      }
    }
  }
}