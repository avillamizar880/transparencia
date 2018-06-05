using System.Data;
using Newtonsoft.Json;
using AuditoriasCiudadanas.Models;
using System;

namespace AuditoriasCiudadanas.Controllers
{
  public class PublicarNoticiasCampanasController
  {
    /// <summary>
    /// ObtenerTotalNoticiasPublicadas
    /// </summary>
    /// <param name="palabraClave">Es la palabra sobre la cual se realizará la búsqueda</param>
    /// <returns>Devuelve el número de noticias publicadas que cumplen con el criterio de búsqueda</returns>
    public string ObtenerTotalNoticiasPublicadas(string palabraClave)
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

    /// <summary>
    /// Sirve para traer las noticias que coincidan con la palabra clave
    /// </summary>
    /// <param name="palabraClave">Devuelve un string con los datos solicitados</param>
    /// <param name="numPag">Correponde al número de la página que desea consultar</param>
    /// <param name="tamanoPag">Correponde al tamaño de la página</param>
    /// <returns>Devuelve las noticias que cumplen con el criterio de búsqueda</returns>
    public string ObtenerNoticiasPublicadasXPalabraClave(string palabraClave, int numPag, int tamanoPag)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsNoticia.ObtenerPublicarNoticiasXPalabraClave(palabraClave, numPag, tamanoPag);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }
    /// <summary>
    /// Sirve para eliminar una noticia.
    /// </summary>
    /// <param name="idNoticiaEliminar">Es el id de la noticia a eliminar</param>
    /// <param name="idUsuario">Es el id del usuario que realiza la operación.</param>
    /// <returns>Devuelve un valor (true o false) el cual indica que se realizó el procedimiento</returns>
    public string EliminarNoticia(int idNoticiaEliminar, int idUsuario)
    {
      return clsNoticia.EliminarNoticia(idNoticiaEliminar, idUsuario);
    }

    /// <summary>
    /// Sirve para publicar una noticia.
    /// </summary>
    /// <param name="idNoticiaPublicar">Es el id de la noticia a publicar</param>
    /// <param name="idUsuario">Es el id del usuario que realiza la operación.</param>
    /// <returns>Devuelve un valor (true o false) el cual indica que se realizó el procedimiento</returns>
    public string PublicarNoticia(int idNoticiaPublicar, int idUsuario)
    {
      return clsNoticia.PublicarNoticia(idNoticiaPublicar, idUsuario);
    }
    /// <summary>
    /// Sirve para guardar los datos básicos de una noticia
    /// </summary>
    /// <param name="parametrosGuardar">Son algunos de los parámetros necesarios para crear un registro de tarea</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public string GuardarNoticia(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos provenientes del formulario.
      return clsNoticia.GuardarNoticia(parametos);
    }


  }
}