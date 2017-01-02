function obtInfoProyecto(id_proyecto) {
    ajaxPost('../../Views/Proyectos/infoProyecto', { id_proyecto: id_proyecto }, 'dvPrincipal', function (r) {
        $(".detalleEncabezadoProy").show();
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

function verDetalleProyecto(id_proyecto,id_usuario) {
    ajaxPost('../../Views/Proyectos/detalleProyecto_ajax', { id_proyecto: id_proyecto,id_usuario:id_usuario }, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
        $(".detalleEncabezadoProy").show();
        var $input = $("#btnNewImagenTecnica");
        $input.fileinput({
            uploadUrl: "../../Views/Proyectos/agregarInfoTecnica_ajax", // server upload action
            showUpload: false,
            maxFileCount: 1,
            showCaption: false,
            allowedFileExtensions: ['jpg', 'png'],
            maxFileCount: 1,
            browseLabel: "Imagen",
            showDrag: false,
            dropZoneEnabled: false,
        }).on('filebatchpreupload', function(event, data) {
            var formulario_ok = "1";
            var titulo = $("#txtNewTituloTecnica").val();
            var descripcion = $("#txtNewDescTecnica").val();
            if (titulo == "") {
                formulario_ok = "0";
                $("#error_txtNewTituloTecnica").show();
            }
            if (descripcion == "") {
                $("#error_txtNewDescTecnica").show();
            }
            if (formulario_ok == "0") {
                    return {
                        message: "Imagen no guardada", // upload error message
                        data:{} // any other data to send that can be referred in `filecustomerror`
                            };


            } else {
                $("#error_txtNewTituloTecnica").hide();
                $("#error_txtNewDescTecnica").hide();
            }

        }).on('filebatchuploadsuccess', function (event, data, id, index) {
            alert(data);
            //var fname = data.files[index].name,
            //    out = '<li>' + 'Uploaded file # ' + (index + 1) + ' - ' +
            //        fname + ' successfully.' + '</li>';
            //$('#kv-success-1 ul').append(out);
            //$('#kv-success-1').fadeIn('slow');
        });
        $("#btnGuardarNewInfoTecnica").click(function () {
            $input.fileinput("upload");
        });

    }, function (e) {
        bootbox.alert(e.responseText);
    });

}

function verInfoTecnica(id_info) {
    ajaxPost('../../Views/Proyectos/detalleInfoTecnica_ajax', { id_info: id_info }, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
        $('#divDetalleFormCalidad').slideUp(); $('#divItemsCalidad').slideDown();
    }, function (e) {
        bootbox.alert(e.responseText);
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

function volverListadoGrupos() {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
        $(".detalleEncabezadoProy").show();
            $("#divListadoAudit").slideDown(function () {
                $("#divDetalleGestion").slideUp(function () {
                    $("#divDetallePlanTrabajo").slideUp();
                });
            });
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
        $("#divDetalleGestion").show();
        $("#divListadoAudit").slideUp(function () {
            $("#divDetalleGestion").slideDown(function () {
                $("#divDetallePlanTrabajo").slideUp();
            });
        });

    }, function (e) {
        bootbox.alert(e.responseText);
    });

}

function obtPlanTrabajoGAC(id_grupo) {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    $(".detalleEncabezadoProy").show();
    $('#divPlanTrabajoGrupo').html('');
    $("#divDetallePlanTrabajo").show();
    $("#divListadoAudit").slideUp(function () {
        $("#divDetallePlanTrabajo").slideDown(function () {
            $("#divDetalleGestion").slideUp();
        });
    });
   

}

function obtGACProyecto(id_proyecto,id_usuario) {
    var params = { id_proyecto: id_proyecto,id_usuario: id_usuario };
    ajaxPost('../Views/Proyectos/detalleGACProyecto_ajax', params, 'divListadoAudit', function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

function generarActaReuPrevias(cod_bpin, id_usuario) {
    ajaxPost('../Views/Audiencias/ActaReunionesPrevias', { cod_bpin: cod_bpin, id_usuario: id_usuario }, 'divCodPlantilla', function (r) {
        cargaPlantillas();
    }, function (e) {
        bootbox.alert(e.responseText);
    });
  
}
function obtInformeObsReuPrevias(cod_bpin, id_usuario) {
    ajaxPost('../Views/Audiencias/InformePrevioInicio', { cod_bpin: cod_bpin, id_usuario: id_usuario }, 'divCodPlantilla', function (r) {
        cargaPlantillas();
    }, function (e) {
        bootbox.alert(e.responseText);
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

function valorarproyecto(cod_bpin, id_usuario) {
    ajaxPost('../Views/Audiencias/ValoracionProyecto', { cod_bpin: cod_bpin, id_usuario: id_usuario }, 'divCodPlantilla', function (r) {
        cargaPlantillas();
    }, function (e) {
        bootbox.alert(e.responseText);
    });

}

function addDescripcionTecnicaProy(params) {
    ajaxPost('../Views/Proyectos/addDescripcionTecnica_ajax', params, null, function (r) {
        if (r.indexOf("<||>") != -1) {
            var cod_error = r.split("<||>")[0];
            var mensaje_error = r.split("<||>")[1];
            if (cod_error == '0') {
                //accion exitosa
                bootbox.alert("Información agregada con éxito", function () {
                    $("#divInformacionCalidad").hide();
                    //recargar informacon
                });
            } else {
                bootbox.alert(mensRes);
            }
        }

    }, function (e) {
        bootbox.alert(e.responseText);
    });

}