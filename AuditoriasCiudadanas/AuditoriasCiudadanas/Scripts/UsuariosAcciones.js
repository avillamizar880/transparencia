/// <reference path="E:\AUD_CIUDADANAS\transparencia3\AuditoriasCiudadanas\AuditoriasCiudadanas\Views/General/listarMunicipios.aspx" />
/// <reference path="E:\AUD_CIUDADANAS\transparencia3\AuditoriasCiudadanas\AuditoriasCiudadanas\Views/General/listarMunicipios.aspx" />
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
    $.ajax({
        url: "../Views/General/listarMunicipios",
        cache:false,
        method: "POST",
        data: { id_departamento: $("#ddlDepartamento option:selected").val() },
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
                }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });
 });

$("#btnAvanzarReg").click(function () {
    if ($("#txtPassword").val() != $("#txtPassword_2").val()) {
        alert("Confirmación contraseña incorrecta");
    } else {
        //validarCorreo
        if (validaEmail($('#txtEmail').val())) {
            if ($("#cb_condiciones").is(':checked')) {
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
                        alert(errRes);
                        if (errRes == "0") {
                            alert("avanza_paso");
                            avanzar_paso("4", params);
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






