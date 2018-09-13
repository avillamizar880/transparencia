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
            var ForoConfig = $("#hdIdForoConfig").val();
            var nuevo1 = "<div class=\"col-md-12 text-center\">" +
                "<div class=\"btn btn-default\"><a href=\"#\" onclick=\"cargaMenuParams('Comunicacion/ForoDetalle', 'dvPrincipal', '" + idForo + "@" + ForoConfig + "')\"><span class=\"glyphicon glyphicon-plus\"></span>Ver Respuestas</a></div>" +
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
        waitblockUIParam('Guardando respuesta...');
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
                unblockUI();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
                unblockUI();
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
                Descripcion: $("#txtDescripcionForo").val(),
                foroConfig: $("#hdIdForoConfig").val()
            },
            success: function (data) {
                if (data.Mensaje == "@OK") {
                    cargaMenu('Comunicacion/adminForo?config=' + $("#hdIdForoConfig").val(), 'dvPrincipal');
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


function BuscarForos() {
    if ($('#txtBuscarTema').val() != "") {
        var busqueda = $('#txtBuscarTema').val();
        $.ajax({
            url: "Foro/GetForoByString",
            dataType: "json",
            type: "POST",
            data: {
                buscar: busqueda,
                foroConfig: $("#hdIdForoConfig").val()
            },
            success: function (data) {
                console.log(data);
                $("#divInfoForo .questionsBox").remove();
                var ForoConfig = $("#hdIdForoConfig").val();
                $.each(data, function (i, item) {
                    var anterior = $("#divInfoForo").html();
                    var nuevo = "<div class=\"questionsBox row\">" +
                        "<div class=\"col-md-1\">" +
                        "<div class=\"imgUser\">" +
                        "<img class=\"img-responsive\" src=\"Content/img/imagUser.jpg\" />" +
                        "</div>" +
                        "<div class=\"text-center\">" + item.Nombre + "</div>" +
                        "</div>" +
                        "<div class=\"col-md-11\" id=\"foro" + item.IdForo + "\">" +
                        "<div class=\"label simple-label\">" + item.FechaCreacionStr + "</div>" +
                        "<div class=\"label simple-label\">Tema</div>" +
                        "<a onclick=\"cargaMenuParams('Comunicacion/ForoDetalle', 'dvPrincipal', '" + item.IdForo + "@" + ForoConfig + "')\" >" +
                        "<h3 class=\"titQuestion\">" + item.Tema.replace(busqueda, "<mark>" + busqueda + "</mark>") + "</h3>" +
                        "</a>" +
                        "<p class=\"descQuestion\">" + item.Descripcion.replace(busqueda, "<mark>" + busqueda + "</mark>") + "</p>" +
                        "<div class=\"optionsBtn\">" +
                        "<div class=\"btn btn-primary\" data-toggle=\"collapse\" data-target=\"#newComent" + item.IdForo + "\" ><span class=\"glyphicon glyphicon-share-alt\"></span> Responder</div>" +
                        "<div class=\"btn btn-default\" id=\"btnRespuestas" + item.IdForo + "\" onclick=\"verRespuestas(" + item.IdForo + ")\"><span class=\"glyphicon glyphicon-plus\"></span> Ver Respuestas</div>" +
                        "</div>" +
                        "<div class=\"collapse\" id=\"newComent" + item.IdForo + "\" > " +
                        "<div class=\"comentBox\" > " +
                        "<label>Escriba aqui su respuesta</label>" +
                        "<textarea rows=\"4\" class=\"form-control\" id=\"txtMensaje" + item.IdForo + "\"></textarea>" +
                        "<button class=\"btn btn-primary\" onclick=\"guardarRespuesta(" + item.IdForo + ");\" ><span class=\"glyphicon glyphicon-send\" ></span> Enviar</button>" +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</div>";
                    $("#divInfoForo").html(anterior + nuevo);
                });

                $("#btnNuevoTema").bind("click", function () {
                    $("#divNuevoTema").show("blind");
                });

                $("#btnBuscarTema").bind("click", function () {
                    BuscarForos();
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
}
