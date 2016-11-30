function obtDetProyecto(id_proyecto) {
    ajaxPost("../Proyectos/infoProyecto.aspx", { id_proyecto:id_proyecto }, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);

    }, function (e) {
        alert(e.responseText);
    });

}
