$("#btnAddPregunta").click(function () {
    $("#divContenedorPreguntas").slideDown(function () {
       
    });
});

$('#ddlTipoPregunta').bind('change', function () {
    var val_tipo = $('option:selected', $(this)).val();
    if (val_tipo == "1") {
        $(".well").hide();
        $('#divPregTexto').show();
    } else if (val_tipo == "2") {
        $(".well").hide();
        $('#divPregRadio').show();
    } else if (val_tipo == "3") {
        $(".well").hide();
        $('#divPregCheckbox').show();
    } else if (val_tipo == "4") {
        $(".well").hide();
        $('#divPregTextArea').show();
    } else if (val_tipo == "5") {
        $(".well").hide();
        $('#divPregEscala').show();
    } else if (val_tipo == "6") {
        $(".well").hide();
        $('#divPregFecha').show();
    } else if (val_tipo == "7") {
        $(".well").hide();
        $('#divPregTiempo').show();
    } else {
        $(".well").hide();
    }
});