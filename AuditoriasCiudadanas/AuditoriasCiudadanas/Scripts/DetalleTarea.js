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
function GuardarTemasActaReunionTarea()
{
    var guardarRegistro = ValidarTemasActaReunionTarea();
    if (guardarRegistro == true)
    {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarTemaActaReunionTarea: $("#hfidTarea").val() + '*' + $("#txtTemasReuniones").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamDetalleTarea('Guardando temas acta reunión...');
            },
            success: function (result)
            {
                unblockUIDetalleTarea();
                if (result == '<||>')
                {
                    CargarInformacionActasReuniones();
                    $("#myModalTemasReunion").hidden = "hidden";
                    $("#myModalTemasReunion").modal('toggle');
                }
            }
        });
    }
}
function ValidarTemasActaReunionTarea()
{
    $("#errorTemasReuniones").hide();
    $("#errorTemasReunionesAsteriscos").hide();
    var caracteresEspeciales = $("#txtTemasReuniones").val().split('*');
    if ($("#txtTemasReuniones").val() == '')
    {
        $("#errorTemasReuniones").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1)
    {
        $("#errorTemasReunionesAsteriscos").show();
        return false;
    }
    return true;
}
function CargarInformacionActasReuniones()
{

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
            $("#fechaTareaActaReuniones").html('<span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: ' + $("#hfFechaTarea").val());
            $("#horaTareaActaReuniones").html('<span class="glyphicon glyphicon-calendar"></span>&nbsp; Hora:' + $("#hfHoraTarea").val());
            if (result.Head.length > 0) {
                for (var i = 0; i < result.Head.length; i++)
                {
                    $("#tareaTemasReuniones").html(result.Head[0].Temas);
                    $("#txtTemasReuniones").html(result.Head[0].Temas);
                }
            }
            else
            {
                $("#txtTemasReuniones").html('');
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
//function ObtenerTemaActaReunion()
//{
//    $("#txtTemasReuniones").html($("#tareaTemasReuniones").html());
//}
