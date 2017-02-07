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
                        $('#ddlMunicipio').append('<option value="' + jsonData.Head[i].id_munic + '">' + jsonData.Head[i].nom_municipio + '</option>');
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
        if ($("#txtPassword").val() != $("#txtPassword_2").val()) {
            bootbox.alert("Confirmación contraseña incorrecta");
        } else {
            //validarCorreo
            if (validaEmail($('#txtEmail').val())) {
                if ($("#cb_condiciones").is(':checked')) {
                    var patron = /^\d*$/;
                    if ($("#txtCelular").val().search(patron)) {
                        bootbox.alert("Número de celular inválido");
                    } else {
                        //formulario registro
                        var params = {
                            nombre: $("#txtNombre").val(),
                            email: $("#txtEmail").val(),
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
                                alert(idUsuario);
                                params = {
                                    email: $("#txtEmail").val(),
                                    id_usuario:idUsuario
                                };
                                  if (errRes == "0") {
                                    avanzar_paso("4", params);
                                } else {
                                    bootbox.alert(mensRes);
                                }
                            }
                        }, function (r) {
                            bootbox.alert(r.responseText);
                        });


                    }

                } else {
                    bootbox.alert("Debe aceptar términos y condiciones");
                }

            } else {
                bootbox.alert("Correo electrónico inválido");
            }
        }
    }
});

$("#btnVerificaCuenta").click(function () {
    var params = {};
    avanzar_paso("4", params);
});

$("#btnCambiarClave").click(function () {
    var id_usuario = $("#hdIdUsuario").val();
    var clave_ant = encodeRFC5987ValueChars($("#txtPassword_ant").val());
    var clave_new = encodeRFC5987ValueChars($("#txtPassword").val());
    if ($("#txtPassword").val() != $("#txtPassword_2").val()) {
        bootbox.alert({
            message: "Confirmación contraseña incorrecta",
            buttons: {
                ok: {
                    label: 'Aceptar'
                }
            },
            callback: function () {
            var params = { clave_ant: clave_ant, clave_new: clave_new,id_usuario:id_usuario };
            ajaxPost('Views/Usuarios/cambioClave_ajax', params, null, function (r) {
                var errRes = r.split("<||>")[0];
                var mensRes = r.split("<||>")[1];
                if (r.indexOf("<||>") != -1) {
                    if (errRes == '0') {
                        bootbox.alert('Contraseña cambiada exitosamente.', function () {

                        });
                    } else {
                        bootbox.alert(mensRes);
                    }
                }
        }, function (r) {
            bootbox.alert(r.responseText);
        });
            }
        });
    }

});

$("#btnCrearUsuPerfil").click(function () {
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
                bootbox.alert('Usuario creado exitosamente.', function () {

                });
            } else {
                bootbox.alert(mensRes);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });

});



