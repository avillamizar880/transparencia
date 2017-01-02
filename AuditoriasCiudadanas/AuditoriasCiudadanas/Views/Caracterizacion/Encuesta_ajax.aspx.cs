using System;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.Caracterizacion
{
  public partial class Encuesta_ajax : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.CaracterizacionController datos = new Controllers.CaracterizacionController();
      var idUsuario = 0;
      var nombreMunicipio = string.Empty;
      //var parametros= new string[];
      if (Request.Form != null)
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "MUNICIPIO":
                Response.Write(datos.ObtenerMunicipiosYDepartamentos());
                break;
              case "VALIDARNOMBREMUNICIPIO":
                Response.Write(datos.ExisteMunicipio(Request.Form[i]));
                break;
              case "GUARDARPAG1":
                Response.Write(datos.GuardarEncuestaCaracterizacion(1,Request.Form[i]));
                break;
              case "GUARDARPAG2":
                Response.Write(datos.GuardarEncuestaCaracterizacion(2, Request.Form[i]));
                break;
              case "GUARDARPAG3":
                Response.Write(datos.GuardarEncuestaCaracterizacion(3, Request.Form[i]));
                break;
              case "GUARDARPAG4":
                Response.Write(datos.GuardarEncuestaCaracterizacion(4, Request.Form[i]));
                break;
              case "OBTENERDATOSENCUESTAUSUARIOPARTE1":
                idUsuario = 0;
                if(int.TryParse(Request.Form[i].ToString(), out idUsuario))
                  Response.Write(datos.ObtenerDatosEncuestaUsuario(1, idUsuario,string.Empty));
                break;
              case "OBTENERDATOSENCUESTAUSUARIOPARTE2":
                idUsuario = 0;
                nombreMunicipio = string.Empty;
                var parametros = Request.Form[i].ToString().Split('*');
                if (parametros.Length >= 2)
                {
                  var divipola = parametros[1].ToString().Split('-');
                  nombreMunicipio = divipola[0].ToString().Trim();
                  int.TryParse(parametros[0].ToString(), out idUsuario);
                }
                else if (parametros.Length >= 1)
                {
                  int.TryParse(parametros[0].ToString(), out idUsuario);
                }
                if (idUsuario != 0)
                  Response.Write(datos.ObtenerDatosEncuestaUsuario(2, idUsuario, nombreMunicipio));
                break;
              case "OBTENERDATOSENCUESTAUSUARIOPARTE3":
                idUsuario = 0;
                nombreMunicipio = string.Empty;
                var parametrosPag3 = Request.Form[i].ToString().Split('*');
                if (parametrosPag3.Length >= 2)
                {
                  var divipola = parametrosPag3[1].ToString().Split('-');
                  nombreMunicipio = divipola[0].ToString().Trim();
                  int.TryParse(parametrosPag3[0].ToString(), out idUsuario);
                }
                else if (parametrosPag3.Length >= 1)
                {
                  int.TryParse(parametrosPag3[0].ToString(), out idUsuario);
                }
                if (idUsuario != 0)
                  Response.Write(datos.ObtenerDatosEncuestaUsuario(3, idUsuario, nombreMunicipio));
                break;
              case "OBTENERDATOSENCUESTAUSUARIOPARTE4":
                idUsuario = 0;
                nombreMunicipio = string.Empty;
                var parametrosPag4 = Request.Form[i].ToString().Split('*');
                if (parametrosPag4.Length >= 2)
                {
                  var divipola = parametrosPag4[1].ToString().Split('-');
                  nombreMunicipio = divipola[0].ToString().Trim();
                  int.TryParse(parametrosPag4[0].ToString(), out idUsuario);
                }
                else if (parametrosPag4.Length >= 1)
                {
                  int.TryParse(parametrosPag4[0].ToString(), out idUsuario);
                }
                if (idUsuario != 0)
                  Response.Write(datos.ObtenerDatosEncuestaUsuario(4, idUsuario, nombreMunicipio));
                break;
            }
    }
  }
}