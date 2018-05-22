using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
  public class clsCapacitacion
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
    static public string ObtenerUrlCapacitacion(string nombreCapacitacion)
    {
      var parametros = new List<PaParams>();
      parametros.Add(new PaParams("@nombreCapacitacion", SqlDbType.VarChar, nombreCapacitacion, ParameterDirection.Input, 100));
      var dtUrlCapacitacion = DbManagement.getDatosDataTable("dbo.pa_obt_urlcap", CommandType.StoredProcedure, cadTransparencia, parametros);
      if (dtUrlCapacitacion != null && dtUrlCapacitacion.Rows.Count > 0) return dtUrlCapacitacion.Rows[0].ItemArray[0].ToString();
      else return string.Empty;//Significa que no hubo datos
    }
  }
}