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
              case "BUSCARNOTICIASPALABRACLAVE":
                var parametrosConsulta = Request.Form[i].ToString().Split('*');
                if (parametrosConsulta.Length >= 3)
                {
                  var numPag = 1;
                  var tamanoPag = 20;
                  if (parametrosConsulta[1] != string.Empty && parametrosConsulta[2] != string.Empty && int.TryParse(parametrosConsulta[1], out numPag) && int.TryParse(parametrosConsulta[2], out tamanoPag)) Response.Write(datosNoticias.ObtenerNoticiasXPalabraClave(parametrosConsulta[0], numPag, tamanoPag));
                  else Response.Write(datosNoticias.ObtenerNoticiasXPalabraClave(parametrosConsulta[0], 1, 20));
                }
                else
                  Response.Write(datosNoticias.ObtenerNoticiasXPalabraClave(Request.Form[i].ToString(), 1, 20));
                break;
            }
      }

    }
  }
}