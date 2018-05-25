function ObtenerUrlCapacitacion(titulo) {
    console.log('Entrando url capacitación');
    $.ajax(
    {
        type: "POST",
        url: '../../Views/Capacitacion/CapacitacionInicialFaseI_ajax', data: {},
        traditional: true,
        cache: false,
        dataType: "text",// "json",
        beforeSend: function () {
            waitblockUIParamDetalleTarea('Obteniendo video...');
        },
        success: function (result) {
            result = result.replace("watch?v=", "embed/");
            if (titulo.toUpperCase() == 'CONTROL SOCIAL') {
                $("#player").attr('src', result);
            }
            else if (titulo.toUpperCase() == 'FUNCIONAMIENTO APLICATIVO') {
                $("#playerFaseII").attr('src', result);
                //$("#videocapinifaseII").html('<iframe id="player" src="' + result + '" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>' + '<br/>' + '<p id="progress" hidden="hidden"></p>');
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

