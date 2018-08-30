function CambiarEstado(nombreControl) {
    alert(nombreControl);
}
function ObtenerOpcionProyectosAuditores(opcion) {
    $("#hfOpcionBusqueda").val(opcion);
    if (opcion == "Proyectos") {
        $("#txtPalabraClave").attr("placeHolder", "Nueva búsqueda de proyecto");
        $('#TituloPagina').html('Listado de proyectos');
    } else {
        $("#txtPalabraClave").attr("placeHolder", "Nueva búsqueda de auditor");
        $('#TituloPagina').html('Listado de auditores');
    }
    CargarProyectosAuditores();
}

function CargarProyectosAuditores()
{
    if ($("#hfOpcionBusqueda").val() == "") $("#hfOpcionBusqueda").val("Proyectos");
    if ($("#hfOpcionBusqueda").val() == "Proyectos") {

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
                GenerarPaginador(result);
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
            url: '../../Views/AccesoInformacion/BuscadorProyectosAuditores_ajax', data: { BuscarTotalAuditores: $("#txtPalabraClave").val() },
            traditional: true,
            cache: false,
            dataType: "json",
            beforeSend: function () {
                waitblockUIParam('Buscando auditores...');
            },
            success: function (result) {
                GenerarPaginador(result);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }

        });
    }
}

function GenerarPaginador(result) {
    $("#datosEncontrados").html();
    var totalProyectos = 0;
    if (result != null && result != "" && result.Head.length >= 0)
        totalProyectos = parseInt(result.Head[0].Total);
    if (totalProyectos.toString() != "NaN") {
        if (totalProyectos == 1) $("#datosEncontrados").html(totalProyectos.toString() + ' registro encontrado');
        else $("#datosEncontrados").html(totalProyectos.toString() + ' registros encontrados');
        if (totalProyectos == 0) {
            $("#datos").html('');
            $("#navegadorResultados").hide();
            unblockUI();
        }
        else {
            var paginasPosibles = totalProyectos / 20;
            if (paginasPosibles > 1) {
                $("#navegadorResultados").show();
                var paginasEnteras = parseInt(paginasPosibles);
                if (paginasEnteras < paginasPosibles) paginasEnteras++;
                $("#navegadorResultados").html();
                var contenidopreview = '<li id="Pag_prev" onclick="CargarDatosProyectosAuditoresPreview()"><a href="#" aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>';
                var contenidoPaginas = '';
                $("#ultimaPagina").text(paginasEnteras);
                for (var i = 1; i <= paginasEnteras; i++)
                    contenidoPaginas = contenidoPaginas + '<li id="Pag_" ' + i + ' onclick="CargarDatosProyectosAuditores(' + i + ')">' + '<a href="#">' + i + '</a></li>';
                var contenidoNext = '<li id="Pag_next" onclick="CargarDatosProyectosAuditoresNext()"><a href="#" aria-label="Next"><span aria-hidden="true">&raquo;</span></a></li>';
                $("#paginador").html(contenidopreview + contenidoPaginas + contenidoNext);
            }
            else $("#navegadorResultados").hide();
            CargarDatosProyectosAuditores(1);
        }
    }
    else unblockUI();
}
function CargarDatosProyectosAuditores(paginaSeleccionada) {
    if ($("#hfOpcionBusqueda").val() == "Auditores") {
        $.ajax({
            type: "POST",
            url: '../../Views/AccesoInformacion/BuscadorProyectosAuditores_ajax', data: { BuscarAuditoresPalabraClave: $("#txtPalabraClave").val() + "*" + paginaSeleccionada + "*20" },
            traditional: true,
            cache: false,
            dataType: "json",
            beforeSend: function () {
                waitblockUIParam('Cargar datos auditores...');
            },
            success: function (result) {
                var datasource = '';
                if (result != null && result != "") {
                    //add rotulos
                    datasource += '<div class="list-group-item etiqueta">' +
                         '<div class="col-sm-2" hidden="hidden"></div>' +
                         //'<div class="col-sm-1"><span>Imagen</span></div>' +
                         '<div class="col-sm-5"><span class="glyphicon glyphicon-user"></span><span>' + ' Nombre' + '</span></div>' +
                         //'<div class="col-sm-4"><span>' + 'Categoría' + '</span></div>' +
                         //'<div class="col-sm-1"></div>' +
                         //'<div class="col-sm-1"><span>Rango</span></div>' + 
                         '</div>';

                    for (var i = 0; i < result.Head.length; i++)
                    {
                        var rutaImagen = '';
                        if (result.Head[i].Imagen != null) rutaImagen = "<img id='rutaImagen' src=../../Images/CatAuditor/" + result.Head[i].Imagen + '" width="40"/>';
                        var nombreAuditor = '';
                        if (result.Head[i].Nombre != null) nombreAuditor = result.Head[i].Nombre;
                        var tipoAuditor = '';
                        if (result.Head[i].TipoAuditor != null) tipoAuditor = result.Head[i].TipoAuditor;
                        var limites = '';
                        if (result.Head[i].LimiteInferior != null && result.Head[i].LimiteSuperior != null) limites = ' ' + result.Head[i].LimiteInferior + "-" + result.Head[i].LimiteSuperior;
                        datasource = datasource +
                                 '<div class="list-group-item">' +
                                 '<div class="col-sm-2" hidden="hidden"><p class="list-group-item-text"><a href="#">' + result.Head[i].IdUsuario + '</a></p></div>' +
                                 //'<div class="col-sm-1">' + rutaImagen + '</div>' +
                                 '<div class="col-sm-5"><span class="glyphicon glyphicon-user"></span><span>' + ' ' + nombreAuditor + '</span></div>' +
                                 //'<div class="col-sm-4"><span></span><span>' + tipoAuditor + '</span></div>' +
                                 //'<div class="col-sm-1"><a href="#"><span class="glyphicon glyphicon-comment"><span></span></span></a></div>' +
                                 //'<div class="col-sm-1"><a href=""><span class="label label-info"><span class="glyphicon glyphicon-star"> </span>' + limites + '</span></a></div>' +
                                 '</div>';
                    }
                }
                $("#divContenedorDatos").addClass("w70");
                $("#datos").html(datasource);
                
                $('#TituloPagina').html('Listado de auditores');
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
                    //add rotulos
                    datasource += '<div class="list-group-item etiqueta">' +
                         '<div class="col-sm-2" hidden="hidden"></div>' +
                         '<div class="col-sm-5"><span>' + 'Nombre del proyecto' + '</span></div>' +
                         '<div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>' + ' Lugar de ejecución' + '</span></div>' +
                         '<div class="col-sm-2"><span class="glyphicon glyphicon-user"></span><span>' + ' Entidad ejecutora' + '</span></div>' +
                         '<div class="col-sm-3"><span>' + ' ' + '</span></div>' +
                         '</div>';
                    for (var i = 0; i < result.Head.length; i++) {
                        var total_gac = result.Head[i].TotalGac;
                        var texto_gac = "Participar";
                        datasource += '<div class="list-group-item">' +
                                 '<div class="col-sm-2" hidden="hidden"><p class="list-group-item-text"><a href="#">' + result.Head[i].CodigoBPIN + '</a></p></div>' +
                                 '<div class="col-sm-5"><span>' + result.Head[i].Objeto + '</span></div>' +
                                 '<div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>' + result.Head[i].Localizacion + '</span></div>' +
                                 '<div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>' + result.Head[i].Ejecutor + '</div>' +
                                 '<div class="col-sm-3 opcionesList">';
           
                        if (($(".LogIn").attr("menu") != "4")&&($(".LogIn").attr("menu") != "1")) {
                            datasource += '<a role="button" onclick="seguirProyecto(\'' + result.Head[i].CodigoBPIN + '\');" title="La opción SEGUIR le permite recibir en su correo electrónico información sobre los avances del proyecto o de la gestión del Grupo Auditor Ciudadano que lo vigila."><span class="glyphicon glyphicon-pushpin" ></span><span>Seguir</span></a>' +
                            '<a role="button"  onclick="selectInfoGrupos(\'' + result.Head[i].CodigoBPIN + '\');" title="La opción PARTICIPAR le permite crear o unirse a un Grupo Auditor Ciudadano para vigilar este proyecto con otros auditores"><span><img src="../../Content/img/iconHand.png"  /></span><span>' + texto_gac + '</span></a>';
                        }
                        datasource += '<a role="button" title="La opción INFORMACIÓN le permite visualizar información detallada de los proyectos en aspectos relevantes como presupuesto, contratación, actividades a ejecutar o en ejecución, entre otros." onclick="obtInfoProyecto(\'' + result.Head[i].CodigoBPIN + '\');"><span class="glyphicon glyphicon-info-sign"></span><span>Información</span></a>' +
                                 '</div>' +
                                 '</div>';
                    }
                }
                $("#divContenedorDatos").removeClass("w70");
                $("#datos").html(datasource);
                $('#TituloPagina').html('Listado de proyectos');
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }

        });
    }
    $("#paginaActual").text(paginaSeleccionada);
}


function CargarDatosProyectosAuditoresPreview() {
    if ($("#paginaActual").text() != '')
    {
        var paginaActual = parseInt($("#paginaActual").text());
        if (paginaActual > 1)
            CargarDatosProyectosAuditores(paginaActual-1);
    }
}
function CargarDatosProyectosAuditoresNext() {
    if ($("#paginaActual").text() != '') {
        var paginaActual = parseInt($("#paginaActual").text());
        var maxPagina = parseInt($("#ultimaPagina").text());
        if (paginaActual < maxPagina)
            CargarDatosProyectosAuditores(paginaActual + 1);
    }
}


function prueba(obj) {
    var codigo = $(obj).closest('.det_bpin').val();
    alert(codigo);
}
function waitblockUIParam(mensaje) { $.blockUI({ message: "<h2>" + mensaje + "</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }
