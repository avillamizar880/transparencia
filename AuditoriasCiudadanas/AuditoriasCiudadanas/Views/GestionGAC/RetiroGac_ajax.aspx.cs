using System;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.GestionGAC
{
  public partial class RetiroGac_ajax : App_Code.PageSession
    {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.ProyectosController datos = new Controllers.ProyectosController();
      if (Request.Form != null)
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "BUSCARTOTALGAC":
                Response.Write(datos.ObtenerTotalGruposAuditoresCiudadanos(Request.Form[i].ToString()));
                break;
              case "BUSCARGAC":
                var parametrosConsulta = Request.Form[i].ToString().Split('*');
                if (parametrosConsulta.Length >= 3)
                {
                  var numPag = 1;
                  var tamanoPag = 20;
                  if (parametrosConsulta[1] != string.Empty && parametrosConsulta[2] != string.Empty && int.TryParse(parametrosConsulta[1], out numPag) && int.TryParse(parametrosConsulta[2], out tamanoPag)) Response.Write(datos.ObtenerGacXPalabraClave(parametrosConsulta[0], numPag, tamanoPag));
                  else Response.Write(datos.ObtenerGacXPalabraClave(parametrosConsulta[0], 1, 20));
                }
                else
                  Response.Write(datos.ObtenerGacXPalabraClave(Request.Form[i].ToString(), 1, 20));
                break;
              case "MODIFICARESTADOMIEMBROGAC": 
                Response.Write(datos.ModificarEstadoMiembroGac(Request.Form[i].ToString()));
                break;
              case "MODIFICARESTADOGAC":
                Response.Write(datos.ModificarEstadoGac(Request.Form[i].ToString()));
                break;
            }
    }
  }
}