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
    /// Sirve para guardar los datos de la encuesta
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros de la encuesta</param>
    /// <returns>Devuelve un texto indicando si hubo o no errores al guardar la encuesta</returns>
    static public string IngresarEncuesta(params object[] parametrosGuardar)
    {
      if (parametrosGuardar == null || parametrosGuardar.Length <= 16) return "-2";//Significa que los parámetros no son correctos
      var idDivipola = ObtenerIdDivipola(parametrosGuardar[0].ToString());
      if (idDivipola <= 0) return "-2";
      var vinculacionActual = parametrosGuardar[9].ToString() != string.Empty ? parametrosGuardar[9].ToString() : parametrosGuardar[8].ToString();
      var mecanismoHaParticipado = parametrosGuardar[11].ToString() != string.Empty ? parametrosGuardar[11].ToString() : parametrosGuardar[10].ToString();
      var espaciosParticipadoCiudadano = parametrosGuardar[13].ToString() != string.Empty ? parametrosGuardar[13].ToString() : parametrosGuardar[12].ToString();
      List <DataTable> Data = new List<DataTable>();
      List<PaParams> parametros = new List<PaParams>();
      string cod_error = "1";
      string mensaje_error = string.Empty;
      parametros.Add(new PaParams("@IdUsuario", SqlDbType.VarChar, parametrosGuardar[16].ToString(), ParameterDirection.Input, 100));
      parametros.Add(new PaParams("@idDivipola", SqlDbType.VarChar, idDivipola.ToString(), ParameterDirection.Input, 15));
      parametros.Add(new PaParams("@Fecha", SqlDbType.DateTime, DateTime.Now, ParameterDirection.Input));
      parametros.Add(new PaParams("@Genero", SqlDbType.VarChar, parametrosGuardar[1].ToString(), ParameterDirection.Input, 50));
      parametros.Add(new PaParams("@RangoEdad", SqlDbType.VarChar, parametrosGuardar[2].ToString(), ParameterDirection.Input, 20));
      parametros.Add(new PaParams("@Ocupacion", SqlDbType.VarChar, parametrosGuardar[3].ToString(), ParameterDirection.Input, 200));
      parametros.Add(new PaParams("@Cargo", SqlDbType.VarChar, parametrosGuardar[4].ToString(), ParameterDirection.Input,50));
      parametros.Add(new PaParams("@LugarResidencia", SqlDbType.VarChar, parametrosGuardar[5].ToString(), ParameterDirection.Input,50));
      parametros.Add(new PaParams("@PerteneceMinoria", SqlDbType.VarChar, parametrosGuardar[6].ToString(), ParameterDirection.Input,2));
      parametros.Add(new PaParams("@PerteneceOrganizacionSocial", SqlDbType.VarChar, parametrosGuardar[7].ToString(), ParameterDirection.Input,2));
      parametros.Add(new PaParams("@VinculacionActual", SqlDbType.VarChar, vinculacionActual, ParameterDirection.Input,100));
      parametros.Add(new PaParams("@MecanismoHaParticipado", SqlDbType.VarChar, mecanismoHaParticipado, ParameterDirection.Input,50));
      parametros.Add(new PaParams("@EspaciosParticipadoCiudadano", SqlDbType.VarChar, espaciosParticipadoCiudadano, ParameterDirection.Input,50));
      parametros.Add(new PaParams("@RecursosAlcaldia", SqlDbType.VarChar, parametrosGuardar[14].ToString(), ParameterDirection.Input,10));
      parametros.Add(new PaParams("@AuditoriasVisiblesDNP", SqlDbType.VarChar, parametrosGuardar[15].ToString(), ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
      Data = DbManagement.getDatos("dbo.pa_ins_encaracterizacion", CommandType.StoredProcedure, cadTransparencia, parametros);
      return cod_error + "<||>" + mensaje_error;
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

      public static List<DataTable> obtDetalleEncuesta(int id_corte, DateTime fecha_ini,DateTime fecha_fin)
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