using System;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.Caracterizacion
{
  public partial class EncuestaParte2 : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          if (Request.Form != null)
          {
            for (var i = 0; i < Request.Form.AllKeys.Length; i++)
              if (Request.Form.AllKeys[i] != null)
                switch (Request.Form.AllKeys[i].ToString().ToUpper())
                {
                  case "PARAMETROINICIO":
                    var parametrosInicio = Request.Form[i].ToString().Split('*');
                    if (parametrosInicio.Length >= 2)
                    {
                      //hfmunicipio.Value = parametrosInicio[0].ToString();
                      hfUsuarioId.Value = parametrosInicio[1].ToString();
                    }
                    else if (parametrosInicio.Length >= 1)
                    {
                      hfUsuarioId.Value = parametrosInicio[0].ToString();
                      //hfmunicipio.Value = parametrosInicio[0].ToString();
                    }
                    break;
                }
          }
       }
    }
}