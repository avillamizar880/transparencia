using System.Data;
using Newtonsoft.Json;
using AuditoriasCiudadanas.Models;
using System;

namespace AuditoriasCiudadanas.Controllers
{
  public class PublicarNoticiasCampanasController
  {
    #region Noticias
    /// <summary>
    /// ObtenerTotalNoticiasPublicadas
    /// </summary>
    /// <param name="palabraClave">Es la palabra sobre la cual se realizará la búsqueda</param>
    /// <returns>Devuelve el número de noticias publicadas que cumplen con el criterio de búsqueda</returns>
    public string ObtenerTotalNoticiasPublicadas(string palabraClave)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsNoticia.ObtenerTotalNoticiasPublicadas(palabraClave);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }
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
    /// Sirve para consultar el nombre de la imagen a 
    /// </summary>
    /// <param name="idRecurso">Es el id del recurso</param>
    /// <returns>Devuelve una lista con los resultados encontrados</returns>
    public string ObtenerImagenRecurso(int idRecurso)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsCampana.ObtenerImagenRecurso(idRecurso);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }

    /// <summary>
    /// Sirve para guardar los datos básicos de una noticia
    /// </summary>
    /// <param name="parametrosGuardar">Son algunos de los parámetros necesarios para crear un registro de noticias</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public string GuardarNoticia(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos provenientes del formulario.
      return clsNoticia.GuardarNoticia(parametos);
    }
    /// <summary>
    /// Sirve para editar los datos básicos de una noticia
    /// </summary>
    /// <param name="parametrosGuardar">Son algunos de los parámetros necesarios para editar un registro de tarea</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public string EditarNoticia(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos provenientes del formulario.
      return clsNoticia.EditarNoticia(parametos);
    }
    #endregion Noticias
    #region Campañas
    /// <summary>
    /// Sirve para obtener todas las campañas publicadas
    /// </summary>
    /// <param name="palabraClave">Es la palabra sobre la cual se realizará la búsqueda</param>
    /// <returns>Devuelve el número de campañas publicadas que cumplen con el criterio de búsqueda</returns>
    public string ObtenerTotalCampanasPublicadas(string palabraClave)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsCampana.ObtenerTotalCampanasPublicadas(palabraClave);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }
    /// <summary>
    /// Sirve para obtener todas las campañas
    /// </summary>
    /// <param name="palabraClave">Es la palabra sobre la cual se realizará la búsqueda</param>
    /// <returns>Devuelve el número de campañas que cumplen con el criterio de búsqueda</returns>
    public string ObtenerTotalCampanas(string palabraClave)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsCampana.ObtenerTotalCampanas(palabraClave);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }
    /// <summary>
    /// Sirve para traer las campañas que coincidan con la palabra clave
    /// </summary>
    /// <param name="palabraClave">Devuelve un string con los datos solicitados</param>
    /// <param name="numPag">Correponde al número de la página que desea consultar</param>
    /// <param name="tamanoPag">Correponde al tamaño de la página</param>
    /// <returns>Devuelve las campañas que cumplen con el criterio de búsqueda</returns>
    public string ObtenerCampanasPublicadasXPalabraClave(string palabraClave, int numPag, int tamanoPag)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsCampana.ObtenerPublicarCampanasXPalabraClave(palabraClave, numPag, tamanoPag);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }
    /// <summary>
    /// Sirve para eliminar una campaña.
    /// </summary>
    /// <param name="idCampanaEliminar">Es el id de la campaña a eliminar</param>
    /// <param name="idUsuario">Es el id del usuario que realiza la operación.</param>
    /// <returns>Devuelve un valor (true o false) el cual indica que se realizó el procedimiento</returns>
    public string EliminarCampana(int idCampanaEliminar, int idUsuario)
    {
      return clsCampana.EliminarCampana(idCampanaEliminar, idUsuario);
    }
    /// <summary>
    /// Sirve para publicar una noticia.
    /// </summary>
    /// <param name="idCampanaPublicar">Es el id de la campaña a publicar</param>
    /// <param name="idUsuario">Es el id del usuario que realiza la operación.</param>
    /// <returns>Devuelve un valor (true o false) el cual indica que se realizó el procedimiento</returns>
    public string PublicarCampana(int idCampanaPublicar, int idUsuario)
    {
      return clsCampana.PublicarCampana(idCampanaPublicar, idUsuario);
    }
    /// <summary>
    /// Sirve para guardar los datos básicos de una campaña
    /// </summary>
    /// <param name="parametrosGuardar">Son algunos de los parámetros necesarios para crear un registro de campaña</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public string GuardarCampana(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos provenientes del formulario.
      return clsCampana.GuardarCampana(parametos);
    }
    /// <summary>
    /// Sirve para editar los datos básicos de una campaña
    /// </summary>
    /// <param name="parametrosGuardar">Son algunos de los parámetros necesarios para editar un registro de una campaña</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public string EditarCampana(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos provenientes del formulario.
      return clsCampana.EditarCampana(parametos);
    }

    /// <summary>
    /// Sirve para guardar los recursos multimedia de las campañas y noticias
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros a guardar</param>
    /// <returns>Devuelve una cadena de texto que indica si se guardo correctamente el registro en la base de datos </returns>
    public string GuardarDetalleRecursoMultimedia(string parametrosGuardar)
    {
      var parametros = parametrosGuardar.Split('*');
      return clsCampana.GuardarRegistroMultimedia(parametros);
    }
    #endregion Campañas
  }
}