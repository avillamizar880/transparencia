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
function BuscarTotalCampanasPublicadas() {
    $.ajax({
        type: "POST",
        url: '../../Views/Administracion/PublicarCampanas_ajax', data: { BuscarTotalCampanasPublicadas: '' },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Buscando total campañas publicadas...');
        },
        success: function (result) {
            GenerarPaginadorCampanasPublicadas(result);
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
function GenerarPaginadorCampanasPublicadas(result) {
    $("#datosEncontradosCampanasPublicadas").html();
    var totalCampanas = 0;
    if (result != null && result != "" && result.Head.length >= 0)
        totalCampanas = parseInt(result.Head[0].Total);
    if (totalCampanas.toString() != "NaN") {
        if (totalCampanas == 1) $("#datosEncontradosCampanasPublicadas").html(totalCampanas.toString() + ' registro encontrado');
        else $("#datosEncontradosCampanasPublicadas").html(totalCampanas.toString() + ' registros encontrados');
        if (totalCampanas == 0) {
            $("#datosCampanasPublicadas").html('');
            $("#navegadorResultadosCampanasPublicadas").hide();
            unblockUI();
        }
        else {
            var paginasPosibles = totalCampanas / 20;
            if (paginasPosibles > 1) {
                $("#navegadorResultadosCampanasPublicadas").show();
                var paginasEnteras = parseInt(paginasPosibles);
                if (paginasEnteras < paginasPosibles) paginasEnteras++;
                $("#navegadorResultadosCampanasPublicadas").html();
                var contenidopreview = '<li id="Pag_prev" onclick="CargarDatosCampanasPublicadasPreview()"><a href="#" aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>';
                var contenidoPaginas = '';
                $("#ultimaPaginaCampanasPublicadas").text(paginasEnteras);
                for (var i = 1; i <= paginasEnteras; i++)
                    contenidoPaginas = contenidoPaginas + '<li id="Pag_" ' + i + ' onclick="CargarDatosCampanasPublicadas(' + i + ')">' + '<a href="#">' + i + '</a></li>';
                var contenidoNext = '<li id="Pag_next" onclick="CargarDatosCampanasPublicadasNext()"><a href="#" aria-label="Next"><span aria-hidden="true">&raquo;</span></a></li>';
                $("#paginadorCampanasPublicadas").html(contenidopreview + contenidoPaginas + contenidoNext);
            }
            else $("#navegadorResultadosCampanasPublicadas").hide();
            CargarDatosCampanasPublicadas(1);
        }
    }
    else unblockUI();
}
function CargarDatosCampanasPublicadasPreview() {
    if ($("#paginaActualCampanasPublicadas").text() != '') {
        var paginaActual = parseInt($("#paginaActualCampanasPublicadas").text());
        if (paginaActual > 1)
            CargarDatosCampanasPublicadas(paginaActual - 1);
    }
}
function CargarDatosCampanasPublicadasNext() {
    if ($("#paginaActualCampanasPublicadas").text() != '') {
        var paginaActual = parseInt($("#paginaActualCampanasPublicadas").text());
        var maxPagina = parseInt($("#ultimaPaginaCampanasPublicadas").text());
        if (paginaActual < maxPagina)
            CargarDatosCampanasPublicadas(paginaActual + 1);
    }
}
function CargarDatosNoticiasPublicadasPreview() {
    if ($("#paginaActualNoticiasPublicadas").text() != '') {
        var paginaActual = parseInt($("#paginaActualNoticiasPublicadas").text());
        if (paginaActual > 1)
            CargarDatosNoticiasPublicadas(paginaActual - 1);
    }
}
function CargarDatosNoticiasPublicadasNext() {
    if ($("#paginaActualNoticiasPublicadas").text() != '') {
        var paginaActual = parseInt($("#paginaActualNoticiasPublicadas").text());
        var maxPagina = parseInt($("#ultimaPaginaNoticiasPublicadas").text());
        if (paginaActual < maxPagina)
            CargarDatosNoticiasPublicadas(paginaActual + 1);
    }
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
                        if (result.Head[i].ImagenUrl == '' || result.Head[i].ImagenUrl == null ) {
                            datasource += '<div class="list-group-item">' +
                                '<div class="col-sm-1" hidden="hidden"><p class="list-group-item-text"><a href="#">' + result.Head[i].idNotica + '</a></p></div>' +
                                '<div class="col-sm-1">' + mensajeNuevo + '</div>' +
                                '<div class="col-sm-7"><a href="#" onclick="EnlazarNoticia(\'' + "\',\'" + result.Head[i].Titulo + "\',\'" + result.Head[i].Resumen + "\',\'" + fechaNoticia.getDate() + "/" + (fechaNoticia.getMonth() + 1) + "/" + fechaNoticia.getFullYear() + "\',\'" + '\');"><h4>' + result.Head[i].Titulo + '</h4>' + '<br>' + result.Head[i].Resumen + '</a></div>' +
                                '<div class="col-sm-3">' + '</div>' +
                                '</div>';
                        }
                        else {
                            datasource += '<div class="list-group-item">' +
                                 '<div class="col-sm-1" hidden="hidden"><p class="list-group-item-text"><a href="#">' + result.Head[i].idNotica + '</a></p></div>' +
                                 '<div class="col-sm-1">' + mensajeNuevo + '</div>' +
                                 '<div class="col-sm-7"><a href="#" onclick="EnlazarNoticia(\'' + result.Head[i].Url + "\',\'" + result.Head[i].Titulo + "\',\'" + result.Head[i].Resumen + "\',\'" + fechaNoticia.getDate() + "/" + (fechaNoticia.getMonth() + 1) + "/" + fechaNoticia.getFullYear() + "\',\'" + '/Adjuntos/CampanasNoticias/' + result.Head[i].ImagenUrl + '\');"><h4>' + result.Head[i].Titulo + '</h4>' + '<br>' + result.Head[i].Resumen + '</a></div>' +
                                 '<div class="col-sm-3"><img src="/Adjuntos/CampanasNoticias/' + result.Head[i].ImagenUrl + '" width="250" height="120">' + '</div>' +
                                 '</div>';
                        }
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
function EnlazarNoticia(urlNoticia, titulo, resumen, fechaNoticia, imgUrl) {
    $("#txtTituloNoticia").val(titulo);
    $("#txtResumenNoticia").val(resumen);
    $("#fechaDetalleNoticia").val(fechaNoticia);
    if (urlNoticia == '') {
        $("#btnVerMasNoticia").hide();
    }
    else {
        $("#btnVerMasNoticia").show();
    }
    if (imgUrl == '') {
        $("#imgDetalleNoticia").hidden = "hidden";
    }
    else {
        $("#imgDetalleNoticia").show();
        $("#imgDetalleNoticia").attr("src", imgUrl);
    }
    $("#hfUrlDetalleNoticia").val(urlNoticia);
    cargaPlantillasAdminNoticiasCampanas("divPrincipalVerNoticia", "divPrincipalEnlaceNoticia");
}
function MasInformacionNoticia()
{
    window.open($("#hfUrlDetalleNoticia").val(), 'Noticia');
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
					                '<div class="col-sm-3"><p class="list-group-item-text"><a href="#">' + result.Head[i].Titulo + '</a></p> </div>' +
					                '<div class="col-sm-1"><span class="glyphicon glyphicon-calendar">' + result.Head[i].FechaNoticia + '</span> </div>' +
					                '<div class="col-sm-5"><p>' + result.Head[i].Resumen + '</p></div>' +
                                    '<div class="col-sm-3">' +
                                        '<div hidden="hidden">' + result.Head[i].Url + '</div>' +
					                    '<div class="btn-group btn-group-justified" role="group" aria-label="...">' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default" data-toggle="tooltip" data-placement="top" title="Subir Imagen" onclick="SubirRecursoMultimediaNoticia(' + result.Head[i].idNoticia + ')"><span class="glyphicon glyphicon-camera"></span></button>' +
								                '</div>' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default" data-toggle="tooltip" data-placement="top" title="Publicar Noticia" onclick="PublicarNoticia(' + result.Head[i].idNoticia + ')"><span class="glyphicon glyphicon-share-alt"></span></button>' +
								                '</div>' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default" data-toggle="tooltip" data-placement="top" title="Editar Noticia" onclick="EditarNoticia(' + result.Head[i].idNoticia + ',' + "'" + result.Head[i].Titulo + "'" + ',' + "'" + result.Head[i].FechaNoticia + "'" + ',' + "'" + result.Head[i].Resumen + "'" + ',' + "'" + result.Head[i].Url + "'" + ')"><span class="glyphicon glyphicon-edit"></span></button>' +
								                '</div>' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default" data-toggle="tooltip" data-placement="top" title="Eliminar Noticia" onclick="EliminarNoticia(' + result.Head[i].idNoticia + ')"><span class="glyphicon glyphicon-trash" ></span></button>' +
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
function CargarDatosCampanasPublicadas(paginaSeleccionada) {
    $.ajax({
        type: "POST",
        url: '../../Views/Administracion/PublicarCampanas_ajax', data: { BuscarCampanasPublicadasPalabraClave: '' + "*" + paginaSeleccionada + "*20" },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Buscando campañas publicadas...');
        },
        success: function (result) {
            var datasource = '';
            if (result != null && result != "") {
                for (var i = 0; i < result.Head.length; i++) {
                    datasource += '<div class="list-group-item">' +
					                '<div class="col-sm-3"><p class="list-group-item-text"><a href="#">' + result.Head[i].Titulo + '</a></p> </div>' +
					                '<div class="col-sm-1"><span class="glyphicon glyphicon-calendar">' + result.Head[i].FechaNoticia + '</span> </div>' +
					                '<div class="col-sm-5"><p>' + result.Head[i].Resumen + '</p></div>' +
                                    '<div class="col-sm-3">' +
                                        '<div hidden="hidden">' + result.Head[i].Url + '</div>' +
					                    '<div class="btn-group btn-group-justified" role="group" aria-label="...">' +
								                '<div class="btn-group" role="group">' + 
									                '<button type="button" class="btn btn-default" class="btn btn-default" data-toggle="tooltip" data-placement="top" title="Subir Imagen" onclick="SubirRecursoMultimediaCampana(' + result.Head[i].idNoticia + ')"><span class="glyphicon glyphicon-camera"></span></button>' +
								                '</div>' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default" class="btn btn-default" data-toggle="tooltip" data-placement="top" title="Publicar Campaña" onclick="PublicarCampana(' + result.Head[i].idNoticia + ')"><span class="glyphicon glyphicon-share-alt"></span></button>' +
								                '</div>' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default" class="btn btn-default" data-toggle="tooltip" data-placement="top" title="Editar Campaña" onclick="EditarCampana(' + result.Head[i].idNoticia + ',' + "'" + result.Head[i].Titulo + "'" + ',' + "'" + result.Head[i].FechaNoticia + "'" + ',' + "'" + result.Head[i].Resumen + "'" + ',' + "'" + result.Head[i].Url + "'" + ')"><span class="glyphicon glyphicon-edit"></span></button>' +
								                '</div>' +
								                '<div class="btn-group" role="group">' +
									                '<button type="button" class="btn btn-default" class="btn btn-default" data-toggle="tooltip" data-placement="top" title="Eliminar Campaña" onclick="EliminarCampana(' + result.Head[i].idNoticia + ')"><span class="glyphicon glyphicon-trash" ></span></button>' +
								                '</div>' +
								        '</div>' +
					                '</div>' +
               	                '</div>';
                }
            }
            $("#datosCampanasPublicadas").html(datasource);
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
    $("#paginaActualCampanasPublicadas").text(paginaSeleccionada);
}
function SubirRecursoMultimediaCampana(idRecurso)
{
    $.ajax({
        type: "POST",
        url: '../../Views/Administracion/PublicarCampanas_ajax', data: { ObtenerImagenRecurso: idRecurso },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Buscando recurso multimedia...');
        },
        success: function (result) {
            if (result != null && result != "" && result.Head.length>0) {
                $("#inpsubirFotoCampanaEditar").val(); //Limpiar control de cargue de imágenes
                $('#hfIdDetalleRecursoMultCampanaEditar').val(result.Head[0].idDetalleRecurso);
                $('#hfIdRecursoMultCampanaEditar').val(idRecurso);
                $("#imgAnteriorCampana").attr("src", '/Adjuntos/CampanasNoticias/' + result.Head[0].rutaUrl);
                cargaPlantillasAdminNoticiasCampanas("divPrincipalCampanas", "divPrincipalAnadirRecursoMultimediaCampanaEditar");
            }
            else {
                $('#hfIdDetalleRecursoMultCampana').val('0');
                $('#hfIdRecursoMultCampana').val(idRecurso);
                cargaPlantillasAdminNoticiasCampanas("divPrincipalCampanas", "divPrincipalAnadirRecursoMultimediaCampana");
            }
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
}
function SubirRecursoMultimediaNoticia(idRecurso) {
    $.ajax({
        type: "POST",
        url: '../../Views/Administracion/PublicarCampanas_ajax', data: { ObtenerImagenRecurso: idRecurso },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Buscando recurso multimedia...');
        },
        success: function (result) {
            if (result != null && result != "" && result.Head.length > 0) {
                $("#inpsubirFotoNoticiaEditar").val();
                cargaPlantillasAdminNoticiasCampanas("divPrincipalNoticias", "divPrincipalAnadirRecursoMultimediaEditar");
                $('#hfIdDetalleRecursoMultNoticiaEditar').val(result.Head[0].idDetalleRecurso);
                $('#hfIdRecursoMultNoticiaEditar').val(idRecurso);
                $("#imgAnteriorNoticia").attr("src", '/Adjuntos/CampanasNoticias/' + result.Head[0].rutaUrl);
            }
            else {
                cargaPlantillasAdminNoticiasCampanas("divPrincipalNoticias", "divPrincipalAnadirRecursoMultimedia");
                $('#hfIdDetalleRecursoMultNoticia').val('0');
                $('#hfIdRecursoMultNoticia').val(idRecurso);
            }
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
}
function GuardarRegistroFotograficoNoticia() {
    if (ValidarGuardarRegistroFotograficoNoticia() == true) $("#inpsubirNoticiaFoto").fileinput("upload");
    else alert("No fue posible guardar el registro fotográfico.\nPor favor revise los mensajes de error señalados en rojo que aparecen en el formato.");
}
function GuardarRegistroFotograficoNoticiaEditar() {
    if (ValidarGuardarRegistroFotograficoNoticiaEditar() == true) $("#inpsubirFotoNoticiaEditar").fileinput("upload");
    else alert("No fue posible guardar el registro fotográfico.\nPor favor revise los mensajes de error señalados en rojo que aparecen en el formato.");
}
function ValidarGuardarRegistroFotograficoNoticiaEditar() {
    if ($("#inpsubirFotoNoticiaEditar").val() == '') {
        $("#errorRecursoMultimediaNoticiaEditar").show();
        return false;
    }
    return true;
}
function GuardarRegistroFotograficoCampana()
{
    if (ValidarGuardarRegistroFotograficoCampana() == true) $("#inpsubirCampanaFoto").fileinput("upload");
    else alert("No fue posible guardar el registro fotográfico.\nPor favor revise los mensajes de error señalados en rojo que aparecen en el formato.");
}
function GuardarRegistroFotograficoCampanaEditar() {
    if (ValidarGuardarRegistroFotograficoCampanaEditar() == true) $("#inpsubirFotoCampanaEditar").fileinput("upload");
    else alert("No fue posible guardar el registro fotográfico.\nPor favor revise los mensajes de error señalados en rojo que aparecen en el formato.");
}
function ValidarGuardarRegistroFotograficoCampanaEditar() {
    if ($("#inpsubirFotoCampanaEditar").val() == '') {
        $("#errorRecursoMultimediaCampanaEditar").show();
        return false;
    }
    return true;
}
function ValidarGuardarRegistroFotograficoNoticia() {
    if ($("#inpsubirCampanaFoto").val() == '') {
        $("#errorRecursoMultimediaCampana").show();
        return false;
    }
    return true;
}
function ValidarGuardarRegistroFotograficoCampana() {
    if ($("#inpsubirFoto").val() == '') {
        $("#errorRecursoMultimediaCampana").show();
        return false;
    }
    return true;
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
function EliminarCampana(idCampana) {
    var params = {
        id_usuario: $("#hdIdUsuario").val(),
        id_Cam: idCampana,
    };
    bootbox.confirm({
        title: "Confirmar Eliminación",
        message: "Esta seguro de eliminar la campaña y los recursos relacionados?",
        buttons: {
            confirm: {
                label: 'Eliminar'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                $.ajax({
                    type: "POST",
                    url: '../../Views/Administracion/PublicarCampanas_ajax', data: { EliminarCampana: params.id_Cam + "*" + params.id_usuario },
                    traditional: true,
                    cache: false,
                    beforeSend: function () {
                        waitblockUIParam('Eliminando campaña ...');
                    },
                    success: function (result) {
                        BuscarTotalCampanasPublicadas();
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
function PublicarCampana(idCampana) {
    var params = {
        id_usuario: $("#hdIdUsuario").val(),
        id_Cam: idCampana,
    };
    bootbox.confirm({
        title: "Confirmar Publicación",
        message: "Esta seguro de publicar esta campaña y los recursos relacionados?",
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
                    url: '../../Views/Administracion/PublicarCampanas_ajax', data: { PublicarCampana: params.id_Cam + "*" + params.id_usuario },
                    traditional: true,
                    cache: false,
                    beforeSend: function () {
                        waitblockUIParam('Publicando campaña ...');
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
function AnadirNoticia() {
    if ($("#hdIdUsuario").val() != '') {
        var fechaActual = new Date();
        var fecha = fechaActual.getFullYear() + '-' + (fechaActual.getMonth() + 1) + '-' + fechaActual.getDate(); 
        AsignarValoresNoticia(fecha, $("#hdIdUsuario").val(), 0,'','','');
        OcultarValidadoresNoticia();
        cargaPlantillasAdminNoticiasCampanas("divPrincipalNoticias", "divPrincipalAnadirNoticia");
    }
    else
        bootbox.alert("Lo sentimos.\nPor favor, inicie sesión en el sistema de lo contrario no podrá agregar noticias.");
}
function AnadirCampana() {
    if ($("#hdIdUsuario").val() != '') {
        var fechaActual = new Date();
        var fecha = fechaActual.getFullYear() + '-' + (fechaActual.getMonth() + 1) + '-' + fechaActual.getDate();
        AsignarValoresCampana(fecha, $("#hdIdUsuario").val(), 0, '', '', '');
        $("#tituloAnadirCampana").text("Añadir campaña");
        OcultarValidadoresCampana();
        cargaPlantillasAdminNoticiasCampanas("divPrincipalCampanas", "divPrincipalAnadirCampana");
    }
    else
        bootbox.alert("Lo sentimos.\nPor favor, inicie sesión en el sistema de lo contrario no podrá agregar campañas.");
}
function AsignarValoresNoticia(fechaNoticia, idUsuario, idNoticia, titulo, resumen, urlRecursoNoticia) {
    $('#dtpFechaNoticia').val(fechaNoticia);
    $('#fechaNoticiaInput').val(fechaNoticia);
    $('#hfidNoticiaModal').val(idNoticia);
    $('#hfidUsuarioNoticiaModal').val(idUsuario);
    $('#txtUrlNoticia').val(urlRecursoNoticia);
    $('#txtTituloNoticia').val(titulo);
    $('#txtResumenNoticia').val(resumen);

}
function AsignarValoresCampana(fechaNoticia, idUsuario, idNoticia, titulo, resumen, urlRecursoNoticia) {
    $('#dtpFechaCampana').val(fechaNoticia);
    $('#fechaCampanaInput').val(fechaNoticia);
    $('#hfidCampanaModal').val(idNoticia);
    $('#hfidUsuarioCampanaModal').val(idUsuario);
    $('#txtUrlCampana').val(urlRecursoNoticia);
    $('#txtTituloCampana').val(titulo);
    $('#txtResumenCampana').val(resumen);
}
function OcultarValidadoresNoticia() {
    $("#errorTituloNoticia").hide();
    $("#errorFechaNoticia").hide();
    $("#errorTituloNoticiaAsterisco").hide();
    $("#errorResumenNoticia").hide();
    $("#errorResumenNoticiaAsterisco").hide();  
}
function OcultarValidadoresCampana() {
    $("#errorTituloCampana").hide();
    $("#errorFechaCampana").hide();
    $("#errorTituloCampanaAsterisco").hide();
    $("#errorResumenCampana").hide();
    $("#errorResumenCampanaAsterisco").hide();
}
function GuardarNoticia() {
    OcultarValidadoresNoticia();
    var guardarRegistro = ValidarNoticia();
    if (guardarRegistro == true) {
        if ($("#hfidNoticiaModal").val() == '' || $("#hfidNoticiaModal").val() == '0') {
            $.ajax({
                type: "POST", url: '../../Views/Administracion/PublicarNoticias_ajax', data: { GuardarNoticia: $("#txtTituloNoticia").val() + '*' + $("#fechaNoticiaInput").val() + '*' + $("#txtResumenNoticia").val() + '*' + $("#txtUrlNoticia").val() + '*' + $("#hfidUsuarioNoticiaModal").val() }, traditional: true,
                beforeSend: function () {
                    waitblockUIParamPlanTrabajo('Guardando noticia...');
                },
                success: function (result) {
                    unblockUI();
                    if (result == '<||>') {
                        volverListadoNoticiasCampanas("divPrincipalAnadirNoticia", "divPrincipalNoticias");
                        BuscarTotalNoticiasPublicadas();
                        //$("#myModalIngresarNoticia").hidden = "hidden";
                        //$("#myModalIngresarNoticia").modal('toggle');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("error");
                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                }
            });
        }
        else {
            $.ajax({
                type: "POST", url: '../../Views/Administracion/PublicarNoticias_ajax', data: { EditarNoticia: $("#txtTituloNoticia").val() + '*' + $("#fechaNoticiaInput").val() + '*' + $("#txtResumenNoticia").val() + '*' + $("#txtUrlNoticia").val() + '*' + $("#hfidUsuarioNoticiaModal").val() + '*' + $("#hfidNoticiaModal").val() }, traditional: true,
                beforeSend: function () {
                    waitblockUIParamPlanTrabajo('Editar noticia...');
                },
                success: function (result) {
                    unblockUI();
                    if (result == '<||>') {
                        volverListadoNoticiasCampanas("divPrincipalAnadirNoticia", "divPrincipalNoticias");
                        BuscarTotalNoticiasPublicadas();
                        //$("#myModalIngresarNoticia").hidden = "hidden";
                        //$("#myModalIngresarNoticia").modal('toggle');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("error");
                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                }
            });
        }
        
    }
}
function GuardarCampana() {
    OcultarValidadoresCampana();
    var guardarRegistro = ValidarCampana();
    if (guardarRegistro == true) {
        if ($("#hfidCampanaModal").val() == '' || $("#hfidCampanaModal").val() == '0') {
            $.ajax({
                type: "POST", url: '../../Views/Administracion/PublicarCampanas_ajax', data: { GuardarCampana: $("#txtTituloCampana").val() + '*' + $("#fechaCampanaInput").val() + '*' + $("#txtResumenCampana").val() + '*' + $("#txtUrlCampana").val() + '*' + $("#hfidUsuarioCampanaModal").val() }, traditional: true,
                beforeSend: function () {
                    waitblockUIParamPlanTrabajo('Guardando campaña...');
                },
                success: function (result) {
                    unblockUI();
                    if (result == '<||>') {
                        BuscarTotalCampanasPublicadas();
                        volverListadoNoticiasCampanas("divPrincipalAnadirCampana", "divPrincipalCampanas");
                        //$("#myModalIngresarCampana").hidden = "hidden";
                        //$("#myModalIngresarCampana").modal('toggle');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("error");
                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                }
            });
        }
        else {
            $.ajax({
                type: "POST", url: '../../Views/Administracion/PublicarCampanas_ajax', data: { EditarCampana: $("#txtTituloCampana").val() + '*' + $("#fechaCampanaInput").val() + '*' + $("#txtResumenCampana").val() + '*' + $("#txtUrlCampana").val() + '*' + $("#hfidUsuarioCampanaModal").val() + '*' + $("#hfidCampanaModal").val() }, traditional: true,
                beforeSend: function () {
                    waitblockUIParamPlanTrabajo('Editar campaña...');
                },
                success: function (result) {
                    unblockUI();
                    if (result == '<||>') {
                        BuscarTotalCampanasPublicadas();
                        volverListadoNoticiasCampanas("divPrincipalAnadirCampana", "divPrincipalCampanas");
                        //$("#myModalIngresarCampana").hidden = "hidden";
                        //$("#myModalIngresarCampana").modal('toggle');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("error");
                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                }
            });
        }

    }
}
function ValidarNoticia() {
    if ($("#fechaNoticiaInput").val() == '') {
        $("#errorFechaNoticia").show();
        return false;
    }
    if ($("#txtTituloNoticia").val() == '') {
        $("#errorTituloNoticia").show();
        return false;
    }
    if ($("#txtResumenNoticia").val() == '') {
        $("#errorResumenNoticia").show();
        return false;
    }
    var descripcionNoticiaAsterisco = $("#txtResumenNoticia").val().split('*');
    if (descripcionNoticiaAsterisco.length > 1) {
        $("#errorResumenNoticiaAsterisco").show();
        return false;
    }
    var tituloNoticiaAsterisco = $("#txtTituloNoticia").val().split('*');
    if (tituloNoticiaAsterisco.length > 1) {
        $("#errorTituloNoticiaAsterisco").show();
        return false;
    }
    return true;
}
function ValidarCampana() {
    if ($("#fechaCampanaInput").val() == '') {
        $("#errorFechaCampana").show();
        return false;
    }
    if ($("#txtTituloCampana").val() == '') {
        $("#errorTituloCampana").show();
        return false;
    }
    if ($("#txtResumenCampana").val() == '') {
        $("#errorResumenCampana").show();
        return false;
    }
    var descripcionCampanaAsterisco = $("#txtResumenCampana").val().split('*');
    if (descripcionCampanaAsterisco.length > 1) {
        $("#errorResumenCampanaAsterisco").show();
        return false;
    }
    var tituloCampanaAsterisco = $("#txtTituloCampana").val().split('*');
    if (tituloCampanaAsterisco.length > 1) {
        $("#errorTituloCampanaAsterisco").show();
        return false;
    }
    return true;
}
function EditarNoticia(idNoticia, titulo, fechaNoticia, resumen, urlNoticia) {
    if ($("#hdIdUsuario").val() != '') {
        AsignarValoresNoticia(fechaNoticia, $("#hdIdUsuario").val(), idNoticia, titulo, resumen, urlNoticia);
        OcultarValidadoresNoticia();
        cargaPlantillasAdminNoticiasCampanas("divPrincipalNoticias", "divPrincipalAnadirNoticia");
    }
    else
        bootbox.alert("Lo sentimos.\nPor favor, inicie sesión en el sistema de lo contrario no podrá editar noticias.");
}
function EditarCampana(idNoticia, titulo, fechaNoticia, resumen, urlNoticia) {
    if ($("#hdIdUsuario").val() != '') {
        AsignarValoresCampana(fechaNoticia, $("#hdIdUsuario").val(), idNoticia, titulo, resumen, urlNoticia);
        OcultarValidadoresCampana();
        $("#tituloAnadirCampana").text("Editar campaña");
        cargaPlantillasAdminNoticiasCampanas("divPrincipalCampanas", "divPrincipalAnadirCampana");
    }
    else
        bootbox.alert("Lo sentimos.\nPor favor, inicie sesión en el sistema de lo contrario no podrá agregar campañas.");
}
function volverListadoNoticiasCampanas(objOcultar, objMostrar) {
    $("#" + objMostrar).slideDown(function () {
        $("#" + objOcultar).slideUp(function () {
            $("#" + objOcultar).hide();
        });
    });

}
function cargaPlantillasAdminNoticiasCampanas(objOcultar, objMostrar) {
    $("#" + objOcultar).slideUp(function () {
        $("#" + objMostrar).slideDown(function () {

            $("#" + objMostrar).show();

        });
    });
}
function VerDetalleNoticia()
{
    $.ajax({
        type: "POST",
        url: '../../Views/Informacion/verDetalleNoticia_ajax', data: { ObtenerDetalleNoticia: $("#hfIdDetalleNoticia").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Buscando Noticia...');
        },
        success: function (result) {
            $("#txtTituloNoticia").val(result.Head[0].Titulo);
            $("#txtResumenNoticia").val(result.Head[0].Resumen);
            $("#fechaDetalleNoticia").val(result.Head[0].FechaNoticia);
            $("#imgDetalleNoticia").val(result.Head[0].ImagenUrl);
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });
}

