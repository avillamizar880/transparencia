$('#ddlCategoria').bind('onchange change', function () {
    $('#ddlTipoReporte option:selected').removeAttr('selected');
    $('#ddlTipoReporte option').show();
    var grupo = $("#ddlCategoria option:selected").val();
    $('#ddlTipoReporte option').not("[grupo*=" + grupo + "]").hide();
    
});

$('#ddlTipoReporte').bind('onchange change', function () {
    var filtros = $('#ddlTipoReporte option:selected').attr('filtros_fecha');
    if (filtros == "1") {
        $("#divFechas").show();
    } else {
        $("#divFechas").hide();
    }
});