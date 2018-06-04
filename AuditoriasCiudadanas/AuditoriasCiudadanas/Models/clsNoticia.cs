using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System;

namespace AuditoriasCiudadanas.Models
{
  public class clsNoticia
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
    /// <summary>
    /// Sirve para obtener el total de noticias
    /// </summary>
    /// <param name="palabraClave">Es la palabra clave de la búsqueda</param>
    /// <returns>El total de noticias</returns>
    public static DataTable ObtenerTotalNoticias(string palabraClave)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave.ToUpper(), ParameterDirection.Input, 100));
      return DbManagement.getDatosDataTable("dbo.pa_cont_noticias", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para obtener el total de noticias publicadas
    /// </summary>
    /// <param name="palabraClave">Es la palabra clave de la búsqueda</param>
    /// <returns>El # de noticias presentes</returns>
    public static DataTable ObtenerTotalNoticiasPublicadas(string palabraClave)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave.ToUpper(), ParameterDirection.Input, 100));
      return DbManagement.getDatosDataTable("dbo.pa_cont_noticiaspublicadas", CommandType.StoredProcedure, cadTransparencia, parametros);
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
    /// <summary>
    /// Sirve para publicar una noticia
    /// </summary>
    /// <param name="idNoticiaPublicar">Es el id de la noticia a publicar.</param>
    /// <param name="idUsuario">Es el id del usuario que realiza la operación.</param>
    /// <returns>Devuelve un valor (true o false) el cual indica que se realizó el procedimiento.</returns>
    public static string PublicarNoticia(int idNoticiaPublicar, int idUsuario)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idNoticia", SqlDbType.Int, idNoticiaPublicar, ParameterDirection.Input));
      parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      return DbManagement.EliminarDatos("dbo.pa_publicar_noticia", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    /// <summary>
    /// Sirve para eliminar una noticia
    /// </summary>
    /// <param name="idNoticiaEliminar">Es el id de la noticia a eliminar.</param>
    /// <param name="idUsuario">Es el id del usuario que realiza la operación.</param>
    /// <returns>Devuelve un valor (true o false) el cual indica que se realizó el procedimiento.</returns>
    public static string EliminarNoticia(int idNoticiaEliminar, int idUsuario)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idNoticia", SqlDbType.Int, idNoticiaEliminar, ParameterDirection.Input));
      parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      return DbManagement.EliminarDatos("dbo.pa_del_noticia", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    /// <summary>
    /// Sirve para traer las noticias que coincidan con la palabra clave
    /// </summary>
    /// <param name="palabraClave">Es la palabra a buscar</param>
    /// <param name="numPag">Es el número de la página</param>
    /// <param name="TamanoPag">Es la cantidad de registros por página</param>
    /// <returns>Una tabla con los resultados</returns>
    public static DataTable ObtenerPublicarNoticiasXPalabraClave(string palabraClave, int numPag, int TamanoPag)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave, ParameterDirection.Input, 100));
      parametros.Add(new PaParams("@pagenum", SqlDbType.Int, numPag, ParameterDirection.Input));
      parametros.Add(new PaParams("@pagesize", SqlDbType.Int, TamanoPag, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_lista_noticiaspublicadas", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

  }
}