using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace AuditoriasCiudadanas.Models
{
  public class clsNoticia
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

    /// <summary>
    /// Sirve para obtener el total de proyectos auditables
    /// </summary>
    /// <param name="palabraClave">Es la palabra clave de la búsqueda</param>
    /// <returns>El # de proyectos presentes</returns>
    public static DataTable ObtenerTotalNoticias(string palabraClave)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave.ToUpper(), ParameterDirection.Input, 100));
      return DbManagement.getDatosDataTable("dbo.pa_cont_noticias", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
  }
}