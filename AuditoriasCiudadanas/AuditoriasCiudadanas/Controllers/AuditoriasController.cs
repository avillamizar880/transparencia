using AuditoriasCiudadanas.Models;
using Newtonsoft.Json;
//using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Controllers
{
  public class AuditoriasController
  {
    /// <summary>
    /// Sirve para traer las categorias de los auditores
    /// </summary>
    /// <returns></returns>
    public string ObtenerCategoriasAuditor()
    {
      string rta = string.Empty;
      DataTable dtSalida = clsCategoriasAuditorModels.GetCategoriasAuditor();
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }

    public string GuardarTipoAuditoria(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos de los dos formularios de la encuesta
      return clsCategoriasAuditorModels.IngresarActualizarCategoriaAuditor(parametos);
    }

    public string SubirImagen(string rutaImagen)
    {
      //FileUpload xxx = new FileUpload();
      //xxx.s = rutaImagen;
      //var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos de los dos formularios de la encuesta
      //return clsCategoriasAuditorModels.IngresarActualizarCategoriaAuditor(parametos);
      return string.Empty;
    }


    /// <summary>
    /// Sirve para eliminar una categoría del auditor
    /// </summary>
    /// <param name="idTipoAuditor">Es el id del tipo de auditor</param>
    /// <returns>Un valor que indica si la eliminación fue exitosa o no</returns>
    public bool EliminarCategoriasAuditor(int idTipoAuditor)
    {
      return clsCategoriasAuditorModels.EliminarCategoriasAuditor(idTipoAuditor) ? true : false;
    }
  }
}