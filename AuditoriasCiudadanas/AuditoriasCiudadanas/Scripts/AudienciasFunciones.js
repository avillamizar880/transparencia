function registrarObsAudiencia(params) {
    ajaxPost('../../Views/Audiencias/InformePrevioInicio_ajax', params, null, function (r) {
            var codigo_error = r.split("<||>")[0];
            var mensaje = r.split("<||>")[1];
            if (r.indexOf("<||>") != -1) {
                if (codigo_error == '0') {
                    bootbox.alert("Registro guardado exitosamente");
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
                bootbox.alert("Fecha registrada exitosamente");
            } else {
                bootbox.alert(mensaje);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });
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

function guardar_compromisos() {
    var rutaImagen = $("#btnNewAdjuntoCompromiso").val().split("\\");
    //traer xml
    if (rutaImagen == "") {
        var xml_data = generar_xml_compromisos();
        registrarCompromisosAud(xml_data);
    } else {
        $("#btnNewAdjuntoCompromiso").fileinput("upload");
    }
}

function generar_xml_compromisos() {
    ////valida info, crea xml
    var xml_txt = "";
    var id_audiencia = $("#hdIdAudiencia").val();
    var id_usuario_cre = $("#hdIdUsuario").val();
    var num_asistentes = 0;
    xml_txt += "<asistencia>";
        $('.asistentes', $("#divAsistente")).each(function (i, e) {
            xml_txt += "<asistentes>";
            $('input', $(e)).each(function (ii, ee) {
                if ($(ee).attr("class").indexOf("asistente") > -1) {
                    xml_txt += "<id_tipo_asistente>" + $(ee).val() + "</id_tipo_asistente>";
                } else if ($(ee).attr("class").indexOf("cantidad") > -1) {
                    xml_txt += "<cantidad>" + $(ee).val() + "</cantidad>";
                    num_asistentes += $(ee).val();
                }
            });
            xml_txt += "</asistentes>";
        });
    xml_txt += "</asistencia>";

    xml_txt += "<compromisos><num_asistentes>" + num_asistentes + "</num_asistentes><id_audiencia>" + id_audiencia + "</id_audiencia><id_usuario_cre>" + id_usuario_cre + "</id_usuario_cre>";
    $('.registro', $("#divCompromisos")).each(function (i, e) {
        xml_txt += "<registro>";
        $('input', $(e)).each(function (ii, ee) {
            if ($(ee).attr("class").indexOf("compromiso") > -1) {
                xml_txt += "<descripcion>" + $(ee).val() + "</descripcion>";
            } else if ($(ee).attr("class").indexOf("responsable") > -1) {
                xml_txt += "<responsables>" + $(ee).val() + "</responsables>";
            } else {
                xml_txt += "<fecha_cumplimiento>" + $(ee).val() + "</fecha_cumplimiento>";
            };
        });
        xml_txt += "</registro>";
    });
    xml_txt += "</compromisos>";
    return xml_txt;
    //registrarCompromisosAud(xml_txt);

    
}
    
    