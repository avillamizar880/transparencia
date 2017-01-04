function BuscarGruposAuditorCiudadano()
{
    $.ajax({
        type: "POST",
        url: '../../Views/GestionGAC/RetiroGac_ajax', data: { BuscarTotalGac: $("#txtPalabraClaveGac").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Buscando auditores ciudadanos...');
        },
        success: function (result) {
            GenerarPaginadorGac(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
}
function GenerarPaginadorGac(result)
{
    $("#datosEncontradosGac").html();
    var totalGac = 0;
    if (result != null && result != "" && result.Head.length >= 0)
        totalGac = parseInt(result.Head[0].Total);
    if (totalGac.toString() != "NaN") {
        if (totalGac == 1) $("#datosEncontrados").html(totalGac.toString() + ' registro encontrado');
        else $("#datosEncontrados").html(totalGac.toString() + ' registros encontrados');
        if (totalGac == 0)
        {
            $("#datos").html('');
            $("#navegadorResultados").hide();
            unblockUI();
        }
        else
        {
            var paginasPosibles = totalGac / 20;
            if (paginasPosibles > 1)
            {
                $("#navegadorResultadosGac").show();
                var paginasEnteras = parseInt(paginasPosibles);
                if (paginasEnteras < paginasPosibles) paginasEnteras++;
                $("#navegadorResultadosGac").html();
                var contenidopreview = '<li><a href="#" aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>';
                var contenidoPaginas = '';
                for (var i = 1; i <= paginasEnteras; i++)
                    contenidoPaginas = contenidoPaginas + '<li id="Pag_" ' + i + ' onclick="CargarDatosProyectosAuditores(' + i + ')">' + '<a href="#">' + i + '</a></li>';
                var contenidoNext = '<li><a href="#" aria-label="Next"><span aria-hidden="true">&raquo;</span></a></li>';
                $("#paginador").html(contenidopreview + contenidoPaginas + contenidoNext);
            }
            else $("#navegadorResultados").hide();
            CargarDatosGac(1);
        }
    }
    else unblockUI();
}
function CargarDatosGac(paginaSeleccionada)
{
   $.ajax({
            type: "POST",
            url: '../../Views/GestionGAC/RetiroGac_ajax', data: { BuscarGac: $("#txtPalabraClaveGac").val() + "*" + paginaSeleccionada + "*20" },
            traditional: true,
            cache: false,
            dataType: "json",
            beforeSend: function () {
                waitblockUIParam('Cargar datos grupos auditores ciudadanos...');
            },
            success: function (result)
            {
                var datasource = '';
                if (result != null && result != "")
                {
                    for (var i = 0; i < result.Head.length; i++)
                    {
                        var mensajeGac = '  Vincular grupo ';
                        var iconGac = 'glyphicon glyphicon-thumbs-up';
                        if (result.Head[i].EstadoGrupo == "1")
                        {
                            mensajeGac = "Desvincular grupo";
                            iconGac = 'glyphicon glyphicon-thumbs-down';
                        }
                        var iconMiembroGac = "glyphicon glyphicon-hand-up";
                        var mensajeUsuario = '  Vincular miembro ';
                        if (result.Head[i].EstadoUsuario == "1")
                        {
                            mensajeUsuario = "Desvincular miembro";
                            iconMiembroGac = "glyphicon glyphicon-hand-down";
                        }

                        datasource = datasource +
                                 '<div class="list-group-item">' +
                                 '<div class="col-sm-0" hidden="hidden"><p class="list-group-item-text"><a href="#">' + paginaSeleccionada + '</a></p></div>' +
                                 '<div class="col-sm-0" hidden="hidden"><p class="list-group-item-text"><a href="#">' + result.Head[i].idMiembroGac + '</a></p></div>' +
                                 '<div class="col-sm-0" hidden="hidden"><p class="list-group-item-text"><a href="#">' + result.Head[i].idGac + '</a></p></div>' +
                                 '<div class="col-sm-3"><span></span><span>' + result.Head[i].CodigoBPIN + '</span></div>' +
                                 '<div class="col-sm-3"><span class="glyphicon glyphicon-user">' + ' ' + result.Head[i].Nombre + '</span></div>' +
                                 '<div class="col-sm-6 opcionesList">' +
                                 '<a role="button" onclick="ActivarDesactivarMiembroGac(' + paginaSeleccionada + ',' + result.Head[i].idMiembroGac + ',' + result.Head[i].EstadoUsuario + ')"><span class="' + iconMiembroGac + '"></span><span>' + mensajeUsuario + '</span></a>' +
                                 '<a role="button" onclick="ActivarDesactivarGac(' + paginaSeleccionada + ',' + result.Head[i].idGac + ',' + result.Head[i].EstadoGrupo + ')"><span class="' + iconGac + '"></span><span>' + mensajeGac + '</span></a>' +
                                 '</div>' +
                                 '</div>';
                    }
                }
                $("#datosGac").html(datasource);
                $('#TituloPagina').html('Resultados de la Búsqueda');
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });  
}
function ActivarDesactivarMiembroGac(paginaSeleccionada, idMiembroGac, estadoMiembroGrupo) {
    var mensajeConfirmacion = '¿Desea desvincular este miembro del grupo de auditoria ciudadana?';
    if (estadoMiembroGrupo != "1") mensajeConfirmacion = '¿Desea vincular este miembro del grupo de auditoria ciudadana?';
    if (confirm(mensajeConfirmacion))
    {
        $.ajax({
            type: "POST", url: '../../Views/GestionGAC/RetiroGac_ajax', data: { ModificarEstadoMiembroGac: idMiembroGac + '*' + estadoMiembroGrupo }, traditional: true,
            beforeSend: function () {
                waitblockUIParam('Modificando estado miembro del grupo auditor ciudadano...');
            },
            success: function (result)
            {
                if (result == "<||>") {
                    CargarDatosGac(paginaSeleccionada);
                }
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
}
function ActivarDesactivarGac(paginaSeleccionada, idMiembroGac, estadoGrupo)
{
    var mensajeConfirmacion = '¿Desea desvincular este grupo de auditoria ciudadana?';
    if (estadoGrupo != "1") mensajeConfirmacion = '¿Desea vincular este grupo de auditoria ciudadana?';
    if (confirm(mensajeConfirmacion))
    {
        $.ajax({
            type: "POST", url: '../../Views/GestionGAC/RetiroGac_ajax', data: { ModificarEstadoGac: idMiembroGac + '*' + estadoGrupo }, traditional: true,
            beforeSend: function () {
                waitblockUIParam('Modificando estado del grupo auditor ciudadano...');
            },
            success: function (result)
            {
                if (result == "<||>")
                {
                    CargarDatosGac(paginaSeleccionada);
                }
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
}


