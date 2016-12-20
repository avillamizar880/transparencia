function EnviarEncuesta() {
    $.ajax({
        type: "POST", url: '../../Views/Caracterizacion/EvaluarExperiencia_ajax', data: { Guardar: $("#selVinculacionActual").val() + '*' + $("#txtVinculacionActual").val() + '*' + $("#selMecanismosParticipacion").val() + '*' + $("#txtMecanismosParticipacion").val() + '*' + $("#selEspacioCiudadanoFuncionario").val() + '*' + $("#txtEspacioCiudadanoFuncionario").val() + '*' + $("#selRecursosAlcaldia").val() + '*' + $("#selAuditoriasVisibles").val() }, traditional: true,
        beforeSend: function () {
            waitblockUIValidacion();
        },
        success: function (result) {
            if (result == 'True') {
                window.location = 'EncuestaParte3';
            }
            unblockUI();

        }
    });
}

function SeleccionarItem(control) {
    if ($("#sel" + control).val() == "Otra, ¿cuál?") $("#txt" + control).show();
    else {
        $("#txt" + control).html('');
        $("#txt" + control).hide();
        $("#error" + control).hide();
        $("#error" + control).html('');
    }
}