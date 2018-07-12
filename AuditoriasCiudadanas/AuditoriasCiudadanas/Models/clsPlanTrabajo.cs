using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace AuditoriasCiudadanas.Models
{
  static public class clsPlanTrabajo
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

    /// <summary>
    /// Sirve para eliminar una tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve un texto que indica si se hizo correctamente o no</returns>
    static public string EliminarRegistroMultimediaxUrl(string[] parametrosGuardar)
    {
      if (parametrosGuardar == null || parametrosGuardar.Length < 2) return "-1";//Significa que los parámetros no son correctos
      var url = parametrosGuardar[0];
      var idUsuario = 0;
      int.TryParse(parametrosGuardar[1], out idUsuario);
      if (idUsuario == 0) return "-2"; //Significa que los parámetros no son correctos
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
      parametros.Add(new PaParams("@url", SqlDbType.VarChar, url, ParameterDirection.Input, 1000));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      return DbManagement.EliminarDatos("dbo.pa_del_detalle_multimedia_tarea_url", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    /// <summary>
    /// Sirve para traer los planes de trabajo de todos los proyectos
    /// </summary>
    /// <param name="codigoBPIN">Es el código del proyecto</param>
    /// <param name="idUsuario">Es el id del usuario</param>
    /// <param name="idGac">Es el id del Gac</param>
    /// <returns>Todos los planes de trabajo que existan en la base de datos para ese proyecto y usuario</returns>
    static public DataTable GetPlanesTrabajo(string codigoBPIN, int idGac, int idUsuario)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@codigoBPIN", SqlDbType.VarChar, codigoBPIN, ParameterDirection.Input, 15));
      parametros.Add(new PaParams("@idGac", SqlDbType.VarChar, idGac, ParameterDirection.Input));
      parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_plan_trabajo", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    public static string EliminarDiarioNotas(int idDiarioNotas)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idDiarioNotas", SqlDbType.Int, idDiarioNotas, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      return DbManagement.EliminarDatos("dbo.pa_del_diarionotas", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    public static string GuardarDetalleTareaDiarioNotas(string datosGuardar)
    {
      try
      {
        var parametrosGuardar = datosGuardar.Split('*');
        if (parametrosGuardar == null || parametrosGuardar.Length < 4) return "-1";//Significa que los parámetros no son correctos
        var idDiarioNotas = 0;
        var idTarea = 0;
        var descripcion = string.Empty;
        var reflexion = string.Empty;
        var fechaTarea = DateTime.Now;
        if (!int.TryParse(parametrosGuardar[0].ToString(), out idTarea)) return "-2";//No se encontró un idTipoTarea para el nombre enviado
        if (!DateTime.TryParse(parametrosGuardar[3].ToString(), out fechaTarea)) return "-3";//El valor de la fecha no es válido
        if (!int.TryParse(parametrosGuardar[4].ToString(), out idDiarioNotas)) return "-4";//No se encontró un idDiarioNotas para el nombre enviado
        descripcion = parametrosGuardar[1].ToString();
        reflexion = parametrosGuardar[2].ToString();
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        if (idDiarioNotas == 0)
        {
          string procedimientoAlmacenado = "pa_ins_diarionotas_tarea";
          parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
          parametros.Add(new PaParams("@descripcion", SqlDbType.NVarChar, descripcion, ParameterDirection.Input, 1000));
          parametros.Add(new PaParams("@reflexion", SqlDbType.NVarChar, reflexion, ParameterDirection.Input, 1000));
          parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaTarea, ParameterDirection.Input));
          parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
          parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
          Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        }
        else
        {
          string procedimientoAlmacenado = "pa_upd_diarionotas_tarea";
          parametros.Add(new PaParams("@idDiarioNotas", SqlDbType.Int, idDiarioNotas, ParameterDirection.Input));
          parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
          parametros.Add(new PaParams("@descripcion", SqlDbType.NVarChar, descripcion, ParameterDirection.Input, 1000));
          parametros.Add(new PaParams("@reflexion", SqlDbType.NVarChar, reflexion, ParameterDirection.Input, 1000));
          parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaTarea, ParameterDirection.Input));
          parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
          parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
          Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        }
        return cod_error + "<||>" + mensaje_error;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public static string ValidarUsuarioMiembroGac(string parametrosConsulta)
    {
      try
      {
        var parametrosConsultar = parametrosConsulta.Split('*');
        if (parametrosConsultar == null || parametrosConsultar.Length < 2) return "-1";//Significa que los parámetros no son correctos
        var idUsuario = 0;
        var idGac = 0;
        if (!int.TryParse(parametrosConsultar[0].ToString(), out idUsuario)) return "-2";//No se encontró un idUsuario para el nombre enviado
        if (!int.TryParse(parametrosConsultar[1].ToString(), out idGac)) return "-3";//No se encontró un idGac para el nombre enviado
        var data = new DataTable();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_obt_miembrosgac_idusuario";
        parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@idGac", SqlDbType.Int, idGac, ParameterDirection.Input));
        data = DbManagement.getDatosDataTable(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        return data.Rows.Count > 0?  "true": "false";
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    /// <summary>
    /// Sirve para obtener los tipos de tarea
    /// </summary>
    /// <returns>Devuelve los tipos de tarea</returns>
    public static DataTable GetTiposTareas()
    {
      return DbManagement.getDatosDataTable("dbo.pa_obt_tipos_tarea", CommandType.StoredProcedure, cadTransparencia, new List<PaParams>());
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="idTarea"></param>
    /// <returns></returns>
    public static DataTable ObtenerDetalleTareaDiarioNotas(int idTarea)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_diarionotastarea", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    public static DataTable ObtenerCompromisosActasReuniones(int idTarea)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_compromisosactareuniones", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    public static DataTable BuscarInformacionVisitaCampo(int idTarea)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_infovisitacampo", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idTarea"></param>
    /// <returns></returns>
    public static string EliminarTareaRegistroFotografico(int idTarea)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      return DbManagement.EliminarDatos("dbo.pa_del_registrofotograficotarea", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idTarea"></param>
    /// <returns></returns>
    public static string EliminarDiarioNotasTarea(int idTarea)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      return DbManagement.EliminarDatos("dbo.pa_del_diarionotastarea", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="parametos"></param>
    /// <returns></returns>
    public static string GuardarActividadesVisitaCampoTarea(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length < 1) return "-1";//Significa que los parámetros no son correctos
        var idTarea = 0;
        var actividadesVisitaCampo = string.Empty;
        if (!int.TryParse(parametrosGuardar[0].ToString(), out idTarea)) return "-2";//No se encontró un idTipoTarea para el nombre enviado
        if (parametrosGuardar[1] != null) actividadesVisitaCampo = parametrosGuardar[1];
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_upd_actividadesvisitacampotareas";
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@actividadesVisitaCampo", SqlDbType.NVarChar, actividadesVisitaCampo, ParameterDirection.Input, 1000));
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

    public static string GuardarFuncionarioPublicoAcompanaVisitaTarea(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length < 1) return "-1";//Significa que los parámetros no son correctos
        var idTarea = 0;
        var funcionarioAcompanaVisita = string.Empty;
        if (!int.TryParse(parametrosGuardar[0].ToString(), out idTarea)) return "-2";//No se encontró un idTipoTarea para el nombre enviado
        if (parametrosGuardar[1] != null) funcionarioAcompanaVisita = parametrosGuardar[1]; 
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_upd_funcionarioAcompanatareas";
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@funcionarioAcompanaVisita", SqlDbType.NVarChar, funcionarioAcompanaVisita, ParameterDirection.Input, 1000));
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
    /// 
    /// </summary>
    /// <param name="idTarea"></param>
    /// <param name="idTipoAdjunto"></param>
    /// <param name="rutaRecurso"></param>
    /// <returns></returns>
    public static string ObtenerListaAsistenciaActasReuniones(int idTarea, int idTipoAdjunto ,string rutaRecurso)
    {
      string rta = string.Empty;
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      parametros.Add(new PaParams("@idTipoAdjunto", SqlDbType.Int, idTipoAdjunto, ParameterDirection.Input));
      var dtRta= DbManagement.getDatosDataTable("dbo.pa_obt_rutasadjuntotarea", CommandType.StoredProcedure, cadTransparencia, parametros);
      for(int j=0; j<dtRta.Rows.Count;j++)
        rta= j==0 ? rutaRecurso + "/" + dtRta.Rows[j].ItemArray[0].ToString(): rta + "*_*" + rutaRecurso + "/" + dtRta.Rows[j].ItemArray[0].ToString();
      //"../.." + rutaRecurso + "/" + dtRta.Rows[j].ItemArray[0].ToString(): rta + "*_*" + "../.." + rutaRecurso + "/" + dtRta.Rows[j].ItemArray[0].ToString();
      return rta;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="datosGuardar"></param>
    /// <returns></returns>
    public static string GuardarCompromisoActaReunionTarea(string datosGuardar)
    {
      try
      {
        var parametrosGuardar = datosGuardar.Split('*');
        if (parametrosGuardar == null || parametrosGuardar.Length < 4) return "-1";//Significa que los parámetros no son correctos
        var idTarea = 0;
        var nombre = string.Empty;
        var responsable = string.Empty;
        var fechaTarea = DateTime.Now;
        var idCompromisoTarea = 0;
        if (!int.TryParse(parametrosGuardar[0].ToString(), out idTarea)) return "-2";//No se encontró un idTipoTarea para el nombre enviado
        if (!DateTime.TryParse(parametrosGuardar[3].ToString(), out fechaTarea)) return "-3";//El valor de la fecha no es válido
        if (!int.TryParse(parametrosGuardar[4].ToString(), out idCompromisoTarea)) return "-4";//No se encontró un idTipoTarea para el nombre enviado
        nombre = parametrosGuardar[1].ToString();
        responsable = parametrosGuardar[2].ToString();
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        if (idCompromisoTarea == 0)
        {
          string procedimientoAlmacenado = "pa_ins_compromisos_actareunion_tarea";
          parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
          parametros.Add(new PaParams("@nombre", SqlDbType.NVarChar, nombre, ParameterDirection.Input, 200));
          parametros.Add(new PaParams("@responsable", SqlDbType.NVarChar, responsable, ParameterDirection.Input, 200));
          parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaTarea, ParameterDirection.Input));
          parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
          parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
          Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        }
        else {
          string procedimientoAlmacenado = "pa_upd_compromisos_actareunion_tarea";
          parametros.Add(new PaParams("@idCompromisoTarea", SqlDbType.Int, idCompromisoTarea, ParameterDirection.Input));
          parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
          parametros.Add(new PaParams("@nombre", SqlDbType.NVarChar, nombre, ParameterDirection.Input, 200));
          parametros.Add(new PaParams("@responsable", SqlDbType.NVarChar, responsable, ParameterDirection.Input, 200));
          parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaTarea, ParameterDirection.Input));
          parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
          parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
          Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        }
        return cod_error + "<||>" + mensaje_error;

      }
      catch (Exception ex)
      {
        return ex.Message;
      }

    }
    /// <summary>
    /// Devuelve la información el detalle de un acta de reuniones de una tarea
    /// </summary>
    /// <param name="idTareadtar">Es el id de la tarea</param>
    /// <returns>Devuelve una tabla de datos con los detalles de las actas de reuniones</returns>
    public static DataTable ObtenerTemasTratarActasReuniones(int idTareadtar)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTareadtar, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_temastratar_acta_reuniones", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    public static string GuardarTemasActasReuniones(int idTareActaReunion, string temas)
    {
      try
      {
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_upd_temastareas";
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTareActaReunion, ParameterDirection.Input));
        parametros.Add(new PaParams("@temas", SqlDbType.NVarChar, temas, ParameterDirection.Input, 1000));
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
    /// Sirve para obtener la información relacionada a los recursos disponibles en la tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve un texto con la información asociada a los recursos de la tarea</returns>
    public static DataTable ObtenerRecursosTarea(int idTarea)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_recursos_tarea", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    public static DataTable ObtenerRecursosFotografico(int idTarea, string rutaRecurso)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      DataTable dtRta = new DataTable();
      dtRta.Columns.Add("url");
      dtRta.Columns.Add("fechaCreacion");
      dtRta.Columns.Add("descripcion");
      dtRta.Columns.Add("responsable");
      dtRta.Columns.Add("lugar");
      dtRta.Columns.Add("estado");
      dtRta.Columns.Add("idAdjuntoTarea");
      DataTable dtDatos= DbManagement.getDatosDataTable("dbo.pa_obt_recursos_tarea", CommandType.StoredProcedure, cadTransparencia, parametros);
      foreach (DataRow drFila in dtDatos.Rows)
      {
        DataRow nuevaFila = dtRta.NewRow();
        nuevaFila[0] = "../.." + rutaRecurso + "/" + drFila.ItemArray[0];
        nuevaFila[1] = drFila.ItemArray[1];
        nuevaFila[2] = drFila.ItemArray[2];
        nuevaFila[3] = drFila.ItemArray[3];
        nuevaFila[4] = drFila.ItemArray[4];
        nuevaFila[5] = drFila.ItemArray[5];
        nuevaFila[6] = drFila.ItemArray[6];
        dtRta.Rows.Add(nuevaFila);
      }
      return dtRta;
    }
    /// <summary>
    /// Sirve para obtener el nombre de los miembros del grupo auditor que hace parte del proyecto
    /// </summary>
    /// <param name="idGac">Es el código del proyecto</param>
    /// <returns>Devulve el nombre de los miembros del GAC</returns>
    public static DataTable GetMiembrosGac(int idGac)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idGac", SqlDbType.Int, idGac, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_usuarios_gac_idgac", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    public static string VerificarRelacionProyectoAudiencia(string codigoBpin, string tipoAudiencia)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, codigoBpin, ParameterDirection.Input, 15));
      parametros.Add(new PaParams("@TipoAudiencia", SqlDbType.NVarChar, tipoAudiencia, ParameterDirection.Input, 100));
      var dtSalida= DbManagement.getDatosDataTable("dbo.pa_obt_idaudiencia_codigobpin_tipoaudiencia", CommandType.StoredProcedure, cadTransparencia, parametros);
      if (dtSalida.Rows.Count > 0 && dtSalida.Columns.Count>0 && dtSalida.Rows[0].ItemArray[0] != null) return dtSalida.Rows[0].ItemArray[0].ToString();
      else return string.Empty;
    }
    /// <summary>
    /// Sirve para verificar si un usuario pertenece al Gac
    /// </summary>
    /// <param name="parametrosConsulta">Son los parámetros necesarios para la consulta</param>
    /// <returns>Devuelve una cadena de texto que indica si el usuario pertenece o no al GAC</returns>
    public static string VerificarUsuarioGac(string[] parametos)
    {
      try
      {
        if (parametos == null || parametos.Length < 2) return "-1";//Significa que los parámetros no son correctos
        var idUsuario = 0;
        var codigoBpin = "";
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, codigoBpin, ParameterDirection.Input, 15));
        parametros.Add(new PaParams("@IdUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
        var dtSalida = DbManagement.getDatosDataTable("dbo.pa_obt_idaudiencia_codigobpin_tipoaudiencia", CommandType.StoredProcedure, cadTransparencia, parametros);
        if (dtSalida.Rows.Count > 0 && dtSalida.Columns.Count > 0 && dtSalida.Rows[0].ItemArray[0] != null) return dtSalida.Rows[0].ItemArray[0].ToString();
        else return string.Empty;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
      
    }
    /// <summary>
    /// Sirve para guardar los datos básicos de una tarea
    /// </summary>
    /// <param name="parametos">Son algunos de los parámetros necesarios para crear un registro de tarea</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public static string GuardarTarea(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length < 5) return "-2";//Significa que los parámetros no son correctos
        var idTipoTarea = 0;
        var detalle = string.Empty;
        var idUsuario = 0;
        var fechaTarea = DateTime.Now;
        var codigoBPIN = string.Empty;
        var estado = 0;
        detalle = parametrosGuardar[0];
        if (!int.TryParse(parametrosGuardar[1].ToString(), out idTipoTarea)) return "-3";//No se encontró un idTipoTarea para el nombre enviado
        if (!DateTime.TryParse(parametrosGuardar[2].ToString(), out fechaTarea)) return "-4";//El valor de la fecha no es válido
        codigoBPIN = parametrosGuardar[3].ToString();
        if (!int.TryParse(parametrosGuardar[4].ToString(), out idUsuario)) return "-5";//El valor del idUsuario no es un número
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_ins_tareas";
        parametros.Add(new PaParams("@idTipoTarea", SqlDbType.Int, idTipoTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@detalle", SqlDbType.NVarChar, detalle, ParameterDirection.Input, 1000));
        parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@codigoBPIN", SqlDbType.VarChar, codigoBPIN, ParameterDirection.Input,15));
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
    /// <summary>
    /// Sirve para consultar el detalle de una tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve una lista con el detalle de cada tarea</returns>
    static public DataTable ObtenerDetalleTarea(int idTarea)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_detalle_tarea", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para actualizar el resultado de una tarea
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros empleados en la actualización del registro</param>
    /// <returns>Devuelve un texto que indica si se hizo o no el proceso<</returns>
    public static string ActualizarResultadoTarea(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length <= 2) return "-2";//Significa que los parámetros no son correctos
        var idTarea = 0;
        var fechaDescripcionTarea = DateTime.Now;
        if (!int.TryParse(parametrosGuardar[0].ToString(), out idTarea)) return "-3";//El valor del idTarea no es un número
        if (!DateTime.TryParse(parametrosGuardar[1].ToString(), out fechaDescripcionTarea)) return "-4";//El valor del idTarea no es un número
        var descripcion = parametrosGuardar[2].ToString() != string.Empty ? parametrosGuardar[2].ToString() : string.Empty;
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_upd_temastareas";
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@fechaResultadoTarea", SqlDbType.DateTime, fechaDescripcionTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@resultadoTarea", SqlDbType.NVarChar, descripcion, ParameterDirection.Input, 1000));
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
    /// Sirve para ingresar un registro multimedia
    /// </summary>
    /// <param name="parametos">Son los parámetros correspondientes al adjunto de la tarea</param>
    /// <returns>Devuelve un texto que indica si se hizo o no el proceso</returns>
    public static string IngresarRegistroMultimedia(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length <= 7) return "-2";//Significa que los parámetros no son correctos
        var idTarea = 0;
        var idTipoAdjunto = 0;
        var idUsuario = 0;
        var idMiembroGac = 0;
        var fechaRecursoTarea = DateTime.Now;
        if (!int.TryParse(parametrosGuardar[0].ToString(), out idTarea)) return "-3";//El valor del idTarea no es un número
        if (!int.TryParse(parametrosGuardar[1].ToString(), out idTipoAdjunto)) return "-4";//El valor del idTipoAdjunto no es un número
        if (!DateTime.TryParse(parametrosGuardar[2].ToString(), out fechaRecursoTarea)) return "-5";//El valor de la fecha Recurso no es un datetime
        var url = string.Empty;
        if (parametrosGuardar[3] != null) url = parametrosGuardar[3].ToString();
        else return "-5"; 
        var descripcion = parametrosGuardar[4].ToString() != string.Empty ? parametrosGuardar[4].ToString() : string.Empty;
        var responsable= parametrosGuardar[5].ToString() != string.Empty ? parametrosGuardar[5].ToString() : string.Empty;
        var lugar = parametrosGuardar[6].ToString() != string.Empty ? parametrosGuardar[6].ToString() : string.Empty;
        if (!int.TryParse(parametrosGuardar[7].ToString(), out idUsuario)) return "-7";//El valor del idUsuario no es un número
        idMiembroGac = ObtenerIdMiembroGac(idUsuario,idTarea);
        if (idMiembroGac < 0) return idMiembroGac.ToString();
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_ins_recurso_tarea";
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@idTipoAdjunto", SqlDbType.Int, idTipoAdjunto, ParameterDirection.Input));
        parametros.Add(new PaParams("@url", SqlDbType.NVarChar, url, ParameterDirection.Input,1000));
        parametros.Add(new PaParams("@fechaCreacion", SqlDbType.DateTime, fechaRecursoTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@descripcion", SqlDbType.NVarChar, descripcion, ParameterDirection.Input, 1000));
        parametros.Add(new PaParams("@responsable", SqlDbType.NVarChar, responsable, ParameterDirection.Input, 100));
        parametros.Add(new PaParams("@lugar", SqlDbType.NVarChar, lugar, ParameterDirection.Input, 200));
        parametros.Add(new PaParams("@idMiembroGac", SqlDbType.Int, idMiembroGac, ParameterDirection.Input));
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

    private static int ObtenerIdMiembroGac(int idUsuario, int idTarea)
    {
      try
      {
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
        DataTable dtSalida = DbManagement.getDatosDataTable("dbo.pa_obt_idmiembrogac_idUsuarioIdTarea", CommandType.StoredProcedure, cadTransparencia, parametros);
        if (dtSalida.Rows.Count > 0 && dtSalida.Columns.Count > 0 && dtSalida.Rows[0].ItemArray[0] != null && dtSalida.Rows[0].ItemArray[0].ToString() != string.Empty)
          return Convert.ToInt32(dtSalida.Rows[0].ItemArray[0]);
        else return -9; // Significa que no existe una relación entre idUsuario y miembro gac
      }
      catch (Exception)
      {
        return -8; //Significa hubo un error en la consulta a la base de datos
      }
    }

    /// <summary>
    /// Sirve para finalizar una tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve un texto que indica si se hizo o no el proceso</returns>
    static public string FinalizarTarea(string parametrosGuardar)
    {
      try
      {
        var idTarea = 0;
        if (!int.TryParse(parametrosGuardar, out idTarea)) return "-3";//El valor del idTarea no es un número
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_upd_finalizar_tarea";
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@fechaCierreTarea", SqlDbType.DateTime, DateTime.Now, ParameterDirection.Input));
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
    /// Sirve para eliminar una tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve un texto que indica si se hizo correctamente o no</returns>
    static public string EliminarTarea(int idTarea)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      return DbManagement.EliminarDatos("dbo.pa_del_tarea", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para eliminar un compromiso del acta de reunión
    /// </summary>
    /// <param name="idCompromisoActaReunion">Es el id del compromiso</param>
    /// <returns>Devuelve un texto que indica si se hizo correctamente o no</returns>
    static public string EliminarCompromisoActaReunionesTarea(int idCompromisoActaReunion)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idCompromisoActaReunion", SqlDbType.Int, idCompromisoActaReunion, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      return DbManagement.EliminarDatos("dbo.pa_del_compromisoactareuniontarea", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para actualizar la descripción de una tarea. La opción de ingresar no aplica porque se debe conocer el id de la tarea para hacer las operaciones
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros que se utilizarán para guardar los datos</param>
    /// <returns>Una string el cual indica si la operación fue correcta o no</returns>
    static public string ActualizarDescripcionTarea(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length <= 2) return "-2";//Significa que los parámetros no son correctos
        var idTarea = 0;
        var fechaDescripcionTarea = DateTime.Now;
        if (!int.TryParse(parametrosGuardar[0].ToString(), out idTarea)) return "-3";//El valor del idTarea no es un número
        if (!DateTime.TryParse(parametrosGuardar[1].ToString(), out fechaDescripcionTarea)) return "-4";//El valor del idTarea no es un número
        var descripcion = parametrosGuardar[2].ToString() != string.Empty ? parametrosGuardar[2].ToString() : string.Empty;
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_upd_detalle_tarea";
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@fechaDescripcionTarea", SqlDbType.DateTime, fechaDescripcionTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@descripcionTarea", SqlDbType.NVarChar, descripcion, ParameterDirection.Input, 1000));
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