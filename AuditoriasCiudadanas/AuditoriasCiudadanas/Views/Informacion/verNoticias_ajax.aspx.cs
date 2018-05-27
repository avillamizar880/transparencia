using System;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.Informacion
{
  public partial class verNoticias_ajax : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.InformacionController datosNoticias = new Controllers.InformacionController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "BUSCARTOTALNOTICIAS":
                Response.Write(datosNoticias.ObtenerTotalNoticias(Request.Form[i].ToString()));
                break;
            }
      }

    }
  }
}