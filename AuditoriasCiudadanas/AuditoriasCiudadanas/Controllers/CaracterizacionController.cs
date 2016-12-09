using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace AuditoriasCiudadanas.Controllers
{
  public class CaracterizacionController
  {
    /// <summary>
    /// Esta función se utiliza para consultar todos los municipios y su departamento
    /// </summary>
    /// <returns>Devuelve un texto con el listado de todos los municipios y su departamento que se encuentren en la base de datos siguiendo la notación Municipio - Departamento.
    /// Se emplea el caracter \n para separar a un municipio de otro.
    /// </returns>
    public string ObtenerMunicipiosYDepartamentos()
    {
      string rta = string.Empty;
      DataTable dtSalida = Models.clsCaracterizacionModels.GetMunicipiosDepartamento();
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
        foreach (DataRow drFila in dtSalida.Rows) //Cada fila corresponde a un registro con el nombre del municipio y su departamento.
          if (drFila != null && drFila.ItemArray.Length >= 2 && drFila[1].ToString() != string.Empty)
            rta = rta == string.Empty ? drFila[1].ToString() + " - " + drFila[0].ToString() : rta + "\n" + drFila[1].ToString() + " - " + drFila[0].ToString();
      return rta;
    }
    /// <summary>
    /// Sirve para validar la existencia del municipio y departamento en la tabla Divipola
    /// </summary>
    /// <param name="nombreMunicipio">Corresponde a la combinación municipio - departamento</param>
    /// <returns></returns>
    public bool ExisteMunicipio(string nombreMunicipio)
    {
      var parametros = nombreMunicipio.Split('*');//El * es un caracter que usamos para separar los datos de los dos formularios de la encuesta
      return Models.clsCaracterizacionModels.ExisteMunicipio(parametros[0]);
    }
    /// <summary>
    /// Sirve para guardar los resultados de la encuesta de caracterización.
    /// </summary>
    /// <param name="parametrosGuardar">Corresponde a la lista de parámetros de la encuesta que serán guardados</param>
    /// <returns></returns>
    public bool GuardarEncuestaCaracterizacion(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos de los dos formularios de la encuesta
      return Models.clsCaracterizacionModels.IngresarEncuesta(parametos)== "1<||>"? true:false;
    }

    public DataTable obtDetalleEncuesta(int id_corte, DateTime fecha_ini, DateTime fecha_fin)
    {
        DataTable dtInfo = new DataTable();
        dtInfo = Models.clsCaracterizacionModels.obtDetalleEncuesta(id_corte,fecha_ini,fecha_fin)[0];
        return dtInfo;

    }
  }
}