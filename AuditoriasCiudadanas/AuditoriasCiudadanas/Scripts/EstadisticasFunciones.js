function ObtenerReporteEstadisticas() {
    var tipo = $('#ddlTipoReporte option:selected').val();
    var fecha_ini = $("#FechaInicioCorte").val();
    var fecha_fin = $("#FechaFinCorte").val();
    if ($('#ifrExcelEncuesta').length == 0) {
        $('#divOtros').append('<iframe id="ifrExcelEncuesta" name="ifrExcelEncuesta" width="0" height="0" style="width:0px;height:0px;float:right;"></iframe><form id="frmExpExcel" name="frmExpExcel" style="display:none;float:right;" target="ifrExcelEncuesta" method="POST" action="/Views/Estadisticas/infoEstadisticas_ajax"></form>');
    }
    $('#frmExpExcel').html('<input type="hidden" id="tipo_reporte" name="tipo_reporte" value="' + tipo + '" /><input type="hidden" id="fecha_ini" name="fecha_ini" value="' + fecha_ini + '" /><input type="hidden" id="fecha_fin" name="fecha_fin" value="' + fecha_fin + '" />');
    $('#frmExpExcel').submit();

}