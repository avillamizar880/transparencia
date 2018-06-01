
function BuscarTotalNoticias() {
    $.ajax({
        type: "POST",
        url: '../../Views/Informacion/verNoticias_ajax', data: { BuscarTotalNoticias: $("#txtPalabraClaveNoticias").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Buscando total noticias...');
        },
        success: function (result) {
            GenerarPaginadorNoticias(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
}

function GenerarPaginadorNoticias(result) {
    $("#datosEncontradosNoticias").html();
    var totalNoticias = 0;
    if (result != null && result != "" && result.Head.length >= 0)
        totalNoticias = parseInt(result.Head[0].Total);
    if (totalNoticias.toString() != "NaN") {
        if (totalNoticias == 1) $("#datosEncontradosNoticias").html(totalNoticias.toString() + ' registro encontrado');
        else $("#datosEncontradosNoticias").html(totalNoticias.toString() + ' registros encontrados');
        if (totalNoticias == 0) {
            $("#datosNoticias").html('');
            $("#navegadorResultadosNoticias").hide();
            unblockUI();
        }
        else {
            var paginasPosibles = totalNoticias / 20;
            if (paginasPosibles > 1) {
                $("#navegadorResultadosNoticias").show();
                var paginasEnteras = parseInt(paginasPosibles);
                if (paginasEnteras < paginasPosibles) paginasEnteras++;
                $("#navegadorResultadosNoticias").html();
                var contenidopreview = '<li id="Pag_prev" onclick="CargarDatosNoticiasPreview()"><a href="#" aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>';
                var contenidoPaginas = '';
                $("#ultimaPaginaNoticias").text(paginasEnteras);
                for (var i = 1; i <= paginasEnteras; i++)
                    contenidoPaginas = contenidoPaginas + '<li id="Pag_" ' + i + ' onclick="CargarDatosNoticias(' + i + ')">' + '<a href="#">' + i + '</a></li>';
                var contenidoNext = '<li id="Pag_next" onclick="CargarDatosNoticiasNext()"><a href="#" aria-label="Next"><span aria-hidden="true">&raquo;</span></a></li>';
                $("#paginadorNoticias").html(contenidopreview + contenidoPaginas + contenidoNext);
            }
            else $("#navegadorResultadosNoticias").hide();
            CargarDatosNoticias(1);
        }
    }
    else unblockUI();
}
function CargarDatosNoticias(paginaSeleccionada) {
        $.ajax({
            type: "POST",
            url: '../../Views/Informacion/verNoticias_ajax', data: { BuscarNoticiasPalabraClave: $("#txtPalabraClaveNoticias").val() + "*" + paginaSeleccionada + "*20" },
            traditional: true,
            cache: false,
            dataType: "json",
            beforeSend: function () {
                waitblockUIParam('Buscando noticias...');
            },
            success: function (result) {
                var datasource = '';
                if (result != null && result != "") {
                    for (var i = 0; i < result.Head.length; i++) {
                        var mensajeNuevo = '';
                        var fechaNoticia = new Date(Date.parse(result.Head[i].FechaNoticia));
                        var hoy = new Date();
                        if (fechaNoticia > hoy) mensajeNuevo = '<strong>¡Nuevo!</strong>';
                        else
                        {
                            var diasPasadoNoticia = new Date(new Date() - new Date(Date.parse(result.Head[i].FechaNoticia))).getDate();
                            if (diasPasadoNoticia <= 1) mensajeNuevo = '<strong>¡Nuevo!</strong>';
                            else mensajeNuevo = 'Hace ' + diasPasadoNoticia + ' días';
                        }
                        datasource += '<div class="list-group-item">' +
                                 '<div class="col-sm-1" hidden="hidden"><p class="list-group-item-text"><a href="#">' + result.Head[i].idNotica + '</a></p></div>' +
                                 '<div class="col-sm-1">'+mensajeNuevo+'</div>' +
                                 '<div class="col-sm-7"><a href="' + result.Head[i].Url +  '"><h4>' + result.Head[i].Titulo + '</h4>' + '<br>' + result.Head[i].Resumen + '</a></div>' +
                                 '<div class="col-sm-3"><img src="/Adjuntos/Noticias/' + result.Head[i].ImagenUrl + '" width="250" height="120">' + '</div>' +
                                 '</div>';
                    }
                }
                $("#datosNoticias").html(datasource);
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }

        });
        $("#paginaActualNoticias").text(paginaSeleccionada);
}


function CargarDatosNoticiasPreview() {
    if ($("#paginaActualNoticias").text() != '') {
        var paginaActual = parseInt($("#paginaActualNoticias").text());
        if (paginaActual > 1)
            CargarDatosNoticias(paginaActual - 1);
    }
}
function CargarDatosNoticiasNext() {
    if ($("#paginaActualNoticias").text() != '') {
        var paginaActual = parseInt($("#paginaActualNoticias").text());
        var maxPagina = parseInt($("#ultimaPaginaNoticias").text());
        if (paginaActual < maxPagina)
            CargarDatosNoticias(paginaActual + 1);
    }
}

