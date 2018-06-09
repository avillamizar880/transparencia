using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System;

namespace AuditoriasCiudadanas.Models
{
  //Creado por DianaB
  public class clsCampana
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
    /// <summary>
    /// Sirve para obtener el total de campañas
    /// </summary>
    /// <param name="palabraClave">Es la palabra clave de la búsqueda</param>
    /// <returns>El total de campañas que cumplen con el criterio de búsqueda</returns>
    public static DataTable ObtenerTotalCampanas(string palabraClave)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave.ToUpper(), ParameterDirection.Input, 100));
      return DbManagement.getDatosDataTable("dbo.pa_cont_campanas", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para obtener el total de campañas publicadas
    /// </summary>
    /// <param name="palabraClave">Es la palabra clave de la búsqueda</param>
    /// <returns>El # de campañas presentes</returns>
    public static DataTable ObtenerTotalCampanasPublicadas(string palabraClave)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave.ToUpper(), ParameterDirection.Input, 100));
      return DbManagement.getDatosDataTable("dbo.pa_cont_campanaspublicadas", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para traer las campañas que coincidan con la palabra clave
    /// </summary>
    /// <param name="palabraClave">Es la palabra a buscar</param>
    /// <param name="numPag">Es el número de la página</param>
    /// <param name="TamanoPag">Es la cantidad de registros por página</param>
    /// <returns>Una tabla con los resultados</returns>
    public static DataTable ObtenerCampanasXPalabraClave(string palabraClave, int numPag, int TamanoPag)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave, ParameterDirection.Input, 100));
      parametros.Add(new PaParams("@pagenum", SqlDbType.Int, numPag, ParameterDirection.Input));
      parametros.Add(new PaParams("@pagesize", SqlDbType.Int, TamanoPag, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_lista_campanas", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para publicar una campaña
    /// </summary>
    /// <param name="idNoticiaPublicar">Es el id de la campaña a publicar.</param>
    /// <param name="idUsuario">Es el id del usuario que realiza la operación.</param>
    /// <returns>Devuelve un valor (true o false) el cual indica que se realizó el procedimiento.</returns>
    public static string PublicarCampana(int idNoticiaPublicar, int idUsuario)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idCampana", SqlDbType.Int, idNoticiaPublicar, ParameterDirection.Input));
      parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      return DbManagement.EliminarDatos("dbo.pa_publicar_campana", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para guardar los datos básicos de una campaña
    /// </summary>
    /// <param name="parametos">Son algunos de los parámetros necesarios para crear un registro de campaña</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public static string GuardarCampana(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length < 5) return "-2";//Significa que los parámetros no son correctos
        var titulo = string.Empty;
        var fechaCampana = DateTime.Now;
        var detalle = string.Empty;
        var urlNoticia = string.Empty;
        var idUsuario = 0;
        var estado = 1;
        var publicado = 0;
        titulo = parametrosGuardar[0];
        if (!DateTime.TryParse(parametrosGuardar[1].ToString(), out fechaCampana)) return "-3";//El valor de la fecha no es válido
        detalle = parametrosGuardar[2];
        urlNoticia = parametrosGuardar[3];
        if (!int.TryParse(parametrosGuardar[4].ToString(), out idUsuario)) return "-4";//El valor del idUsuario no es un número
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_ins_campana";
        parametros.Add(new PaParams("@titulo", SqlDbType.NVarChar, titulo, ParameterDirection.Input, 2000));
        parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaCampana, ParameterDirection.Input));
        parametros.Add(new PaParams("@detalle", SqlDbType.NVarChar, detalle, ParameterDirection.Input, 1000));
        parametros.Add(new PaParams("@urlNoticia", SqlDbType.NVarChar, urlNoticia, ParameterDirection.Input, 300));
        parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@estado", SqlDbType.VarChar, estado, ParameterDirection.Input, 1));
        parametros.Add(new PaParams("@publicado", SqlDbType.VarChar, publicado, ParameterDirection.Input, 1));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        return cod_error + "<||>" + mensaje_error;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }
    /// <summary>
    /// Sirve para guardar los datos básicos de una campaña
    /// </summary>
    /// <param name="parametos">Son algunos de los parámetros necesarios para crear un registro de noticia</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public static string EditarCampana(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length < 6) return "-2";//Significa que los parámetros no son correctos
        var titulo = string.Empty;
        var fechaCampana = DateTime.Now;
        var detalle = string.Empty;
        var urlNoticia = string.Empty;
        var idUsuario = 0;
        var idNoticia = 0;
        titulo = parametrosGuardar[0];
        if (!DateTime.TryParse(parametrosGuardar[1].ToString(), out fechaCampana)) return "-3";//El valor de la fecha no es válido
        detalle = parametrosGuardar[2];
        urlNoticia = parametrosGuardar[3];
        if (!int.TryParse(parametrosGuardar[4].ToString(), out idUsuario)) return "-4";//El valor del idUsuario no es un número
        if (!int.TryParse(parametrosGuardar[5].ToString(), out idNoticia)) return "-5";//El valor del idNoticia no es un número
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_upd_campana";
        parametros.Add(new PaParams("@idCampana", SqlDbType.Int, idNoticia, ParameterDirection.Input));
        parametros.Add(new PaParams("@titulo", SqlDbType.NVarChar, titulo, ParameterDirection.Input, 2000));
        parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaCampana, ParameterDirection.Input));
        parametros.Add(new PaParams("@detalle", SqlDbType.NVarChar, detalle, ParameterDirection.Input, 1000));
        parametros.Add(new PaParams("@urlNoticia", SqlDbType.NVarChar, urlNoticia, ParameterDirection.Input, 300));
        parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        return cod_error + "<||>" + mensaje_error;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }
    /// <summary>
    /// Sirve para eliminar una campaña
    /// </summary>
    /// <param name="idCampanaEliminar">Es el id de la campaña a eliminar.</param>
    /// <param name="idUsuario">Es el id del usuario que realiza la operación.</param>
    /// <returns>Devuelve un valor (true o false) el cual indica que se realizó el procedimiento.</returns>
    public static string EliminarCampana(int idCampanaEliminar, int idUsuario)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idCampana", SqlDbType.Int, idCampanaEliminar, ParameterDirection.Input));
      parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      return DbManagement.EliminarDatos("dbo.pa_del_campana", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para traer las campañas que coincidan con la palabra clave
    /// </summary>
    /// <param name="palabraClave">Es la palabra a buscar</param>
    /// <param name="numPag">Es el número de la página</param>
    /// <param name="TamanoPag">Es la cantidad de registros por página</param>
    /// <returns>Una tabla con los resultados</returns>
    public static DataTable ObtenerPublicarCampanasXPalabraClave(string palabraClave, int numPag, int TamanoPag)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave, ParameterDirection.Input, 100));
      parametros.Add(new PaParams("@pagenum", SqlDbType.Int, numPag, ParameterDirection.Input));
      parametros.Add(new PaParams("@pagesize", SqlDbType.Int, TamanoPag, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_lista_campanaspublicadas", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    /// <summary>
    /// Sirve para guardar los datos relacionados a los registros multimedia de la campaña
    /// </summary>
    /// <param name="parametos">Son algunos de los parámetros necesarios para crear un registro de tarea</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public static string GuardarRegistroMultimedia(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length < 2) return "-1";//Significa que los parámetros no son correctos
        var idRecurso = 0;
        var rutaImagen = string.Empty;
        var idUsuario = 0;
        var fechaTarea = DateTime.Now;
        var estado = 1;
        if (!int.TryParse(parametrosGuardar[0].ToString(), out idRecurso)) return "-2";//No se encontró un idRecurso para el nombre enviado
        rutaImagen = parametrosGuardar[1].ToString();
        if (!int.TryParse(parametrosGuardar[2].ToString(), out idUsuario)) return "-3";//No se encontró un idUsuario para el nombre enviado
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_ins_detalle_recurso_multimedia";
        parametros.Add(new PaParams("@idRecurso", SqlDbType.Int, idRecurso, ParameterDirection.Input));
        parametros.Add(new PaParams("@rutaImagen", SqlDbType.NVarChar, rutaImagen, ParameterDirection.Input, 300));
        parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@estado", SqlDbType.Int, estado, ParameterDirection.Input));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        return cod_error + "<||>" + mensaje_error;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

  }
}