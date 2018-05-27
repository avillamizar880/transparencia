using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Globalization;
using AuditoriasCiudadanas.Models;

namespace AuditoriasCiudadanas.Controllers
{
  public class InformacionController
  {
    /// <summary>
    /// ObtenerTotalAuditoresXPalabraClave
    /// </summary>
    /// <param name="palabraClave"></param>
    /// <returns></returns>
    public string ObtenerTotalNoticias(string palabraClave)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsNoticia.ObtenerTotalNoticias(palabraClave);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }

  }
}