function registrarObsAudiencia(params) {
    ajaxPost('../../Views/Audiencias/InformePrevioInicio_ajax', params, null, function (r) {
            var codigo_error = r.split("<||>")[0];
            var mensaje = r.split("<||>")[1];
            if (r.indexOf("<||>") != -1) {
                if (codigo_error == '0') {
                    bootbox.alert("Registro guardado exitosamente", function () {
                        volver_listado_gestion();
                    });
                } else {
                    bootbox.alert(mensaje);
                }
            }
        }, function (r) {
            bootbox.alert(r.responseText);
        });
}




function registrarCompromisosAud(xml_data) {
    $.ajax({
        type: "POST",
        contentType: "text/xml",
        url: '../../Views/Audiencias/RegistrarCompromisos_ajax',
        processData: false,
        data: xml_data,
        success: function (r) {
            var codigo_error = r.split("<||>")[0];
            var mensaje = r.split("<||>")[1];
            if (r.indexOf("<||>") != -1) {
                if (codigo_error == '0') {
                    bootbox.alert("Compromisos guardados exitosamente", function () {
                        //deshabilitar edicion de campos
                        volver_listado_gestion();
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

function proponerFechaReuPrevias(params){
    ajaxPost('ProponerFechaReuPrevias_ajax', params, null, function (r) {
        var codigo_error = r.split("<||>")[0];
        var mensaje = r.split("<||>")[1];
        if (r.indexOf("<||>") != -1) {
            if (codigo_error == '0') {
                bootbox.alert("Registro guardado exitosamente!");

            } else {
                bootbox.alert(mensaje);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });
}

function insertarFechaAudiencia(params) {
    ajaxPost('../../Views/Audiencias/RegistrarFechaAud_ajax', params, null, function (r) {
        var codigo_error = r.split("<||>")[0];
        var mensaje = r.split("<||>")[1];
        if (r.indexOf("<||>") != -1) {
            if (codigo_error == '0') {
                bootbox.alert("Fecha registrada exitosamente", function () {
                    var id_usuario_old = $("hdIdUsuario").val();
                    inicializarDatos("divInfoAudiencia", function () {
                        $("#hdIdMunicipio").val("");
                        $("#hdIdProyecto").val("");
                        $("#hdIdUsuario").val(id_usuario_old);
                        $("#dtp_fecha").val("");
                    });
                });
            } else {
                bootbox.alert(mensaje);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });
}

function inicializarDatos(idContenedor, funEspecial) {
    var objContenedor = $('#' + idContenedor);
    $('input[type=text]', objContenedor).val('');
    $('input[type=checkbox]', objContenedor).attr('checked', false);
    $('input[type=radio]', objContenedor).attr('checked', false);
    $('select', objContenedor).val('');
    //$('.txt_asterisco', objContenedor).remove();
    if ($.isFunction(funEspecial)) {
        funEspecial();
    }
}

function registrarInformeProc(xml_data) {
    $.ajax({
        type: "POST",
        contentType: "text/xml",
        url: '../../Views/Audiencias/InformeProceso_ajax',
        processData: false,
        data: xml_data,
        success: function (r) {
            var codigo_error = r.split("<||>")[0];
            var mensaje = r.split("<||>")[1];
            if (r.indexOf("<||>") != -1) {
                if (codigo_error == '0') {
                    bootbox.alert("Informe guardado exitosamente", function () {
                        //deshabilitar edicion de campos
                        volver_listado_gestion();
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

function guardar_compromisos() {
    var opc = "";
    var rutaImagen = $("#btnNewAdjuntoCompromiso-1").val().split("\\");
    //traer xml
    if (rutaImagen == "") {
        var valida = validaFormCompromisos();
        if (valida == true) {
            opc = "NO";
            var xml_data = generar_xml_compromisos(opc);
            registrarCompromisosAud(xml_data);
        } else {
            bootbox.alert("Revise campos inválidos");
        }
        
    } else {
        $("#btnNewAdjuntoCompromiso-1").fileinput("upload");
    }
}

function validaFormCompromisos() {
    var formularioOk = true;
    $("#error_usuario").hide();
    $("#error_audiencia").hide();

    var id_audiencia = $("#hdIdAudiencia").val();
    var id_usuario_cre = $("#hdIdUsuario").val();
    if (id_audiencia == "") {
        formulario_ok = false;
        $("#error_usuario").show();
    }
    if (id_usuario_cre == "") {
        formularioOk = false;
        $("#error_audiencia").show();
    }

    return formularioOk;
}

function generar_xml_compromisos(opc) {
    ////valida info, crea xml
    var xml_txt = "";
    var xml_asistentes = "";
    var id_audiencia = $("#hdIdAudiencia").val();
    var id_usuario_cre = $("#hdIdUsuario").val();
    var num_asistentes = 0;
    
    $('.asistencia', $("#divAsistente")).each(function (i, e) {
        xml_asistentes += "<asistentes>";
            $('input,select', $(e)).each(function (ii, ee) {
                if ($(ee).attr("class").indexOf("tipo") > -1) {
                    xml_asistentes += "<id_tipo_asistente>" + $(ee).val() + "</id_tipo_asistente>";
                } else if ($(ee).attr("class").indexOf("cant") > -1) {
                    xml_asistentes += "<cantidad>" + $(ee).val() + "</cantidad>";
                    num_asistentes += parseFloat($(ee).val());
                }
            });
            xml_asistentes += "</asistentes>";
    });
    if (opc == "NO") {
        xml_txt += "<compromisos>";
    }
    xml_txt += "<num_asistentes>" + num_asistentes + "</num_asistentes><id_audiencia>" + id_audiencia + "</id_audiencia><id_usuario_cre>" + id_usuario_cre + "</id_usuario_cre>";
    $('.registro', $("#divCompromisos")).each(function (i, e) {
        xml_txt += "<registro>";
        $('input', $(e)).each(function (ii, ee) {
            if ($(ee).attr("class").indexOf("compromiso") > -1) {
                xml_txt += "<descripcion>" + $(ee).val() + "</descripcion>";
            } else if ($(ee).attr("class").indexOf("responsable") > -1) {
                xml_txt += "<responsables>" + $(ee).val() + "</responsables>";
            } else if ($(ee).attr("class").indexOf("fecha") > -1) {
                xml_txt += "<fecha_cumplimiento>" + $(ee).val() + "</fecha_cumplimiento>";
            };
        });
        xml_txt += "</registro>";
    });
    xml_txt += xml_asistentes;
    if (opc == "NO") {
        xml_txt += "</compromisos>";
    }
    return xml_txt;
    
}

//function genPdfPlantilla(url_plantilla, divPlantilla, params) {
//    $("#ifrPDFPlantilla").remove();
//    $("#frmPlantillaPDF").remove();

//    if ($('#ifrPDFPlantilla').length == 0) {
//        if (divPlantilla == "" || divPlantilla == undefined) {
//            $("body").append('<iframe id="ifrPDFPlantilla" name="ifrPDFPlantilla" width="0" height="0" style="width:0px;height:0px;float:right;"></iframe><form id="frmPlantillaPDF" name="frmPlantillaPDF" style="display:none;float:right;" target="ifrPDFPlantilla" method="POST" action="' + url_plantilla + '"></form>');
//        } else {
//            $("#" + divPlantilla).append('<iframe id="ifrPDFPlantilla" name="ifrPDFPlantilla" width="0" height="0" style="width:0px;height:0px;float:right;"></iframe><form id="frmPlantillaPDF" name="frmPlantillaPDF" style="display:none;float:right;" target="ifrPDFPlantilla" method="POST" action="' + url_plantilla + '"></form>');
//        }
//    }
//    $('#frmPlantillaPDF').children().remove();
//    $('#ifrPDFPlantilla').html('');
//    $('#frmPlantillaPDF').html('');

//    for (key in params) {
//        var valor = params[key];
//        if (valor == undefined) {
//            valor = "";
//        }
//        var hdn = $('<input type="hidden"/>');
//        hdn.attr('name', key);
//        hdn.attr('id', key);
//        hdn.val(valor);
//        $('#frmPlantillaPDF').append(hdn);
//    }
//    $('#frmPlantillaPDF').submit();
//}
    