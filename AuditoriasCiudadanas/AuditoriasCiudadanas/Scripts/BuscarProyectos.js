function CambiarEstado(nombreControl)
{
    alert(nombreControl);
}
function CargarProyectosAuditores() {
    $.ajax({
        type: "POST",
        url: '../../Views/AccesoInformacion/BuscadorProyectosAuditores_ajax', data: { BuscarTotalProyectosAuditables: $("#txtPalabraClave").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Buscando proyectos...');
        },
        success: function (result) {
            $("#datosEncontrados").html();
            var totalProyectos = 0;
            if (result != null && result != "" && result.Head.length >= 0)
                totalProyectos = parseInt(result.Head[0].Total);
            if (totalProyectos.toString() != "NaN") {
                $("#datosEncontrados").html(totalProyectos.toString() + ' registros encontrados');
                if (totalProyectos == 0) unblockUI();
                else {
                    var paginasPosibles = totalProyectos / 20;
                    if (paginasPosibles > 1) {
                        $("#navegadorResultados").show();
                        var paginasEnteras = parseInt(paginasPosibles);
                        if (paginasEnteras < paginasPosibles) paginasEnteras++;
                        $("#navegadorResultados").html();
                        var contenidopreview = '<li><a href="#" aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>';
                        var contenidoPaginas = '';
                        for (var i = 1; i <= paginasEnteras; i++)
                            contenidoPaginas = contenidoPaginas + '<li id="Pag_" ' + i + ' onclick="CargarDatosProyectosAuditores(' + i + ')">' + '<a href="#">' + i + '</a></li>';
                        var contenidoNext = '<li><a href="#" aria-label="Next"><span aria-hidden="true">&raquo;</span></a></li>';
                        $("#paginador").html(contenidopreview + contenidoPaginas + contenidoNext);
                    }
                    else $("#navegadorResultados").hide();
                    CargarDatosProyectosAuditores(1);
                }
            }
            else unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
}
function CargarDatosProyectosAuditores(paginaSeleccionada) {
    if ($("#r_Auditores").is(':checked')) {
        $.ajax({
            type: "POST",
            url: '../../Views/AccesoInformacion/BuscadorProyectosAuditores_ajax', data: { BuscarAuditoresPalabraClave: $("#txtPalabraClave").val() },
            traditional: true,
            cache: false,
            dataType: "json",
            beforeSend: function () {
                waitblockUIParam('Cargar datos auditores...');
            },
            success: function (result) {
                var datasource = '';
                if (result != null && result != "") {
                    for (var i = 0; i < result.Head.length; i++) {
                        datasource = datasource +
                                 '<div class="list-group-item">' +
                                 '<div class="col-sm-2" hidden="hidden"><p class="list-group-item-text"><a href="#">' + result.Head[i].IdUsuario + '</a></p></div>' +
                                 '<div class="col-sm-3"><span>' + result.Head[i].Nombre + '</span></div>' +
                                 '<div class="col-sm-3"><span></span><span>' + result.Head[i].TipoAuditor + '</span></div>' +
                                 '<div class="col-sm-2"><a href="#"><span class="glyphicon glyphicon-envelope fa-5x"><span></span></span></a></div>' +
                                 '<div class="col-sm-2"><img id="rutaImagen" src="../../Images/CatAuditor/' + result.Head[i].Imagen + '" width="40">' + '</img></div>' +
                                 '<div class="col-sm-2"><span></span>' + result.Head[i].LimiteInferior + "-" + result.Head[i].LimiteSuperior + '</div>' +
                                 '</div>';
                    }
                }
                $("#datos").html(datasource);
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }

        });
    }
    else {
        $.ajax({
            type: "POST",
            url: '../../Views/AccesoInformacion/BuscadorProyectosAuditores_ajax', data: { BuscarProyectosPalabraClave: $("#txtPalabraClave").val() + "*" + paginaSeleccionada + "*20" },
            traditional: true,
            cache: false,
            dataType: "json",
            beforeSend: function () {
                waitblockUIParam('Cargando datos proyectos...');
            },
            success: function (result) {
                var datasource = '';
                if (result != null && result != "") {
                    for (var i = 0; i < result.Head.length; i++) {
                        datasource = datasource +
                                 '<div class="list-group-item">' +
                                 '<div class="col-sm-2" hidden="hidden"><p class="list-group-item-text"><a href="#">' + result.Head[i].CodigoBPIN + '</a></p></div>' +
                                 '<div class="col-sm-5"><span>' + result.Head[i].Objeto + '</span></div>' +
                                 '<div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>' + result.Head[i].Localizacion + '</span></div>' +
                                 '<div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>' + result.Head[i].Ejecutor + '</div>' +
                                 '<div class="col-sm-3 opcionesList">' +
                                 '<a href="#"><span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span></a>' +
                                 '<a href="#"><span><img src="../../Content/img/iconHand.png" /></span></a>' +
                                 '<a role="button" onclick="obtInfoProyecto(\'' + result.Head[i].CodigoBPIN + '\');"><span class="glyphicon glyphicon-info-sign"></span><span>Información</span></a>' +
                                 '</div>' +
                                 '</div>';
                    }
                }
                $("#datos").html(datasource);
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }

        });
    }
}
function prueba(obj) {
    var codigo = $(obj).closest('.det_bpin').val();
    alert(codigo);
}
function waitblockUIParam(mensaje) { $.blockUI({ message: "<h2>" + mensaje + "</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }
//function ActivarEstiloBoton() {
//    $("#OpcionesBusqueda").buttonset();
//}