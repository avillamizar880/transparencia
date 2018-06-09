function validaObligatorios(divcontenedor) {
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    var nom_contenedor = "#" + divcontenedor;
    $('.required', $(nom_contenedor)).each(function (i, e) {
        var id_txt = $(e).attr("for");
        if ($("#" + id_txt).val() == "" || $('#' + id_txt + ' option:selected').val() == "0") {
            camposReq += "[" + id_txt + "]";
            $("#error_" + id_txt).show();
            formularioOK = false;
        } else {
            $("#error_" + id_txt).hide();
        }
    });
    return formularioOK;
}

function verRespuestas(idForo) {
    $.ajax({
        url: "Foro/BuscarRespuestas",
        dataType: "json",
        type: "POST",
        data: {
            idForo: idForo
        },
        success: function (data) {
            $("#btnRespuestas" + idForo).html("");
            $("#btnRespuestas" + idForo).hide();
            $.each(data, function (i, item) {
                var anterior = $("#foro" + idForo).html();
                var nuevo = "<div class=\"answerBox\" id=\"mensaje" + item.idForoMensaje + "\">" +
                    "<div class=\"col-md-1 text-center\">" +
                    "<div class=\"imgUser\">" +
                    "<img class=\"img-responsive\" src=\"Content/img/imagUser.jpg\" />" +
                    "</div>" +
                    "</div>" +
                    "<div class=\"col-md-11\">" +
                    "<div class=\"label simple-label\">Por: " + item.nombreUsuario + "</div>" +
                    "<div class=\"label simple-label\">" + item.fecha + "</div>" +
                    "<p class=\"descQuestion\">" + item.mensaje + "</p>" +
                    "</div>" +
                    "</div>";
                $("#foro" + idForo).html(anterior + nuevo);
            });
            var anterior1 = $("#foro" + idForo).html();
            var nuevo1 = "<div class=\"col-md-12 text-center\">" +
                "<div class=\"btn btn-default\"><a href=\"#\" onclick=\"cargaMenuParams('Comunicacion/ForoDetalle', 'dvPrincipal', " + idForo + ")\"><span class=\"glyphicon glyphicon-plus\"></span>Ver Respuestas</a></div>" +
                "</div>";
            $("#foro" + idForo).html(anterior1 + nuevo1);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
}
function verRespuestasCompletas(idForo) {
    $.ajax({
        url: "Foro/BuscarRespuestas",
        dataType: "json",
        type: "POST",
        data: {
            idForo: idForo,
            flag: true
        },
        success: function (data) {
            $("#btnRespuestas" + idForo).html("");
            $("#btnRespuestas" + idForo).hide();
            $.each(data, function (i, item) {
                var anterior = $("#foro" + idForo).html();
                var nuevo = "<div class=\"answerBox\" id=\"mensaje" + item.idForoMensaje + "\">" +
                    "<div class=\"col-md-1 text-center\">" +
                    "<div class=\"imgUser\">" +
                    "<img class=\"img-responsive\" src=\"Content/img/imagUser.jpg\" />" +
                    "</div>" +
                    "</div>" +
                    "<div class=\"col-md-11\">" +
                    "<div class=\"label simple-label\">Por: " + item.nombreUsuario + "</div>" +
                    "<div class=\"label simple-label\">" + item.fecha + "</div>" +
                    "<p class=\"descQuestion\">" + item.mensaje + "</p>" +
                    "</div>" +
                    "</div>";
                $("#foro" + idForo).html(anterior + nuevo);
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
}


function guardarRespuesta(idForo) {
    if ($("#txtMensaje" + idForo).val() != "") {
        $.ajax({
            url: "Foro/guardarRespuesta",
            dataType: "json",
            type: "POST",
            data: {
                IdForo: idForo,
                IdUsuario: $("#hdIdUsuario").val(),
                Mensaje: $("#txtMensaje" + idForo).val()
            },
            success: function (data) {
                if (data.Mensaje == "@OK") {
                    $("#txtMensaje" + idForo).val("");
                    $("#foro" + idForo + " .answerBox").remove();
                    $("#foro" + idForo + " .col-md-12").remove();
                    verRespuestas(idForo);
                }
                else {
                    bootbox.alert("Error guardando respuesta");
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }

}

function guardarTema() {
    if ($("#txtTemaForo").val() != "" && $("#txtDescripcionForo").val() != "") {
        $.ajax({
            url: "Foro/guardarTema",
            dataType: "json",
            type: "POST",
            data: {
                Tema: $("#txtTemaForo").val(),
                IdUsuario: $("#hdIdUsuario").val(),
                Descripcion: $("#txtDescripcionForo").val()
            },
            success: function (data) {
                if (data.Mensaje == "@OK") {
                    cargaMenu('Comunicacion/adminForo', 'dvPrincipal');
                }
                else {
                    bootbox.alert("Error guardando respuesta");
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }

}
