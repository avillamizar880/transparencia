using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace AuditoriasCiudadanas.Models
{
  public class clsProyectos
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

    public static List<DataTable> listarProyectosAll()
    {
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        Data = DbManagement.getDatos("dbo.pa_listar_proyectos", CommandType.StoredProcedure, cadTransparencia, parametros);
        return Data;
    }   
      
    public static List<DataTable> obtInfoProyecto(string id_proyecto,int id_usuario)
    {
      List<DataTable> Data = new List<DataTable>();
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, id_proyecto, ParameterDirection.Input, 15));
      parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
      Data = DbManagement.getDatos("dbo.pa_obt_proyecto", CommandType.StoredProcedure, cadTransparencia, parametros);
      return Data;
    }

    public static string addDescripTecnica(string bpin_proy,string titulo,string descripcion, int id_usuario) 
    {
        string outTxt = "";
        string cod_error = "-1";
        string mensaje_error = "@ERROR";
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@codigoBPIN", SqlDbType.VarChar, bpin_proy, ParameterDirection.Input, 15));
        parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@titulo", SqlDbType.VarChar, titulo, ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, descripcion, ParameterDirection.Input,500));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        Data = DbManagement.getDatos("dbo.pa_ins_info_tecnica_desc", CommandType.StoredProcedure, cadTransparencia, parametros);
        if (Data.Count > 1)
        {
            if (Data[1].Rows.Count > 0)
            {
                cod_error = Data[1].Rows[0]["cod_error"].ToString();
                mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
            }
        }

        outTxt = cod_error + "<||>" + mensaje_error;
        return outTxt;
    }

    public static string EliminarGrupoAuditor(string idGrupo)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idGac", SqlDbType.Int, idGrupo, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      return DbManagement.EliminarDatos("dbo.pa_del_gac", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    public static string addInfoTecnica(string bpin_proy, string titulo, string descripcion, string[] adjuntos, int id_usuario)
    {
      string outTxt = "";
      DateTime fecha_cre = DateTime.Now;
      string ruta_doc = adjuntos[1];
      string ruta_img = adjuntos[0];
      string cod_error = "-1";
      string mensaje_error = "@ERROR";
      List<DataTable> Data = new List<DataTable>();
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, bpin_proy, ParameterDirection.Input, 15));
      parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, id_usuario, ParameterDirection.Input, 15));
      parametros.Add(new PaParams("@fechaCreacion", SqlDbType.DateTime, fecha_cre, ParameterDirection.Input));
      parametros.Add(new PaParams("@titulo", SqlDbType.VarChar, titulo, ParameterDirection.Input, 500));
      parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, descripcion, ParameterDirection.Input, 4000));
      parametros.Add(new PaParams("@ruta_arch", SqlDbType.VarChar, ruta_doc, ParameterDirection.Input, 100));
      parametros.Add(new PaParams("@UrlFoto", SqlDbType.VarChar, ruta_img, ParameterDirection.Input, 500));
      parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
      Data = DbManagement.getDatos("dbo.pa_ins_info_tecnica", CommandType.StoredProcedure, cadTransparencia, parametros);
      if (Data.Count > 1)
      {
          if (Data[1].Rows.Count > 0)
          {
              cod_error = Data[1].Rows[0]["cod_error"].ToString();
              mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
          }
      }

      outTxt = cod_error + "<||>" + mensaje_error;
      return outTxt;
    }
    public static List<DataTable> obtInfoTecnica(int id_info)
    {
      List<DataTable> Data = new List<DataTable>();
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@id_info_tecnica", SqlDbType.Int, id_info, ParameterDirection.Input));
      Data = DbManagement.getDatos("dbo.pa_obt_info_tecnica", CommandType.StoredProcedure, cadTransparencia, parametros);
      return Data;
    }
    public static string ModifInfoTecnica(int id_info, string titulo, string descripcion, string[] adjuntos, int id_usuario)
    {
          string outTxt = "";
          string cod_error = "-1";
          string mensaje_error = "@ERROR";
          DateTime fecha_modif = DateTime.Now;
          string ruta_doc = adjuntos[1];
          string ruta_img = adjuntos[0];
          List<DataTable> Data = new List<DataTable>();
          List<PaParams> parametros = new List<PaParams>();
          parametros.Add(new PaParams("@idInfo", SqlDbType.Int, id_info, ParameterDirection.Input));
          parametros.Add(new PaParams("@idUsuarioModif", SqlDbType.Int, id_usuario, ParameterDirection.Input));
          parametros.Add(new PaParams("@fechaModif", SqlDbType.DateTime, fecha_modif, ParameterDirection.Input));
          parametros.Add(new PaParams("@titulo", SqlDbType.VarChar, titulo, ParameterDirection.Input, 500));
          parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, descripcion, ParameterDirection.Input, 4000));
          parametros.Add(new PaParams("@ruta_arch", SqlDbType.VarChar, ruta_doc, ParameterDirection.Input, 100));
          parametros.Add(new PaParams("@UrlFoto", SqlDbType.VarChar, ruta_img, ParameterDirection.Input, 100));
          parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
          parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
          Data = DbManagement.getDatos("dbo.pa_upd_info_tecnica", CommandType.StoredProcedure, cadTransparencia, parametros);
          if (Data.Count > 1)
          {
              if (Data[1].Rows.Count > 0)
              {
                  cod_error = Data[1].Rows[0]["cod_error"].ToString();
                  mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
              }
          }

            outTxt = cod_error + "<||>" + mensaje_error;
        return outTxt;

    }

    public static List<DataTable> obtInfoGestionProy(string bpin_proyecto, int id_grupo, int id_usuario)
    {

        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@bpin_proyecto", SqlDbType.VarChar, bpin_proyecto, ParameterDirection.Input, 15));
        parametros.Add(new PaParams("@id_grupo", SqlDbType.Int, id_grupo, ParameterDirection.Input));
        parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
        Data = DbManagement.getDatos("dbo.pa_obt_gestion_proyecto", CommandType.StoredProcedure, cadTransparencia, parametros);
        return Data;
    }

    public static List<DataTable> obtCronogramaProyecto(string codigo_bpin,DateTime fecha_ini,DateTime fecha_fin)
    {
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, codigo_bpin, ParameterDirection.Input, 100));
        parametros.Add(new PaParams("@fecha_ini", SqlDbType.DateTime, fecha_ini, ParameterDirection.Input));
        parametros.Add(new PaParams("@fecha_fin", SqlDbType.DateTime, fecha_fin, ParameterDirection.Input));
        Data = DbManagement.getDatos("dbo.pa_obt_actividades_proy", CommandType.StoredProcedure, cadTransparencia, parametros);
        return Data;
    }


    public static List<DataTable> obtGACProyecto(string codigo_bpin, int id_usuario)
    {
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, codigo_bpin, ParameterDirection.Input, 15));
        if (id_usuario <= 0)
        {
            parametros.Add(new PaParams("@id_usuario", SqlDbType.VarChar, System.DBNull.Value, ParameterDirection.Input, 15));
        }
        else {
            parametros.Add(new PaParams("@id_usuario", SqlDbType.VarChar, id_usuario, ParameterDirection.Input, 15));
        }
        Data = DbManagement.getDatos("dbo.pa_obt_grupos_proy", CommandType.StoredProcedure, cadTransparencia, parametros);
        return Data;
    }

    public static List<DataTable> obtInfoTecnicaProyecto(string codigo_bpin, int id_usuario)
    {
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, codigo_bpin, ParameterDirection.Input, 15));
        if (id_usuario <= 0)
        {
            parametros.Add(new PaParams("@id_usuario", SqlDbType.VarChar, System.DBNull.Value, ParameterDirection.Input, 15));
        }
        else
        {
            parametros.Add(new PaParams("@id_usuario", SqlDbType.VarChar, id_usuario, ParameterDirection.Input, 15));
        }
        Data = DbManagement.getDatos("dbo.pa_obt_infoTecnicaProy", CommandType.StoredProcedure, cadTransparencia, parametros);
        return Data;
    }

    /// <summary>
    /// Sirve para obtener información de los proyectos
    /// </summary>
    /// <param name="palabraClave">Es la palabra clave de la búsqueda</param>
    /// <param name="numPag">Número de página</param>
    /// <param name="TamanoPag">Tamaño de la página</param>
    /// <returns>Devuelve una tabla con todos los proyectos que cumplen la condición</returns>
    public static DataTable ObtInfoBuscarProyectos(string palabraClave, int numPag, int TamanoPag)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave, ParameterDirection.Input, 200));
      parametros.Add(new PaParams("@pagenum", SqlDbType.Int, numPag, ParameterDirection.Input));
      parametros.Add(new PaParams("@pagesize", SqlDbType.Int, TamanoPag, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_lista_proyectos", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    /// <summary>
    /// Sirve para traer los auditores que coincidan con la palabra clave
    /// </summary>
    /// <param name="palabraClave">Es la palabra a buscar</param>
    /// <returns>Una tabla con los resultados</returns>
    public static DataTable ObtInfoAuditoresProyectos(string palabraClave, int numPag, int TamanoPag)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave, ParameterDirection.Input, 200));
      parametros.Add(new PaParams("@pagenum", SqlDbType.Int, numPag, ParameterDirection.Input));
      parametros.Add(new PaParams("@pagesize", SqlDbType.Int, TamanoPag, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_buscador_auditores", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    /// <summary>
    /// Sirve para obtener el total de proyectos auditables
    /// </summary>
    /// <param name="palabraClave">Es la palabra clave de la búsqueda</param>
    /// <returns>El # de proyectos presentes</returns>
    public static DataTable ObtenerTotalProyectosAuditables(string palabraClave)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave.ToUpper(), ParameterDirection.Input, 200));
      return DbManagement.getDatosDataTable("dbo.pa_cont_proyectos", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    public static DataTable ObtenerTotalAuditoresXPalabraClave(string palabraClave)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave.ToUpper(), ParameterDirection.Input, 200));
      return DbManagement.getDatosDataTable("dbo.pa_cont_auditores", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

        public static List<DataTable> obtInfoContratoProy(string NumCtto)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@NumCtto", SqlDbType.VarChar, NumCtto, ParameterDirection.Input, 50));
            Data = DbManagement.getDatos("dbo.pa_obt_detalle_contrato", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

    /// <summary>
    /// Sirve para obtener el total de grupos auditorias ciudadanas
    /// </summary>
    /// <param name="palabraClave">Es la palabra clave de la búsqueda</param>
    /// <returns>El # de grupos de auditorias ciudadanas</returns>
    public static DataTable ObtenerTotalGruposAuditoriasCiudadanas(string palabraClave)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave.ToUpper(), ParameterDirection.Input, 200));
      return DbManagement.getDatosDataTable("dbo.pa_cont_gac", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para obtener información de los proyectos
    /// </summary>
    /// <param name="palabraClave">Es la palabra clave de la búsqueda</param>
    /// <param name="numPag">Número de página</param>
    /// <param name="TamanoPag">Tamaño de la página</param>
    /// <returns>Devuelve una tabla con todos los proyectos que cumplen la condición</returns>
    public static DataTable ObtInfoGac(string palabraClave, int numPag, int TamanoPag)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave, ParameterDirection.Input, 200));
      parametros.Add(new PaParams("@pagenum", SqlDbType.Int, numPag, ParameterDirection.Input));
      parametros.Add(new PaParams("@pagesize", SqlDbType.Int, TamanoPag, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_gac", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para modificar el estado de un grupo auditor
    /// </summary>
    /// <param name="parametrosModificar">Contiene los parámetros necesarios para hacer la modificación del registro</param>
    /// <returns>Devuelve una cadena de texto que indica si se realizó o no la actividad</returns>
    public static string ModificarEstadoMiembroGac(string[] parametrosModificar)
    {
      if (parametrosModificar.Length <= 1) return "-1"; //Significa que no se cuenta con los parámetros mínimos para modificar la bd
      var idMiembroGac = 0;
      var estado = 0;
      if (!int.TryParse(parametrosModificar[0], out idMiembroGac)) return "-2"; // Significa que el idMiembroGac enviado no es un entero
      if (!int.TryParse(parametrosModificar[1], out estado)) return "-3"; // Significa que el estado enviado no es un entero
      estado = estado == 0 ? 1 : 0;
      List<DataTable> Data = new List<DataTable>();
      List<PaParams> parametros = new List<PaParams>();
      string cod_error = string.Empty;
      string mensaje_error = string.Empty;
      parametros.Add(new PaParams("@idMiembroGac", SqlDbType.Int, idMiembroGac, ParameterDirection.Input));
      parametros.Add(new PaParams("@estado", SqlDbType.Int, estado, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output, 100));
      Data = DbManagement.getDatos("pa_upd_estadomiembrogac", CommandType.StoredProcedure, cadTransparencia, parametros);
      return cod_error + "<||>" + mensaje_error;
    }
    /// <summary>
    /// Sirve para modificar el estado de un grupo auditor
    /// </summary>
    /// <param name="parametrosModificar">Contiene los parámetros necesarios para hacer la modificación del registro</param>
    /// <returns>Devuelve una cadena de texto que indica si se realizó o no la actividad</returns>
    public static string ModificarEstadoGac(string[] parametrosModificar)
    {
      if (parametrosModificar.Length <= 1) return "-1"; //Significa que no se cuenta con los parámetros mínimos para modificar la bd
      var idGac = 0;
      var estado = 0;
      if (!int.TryParse(parametrosModificar[0], out idGac)) return "-2"; // Significa que el idMiembroGac enviado no es un entero
      if (!int.TryParse(parametrosModificar[1], out estado)) return "-3"; // Significa que el estado enviado no es un entero
      estado = estado == 0 ? 1 : 0;
      List<DataTable> Data = new List<DataTable>();
      List<PaParams> parametros = new List<PaParams>();
      string cod_error = string.Empty;
      string mensaje_error = string.Empty;
      parametros.Add(new PaParams("@idGac", SqlDbType.Int, idGac, ParameterDirection.Input));
      parametros.Add(new PaParams("@estado", SqlDbType.Int, estado, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output, 100));
      Data = DbManagement.getDatos("pa_upd_estadogac", CommandType.StoredProcedure, cadTransparencia, parametros);
      return cod_error + "<||>" + mensaje_error;
    }
  }
}