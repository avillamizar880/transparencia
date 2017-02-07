function encodeRFC5987ValueChars(str) {
    return encodeURIComponent(str).replace(/['()]/g, escape).replace(/\*/g, '%2A').replace(/%(?:7C|60|5E)/g, unescape);
}

function avanzar_paso(id_paso, params) {
    if (id_paso == "2") {
        ajaxPost('../Views/Usuarios/verificaCuenta', params, 'dvPrincipal', function (r) {
            if (r.indexOf("<||>") != -1) {
                var errRes = r.split("<||>")[0];
                var mensRes = r.split("<||>")[1];
                if (errRes == '0') {
                    //encuesta
                    //avanzar_paso('3', params);
                } else {
                    alert(mensRes);
                }
            }
        }, function (r) {
            alert(r.responseText);
        });
    } else if (id_paso == "4") {
        //paso=3 mensaje inicio
        ajaxPost('../Views/Caracterizacion/EncuestaParte1', 'ParametroInicio', 'dvPrincipal', function (r) {
           
        }, function (r) {
            alert(r.responseText);
        });

    }
}

function ver_proyecto() {
    
}


