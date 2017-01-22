function ConsultarInformeHallazgo()
{

    //$.ajax({
    //    type: "POST",
    //    url: '../../Views/VerificacionAnalisis/InformeHallazgo_ajax', data: { BuscarHallazgosReportados: $("#txtPalabraClave").val() },
    //    traditional: true,
    //    cache: false,
    //    dataType: "json",
    //    beforeSend: function () {
    //        waitblockUIParam('Buscando proyectos...');
    //    },
    //    success: function (result) {
    //        GenerarPaginador(result);
    //    },
    //    error: function (XMLHttpRequest, textStatus, errorThrown) {
    //        alert("error");
    //        alert(textStatus + ": " + XMLHttpRequest.responseText);
    //    }

    //});


    $("#recursoMultimediaHallazgo").fileinput({
        uploadUrl: "http://localhost/file-upload-single/1", // server upload action
        uploadAsync: true,
        maxFileCount: 5
    });
}
function GuardarInformeHallazgo()
{
    var mensajeAsterisco = $("#txtHallazgo").val().split('*');
    $("#errorRecursoMultimediaHallazgo").hide();
    if (mensajeAsterisco.length > 1)
    {
        $("#errorHallazgo").html('No se permite el uso del caracter * en el nombre del hallazgo.');
        $("#errorHallazgo").show();
        return false;
    }
    if ($("#txtHallazgo").val() == '')
    {
        $("#errorHallazgo").html('Por favor ingrese una descripción del hallazgo.');
        $("#errorHallazgo").show();
        return false;
    }
    if ($("#recursoMultimediaHallazgo").val() == '') {
        $("#errorRecursoMultimediaHallazgo").html('Por favor ingrese una descripción del hallazgo.');
        $("#errorRecursoMultimediaHallazgo").show();
        return false;
    }
    return true;
}

function guardarInformeHallazgo()
{
    var guardarDatos = GuardarInformeHallazgo();
    if (guardarDatos == true) {
        $.ajax({
            type: "POST",
            //url: '../../Views/VerificacionAnalisis/InformeHallazgo_ajax', data: { GuardarInformeHallazgo: $("#txtHallazgo").val() + '*' + $("#recursoMultimediaHallazgo").val() + '*' + $("#hfIdGrupoGac").val() + '*' + $("#hfIdUsuario").val() },
            url: '../../Views/VerificacionAnalisis/InformeHallazgo_ajax', data: { GuardarInformeHallazgo: $("#txtHallazgo").val() + '*' + $("#hfIdGrupoGac").val() + '*' + $("#hfIdUsuario").val() },
            traditional: true,
            cache: false,
            dataType: "json",
            beforeSend: function () {
                waitblockUIParam('Guardando hallazgo...');
            },
            success: function (result)
            {
                alert();
                GenerarPaginador(result);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
    else alert("Se presentaron inconsistencias al guardar este reporte.\nRevise los mensajes que aparecen en la pantalla.");
}