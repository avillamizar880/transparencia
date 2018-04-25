using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
    public class ValoracionController
    {
        public string formato(string cadena)
        {
            return HttpUtility.HtmlEncode(cadena).Replace("\r", " ").Replace("\n", " ");
        }
        
        public DataTable listarTipoCuestionario() {
            DataTable datos = new DataTable("datos");
            List<DataTable> l_datos = Models.clsValoracion.listaTipoCuestionario();
            if (l_datos.Count > 0) { 
                datos = l_datos[0];
            }
            
            return datos;
        }
        
        public string CrearCuestionario(int id_tipo, string titulo, string descripcion, int id_usuario,string bpin_proyecto) {
            string outTxt = "";
            outTxt = Models.clsValoracion.crearCuestionario(id_tipo, titulo, descripcion, id_usuario,bpin_proyecto);
            return outTxt;
        }

        public string ModificarCuestionario(int id_cuestionario,int id_tipo, string titulo, string descripcion, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsValoracion.modificarCuestionario(id_cuestionario,id_tipo, titulo, descripcion, id_usuario);
            return outTxt;
        }

        public string insPregunta(string xml_info)
        {
            string outTxt = "";
            outTxt = Models.clsValoracion.insPregunta(xml_info);
            return outTxt;
        }
        public string modifPregunta(string xml_info,int id_pregunta)
        {
            string outTxt = "";
            outTxt = Models.clsValoracion.modifPregunta(xml_info,id_pregunta);
            return outTxt;
        }

        public string insRespuestas(string xml_info, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsValoracion.insRespuestas(xml_info, id_usuario);
            return outTxt;
        }

        public string modifRespuestas(string xml_info, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsValoracion.modifRespuestas(xml_info, id_usuario);
            return outTxt;
        }
        public string obtPreguntaById(int id_pregunta) { 
            string outTxt = "";
            List<DataTable> listado = Models.clsValoracion.obtPreguntaById(id_pregunta);
            if (listado.Count > 1) {
                DataTable dt_encabezado = listado[0];
                DataTable dt_detalle = listado[1];
                AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
                if (dt_encabezado.Rows.Count > 0) {
                    outTxt+= datos_func.convertToJson(dt_encabezado);
                }
                if (dt_detalle.Rows.Count > 0) {
                    outTxt+= "<||>" + datos_func.convertToJson(dt_detalle);
                }
               
            }
            return outTxt;

        }

        public string ObtIdCuestionarioAyuda() {
            string outTxt = "";
            List<DataTable> listado = Models.clsValoracion.obtCuestionarioAyuda();
            if (listado.Count > 1)
            {
                DataTable dtGeneral = listado[0];
                outTxt= dtGeneral.Rows[0]["idCuestionario"].ToString().Trim() + "<||>" + dtGeneral.Rows[0]["Titulo"].ToString().Trim()  + "<||>" + dtGeneral.Rows[0]["Descripcion"].ToString().Trim(); 
            }
            return outTxt;
        }

        public string obtCuestionarioAyuda() {
            string outTxt = "";
            string outPreg = "";
            List<DataTable> listado = Models.clsValoracion.obtCuestionarioAyuda();
            if (listado.Count > 1)
            {
                DataTable dtGeneral = listado[0];
                DataTable dtOpciones = listado[1];
                DataTable dtRespuestas = listado[2];
                int cant_preguntas = dtGeneral.Rows.Count;
                string titulo_cuestionario = dtGeneral.Rows[0]["Titulo"].ToString().Trim();
                string descripcion_cuestionario = dtGeneral.Rows[0]["Descripcion"].ToString().Trim();
                outTxt += "<div class=\"container encuestaView\">";
                outTxt += "<div class=\"center-block w60\">";
                outTxt += "<div class=\"card\">";
                outTxt += " <div class=\"card-block\">";
                outTxt += "<h2 class=\"card-title\">" + titulo_cuestionario + "</h2>";
                outTxt += "<h4 class=\"card-subtitle text-muted\">" + descripcion_cuestionario + "</h4>";
                outTxt += "</div>";
                for (int i = 0; i < cant_preguntas; i++)
                {
                    //encabezados preguntas datos generales
                    if (i == 0)
                    {
                        outTxt += "<div class=\"card-block\">";
                    }
                    string id_pregunta = dtGeneral.Rows[i]["idPregunta"].ToString().Trim();
                    string nom_tipo = dtGeneral.Rows[i]["nomTipoPregunta"].ToString().Trim();
                    string texto_pregunta = formato(dtGeneral.Rows[i]["textoPregunta"].ToString().Trim());
                    string texto_explicativo = formato(dtGeneral.Rows[i]["textoExplicativo"].ToString().Trim());
                    if (nom_tipo.Equals("unica_respuesta") || nom_tipo.Equals("parrafo"))
                    {
                        //texto_Corto
                        outTxt += "<div class=\"form-group\">";
                        outTxt += "<label for=\"q_" + id_pregunta + "\">" + texto_pregunta + "</label>";
                        outTxt += "<div id=\"texto_explicativo_" + id_pregunta + "\" class=\"explica alert-warning\">" + texto_explicativo + "</div>";

                        if (dtRespuestas.Rows.Count > 0) { 
                            DataRow[] result = dtRespuestas.Select("idPregunta = '" + id_pregunta + "'");
                            foreach (DataRow fila in result)
                            {
                                outTxt += "<div class=\"form-group text-justify\">";
                                outTxt += "<p>" + formato(fila["textoAbierta"].ToString()) + "</p>";
                                outTxt += "</div>";
                             }
                        }
                        outTxt += "</div>";

                    }
                    if (i == cant_preguntas - 1)
                    {
                        outTxt += "</div>";
                    }
                }
                outTxt += "</div></div></div>";
            }
            outPreg += "$(\"#divPreliminarVista\").html('" + outTxt + "');";
            return outPreg;
        }

        public string obtPreguntasCuestionario(int id_cuestionario,string opc) {
            string outTxt = "";
            string outPreg = "";
            string etiqueta_aux = "";
            string idTipoCuestionario = "";
            List<DataTable> listado = Models.clsValoracion.obtPreguntasCuestionario(id_cuestionario);
            if (listado.Count > 1) {
                DataTable dtGeneral = listado[0];
                DataTable dtOpciones = listado[1];
                DataTable dtRespuestas= new DataTable("respuestas");
                if (opc.Equals("RESPONDER")) {
                    List<DataTable> listado_respuestas = Models.clsValoracion.obtRespuestasCuestionario(id_cuestionario);
                    if (listado_respuestas.Count >= 1) {
                        dtRespuestas = listado_respuestas[0];
                    }
                }

                int cant_preguntas = dtGeneral.Rows.Count;
                if (cant_preguntas > 0) { 
                string titulo_cuestionario = dtGeneral.Rows[0]["Titulo"].ToString().Trim();
                string descripcion_cuestionario = dtGeneral.Rows[0]["Descripcion"].ToString().Trim();
                idTipoCuestionario = dtGeneral.Rows[0]["idTipoCuestionario"].ToString().Trim();
                outTxt += "<div class=\"container encuestaView\">";
                outTxt += "<div class=\"center-block w60\">";
                outTxt += "<div class=\"card\">";
                outTxt += " <div class=\"card-block\">";
                outTxt += "<h2 class=\"card-title\">" + titulo_cuestionario + "</h2>";
                outTxt += "<h4 class=\"card-subtitle text-muted\">"+ descripcion_cuestionario + "</h4>";
                outTxt += "</div>";
                }
                

                for (int i = 0; i < cant_preguntas; i++)
                {
                   //encabezados preguntas datos generales
                    if(i==0){
                      outTxt +="<div class=\"card-block\">";
                    }
                    string id_pregunta = dtGeneral.Rows[i]["idPregunta"].ToString().Trim();
                    string tipo_pregunta = dtGeneral.Rows[i]["idTipoPregunta"].ToString().Trim();
                    string nom_tipo = dtGeneral.Rows[i]["nomTipoPregunta"].ToString().Trim();
                    string obligatoria = dtGeneral.Rows[i]["Obligatoria"].ToString().Trim();
                    string id_tipo_validacion = dtGeneral.Rows[i]["idTipoValidacion"].ToString().Trim();
                    string texto_pregunta = dtGeneral.Rows[i]["textoPregunta"].ToString().Trim();
                    string texto_explicativo = dtGeneral.Rows[i]["textoExplicativo"].ToString().Trim();
                    string mensaje_error_valida= dtGeneral.Rows[i]["MensajeErrorValida"].ToString().Trim();
                    string rango_validacion = dtGeneral.Rows[i]["RangoValidacion"].ToString().Trim();
                    int cant_minima=Convert.ToInt16(dtGeneral.Rows[i]["CantMinima"].ToString().Trim());
                    int cant_maxima=Convert.ToInt16(dtGeneral.Rows[i]["CantMaxima"].ToString().Trim());
                    string etiqueta_min=dtGeneral.Rows[i]["EtiquetaMin"].ToString().Trim();
                    string etiqueta_max= dtGeneral.Rows[i]["EtiquetaMax"].ToString().Trim();
                    string valor_respuesta = "";
                    
                    string requerida = "";
                    if (!string.IsNullOrEmpty(etiqueta_min) && !string.IsNullOrEmpty(etiqueta_max)) { 
                        etiqueta_aux = "[Califique de " + etiqueta_min + " a " + etiqueta_max + "]";
                    }
                    if (obligatoria.Equals("S")) {
                        requerida = "required";
                    }else{
                      requerida="";
                    }

                    if (nom_tipo.Equals("unica_respuesta")) { 
                       //texto_Corto
                        outTxt += "<div class=\"form-group\">";
                        outTxt += "<label for=\"q_" + id_pregunta + "\" class=\"" + requerida + "\">" + texto_pregunta + "</label>";
                        outTxt += "<div id=\"texto_explicativo_" + id_pregunta + "\" class=\"explica alert-warning\">" + texto_explicativo + "</div>";
                        if (opc.Equals("EDITAR")) { 
                           outTxt += "<div class=\"row\">";
                        outTxt += "<div class=\"col-sm-10\">";
                        }
                        outTxt += "<input type=\"text\" class=\"preguntaUsu form-control\" id=\"q_" + id_pregunta + "\" placeholder=\"Su respuesta\" tipo_pregunta=\"" + tipo_pregunta + "\" tipo_valida=\"" + id_tipo_validacion + "\" obligatoria=\"" + obligatoria + "\" mensaje_error=\"" + mensaje_error_valida + "\" cant_minima=\"" + cant_minima.ToString() + "\" cant_maxima=\"" + cant_maxima.ToString() + "\" rango_valor=\"" + rango_validacion + "\" id_pregunta=\"" + id_pregunta + "\">";
                        if (opc.Equals("EDITAR"))
                        {
                            outTxt += "</div>";
                            outTxt += "<div class=\"col-sm-1 editPreg\"><a onclick=\"editar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-edit\"></span></a></div>";
                            outTxt += "<div class=\"elimPreg\"><a onclick=\"eliminar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-trash\"></span></a>";
                          outTxt += "</div>";
                        
                        }
                       
                        outTxt += "</div>";
                        outTxt += "<div id=\"error_q_" + id_pregunta + "\" class=\"alert alert-danger alert-dismissible\" hidden=\"hidden\"></div>";

                    }
                    else if (nom_tipo.Equals("unica_seleccion")) { 
                       //unica respuesta radio-buttons
                        outTxt += "<div class=\"form-group\">";
                        outTxt += "<label for=\"q_" + id_pregunta + "\" class=\"" + requerida + "\">" + texto_pregunta + "</label>";
                        outTxt += "<div id=\"texto_explicativo_" + id_pregunta + "\" class=\"explica alert-warning\">" + texto_explicativo + "</div>";
                        if (opc.Equals("EDITAR"))
                        {
                            outTxt += "<div class=\"row\">";
                            outTxt += "<div class=\"col-sm-10\">";
                        }
                        DataRow[] result = dtOpciones.Select("idPregunta = '" + id_pregunta + "'");
                        foreach (DataRow fila in result)
                        {
                            int contador_radio = 0;
                            outTxt +="<div class=\"row\">";
                            outTxt += "<div class=\"col-sm-6\"><input type=\"radio\" name=\"options_q_" + id_pregunta + "\" id=\"q_" + id_pregunta + "_" + contador_radio + "\" value=\"" + fila["idOpcionRespuestas"] + "\" class=\"form-check-input\"><span> " + fila["etiquetaOpcion"] + "</span></div>";
                            outTxt += "</div>";
                            contador_radio += 1;
                         }
                        if (opc.Equals("EDITAR"))
                        {
                            outTxt += "</div>";
                            outTxt += "<div class=\"col-sm-1 editPreg\"><a onclick=\"editar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-edit\"></span></a></div>";
                            outTxt += "<div class=\"elimPreg\"><a onclick=\"eliminar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-trash\"></span></a></div>";
                            outTxt += "</div>";

                        }
                        outTxt += "<input type=\"hidden\" class=\"preguntaUsu form-control\" id=\"q_" + id_pregunta + "\" tipo_pregunta=\"" + tipo_pregunta + "\" tipo_valida=\"" + id_tipo_validacion + "\" obligatoria=\"" + obligatoria + "\" mensaje_error=\"" + mensaje_error_valida + "\" cant_minima=\"" + cant_minima.ToString() + "\" cant_maxima=\"" + cant_maxima.ToString() + "\" rango_valor=\"" + rango_validacion + "\" id_pregunta=\"" + id_pregunta + "\">";
                        outTxt += "</div>";
                        outTxt += "<div id=\"error_q_" + id_pregunta + "\" class=\"alert alert-danger alert-dismissible\" hidden=\"hidden\"></div>";
                      
                    }
                    else if (nom_tipo.Equals("multiple_seleccion")) {
                        //multiple respuesta checkbox
                        outTxt += "<div class=\"form-group\">";
                        outTxt += "<label for=\"q_" + id_pregunta + "\" class=\"" + requerida + "\">" + texto_pregunta + "</label>";
                        outTxt += "<div id=\"texto_explicativo_" + id_pregunta + "\" class=\"explica alert-warning\">" + texto_explicativo + "</div>";
                        DataRow[] result = dtOpciones.Select("idPregunta = '" + id_pregunta + "'");
                        if (opc.Equals("EDITAR"))
                        {
                            outTxt += "<div class=\"row\">";
                            outTxt += "<div class=\"col-sm-10\">";
                        }
                        int contador = 0;
                        foreach (DataRow fila in result)
                        {
                            outTxt += "<div class=\"row\">";
                            outTxt += "<div class=\"col-sm-6\"><input type=\"checkbox\"  name=\"options_q_" + id_pregunta + "\" id=\"q_" + id_pregunta + "_" + contador + "\" class=\"form-check-input\" value=\"" + fila["idOpcionRespuestas"] + "\"><span> " + fila["etiquetaOpcion"] + "</span></div>";
                            outTxt += "</div>";
                            contador += 1;
                        }
                        if (opc.Equals("EDITAR"))
                        {
                            outTxt += "</div>";
                            outTxt += "<div class=\"col-sm-1 editPreg\"><a onclick=\"editar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-edit\"></span></a></div>";
                            outTxt += "<div class=\"elimPreg\"><a onclick=\"eliminar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-trash\"></span></a></div>";
                            outTxt += "</div>";

                        }
                        outTxt += "<input type=\"hidden\" class=\"preguntaUsu form-control\" id=\"q_" + id_pregunta + "\"  placeholder=\"Su respuesta\" tipo_pregunta=\"" + tipo_pregunta + "\" tipo_valida=\"" + id_tipo_validacion + "\" obligatoria=\"" + obligatoria + "\" mensaje_error=\"" + mensaje_error_valida + "\" cant_minima=\"" + cant_minima.ToString() + "\" cant_maxima=\"" + cant_maxima.ToString() + "\" rango_valor=\"" + rango_validacion + "\" id_pregunta=\"" + id_pregunta + "\">";
                        outTxt += "</div>";
                        outTxt += "<div id=\"error_q_" + id_pregunta + "\" class=\"alert alert-danger alert-dismissible\" hidden=\"hidden\"></div>";

                    }
                    else if (nom_tipo.Equals("parrafo")) {
                        valor_respuesta = "";
                        //texto_largo textarea
                        outTxt += "<div class=\"form-group\">";
                        outTxt += "<label for=\"q_" + id_pregunta + "\" class=\"" + requerida + "\">" + texto_pregunta + "</label>";
                        outTxt += "<div id=\"texto_explicativo_" + id_pregunta + "\" class=\"explica alert-warning\">" + texto_explicativo + "</div>";
                        if (opc.Equals("EDITAR"))
                        {
                            outTxt += "<div class=\"row\">";
                            outTxt += "<div class=\"col-sm-10\">";
                        }
                        if (dtRespuestas.Rows.Count > 0)
                        {
                            DataRow[] result = dtRespuestas.Select("idPregunta = '" + id_pregunta + "'");
                            foreach (DataRow fila in result)
                            {
                                valor_respuesta = fila["textoAbierta"].ToString();
                            }
                        }

                        outTxt += "<textarea rows=\"5\" id=\"q_" + id_pregunta + "\" class=\"preguntaUsu form-control\" placeholder=\"Su respuesta\" tipo_pregunta=\"" + tipo_pregunta + "\" tipo_valida=\"" + id_tipo_validacion + "\" obligatoria=\"" + obligatoria + "\" mensaje_error=\"" + mensaje_error_valida + "\" cant_minima=\"" + cant_minima.ToString() + "\" cant_maxima=\"" + cant_maxima.ToString() + "\" rango_valor=\"" + rango_validacion + "\" id_pregunta=\"" + id_pregunta + "\">" + valor_respuesta + "</textarea>";
                        if (opc.Equals("EDITAR"))
                        {
                            outTxt += "</div>";
                            outTxt += "<div class=\"col-sm-1 editPreg\"><a onclick=\"editar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-edit\"></span></a></div>";
                            outTxt += "<div class=\"elimPreg\"><a onclick=\"eliminar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-trash\"></span></a></div>";
                            outTxt += "</div>";

                        }
                        outTxt += "</div>";
                        outTxt += "<div id=\"error_q_" + id_pregunta + "\" class=\"alert alert-danger alert-dismissible\" hidden=\"hidden\"></div>";

                    }
                    else if (nom_tipo.Equals("escala")) { 
                         //escala rango de calificacion entre 1 y n
                        outTxt += "<div class=\"form-group singleChoise\">";
                        outTxt += "<label for=\"q_" + id_pregunta + "\" class=\"" + requerida + "\">" + texto_pregunta + " " + etiqueta_aux.Trim() + "</label>";
                        outTxt += "<div id=\"texto_explicativo_" + id_pregunta + "\" class=\"explica alert-warning\">" + texto_explicativo + "</div>";
                        if (opc.Equals("EDITAR"))
                        {
                            outTxt += "<div class=\"row\">";
                            outTxt += "<div class=\"col-sm-10\">";
                        }
                        
                        //agregar items
                        outTxt += "<div class=\"btn-group\" data-toggle=\"buttons\">";
                         for (int k=cant_minima;k<=cant_maxima;k++){
                                outTxt += "<label class=\"btn btn-default\"><input type=\"radio\" name=\"options_q_" + id_pregunta + "\" id=\"q_" + id_pregunta + "_" + k + "\" autocomplete=\"off\">" + k + "</label>";
                              }
                        outTxt += "</div>";
                        if (opc.Equals("EDITAR"))
                        {
                            outTxt += "</div>";
                            outTxt += "<div class=\"col-sm-1 editPreg\"><a onclick=\"editar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-edit\"></span></a></div>";
                            outTxt += "<div class=\"elimPreg\"><a onclick=\"eliminar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-trash\"></span></a></div>";
                            outTxt += "</div>";

                        }
                        outTxt += "<input type=\"hidden\" class=\" preguntaUsu form-control\" id=\"q_" + id_pregunta + "\" placeholder=\"Su respuesta\" tipo_pregunta=\"" + tipo_pregunta + "\" tipo_valida=\"" + id_tipo_validacion + "\" obligatoria=\"" + obligatoria + "\" mensaje_error=\"" + mensaje_error_valida + "\" cant_minima=\"" + cant_minima.ToString() + "\" cant_maxima=\"" + cant_maxima.ToString() + "\" rango_valor=\"" + rango_validacion + "\" id_pregunta=\"" + id_pregunta + "\">";
                        outTxt += "</div>";
                        outTxt += "<div id=\"error_q_" + id_pregunta + "\" class=\"alert alert-danger alert-dismissible\" hidden=\"hidden\"></div>";

                    }
                    else if (nom_tipo.Equals("fecha")) { 
                       //fecha
                        string formato_fecha = etiqueta_min;
                        if (!string.IsNullOrEmpty(formato_fecha)) {
                            if (formato_fecha.Equals("yyyy-mm-dd")) { 
                               //calendario solo fecha
                               outTxt += "<div class=\"form-group\">";
                               outTxt += "<label for=\"dtp_input2\" class=\"control-label " + requerida + "\">" + texto_pregunta + "</label>";
                               outTxt += "<div id=\"texto_explicativo_" + id_pregunta + "\" class=\"explica alert-warning\">" + texto_explicativo + "</div>";
                               if (opc.Equals("EDITAR"))
                               {
                                   outTxt += "<div class=\"row\">";
                                   outTxt += "<div class=\"col-sm-10\">";
                               }
                               outTxt += "<div class=\"col-sm-6 input-group date form_date\" data-date=\"\" data-date-format=\"dd MM yyyy\" data-link-field=\"q_" + id_pregunta + "\" data-link-format=\"yyyy-mm-dd\">";
                               outTxt += "<input class=\"form-control\" size=\"16\" type=\"text\" value=\"\" readonly>";
                               outTxt += "<span class=\"input-group-addon\"><span class=\"glyphicon glyphicon-remove\"></span></span>";
                               outTxt += "<span class=\"input-group-addon\"><span class=\"glyphicon glyphicon-calendar\"></span></span>";
                               outTxt += "</div>";
                               if (opc.Equals("EDITAR"))
                               {
                                   outTxt += "</div>";
                                   outTxt += "<div class=\"col-sm-1 editPreg\"><a onclick=\"editar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-edit\"></span></a></div>";
                                   outTxt += "<div class=\"elimPreg\"><a onclick=\"eliminar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-trash\"></span></a></div>";
                                   outTxt += "</div>";

                               }
                               outTxt += "<input type=\"hidden\" class=\"preguntaUsu form-control\" id=\"q_" + id_pregunta + "\" value=\"\" tipo_pregunta=\"" + tipo_pregunta + "\" tipo_valida=\"" + id_tipo_validacion + "\" obligatoria=\"" + obligatoria + "\" mensaje_error=\"" + mensaje_error_valida + "\" cant_minima=\"" + cant_minima.ToString() + "\" cant_maxima=\"" + cant_maxima.ToString() + "\" rango_valor=\"" + rango_validacion + "\" id_pregunta=\"" + id_pregunta + "\"><br/>";
                               
                               outTxt += "</div>";
                               outTxt += "<div id=\"error_q_" + id_pregunta + "\" class=\"alert alert-danger alert-dismissible\" hidden=\"hidden\"></div>";
                            }
                        }
                    }
                    else if (nom_tipo.Equals("tiempo")) { 
                        string formato_fecha = etiqueta_min;
                        if (!string.IsNullOrEmpty(formato_fecha))
                        {
                            outTxt += "<div class=\"form-group\">";
                            outTxt += "<label for=\"q_" + id_pregunta + "\" class=\"" + requerida + "\">" + texto_pregunta  + " [" + formato_fecha + "]</label>";
                            outTxt += "<div id=\"texto_explicativo_" + id_pregunta + "\" class=\"explica alert-warning\">" + texto_explicativo + "</div>";
                            if (opc.Equals("EDITAR"))
                            {
                                outTxt += "<div class=\"row\">";
                                outTxt += "<div class=\"col-sm-10\">";
                            }
                            outTxt += "<div class=\"row tiempo\">";
                            string[] vecFecha = formato_fecha.Split(new char[] { ':' });
                            for (int t = 0; t < vecFecha.Length; t++) {
                                if (t != vecFecha.Length-1)
                                {
                                    outTxt += "<div class=\"col-sm-2\"><input type=\"text\" class=\"form-control text-center\" id=\"q_" + id_pregunta + "_"+ t.ToString() + "\"></div><div class=\"col-sm-1 text-center\"><p>:</p></div>";
                                }
                                else {
                                    outTxt += "<div class=\"col-sm-2\"><input type=\"text\" class=\"form-control text-center\" id=\"q_" + id_pregunta + "_" + t.ToString() + "\"></div><div class=\"col-sm-1 text-center\"></div>";
                                }
                                
                            }
                              outTxt += "</div>";
                              if (opc.Equals("EDITAR"))
                              {
                                  outTxt += "</div>";
                                  outTxt += "<div class=\"col-sm-1 editPreg\"><a onclick=\"editar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-edit\"></span></a></div>";
                                  outTxt += "<div class=\"elimPreg\"><a onclick=\"eliminar_pregunta(" + "\\'" + id_pregunta + "\\'" + ");\" class=\"btn-default MT25\" role=\"button\"><span class=\"glyphicon glyphicon-trash\"></span></a></div>";
                                  outTxt += "</div>";

                              }
                              outTxt += "<input type=\"hidden\" class=\"preguntaUsu form-control text-center\" id=\"q_" + id_pregunta + "\" tipo_pregunta=\"" + tipo_pregunta + "\" tipo_valida=\"" + id_tipo_validacion + "\" obligatoria=\"" + obligatoria + "\" mensaje_error=\"" + mensaje_error_valida + "\" cant_minima=\"" + cant_minima.ToString() + "\" cant_maxima=\"" + cant_maxima.ToString() + "\" rango_valor=\"" + rango_validacion + "\" id_pregunta=\"" + id_pregunta + "\">"; 
                              outTxt += "</div>";
                              outTxt += "<div id=\"error_q_" + id_pregunta + "\" class=\"alert alert-danger alert-dismissible\" hidden=\"hidden\"></div>";
                        }
                    }
                    if (i == cant_preguntas-1) {
                        outTxt += "</div>";
                    }
                }
                if (cant_preguntas > 0) { 
                    outTxt += "<div class=\"botonera text-center\"><div id=\"divBtnEnviaRespuestas\" class=\"btn btn-primary\"><a id=\"btnEnviaRespuestas\" role=\"button\"><span class=\"glyphicon glyphicon-check\"></span> Enviar</a></div></div>";
                outTxt += "</div></div></div>";
                }

                outPreg += "$(\"#hdTipoCuestionario\").val(\'" + idTipoCuestionario + "\');";
            }
            outPreg += "$(\"#divPreliminarVista\").html('" + outTxt + "');";


            return outPreg;
        
        }


        public DataTable obtEvaluacionPosteriorBpin(string bpin_proyecto){
            DataTable dtCuestionario=new DataTable();
            List<DataTable> listado_dt = new List<DataTable>();
            listado_dt = AuditoriasCiudadanas.Models.clsValoracion.obtCuestionarioPosterior(bpin_proyecto);
            if (listado_dt.Count > 0)
            {
                dtCuestionario = listado_dt[0];
            }
            return dtCuestionario;
            
        }

        public string eliminarPregunta(int id_pregunta) {
            string outTxt = "";
            outTxt = AuditoriasCiudadanas.Models.clsValoracion.eliminarPregunta(id_pregunta);
            return outTxt;
        }
        
    }


}