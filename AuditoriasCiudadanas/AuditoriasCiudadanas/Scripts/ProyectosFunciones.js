/// <reference path="E:\AUD_CIUDADANAS\transparencia7\AuditoriasCiudadanas\AuditoriasCiudadanas\Views/Audiencias/InformePrevioInicio_pdf.aspx" />
/// <reference path="E:\AUD_CIUDADANAS\transparencia7\AuditoriasCiudadanas\AuditoriasCiudadanas\Views/Audiencias/InformePrevioInicio_pdf.aspx" />
function obtInfoProyecto(id_proyecto) {
    ajaxPost('../../Views/Proyectos/infoProyecto', { id_proyecto: id_proyecto }, 'dvPrincipal', function (r) {
        $(".detalleEncabezadoProy").show();
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

function selectInfoGrupos(id_proyecto) {
    ajaxPost('../../Views/Proyectos/infoProyecto', { id_proyecto: id_proyecto , accion: 'participar' }, 'dvPrincipal', function (r) {
        $(".detalleEncabezadoProy").show("slow", function () {
        });
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}


function verDetalleProyecto(id_proyecto, id_usuario) {
    ajaxPost('../../Views/Proyectos/detalleProyecto_ajax', { id_proyecto: id_proyecto, id_usuario: id_usuario }, null, function (r) {
        var datosEvalProyecto = htmlUnescape(r);
        eval((datosEvalProyecto));

        //habilitar change para cronograma de actividades
        $('#ddlCronoIni,#ddlCronoFin').bind('change onchange', function () {
            pintarCronogramaProyecto($(this));
        });

        var accion = $("#hdAccion").val();
        var perfil = $("#hdperfil").val();
        var rol = $("#hdrol").val();
        $(".detalleEncabezadoProy").show();
        $('[data-toggle="tooltip"]').tooltip();
        if (accion == "participar") {
            $('.nav-tabs a[href="#' + "divGrupos" + '"]').tab('show');
        } else {
             //consultar menú seleccionado
            var enlace = $('.nav-tabs .active').attr("id");
            if ((enlace == "itemGrupos") && (perfil == "2") && (rol != '3')) {
                //carga grupos auditores
                $("#divInformativo").hide();
                $("#divCrearGAC").show();
            } else {
                $("#divTextoGrupos").hide();
                $("#divInformativo").show();
                $("#divCrearGAC").hide();
            }
        }
        if (perfil !="2")
        {
            $("#divTextoGrupos").hide();
            $("#divCrearGAC").hide();
        }

    }, function (e) {
        bootbox.alert(e.responseText);
    });

}

function pintarCronogramaProyecto(obj) {
    var obj_id = obj.attr("id");
    var bpinProyecto = $("#hfidproyecto").val();
    var mes_ini = $("#ddlCronoIni option:selected").attr("mes");
    var anyo_ini = $("#ddlCronoIni option:selected").attr("anyo");
    var mes_fin = $("#ddlCronoFin option:selected").attr("mes");
    var anyo_fin = $("#ddlCronoIni option:selected").attr("anyo");
    $("#divCronogramaDet").html("");
    $("#divCronoEjecDet").html("");
    ajaxPost('../../Views/Proyectos/detalleCronoProyecto_ajax', { mes_ini: mes_ini, mes_fin: mes_fin, anyo_ini: anyo_ini, anyo_fin: anyo_fin, bpinProyecto: bpinProyecto }, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);

    }, function (e) {
        bootbox.alert(e.responseText);
    });

}

function verInfoTecnica(id_info) {
    ajaxPost('../../Views/Proyectos/detalleInfoTecnica_ajax', { id_info: id_info, opcion:"view" }, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
        $('#divItemsCalidad').slideUp(function () {
            $('#divDetalleFormCalidad').slideDown();
        }); 
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
                if (id_usuario != "" && id_usuario!=undefined) {
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

function seguirProyecto(bpinProyecto) {
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
                if (id_usuario != "" && id_usuario!=undefined) {
                    //usuario registrado en session
                    ajaxPost('../Views/Usuarios/addSeguirProyecto_ajax', { bpin_proyecto: bpinProyecto, id_usuario: id_usuario }, null, function (r) {
                        if (r.indexOf("<||>") != -1) {
                            var cod_error = r.split("<||>")[0];
                            var mensaje_error = r.split("<||>")[1];
                            if (cod_error == '0') {
                                //accion exitosa
                                bootbox.alert("Ahora es un seguidor del proyecto con BPIN: " + bpinProyecto);
                            } else {
                                bootbox.alert(mensaje_error);
                            }
                        }

                    }, function (e) {
                        bootbox.alert(e.responseText);
                    });
                } else {
                    //redireccionar form registro usuarios
                    bootbox.confirm({
                        title: "SEGUIR PROYECTO",
                        message: "Para seguir el proyecto, debe estar registrado en el sistema!",
                        buttons: {
                            confirm: {
                                label: 'Registrarse'
                            },
                            cancel: {
                                label: 'Cancelar'
                            }
                        },
                        callback: function (result) {
                            if (result == true) {
                                goObtMenu('/Views/Usuarios/registroCiudadano');
                            }
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
                if (id_usuario != "" && id_usuario!=undefined) {
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
                    bootbox.confirm({
                        title: "RETIRARSE DE GAC",
                        message: "Para retirarse de un GAC, debe estar registrado en el sistema!",
                        buttons: {
                            confirm: {
                                label: 'Registrarse'
                            },
                            cancel: {
                                label: 'Cancelar'
                            }
                        },
                        callback: function (result) {
                            if (result == true) {
                                goObtMenu('/Views/Usuarios/registroCiudadano');
                            }
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

function volverPlanTrabajo() {
    $(".detalleEncabezadoProy").show();
    $("#divDetalleTarea").hide();
    $("#divDetallePlanTrabajo").slideDown(function () {
        $("#divDetalleGestion").slideUp(function () {
            $("#divDetalleTareaPlanTrabajoGrupo").slideUp();
        });
    });
}

function volver_listado_gestion() {
    $("#divCuerpoProy").slideDown(function () {
        $("#divPlantillasProy").slideUp(function () {
            $(".detalleEncabezadoProy").show();
            $("#divPlantillasProy").hide();
                if ($("#hdIdGrupo").length > 0) {
                        var id_grupo = $("#hdIdGrupo").val();
                        if (id_grupo != "" && id_grupo != undefined) {
                            obtGestionGAC(id_grupo);
                         }
                    }

        });
    });
   
    

}


function obtGestionGAC(id_grupo){
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    //pedir usuario
    if (id_usuario == "" || id_usuario==undefined) {
        bootbox.alert({
            message: "Para ver la gestión de un GAC, debe estar registrado en el sistema!",
            buttons: {
                ok: {
                    label: 'Aceptar',   
                }
            },
            callback: function () {
            }
            
        });
        } else {
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
}

function obtPlanTrabajoGAC(id_grupo) {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    //pedir usuario
    if (id_usuario == "" || id_usuario==undefined) {
        bootbox.alert({
            message: "Para ver el plan de trabajo de un GAC, debe estar registrado en el sistema!",
            buttons: {
                ok: {
                    label: 'Aceptar',   
                }
            },
            callback: function () {
            }
            
        });
        } else {
        $(".detalleEncabezadoProy").show();
        $('#divPlanTrabajoGrupo').html('');

        var params = { ParametroInicio: bpinProyecto + "*" + id_grupo };
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
}

function obtGACProyecto(id_proyecto, id_usuario) {
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
function RegInformeObsReuPrevias(cod_bpin, id_usuario, id_grupo) {
    ajaxPost('../Views/Audiencias/InformePrevioInicio', { cod_bpin: cod_bpin, id_usuario: id_usuario , id_grupo:id_grupo }, 'divCodPlantilla', function (r) {
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
    if (idtipoaud == "1") {
        ajaxPost('../Views/Audiencias/InformeProceso  ', { cod_bpin: cod_bpin, id_usuario: id_usuario, idtipoaud: idtipoaud, idaud: idaud, id_GAC: id_GAC, estado: estado }, 'divCodPlantilla', function (r) {
            cargaPlantillas();
        }, function (e) {
            bootbox.alert(e.responseText);
        });
    } else if (idtipoaud == "2") {
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
                    //recargar informacion
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
    var params = { ParametroInicio: idGac };
    ajaxPost('../Views/VerificacionAnalisis/InformeHallazgo', params, 'divCodPlantilla', function (r) {
        //$("#divReporteHallazgos").show();
             cargaPlantillas();
        }, function (e) {
              bootbox.alert(e.responseText);
        });
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

function configEvaluacionPosterior(bpin_proyecto,id_usuario) {
    ajaxPost('../Views/Valoracion/configuraEncuestas?opc=1', null, 'divCodPlantilla', function (r) {
        cargaPlantillas();
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

function responderEvaluacionPosterior(bpin_proyecto, id_usuario) {
    ajaxPost('../Views/Valoracion/envioEncuesta', null, 'divCodPlantilla', function (r) {
        cargaPlantillas();
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

function ver_infoTecnicaEdit(id_info) {
    ajaxPost('../../Views/Proyectos/detalleInfoTecnica_ajax', { id_info: id_info , opcion: "edit" }, null, function (r) {
    var jsonObj = r;
    var jsonData = eval("(" + jsonObj + ")");
    var url_foto = "";
    var titulo = "";
    var descripcion = "";
            for (var i = 0; i < jsonData.Head.length; i++) {
                //var idCuestionario = jsonData.Head[i].idCuestionario;
                titulo = jsonData.Head[i].Titulo; 
                descripcion = jsonData.Head[i].Descripcion;
                url_foto = jsonData.Head[i].UrlFoto;
            }
            asignar_valores_info(id_info,url_foto, titulo, descripcion,"edit");

    }, function (e) {
        bootbox.alert(e.responseText);
    });

}

function asignar_valores_info(id_info, url_foto, titulo, descripcion, opcion) {
    $("#divAgregarAdjunto").children().remove();
    $("#txtNewTituloTecnica").val(titulo);
    $("#txtNewDescTecnica").val(descripcion);
    var ruta_imagen = "../../" + url_foto;
    //var ruta_imagen = url_foto;
    var obj_imagen = '<div class="btn-group btn-group-justified" role="group" aria-label="...">' +
    '<div role="group"><input id="btnNewImagenTecnica" class="file-loading" type="file"></span>';
    $("#divAgregarAdjunto").append(obj_imagen);
    if (opcion == "new") {
        $("#btnNewImagenTecnica").fileinput({
            uploadUrl: "../../Views/Proyectos/agregarInfoTecnica_ajax", // server upload action
            showUpload: false,
            maxFileCount: 1,
            showCaption: false,
            allowedFileExtensions: ['jpg', 'png', 'pdf'],
            browseLabel: "Adjunto (img/archivo)",
            showDrag: false,
            dropZoneEnabled: false,
            showPreview: true
        }).on('filebatchpreupload', function (event, data) {
            var valida = validar_datos_info();
            if (valida == false) {
                return {
                    message: "Imagen no guardada", // upload error message
                    data: {} // any other data to send that can be referred in `filecustomerror`
                };
            }
        }).on('filepreupload', function (event, data, previewId, index, jqXHR) {
            var titulo = $("#txtNewTituloTecnica").val();
            var descripcion = $("#txtNewDescTecnica").val();
            var id_proyecto = $("#hfidproyecto").val();
            var id_usuario = $("#hdIdUsuario").val();

            data.form.append("titulo", titulo);
            data.form.append("descripcion", descripcion);
            data.form.append("cod_bpin", id_proyecto);
            data.form.append("id_usuario", id_usuario);
            data.form.append("opcion", "new");
            data.form.append("id_info", id_info);
        }).on('fileuploaded', function (event, data, id, index) {
            bootbox.alert("Información cargada con exito", function () {
                  cargarInfoTecnica();
            });
           
        });

        $("#btnGuardarNewInfoTecnica").click(function () {
            $("#btnNewImagenTecnica").fileinput("upload");
        });
       

    } else if (opcion == "edit") {

        $("#btnNewImagenTecnica").fileinput({
            uploadUrl: "../../Views/Proyectos/agregarInfoTecnica_ajax", // server upload action
            showUpload: false,
            maxFileCount: 1,
            showCaption: false,
            allowedFileExtensions: ['jpg', 'png', 'pdf'],
            browseLabel: "Adjunto (img/archivo)",
            showDrag: false,
            dropZoneEnabled: false,
            showPreview: true,
            initialPreview: [ruta_imagen],
            initialPreviewAsData: true, // identify if you are sending preview data only and not the raw markup
            initialPreviewFileType: 'image' // image is the default and can be overridden in config below
        }).on('filebatchpreupload', function (event, data) {
            var valida = validar_datos_info();
            if (valida == false) {
                return {
                    message: "Imagen no guardada", // upload error message
                    data: {} // any other data to send that can be referred in `filecustomerror`
                };
            }
        }).on('filepreupload', function (event, data, previewId, index, jqXHR) {
            var titulo = $("#txtNewTituloTecnica").val();
            var descripcion = $("#txtNewDescTecnica").val();
            var id_proyecto = $("#hfidproyecto").val();
            var id_usuario = $("#hdIdUsuario").val();

            data.form.append("titulo", titulo);
            data.form.append("descripcion", descripcion);
            data.form.append("cod_bpin", id_proyecto);
            data.form.append("id_usuario", id_usuario);
            data.form.append("opcion", "edit");
            data.form.append("id_info", id_info);
        }).on('fileuploaded', function (event, data, id, index) {
            bootbox.alert("Información cargada con exito", function () {
                cargarInfoTecnica();
            });
        });

        $("#btnEditarNewInfoTecnica").click(function () {
            $("#btnNewImagenTecnica").fileinput("upload");
        });
    }
}

function validar_datos_info() {
    var formularioOk = true;
    $("#error_txtNewTituloTecnica").hide();
    $("#error_txtNewDescTecnica").hide();
    var titulo = $("#txtNewTituloTecnica").val();
    var descripcion = $("#txtNewDescTecnica").val();
    if (titulo == "") {
        formulario_ok = false;
        $("#error_txtNewTituloTecnica").show();
    }
    if (descripcion == "") {
        formularioOk = false;
        $("#error_txtNewDescTecnica").show();
    }
    
    return formularioOk;
}



function cargarInfoTecnica() {
    var id_proyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    ajaxPost('../../Views/Proyectos/detalleInfoTecnica_ajax', { id_proyecto:id_proyecto,id_usuario:id_usuario, opcion: "all" }, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
         $('#divDetalleFormCalidad').slideUp(function () {
             $('#divItemsCalidad').slideDown(function () {
                 $("#divInfoTecnicaDet").show();
                 $('#collapseNewInfo').collapse('toggle');
            });
        });

        
    }, function (e) {
        bootbox.alert(e.responseText);
    });

}

function InsRegistroCompromisos(id_audiencia) {
    ajaxPost('../Views/Audiencias/RegistrarCompromisos', { id_audiencia:id_audiencia }, 'divCodPlantilla', function (r) {
        cargaPlantillas();
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

function VerInformeObsReuPrevias(cod_bpin) {
    //obt informe diligenciado
    var params = { cod_bpin: $("#hfidproyecto").val() };
    genPdfPlantilla("../Views/Audiencias/InformePrevioInicio_pdf", "divAdicionalPdf", params);


}

function genPdfPlantilla(url_plantilla, divPlantilla, params) {
    if ($("#ifrPDFPlantilla").length > 0) {
        $("#ifrPDFPlantilla").remove();
    }

    if ($("#frmPlantillaPDF").length > 0) {
        $("#frmPlantillaPDF").remove();
    }
 
    if ($('#ifrPDFPlantilla').length == 0) {
        if (divPlantilla == "" || divPlantilla == undefined) {
            $("body").append('<iframe id="ifrPDFPlantilla" name="ifrPDFPlantilla" width="0" height="0" style="width:0px;height:0px;float:right;"></iframe><form id="frmPlantillaPDF" name="frmPlantillaPDF" style="display:none;float:right;" target="ifrPDFPlantilla" method="POST" action="' + url_plantilla + '"></form>');
        } else {
            $("#" + divPlantilla).append('<iframe id="ifrPDFPlantilla" name="ifrPDFPlantilla" width="0" height="0" style="width:0px;height:0px;float:right;"></iframe><form id="frmPlantillaPDF" name="frmPlantillaPDF" style="display:none;float:right;" target="ifrPDFPlantilla" method="POST" action="' + url_plantilla + '"></form>');
        }
    }
    $('#frmPlantillaPDF').children().remove();
    $('#ifrPDFPlantilla').html('');
    $('#frmPlantillaPDF').html('');

    for (key in params) {
        var valor = params[key];
        if (valor == undefined) {
            valor = "";
        }
        var hdn = $('<input type="hidden"/>');
        hdn.attr('name', key);
        hdn.attr('id', key);
        hdn.val(valor);
        $('#frmPlantillaPDF').append(hdn);
    }
    $('#frmPlantillaPDF').submit();
}

function VerActaReuPrevias(cod_bpin) {
    //obt informe diligenciado
    var params = { cod_bpin: cod_bpin };
    genPdfPlantilla("../Views/Audiencias/ActaReunionesPrevias_pdf", "divAdicionalPdf", params);

}

function verRegistroCompromisos(id_audiencia) {
    var params = { id_audiencia: id_audiencia };
    genPdfPlantilla("../Views/Audiencias/RegistrarCompromisos_pdf", "divAdicionalPdf", params);
}


function VerValoracionProyecto(cod_bpin) {
    //obt informe diligenciado
    var params = { cod_bpin: cod_bpin };
    genPdfPlantilla("../Views/Audiencias/ValoracionProyecto_pdf", "divAdicionalPdf", params);

}

function obtEvaluacionExperiencia(idAudiencia) {
    ajaxPost('../Views/Audiencias/EvaluarExperiencia', { ParametroInicio: idAudiencia }, 'divCodPlantilla', function (r) {
        cargaPlantillas();
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

function obtAutoEvaluacion(codigoBpin) {
    ajaxPost('../Views/GestionGAC/AutoevaluacionAC', { ParametroInicio: codigoBpin }, 'divCodPlantilla', function (r) {
        cargaPlantillas();
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

