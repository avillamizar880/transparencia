
function BuscarTotalNoticias() {
    $.ajax({
        type: "POST",
        url: '../../Views/Informacion/verNoticias_ajax', data: { BuscarTotalNoticias: $("#txtPalabraClaveNoticias").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Buscando noticias...');
        },
        success: function (result) {
            //alert("Se han encontrado " + result + " resultados");
            GenerarPaginadorNoticias(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
}

function GenerarPaginadorNoticias(result) {
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