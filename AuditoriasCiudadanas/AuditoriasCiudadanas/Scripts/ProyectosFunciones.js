function obtInfoProyecto(id_proyecto) {
    ajaxPost('../../Views/Proyectos/infoProyecto', { id_proyecto: id_proyecto }, 'dvPrincipal', function (r) {
    }, function (e) {
        alert(e.responseText);
    });
}

function verDetalleProyecto(id_proyecto) {
    ajaxPost('../../Views/Proyectos/detalleProyecto_ajax', { id_proyecto: id_proyecto }, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
        
    }, function (e) {
        alert(e.responseText);
    });

}

function verInfoTecnica(id_info) {
    ajaxPost('detalleInfoTecnica_ajax', { id_info: id_info }, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
        $('#divDetalleFormCalidad').slideUp(); $('#divItemsCalidad').slideDown();
    }, function (e) {
        alert(e.responseText);
    });

}

