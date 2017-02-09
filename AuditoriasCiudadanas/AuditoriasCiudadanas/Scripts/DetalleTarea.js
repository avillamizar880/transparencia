function MostrarDetallePlanTrabajo()
{
    if ($("#hfTitulo").val() != null)
    {
        $("#tareaActaReuniones").hide();
        $("#tareaDiarioNotas").hide();
        $("#tareaVisitaCampo").hide();
        switch ($("#hfTitulo").val().toUpperCase().trim())
        {
            case "VISITA DE CAMPO":
                $("#tareaVisitaCampo").show();
                break;
            case "ACTAS REUNIONES":
                $("#tareaActaReuniones").show();
                CargarInformacionActasReuniones();
                break;
            case "DIARIO DE NOTAS":
                $("#tareaVisitaCampo").show();
                break;
            case "REGISTRO FOTOGRÁFICO":
                break;
        }
    }
}

function CargarInformacionActasReuniones()
{
    $("fechaTareaActaReuniones").html('<span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: ' + $("#hfFechaTarea").val());
    $("#horaTareaActaReuniones").html('<span class="glyphicon glyphicon-calendar"></span>&nbsp; Hora:' + $("#hfHoraTarea").val());
    $.ajax(
    {
        type: "POST",
        url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { Buscardetalletareaactasreuniones: $("#hfidTarea").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function ()
        {
            waitblockUIParamDetalleTarea('Cargando detalle actas reuniones...');
        },
        success: function (result)
        {
            if (result.Head.length > 0) {
                for (var i = 0; i < result.Head.length; i++)
                {
                    $("#tareaTemasReuniones").html(result.Head[0].Temas);
                }
            }
            else
            {
                $("#tareaTemasReuniones").html('<p></p>');
                $("#tareaCompromisos").html('');
                $("#tareaAsistentes").html('<p>Documento o imagen</p>');
            }
            unblockUIDetalleTarea();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUIDetalleTarea();
        }
    });
}

function waitblockUIParamDetalleTarea(mensaje) { $.blockUI({ message: "<h2>" + mensaje + "</h2>" }); }
function unblockUIDetalleTarea() { $.unblockUI(); }
