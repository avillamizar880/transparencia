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
              case "VALIDARACCESO":
                if (Session != null && Session["idUsuario"] != null) Response.Write("True");
                else Response.Write("False");
                break;
              case "BUSCARPROYECTOSPALABRACLAVE":
                var parametrosConsulta = Request.Form[i].ToString().Split('*');
                if (parametrosConsulta.Length >= 3)
                {
                  var numPag = 1;
                  var tamanoPag = 20;
                  if (parametrosConsulta[1] != string.Empty && parametrosConsulta[2] != string.Empty && int.TryParse(parametrosConsulta[1], out numPag) && int.TryParse(parametrosConsulta[2], out tamanoPag)) Response.Write(datosProyectos.ObtenerProyectosXPalabraClave(parametrosConsulta[0], numPag, tamanoPag));
                  else Response.Write(datosProyectos.ObtenerProyectosXPalabraClave(parametrosConsulta[0], 1, 20));
                }
                else
                  Response.Write(datosProyectos.ObtenerProyectosXPalabraClave(Request.Form[i].ToString(), 1, 20));
                break;
              case "BUSCARTOTALPROYECTOSAUDITABLES":
                Response.Write(datosProyectos.ObtenerTotalProyectosAuditables(Request.Form[i].ToString()));
                break;
              case "BUSCARAUDITORESPALABRACLAVE":
                Response.Write(datosProyectos.ObtenerAuditoresProyectosXPalabraClave(Request.Form[i].ToString()));
                break;
              case "BUSCARTOTALAUDITORES":
                Response.Write(datosProyectos.ObtenerTotalAuditoresXPalabraClave(Request.Form[i].ToString()));
                break;
            }
      }
    }
  }
}