function registrarObsAudiencia(params) {
        ajaxPost('RegistrarObservaciones_ajax', params, null, function (r) {
            var codigo_error = r.split("<||>")[0];
            var mensaje = r.split("<||>")[1];
            if (r.indexOf("<||>") != -1) {
                if (codigo_error == '0') {
                    alert("Registro guardado exitosamente");
                } else {
                    alert(mensaje);
                }
            }
        }, function (r) {
            alert(r.responseText);
        });
}

function registrarCompromisosAud(params) {
    ajaxPost('RegistrarCompromisos_ajax', params, null, function (r) {
        var codigo_error = r.split("<||>")[0];
        var mensaje = r.split("<||>")[1];
        if (r.indexOf("<||>") != -1) {
            if (codigo_error == '0') {
                alert("Registro guardado exitosamente");
            } else {
                alert(mensaje);
            }
        }
    }, function (r) {
        alert(r.responseText);
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
