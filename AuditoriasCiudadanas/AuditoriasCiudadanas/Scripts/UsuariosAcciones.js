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

$("#btnIngreso").click(function () {
    var params = { correo: $("#txtCorreo").val(), clave: $("#txtClave").val() }
    ajaxPost('validaLogin.aspx', params, null, function (r) {
        alert(r);
        var errRes = r.split("<||>")[1];
        var mensRes = r.split("<||>")[2];
        if (r.indexOf("<||>") != -1) {
            if (mensRes == 'OK') {
                //habilita menús


            } else {
                alert(mensRes);
            }
        }
    }, function (r) {
        alert(r.responseText);
    });
});

$('#ddlDepartamento').bind('change onchange', function () {
    //var params = new Object();
    //params.id_departamento = $("#ddlDepartamento option:selected").val();
    //params = JSON.stringify(params);
    //$.ajax({
    //    url: "../General/listarMunicipios.aspx",
    //    cache:false,
    //    method: "POST",
    //    data: { id_departamento: '1' },
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: function (data) {
    //            if (data == null) {
    //                response([{ label: "[No se encontraron resultados con el criterio seleccionado]", value: "", id_departamento: "" }]);
    //            } else {
    //                var jsonData = eval(data);
    //                for (var i = 0; i < jsonData.Head.length; i++) {
    //                    $('#ddlMunicipio').append('<option value="' + jsonData.Head[i].id_munic + '">' + jsonData.Head[i].nom_municipio + '</option>');
    //                }
    //            }
    //    },
    //    error: function (XMLHttpRequest, textStatus, errorThrown) {
    //        alert("error");
    //        alert(textStatus + ": " + XMLHttpRequest.responseText);
    //    }
    //});
    
    $.post("../General/listarMunicipios.aspx", function (data) {
        $(".result").html(data);
    });

   

});

$("#btnAvanzarReg").click(function () {

    if ($("#txt_contrasena").val() != $("#txt_contrasena_2").val()) {
        alert("Confirmación contraseña incorrecta");
    } else {
        //validarCorreo
        if (validaEmail($('#txt_correo').val())) {
            if ($("cb_condiciones").is(':checked')) {
                //formulario registro
                ajaxPost('registroCiudadano_ajax.aspx', null, null, function (r) {
                    alert(r);
                    var errRes = r.split("<||>")[1];
                    var mensRes = r.split("<||>")[2];
                    if (r.indexOf("<||>") != -1) {
                        if (mensRes == 'OK') {
                            alert('Usuario registrado exitosamente.', function () {
                            });
                        } else {
                            alert(mensRes);
                        }
                    }
                }, function (r) {
                    alert(r.responseText);
                });
            } else {
                alert("Debe aceptar las condiciones");
            }

        } else {
            alert("Correo electrónico inválido");
        }
    }

});

$("#btnCambiarClave").click(function () {
    ajaxPost('Views/Usuarios/cambioClave_ajax.aspx', null, null, function (r) {
        var errRes = r.split("<||>")[1];
        var mensRes = r.split("<||>")[2];
        if (r.indexOf("<||>") != -1) {
            if (mensRes == 'OK') {
                alert('Contraseña cambiada exitosamente.', function () {

                });
            } else {
                alert(mensRes);
            }
        }
    }, function (r) {
        alert(r.responseText);
    });

});



$("#lnkPassword").click(function () {
    //redirecciona recuperación contraseña
});

$("#lnkRegistroUsu").click(function () {
    //redirecciona registro ciudadano
    ajaxPost('Views/registroCiudadano.aspx', null, null, function (r) {
        var errRes = r.split("<||>")[1];
        var mensRes = r.split("<||>")[2];
        if (r.indexOf("<||>") != -1) {
            if (mensRes == 'OK') {
                alert('Usuario registrado exitosamente.', function () {
                });
            } else {
                alert(mensRes);
            }
        }
    }, function (r) {
        alert(r.responseText);
    });

});

