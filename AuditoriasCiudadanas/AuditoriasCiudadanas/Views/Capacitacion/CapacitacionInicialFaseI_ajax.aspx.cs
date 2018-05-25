using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Capacitacion
{
  public partial class CapacitacionInicialFaseI_ajax : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.CapacitacionController datosCapacitacion = new Controllers.CapacitacionController();
      Response.Write(datosCapacitacion.ObtenerUrlCapacitacion("Control Social"));
    }
  }
}