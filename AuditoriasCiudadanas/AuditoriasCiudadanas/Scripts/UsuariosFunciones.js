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


function delSeguirProyecto(id_usuario,bpinProyecto) {
    //mensaje confirmacion
    bootbox.confirm({
        title: "DEJAR DE SEGUIR PROYECTO",
        message: "¿Está seguro de que desea dejar de seguir este proyecto?",
        buttons: {
            confirm: {
                label: 'Dejar de Seguir'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                if (id_usuario != "" && id_usuario != undefined) {
                    //usuario registrado en session
                    ajaxPost('../Views/Usuarios/addSeguirProyecto_ajax', { bpin_proyecto: bpinProyecto, id_usuario: id_usuario , opcion: "ELIMINAR" }, null, function (r) {
                        if (r.indexOf("<||>") != -1) {
                            var cod_error = r.split("<||>")[0];
                            var mensaje_error = r.split("<||>")[1];
                            if (cod_error == '0') {
                                //accion exitosa
                                bootbox.alert("Acción completada con éxito, ya no es un seguidor del proyecto con BPIN: " + bpinProyecto, function () {
                                    //recarga pagina perfil
                                    CuentaUsu();
                                });
                            } else {
                                bootbox.alert(mensaje_error);
                            }
                        }

                    }, function (e) {
                        bootbox.alert(e.responseText);
                    });
                } else {
                    //redireccionar form registro usuarios
                    bootbox.confirm({
                        title: "DEJAR DE SEGUIR PROYECTO",
                        message: "Para dejar de seguir el proyecto, debe estar registrado en el sistema!",
                        buttons: {
                            confirm: {
                                label: 'Registrarse'
                            },
                            cancel: {
                                label: 'Cancelar'
                            }
                        },
                        callback: function (result) {
                            if (result == true) {
                                goObtMenu('/Views/Usuarios/registroCiudadano');
                            }
                        }

                    });

                }
            }
        }
    });

}

