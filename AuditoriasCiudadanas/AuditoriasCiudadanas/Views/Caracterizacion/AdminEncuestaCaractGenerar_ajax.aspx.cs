using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Caracterizacion
{
  public partial class AdminEncuestaCaractGenerar_ajax : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.CaracterizacionController datos = new Controllers.CaracterizacionController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "RESULTADOFECHACORTE":
                Response.Write(datos.ObtenerFechaCorteReporteCaracterizacion(Request.Form[i]));
                break;
            }
      }
    }
  }
}