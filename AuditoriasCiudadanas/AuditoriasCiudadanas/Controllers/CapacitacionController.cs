using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Controllers
{
  public class CapacitacionController
  {
    public string ObtenerUrlCapacitacion(string nombreCapacitacion)
    {
      return Models.clsCapacitacion.ObtenerUrlCapacitacion(nombreCapacitacion);
    }
  }
}