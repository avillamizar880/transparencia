$("#btnAddPregunta").click(function () {
    $("#divContenedorPreguntas").slideDown(function () {
       
    });
});

$('#ddlTipoPregunta').bind('change', function () {
    var val_tipo = $('option:selected', $(this)).val();
    if (val_tipo == "1") {
        $(".well").hide();
        $('#divPregTexto').show();
    } else if (val_tipo == "2") {
        $(".well").hide();
        $('#divPregRadio').show();
    } else if (val_tipo == "3") {
        $(".well").hide();
        $('#divPregCheckbox').show();
    } else if (val_tipo == "4") {
        $(".well").hide();
        $('#divPregTextArea').show();
    } else if (val_tipo == "5") {
        $(".well").hide();
        $('#divPregEscala').show();
    } else if (val_tipo == "6") {
        $(".well").hide();
        $('#divPregFecha').show();
    } else if (val_tipo == "7") {
        $(".well").hide();
        $('#divPregTiempo').show();
    } else {
        $(".well").hide();
    }
});

$('#ddlEscalaInicial').bind('change', function () {
    var sel_valor = $('option:selected', $(this)).val();
    $("#spnEscalaInicial").html(sel_valor);
});

$('#ddlEscalaFinal').bind('change', function () {
    var sel_valor = $('option:selected', $(this)).val();
    $("#spnEscalaFinal").html(sel_valor);

});

$('#chkTiempoDuracion').bind('change', function () {
    if ($(this).is(':checked')) {
        $("#textHoraDuracion").val("13:45:10");
    } else {
        $("#textHoraDuracion").val("13:45");
    }
});

$('#chkIncluirAnyo').bind('change', function () {
    if ($(this).is(':checked')) {
        $("#txtFechaEjemplo").val("2017-08-01");
    } else {
        $("#txtFechaEjemplo").val("08-01");
    }
});

$('#chkIncluirHora').bind('change', function () {
    if ($(this).is(':checked')) {
        $("#divHoraPregFecha").show();
    } else {
        $("#divHoraPregFecha").hide();
    }
});


$('#btnCrearCuestionario').bind('click', function () {
    var opc = "CREAR";
    var titulo = $("#txtTitulo").val();
    var descripcion = $("#txtDescripcion").val();
    var idTipoCuestionario = $('option:selected', $('#ddlTipoCuestionario')).val();
    var formulario = "1";
    if (idTipoCuestionario == "0") {
        $("#error_ddlTipoCuestionario").show();
        formulario = "0";
    } else { $("#error_ddlTipoCuestionario").hide(); }
    if (titulo == "") {
        $("#error_txtTitulo").show();
        formulario = "0";
    } else { $("#error_txtTitulo").hide(); }
    if (descripcion == "") {
        $("#error_txtDescripcion").show();
        formulario = "0";
    } else { $("#error_txtTitulo").hide(); }
    if (formulario == "1") {
        $("#error_ddlTipoCuestionario").hide();
        $("#error_txtTitulo").hide();
        $("#error_txtDescripcion").hide();
        var params = {id_tipo:idTipoCuestionario,titulo: titulo, descripcion: descripcion, opc: opc };
        crearCuestionario(params);
    } else {
        
        bootbox.alert("Faltan datos obligatorios");
                                
    }

});

$("#btnCrearPregunta").bind('click', function () {
    limpiar_datos();
    var id_cuestionario = $("#hdIdCuestionario").val();
    var opc = "PREG";
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
    var texto_limite = $('option:selected', $('#ddlTextoLimite')).val();
    var texto_limite_valor = $.trim($("#txtLimiteValor").val());
    var texto_error = $.trim($("#txtCampoEquivocado").val());
    var check_limite_valor = $.trim($("#txtLimiteCheck").val());
    var check_limite_longitud = $.trim($("#chkValidaDatosParrafo").val());

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
        if ($('#chkValidaDatosTexto').is(':checked')) {
            valida_datos = "S";
            if (tipo_validacion_texto == "") {
                $("#error_ddlTipo_validacion_dato").show();
                formulario_ok = "0";
            } else {
                if (tipo_validacion_texto == "1") {
                    if (texto_limite != "") {
                        if (texto_limite_valor == "") {
                            $("#error_txtLimiteValor").show();
                            formulario_ok = "0";
                        }
                    }
                }
           }
        } else { valida_datos = "N" }
    } else if (tipo_pregunta == "2") {
       


    }
    else if (tipo_pregunta == "3") {
        if ($('#chkValidaDatosCheck').is(':checked')) {
            valida_datos = "S";
            if (tipo_validacion_check == "") {
                $("#error_ddlCantidadCheckValida").show();
                formulario_ok = "0";
            } else {
                if (check_limite_valor == "") {
                    $("#error_txtLimiteCheck").show();
                    formulario_ok = "0";
                }
            }
        } else { valida_datos = "N" }

    } else if (tipo_pregunta == 4) {
        if ($('#chkValidaDatosParrafo').is(':checked')) {
            valida_datos = "S";
            if (tipo_validacion_check == "") {
                $("#error_txtLimiteParrafo").show();
                formulario_ok = "0";
            } else {
                if (check_limite_valor == "") {
                    $("#error_txtLimiteParrafo").show();
                    formulario_ok = "0";
                }
            }
        } else { valida_datos = "N" }
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
        //<opciones_respuesta>
        //<etiqueta_opcion valor=""femenino"" />
        //<etiqueta_opcion valor=""masculino"" />
        //<etiqueta_opcion valor=""otros"" />
        //</opciones_respuesta>
        //</pregunta>
        var xml_txt = "";
        xml_txt += "<pregunta>";
        xml_txt += "<id_cuestionario>" + id_cuestionario + "</id_cuestionario>";
        xml_txt += "<id_tipo_pregunta>" + tipo_pregunta + "</id_tipo_pregunta>";
        xml_txt += "<obligatoria>" + preg_obligatoria + "</obligatoria>";
        xml_txt += "<texto_pregunta>" + texto_pregunta + "</texto_pregunta>";
        xml_txt += "<texto_explicativo>" + texto_ayuda + "</texto_explicativo>";
        xml_txt += "<texto_justificacion>" + texto_justificacion + "</texto_justificacion>";
        xml_txt += "<id_tipo_validacion>" + tipo_validacion + "</id_tipo_validacion>";
        xml_txt += "<mensaje_error_valida>" + texto_error + "</mensaje_error_valida>";
        xml_txt += "<opciones_respuesta>";
        if (tipo_pregunta == "1") {
            xml_txt += "<etiqueta_opcion valor=\"" + texto_pregunta +"\"></etiqueta_opcion>";
        } else if (tipo_pregunta == "2") {
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
        crearPregunta(xml_txt);

    } else {
        bootbox.alert("Faltan datos obligatorios");
    }

});

$("#btnAgregarRadio").bind('click', function () {
    //divPregUnicaRespuesta
    var divNuevoRadio = "";
    var cantidad = $(".preg_radio").length + 1;
    divNuevoRadio += '<div class="row preg_radio"><div class="col-sm-1"><label class="form-check-label"><input type="radio" class="form-check-input"></label></div><div class="col-sm-11"><div class="form-group">';
    divNuevoRadio += '<input type="text" class="form-control" id="r_respuesta_' + cantidad + '" placeholder="Opcion de Respuesta ' + cantidad +'">';
    divNuevoRadio += '</div></div></div>';
    $("#divPregUnicaRespuesta").append($.trim(divNuevoRadio));

});

$("#btnAgregarCheck").bind('click', function () {
    //divPregUnicaRespuesta
    var divNuevoCheck = "";
    var cantidad = $(".preg_check").length + 1;
    divNuevoCheck += '<div class="row preg_check"><div class="col-sm-1"><label class="form-check-label"><input type="checkbox" class="form-check-input"></label></div><div class="col-sm-11">';
    divNuevoCheck += '<div class="form-group"><input type="text" class="form-control" id="chk_respuesta_' + cantidad + '" placeholder="Opcion de Respuesta ' + cantidad +'">';
    divNuevoCheck += '</div></div></div>';
    $("#divPregMultipleRespuesta").append($.trim(divNuevoCheck));

});

$("#btnEliminarRadio").bind('click', function () {
    //divPregUnicaRespuesta
    var divNuevoRadio = "";
    var cantidad = $(".preg_radio").length + 1;
    divNuevoRadio += '<div class="row"><div class="col-sm-1"><label class="form-check-label"><input type="radio" class="form-check-input"></label></div><div class="col-sm-11"><div class="form-group">';
    divNuevoRadio += '<input type="text" class="form-control" id="r_respuesta_' + cantidad + ' placeholder="Opcion de Respuesta ' + cantidad + '">';
    divNuevoRadio += '</div></div></div>';
    $("#divPregUnicaRespuesta").append($.trim(divNuevoRadio));

});