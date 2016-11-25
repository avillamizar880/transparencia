//Previene que el backspace navegue en la página.
//$(document).unbind('keydown').bind('keydown', function (event) {
//    var doPrevent = false;
//    if (event.keyCode === 8) {
//        var d = event.srcElement || event.target;
//        if ((d.tagName.toUpperCase() === 'INPUT' && (d.type.toUpperCase() === 'TEXT' || d.type.toUpperCase() === 'PASSWORD'))
//             || d.tagName.toUpperCase() === 'TEXTAREA') {
//            doPrevent = d.readOnly || d.disabled;
//        }
//        else {
//            doPrevent = true;
//        }
//    }

//    if (doPrevent) {
//        event.preventDefault();
//    }
//});
$('#ddlDepartamento').bind('change onchange', function () {
    var params = new Object();
    params.id_departamento = "1";
    params = JSON.stringify(params);

    $.ajax({
        type: "POST",
        url: "../General/listarMunicipios.aspx",
        data: params,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            alert(data);
                if (data == null) {
                    response([{ label: "[No se encontraron resultados con el criterio seleccionado]", value: "", id_departamento: "" }]);
                } else {
                    var jsonData = eval(data);
                    for (var i = 0; i < jsonData.length; i++) {
                        $('#ddlMunicipio').append('<option value="' + jsonData.Head[i].id_munic + '">' + jsonData.Head[i].nom_municipio + '</option>');
                    }
                }
            },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });


});

function LoadCiudades(result) {
    alert(result);
    $.each(result.d, function () {
        //$("#<%=ddlCiudades.ClientID%>").append($("<option></option>").attr("value", this.cod).text(this.descripcion))

    });
}


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

$("#lnkPassword").click(function () {
    //redirecciona recuperación contraseña
});

$("#lnkRegistroUsu").click(function () {
    //redirecciona registro ciudadano
    //formulario registro
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

