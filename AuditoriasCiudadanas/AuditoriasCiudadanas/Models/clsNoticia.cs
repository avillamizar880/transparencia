﻿using System.Collections.Generic;
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
    /// Sirve para obtener el detalle de la noticia
    /// </summary>
    /// <param name="idNoticia">Es el id de la noticia</param>
    /// <returns>Devuelve un registro con el detalle de la noticia</returns>
    public static DataTable ObtenerDetalleNoticia(int idNoticia)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idNoticia", SqlDbType.Int, idNoticia, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_detallenoticia", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para obtener el total de nuevas (menor a 24 horas) noticias publicadas
    /// </summary>
    /// <returns>El total de noticias que cumplen con esta condición</returns>
    public static DataTable ObtenerTotalNoticiasNuevas()
    {
      return DbManagement.getDatosDataTable("dbo.pa_cont_noticias_nuevas", CommandType.StoredProcedure, cadTransparencia, new List<PaParams>());
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
    /// Sirve para guardar los datos básicos de una noticia
    /// </summary>
    /// <param name="parametos">Son algunos de los parámetros necesarios para crear un registro de noticia</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public static string GuardarNoticia(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length < 5) return "-2";//Significa que los parámetros no son correctos
        var titulo = string.Empty;
        var fechaNoticia = DateTime.Now;
        var detalle = string.Empty;
        var urlNoticia = string.Empty;
        var idUsuario = 0;
        var estado = 1;
        var publicado = 0;
        titulo = parametrosGuardar[0];
        if (!DateTime.TryParse(parametrosGuardar[1].ToString().Trim(), out fechaNoticia)) return "-3";//El valor de la fecha no es válido
        detalle = parametrosGuardar[2].Trim();
        urlNoticia = parametrosGuardar[3].Trim();
        if (!int.TryParse(parametrosGuardar[4].ToString().Trim(), out idUsuario)) return "-4";//El valor del idUsuario no es un número
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_ins_noticia";
        parametros.Add(new PaParams("@titulo", SqlDbType.NVarChar, titulo, ParameterDirection.Input,2000));
        parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaNoticia, ParameterDirection.Input));
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
    /// Sirve para guardar los datos básicos de una noticia
    /// </summary>
    /// <param name="parametos">Son algunos de los parámetros necesarios para crear un registro de noticia</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public static string EditarNoticia(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length < 6) return "-2";//Significa que los parámetros no son correctos
        var titulo = string.Empty;
        var fechaNoticia = DateTime.Now;
        var detalle = string.Empty;
        var urlNoticia = string.Empty;
        var idUsuario = 0;
        var idNoticia = 0;
        titulo = parametrosGuardar[0].Trim();
        if (!DateTime.TryParse(parametrosGuardar[1].ToString().Trim(), out fechaNoticia)) return "-3";//El valor de la fecha no es válido
        detalle = parametrosGuardar[2].Trim();
        urlNoticia = parametrosGuardar[3].Trim();
        if (!int.TryParse(parametrosGuardar[4].ToString().Trim(), out idUsuario)) return "-4";//El valor del idUsuario no es un número
        if (!int.TryParse(parametrosGuardar[5].ToString().Trim(), out idNoticia)) return "-5";//El valor del idNoticia no es un número
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_upd_noticia";
        parametros.Add(new PaParams("@idNoticia", SqlDbType.Int, idNoticia, ParameterDirection.Input));
        parametros.Add(new PaParams("@titulo", SqlDbType.NVarChar, titulo, ParameterDirection.Input, 2000));
        parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaNoticia, ParameterDirection.Input));
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