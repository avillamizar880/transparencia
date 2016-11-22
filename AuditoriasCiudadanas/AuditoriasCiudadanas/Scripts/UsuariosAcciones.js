$("#btnAvanzarReg").click(function () {
    var estadoForm = "0";
    if ($("#txt_contrasena").val() != $("#txt_contrasena_2").val()) {
        estado = "1";
        alert("Confirmación contraseña incorrecta");
    } else {
        //validarCorreo
        if (validarEmail($('#txt_correo').val())) {
            //formulario registro
            ajaxPost('registroCiudadano_ajax.aspx', null, null, function (r) {
                var errRes = r.split("<||>")[1];
                var mensRes = r.split("<||>")[2];
                if (r.indexOf("<||>") != -1) {
                    if (mensRes == 'OK') {
                        jsycAlert('Usuario registrado exitósamente.', function () {
                        });
                    } else {
                        jsycAlert(mensRes);
                    }
                }
            }, function (r) {
                alert(r.responseText);
            });

        } else {
            alert("Correo electrónico inválido");
        }
    }

});