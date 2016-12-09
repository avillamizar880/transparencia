using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace AuditoriasCiudadanas.Models
{
  static public class clsCategoriasAuditorModels
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
    /// <summary>
    /// Sirve para obtener todas las categorias de auditores definidas
    /// </summary>
    /// <returns>Una tabla con los tipos de auditor que existen en la base de datos</returns>
    static public DataTable GetCategoriasAuditor()
    {
      return DbManagement.getDatosDataTable("dbo.pa_listar_tiposauditor", CommandType.StoredProcedure, cadTransparencia, new List<PaParams>());
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="idTipoAuditor"></param>
    /// <returns></returns>
    static public bool EliminarCategoriasAuditor(int idTipoAuditor)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTipoAuditor", SqlDbType.Int, idTipoAuditor, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output,100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      string cod_error =DbManagement.EliminarDatos("dbo.pa_del_tiposauditor", CommandType.StoredProcedure, cadTransparencia, parametros);
      return cod_error==string.Empty? true:false;
    }
    /// <summary>
    /// Sirve para guardar el registro correspondiente a la categoría de un auditor
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros de la encuesta</param>
    /// <returns>Devuelve un texto indicando si hubo o no errores al guardar la encuesta</returns>
    static public string IngresarActualizarCategoriaAuditor(params object[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length <= 5) return "-2";//Significa que los parámetros no son correctos
        var nombre = parametrosGuardar[1].ToString() != string.Empty ? parametrosGuardar[1].ToString() : string.Empty;
        var descripcion = parametrosGuardar[2].ToString() != string.Empty ? parametrosGuardar[2].ToString() : string.Empty;
        var rutaImagen = parametrosGuardar[3].ToString() != string.Empty ? parametrosGuardar[3].ToString() : string.Empty;
        var limiteInferior = 0;
        var limiteSuperior = 0;
        if (!int.TryParse(parametrosGuardar[4].ToString(), out limiteInferior)) return "-3"; //El límite inferior no es un dato numérico
        if (!int.TryParse(parametrosGuardar[5].ToString(), out limiteSuperior)) return "-4"; //El límite superior no es un dato numérico
        if (limiteSuperior < limiteInferior) return "-5";//El límite superior no puede ser menor al limite inferior
        var idTipoAuditor = 0;
        if (!int.TryParse(parametrosGuardar[0].ToString(), out idTipoAuditor)) return "-6";//El valor del idTipoAuditor no es un número
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_ins_tiposauditor";
        if (idTipoAuditor > 0)
        {
          parametros.Add(new PaParams("@idTipoAuditor", SqlDbType.Int, idTipoAuditor.ToString(), ParameterDirection.Input));
          procedimientoAlmacenado = "pa_upd_tiposauditor";
        }
        parametros.Add(new PaParams("@nombre", SqlDbType.VarChar, nombre, ParameterDirection.Input, 100));
        parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, descripcion, ParameterDirection.Input, 100));
        parametros.Add(new PaParams("@imagen", SqlDbType.VarChar, rutaImagen, ParameterDirection.Input, 100));
        parametros.Add(new PaParams("@limiteInferior", SqlDbType.Int, limiteInferior.ToString(), ParameterDirection.Input));
        parametros.Add(new PaParams("@limiteSuperior", SqlDbType.Int, limiteSuperior, ParameterDirection.Input));
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