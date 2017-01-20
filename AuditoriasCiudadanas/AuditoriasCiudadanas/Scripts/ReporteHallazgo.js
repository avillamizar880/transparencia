function ConsultarInformeHallazgo()
{

    $.ajax({
        type: "POST",
        url: '../../Views/VerificacionAnalisis/InformeHallazgo_ajax', data: { BuscarHallazgosReportados: $("#txtPalabraClave").val() },
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


    $("#recursoMultimediaHallazgo").fileinput({
        uploadUrl: "http://localhost/file-upload-single/1", // server upload action
        uploadAsync: true,
        maxFileCount: 5
    });
}