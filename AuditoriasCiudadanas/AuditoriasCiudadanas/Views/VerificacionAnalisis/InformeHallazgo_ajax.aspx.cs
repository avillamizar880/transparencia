using System;
using System.Web.UI;
namespace AuditoriasCiudadanas.Views.GrupoAuditor
{
  public partial class InformeHallazgo_ajax : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.InformeHallazgoController reporteHallazgo = new Controllers.InformeHallazgoController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "GUARDARINFORMEHALLAZGO":
                Response.Write(reporteHallazgo.GuardarInformeHallazgo(Request.Form[i].ToString()));
                break;
            }
      }
    }
  }
}