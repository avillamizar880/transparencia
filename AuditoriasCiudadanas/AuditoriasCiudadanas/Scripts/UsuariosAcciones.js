//Previene que el backspace navegue en la página.
$(document).unbind('keydown').bind('keydown', function (event) {
    var doPrevent = false;
    if (event.keyCode === 8) {
        var d = event.srcElement || event.target;
        if ((d.tagName.toUpperCase() === 'INPUT' && (d.type.toUpperCase() === 'TEXT' || d.type.toUpperCase() === 'PASSWORD'))
             || d.tagName.toUpperCase() === 'TEXTAREA') {
            doPrevent = d.readOnly || d.disabled;
        }
        else {
            doPrevent = true;
        }
    }

    if (doPrevent) {
        event.preventDefault();
    }
});


$('#ddlDepartamento').bind('change onchange', function () {
    var id_departamento = $("#ddlDepartamento option:selected").val();
    $.ajax({
        url: "../Views/General/listarMunicipios",
        cache:false,
        method: "POST",
        data: { id_departamento: id_departamento },
        dataType: "json",

        success: function (data) {
                if (data == null || data=="") {
                    response([{ label: "[No se encontraron resultados con el criterio seleccionado]", value: "", id_departamento: "" }]);
                } else {
                    var jsonData = eval(data);
                    $("#ddlMunicipio option[value!='0']").remove();
                    for (var i = 0; i < jsonData.Head.length; i++) {
                        $('#ddlMunicipio').append('<option divipola="' + jsonData.Head[i].idDivipola + '" value="' + jsonData.Head[i].id_munic + '">' + jsonData.Head[i].nom_municipio + '</option>');
                    }
                    if (id_departamento == "11") {
                        //si es bogotá, cargue municipio bogotá
                        $('#ddlMunicipio').val("001");
                    }
                }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });
 });

$("#btnAvanzarReg").click(function () {
    var valido = true;
    //valida campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divInfoUsu')).each(function (i, e) {
        var id_txt = $(e).attr("for");
       if ($("#" + id_txt).val() == "" || $('#' + id_txt +' option:selected').val()=="0") {
            camposReq += "[" + id_txt + "]";
            $("#error_" + id_txt).show();
            formularioOK = false;
        } else {
            $("#error_" + id_txt).hide();
        }
    });

    if (formularioOK == false) {
        if (camposReq != "") {
            bootbox.alert("Faltan campos obligatorios");
        }
    } else {
        //valida formato de campos digitados
        //valida nombre
        if (validaAlfabetico($("#txtNombre").val()) == false) {
            valido = false;
            $("#error_txtNombre_Formato").show();
        }
        //valida correo
        if (validaEmail($('#txtEmail').val())==false) {
            valido = false;
            $("#error_txtEmail_Formato").show();
        }
        //valida celular
        if ($("#txtCelular").val() != "") {
            if (validaCelular($("#txtCelular").val()) == false) {
                valido = false;
                $("#error_txtCelular_Formato").show();
             }
        }
        
        //si todo esta ok
        if (valido == true) {
            if ($("#txtPassword").val() != $("#txtPassword_2").val()) {
                valido = false;
                $("#error_txtPassword_2_Formato").show();
            } else {
                if (validaClaveUsu($("#txtPassword").val()) == false) {
                    valido = false;
                    $("#error_txtPassword_Formato").show();
                }
            }
        }
        if (valido == false) {
            bootbox.alert("Revise campos inválidos");
        } else {
            if ($("#cb_condiciones").is(':checked')) {
                //formulario registro
                var params = {
                    nombre: $("#txtNombre").val(),
                    email:$('#txtEmail').val(),
                    celular: $("#txtCelular").val(),
                    hash_clave: $("#txtPassword").val(),
                    id_departamento: $("#ddlDepartamento option:selected").val(),
                    id_municipio: $("#ddlMunicipio option:selected").val()
                };
                ajaxPost('../Views/Usuarios/registroCiudadano_ajax', params, null, function (r) {
                    if (r.indexOf("<||>") != -1) {
                        var errRes = r.split("<||>")[0];
                        var mensRes = r.split("<||>")[1];
                        var idUsuario = r.split("<||>")[2];
                        params = {
                            email: $("#txtEmail").val(),
                            id_usuario: idUsuario
                        };
                        if (errRes == "0") {
                            avanzar_paso("2", params);
                            //avanzar_paso("4", params);
                        } else {
                            bootbox.alert(mensRes);
                        }
                    }
                }, function (r) {
                    bootbox.alert(r.responseText);
                });

            } else {
                bootbox.alert("Debe aceptar términos y condiciones");
            }
        }

    }
});

function validaClaveUsu(cadena) {
    //que tenga mayusculas, numeros,de 8 digitos al menos
    var clave = new RegExp(/^(?=(?:.*\d){1})(?=(?:.*[A-Z]){1})\S{8,}$/);
    var valida = clave.test(cadena);
    return valida;
}

function validaAlfabetico(cadena) {
    var expreg = new RegExp(/^[a-zA-Z\sáéíóúñÁÉÍÓÚÑäëïöüÿÄËÏÖÜ]+$/);
    var valida = expreg.test(cadena);
    return valida;
}

function validaCelular(cadena) {
    var expreg = new RegExp(/^[0-9]{10}$/);
    var valida = expreg.test(cadena);
    return valida;
}

//$("#btnVerificaCuenta").click(function () {
//    var params = {};
//    avanzar_paso("4", params);
//});

$("#btnCambiarClave").click(function () {
    var id_usuario = $("#hdIdUsuario").val();
    var clave_ant = encodeRFC5987ValueChars($("#txtPassword_ant").val());
    var clave_new = encodeRFC5987ValueChars($("#txtPassword").val());

    var valida = validaCamposObligatorios("divCambioClave");
    if (valida==true) {
        if ($("#txtPassword").val() != $("#txtPassword_2").val()) {
            bootbox.alert({
                message: "Confirmación contraseña incorrecta",
                buttons: {
                    ok: {
                        label: 'Aceptar'
                    }
                },
                callback: function () {

                }
            });
        } else {
            if (validaClaveUsu($("#txtPassword").val()) == false) {
                bootbox.alert("La contraseña debe tener mayúsculas, números y una longitud mínima de 8 digitos");
            } else {
                var params = { clave_ant: clave_ant, clave_new: clave_new, id_usuario: id_usuario };
                ajaxPost('Views/Usuarios/cambioClave_ajax', params, null, function (r) {
                    var errRes = r.split("<||>")[0];
                    var mensRes = r.split("<||>")[1];
                    if (r.indexOf("<||>") != -1) {
                        if (errRes == '0') {
                            bootbox.alert('Contraseña cambiada exitosamente.', function () {
                                location.reload();
                            });
                        } else {
                            bootbox.alert(mensRes);
                        }
                    }
                }, function (r) {
                    bootbox.alert(r.responseText);
                });

            }

        }
    } else {
        bootbox.alert("Faltan campos obligatorios");
    }




});

$("#btnCrearUsuPerfil").click(function () {
    //validar campos obligatorios
    //valida campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divInfoUsuario')).each(function (i, e) {
        var id_txt = $(e).attr("for");
        if ($("#" + id_txt).val() == "" || $('#' + id_txt +' option:selected').val()=="0") {
            camposReq += "[" + id_txt + "]";
            $("#error_" + id_txt).show();
            formularioOK = false;
        } else {
            $("#error_" + id_txt).hide();
        }
    });

    if (formularioOK == false) {
        if (camposReq != "") {
            bootbox.alert("Faltan campos obligatorios");
        }
    } else {
            //validarCorreo
        if (validaEmail($('#txtEmail').val())) {
            var patron = /^\d*$/;
            if ($("#txtCelular").val().search(patron)) {
                bootbox.alert("Número de celular inválido");
            } else {
                //guarda registro en bd
                var params = {
                    nombre: $("#txtNombre").val(),
                    email: $("#txtEmail").val(),
                    celular: $("#txtCelular").val(),
                    id_perfil: $("#ddlPerfil option:selected").val()
                };

                ajaxPost('Views/Usuarios/crearUsuarios_ajax', params, null, function (r) {
                    var errRes = r.split("<||>")[0];
                    var mensRes = r.split("<||>")[1];
                    if (r.indexOf("<||>") != -1) {
                        if (errRes == '0') {
                            bootbox.alert('Usuario creado exitosamente. Se enviaron instrucciones de verificación al correo registrado', function () {
                                resetearCampos("divInfoUsuario");
                            });
                        } else {
                            bootbox.alert("@Error: " + mensRes);
                        }
                    }
                }, function (r) {
                    bootbox.alert(r.responseText);
                });
            }
        } else {
            bootbox.alert("Correo electrónico inválido");
        }

    }

    

});


$("#btnEnviaCodigoClave").click(function () {
    //validar campos obligatorios
    //valida campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divInfoUsuario')).each(function (i, e) {
        var id_txt = $(e).attr("for");
        if ($("#" + id_txt).val() == "" || $('#' + id_txt + ' option:selected').val() == "0") {
            camposReq += "[" + id_txt + "]";
            $("#error_" + id_txt).show();
            formularioOK = false;
        } else {
            $("#error_" + id_txt).hide();
        }
    });

    if (formularioOK == false) {
        if (camposReq != "") {
            bootbox.alert("Faltan campos obligatorios");
        }
    } else {
        //validarCorreo
        if (validaEmail($('#txtEmail').val())) {
                //guarda registro en bd
                var params = {
                    email: $("#txtEmail").val(),
                 };

                ajaxPost('Views/Usuarios/olvidoClave_ajax', params, 'dvPrincipal', function (r) {

                }, function (r) {
                    bootbox.alert(r.responseText);
                });

        } else {
            bootbox.alert("Correo electrónico inválido");
        }

    }



});


$("#btnVerificaCodigoClave").click(function () {
    //validar campos obligatorios
    //valida campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divInfoUsuario')).each(function (i, e) {
        var id_txt = $(e).attr("for");
        if ($("#" + id_txt).val() == "" || $('#' + id_txt + ' option:selected').val() == "0") {
            camposReq += "[" + id_txt + "]";
            $("#error_" + id_txt).show();
            formularioOK = false;
        } else {
            $("#error_" + id_txt).hide();
        }
    });

    if (formularioOK == false) {
        if (camposReq != "") {
            bootbox.alert("Faltan campos obligatorios");
        }
    } else {
        //validarCorreo
        //guarda registro en bd
        var params = {
            codigo: $("#txtCodigoVerifica").val(),
            id_usuario: $("#hdIdUsuario").val()

        };
        ajaxPost('Views/Usuarios/verificaCodigo_ajax', params, null, function (r) {
            var errRes = r.split("<||>")[0];
            var mensRes = r.split("<||>")[1];
            if (r.indexOf("<||>") != -1) {
                if (errRes == '0') {
                    //redirecciona cambio clave
                    ajaxPost('Views/Usuarios/restablecerPassword', params, 'dvPrincipal', function (r) {

                    }, function (r) {
                        bootbox.alert(r.responseText);
                    }
        );

                } else {
                    bootbox.alert("@Error: " + mensRes);
                }
            }
        }, function (r) {
            bootbox.alert(r.responseText);
        });
    }
});

$("#btnCambiarClaveOlvido").click(function () {
    //validar campos obligatorios
    //valida campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divInfoUsuario')).each(function (i, e) {
        var id_txt = $(e).attr("for");
        if ($("#" + id_txt).val() == "" || $('#' + id_txt + ' option:selected').val() == "0") {
            camposReq += "[" + id_txt + "]";
            $("#error_" + id_txt).show();
            formularioOK = false;
        } else {
            $("#error_" + id_txt).hide();
        }
    });

    if (formularioOK == false) {
        if (camposReq != "") {
            bootbox.alert("Faltan campos obligatorios");
        }
    } else {
        if ($("#txtPassword").val() != $("#txtPassword_2").val()) {
            bootbox.alert("Verifique los datos: Confirmación de nueva clave incorrecta");
            
        } else {
            //formato clave
            if (validaClaveUsu($("#txtPassword").val() == false)) {
                bootbox.alert("La contraseña debe tener mayúsculas, números y una longitud mínima de 8 digitos");
            } else {

            //guarda registro en bd
            var params = {
                clave_new: $("#txtPassword").val(),
                id_usuario: $("#hdIdUsuario").val()

            };

            ajaxPost('Views/Usuarios/restablecerPassword_ajax', params, null, function (r) {
                var errRes = r.split("<||>")[0];
                var mensRes = r.split("<||>")[1];
                var url_redirecciona = '\"' + r.split("<||>")[2] + '\"';
                if (r.indexOf("<||>") != -1) {
                    if (errRes == '0') {
                        bootbox.alert('Nueva clave guardada exitosamente', function () {
                            location.reload();
                        });
                    } else {
                        bootbox.alert("@Error: " + mensRes);
                    }
                }
            }, function (r) {
                bootbox.alert(r.responseText);
            }
            );

            }


        }

    }
});

$("#btnActualizarDatos").click(function () {
    //validar campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    var valida = true;
    $(".alert-danger").hide();
    $('.required', $('#divInfoUsuario')).each(function (i, e) {
        var id_txt = $(e).attr("for");
        if ($("#" + id_txt).val() == "" || $('#' + id_txt + ' option:selected').val() == "0") {
            camposReq += "[" + id_txt + "]";
            $("#error_" + id_txt).show();
            formularioOK = false;
        } else {
            if (parseFloat($("#" + id_txt).val()) == 0 || parseFloat($('#' + id_txt + ' option:selected').val()) == 0) {
                camposReq += "[" + id_txt + "]";
                $("#error_" + id_txt).show();
                formularioOK = false;
            } else {
                $("#error_" + id_txt).hide();
            }
            
        }
    });

    if (formularioOK == false) {
        if (camposReq != "") {
            bootbox.alert("Faltan campos obligatorios");
        }
    } else {
        //valida formato datos
        var divipola = $("#ddlMunicipio option:selected").attr("divipola");
        var nombre = $("#txtNombre").val();
        var celular = $("#txtCelular").val();
        if (validaAlfabetico(nombre) == false) {
            valida = false;
            $("#error_txtNombre_Formato").show();
        }
        if (celular != "") {
            if (validaCelular(celular) == false) {
                valida = false;
                $("#error_txtCelular_Formato").show();
            }
        }
        if (valida == true) {
            //guarda registro en bd
            var params = {
                id_usuario: $("#hdIdUsuario").val(),
                nombre: nombre,
                correo: $("#txtEmail").val(),
                celular: celular,
                id_divipola: divipola

            };
            ajaxPost('Views/Usuarios/actualizaDatos_ajax', params, null, function (r) {
                var errRes = r.split("<||>")[0];
                var mensRes = r.split("<||>")[1];
                if (r.indexOf("<||>") != -1) {
                    if (errRes == '0') {
                        bootbox.alert("Datos modificados exitosamente", function () {
                            location.reload();
                            nombre = nombre.split(" ")[0].toUpperCase();
                            $.cookie("usrName", nombre);

                        });

                    } else {
                        bootbox.alert("@Error: " + mensRes);
                    }
                }
            }, function (r) {
                bootbox.alert(r.responseText);
            });

        } else {
            bootbox.alert("Revise campos inválidos");
        }

    }
});

$("#btnVolverProy").click(function () {
    cargaMenu('AccesoInformacion/BuscadorProyectosAuditores', 'dvPrincipal');
});