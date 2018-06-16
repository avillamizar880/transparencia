using System.Data;
using Newtonsoft.Json;
using AuditoriasCiudadanas.Models;
using System;

namespace AuditoriasCiudadanas.Controllers
{
  public class InformacionController
  {
    /// <summary>
    /// ObtenerTotalNoticias
    /// </summary>
    /// <param name="palabraClave">Es la palabra sobre la cual se realizará la búsqueda</param>
    /// <returns>Devuelve el número de noticias que cumplen con el criterio de búsqueda</returns>
    public string ObtenerTotalNoticias(string palabraClave)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsNoticia.ObtenerTotalNoticias(palabraClave);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }

    public string ObtenerDetalleNoticia(int idNoticia)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsNoticia.ObtenerDetalleNoticia(idNoticia);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }

    /// <summary>
    /// ObtenerTotalNoticiasNuevas
    /// </summary>
    /// <returns>Devuelve el número de noticias nuevas que cumplen con el criterio de búsqueda</returns>
    public string ObtenerTotalNoticiasNuevas()
    {
      string rta = string.Empty;
      DataTable dtSalida = clsNoticia.ObtenerTotalNoticiasNuevas();
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }
    /// <summary>
    /// Sirve para traer las noticias que coincidan con la palabra clave
    /// </summary>
    /// <param name="palabraClave">Devuelve un string con los datos solicitados</param>
    /// <param name="numPag">Correponde al número de la página que desea consultar</param>
    /// <param name="tamanoPag">Correponde al tamaño de la página</param>
    /// <returns>Devuelve las noticias que cumplen con el criterio de búsqueda</returns>
    public string ObtenerNoticiasXPalabraClave(string palabraClave, int numPag, int tamanoPag)
    {
      string rta = string.Empty;
      DataTable dtSalida =  clsNoticia.ObtenerNoticiasXPalabraClave(palabraClave, numPag, tamanoPag);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }

  }
}