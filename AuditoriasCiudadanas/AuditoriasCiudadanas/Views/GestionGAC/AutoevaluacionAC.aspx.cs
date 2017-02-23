using System;

namespace AuditoriasCiudadanas.Views.GestionGAC
{
  public partial class AutoevaluacionAC : System.Web.UI.Page
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
                hfCodigoBPIN.Value = string.Empty;
                hfidUsuario.Value = string.Empty;
                if (Session["idUsuario"] != null) hfidUsuario.Value = Session["idUsuario"].ToString();
                switch (parametrosInicio.Length)
                {
                  case 1:
                    hfCodigoBPIN.Value = parametrosInicio[0].ToString();
                    break;
                  default:
                    hfCodigoBPIN.Value = parametrosInicio[0].ToString();
                    break;
                }
                break;
            }
      }
    }
  }
}