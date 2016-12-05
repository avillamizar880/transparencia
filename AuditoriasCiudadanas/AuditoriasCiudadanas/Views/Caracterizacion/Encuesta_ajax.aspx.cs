using System;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.Caracterizacion
{
  public partial class Encuesta_ajax : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.CaracterizacionController datos = new Controllers.CaracterizacionController();
      if (Request.Form != null)
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "MUNICIPIO":
                Response.Write(datos.ObtenerMunicipiosYDepartamentos());
                break;
              case "VALIDARNOMBREMUNICIPIO":
                Session["ParGuardarEncuesta"] = Request.Form[i];
                Response.Write(datos.ExisteMunicipio(Request.Form[i]));
                break;
              case "GUARDAR":
                Session["ParGuardarEncuesta"] = Session["ParGuardarEncuesta"] + "*" + Request.Form[i] + "*1";//TODO: El ultimo es el id del usuario, debemos cambiarlo luego!!!
                Response.Write(datos.GuardarEncuestaCaracterizacion(Session["ParGuardarEncuesta"].ToString()));
                break;
            }
    }
  }
}