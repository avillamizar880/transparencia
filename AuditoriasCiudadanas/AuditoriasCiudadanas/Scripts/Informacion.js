
function CargarNoticias() {
    if ($("#hfOpcionBusqueda").val() == "") $("#hfOpcionBusqueda").val("Proyectos");
    if ($("#hfOpcionBusqueda").val() == "Proyectos") {

        $.ajax({
            type: "POST",
            url: '../../Views/AccesoInformacion/BuscadorProyectosAuditores_ajax', data: { BuscarTotalProyectosAuditables: $("#txtPalabraClave").val() },
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
    }
    else {
        $.ajax({
            type: "POST",
            url: '../../Views/AccesoInformacion/BuscadorProyectosAuditores_ajax', data: { BuscarTotalAuditores: $("#txtPalabraClave").val() },
            traditional: true,
            cache: false,
            dataType: "json",
            beforeSend: function () {
                waitblockUIParam('Buscando auditores...');
            },
            success: function (result) {
                GenerarPaginador(result);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }

        });
    }
}