using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace AuditoriasCiudadanas.Models
{
  static public class clsCaracterizacionModels
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    static public DataTable GetMunicipiosDepartamento()
    {
      return DbManagement.getDatosDataTable("dbo.pa_listar_depmun", CommandType.StoredProcedure, cadTransparencia, new List<PaParams>());
    }

    /// <summary>
    /// Sirve para obtener las encuestas realizadas en cada fecha de corte
    /// </summary>
    /// <returns></returns>
    static public DataTable ObtenerFechaCorteReporteCaracterizacion(string fechasCorte)
    {
      DataTable rta = null;
      try
      {
        var fechasConsultar = fechasCorte.Split('*');
        if (fechasConsultar.Length >= 2)
        {
          var fechaInicio = DateTime.Now;
          var fechaFin = DateTime.Now;
          if (!DateTime.TryParse(fechasConsultar[0], out fechaInicio)) return null;
          if (!DateTime.TryParse(fechasConsultar[1], out fechaFin)) return null;
          rta = new DataTable();
          rta.Columns.Add("FechaInicio", typeof(string));
          rta.Columns.Add("FechaFin", typeof(string));
          rta.Columns.Add("Total", typeof(int));
          var parametros = new List<PaParams>();
          parametros.Add(new PaParams("@FechaInicio", SqlDbType.DateTime, fechaInicio, ParameterDirection.Input));
          parametros.Add(new PaParams("@FechaFin", SqlDbType.DateTime, fechaFin, ParameterDirection.Input));
          DataTable dtEncuestasRealizadas = DbManagement.getDatosDataTable("dbo.pa_obt_totalencuestasxfechascorte", CommandType.StoredProcedure, cadTransparencia, parametros);
          DataRow drFilaIngresar = rta.NewRow();
          drFilaIngresar[0] = fechaInicio.ToShortDateString();
          drFilaIngresar[1] = fechaFin.ToShortDateString();
          drFilaIngresar[2] = 0;
          if (dtEncuestasRealizadas.Rows.Count > 0)
            drFilaIngresar[2] = Convert.ToInt32(dtEncuestasRealizadas.Rows[0].ItemArray[0]);
          rta.Rows.Add(drFilaIngresar);
        }
        //DataTable dtFechaCorte = DbManagement.getDatosDataTable("dbo.pa_obt_fechascorteencuesta", CommandType.StoredProcedure, cadTransparencia, new List<PaParams>());
        //if (dtFechaCorte != null && dtFechaCorte.Rows.Count > 0)
        //{
        //  rta = new DataTable();
        //  rta.Columns.Add("FechaInicio", typeof(string));
        //  rta.Columns.Add("FechaFin", typeof(string));
        //  rta.Columns.Add("Total", typeof(int));
        //  foreach (DataRow drfila in dtFechaCorte.Rows)
        //  {
        //    var fechaInicio = DateTime.Now;
        //    var fechaFin = DateTime.Now;
        //    if (!DateTime.TryParse(drfila.ItemArray[0].ToString(), out fechaInicio)) return null;
        //    if (!DateTime.TryParse(drfila.ItemArray[1].ToString(), out fechaFin)) return null;
        //    var parametros = new List<PaParams>();
        //    parametros.Add(new PaParams("@FechaInicio", SqlDbType.DateTime, fechaInicio, ParameterDirection.Input));
        //    parametros.Add(new PaParams("@FechaFin", SqlDbType.DateTime, fechaFin, ParameterDirection.Input));
        //    DataTable dtEncuestasRealizadas = DbManagement.getDatosDataTable("dbo.pa_obt_totalencuestasxfechascorte", CommandType.StoredProcedure, cadTransparencia, parametros);
        //    DataRow drFilaIngresar = rta.NewRow();
        //    drFilaIngresar[0] = fechaInicio.ToShortDateString();
        //    drFilaIngresar[1] = fechaFin.ToShortDateString();
        //    drFilaIngresar[2] = 0;
        //    if (dtEncuestasRealizadas.Rows.Count > 0)
        //      drFilaIngresar[2] = Convert.ToInt32(dtEncuestasRealizadas.Rows[0].ItemArray[0]);
        //    rta.Rows.Add(drFilaIngresar);
        //  }
        //}
      }
      catch (Exception)
      {
        rta = null;
      }
      return rta;
    }

    static private int ObtenerIdDivipola(string municipioDepartamento)
    {
      var entidadesTerritoriales = municipioDepartamento.Split('-');
      if (entidadesTerritoriales.Length < 2) return -1;//Significa que no existen los datos de entrada (Municipio y Departamento)
      var parametros = new List<PaParams>();
      parametros.Add(new PaParams("@nombreCiudad", SqlDbType.VarChar, entidadesTerritoriales[0].Trim(), ParameterDirection.Input, 100));
      parametros.Add(new PaParams("@nombreDepto", SqlDbType.VarChar, entidadesTerritoriales[1].Trim(), ParameterDirection.Input, 100));
      var dtIdDivipola = DbManagement.getDatosDataTable("dbo.pa_obt_divipolaid", CommandType.StoredProcedure, cadTransparencia, parametros);
      if (dtIdDivipola != null && dtIdDivipola.Rows.Count > 0)
      {
        int rta = 0;
        return int.TryParse(dtIdDivipola.Rows[0].ItemArray[0].ToString(), out rta) ? rta : -2;//Significa que el valor que trajo no es entero
      }
      else return 0;//Significa que no hubo datos
    }

    /// <summary>
    /// Sirve para consultar la información registrada por un usuario
    /// </summary>
    /// <param name="pagina">Es la página de la encuesta a consultar</param>
    /// <param name="usuarioId">Es el id del usuario</param>
    /// <returns>Devuelve una tabla con los datos solicitados</returns>
    public static DataTable ObtenerDatosEncuestaUsuario(int pagina, int usuarioId)
    {
      List<PaParams> parametros = new List<PaParams>();
      switch (pagina)
      {
        case 1:
          parametros.Add(new PaParams("@IdUsuario", SqlDbType.Int, usuarioId, ParameterDirection.Input));
          return DbManagement.getDatosDataTable("dbo.pa_obt_idfoencuestapart1_idUsu", CommandType.StoredProcedure, cadTransparencia, parametros);
        case 2:
          parametros.Add(new PaParams("@IdUsuario", SqlDbType.Int, usuarioId, ParameterDirection.Input));
          //parametros.Add(new PaParams("@NombreMunicipio", SqlDbType.VarChar, nombreMunicipio, ParameterDirection.Input,100));
          return DbManagement.getDatosDataTable("dbo.pa_obt_idfoencuestapart2_idUsu", CommandType.StoredProcedure, cadTransparencia, parametros);
        case 3:
          parametros.Add(new PaParams("@IdUsuario", SqlDbType.Int, usuarioId, ParameterDirection.Input));
          //parametros.Add(new PaParams("@NombreMunicipio", SqlDbType.VarChar, nombreMunicipio, ParameterDirection.Input, 100));
          return DbManagement.getDatosDataTable("dbo.pa_obt_idfoencuestapart3_idUsu", CommandType.StoredProcedure, cadTransparencia, parametros);
        case 4:
          parametros.Add(new PaParams("@IdUsuario", SqlDbType.Int, usuarioId, ParameterDirection.Input));
          //parametros.Add(new PaParams("@NombreMunicipio", SqlDbType.VarChar, nombreMunicipio, ParameterDirection.Input, 100));
          return DbManagement.getDatosDataTable("dbo.pa_obt_idfoencuestapart4_idUsu", CommandType.StoredProcedure, cadTransparencia, parametros);
      }
      return null;
    }

    /// <summary>
    /// Sirve para guardar los datos de la encuesta
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros de la encuesta</param>
    /// <returns>Devuelve un texto indicando si hubo o no errores al guardar la encuesta</returns>
    static public string IngresarEncuesta(int pagina, params object[] parametrosGuardar)
    {
      string cod_error = string.Empty;
      string mensaje_error = string.Empty;
      List<DataTable> Data = new List<DataTable>();
      List<PaParams> parametros = new List<PaParams>();
      int idEncuestaCaracterizacion = 0;
      //var idDivipola = 0;
      var idUsuario = 0;
      switch (pagina)
      {
        case 1:
          #region Guardo los datos de la parte 1 de la encuesta
          if (parametrosGuardar == null || parametrosGuardar.Length <= 6) return "-1";//Significa que los parámetros no son correctos
          //idDivipola = ObtenerIdDivipola(parametrosGuardar[0].ToString());
          //if (idDivipola <= 0) return "-2";//Significa que el municipio no existe en la base de datos
          if (!int.TryParse(parametrosGuardar[6].ToString(), out idUsuario)) return "-3";
          idEncuestaCaracterizacion = ObtenerIdEncuestaCaracterizacion(idUsuario);
          if (idEncuestaCaracterizacion == 0)
          {
            parametros.Add(new PaParams("@IdUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
            //parametros.Add(new PaParams("@idDivipola", SqlDbType.VarChar, idDivipola.ToString(), ParameterDirection.Input, 15));
            parametros.Add(new PaParams("@Fecha", SqlDbType.DateTime, DateTime.Now, ParameterDirection.Input));
            parametros.Add(new PaParams("@Genero", SqlDbType.VarChar, parametrosGuardar[0].ToString(), ParameterDirection.Input, 50));
            parametros.Add(new PaParams("@RangoEdad", SqlDbType.VarChar, parametrosGuardar[1].ToString(), ParameterDirection.Input, 20));
            parametros.Add(new PaParams("@Ocupacion", SqlDbType.VarChar, parametrosGuardar[2].ToString(), ParameterDirection.Input, 200));
            //parametros.Add(new PaParams("@Cargo", SqlDbType.VarChar, parametrosGuardar[4].ToString(), ParameterDirection.Input, 50));
            parametros.Add(new PaParams("@LugarResidencia", SqlDbType.VarChar, parametrosGuardar[3].ToString(), ParameterDirection.Input, 50));
            parametros.Add(new PaParams("@PerteneceMinoria", SqlDbType.VarChar, parametrosGuardar[4].ToString(), ParameterDirection.Input, 2));
            parametros.Add(new PaParams("@PerteneceOrganizacionSocial", SqlDbType.VarChar, parametrosGuardar[5].ToString(), ParameterDirection.Input, 2));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_encaracterizacion", CommandType.StoredProcedure, cadTransparencia, parametros);
            return cod_error + "<||>" + mensaje_error;
          }
          else
          {
            parametros.Add(new PaParams("@IdEncuestaCaracterizacion", SqlDbType.Int, idEncuestaCaracterizacion, ParameterDirection.Input));
            parametros.Add(new PaParams("@Fecha", SqlDbType.DateTime, DateTime.Now, ParameterDirection.Input));
            parametros.Add(new PaParams("@Genero", SqlDbType.VarChar, parametrosGuardar[0].ToString(), ParameterDirection.Input, 50));
            parametros.Add(new PaParams("@RangoEdad", SqlDbType.VarChar, parametrosGuardar[1].ToString(), ParameterDirection.Input, 20));
            parametros.Add(new PaParams("@Ocupacion", SqlDbType.VarChar, parametrosGuardar[2].ToString(), ParameterDirection.Input, 200));
            //parametros.Add(new PaParams("@Cargo", SqlDbType.VarChar, parametrosGuardar[4].ToString(), ParameterDirection.Input, 50));
            parametros.Add(new PaParams("@LugarResidencia", SqlDbType.VarChar, parametrosGuardar[3].ToString(), ParameterDirection.Input, 50));
            parametros.Add(new PaParams("@PerteneceMinoria", SqlDbType.VarChar, parametrosGuardar[4].ToString(), ParameterDirection.Input, 2));
            parametros.Add(new PaParams("@PerteneceOrganizacionSocial", SqlDbType.VarChar, parametrosGuardar[5].ToString(), ParameterDirection.Input, 2));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("pa_upd_encaracterparte1", CommandType.StoredProcedure, cadTransparencia, parametros);
            return cod_error + "<||>" + mensaje_error;
          }
        #endregion Guardo los datos de la parte 1 de la encuesta
        case 2:
          #region Guardo los datos de la parte 2 de la encuesta
          if (parametrosGuardar == null || parametrosGuardar.Length <= 8) return "-1";//Significa que los parámetros no son correctos
          //var vinculacionActual = parametrosGuardar[1].ToString() != string.Empty ? parametrosGuardar[1].ToString() : parametrosGuardar[0].ToString();
          var mecanismoHaParticipado = parametrosGuardar[1].ToString() != string.Empty ? parametrosGuardar[1].ToString() : parametrosGuardar[0].ToString();
          //var espaciosParticipadoCiudadano = parametrosGuardar[5].ToString() != string.Empty ? parametrosGuardar[5].ToString() : parametrosGuardar[4].ToString();
          var recursosAlcaldia = parametrosGuardar[2].ToString();
          var auditoriasVisibles= parametrosGuardar[3].ToString();
          var gestionAutoridades = parametrosGuardar[4].ToString();
          var planAccion = parametrosGuardar[5].ToString();
          var estrategiaSeguimiento = parametrosGuardar[7].ToString() != string.Empty ? parametrosGuardar[7].ToString() : parametrosGuardar[6].ToString();
          //var participacionAnterior = parametrosGuardar[9].ToString() != string.Empty ? parametrosGuardar[9].ToString() : parametrosGuardar[8].ToString();
          //var capacitacionesEntidades = parametrosGuardar[11].ToString() != string.Empty ? parametrosGuardar[11].ToString() : parametrosGuardar[10].ToString();
          //idDivipola = ObtenerIdDivipola(parametrosGuardar[13].ToString());
          //if (idDivipola == 0) return "-2"; //Significa que el municipio no existe en la base de datos
          if (!int.TryParse(parametrosGuardar[8].ToString(), out idUsuario)) return "-3";
          idEncuestaCaracterizacion = ObtenerIdEncuestaCaracterizacion(idUsuario);
          if (idEncuestaCaracterizacion == 0) return "-4";
          parametros.Add(new PaParams("@IdEncuestaCaracterizacion", SqlDbType.Int, idEncuestaCaracterizacion, ParameterDirection.Input));
          parametros.Add(new PaParams("@Fecha", SqlDbType.DateTime, DateTime.Now, ParameterDirection.Input));
          //parametros.Add(new PaParams("@ViculacionActual", SqlDbType.VarChar, vinculacionActual, ParameterDirection.Input, 100));
          parametros.Add(new PaParams("@MecanismoHaParticipado", SqlDbType.VarChar, mecanismoHaParticipado, ParameterDirection.Input,50));
          //parametros.Add(new PaParams("@EspaciosParticipadoCiudadano", SqlDbType.VarChar, espaciosParticipadoCiudadano, ParameterDirection.Input, 50));
          parametros.Add(new PaParams("@RecursosAlcaldia", SqlDbType.VarChar, recursosAlcaldia, ParameterDirection.Input, 10));
          parametros.Add(new PaParams("@AuditoriasVisiblesDNP", SqlDbType.VarChar, auditoriasVisibles, ParameterDirection.Input, 10));
          parametros.Add(new PaParams("@PlanAccion", SqlDbType.NVarChar, planAccion, ParameterDirection.Input, 50));
          parametros.Add(new PaParams("@GestionAutoridades", SqlDbType.NVarChar, gestionAutoridades, ParameterDirection.Input, 200));
          parametros.Add(new PaParams("@EstrategiaSeguimiento", SqlDbType.NVarChar, estrategiaSeguimiento, ParameterDirection.Input, 110));
          //parametros.Add(new PaParams("@ParticipacionAnterior", SqlDbType.VarChar, participacionAnterior, ParameterDirection.Input, 100)); 
          //parametros.Add(new PaParams("@CapacitacionEntidades", SqlDbType.VarChar, capacitacionesEntidades, ParameterDirection.Input, 100));
          parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
          parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
          Data = DbManagement.getDatos("dbo.pa_upd_encaracterparte2", CommandType.StoredProcedure, cadTransparencia, parametros);
          return cod_error + "<||>" + mensaje_error;
        #endregion Guardo los datos de la parte 2 de la encuesta
        case 3:
          #region Guardo los datos de la parte 3 de la encuesta
          if (parametrosGuardar == null || parametrosGuardar.Length <= 8) return "-1";//Significa que los parámetros no son correctos
          //var seguimientoGestionPublica = parametrosGuardar[0].ToString();
          //var seguimientoProyectos = parametrosGuardar[1].ToString();
          //var apoyoAlcaldia = parametrosGuardar[3].ToString() != string.Empty ? parametrosGuardar[3].ToString() : parametrosGuardar[2].ToString();
          //var relacionAdminComunidad = parametrosGuardar[4].ToString();
          //var gestionComunidad = parametrosGuardar[5].ToString();
          //var gestionAutoridades = parametrosGuardar[6].ToString();
          //var planAccion = parametrosGuardar[7].ToString();
          //var estrategiaSeguimiento = parametrosGuardar[9].ToString() != string.Empty ? parametrosGuardar[9].ToString() : parametrosGuardar[8].ToString();
          var estrategiaHallazgos = parametrosGuardar[1].ToString() != string.Empty ? parametrosGuardar[1].ToString() : parametrosGuardar[0].ToString();
          var cambiosGestion = parametrosGuardar[3].ToString() != string.Empty ? parametrosGuardar[3].ToString() : parametrosGuardar[2].ToString();
          var frecuenciaSeguimiento = parametrosGuardar[4].ToString();
          var radicaciónDerechoPeticion = parametrosGuardar[5].ToString();
          var facilidadAccesoInfo = parametrosGuardar[6].ToString();
          var percepcionSeguridad = parametrosGuardar[7].ToString();
          //var frecuenciasDenunciasControl = parametrosGuardar[12].ToString();
          //idDivipola = ObtenerIdDivipola(parametrosGuardar[14].ToString());
          //if (idDivipola == 0) return "-2"; //Significa que el municipio no existe en la base de datos
          if (!int.TryParse(parametrosGuardar[8].ToString(), out idUsuario)) return "-3";
          idEncuestaCaracterizacion = ObtenerIdEncuestaCaracterizacion(idUsuario);
          if (idEncuestaCaracterizacion == 0) return "-4";
          parametros.Add(new PaParams("@IdEncuestaCaracterizacion", SqlDbType.Int, idEncuestaCaracterizacion, ParameterDirection.Input));
          parametros.Add(new PaParams("@Fecha", SqlDbType.DateTime, DateTime.Now, ParameterDirection.Input));
          //parametros.Add(new PaParams("@SeguimientoGestionPublica", SqlDbType.NVarChar, seguimientoGestionPublica, ParameterDirection.Input, 10));
          //parametros.Add(new PaParams("@SeguimientoProyectos", SqlDbType.NVarChar, seguimientoProyectos, ParameterDirection.Input, 10));
          //parametros.Add(new PaParams("@ApoyoAlcaldía", SqlDbType.NVarChar, apoyoAlcaldia, ParameterDirection.Input, 100));
          //parametros.Add(new PaParams("@RelacionAdminComunidad", SqlDbType.NVarChar, relacionAdminComunidad, ParameterDirection.Input, 210));
          //parametros.Add(new PaParams("@GestionComunidad", SqlDbType.NVarChar, gestionComunidad, ParameterDirection.Input, 270));
          //parametros.Add(new PaParams("@PlanAccion", SqlDbType.NVarChar, planAccion, ParameterDirection.Input, 50));
          parametros.Add(new PaParams("@EstrategiaHallazgos", SqlDbType.NVarChar, estrategiaHallazgos, ParameterDirection.Input, 90));
          parametros.Add(new PaParams("@CambiosGestion", SqlDbType.NVarChar, cambiosGestion, ParameterDirection.Input, 40));
          parametros.Add(new PaParams("@FrecuenciaSeguimiento", SqlDbType.NVarChar, frecuenciaSeguimiento, ParameterDirection.Input, 180));
          parametros.Add(new PaParams("@RadicacionDerechoPeticion", SqlDbType.NVarChar, radicaciónDerechoPeticion, ParameterDirection.Input, 10));
          parametros.Add(new PaParams("@FacilidadAccesoInfo", SqlDbType.NVarChar, facilidadAccesoInfo, ParameterDirection.Input, 160));
          parametros.Add(new PaParams("@PercepcionSeguridad", SqlDbType.NVarChar, percepcionSeguridad, ParameterDirection.Input, 2));
          //parametros.Add(new PaParams("@FrecuenciaDenunciasControl", SqlDbType.NVarChar, frecuenciasDenunciasControl, ParameterDirection.Input, 15));
          //parametros.Add(new PaParams("@GestionAutoridades", SqlDbType.NVarChar, gestionAutoridades, ParameterDirection.Input, 200));
          //parametros.Add(new PaParams("@EstrategiaSeguimiento", SqlDbType.NVarChar, estrategiaSeguimiento, ParameterDirection.Input, 110));
          parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
          parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
          Data = DbManagement.getDatos("dbo.pa_upd_encaracterparte3", CommandType.StoredProcedure, cadTransparencia, parametros);
          return cod_error + "<||>" + mensaje_error;
        #endregion Guardo los datos de la parte 3 de la encuesta
        //case 4:
        //  #region Guardo los datos de la parte 3 de la encuesta
        //  if (parametrosGuardar == null || parametrosGuardar.Length <= 9) return "-1";//Significa que los parámetros no son correctos
        //  var frecuenciaDenunciasComunicacion = parametrosGuardar[0].ToString();
        //  var radicaciónDerechoPeticion = parametrosGuardar[1].ToString();
        //  var facilidadAccesoInfo = parametrosGuardar[2].ToString();
        //  var evaluacionesInternas = parametrosGuardar[3].ToString();
        //  var difusionResultados = parametrosGuardar[4].ToString();
        //  var cambiosGestion = parametrosGuardar[6].ToString() != string.Empty ? parametrosGuardar[6].ToString() : parametrosGuardar[5].ToString();
        //  var frecuenciaSeguimiento = parametrosGuardar[7].ToString();
        //  //idDivipola = ObtenerIdDivipola(parametrosGuardar[9].ToString());
        //  //if (idDivipola == 0) return "-2"; //Significa que el municipio no existe en la base de datos
        //  if (!int.TryParse(parametrosGuardar[8].ToString(), out idUsuario)) return "-3";
        //  idEncuestaCaracterizacion = ObtenerIdEncuestaCaracterizacion(idUsuario);
        //  if (idEncuestaCaracterizacion == 0) return "-4";
        //  parametros.Add(new PaParams("@IdEncuestaCaracterizacion", SqlDbType.Int, idEncuestaCaracterizacion, ParameterDirection.Input));
        //  parametros.Add(new PaParams("@Fecha", SqlDbType.DateTime, DateTime.Now, ParameterDirection.Input));
        //  parametros.Add(new PaParams("@FrecuenciaDenunciasComunicacion", SqlDbType.NVarChar, frecuenciaDenunciasComunicacion, ParameterDirection.Input, 15));
        //  parametros.Add(new PaParams("@RadicacionDerechoPeticion", SqlDbType.NVarChar, radicaciónDerechoPeticion, ParameterDirection.Input, 10));
        //  parametros.Add(new PaParams("@FacilidadAccesoInfo", SqlDbType.NVarChar, facilidadAccesoInfo, ParameterDirection.Input, 160));
        //  parametros.Add(new PaParams("@EvaluacionesInternas", SqlDbType.NVarChar, evaluacionesInternas, ParameterDirection.Input, 10));
        //  parametros.Add(new PaParams("@DifusionResultados", SqlDbType.NVarChar, difusionResultados, ParameterDirection.Input, 10));
        //  parametros.Add(new PaParams("@CambiosGestion", SqlDbType.NVarChar, cambiosGestion, ParameterDirection.Input, 40));
        //  parametros.Add(new PaParams("@FrecuenciaSeguimiento", SqlDbType.NVarChar, frecuenciaSeguimiento, ParameterDirection.Input, 180));
        //  parametros.Add(new PaParams("@Estado", SqlDbType.NVarChar, "1", ParameterDirection.Input, 1));
        //  parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        //  parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        //  Data = DbManagement.getDatos("dbo.pa_upd_encaracterparte4", CommandType.StoredProcedure, cadTransparencia, parametros);
        //  return cod_error + "<||>" + mensaje_error;
        //  #endregion Guardo los datos de la parte 3 de la encuesta
      }
      return string.Empty;
    }
    /// <summary>
    /// Sirve para saber si ya existe un id de encuesta caracterización
    /// </summary>
    /// <param name="idUsuario">Es el id del usuario</param>
    /// <returns>Devuelve un número que indica si hay o no un registro de caracterización para este usuario</returns>
    private static int ObtenerIdEncuestaCaracterizacion(int idUsuario)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@IdUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
      //parametros.Add(new PaParams("@idDivipola", SqlDbType.VarChar, idDivipola.ToString(), ParameterDirection.Input, 15));
      DataTable dtRta = DbManagement.getDatosDataTable("pa_obt_idenccarac_idUsu", CommandType.StoredProcedure, cadTransparencia, parametros);
      int sal = 0;
      if (dtRta.Rows.Count == 0 || dtRta.Columns.Count == 0) return 0;
      else if (!int.TryParse(dtRta.Rows[0].ItemArray[0].ToString(), out sal)) return 0;
      else return Convert.ToInt32(dtRta.Rows[0].ItemArray[0]);
    }

    /// <summary>
    /// Sirve para validar si el municipio existe en la base de datos 
    /// </summary>
    /// <param name="nombreMunicipio">Correponde a la secuencia municipio-Departamento</param>
    /// <returns>Si los nombres del municipio y departamento coinciden con los almacenados en la bd devuelve verdadero.</returns>
    static public bool ExisteMunicipio(string nombreMunicipio)
    {
      var municipio = string.Empty;
      var departamento = string.Empty;
      var municipioProcesar = nombreMunicipio.Split('-');
      if(municipioProcesar.Length>1)
      {
        municipio = municipioProcesar[0].Trim().ToUpper();
        departamento= municipioProcesar[1].Trim().ToUpper();
      }
      else municipio = municipioProcesar[0].Trim().ToUpper();
      DataTable dtMunicipios= DbManagement.getDatosDataTable("dbo.pa_listar_depmun", CommandType.StoredProcedure, cadTransparencia, new List<PaParams>());
      var existeMunicipio = (from registro in dtMunicipios.AsEnumerable()
                            where registro.ItemArray[1] != null && registro.ItemArray[0] != null && registro.ItemArray[1].ToString().Trim().ToUpper() == municipio && registro.ItemArray[0].ToString().Trim().ToUpper() == departamento
                            select registro).ToArray();
      return existeMunicipio.Any();
    }

      public static List<DataTable> obtDetalleEncuesta(DateTime fecha_ini,DateTime fecha_fin)
      {
          List<DataTable> Data = new List<DataTable>();
          List<PaParams> parametros = new List<PaParams>();
          parametros.Add(new PaParams("@fecha_inicial", SqlDbType.DateTime, fecha_ini, ParameterDirection.Input));
          parametros.Add(new PaParams("@fecha_final", SqlDbType.DateTime, fecha_fin, ParameterDirection.Input));
          Data = DbManagement.getDatos("dbo.pa_obt_detalle_encuesta", CommandType.StoredProcedure, cadTransparencia, parametros);
          return Data;
      }
  }

}