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

    public static List<DataTable> obtInfoProyecto(string id_proyecto)
    {
      List<DataTable> Data = new List<DataTable>();
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, id_proyecto, ParameterDirection.Input, 15));
      Data = DbManagement.getDatos("dbo.pa_obt_proyecto", CommandType.StoredProcedure, cadTransparencia, parametros);
      return Data;
    }
    public static List<DataTable> addInfoTecnica(string bpin_proy, string titulo, string descripcion, string[] adjuntos, int id_usuario)
    {
      DateTime fecha_cre = DateTime.Now;
      string ruta_doc = adjuntos[0];
      string ruta_img = adjuntos[1];
      List<DataTable> Data = new List<DataTable>();
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, bpin_proy, ParameterDirection.Input, 15));
      parametros.Add(new PaParams("@fechaCreacion", SqlDbType.DateTime, fecha_cre, ParameterDirection.Input));
      parametros.Add(new PaParams("@titulo", SqlDbType.VarChar, titulo, ParameterDirection.Input, 500));
      parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, descripcion, ParameterDirection.Input, 4000));
      parametros.Add(new PaParams("@ruta_arch", SqlDbType.VarChar, ruta_doc, ParameterDirection.Input, 100));
      parametros.Add(new PaParams("@UrlFoto", SqlDbType.VarChar, ruta_img, ParameterDirection.Input, 100));
      Data = DbManagement.getDatos("dbo.pa_ins_info_tecnica", CommandType.StoredProcedure, cadTransparencia, parametros);
      return Data;
    }
    public static List<DataTable> obtInfoTecnica(int id_info)
    {
      List<DataTable> Data = new List<DataTable>();
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@id_info_tecnica", SqlDbType.Int, id_info, ParameterDirection.Input));
      Data = DbManagement.getDatos("dbo.pa_obt_info_tecnica", CommandType.StoredProcedure, cadTransparencia, parametros);
      return Data;
    }
    public static List<DataTable> ModifInfoTecnica(int id_info, string titulo, string descripcion, string[] adjuntos, int id_usuario)
    {
      DateTime fecha_modif = DateTime.Now;
      string ruta_doc = adjuntos[0];
      string ruta_img = adjuntos[1];
      List<DataTable> Data = new List<DataTable>();
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@id_info", SqlDbType.Int, id_info, ParameterDirection.Input));
      parametros.Add(new PaParams("@fechaModif", SqlDbType.DateTime, fecha_modif, ParameterDirection.Input));
      parametros.Add(new PaParams("@titulo", SqlDbType.VarChar, titulo, ParameterDirection.Input, 500));
      parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, descripcion, ParameterDirection.Input, 4000));
      parametros.Add(new PaParams("@ruta_arch", SqlDbType.VarChar, ruta_doc, ParameterDirection.Input, 100));
      parametros.Add(new PaParams("@UrlFoto", SqlDbType.VarChar, ruta_img, ParameterDirection.Input, 100));
      Data = DbManagement.getDatos("dbo.pa_modif_info_tecnica", CommandType.StoredProcedure, cadTransparencia, parametros);
      return Data;
    }

    /// <summary>
    /// Sirve para traer los proyectos que coincidan con la palabra clave
    /// </summary>
    /// <param name="palabraClave">Es la palabra a buscar</param>
    /// <returns>Una tabla con los resultados</returns>
    public static DataTable ObtInfoBuscarProyectos(string palabraClave)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave, ParameterDirection.Input, 200));
      return DbManagement.getDatosDataTable("dbo.pa_obt_lista_proyectos", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    /// <summary>
    /// Sirve para traer los auditores que coincidan con la palabra clave
    /// </summary>
    /// <param name="palabraClave">Es la palabra a buscar</param>
    /// <returns>Una tabla con los resultados</returns>
    public static DataTable ObtInfoAuditoresProyectos(string palabraClave)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@palabraClave", SqlDbType.VarChar, palabraClave, ParameterDirection.Input, 200));
      return DbManagement.getDatosDataTable("dbo.pa_obt_lista_auditores", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

  }
}