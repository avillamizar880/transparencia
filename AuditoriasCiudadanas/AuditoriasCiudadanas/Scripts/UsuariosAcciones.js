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

$("#btnAvanzarReg").click(function () {
    if ($("#txt_contrasena").val() != $("#txt_contrasena_2").val()) {
        alert("Confirmación contraseña incorrecta");
    } else {
        //validarCorreo
        if (validarEmail($('#txt_correo').val())) {
            if ($("cb_condiciones").is(':checked')) {
                //formulario registro
                ajaxPost('registroCiudadano_ajax.aspx', null, null, function (r) {
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

$("#lnkPassword").click(function () {
    //redirecciona recuperación contraseña
});
