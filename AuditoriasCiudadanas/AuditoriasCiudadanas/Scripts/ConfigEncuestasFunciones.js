function crearCuestionario(params) {
    ajaxPost('../../Views/Valoracion/configuraEncuestas_ajax', params, null, function (r) {
        var codigo_error = r.split("<||>")[0];
        var mensaje = r.split("<||>")[1];
        var id_Cuestionario = r.split("<||>")[2];
        if (r.indexOf("<||>") != -1) {
            if (codigo_error == '0') {
                bootbox.alert("Cuestionario creado exitosamente", function () {
                    //paso:2 config preguntas
                    $("#hdIdCuestionario").val(id_Cuestionario);
                    $("#ddlTipoCuestionario").attr("disabled", "disabled");
                    $("#txtTitulo").attr("disabled", "disabled");
                    $("#txtDescripcion").attr("disabled", "disabled");
                    $("#divNuevaPregunta").show();
                });
            } else {
                bootbox.alert(mensaje);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });
}

function limpiar_datos() {
    $("#error_txtTituloPreg").hide();
    $("#error_txtAyuda").hide();
    $("#error_ddlTipoPregunta").hide();
    $("#error_ddlTipo_validacion_dato").hide();
    $("#error_txtLimiteValor").hide();
    $("#error_ddlCantidadCheckValida").hide();
    $("#error_txtLimiteCheck").hide();

}

function crearPregunta(xml_data) {
    $.ajax({
        type: "POST",
        contentType: "text/xml",
        url: '../../Views/Valoracion/configuraEncuestas_ajax?opc=PREG',
        processData: false,
        data: xml_data,
        success: function (r) {
            var codigo_error = r.split("<||>")[0];
            var mensaje = r.split("<||>")[1];
            if (r.indexOf("<||>") != -1) {
                if (codigo_error == '0') {
                    bootbox.alert("Pregunta registrada exitosamente", function () {
                        //deshabilitar edicion de campos
                    });
                } else {
                    bootbox.alert(mensaje);
                }
            }
        },
        error: function (response) {
            bootbox.alert(response);
        }
    });
}