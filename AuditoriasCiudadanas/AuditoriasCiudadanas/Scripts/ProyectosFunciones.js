function obtInfoProyecto(id_proyecto) {
    ajaxPost('../../Views/Proyectos/infoProyecto', { id_proyecto: id_proyecto }, 'dvPrincipal', function (r) {
        $(".detalleEncabezadoProy").show();
    }, function (e) {
        alert(e.responseText);
    });
}

function verDetalleProyecto(id_proyecto,id_usuario) {
    ajaxPost('../../Views/Proyectos/detalleProyecto_ajax', { id_proyecto: id_proyecto,id_usuario:id_usuario }, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
        $(".detalleEncabezadoProy").show();
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
                            obtGACProyecto(bpinProyecto, id_usuario);
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

function volverListadoGrupos(opc) {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    $(".detalleEncabezadoProy").show();
    $("#divListadoAudit").slideDown(function () {
        $("#divDetalleGestion").slideUp(function () {
            $("#divDetallePlanTrabajo").slideUp();
        });
    });
    //$('#divListadoAudit').html('');
    //obtGACProyecto(id_proyecto, id_usuario);
    //var params = { bpin_proyecto: bpinProyecto, id_usuario: id_usuario, id_grupo: id_grupo };
    //ajaxPost('../Views/Proyectos/detalleGestionProyecto_ajax', params, 'divListadoAudit', function (r) {
    //    var datosEvalProyecto = r;
    //    eval(datosEvalProyecto);
    //    //$('#acordionGestion').trigger('click');
    //    $("#divListadoAudit").slideDown(function () {
    //        $("#divDetalleGestion").slideDown();
    //        $("#divDetallePlanTrabajo").slideDown();
    //    });

    //}, function (e) {
    //    alert(e.responseText);
    //});
}

function obtGestionGAC(id_grupo){
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    $(".detalleEncabezadoProy").show();
    $('#divGestion').html('');
    var params = { bpin_proyecto: bpinProyecto, id_usuario: id_usuario, id_grupo: id_grupo };
    ajaxPost('../Views/Proyectos/detalleGestionProyecto_ajax', params, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
        //$('#acordionGestion').trigger('click');
        $("#divListadoAudit").slideUp(function () {
            $("#divDetalleGestion").slideDown(function () {
                $("#divDetallePlanTrabajo").slideUp();
            });
        });

    }, function (e) {
        alert(e.responseText);
    });

}

function obtPlanTrabajoGAC(id_grupo) {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    $(".detalleEncabezadoProy").show();
    $('#divPlanTrabajoGrupo').html('');
    $("#divListadoAudit").slideUp(function () {
        $("#divDetallePlanTrabajo").slideDown(function () {
            $("#divDetalleGestion").slideUp();
        });
    });
    //var params = { bpin_proyecto: bpinProyecto, id_usuario: id_usuario, id_grupo: id_grupo };
    //ajaxPost('../Views/Proyectos/detalleGestionProyecto_ajax', params, null, function (r) {
    //    var datosEvalProyecto = r;
    //    eval(datosEvalProyecto);
    //    //$('#acordionGestion').trigger('click');
    //    $("#divListadoAudit").slideUp();

    //}, function (e) {
    //    alert(e.responseText);
    //});

}

function obtGACProyecto(id_proyecto,id_usuario) {
    var params = { id_proyecto: id_proyecto,id_usuario: id_usuario };
    ajaxPost('../Views/Proyectos/detalleGACProyecto_ajax', params, 'divListadoAudit', function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
        //$('#acordionGestion').trigger('click');
    }, function (e) {
        alert(e.responseText);
    });
}

function generarActaReuPrevias(){
    ajaxPost('../../Views/Audiencias/ActaReunionesPrevias', null, 'dvPrincipal', function (r) {
    }, function (e) {
        alert(e.responseText);
    });
  
}
function obtInformeObsReuPrevias(cod_bpin, id_usuario) {
    ajaxPost('../Views/Audiencias/InformePrevioInicio', { cod_bpin: cod_bpin, id_usuario: id_usuario }, 'divCodPlantilla', function (r) {
        cargaPlantillas();
    }, function (e) {
        alert(e.responseText);
    });
}

function cargaPlantillas() {
    $("#divCuerpoProy").slideUp(function () {
        $("#divPlantillasProy").slideDown(function () {
            $(".detalleEncabezadoProy").hide();
            $("#divPlantillasProy").show();
        });
    });
}

function volverListadoMenuProy() {
    $("#divCuerpoProy").slideDown(function () {
        $("#divPlantillasProy").slideUp(function () {
            $(".detalleEncabezadoProy").show();
            $("#divPlantillasProy").hide();
        });
    });

}