function agregaPregRadio() {
    var divNuevoRadio = "";
    var cantidad = $(".preg_radio").length + 1;
    divNuevoRadio += '<div class="row preg_radio" id="divPregRadio_' + cantidad + '"><div class="col-sm-1"><label class="form-check-label"><input type="radio" class="form-check-input"></label></div><div class="col-sm-10"><div class="form-group">';
    divNuevoRadio += '<input type="text" class="form-control required" id="r_respuesta_' + cantidad + '" placeholder="Opcion de Respuesta ' + cantidad + '"></div></div>';
    divNuevoRadio += '<div class="col-sm-1"><a role="button" onclick="borrar_elem(\'divPregRadio_' + cantidad + '\');" class="btn btn-default MT25" role="button"><span class="glyphicon glyphicon-trash"></span></a></div>';
    divNuevoRadio += '</div>';
    $("#divPregUnicaRespuesta").append($.trim(divNuevoRadio));
}

function agregaPregCheck() {
    var divNuevoCheck = "";
    var cantidad = $(".preg_check").length + 1;
    divNuevoCheck += '<div class="row preg_check" id="divPregCheck_' + cantidad + '"><div class="col-sm-1"><label class="form-check-label"><input type="checkbox" class="form-check-input"></label></div><div class="col-sm-10">';
    divNuevoCheck += '<div class="form-group"><input type="text" class="form-control required" id="chk_respuesta_' + cantidad + '" placeholder="Opcion de Respuesta ' + cantidad + '"></div></div>';
    divNuevoCheck += '<div class="col-sm-1"><a role="button" onclick="borrar_elem(\'divPregCheck_' + cantidad + '\');" class="btn btn-default MT25" role="button"><span class="glyphicon glyphicon-trash"></span></a></div>';
    divNuevoCheck += '</div>';
    $("#divPregMultipleRespuesta").append($.trim(divNuevoCheck));
}

function editarCuestionario(params) {
    ajaxPost('../../Views/Valoracion/configuraEncuestas_ajax', params, null, function (r) {
        var codigo_error = r.split("<||>")[0];
        var mensaje = r.split("<||>")[1];
        var id_Cuestionario = r.split("<||>")[2];
        if (r.indexOf("<||>") != -1) {
            if (codigo_error == '0') {
                bootbox.alert("Cuestionario modificado exitosamente", function () {
                    //paso:2 config preguntas
                    $("#ddlTipoCuestionario").attr("disabled", "disabled");
                    $("#txtTitulo").attr("disabled", "disabled");
                    $("#txtDescripcion").attr("disabled", "disabled");
                    $("#divCrearCuestionario").hide();
                    $("#divModificarCuestionario").hide();
                    $("#divEditarCuestionario").show();
                    $("#divNuevaPregunta").show();
                });
            } else {
                bootbox.alert(mensaje);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });
}


function crearCuestionario(params) {
    ajaxPost('../../Views/Valoracion/configuraEncuestas_ajax', params, null, function (r) {
        var codigo_error = r.split("<||>")[0];
        var mensaje = r.split("<||>")[1];
        var id_Cuestionario = r.split("<||>")[2];
        if (r.indexOf("<||>") != -1) {
            if (codigo_error == '0') {
                bootbox.alert("Cuestionario creado exitosamente", function () {
                    //paso:2 config preguntas
                    $("#hdIdCuestionario").val(id_Cuestionario);
                    $("#ddlTipoCuestionario").attr("disabled", "disabled");
                    $("#txtTitulo").attr("disabled", "disabled");
                    $("#txtDescripcion").attr("disabled", "disabled");
                    $("#divCrearCuestionario").hide();
                    $("#divModificarCuestionario").hide();
                    $("#divEditarCuestionario").show();
                    $("#divNuevaPregunta").show();


                });
            } else {
                if (codigo_error == "-2") {
                    //ya existe cuestionario de ayuda creado
                    bootbox.alert(mensaje, function () {
                        $("#ddlTipoCuestionario").attr("disabled", "disabled");
                        $("#txtTitulo").attr("disabled", "disabled");
                        $("#txtDescripcion").attr("disabled", "disabled");
                        $("#divCrearCuestionario").hide();
                        $("#divModificarCuestionario").hide();
                        $("#divEditarCuestionario").show();
                        $("#divNuevaPregunta").show();

                        obtPreguntasAyuda();
                    });
                }
                
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });
}

function habilitarCuestionario(id_Cuestionario){
    $("#hdIdCuestionario").val(id_Cuestionario);
    $("#ddlTipoCuestionario").attr("disabled", "disabled");
    $("#txtTitulo").attr("disabled", "disabled");
    $("#txtDescripcion").attr("disabled", "disabled");
    $("#divCrearCuestionario").hide();
    $("#divModificarCuestionario").hide();
    $("#divEditarCuestionario").show();
    $("#divNuevaPregunta").show();

}

function limpiar_datos(opc) {
    if (opc == "all") {
        $("#error_ddlTipoCuestionario").hide();
        $("#error_txtTitulo").hide();
        $("#error_txtDescripcion").hide();
        $("#error_txtTituloPreg").hide();
        $("#error_txtAyuda").hide();
        $("#error_ddlTipoPregunta").hide();
        $("#error_ddlTipo_validacion_dato").hide();
        $("#error_txtLimiteValor").hide();
        $("#error_txtLimiteValor_final").hide();
        $("#error_divPregUnicaRespuesta").hide();
        $("#error_divPregMultipleRespuesta").hide();
        $("#error_ddlCantidadCheckValida").hide();
        $("#error_txtLimiteCheck").hide();
        $("#error_ddlValidaLongitud").hide();
        $("#error_txtLimiteParrafo").hide();
        $("#error_divPregEscala").hide();
        $("#divPregTexto").hide();
        $("#divPregRadio").hide();
        $("#divPregCheckbox").hide();
        $("#divPregTextArea").hide();
        $("#divPregEscala").hide();
        $("#divPregFecha").hide();
        $("#divPregTiempo").hide();
        $("#divBtnModificarPregunta").hide();
        $("#divBtnCancelarEdicion").hide();
        $("#help_ddlTipoPregunta_aux").html("");
    } else if (opc == "error") {
        $("#error_ddlTipoCuestionario").hide();
        $("#error_txtTitulo").hide();
        $("#error_txtDescripcion").hide();
        $("#error_txtTituloPreg").hide();
        $("#error_txtAyuda").hide();
        $("#error_ddlTipoPregunta").hide();
        $("#error_ddlTipo_validacion_dato").hide();
        $("#error_txtLimiteValor").hide();
        $("#error_txtLimiteValor_final").hide();
        $("#error_divPregUnicaRespuesta").hide();
        $("#error_divPregMultipleRespuesta").hide();
        $("#error_ddlCantidadCheckValida").hide();
        $("#error_txtLimiteCheck").hide();
        $("#error_ddlValidaLongitud").hide();
        $("#error_txtLimiteParrafo").hide();
        $("#error_divPregEscala").hide();
        $("#help_ddlTipoPregunta_aux").html("");
    } else if (opc == "datos") {
        $("#divPregTexto").hide();
        $("#divPregRadio").hide();
        $("#divPregCheckbox").hide();
        $("#divPregTextArea").hide();
        $("#divPregEscala").hide();
        $("#divPregFecha").hide();
        $("#divPregTiempo").hide();
        $("#divBtnModificarPregunta").hide();
        $("#divBtnCancelarEdicion").hide();
        $("#help_ddlTipoPregunta_aux").html("");

    }
    
}

function inhabilitar_campos() {
    $("#ddlTipo_validacion_dato").val("").attr("disabled", "disabled");
    $("#ddlTextoLimite").val("").attr("disabled", "disabled");
    $("#ddlCantidadCheckValida").val("").attr("disabled", "disabled");
    $("#ddlValidaLongitud").val("").attr("disabled", "disabled");
    $("#txtLimiteValor").val("").attr("disabled", "disabled");
    $("#txtLimiteValor_final").val("").attr("disabled", "disabled");
    $("#txtCampoEquivocado").val("").attr("disabled", "disabled");
    $("#txtLimiteCheck").val("").attr("disabled", "disabled");
    $("#txtCampoEquivocadoCheck").val("").attr("disabled", "disabled");
    $("#txtLimiteParrafo").val("").attr("disabled", "disabled");
    $("#txtCampoEquivocadoParrafo").val("").attr("disabled", "disabled");
}

function inicializarDatos(idContenedor, funEspecial) {
    var objContenedor = $('#' + idContenedor);
    $('input[type=text]', objContenedor).val('');
    $('input[type=checkbox]', objContenedor).attr('checked', false);
    $('input[type=radio]', objContenedor).attr('checked', false);
    $('select', objContenedor).val('');
    inhabilitar_campos();
    if ($.isFunction(funEspecial)) {
        funEspecial();
    }
}

function crearPregunta(xml_data) {
    $.ajax({
        type: "POST",
        contentType: "text/xml",
        url: '../../Views/Valoracion/configuraEncuestas_ajax?opc=PREG',
        processData: false,
        data: xml_data,
        success: function (r) {
            var codigo_error = r.split("<||>")[0];
            var mensaje = r.split("<||>")[1];
            if (r.indexOf("<||>") != -1) {
                if (codigo_error == '0') {
                    bootbox.alert("Pregunta registrada exitosamente", function () {
                        if ($('#ddlTipoCuestionario option:selected').val() == "2") {
                            //si es config de ayuda 
                            $("#divGenAyuda").show();
                        }
                        //deshabilitar edicion de campos
                        $("#divObtCuestionario").show();
                        $("#divContenedorPreguntas").hide();
                        limpiar_datos('all');
                        inicializarDatos('divContenedorPreguntas', function () {
                            $("#ddlEscalaInicial").val("1");
                            });

                    });
                } else {
                    bootbox.alert(mensaje);
                }
            }
        },
        error: function (response) {
            bootbox.alert(response);
        }
    });
}

function modificarPregunta(xml_data) {
    $.ajax({
        type: "POST",
        contentType: "text/xml",
        url: '../../Views/Valoracion/configuraEncuestas_ajax?opc=PREG_MODIF',
        processData: false,
        data: xml_data,
        success: function (r) {
            var codigo_error = r.split("<||>")[0];
            var mensaje = r.split("<||>")[1];
            if (r.indexOf("<||>") != -1) {
                if (codigo_error == '0') {
                    bootbox.alert("Pregunta modificada exitosamente", function () {
                        //ir nuevamente a listado
                        $("#btnObtCuestionario").trigger('click');

                    });
                } else {
                    bootbox.alert(mensaje);
                }
            }
        },
        error: function (response) {
            bootbox.alert(response);
        }
    });
}

function borrar_elem(id_elem) {
    var obj_elim = "#" + id_elem + "";
    $(obj_elim).remove();

}

function obtPreguntasCuestionario(params) {
    ajaxPost('../../Views/Valoracion/obtPreguntas_ajax', params, null, function (r) {
        var datosEvalProyecto = htmlUnescape(r);
        
        $("#divGeneralPag").slideUp(function () {
            $("#divListadoPreguntas").slideDown(function () {
                eval((datosEvalProyecto));
                $('.form_date').datetimepicker({
                    language: 'es',
                    weekStart: 1,
                    todayBtn: 1,
                    autoclose: 1,
                    todayHighlight: 1,
                    startView: 2,
                    minView: 2,
                    forceParse: 0
                });

            });
        });

    }, function (r) {
        bootbox.alert(r.responseText);
    });

}

function editar_pregunta(id_pregunta) {
    //edita pregunta en cuestionario
    ajaxPost('../Views/Valoracion/obtPreguntas_ajax', { id_pregunta: id_pregunta }, null, function (r) {

        var jsonObj_enc = r.split("<||>")[0];
        var jsonObj_det = r.split("<||>")[1];
        var jsonData = eval("(" + jsonObj_enc + ")");
        limpiar_datos('all');
        inicializarDatos('divContenedorPreguntas', function () {
            $("#ddlEscalaInicial").val("1");
        });
        $("#divListadoPreguntas").slideUp('slow',function () {
        $("#divEncabezado").hide();
        $("#divContenedorTitulo").hide();
        $("#divGeneralPag").slideDown('slow', function () {
           for (var i = 0; i < jsonData.Head.length; i++) {
               var idCuestionario = jsonData.Head[i].idCuestionario;
               var id_pregunta = jsonData.Head[i].idPregunta;
               var id_tipoCuestionario = jsonData.Head[i].idTipoCuestionario;
               var val_tipo = jsonData.Head[i].idTipoPregunta;
               var obligatoria = jsonData.Head[i].Obligatoria;
               var nom_tipo_pregunta = jsonData.Head[i].nomTipoPregunta;
               var textoPregunta = jsonData.Head[i].textoPregunta;
               var textoExplicativo = jsonData.Head[i].textoExplicativo;
               var idTipoValidacion = jsonData.Head[i].idTipoValidacion;
               var MensajeErrorValida = jsonData.Head[i].MensajeErrorValida;
               var RangoValidacion = jsonData.Head[i].RangoValidacion;
               var CantMinima = jsonData.Head[i].CantMinima;
               var CantMaxima = jsonData.Head[i].CantMaxima;
               var EtiquetaMin = jsonData.Head[i].EtiquetaMin;
               var EtiquetaMax = jsonData.Head[i].EtiquetaMax;
               $("#hdIdPregunta").val(id_pregunta);
               $("#ddlTipoPregunta").val(val_tipo);
               $("#txtTituloPreg").val(textoPregunta);
               $("#txtAyuda").val(textoExplicativo);

               if (obligatoria == "S") {
                   $("#chkObligatoria").prop("checked", true);
               } else {
                   $("#chkObligatoria").prop("checked", false);
               }

               if (val_tipo == "1") {
                   if (idTipoValidacion != "") {
                       $("#chkValidaDatosTexto").prop("checked", true);
                   } else {
                       $("#chkValidaDatosTexto").prop("checked", false);
                   }
                   if (idTipoValidacion <= 5) {
                       $("#ddlTipo_validacion_dato").val(idTipoValidacion);
                   } else if (idTipoValidacion >= 6 && idTipoValidacion <= 12) {
                       $("#ddlTipo_validacion_dato").val("1");
                       $("#ddlTextoLimite").val(idTipoValidacion);
                       if (idTipoValidacion == "11" || idTipoValidacion == "12") {
                           if (CantMinima != "" && CantMaxima != "") {
                               $("#txtLimiteValor").val(CantMinima);
                               $("#txtLimiteValor_final").val(CantMaxima);
                           }
                       } else {
                           if (RangoValidacion != "") {
                               $("#txtLimiteValor").val(RangoValidacion);
                           }
                       }
                   }
                   if (MensajeErrorValida != "") {
                       $("#txtCampoEquivocado").val(MensajeErrorValida);
                   }

                   $("#divListadoPreguntas").slideUp(function () {
                       $('#divPregTexto').show();

                   });

               } else if (val_tipo == "2") {
                   if (jsonObj_det != undefined) {
                       var jsonDataDet = eval("(" + jsonObj_det + ")");
                       for (var i = 0; i < jsonDataDet.Head.length; i++) {
                           var idOpcionRespuesta = jsonDataDet.Head[i].idOpcionRespuestas;
                           var etiquetaOpcion = jsonDataDet.Head[i].etiquetaOpcion;
                           var k = i + 1;
                           if ($("#r_respuesta_" + k).length > 0) {
                               $("#r_respuesta_" + k).val(etiquetaOpcion);
                           } else {
                               agregaPregRadio();
                               if ($("#r_respuesta_" + k).length > 0) {
                                    $("#r_respuesta_" + k).val(etiquetaOpcion);
                               }
                               
                           }
                       }
                   }
               
                   $('#divPregRadio').show();
               } else if (val_tipo == "3") {
                   if (jsonObj_det != undefined) {
                       var jsonDataDet = eval("(" + jsonObj_det + ")");
                       for (var i = 0; i < jsonDataDet.Head.length; i++) {
                           var idOpcionRespuesta = jsonDataDet.Head[i].idOpcionRespuestas;
                           var etiquetaOpcion = jsonDataDet.Head[i].etiquetaOpcion;
                           var k = i + 1;
                           if ($("#chk_respuesta_" + k).length > 0) {
                               $("#chk_respuesta_" + k).val(etiquetaOpcion);
                           } else {
                               agregaPregCheck();
                               if ($("#chk_respuesta_" + k).length > 0) {
                                   $("#chk_respuesta_" + k).val(etiquetaOpcion);
                               }

                           }
                          
                       }
                   }


                   $('#divPregCheckbox').show();
               } else if (val_tipo == "4") {
                   $('#divPregTextArea').show();
               } else if (val_tipo == "5") {
                   $('#divPregEscala').show();
               } else if (val_tipo == "6") {
                   $('#divPregFecha').show();
               } else if (val_tipo == "7") {
                   $('#divPregTiempo').show();
               } else {
                   limpiar_datos("all");
               }

           }
           $("#divBtnCrearPregunta").hide();
           $("#divBtnModificarPregunta").show();
           $("#divBtnCancelarEdicion").show();
           $("#divContenedorPreguntas").show();

           if (id_tipoCuestionario == "2") {
               //ayuda
               $('#divRespuestaObligatoria').hide();
               $('#divTipoPregunta').hide();
               $('#divPregTextArea').hide();
           }


        });
    });
         $('.form_date').datetimepicker({
             language: 'es',
             weekStart: 1,
             todayBtn: 1,
             autoclose: 1,
             todayHighlight: 1,
             startView: 2,
             minView: 2,
             forceParse: 0
         });
     }, function (r) {
         bootbox.alert(r.responseText);
     });

}

function guardarPregunta(opc,id_pregunta) {
    //var opc = "PREG";
    limpiar_datos("error");
    var id_cuestionario = $("#hdIdCuestionario").val();
    var tipo_validacion = "";
    var texto_error = "";
    var formulario_ok = "1";
    var valida_datos = "N";
    var preg_obligatoria = "N";
    var texto_pregunta = $.trim($("#txtTituloPreg").val());
    var texto_ayuda = $.trim($("#txtAyuda").val());
    var tipo_pregunta = $('option:selected',$('#ddlTipoPregunta')).val();
    if ($('#chkObligatoria').is(':checked')) {
        preg_obligatoria = "S";
    }
    var tipo_validacion_texto = $('option:selected', $('#ddlTipo_validacion_dato')).val();
    var tipo_validacion_check = $('option:selected', $('#ddlCantidadCheckValida')).val();
    var tipo_validacion_longitud = $('option:selected', $('#ddlValidaLongitud')).val();
    var texto_limite = $('option:selected', $('#ddlTextoLimite')).val();
    var texto_limite_valor = $.trim($("#txtLimiteValor").val());
    var texto_limite_valor_final = $.trim($("#txtLimiteValor_final").val());
    var campo_equivocado_corto = $.trim($("#txtCampoEquivocado").val());
    var campo_equivocado_check = $.trim($("#txtCampoEquivocadoCheck").val());
    var campo_equivocado_parrafo = $.trim($("#txtCampoEquivocadoParrafo").val());
    var check_limite_valor = $.trim($("#txtLimiteCheck").val());
    var check_limite_longitud = $.trim($("#chkValidaDatosParrafo").val());
    var escala_inicial_valor = $('option:selected', $('#ddlEscalaInicial')).val();
    var escala_final_valor = $('option:selected', $('#ddlEscalaFinal')).val();
    var incluir_fecha_anyo = "N";
    var incluir_fecha_hora = "N";
    var incluir_duracion_tiempo = "N";
    var rango_validacion = "";
    var cant_minima = "";
    var cant_maxima = "";
    var etiqueta_min = "";
    var etiqueta_max = "";

    var texto_justificacion = "";
    var opciones_pregunta = "";
    if ($("#txtTituloPreg").val() == "") {
        $("#error_txtTituloPreg").show();
        formulario_ok = "0";
    }
    if (tipo_pregunta == "") {
        $("#error_ddlTipoPregunta").show();
        formulario_ok = "0";
    }

    if (tipo_pregunta == "1") {
        //texto corto
        texto_error = campo_equivocado_corto;
        if ($('#chkValidaDatosTexto').is(':checked')) {
            valida_datos = "S";
            tipo_validacion = tipo_validacion_texto;
            if (tipo_validacion_texto == "") {
                $("#error_ddlTipo_validacion_dato").show();
                formulario_ok = "0";
            } else {
                if (tipo_validacion_texto == "1") {
                    if (texto_limite != "") {
                        tipo_validacion = texto_limite;
                        if (texto_limite == "11" || texto_limite == "12") {
                            rango_validacion = "";
                            if (texto_limite_valor == "") {
                                $("#error_txtLimiteValor").show();
                                formulario_ok = "0";
                            } else {
                                cant_minima = texto_limite_valor;
                            }
                            if (texto_limite_valor_final == "") {
                                $("#error_txtLimiteValor_final").show();
                                formulario_ok = "0";
                            } else {
                                cant_maxima = texto_limite_valor_final;
                            }

                        } else {
                            rango_validacion = $("#txtLimiteValor").val();
                            cant_minima = "";
                            cant_maxima = "";
                            if (texto_limite_valor == "") {
                                $("#error_txtLimiteValor").show();
                                formulario_ok = "0";
                            }
                        }
                    }
                } 
            }
        } else { valida_datos = "N" }
    } else if (tipo_pregunta == "2") {
        //unica seleccion-radios
        $('input[type=text]', $('#divPregUnicaRespuesta')).each(function (i, e) {
            var val1 = $(e).val();
            if (val1 == "") {
                formulario_ok = "0";
                $("#error_divPregUnicaRespuesta").show();
            } else {
                $("#error_divPregUnicaRespuesta").hide();
            }
        });
    }
    else if (tipo_pregunta == "3") {
        //multiple respuesta CHECKBOX
        texto_error = campo_equivocado_check;
        if (tipo_validacion_check == "13") {
            //al menos
            cant_minima = $("#txtLimiteCheck").val();
        } else if (tipo_validacion_check == "14") {
            //maximo
            cant_maxima = $("#txtLimiteCheck").val();
        } else {
            cant_minima = "0";
            cant_maxima = "99";
        }
        
        $('input[type=text]', $('#divPregMultipleRespuesta')).each(function (i, e) {
            var val1 = $(e).val();
            if (val1 == "") {
                formulario_ok = "0";
                $("#error_divPregMultipleRespuesta").show();
            } else {
                $("#error_divPregMultipleRespuesta").hide();
            }
        });
        if ($('#chkValidaDatosCheck').is(':checked')) {
            valida_datos = "S";
            tipo_validacion = tipo_validacion_check;
            if (tipo_validacion_check == "") {
                $("#error_ddlCantidadCheckValida").show();
                formulario_ok = "0";
            } else {
                if (check_limite_valor == "") {
                    $("#error_txtLimiteCheck").show();
                    formulario_ok = "0";
                }
            }

        } else {
            valida_datos = "N";
        }
           
    } else if (tipo_pregunta == 4) {
        //TEXTAREA parrafo
        texto_error = campo_equivocado_parrafo;
        tipo_validacion = tipo_validacion_longitud;
        if ($('#chkValidaDatosParrafo').is(':checked')) {
            valida_datos = "S";
            if (tipo_validacion_longitud == "") {
                $("#error_txtLimiteParrafo").show();
                formulario_ok = "0";
            } else {
                if (tipo_validacion_longitud == "15") {
                    //longitud minima
                    cant_minima = $("#txtLimiteParrafo").val();
                    cant_maxima = "";
                } else if (tipo_validacion_longitud == "16") {
                    //longitud maxima
                    cant_maxima = $("#txtLimiteParrafo").val();
                    cant_minima = "";
                }
            }
        } else { valida_datos = "N" }
    } else if (tipo_pregunta == 5) {
        //ESCALA
        cant_minima = escala_inicial_valor;
        cant_maxima = escala_final_valor;
        if (escala_final_valor <= escala_inicial_valor) {
            $("#error_divPregEscala").show();
            formulario_ok = "0";
        } else {
            $("#error_divPregEscala").hide();
            etiqueta_min = $("#txtEscalaInicial").val();
            etiqueta_max = $("#txtEscalaFinal").val();
        }
    } else if (tipo_pregunta == "6") {
        //FECHA AÑO MES DIA  HORA MINUTO
        if ($('#chkIncluirAnyo').is(':checked')) {
            incluir_fecha_anyo = "S";
        } else {
            incluir_fecha_anyo = "N";
        }
        if ($('#chkIncluirHora').is(':checked')) {
            incluir_fecha_hora = "S";
        } else {
            incluir_fecha_hora = "N";
        }
        
        if (incluir_fecha_anyo == "S") {
            etiqueta_min = "yyyy-mm-dd";
        } else {
            etiqueta_min = "mm-dd";
        }
        if (incluir_fecha_hora == "S") {
            etiqueta_min += " hh:mi";
        }
    } else {
        //<!--TIPO 7 HORA-->  HORA MINUTO SEGUNDO
        if ($('#chkTiempoDuracion').is(':checked')) {
            incluir_duracion_tiempo = "S";
        } else {
            incluir_duracion_tiempo = "N";
        }
        if (incluir_duracion_tiempo == "S") {
            etiqueta_min = "hh:mi:ss";
        } else {
            etiqueta_min = "hh:mi";
        }

    }
    if (formulario_ok == "1") {
        //guardar pregunta -------creacion xml-------------------------
        //<pregunta>
        //<id_cuestionario>1</id_cuestionario>
        //<id_tipo_pregunta>2</id_tipo_pregunta>
        //<obligatoria>S</obligatoria>
        //<texto_pregunta>Sexo</texto_pregunta>
        //<texto_explicativo>Elija a que sexo pertenece</texto_explicativo>
        //<texto_justificacion></texto_justificacion>
        //<id_tipo_validacion>1</id_tipo_validacion>
        //<mensaje_error_valida>Texto equivocado</mensaje_error_valida>
        //<rango_validacion></rango_validacion>
        //<cant_minima></cant_minima>
        //<cant_maxima></cant_maxima>
        //<etiqueta_min></etiqueta_min>
        //<etiqueta_max></etiqueta_max>
        //<opciones_respuesta>
        //<etiqueta_opcion valor=""femenino"" />
        //<etiqueta_opcion valor=""masculino"" />
        //<etiqueta_opcion valor=""otros"" />
        //</opciones_respuesta>
        //</pregunta>
        var xml_txt = "";
        xml_txt += "<pregunta>";
        if (opc == "PREG") {
            xml_txt += "<id_cuestionario>" + id_cuestionario + "</id_cuestionario>";
        } else if (opc == "PREG_MODIF") {
            if (id_pregunta != "") {
                    xml_txt += "<id_pregunta>" + id_pregunta + "</id_pregunta>";
            }
        }
        xml_txt += "<id_tipo_pregunta>" + tipo_pregunta + "</id_tipo_pregunta>";
        xml_txt += "<obligatoria>" + preg_obligatoria + "</obligatoria>";
        xml_txt += "<texto_pregunta>" + texto_pregunta + "</texto_pregunta>";
        xml_txt += "<texto_explicativo>" + texto_ayuda + "</texto_explicativo>";
        xml_txt += "<texto_justificacion>" + texto_justificacion + "</texto_justificacion>";
        if (tipo_validacion != "") {
            xml_txt += "<id_tipo_validacion>" + tipo_validacion + "</id_tipo_validacion>";
        }
       
        xml_txt += "<mensaje_error_valida>" + texto_error + "</mensaje_error_valida>";
        xml_txt += "<rango_validacion>" + rango_validacion + "</rango_validacion>";
        xml_txt += "<cant_minima>" + cant_minima + "</cant_minima>";
        xml_txt += "<cant_maxima>" + cant_maxima + "</cant_maxima>";
        xml_txt += "<etiqueta_min>" + etiqueta_min + "</etiqueta_min>";
        xml_txt += "<etiqueta_max>" + etiqueta_max + "</etiqueta_max>";

        xml_txt += "<opciones_respuesta>";
        if (tipo_pregunta == "2") {
            $('input[type=text]', $('#divPregUnicaRespuesta')).each(function (i, e) {
                var optText = $('#' + $(e).attr("id")).val();
                xml_txt += "<etiqueta_opcion valor=\"" + optText + "\"></etiqueta_opcion>";
            });
            
        } else if (tipo_pregunta == "3") {
            $('input[type=text]', $('#divPregMultipleRespuesta')).each(function (i, e) {
                var optText = $('#' + $(e).attr("id")).val();
                xml_txt += "<etiqueta_opcion valor=\"" + optText + "\"></etiqueta_opcion>";
            });

        }
        xml_txt += "</opciones_respuesta>";
        xml_txt += "</pregunta>";
        if (opc == "PREG") {
            crearPregunta(xml_txt);
        } else {
            modificarPregunta(xml_txt);
        }
        
    } else {
        bootbox.alert("Faltan datos obligatorios");
    }
}

function envioPreguntas_ini(params) {
    ajaxPost('../Views/Valoracion/obtPreguntas_ajax', params, null, function (r) {
        var datosEvalProyecto = htmlUnescape(r);
        eval((datosEvalProyecto));
        //deshabilitar edición de pregunta al usuario
        //$(".editPreg").hide();

        $('.form_date').datetimepicker({
            language: 'es',
            weekStart: 1,
            todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 2,
            minView: 2,
            forceParse: 0
        });
        $("#btnEnviaRespuestas").bind("click", function () {
            enviaRespuestasUsuario();

        });

    }, function (r) {
        bootbox.alert(r.responseText);
    });
}

function volverCuestionario() {
    var idCuestionario = $("#hdIdCuestionario").val();
    $("#divListadoPreguntas").slideUp(function () {
        $("#divGeneralPag").slideDown(function () {
            limpiar_datos('all');
            $("#divObtCuestionario").show();
            $("#divContenedorPreguntas").hide();
            $("#divEncabezado").show();
            $("#divContenedorTitulo").show();
            inicializarDatos('divContenedorPreguntas', function () {
                $("#ddlEscalaInicial").val("1");
            });
        });
    });

}

function enviaRespuestasUsuario() {
    var xml_info = "";
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    var id_usuario = $("#hdIdUsuario").val();
    var id_cuestionario = $("#hdIdCuestionario").val();
    var id_tipoCuestionario = $("#hdTipoCuestionario").val();
    $('.preguntaUsu', $('#divPreliminarVista')).each(function (i, e) {
        var valor_campo=$(e).val() ;
        var obligatoria = $(e).attr("obligatoria");
        var id_pregunta = $(e).attr("id_pregunta");
        var tipo_pregunta = $(e).attr("tipo_pregunta");
        var tipo_validacion = $(e).attr("tipo_valida");
        var mensaje_error = $(e).attr("mensaje_error");
        var cant_minima = $(e).attr("cant_minima");
        var cant_maxima = $(e).attr("cant_maxima");
        var rango_valor = $(e).attr("rango_valor");
        
        //validar campos obligatorios
        if (tipo_pregunta == "1") {
              //texto corto unica respuesta
              if (obligatoria != "" && obligatoria == "S") {
                  if ($(e).is(':visible') && (valor_campo == "")) {
                      $("#error_q_" + id_pregunta).html("Pregunta obligatoria, respuesta no puede ser vacía");
                      $("#error_q_" + id_pregunta).show();
                      formularioOK = false;
                      camposReq += "[" + $(e).attr("id") + "]";
                  }

              }
            } else if (tipo_pregunta == "2") {
                //unica seleccion
                //nombre empieza por options_q_
                //params += "sexo=" + ($('input[name=rbtSexoPaciente]:checked').length > 0 ? $('input[name=rbtSexoPaciente]:checked').val() : "") + "&";
                var cant_select = $('input[name=' + 'options_q_' + id_pregunta + ']:checked').length;
                if (obligatoria != "" && obligatoria == "S") {
                    if (cant_select <= 0) {
                        $("#error_q_" + id_pregunta).html("Pregunta obligatoria, respuesta no puede ser vacía");
                        $("#error_q_" + id_pregunta).show();
                        formularioOK = false;
                        camposReq += "[" + $(e).attr("id") + "]";
                    }
                }
                
            } else if (tipo_pregunta == "3") {
                //checkbox
                var cant_select = $('input[name=' + 'options_q_' + id_pregunta + ']:checked').length;
                if (obligatoria != "" && obligatoria == "S") {
                    if (cant_select <= 0) {
                        $("#error_q_" + id_pregunta).html("Pregunta obligatoria, respuesta no puede ser vacía");
                        $("#error_q_" + id_pregunta).show();
                        formularioOK = false;
                        camposReq += "[" + $(e).attr("id") + "]";
                    }
                }
                

            } else if (tipo_pregunta == "4") {
                //parrafo o texto-largo
                if (obligatoria != "" && obligatoria == "S") {
                    if ($(e).is(':visible') && ($(e).val() == "")) {
                        $("#error_q_" + id_pregunta).html("Pregunta obligatoria, respuesta no puede ser vacía");
                        $("#error_q_" + id_pregunta).show();
                        formularioOK = false;
                        camposReq += "[" + $(e).attr("id") + "]";
                    }
                }

            } else if (tipo_pregunta == "5") {
                //Escala
                var cant_select = $('input[name=' + 'options_q_' + id_pregunta + ']:checked').length;
                if (obligatoria != "" && obligatoria == "S") {
                    if (cant_select <= 0) {
                        $("#error_q_" + id_pregunta).html("Pregunta obligatoria, respuesta no puede ser vacía");
                        $("#error_q_" + id_pregunta).show();
                        formularioOK = false;
                        camposReq += "[" + $(e).attr("id") + "]";
                    }
                }
                
            } else if (tipo_pregunta == "6") {
                //fecha
                //campo oculto contiene valor
                var val_fecha = $("#q_" + id_pregunta).val();
                if (obligatoria != "" && obligatoria == "S") {
                    if (val_fecha == "") {
                        $("#error_q_" + id_pregunta).html("Pregunta obligatoria, respuesta no puede ser vacía");
                        $("#error_q_" + id_pregunta).show();
                        formularioOK = false;
                        camposReq += "[" + $(e).attr("id") + "]";
                    }
                }
           }
            else if (tipo_pregunta == "7")
            {
                //tiempo
                $("[id*=q_" + id_pregunta + "]", $('.tiempo')).each(function (i, e) {
                    var valor_aux = parseFloat($(e).val());
                    if ($(e).is(':visible')) {
                        if (obligatoria != "" && obligatoria == "S") {
                            if ($(e).val() == "") {
                                $("#error_q_" + id_pregunta).html("Pregunta obligatoria, respuesta no puede ser vacía");
                                $("#error_q_" + id_pregunta).show();
                                formularioOK = false;
                                camposReq += "[" + $(e).attr("id") + "]";
                            }
                        }
                        if ($(e).val() != "") {
                            var id_aux = $(e).attr("id").split("_")[2];
                            if (id_aux == "0") {
                                //horas
                                if (valor_aux < 0) {
                                    $("#error_q_" + id_pregunta).html("Valores incorrectos");
                                    $("#error_q_" + id_pregunta).show();
                                    formularioOK = false;
                                }

                            } else if (id_aux == "1") {
                                //minutos
                                if (valor_aux > 59 || valor_aux < 0) {
                                    $("#error_q_" + id_pregunta).html("Valores incorrectos");
                                    $("#error_q_" + id_pregunta).show();
                                    formularioOK = false;
                                }

                            } else if (id_aux == "2") {
                                //segundos
                                if (valor_aux > 59 || valor_aux < 0) {
                                    $("#error_q_" + id_pregunta).html("Valores incorrectos");
                                    $("#error_q_" + id_pregunta).show();
                                    formularioOK = false;
                                }
                            }

                        }
                   } 
                });
            }

          if (valor_campo != "") {
              //validar datos insertados
              if (tipo_validacion == "1") {
                  //numero
                      var patron = /^\d*$/;
                      if (valor_campo.search(patron)) {
                          if (mensaje_error != "") {
                              $("#error_q_" + id_pregunta).html(mensaje_error);
                          } else {
                              $("#error_q_" + id_pregunta).html("Valores incorrectos");
                          }

                          $("#error_q_" + id_pregunta).show();
                      } else {
                          //valor en un rango dado
                          if (cant_minima != "" && cant_maxima != "") {
                              if ((parseFloat(valor_campo) < parseFloat(cant_minima)) || (parseFloat(valor_campo) > parseFloat(cant_maxima))) {
                                  $("#error_q_" + id_pregunta).html(mensaje_error + " valor debe estar entre [" + cant_minima + " y " + cant_maxima + "]");
                                  $("#error_q_" + id_pregunta).show();
                                  formularioOK = false;
                              }
                          }
                      }

              } else if (tipo_validacion == "2") {
                  //alfabetico
                  var patron = /^[a-zA-Z\s]*$/;
                  if (valor_campo.search(patron)) {
                      if (mensaje_error != "") {
                          $("#error_q_" + id_pregunta).html(mensaje_error);
                      } else {
                          $("#error_q_" + id_pregunta).html("Valor incorrecto");
                      }

                      $("#error_q_" + id_pregunta).show();
                      formularioOK = false;
                  }

              } else if (tipo_validacion == "3") {
                  //alfanumerico
                  var patron = /^[A-Za-z0-9\s]*$/;
                  if (valor_campo.search(patron)) {
                      if (mensaje_error != "") {
                          $("#error_q_" + id_pregunta).html(mensaje_error);
                      } else {
                          $("#error_q_" + id_pregunta).html("Valor incorrecto");
                      }

                      $("#error_q_" + id_pregunta).show();
                      formularioOK = false;
                  }
              } else if (tipo_validacion == "4") {
                  //numero positivo
                  var patron = /^\d*$/;
                  if (valor_campo.search(patron)) {
                      if (mensaje_error != "") {
                          $("#error_q_" + id_pregunta).html(mensaje_error);
                      } else {
                          $("#error_q_" + id_pregunta).html("Valores incorrectos");
                      }

                      $("#error_q_" + id_pregunta).show();
                      formularioOK = false;
                  }
              } else if (tipo_validacion == "5") {
                  //numero negativo
                  var patron = /^[-]+[0-9]+([,][0-9]+)?$/;
                  if (!valor_campo.search(patron))
                  {
                      if (mensaje_error != "") {
                          $("#error_q_" + id_pregunta).html(mensaje_error);
                      } else {
                          $("#error_q_" + id_pregunta).html("Valores incorrectos");
                      }

                      $("#error_q_" + id_pregunta).show();
                      formularioOK = false;
                  }

              } else if (tipo_validacion == "6") {
                  //menor que
                  if (rango_valor != "") {
                      if (parseFloat(valor_campo) >= parseFloat(rango_valor)) {
                          if (mensaje_error != "") {
                              $("#error_q_" + id_pregunta).html(mensaje_error);
                          } else {
                              $("#error_q_" + id_pregunta).html("Valor debe ser menor que [" + rango_valor + "]");
                          }
                          
                          $("#error_q_" + id_pregunta).show();
                          formularioOK = false;
                      }
                  }
                  
              } else if (tipo_validacion == "7") {
                  //menor o igual que
                  if (rango_valor != "") {
                      if (parseFloat(valor_campo) > parseFloat(rango_valor)) {
                          if (mensaje_error != "") {
                              $("#error_q_" + id_pregunta).html(mensaje_error);
                          } else {
                              $("#error_q_" + id_pregunta).html("Valor debe ser menor o igual que [" + rango_valor + "]");
                          }

                          $("#error_q_" + id_pregunta).show();
                          formularioOK = false;
                      }
                  }
              } else if (tipo_validacion == "8") {
                  //mayor que
                  if (rango_valor != "") {
                      if (parseFloat(valor_campo) <= parseFloat(rango_valor)) {
                          if (mensaje_error != "") {
                              $("#error_q_" + id_pregunta).html(mensaje_error);
                          } else {
                              $("#error_q_" + id_pregunta).html("Valor debe ser mayor que [" + rango_valor + "]");
                          }

                          $("#error_q_" + id_pregunta).show();
                          formularioOK = false;
                      }
                  }
              } else if (tipo_validacion == "9") {
                  //mayor o igual que
                  if (rango_valor != "") {
                      if (parseFloat(valor_campo) < parseFloat(rango_valor)) {
                          if (mensaje_error != "") {
                              $("#error_q_" + id_pregunta).html(mensaje_error);
                          } else {
                              $("#error_q_" + id_pregunta).html("Valor debe ser mayor o igual que [" + rango_valor + "]");
                          }

                          $("#error_q_" + id_pregunta).show();
                          formularioOK = false;
                      }
                  }
              } else if (tipo_validacion == "10") {
                  //diferente a
                  if (rango_valor != "") {
                      if (valor_campo == rango_valor) {
                          if (mensaje_error != "") {
                              $("#error_q_" + id_pregunta).html(mensaje_error);
                          } else {
                              $("#error_q_" + id_pregunta).html("Valor debe diferente de [" + rango_valor + "]");
                          }
                          $("#error_q_" + id_pregunta).show();
                          formularioOK = false;
                      }

                  }
              } else if (tipo_validacion == "11") {
                  //11: entre a y b 12
                  if (cant_minima != "" && cant_maxima != "") {
                      if ((parseFloat(valor_campo) < parseFloat(cant_minima)) ||
                          (parseFloat(valor_campo) > parseFloat(cant_maxima))) {
                          $("#error_q_" + id_pregunta).html(mensaje_error + " valor debe estar entre [" + cant_minima + " y " + cant_maxima + "]");
                          $("#error_q_" + id_pregunta).show();
                          formularioOK = false;
                      }
                  }
              } else if (tipo_validacion == "12") {
                  //no esté entre a y b
                  if (cant_minima != "" && cant_maxima != "") {
                      if ((parseFloat(valor_campo) >= parseFloat(cant_minima)) && (parseFloat(valor_campo) <= parseFloat(cant_maxima))) {
                          $("#error_q_" + id_pregunta).html(mensaje_error + " valor no debe estar entre [" + cant_minima + " y " + cant_maxima + "]");
                          $("#error_q_" + id_pregunta).show();
                          formularioOK = false;
                      }
                      
                  }
                  
              }  else if (tipo_validacion == "15") {
                  //longitud minima
                  if (tipo_pregunta == "4") {
                      var longitud = valor_campo.length;
                      if (longitud < parseFloat(cant_minima)) {
                          if (mensaje_error != "") {
                              $("#error_q_" + id_pregunta).html(mensaje_error);
                          } else {
                              $("#error_q_" + id_pregunta).html("Debe tener al menos [" + cant_minima + "] caracteres");
                          }
                          $("#error_q_" + id_pregunta).show();
                          formularioOK = false;

                      }
                  }
              } else if (tipo_validacion == "16") {
                  //longitud maxima  
                  if (tipo_pregunta == "4") {
                      var longitud = valor_campo.length;
                      if (longitud > parseFloat(cant_maxima)) {
                          if (mensaje_error != "") {
                              $("#error_q_" + id_pregunta).html(mensaje_error);
                          } else {
                              $("#error_q_" + id_pregunta).html("Debe tener máximo [" + cant_maxima + "] caracteres");
                          }
                          $("#error_q_" + id_pregunta).show();
                          formularioOK = false;

                      }
                  }
              }

          }
          if (tipo_pregunta == "3") {
              if (tipo_validacion == "13") {
                  //seleccionar al menos
                      //$('input[name=options_q_84]:checked').length
                      var cant_select = $('input[name=options_q_' + id_pregunta + ']:checked').length;
                      if (cant_minima != "") {
                          if (cant_select < parseFloat(cant_minima)) {
                              if (mensaje_error != "") {
                                  $("#error_q_" + id_pregunta).html(mensaje_error);
                              } else {
                                  $("#error_q_" + id_pregunta).html("Debe seleccionar al menos [" + cant_minima + "]");
                              }
                              $("#error_q_" + id_pregunta).show();
                              formularioOK = false;
                          }
                      }

              } else if (tipo_validacion == "14") {
                  //seleccionar maximo
                      //checkbox
                  var cant_select = $('input[name=options_q_' + id_pregunta + ']:checked').length;
                  if (cant_maxima != "") {
                    if (cant_select > parseFloat(cant_maxima)) {
                          if (mensaje_error != "") {
                              $("#error_q_" + id_pregunta).html(mensaje_error);
                          } else {
                              $("#error_q_" + id_pregunta).html("Debe seleccionar máximo [" + cant_maxima + "]");
                          }
                          $("#error_q_" + id_pregunta).show();
                          formularioOK = false;
                      }

                  }
                      
              }
          }

    });
    if (formularioOK == false) {
        if (camposReq != "") {
            bootbox.alert("Faltan campos obligatorios");
        } else {
            bootbox.alert("Algunos datos son inválidos");
        }
        
    } else {
            //crear xml
            xml_info = "<respuestas>";
            xml_info += "<id_usuario>" + id_usuario + "</id_usuario>";
            xml_info += "<tipo_cuestionario>" + id_tipoCuestionario + "</tipo_cuestionario>";
            $('.preguntaUsu', $('#divPreliminarVista')).each(function (i, e) {
                var valor_campo = "";
                var opcion_respuesta = "";
                var id_pregunta = $(e).attr("id_pregunta");
                var tipo_pregunta = $(e).attr("tipo_pregunta");
                xml_info += "<registro>";
                xml_info += "<id_pregunta>" + id_pregunta + "</id_pregunta>";
                xml_info += "<opciones_respuesta>";
                if (tipo_pregunta == "1" || tipo_pregunta=="4") {
                    //texto-corto o parrafo
                    valor_campo = $(e).val();
                    xml_info += "<etiqueta_opcion/>";
                } else if (tipo_pregunta == "2" || tipo_pregunta=="5") {
                    //radio escala
                    valor_campo = "";
                    //var optText = $('input[name=' + 'q_' + id_pregunta + ']:checked').val();
                    var optText$('#' + 'q_' + id_pregunta + ' label.active input').val()

                    xml_info += "<etiqueta_opcion valor=\"" + optText + "\"></etiqueta_opcion>";
                } else if (tipo_pregunta == "3") {
                    //checkbox
                    valor_campo = "";
                   $('input[name=' + 'options_q_' + id_pregunta + ']').each(function (i,e) {
                       if ($(this).is(':checked')) {
                           var optText = $('#' + $(e).attr("id")).val();
                           xml_info += "<etiqueta_opcion valor=\"" + optText + "\"></etiqueta_opcion>";
                        }
                    });

                }else if (tipo_pregunta == "6") {
                    //fecha
                    valor_campo = $(e).val();
                    xml_info += "<etiqueta_opcion/>";
                }
                else if (tipo_pregunta == "7") {
                    //tiempo
                    var valor_campo_aux = "";
                    $("[id*=q_" + id_pregunta + "]", $('.tiempo')).each(function (i, e) {
                        var valor_aux = parseFloat($(e).val());
                        if ($(e).is(':visible')) {
                            if ($(e).val() != "") {
                                valor_campo_aux += $(e).val() + " ";
                            }
                        }
                    });
                    valor_campo = $.trim(valor_campo_aux);
                    xml_info += "<etiqueta_opcion/>";
                }
                
                xml_info += "</opciones_respuesta>";
               xml_info += "<texto_abierta>" + $.trim(valor_campo) + "</texto_abierta>";
               xml_info += "</registro>";
            });

            xml_info += "</respuestas>";
            guardarRespuestas(xml_info);
    }

}

function guardarRespuestas(xml_data) {
        $.ajax({
            type: "POST",
            contentType: "text/xml",
            url: '../../Views/Valoracion/envioEncuesta_ajax',
            processData: false,
            data: xml_data,
            success: function (r) {
                var codigo_error = r.split("<||>")[0];
                var mensaje = r.split("<||>")[1];
                if (r.indexOf("<||>") != -1) {
                    if (codigo_error == '0') {
                        bootbox.alert("Respuestas registradas exitosamente", function () {
                            //deshabilitar edicion de campos
                            $("#divBtnEnviaRespuestas").attr("disabled", "disabled");
                            $('#btnEnviaRespuestas').unbind('click');
                        });
                    } else {
                        bootbox.alert(mensaje);
                    }
                }
            },
            error: function (response) {
                bootbox.alert(response);
            }
        });
}

function obtPreguntasAyuda() {
    ajaxPost('../Views/Proyectos/preg_frecuentes_ajax', null, null, function (r) {
        var datosEvalProyecto = htmlUnescape(r);
        eval((datosEvalProyecto));

    }, function (r) {
        bootbox.alert(r.responseText);
    });
}

function eliminar_pregunta(id_pregunta) {
    //elimina pregunta en cuestionario
    var params = { id_pregunta: id_pregunta };
    ajaxPost('../../Views/Valoracion/eliminarPregunta_ajax', params, null, function (r) {
        var codigo_error = r.split("<||>")[0];
        var mensaje = r.split("<||>")[1];
            if (codigo_error == '0') {
                bootbox.alert("Pregunta eliminada exitosamente", function () {
                    //re direccionar
                    $("#btnObtCuestionario").trigger("click");
                });
            } else {
                bootbox.alert(mensaje);
            }

    }, function (r) {
        bootbox.alert(r.responseText);
    });

}