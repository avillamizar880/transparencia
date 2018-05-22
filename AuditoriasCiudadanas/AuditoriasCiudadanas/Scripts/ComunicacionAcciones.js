﻿$("#btnCrearForo").bind("click", function () {
    var valida=validaObligatorios("divInfoForo");
    if (valida == true) {
        var dataForo = {
            tema: $("#txtTema").val(),
            descripcion: $("#txtDescripcion").val(),
            mensaje: $("#txtMensaje").val(),
            idUsuario: $("#hdIdUsuario").val()
        };
        $.ajax({
            url: "Comunicacion/addForo",
            dataType: "json",
            type: "POST",
            data: {
                dataForo
            },
            success: function (data) {
                debugger
                var prueba = data;
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }

});