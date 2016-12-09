function obtDetProyecto_2(id_proyecto) {
    $.ajax({
        url: "../../Views/Proyectos/infoProyecto",
        cache: false,
        method: "POST",
        data: { id_proyecto: id_proyecto },
        dataType: "html",

        success: function (data) {
            $("#divContenedor").html(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("@hageneradoerror");
            //alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });
    

}

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

