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
        public string delRecursoMultimedia(int id_usuario, int id_recurso)
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
        public string modRecursoMultimedia(int id_recurso, string titulo, string descripcion, string ruta, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.modRecursoMultimedia(id_recurso,titulo,descripcion,ruta,id_usuario);
            return outTxt;
        }

        /// <summary>
        /// Funcion que trae el listado de recursos multimedia en un dataTable y pagina en el código
        /// </summary>
        /// <param name="page">pagina a listar</param>
        /// <param name="id_tipo">tipo de recurso multimedia</param>
        /// <returns></returns>
        public Models.ModelDataRecurso ObtListadoRecursoMutimedia(int page, string id_tipo)
        {
            int numPerPag = Convert.ToInt32(ConfigurationManager.AppSettings["MaximumResultsPerPag"]);
            Models.ModelDataRecurso objReturn = new Models.ModelDataRecurso();
            DataTable detalle = new DataTable();
            DataTable source = new DataTable();
            List<DataTable> lst_source = Models.clsCapacitacion.ObtListadoRecursoMutimedia(id_tipo, page, numPerPag);
            if (lst_source.Count > 0)
            {
                source = lst_source[0];
                if (lst_source.Count > 1)
                {
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
        public Models.ModelDataRecurso ObtListadoRecursoMutimediaByPag(int page, string id_tipo)
        {
            int numPerPag = Convert.ToInt32(ConfigurationManager.AppSettings["MaximumResultsPerPag"]);
            Models.ModelDataRecurso objReturn = new Models.ModelDataRecurso();
            objReturn.tipoRecurso = id_tipo;
            DataTable detalle = new DataTable();
            DataTable source = new DataTable();
            if (id_tipo == "5")
            {
                List<DataTable> lst_source = Models.clsCapacitacion.listTemaCapacitacion();
                if (lst_source.Count > 0)
                {
                    source = lst_source[0];
                    objReturn.dtRecursos = source;
                }
            }
            else { 
                List<DataTable> lst_source = Models.clsCapacitacion.ObtListadoRecursoMutimedia(id_tipo, page, numPerPag);
                if (lst_source.Count > 0)
                {
                    source = lst_source[0];
                    if (source.Rows.Count > 0)
                    {
                        objReturn.totalNumber = Convert.ToInt16(source.Rows[0]["total_reg"].ToString());
                    }
                    else
                    {
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
            }
            return objReturn;

        }

        /// <summary>
        /// Funcion que crea cuestionario de evaluacion para una capacitación determinada 
        /// </summary>
        /// <param name="id_tipo"></param>
        /// <param name="titulo"></param>
        /// <param name="descripcion"></param>
        /// <param name="id_usuario"></param>
        /// <param name="bpin_proyecto"></param>
        /// <returns></returns>
        public string CrearCuestionarioEvaluacion(int id_tipo, string titulo, string descripcion, int id_usuario, int id_capacitacion)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.crearCuestionarioEvaluacion(id_tipo, titulo, descripcion, id_usuario, id_capacitacion);
            return outTxt;
        }


        public string obtCuestionarioCapacitacion(int id_capacitacion)
        {
            string outTxt = "";
            List<DataTable> listado = Models.clsCapacitacion.obtCuestionarioCapacitacion(id_capacitacion);
            if (listado.Count > 1)
            {
                DataTable dtGeneral = listado[0];
                if (dtGeneral.Rows.Count > 0)
                {
                    outTxt = dtGeneral.Rows[0]["idCuestionario"].ToString().Trim() + "<||>" + dtGeneral.Rows[0]["Titulo"].ToString().Trim() + "<||>" + dtGeneral.Rows[0]["Descripcion"].ToString().Trim() + "<||>" + dtGeneral.Rows[0]["idTipoCuestionario"].ToString().Trim();
                }
                else
                {
                    outTxt = "0<||>";
                }

            }
            return outTxt;
        }

        public string obtCuestionarioCapacitacionJson(int id_capacitacion)
        {
            string outTxt = "";
            List<DataTable> listado = Models.clsCapacitacion.obtCuestionarioCapacitacion(id_capacitacion);
            if (listado.Count > 1)
            {
                DataTable dtGeneral = listado[0];
                AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
                outTxt = datos_func.convertToJson(dtGeneral);

            }
            return outTxt;
        }

        public string obtRecursoMultimediaById(int id_recurso) {
            string outTxt = "";
            List<DataTable> lstInfo = new List<DataTable>();
            lstInfo = Models.clsCapacitacion.obtRecursoMultimediaById(id_recurso);
            lstInfo[0].TableName = "encabezado";
            lstInfo[1].TableName = "detallle";

            AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
            outTxt = datos_func.convertToJsonObj(lstInfo);

            return outTxt;
        }

        public List<DataTable> dtRecursoMultimediaById(int id_recurso)
        {
            List<DataTable> lstInfo = new List<DataTable>();
            lstInfo = Models.clsCapacitacion.obtRecursoMultimediaById(id_recurso);
            lstInfo[0].TableName = "encabezado";
            lstInfo[1].TableName = "detallle";
            return lstInfo;
        }


        /// <summary>
        /// Obtiene informacion basica de la capacitacion y los id de modulos que esta contiene
        /// </summary>
        /// <param name="id_cap"></param>
        /// <returns></returns>
        public string ObtModulosCapacitacionJson(int id_cap)
        {
            string outTxt = "";

            DataTable dtInfo = new DataTable();
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsCapacitacion.ObtModulosCapacitacion(id_cap);
            AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
            outTxt = datos_func.convertToJsonObj(listaInfo);

            return outTxt;
        }

        /// <summary>
        /// Obtiene los recursos asociados al modulo de una capacitacion
        /// </summary>
        /// <param name="id_cap"></param>
        /// <param name="id_modulo"></param>
        /// <returns></returns>
        public string ObtRecursosModuloJson(int id_cap,int id_modulo, int id_usuario)
        {
            string outTxt = "";

            DataTable dtInfo = new DataTable();
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsCapacitacion.ObtRecursosModuloCap(id_cap,id_modulo, id_usuario);
            AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
            outTxt = datos_func.convertToJsonObj(listaInfo);

            return outTxt;
        }

        // AND

        /// <summary>
        /// Funcion que agrega un registro de tema de capacitacion
        /// </summary>
        /// <param name="titulo">titulo</param>
        /// <param name="detalle">descripcion</param>
        /// <param name="id_usuario">id usuario que agrega el registro</param>
        /// <returns></returns>
        public string addTemaCapacitacion(string titulo, string detalle, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.addTemaCapacitacion(titulo, detalle, id_usuario);
            return outTxt;
        }

        /// Funcion que desactiva un registro de tema de capacitacion
        /// </summary>
        /// <param name="id_cap">id del tema de capacitación</param>
        /// <param name="id_usuario">id usuario que agrega el registro</param>
        /// <returns></returns>
        public string delTemaCapacitacion(int id_cap, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.delTemaCapacitacion(id_cap, id_usuario);
            return outTxt;
        }

        /// Funcion que desactiva un registro de tema de capacitacion
        /// </summary>
        /// <param name="id_cap">id del tema de capacitación</param>
        /// <param name="titulo">titulo</param>
        /// <param name="detalle">descripcion</param>
        /// <param name="id_usuario">id usuario que agrega el registro</param>
        /// <returns></returns>
        public string updTemaCapacitacion(int id_cap, string titulo, string detalle, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.updTemaCapacitacion(id_cap, titulo, detalle, id_usuario);
            return outTxt;
        }
        /// <summary>
        /// Funcion que lista los temas de capacitacion
        /// </summary>
        /// <returns></returns>
        public DataTable ObtListadoTemaCapacitacion()
        {

            DataTable dtInfo = new DataTable();
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsCapacitacion.listTemaCapacitacion();
            dtInfo = listaInfo[0];
            return dtInfo;

        }

        internal string delRecCapacitacion(int id_reccap_aux, int id_usuario_aux)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.delRecCapacitacion(id_reccap_aux, id_usuario_aux);
            return outTxt;
        }

        public string addRecCapacitacion(string tituloRec, int tipo_aux, int modulo_aux, int id_cap_aux, string url, int id_usuario_aux)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.addRecCapacutacion(tituloRec, tipo_aux, modulo_aux, id_cap_aux, url, id_usuario_aux);
            return outTxt;
        }


        public string ObtListadoRecCapacitacion(int id_cap)
        {
            string outTxt = "";

            DataTable dtInfo = new DataTable();
            DataTable dtGeneralEvalua = new DataTable();
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsCapacitacion.obtRecursosCapacitacion(id_cap);
            DataTable dtCapacitacion = listaInfo[0];
            DataTable dtRecursos = listaInfo[1];

            //consultar si ya tiene evaluacion configurada
            List<DataTable> listadoEvaluacion = Models.clsCapacitacion.obtCuestionarioCapacitacion(id_cap);
            if (listadoEvaluacion.Count > 1)
            {
                dtGeneralEvalua = listadoEvaluacion[0];
            }
            if (dtCapacitacion.Rows.Count > 0)
            {
                outTxt += "$(\"#txtTituloCap\").val('" + dtCapacitacion.Rows[0]["TituloCapacitacion"].ToString().Trim() + "');";
                outTxt += "$(\"#txtDescripcionCap\").val('" + dtCapacitacion.Rows[0]["DetalleCapacitacion"].ToString().Trim() + "');";
            }

            if (dtRecursos.Rows.Count > 0)
            {
                string recursos="";
                recursos += "<h2>Recursos de capacitacion</h2>";
                int contmodulo = Convert.ToInt32(dtRecursos.Rows[0]["modulo"].ToString().Trim());
                //imprimir encabezado modulo
                recursos += "<div class=\"nummodulo\" > Módulo " + contmodulo+"</div>";
                recursos += "<div id = \"dato\" class=\"list-group uppText clearfix\" >";
                recursos += "<div class=\"list -group-item etiqueta\" ><div class=\"col-sm-2\" hidden =\"hidden\"></div><div class=\"col-sm-3\" ><span>Título</span></div><div class=\"col-sm-6\" ><span>Detalle</span></div><div class=\"col-sm-3\" ><span></span></div></div></div>";


                for (int i = 0; i <= dtRecursos.Rows.Count - 1; i++)
                {

                    int auxmodulo = Convert.ToInt32(dtRecursos.Rows[i]["modulo"].ToString().Trim());
                    if (contmodulo != auxmodulo)
                    {
                        contmodulo = auxmodulo;
                        //imprimir encabezado modulo
                        recursos += "</div>";
                        recursos += "<div class=\"nummodulo\" > Módulo " + contmodulo + "</div>";
                        recursos += "<div id =\"dato\" class=\"list-group uppText clearfix\">";
                        recursos += "<div class=\"list -group-item etiqueta\" ><div class=\"col-sm-2\" hidden =\"hidden\"></div><div class=\"col-sm-3\" ><span>Título</span></div><div class=\"col-sm-6\" ><span>Detalle</span></div><div class=\"col-sm-3\" ><span></span></div></div></div>";
                    }
                    // Listando recursos

                    recursos += "<div class=\"list-group-item\"> ";
                    recursos += "<div class=\"col-sm-2\" hidden =\"hidden\" ><p class=\"list-group-item-text\" ><a href = \"#\"> "+ dtRecursos.Rows[i]["idRCap"].ToString().Trim() + " </a></p ></div>";
                    recursos += "<div class=\"col-sm-3\" ><span>" + dtRecursos.Rows[i]["titulo"].ToString().Trim() + "</span></div>";
                    recursos += "<div class=\"col-sm-6\" ><span><a target=\"_blank\" href =\"" + dtRecursos.Rows[i]["URL"].ToString().Trim() + "\">" + dtRecursos.Rows[i]["URL"].ToString().Trim() + "</a></span></div>";
                    recursos += "<div class=\"col-sm-3 opcionesList\">";
                    //recursos += "<a role = \"button\" onclick =\"EditarRecurso(" + dtRecursos.Rows[i]["idRCap"].ToString().Trim() + ");\" title =\"Editar Titulo, descripción o recursos\" ><span class=\"glyphicon glyphicon-pushpin\" ></span><span>Editar</span></a>";
                    recursos += "<a role = \"button\" onclick =\"EliminarRecurso(" + dtRecursos.Rows[i]["idRCap"].ToString().Trim() + ");\" title =\"Eliminar el tema de capacitació, solo quedará registro en la base de datos\" ><span><img src = \"../../Content/img/iconHand.png\" ></span><span> Eliminar </span></a>";
                    recursos += "</div>";
                    recursos += "</div>";



    }
                recursos += "</div>";
                //Boton de evaluación
                string btn_evaluacion = "";
                if (dtGeneralEvalua.Rows.Count > 0)
                {
                    btn_evaluacion += "<div class=\"btn btn-info\" id =\"btnAñadirEvaluación\" onclick =\"javascript:CrearEvaluacion(" + id_cap+ ");\" > <span class=\"glyphicon glyphicon-plus\" ></span>Editar Evaluación</div>";
                }
                else {
                    btn_evaluacion += "<div class=\"btn btn-info\" id =\"btnAñadirEvaluación\" onclick =\"javascript:CrearEvaluacion(" + id_cap + ");\" > <span class=\"glyphicon glyphicon-plus\" ></span>Añadir Evaluación</div>";
                }
                

                outTxt += "$(\"#datosRCap\").html('" + recursos + "');$(\"#divAddEvaluacion\").html('" + btn_evaluacion + "');";

            }
            return outTxt;
        }

        public string ObtListadoCapacitacion(int id_cap)
        {
            string outTxt = "";

            DataTable dtInfo = new DataTable();
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsCapacitacion.obtRecursosCapacitacion(id_cap);
            DataTable dtCapacitacion = listaInfo[0];
            DataTable dtRecursos = listaInfo[1];

            if (dtCapacitacion.Rows.Count > 0)
            {
                string encabezado = "";
                encabezado += "<h2>" + dtCapacitacion.Rows[0]["TituloCapacitacion"].ToString().Trim() + "</h2>";
                encabezado += "<p>" + dtCapacitacion.Rows[0]["DetalleCapacitacion"].ToString().Trim() + "</p>";
                outTxt += "$(\"#divCabeceraCapt\").html('" + encabezado + "');";
            }

            if (dtRecursos.Rows.Count > 0)
            {
                //string recursos = "";
                string modulos = "";
                int contmodulo = Convert.ToInt32(dtRecursos.Rows[0]["modulo"].ToString().Trim());
                //imprimir encabezado modulo
                modulos += "<ul class=\"nav nav-tabs nav-stacked\"> ";
                modulos += "<li class=\"active\"><a data-toggle=\"tab\" href =\"#tab" + contmodulo + "\" aria-expanded=\"true\" > Módulo " + contmodulo + "<span class=\"glyphicon glyphicon-menu-right\" ></span></a></li>";

                for (int i = 0; i <= dtRecursos.Rows.Count - 1; i++)
                {

                    int auxmodulo = Convert.ToInt32(dtRecursos.Rows[i]["modulo"].ToString().Trim());
                    if (contmodulo != auxmodulo)
                    {
                        contmodulo = auxmodulo;
                        //cerrar tab anterior

                        //imprimir encabezado modulo
                        modulos += "<li class=\"\"><a data-toggle=\"tab\" href =\"#tab" + contmodulo + "\" aria-expanded=\"true\" > Módulo " + contmodulo + "<span class=\"glyphicon glyphicon-menu-right\" ></span></a></li>";
                        //abrir tab

                    }
                    // Listando recursos
                    //recursos += "<div class=\"list-group-item\"> ";
                    //recursos += "<div class=\"col-sm-2\" hidden =\"hidden\" ><p class=\"list-group-item-text\" ><a href = \"#\"> " + dtRecursos.Rows[i]["idRCap"].ToString().Trim() + " </a></p ></div>";
                    //recursos += "<div class=\"col-sm-3\" ><span>" + dtRecursos.Rows[i]["titulo"].ToString().Trim() + "</span></div>";
                    //recursos += "<div class=\"col-sm-6\" ><span><a target=\"_blank\" href =\"" + dtRecursos.Rows[i]["URL"].ToString().Trim() + "\">" + dtRecursos.Rows[i]["URL"].ToString().Trim() + "</a></span></div>";
                    //recursos += "<div class=\"col-sm-3 opcionesList\">";
                    ////recursos += "<a role = \"button\" onclick =\"EditarRecurso(" + dtRecursos.Rows[i]["idRCap"].ToString().Trim() + ");\" title =\"Editar Titulo, descripción o recursos\" ><span class=\"glyphicon glyphicon-pushpin\" ></span><span>Editar</span></a>";
                    //recursos += "<a role = \"button\" onclick =\"EliminarRecurso(" + dtRecursos.Rows[i]["idRCap"].ToString().Trim() + ");\" title =\"Eliminar el tema de capacitació, solo quedará registro en la base de datos\" ><span><img src = \"../../Content/img/iconHand.png\" ></span><span> Eliminar </span></a>";
                    //recursos += "</div>";
                    //recursos += "</div>";

                }
                contmodulo++;
                //Boton de evaluación
                modulos += "<li class=\"disabled bt1\" ><a data-toggle=\"tab\" href =\"#tab" + contmodulo + "\" aria-expanded=\"false\" > Evaluación<span class=\"glyphicon glyphicon-menu-right\" ></span></a></li>";
                modulos += "</ul>";
                outTxt += "$(\"#divModulos\").html('" + modulos + "');";
                //outTxt += "$(\"#datosRCap\").html('" + recursos + "');";
            }
            return outTxt;
        }

        public string registrarRCaptVista(int id_reccap_aux, int id_usuario_aux)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.registrarRCaptVisto(id_reccap_aux, id_usuario_aux);
            return outTxt;
        }

        ///---------------------------DIANA Y WILLIAM

        /// <summary>
        /// Función para obtener la url de un video de capacitacion
        /// </summary>
        /// <param name="nombreCapacitacion">Es el nombre de la capacitación</param>
        /// <returns>La url del video en youtube</returns>
        public string ObtenerUrlCapacitacion(string nombreCapacitacion)
        {
            return Models.clsCapacitacion.ObtenerUrlCapacitacion(nombreCapacitacion);
        }


    }
}
