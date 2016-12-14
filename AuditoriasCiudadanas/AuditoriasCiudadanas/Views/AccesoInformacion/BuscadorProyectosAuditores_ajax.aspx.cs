using System;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.AccesoInformacion
{
  public partial class BuscadorProyectosAuditores_ajax : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.ProyectosController datosProyectos = new Controllers.ProyectosController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "BUSCARPROYECTOSPALABRACLAVE":
                Response.Write(datosProyectos.ObtenerProyectosXPalabraClave(Request.Form[i].ToString()));
                break;
              case "BUSCARAUDITORESPALABRACLAVE":
                Response.Write(datosProyectos.ObtenerAuditoresProyectosXPalabraClave(Request.Form[i].ToString()));
                break;
            }
      }
    }
  }
}