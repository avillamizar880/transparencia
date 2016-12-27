$("#btnVolverListadoCalidad").click(function () {
    //accion volver a listado de publicaciones inf tecnica
});


$("#btnEditarContenidoCalidad").click(function () {
    //accion editar inf tecnica
});

$("#btnUnirseGAC").click(function () {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    var idGrupo = "";   //grupo seleccionado
    //mensaje confirmacion
    bootbox.confirm({
        title: "CREAR GAC",
        message: "¿Estás seguro que deseas crear un GAC?",
        buttons: {
            confirm: {
                label: 'Crear'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                if (id_usuario != "") {
                    //usuario registrado en session
                    ajaxPost('../Views/Usuarios/addGrupoAuditor_ajax', { bpin_proyecto: bpinProyecto, id_usuario: id_usuario, id_grupo: idGrupo }, null, function (r) {
                        if (r.indexOf("<||>") != -1) {
                            var cod_error = r.split("<||>")[0];
                            var mensaje_error = r.split("<||>")[1];
                            if (cod_error == '0') {
                                //accion exitosa
                                bootbox.alert("Grupo creado exitosamente", function () {
                                    //recargar grupos
                                    obtGACProyecto(bpinProyecto);
                                });
                            } else {
                                bootbox.alert(mensRes);
                            }
                        }

                    }, function (e) {
                        bootbox.alert(e.responseText);
                    });
                } else {
                    //redireccionar form registro usuarios
                    bootbox.alert({
                        message: "Para crear un GAC, debes estar registrado en el sistema!",
                        buttons: {
                            ok: {
                                label: 'Registrarse'
                            }
                        },
                        callback: function () {
                            goObtMenu('/Views/Usuarios/registroCiudadano');
                        }
                    });

                }
            }
        }
    });

});

$("#btnSeguirProy").click(function () {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    //mensaje confirmacion
    bootbox.confirm({
        title: "SEGUIR PROYECTO",
        message: "¿Estás seguro que deseas seguir este proyecto?",
        buttons: {
            confirm: {
                label: 'Seguir'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                if (id_usuario != "") {
                    //usuario registrado en session
                    ajaxPost('../Views/Usuarios/addSeguirProyecto_ajax', { bpin_proyecto: bpinProyecto, id_usuario: id_usuario }, null, function (r) {
                        if (r.indexOf("<||>") != -1) {
                            var cod_error = r.split("<||>")[0];
                            var mensaje_error = r.split("<||>")[1];
                            if (cod_error == '0') {
                                //accion exitosa
                                bootbox.alert("Ahora es un seguidor del proyecto " + bpinProyecto);
                            } else {
                                bootbox.alert(mensRes);
                            }
                        }

                    }, function (e) {
                        bootbox.alert(e.responseText);
                    });
                } else {
                    //redireccionar form registro usuarios
                    bootbox.alert({
                        message: "Para seguir el proyecto, debes estar registrado en el sistema!",
                        buttons: {
                            ok: {
                                label: 'Registrarse'
                            }
                        },
                        callback: function () {
                            goObtMenu('/Views/Usuarios/registroCiudadano');
                        }
                    });

                }
            }
        }
    });
});

