using System;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.Capacitacion
{
  public partial class CapacitacionInicialFaseII_ajax : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.CapacitacionController datosCapacitacion = new Controllers.CapacitacionController();
      Response.Write(datosCapacitacion.ObtenerUrlCapacitacion("Como Capacitarse"));
    }
  }
}