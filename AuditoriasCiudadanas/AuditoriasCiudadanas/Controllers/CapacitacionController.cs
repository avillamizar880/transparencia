using AuditoriasCiudadanas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Controllers
{
    public class CapacitacionController
    {
        /// <summary>
        /// Funcion que agrega un registro multimedia
        /// </summary>
        /// <param name="tipo_recurso">tipo recurso: ver tabla TipoRecurso</param>
        /// <param name="titulo">titulo</param>
        /// <param name="descripcion">descripcion</param>
        /// <param name="ruta">url donde se encuentra el recurso</param>
        /// <param name="id_usuario">id usuario que agrega el registro</param>
        /// <returns></returns>
        public string addRecursoMultimedia(int tipo_recurso, string titulo, string descripcion, string ruta, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.addRecursoMultimedia(tipo_recurso, titulo, descripcion, ruta, id_usuario);
            return outTxt;
        }

        /// <summary>
        /// Funcion que inactiva el recurso multimedia: estado='0'
        /// </summary>
        /// <param name="id_usuario">id usuario que realiza la modificacion</param>
        /// <param name="id_recurso">id recurso a inactivar</param>
        /// <returns></returns>
        public string delRecursoMultimedia(int id_usuario,int id_recurso)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.delRecursoMultimedia(id_recurso, id_usuario);
            return outTxt;
        }

        /// <summary>
        /// Funcion que modifica los datos asociados a un recurso multimedia en particular
        /// </summary>
        /// <param name="id_recurso"></param>
        /// <param name="titulo"></param>
        /// <param name="descripcion"></param>
        /// <param name="ruta"></param>
        /// <param name="id_usuario">id usuario que realiza la modificacion</param>
        /// <returns></returns>
        public string modRecursoMultimedia(int id_recurso, string titulo, string descripcion, string ruta, int id_usuario) {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.delRecursoMultimedia(id_recurso, id_usuario);
            return outTxt;
        }

        /// <summary>
        /// Funcion que trae el listado de recursos multimedia en un dataTable y pagina en el código
        /// </summary>
        /// <param name="page">pagina a listar</param>
        /// <param name="id_tipo">tipo de recurso multimedia</param>
        /// <returns></returns>
        public Models.ModelDataRecurso ObtListadoRecursoMutimedia(int page,int id_tipo) {
            int numPerPag=Convert.ToInt32(ConfigurationManager.AppSettings["MaximumResultsPerPag"]);
            Models.ModelDataRecurso objReturn = new Models.ModelDataRecurso();
            DataTable detalle = new DataTable();
            DataTable source = new DataTable();
            List<DataTable> lst_source = Models.clsCapacitacion.ObtListadoRecursoMutimedia(id_tipo,page,numPerPag);
            if (lst_source.Count > 0) {
                source = lst_source[0];
                if (lst_source.Count > 1) {
                    detalle = lst_source[1];
                }
                
                objReturn.recursos = new List<itemRecurso>();
                objReturn.totalNumber = source.Rows.Count;
                objReturn.pagesNumber = page;
                objReturn.totalPages = (objReturn.totalNumber > numPerPag) ? ((objReturn.totalNumber - (objReturn.totalNumber % numPerPag)) / numPerPag) : 1;
                if ((objReturn.totalNumber >= numPerPag) && ((objReturn.totalNumber % numPerPag) > 0))
                {
                    objReturn.totalPages++;
                }

                List<itemRecurso> listaRecursos = source.AsEnumerable().Select(m => new itemRecurso()
                    {
                        idRecurso = m.Field<int>("idRecurso"),
                        titulo = m.Field<string>("titulo"),
                        descripcion = m.Field<string>("descripcion"),
                        ruta_url = m.Field<string>("rutaUrl")
                    }).ToList();

                if (objReturn.totalNumber > numPerPag)
                {
                    objReturn.recursos.AddRange(listaRecursos.Skip<itemRecurso>(((page - 1) * numPerPag)).Take<itemRecurso>(numPerPag));
                }
                else
                {
                    objReturn.recursos.AddRange(listaRecursos);
                }
            }
            
            return objReturn;

        }
        /// <summary>
        /// Funcion que lista los recursos multimedia ya paginados desde base de datos
        /// </summary>
        /// <param name="page">pagina a listar</param>
        /// <param name="id_tipo">tipo de recurso multimedia</param>
        /// <returns></returns>
        public Models.ModelDataRecurso ObtListadoRecursoMutimediaByPag(int page, int id_tipo)
        {
            int numPerPag = Convert.ToInt32(ConfigurationManager.AppSettings["MaximumResultsPerPag"]);
            Models.ModelDataRecurso objReturn = new Models.ModelDataRecurso();
            DataTable detalle = new DataTable();
            DataTable source = new DataTable();
            List<DataTable> lst_source = Models.clsCapacitacion.ObtListadoRecursoMutimedia(id_tipo,page,numPerPag);
            if (lst_source.Count > 0)
            {
                source = lst_source[0];
                if (source.Rows.Count > 0)
                {
                    objReturn.totalNumber = Convert.ToInt16(source.Rows[0]["total_reg"].ToString());
                }
                else {
                    objReturn.totalNumber = 0;
                }
                if (lst_source.Count > 1)
                {
                    detalle = lst_source[1];
                }

                objReturn.dtRecursos = source;
                objReturn.pagesNumber = page;
                objReturn.totalPages = (objReturn.totalNumber > numPerPag) ? ((objReturn.totalNumber - (objReturn.totalNumber % numPerPag)) / numPerPag) : 1;
                if ((objReturn.totalNumber >= numPerPag) && ((objReturn.totalNumber % numPerPag) > 0))
                {
                    objReturn.totalPages++;
                }


            }

            return objReturn;

        }

        /// <summary>
        /// Funcion que agrega un registro multimedia
        /// </summary>
        /// <param name="tipo_recurso">tipo recurso: ver tabla TipoRecurso</param>
        /// <param name="titulo">titulo</param>
        /// <param name="descripcion">descripcion</param>
        /// <param name="ruta">url donde se encuentra el recurso</param>
        /// <param name="id_usuario">id usuario que agrega el registro</param>
        /// <returns></returns>
        public string addTemaCapacitacion(string titulo, string detalle, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.addTemaCapacitacion(titulo, detalle, id_usuario);
            return outTxt;
        }

    }
}
