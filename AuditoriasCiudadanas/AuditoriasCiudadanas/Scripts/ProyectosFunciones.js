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
    ajaxPost('../../Views/Proyectos/detalleInfoTecnica_ajax', { id_info: id_info }, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
        $('#divDetalleFormCalidad').slideUp(); $('#divItemsCalidad').slideDown();
    }, function (e) {
        alert(e.responseText);
    });

}

function UnirseGAC(id_grupo){
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    var params = { bpin_proyecto: bpinProyecto, id_usuario: id_usuario, id_grupo: id_grupo };
    ajaxPost('addGrupoAuditor_ajax', params, null, function (r) {
        if (r.indexOf("<||>") != -1) {
            var cod_error = r.split("<||>")[0];
            var mensaje_error = r.split("<||>")[1];
            if (cod_error == '0') {
                //accion exitosa
                alert("Se ha unido al grupo auditor");
            } else {
                alert(mensRes);
            }
        }
       
    }, function (e) {
        alert(e.responseText);
    });

}

function obtGestionGAC(id_grupo){
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    var params = { bpin_proyecto: bpinProyecto, id_usuario: id_usuario, id_grupo: id_grupo };
    ajaxPost('detalleGestionProyecto_ajax', params, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);

    }, function (e) {
        alert(e.responseText);
    });

}

