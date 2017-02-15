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
                    bootbox.alert(mensRes);
                }
            }
        }, function (r) {
            bootbox.alert(r.responseText);
        });
    } else if (id_paso == "4") {
        //paso=3 mensaje inicio
        ajaxPost('../Views/Caracterizacion/EncuestaParte1', 'ParametroInicio', 'dvPrincipal', function (r) {
           
        }, function (r) {
            bootbox.alert(r.responseText);
        });

    }
}

function resetearCampos(nomObj) {
    $('select,input[type=text],input[type=radio],textarea', $('#' + nomObj)).each(function (i, e) {
        var id_txt = $(e).attr("id");
        if (!$(e).hasClass('var_sesion')) {
            $(e).val("");
        }
    });

}

//evaluar si se puede eliminar
function ver_proyecto() {
    
}


function delseguir(id_usuario, codigo_bpin) {
    //dejar de seguir
    var params = { id_usuario: id_usuario, cod_bpin: codigo_bpin, opcion: 'ELIMINAR' };
    ajaxPost('../Views/Usuarios/verificaCuenta', params, null, function (r) {
        if (r.indexOf("<||>") != -1) {
            var errRes = r.split("<||>")[0];
            var mensRes = r.split("<||>")[1];
            if (errRes == '0') {
                bootbox.alert("Acción completada con éxito, ya no es seguidor del proyecto");
            } else {
                bootbox.alert(mensRes);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });
}

