﻿function encodeRFC5987ValueChars(str) {
    return encodeURIComponent(str).replace(/['()]/g, escape).replace(/\*/g, '%2A').replace(/%(?:7C|60|5E)/g, unescape);
}

function avanzar_paso(idpaso, params) {
    if (idpaso == "2") {
        ajaxPost('../Views/Usuarios/verificaCuenta', params, null, function (r) {
            if (r.indexOf("<||>") != -1) {
                var errRes = r.split("<||>")[0];
                var mensRes = r.split("<||>")[1];
                if (errRes == '0') {
                    //encuesta
                    avanzar_registro('3', params);
                } else {
                    alert(mensRes);
                }
            }
        }, function (r) {
            alert(r.responseText);
        });
    } else if (idPaso == "4") {
        //paso=3 mensaje inicio
        ajaxPost('../Views/Caracterizacion/EncuestaParte1', params, null, function (r) {
            avanzar_registro('4', params);
            //if (r.indexOf("<||>") != -1) {
            //    var errRes = r.split("<||>")[0];
            //    var mensRes = r.split("<||>")[1];
            //    if (errRes == '0') {
            //        //encuesta
            //        avanzar_registro('3', params);
            //    } else {
            //        alert(mensRes);
            //    }
            //}
        }, function (r) {
            alert(r.responseText);
        });

    }
}

function ver_proyecto() {
    
}


