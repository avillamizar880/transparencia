
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