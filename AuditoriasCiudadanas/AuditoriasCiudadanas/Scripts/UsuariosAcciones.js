$("#btnAvanzarReg").click(function () {
    if ($("#txt_contrasena").val() != $("#txt_contrasena_2").val()) {
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
            alert("Correo electrónico inválido");
        }
    }

});