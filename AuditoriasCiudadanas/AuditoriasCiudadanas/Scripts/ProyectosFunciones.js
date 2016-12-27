function obtInfoProyecto(id_proyecto) {
    ajaxPost('../../Views/Proyectos/infoProyecto', { id_proyecto: id_proyecto }, 'dvPrincipal', function (r) {
    }, function (e) {
        alert(e.responseText);
    });
}

function verDetalleProyecto(id_proyecto,id_usuario) {
    ajaxPost('../../Views/Proyectos/detalleProyecto_ajax', { id_proyecto: id_proyecto,id_usuario:id_usuario }, null, function (r) {
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
    if (id_usuario != "") {
        var params = { bpin_proyecto: bpinProyecto, id_usuario: id_usuario, id_grupo: id_grupo };
            ajaxPost('../Views/Usuarios/addGrupoAuditor_ajax', params, null, function (r) {
                if (r.indexOf("<||>") != -1) {
                    var cod_error = r.split("<||>")[0];
                    var mensaje_error = r.split("<||>")[1];
                    if (cod_error == '0') {
                        //accion exitosa
                        bootbox.alert("Se ha unido al Grupo exitosamente", function () {
                            //recargar grupos
                            obtGACProyecto(bpinProyecto);
                        });
                    } else {
                        bootbox.alert(mensRes);
                    }
                }
       
            }, function (e) {
                bootbox.alert(e.responseText);
            });

    } else {
        bootbox.alert("Aún no ha validado sus credenciales de ingreso al sistema, acción válida para usuarios registrados");

    }

    

}

function obtGestionGAC(id_grupo){
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    $('#divGestion').html('');
    var params = { bpin_proyecto: bpinProyecto, id_usuario: id_usuario, id_grupo: id_grupo };
    ajaxPost('../Views/Proyectos/detalleGestionProyecto_ajax', params, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
        $('#acordionGestion').trigger('click');
    }, function (e) {
        alert(e.responseText);
    });

}

function obtGACProyecto(id_proyecto) {
    var params = { id_proyecto: id_proyecto };
    ajaxPost('../Views/Proyectos/detalleGACProyecto_ajax', params, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
        //$('#acordionGestion').trigger('click');
    }, function (e) {
        alert(e.responseText);
    });
}
