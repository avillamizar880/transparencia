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
function BuscarTotalNoticiasPublicadas() {
    $.ajax({
        type: "POST",
        url: '../../Views/Administracion/PublicarNoticias_ajax', data: { BuscarTotalNoticiasPublicadas: '' },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Buscando total noticias publicadas...');
        },
        success: function (result) {
            GenerarPaginadorNoticiasPublicadas(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
}
function GenerarPaginadorNoticiasPublicadas(result) {
    $("#datosEncontradosNoticias").html();
    var totalNoticias = 0;
    if (result != null && result != "" && result.Head.length >= 0)
        totalNoticias = parseInt(result.Head[0].Total);
    if (totalNoticias.toString() != "NaN") {
        if (totalNoticias == 1) $("#datosEncontradosNoticiasPublicadas").html(totalNoticias.toString() + ' registro encontrado');
        else $("#datosEncontradosNoticiasPublicadas").html(totalNoticias.toString() + ' registros encontrados');
        if (totalNoticias == 0) {
            $("#datosNoticiasPublicadas").html('');
            $("#navegadorResultadosNoticiasPublicadas").hide();
            unblockUI();
        }
        else {
            var paginasPosibles = totalNoticias / 20;
            if (paginasPosibles > 1) {
                $("#navegadorResultadosNoticiasPublicadas").show();
                var paginasEnteras = parseInt(paginasPosibles);
                if (paginasEnteras < paginasPosibles) paginasEnteras++;
                $("#navegadorResultadosNoticiasPublicadas").html();
                var contenidopreview = '<li id="Pag_prev" onclick="CargarDatosNoticiasPublicadasPreview()"><a href="#" aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>';
                var contenidoPaginas = '';
                $("#ultimaPaginaNoticiasPublicadas").text(paginasEnteras);
                for (var i = 1; i <= paginasEnteras; i++)
                    contenidoPaginas = contenidoPaginas + '<li id="Pag_" ' + i + ' onclick="CargarDatosNoticiasPublicadas(' + i + ')">' + '<a href="#">' + i + '</a></li>';
                var contenidoNext = '<li id="Pag_next" onclick="CargarDatosNoticiasPublicadasNext()"><a href="#" aria-label="Next"><span aria-hidden="true">&raquo;</span></a></li>';
                $("#paginadorNoticiasPublicadas").html(contenidopreview + contenidoPaginas + contenidoNext);
            }
            else $("#navegadorResultadosNoticiasPublicadas").hide();
            CargarDatosNoticiasPublicadas(1);
        }
    }
    else unblockUI();
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
function CargarDatosNoticiasPublicadasPreview() {
    if ($("#paginaActualNoticiasPublicadas").text() != '') {
        var paginaActual = parseInt($("#paginaActualNoticiasPublicadas").text());
        if (paginaActual > 1)
            CargarDatosNoticiasPublicadas(paginaActual - 1);
    }
}
function CargarDatosNoticiasPublicadas(paginaSeleccionada) {
    $.ajax({
        type: "POST",
        url: '../../Views/Administracion/PublicarNoticias_ajax', data: { BuscarNoticiasPublicadasPalabraClave: '' + "*" + paginaSeleccionada + "*20" },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Buscando noticias publicadas...');
        },
        success: function (result) {
            var datasource = '';
            if (result != null && result != "") {
                for (var i = 0; i < result.Head.length; i++) {
                    datasource += '<div class="list-group-item">' +
					                '<div class="col-sm-3"><p class="list-group-item-text"><a href="">' + result.Head[i].Titulo + '</a></p> </div>' +
					                '<div class="col-sm-1"><span>' + result.Head[i].FechaNoticia + '</span> </div>' +
					                '<div class="col-sm-5"><p>' + result.Head[i].Resumen + '</p></div>' +
					                '<div class="col-sm-3">' +
					                    '<div class="btn-group btn-group-justified" role="group" aria-label="...">' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default"><span class="glyphicon glyphicon-camera"></span></button>' +
								                '</div>' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span></button>' +
								                '</div>' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span></button>' +
								                '</div>' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default" onclick="PublicarNoticia(' + result.Head[i].idNoticia + ')"><span class="glyphicon glyphicon-share-alt"></span></button>' +
								                '</div>' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default"><span class="glyphicon glyphicon-edit"></span></button>' +
								                '</div>' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default" onclick="EliminarNoticia(' + result.Head[i].idNoticia + ')"><span class="glyphicon glyphicon-trash" ></span></button>' +
								                '</div>' +
								        '</div>' +
					                '</div>' +
               	                '</div>';
                }
            }
            $("#datosNoticiasPublicadas").html(datasource);
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
    $("#paginaActualNoticiasPublicadas").text(paginaSeleccionada);
}
function CargarDatosNoticiasPublicadasNext() {
    if ($("#paginaActualNoticiasPublicadas").text() != '') {
        var paginaActual = parseInt($("#paginaActualNoticiasPublicadas").text());
        var maxPagina = parseInt($("#ultimaPaginaNoticiasPublicadas").text());
        if (paginaActual < maxPagina)
            CargarDatosNoticiasPublicadas(paginaActual + 1);
    }
}
function EliminarNoticia(idNoticia) {
    var params = {
        id_usuario: $("#hdIdUsuario").val(),
        id_Not: idNoticia,
    };
    bootbox.confirm({
        title: "Confirmar Eliminación",
        message: "Esta seguro de eliminar la noticia y los recursos relacionados?",
        buttons: {
            confirm: {
                label: 'Eliminar'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result)
        {
            if (result == true)
            {
                $.ajax({
                    type: "POST",
                    url: '../../Views/Administracion/PublicarNoticias_ajax', data: { EliminarNoticia:  params.id_Not + "*" + params.id_usuario },
                    traditional: true,
                    cache: false,
                    //dataType: "json",
                    beforeSend: function () {
                        waitblockUIParam('Eliminando noticia ...');
                    },
                    success: function (result) {
                        BuscarTotalNoticiasPublicadas();
                        unblockUI();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("error");
                        alert(textStatus + ": " + XMLHttpRequest.responseText);
                    }

                });
            }
        }
    });
}
function PublicarNoticia(idNoticia) {
    var params = {
        id_usuario: $("#hdIdUsuario").val(),
        id_Not: idNoticia,
    };
    bootbox.confirm({
        title: "Confirmar Publicación",
        message: "Esta seguro de publicar esta noticia y los recursos relacionados?",
        buttons: {
            confirm: {
                label: 'Publicar'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                $.ajax({
                    type: "POST",
                    url: '../../Views/Administracion/PublicarNoticias_ajax', data: { PublicarNoticia: params.id_Not + "*" + params.id_usuario },
                    traditional: true,
                    cache: false,
                    //dataType: "json",
                    beforeSend: function () {
                        waitblockUIParam('Publicando noticia ...');
                    },
                    success: function (result) {
                        unblockUI();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("error");
                        alert(textStatus + ": " + XMLHttpRequest.responseText);
                    }
                });
            }
        }
    });
}
