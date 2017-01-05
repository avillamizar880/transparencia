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
