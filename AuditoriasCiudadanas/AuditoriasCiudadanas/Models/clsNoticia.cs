using System.Collections.Generic;
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

    /// <summary>
    /// Sirve para traer las noticias que coincidan con la palabra clave
    /// </summary>
    /// <param name="palabraClave">Es la palabra a buscar</param>
    /// <param name="numPag">Es el número de la página</param>
    /// <param name="TamanoPag">Es la cantidad de registros por página</param>
    /// <returns>Una tabla con los resultados</returns>
    public static DataTable ObtenerNoticiasXPalabraClave(string palabraClave, int numPag, int TamanoPag)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave, ParameterDirection.Input, 100));
      parametros.Add(new PaParams("@pagenum", SqlDbType.Int, numPag, ParameterDirection.Input));
      parametros.Add(new PaParams("@pagesize", SqlDbType.Int, TamanoPag, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_lista_noticias", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

  }
}