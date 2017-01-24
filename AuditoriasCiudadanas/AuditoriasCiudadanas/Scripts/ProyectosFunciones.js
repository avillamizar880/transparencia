function obtInfoProyecto(id_proyecto) {
    ajaxPost('../../Views/Proyectos/infoProyecto', { id_proyecto: id_proyecto }, 'dvPrincipal', function (r) {
        $(".detalleEncabezadoProy").show();
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

function selectInfoGrupos(id_proyecto) {
    ajaxPost('../../Views/Proyectos/infoProyecto', { id_proyecto: id_proyecto }, 'dvPrincipal', function (r) {
        $(".detalleEncabezadoProy").show("slow",function () {
            $('.nav-tabs a[href="#' + "divGrupos" + '"]').tab('show');
        });
        
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

function htmlEscape(str) {
    return str
        .replace(/&/g, '&amp;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#39;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;');
}

function htmlUnescape(str) {
    return str
        .replace(/&quot;/g, '"')
        .replace(/&#39;/g, "'")
        .replace(/&lt;/g, '<')
        .replace(/&gt;/g, '>')
        .replace(/&amp;/g, '&');
}

function verDetalleProyecto(id_proyecto,id_usuario) {
    ajaxPost('../../Views/Proyectos/detalleProyecto_ajax', { id_proyecto: id_proyecto, id_usuario: id_usuario }, null, function (r) {
        var datosEvalProyecto = htmlUnescape(r);
        eval((datosEvalProyecto));
        $(".detalleEncabezadoProy").show();
        var $input = $("#btnNewImagenTecnica");
        $input.fileinput({
            uploadUrl: "../../Views/Proyectos/agregarInfoTecnica_ajax", // server upload action
            showUpload: false,
            maxFileCount: 1,
            showCaption: false,
            allowedFileExtensions: ['jpg', 'png', 'pdf'],
            browseLabel: "Adjunto (img/archivo)",
            showDrag: false,
            dropZoneEnabled: false,
            showPreview: true,
            elErrorContainer: '#kv-error-1'
        }).on('filebatchpreupload', function (event, data) {
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
            $('#kv-success-1').html('<h4>Upload Status</h4><ul></ul>').hide();
        }).on('filepreupload', function (event, data, previewId, index, jqXHR) {
            var titulo = $("#txtNewTituloTecnica").val();
            var descripcion = $("#txtNewDescTecnica").val();
            var id_proyecto=$("#hfidproyecto").val();
            var id_usuario=$("#hdIdUsuario").val();
           
            data.form.append("titulo", titulo);
            data.form.append("descripcion", descripcion);
            data.form.append("cod_bpin", id_proyecto);
            data.form.append("id_usuario",id_usuario );
        }).on('fileuploaded', function (event, data, id, index) {
            //alert(eval(data));
            //imagen cargada
            //for (var i = 0; i < jsonData.Head.length; i++) {
            //    if (jsonData.Head[i].cod_error == "0") {
            //        alert("Registro Guardado exitosamente");
            //    } else {
            //        alert('@Error al guardar: ' + jsonData.Head[i].mensaje_error);
            //    }
            //}
            //var fname = data.files[index].name,
            //        out = '<li>' + 'Uploaded file # ' + (index + 1) + ' - ' +
            //            fname + ' successfully.' + '</li>';
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

function UnirseGAC(id_grupo) {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    //mensaje confirmacion
    bootbox.confirm({
        title: "UNIRSE A GAC",
        message: "¿Está seguro que desea unirse al GAC?",
        buttons: {
            confirm: {
                label: 'Unirse'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                if (id_usuario != "") {
                    //usuario registrado en session
                    ajaxPost('../Views/Usuarios/addGrupoAuditor_ajax', { bpin_proyecto: bpinProyecto, id_usuario: id_usuario, id_grupo: id_grupo }, null, function (r) {
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
                                bootbox.alert(mensaje_error);
                            }
                        }

                    }, function (e) {
                        bootbox.alert(e.responseText);
                    });
                } else {
                    //redireccionar form registro usuarios
                    bootbox.alert("Aún no ha validado sus credenciales de ingreso al sistema, acción válida para usuarios registrados");

                }
            }
        }
    });
    
}

function seguirProyecto() {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    //mensaje confirmacion
    bootbox.confirm({
        title: "SEGUIR PROYECTO",
        message: "La opción “SEGUIR” le permite recibir en su correo electrónico información sobre los avances del proyecto o de la gestión del Grupo Auditor Ciudadano que lo vigila. </br>¿Está seguro de que desea seguir este proyecto?",
        buttons: {
            confirm: {
                label: 'Seguir'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                if (id_usuario != "") {
                    //usuario registrado en session
                    ajaxPost('../Views/Usuarios/addSeguirProyecto_ajax', { bpin_proyecto: bpinProyecto, id_usuario: id_usuario }, null, function (r) {
                        if (r.indexOf("<||>") != -1) {
                            var cod_error = r.split("<||>")[0];
                            var mensaje_error = r.split("<||>")[1];
                            if (cod_error == '0') {
                                //accion exitosa
                                bootbox.alert("Ahora es un seguidor del proyecto " + bpinProyecto);
                            } else {
                                bootbox.alert(mensRes);
                            }
                        }

                    }, function (e) {
                        bootbox.alert(e.responseText);
                    });
                } else {
                    //redireccionar form registro usuarios
                    bootbox.alert({
                        message: "Para seguir el proyecto, debes estar registrado en el sistema!",
                        buttons: {
                            ok: {
                                label: 'Registrarse'
                            }
                        },
                        callback: function () {
                            goObtMenu('/Views/Usuarios/registroCiudadano');
                        }
                    });

                }
            }
        }
    });

}

function RetirarseGAC(id_grupo) {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    //mensaje confirmacion
    bootbox.confirm({
        title: "RETIRARSE DE GAC",
        message: "¿Está seguro que desea retirarse del GAC?",
        buttons: {
            confirm: {
                label: 'Retirarse'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                if (id_usuario != "") {
                    //usuario registrado en session
                    ajaxPost('../Views/Usuarios/retirarseGrupoAuditor_ajax', { bpin_proyecto: bpinProyecto, id_usuario: id_usuario, id_grupo: id_grupo }, null, function (r) {
                        if (r.indexOf("<||>") != -1) {
                            var cod_error = r.split("<||>")[0];
                            var mensaje_error = r.split("<||>")[1];
                            if (cod_error == '0') {
                                //accion exitosa
                                bootbox.alert("Usted ya no pertenece al GAC", function () {
                                    //recargar grupos
                                    obtGACProyecto(bpinProyecto, id_usuario);
                                });
                            } else {
                                bootbox.alert(mensaje_error);
                            }
                        }

                    }, function (e) {
                        bootbox.alert(e.responseText);
                    });
                } else {
                    //redireccionar form registro usuarios
                    bootbox.alert({
                        message: "Para retirarse de un GAC, debes estar registrado en el sistema!",
                        buttons: {
                            ok: {
                                label: 'Registrarse'
                            }
                        },
                        callback: function () {
                            goObtMenu('/Views/Usuarios/registroCiudadano');
                        }
                    });

                }
            }
        }
    });
  
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

    var params = { ParametroInicio: bpinProyecto};
    ajaxPost('../Views/VerificacionAnalisis/PlanTrabajo', params, 'divPlanTrabajoGrupo', function (r) {
        $("#divDetallePlanTrabajo").show();
            $("#divListadoAudit").slideUp(function () {
                $("#divDetallePlanTrabajo").slideDown(function () {
                    $("#divDetalleGestion").slideUp();
                });
            });
    }, function (e) {
        bootbox.alert(e.responseText);
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

function obtGACProyectoByPlantilla(id_proyecto, id_usuario) {
    var params = { id_proyecto: id_proyecto, id_usuario: id_usuario };
    ajaxPost('../Views/Proyectos/detalleGACProyecto_ajax', params, 'divListadoAudit', function (r) {
        cargaPlantillas();
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

function valorarproyecto(cod_bpin, id_usuario, estado) {
    ajaxPost('../Views/Audiencias/ValoracionProyecto', { cod_bpin: cod_bpin, id_usuario: id_usuario, estado:estado }, 'divCodPlantilla', function (r) {
        cargaPlantillas();
    }, function (e) {
        bootbox.alert(e.responseText);
    });

}

function informeproceso(cod_bpin, id_usuario, idtipoaud, estado, idaud, id_GAC) {
    if (idtipoaud == 1) {
        ajaxPost('../Views/Audiencias/InformeProceso  ', { cod_bpin: cod_bpin, id_usuario: id_usuario, idtipoaud: idtipoaud, idaud: idaud, id_GAC: id_GAC, estado: estado }, 'divCodPlantilla', function (r) {
            cargaPlantillas();
        }, function (e) {
            bootbox.alert(e.responseText);
        });
    } else if (idtipoaud == 2) {
        ajaxPost('../Views/Audiencias/InformeProcesCierre  ', { cod_bpin: cod_bpin, id_usuario: id_usuario, idtipoaud: idtipoaud, idaud: idaud, id_GAC: id_GAC, estado: estado }, 'divCodPlantilla', function (r) {
            cargaPlantillas();
        }, function (e) {
            bootbox.alert(e.responseText);
        });
    }
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

function verDetalleContrato(NumCtto) {
    $(".detalleEncabezadoProy").show();
    var params = { NumCtto: NumCtto};
    ajaxPost('../Views/Proyectos/detalleContrato_ajax', params, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
        $("#divDetalleContrato").show();
        //$("#divDetalleGestion").show();
        $("#divContrato").slideUp(function () {
            $("#divDetalleContrato").slideDown(function () {
            });
        });

    }, function (e) {
        bootbox.alert(e.responseText);
    });

}

function volverListadoContrato() {
    $(".detalleEncabezadoProy").show();
    $("#divContrato").slideDown(function () {
        $("#divDetalleContrato").slideUp(function () {
        });
    });
}

function generarReporteHallazgos(idGac) {
    $("#divReporteHallazgos").show();
    var params = { ParametroInicio: idGac };
    //$('#divDetalleGestion').html('');
    ajaxPost('../Views/VerificacionAnalisis/InformeHallazgo', params, 'divCodPlantilla', function (r) {
        //ajaxPost('../Views/Audiencias/InformeProceso  ', { cod_bpin: cod_bpin, id_usuario: id_usuario, idtipoaud: idtipoaud, idaud: idaud, id_GAC: id_GAC, estado: estado }, 'divCodPlantilla', function (r) {
            cargaPlantillas();
        }, function (e) {
            bootbox.alert(e.responseText);
        });
    //    $("#divInformeHallazgos").show();
    //    $("#divDetalleGestion").slideUp(function () {
    //        //$("#divDetalleGestion").slideDown(function () {
    //        //    $("#divInformeHallazgos").slideUp();
    //        //});
    //    });
    //}, function (e) {
    //    bootbox.alert(e.responseText);
    //});
}
function volverDetalleGestion() {
    //$(".detalleEncabezadoProy").show();
    $("#divDetalleGestion").slideDown(function () {
        //$("#divDetalleContrato").slideUp(function () {
        //});
    });
}

function generarAyuda() {
    ajaxPost('../Views/Proyectos/preg_frecuentes', null, 'divCodPlantilla', function (r) {
        cargaPlantillas();
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

function prueba() {
    alert("@aquiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
}