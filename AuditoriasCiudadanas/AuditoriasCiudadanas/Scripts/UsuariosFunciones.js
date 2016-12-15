function avanzar_registro(idpaso,params) {
    if (idpaso == "2") {
        ajaxPost('../Views/Usuarios/registroCiudadano_ajax', params, null, function (r) {
            if (r.indexOf("<||>") != -1) {
                var errRes = r.split("<||>")[0];
                var mensRes = r.split("<||>")[1];
                if (errRes == '0') {
                    alert('Usuario registrado exitosamente.', function () {
                        //encuesta
                        avanzar_registro('2', params);
                    });
                } else {
                    alert(mensRes);
                }
            }
        }, function (r) {
            alert(r.responseText);
        });
    }
}

function ver_proyecto() {
    
}


