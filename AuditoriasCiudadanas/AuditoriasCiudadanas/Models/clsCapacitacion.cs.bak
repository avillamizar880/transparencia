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

    internal static string addRecursoMultimedia(int tipo_recurso, string titulo, string descripcion, string ruta, int id_usuario)
    {
      throw new NotImplementedException();
    }

    internal static string delRecursoMultimedia(int id_recurso, int id_usuario)
    {
      throw new NotImplementedException();
    }

    internal static List<DataTable> ObtListadoRecursoMutimedia(int id_tipo, int page, int numPerPag)
    {
      throw new NotImplementedException();
    }

    internal static string addTemaCapacitacion(string titulo, string detalle, int id_usuario)
    {
      throw new NotImplementedException();
    }

    internal static List<DataTable> listTemaCapacitacion()
    {
      throw new NotImplementedException();
    }
  }
}