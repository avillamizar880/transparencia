//function CargarPlanTrabajoXOpcion(opcion)
//{
//    $("#hftipoAudiencia").val(opcion);
//    CargarPlanesTrabajo();
//}
function CargarPlanesTrabajo() {
    $.ajax({
        type: "POST",
        url: '../../Views/VerificacionAnalisis/PlanTrabajo_ajax', data: { BuscarPlanesTrabajo: $("#hfcodigoBPIN").val() + '*' + $("#hfidGac").val() + '*' + $("#hfidUsuario").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParamPlanTrabajo('Cargando datos tareas...');
        },
        success: function (result) {
            var datasource = '';
            if (result != null && result != "")
            {
                for (var i = 0; i < result.Head.length; i++)
                {
                    var observacionAuditor = '';
                    if (result.Head[i].ObservacionAuditor != null) observacionAuditor = result.Head[i].ObservacionAuditor;
                    var color = result.Head[i].semaforo;
                    var estado='';
                    switch(color) {
                        case 'red':
                            estado = 'Vencido';
                            break;
                        case 'green':
                            estado = 'A tiempo';
                            break;
                        case 'orange':
                            estado = 'Por vencer';
                            break;
                        case 'gris':
                            estado = 'Bien';
                            break;
                        case 'blue':
                            estado = 'Finalizado';
                            break;
                        default:
                            estado = 'A tiempo';
                    }
                    datasource = datasource +
                             '<div class="list-group uppText">' +
                             '<div class="list-group-item">' +
                             '<div class="col-sm-2">' +
                             '<p class="list-group-item-text"><span class="glyphicon glyphicon-copy"></span>'+ result.Head[i].Nombre + '</p>' +
                             '</div>' +
                             '<div class="col-sm-2"><span class="glyphicon glyphicon-user"></span><span>'+result.Head[i].NombreUsuario + '</span></div>' +
                             '<div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>' + result.Head[i].fecha + '</span></div>' +
                             '<div class="col-sm-2">' +
                             '<div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>' + result.Head[i].fechaCierreTarea + '</span></div>' +
                             ' </div>' +
                             //'<div class="col-sm-2"><span class="glyphicon glyphicon-info-sign"></span> <span>' + '' + '</span></div>' +
                             //' </div>' +
                             '<div class="col-sm-2"><a role="button" onclick="ObtInfoTarea(\'' + result.Head[i].idTarea + '*' + result.Head[i].Nombre + '*' + result.Head[i].fecha + '*' + result.Head[i].IdUsuario + '*' + $("#hfidUsuario").val() + '\');"><span class="glyphicon glyphicon-calendar"></span> <span>Detalle</span></a></div>' +
                             '<div class="col-sm-2"><span class="badge ' + color + '">' + estado + '</span></div>' +
                             '</div>' +
                             '</div>';
                }
            }
            $("#datosPlanTrabajo").html(datasource);
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUI();
        }
    });
}

function ObtInfoTarea2(parametrosTarea) {
    bootbox.alert("Archivo cargado con éxito");
    var paramsTarea = parametrosTarea.split('*');
    var idTarea = paramsTarea[0];
    var tipoTarea = paramsTarea.length > 1 ? paramsTarea[1] : "";
    var fechaTarea = paramsTarea.length > 2 ? paramsTarea[2] : "";
    var idUsuarioResponsable = paramsTarea.length > 3 ? paramsTarea[3] : "";
    var idUsuario = paramsTarea.length > 4 ? paramsTarea[4] : "";
    ajaxPost('../../Views/VerificacionAnalisis/DetallePlanTrabajo', { DetallePlanTrabajo: idTarea + "*" + tipoTarea + '*' + fechaTarea + '*' + idUsuarioResponsable + '*' + idUsuario }, 'divDetalleTareaPlanTrabajoGrupo', function (r)
    {
        $("#tareaActaReuniones").show();
        //$("#divDetallePlanTrabajo").slideUp(function () {
        //    $("#divDetalleTarea").slideDown(function () {
        //        $("#divDetalleTareaPlanTrabajoGrupo").show();
        //    });
        //});
        //$("#divListadoAudit").slideUp(function () {
          

            
        //});
    }, function (e) {
        alert(e.responseText);
    });
}


function ObtInfoTarea(parametrosTarea) {
    var paramsTarea = parametrosTarea.split('*');
    var idTarea = paramsTarea[0];
    var tipoTarea = paramsTarea.length > 1 ? paramsTarea[1] : "";
    var fechaTarea = paramsTarea.length > 2 ? paramsTarea[2] : "";
    var idUsuarioResponsable = paramsTarea.length > 3 ? paramsTarea[3] : "";
    var idUsuario = paramsTarea.length > 4 ? paramsTarea[4] : "";
    ajaxPost('../../Views/VerificacionAnalisis/DetallePlanTrabajo', { DetallePlanTrabajo: idTarea + "*" + tipoTarea + '*' + fechaTarea + '*' + idUsuarioResponsable + '*' + idUsuario }, 'divDetalleTareaPlanTrabajoGrupo', function (r)
    {
        $("#divListadoAudit").slideUp(function () {
            $("#divDetallePlanTrabajo").slideUp(function () {
                $("#divDetalleTarea").slideDown(function () {
                    $("#divDetalleTareaPlanTrabajoGrupo").show();
                });
            });

            
        });
    }, function (e) {
        alert(e.responseText);
    });
}
function waitblockUIParamPlanTrabajo(mensaje) { $.blockUI({ message: "<h2>" + mensaje + "</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }
function EliminarTarea()
{
    if (confirm("¿Desea eliminar esta tarea?"))
    {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { EliminarTarea: $("#hfidTarea").val()}, traditional: true,
            beforeSend: function () {
                waitblockUIParamPlanTrabajo('Eliminando tareas...');
            },
            success: function (result)
            {
                if (result == '<||>')
                {
                    //volverPlanTrabajo();
                    cargaMenu('VerificacionAnalisis/PlanTrabajo', 'dvPrincipal');
                }
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
}
function FinalizarTarea()
{
    if (confirm("¿Desea finalizar esta tarea?"))
    {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { FinalizarTarea: $("#hfidTarea").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamPlanTrabajo('Finalizar tareas...');
            },
            success: function (result) {
                if (result == '<||>') {
                    //$("#myModalResultadoTarea").hidden = "hidden";
                    //$("#myModalResultadoTarea").modal('toggle');
                    //cargaMenu('VerificacionAnalisis/PlanTrabajo', 'dvPrincipal');
                    CargarDetalleTarea();
                }
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
}
//#region Lógica detalle tarea
function CargarDetalleTarea() {
    $.ajax({
        type: "POST",
        url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { BuscarDetalleTarea: $("#hfidTarea").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParamPlanTrabajo('Cargando detalle tareas...');
        },
        success: function (result)
        {
            $("#tituloTarea").html($("#hfTitulo").val());
            $("#btnAnadirDescripcion").show();
            $("#btnAnadirResultadoTarea").show();
            $("#btnEditarDescripcion").hide();
            $("#btnEditarResultadoTarea").hide();
            if (result != null && result != "")
            {
                for (var i = 0; i < result.Head.length; i++) {
                    $("#fechaTarea").html("<span class='glyphicon glyphicon-calendar'></span>Fecha:&nbsp;" + result.Head[i].Fecha);
                    $("#horaTarea").html("<span class='glyphicon glyphicon-time'></span>Hora:&nbsp;" + result.Head[i].Hora);
                    if (result.Head[i].fechaCreacion != null) {
                        $("#fechaDescripcion").html("<span class='glyphicon glyphicon-calendar'></span>Fecha:&nbsp;" + result.Head[i].fechaCreacion);
                        $("#btnAnadirDescripcion").hide();
                        $("#btnEditarDescripcion").show();
                    }
                    $("#descripcionTarea").html(result.Head[i].observaciones);
                    if (result.Head[i].fechaResultado != null) {
                        $("#fechaResultadoTarea").html("<span class='glyphicon glyphicon-calendar'></span>Fecha:&nbsp;" + result.Head[i].fechaResultado);
                        $("#btnAnadirResultadoTarea").hide();
                        $("#btnEditarResultadoTarea").show();
                    }
                    $("#resultadoTarea").html(result.Head[i].Resultado);
                    if (result.Head[i].estado == null || result.Head[i].estado == 0)
                    {
                        $("#btnFinalizar").show();
                        $("#btnEliminar").show();
                        $("#AnadirRegistroMultimedia").show();
                    }
                    else
                    {
                        $("#AnadirRegistroMultimedia").hide();
                        $("#btnFinalizar").hide();
                        $("#btnEliminar").hide();
                        $("#btnAnadirDescripcion").hide();
                        $("#btnAnadirResultadoTarea").hide();
                        $("#btnEditarDescripcion").hide();
                        $("#btnEditarResultadoTarea").hide();
                    }
                }
            }
            CargarRecursosTareas();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUI();
        }
    });
}
function CargarRecursosTareas() {
    $.ajax({
        type: "POST",
        url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { ObtenerRecursosTarea: $("#hfidTarea").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParamPlanTrabajo('Cargando detalle tareas...');
        },
        success: function (result)
        {
            var datasource = ''
            var cabecera = "<h4>Registro Multimedia <div id='AnadirRegistroMultimedia' onclick='AnadirRecursoMultimediaTarea()' class='btn btn-info fr'><a href='' data-toggle='modal' data-target='#myModal' ><span class='glyphicon glyphicon-plus'></span> Agregar Registro Multimedia</a></div></h4>";
            if (result != null && result != "")
            {
                var celdas = '';
                var contadorFila = 0;
                for (var i = 0; i < result.Head.length; i++) {
                    var esposibleFila = VerificarRegistroEsNuevaFila(i);
                    if (esposibleFila == true) {
                        if (i != 0) datasource = datasource + '<div id="row' + (contadorFila).toString() + '" class="row">' + celdas + '</div>';
                        celdas = '';
                        contadorFila++;
                    }
                    celdas = celdas +
                                '<div class="col-sm-4">' +
                                    '<div class="card">' +
                                        '<input id="imagenRecursosDetalleTarea_' + i.toString() + '" class="file-loading" multiple type="file">' +
                                        '<div id="errorImagen_" ' + i + ' class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre de la imagen no puede ser vacío.</div>' +
                                        '<div class="card-block">' +
                                            '<ul class="list-group">' +
                                            '<li class="list-group-item"><p class="card-text">' + result.Head[i].descripcion + '</p></li>' +
                                            '<li class="list-group-item"><span class="glyphicon glyphicon-user"></span>&nbsp; Reportado por: ' + result.Head[i].Nombre + '</li>' +
                                            '<li class="list-group-item"><span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: ' + result.Head[i].fechaCreacion + '</li>' +
                                            '</ul>' +
                                        '</div>' +
                                    '</div>' +
                                 '</div>';
                    if (result.Head[i].url != null && result.Head[i].url != '') {
                        $("#imagenRecursosDetalleTarea_" + i.toString()).fileinput({
                            //uploadUrl: "/file-upload-batch/2",
                            language: 'es',
                            uploadAsync: true,
                            minFileCount: 1,
                            maxFileCount: 1,
                            overwriteInitial: true,
                            showBrowse: false,
                            showUpload: false,
                            showCancel: false,
                            showClose: false,
                            showCaption: false,
                            showRemove: false,
                            showZoom: true,
                            removeFromPreviewOnError: false,
                            browseLabel: "",
                            //initialPreview: ["../../Adjuntos/Tareas/" + result.Head[i].url],
                            initialPreview: [],
                            initialPreviewAsData: true, // identify if you are sending preview data only and not the raw markup
                            previewFileIcon: '<i class="fa fa-file"></i>',
                            preferIconicPreview: true, // this will force thumbnails to display icons for following file extensions
                            previewFileIconSettings: { // configure your icon file extensions
                                'doc': '<i class="fa fa-file-word-o text-primary"></i>',
                                'xls': '<i class="fa fa-file-excel-o text-success"></i>',
                                'ppt': '<i class="fa fa-file-powerpoint-o text-danger"></i>',
                                'pdf': '<i class="fa fa-file-pdf-o text-danger"></i>',
                                'zip': '<i class="fa fa-file-archive-o text-muted"></i>',
                                'htm': '<i class="fa fa-file-code-o text-info"></i>',
                                'txt': '<i class="fa fa-file-text-o text-info"></i>',
                                'mov': '<i class="fa fa-file-movie-o text-warning"></i>',
                                'mp3': '<i class="fa fa-file-audio-o text-warning"></i>',
                                // note for these file types below no extension determination logic 
                                // has been configured (the keys itself will be used as extensions)
                                'jpg': '<i class="fa fa-file-photo-o text-danger"></i>',
                                'gif': '<i class="fa fa-file-photo-o text-warning"></i>',
                                'png': '<i class="fa fa-file-photo-o text-primary"></i>'
                            },
                            previewFileExtSettings: { // configure the logic for determining icon file extensions
                                'doc': function (ext) {
                                    return ext.match(/(doc|docx)$/i);
                                },
                                'xls': function (ext) {
                                    return ext.match(/(xls|xlsx)$/i);
                                },
                                'ppt': function (ext) {
                                    return ext.match(/(ppt|pptx)$/i);
                                },
                                'zip': function (ext) {
                                    return ext.match(/(zip|rar|tar|gzip|gz|7z)$/i);
                                },
                                'htm': function (ext) {
                                    return ext.match(/(htm|html)$/i);
                                },
                                'txt': function (ext) {
                                    return ext.match(/(txt|ini|csv|java|php|js|css)$/i);
                                },
                                'mov': function (ext) {
                                    return ext.match(/(avi|mpg|mkv|mov|mp4|3gp|webm|wmv)$/i);
                                },
                                'mp3': function (ext) {
                                    return ext.match(/(mp3|wav)$/i);
                                },
                            }
                        });
                    }
                }
                if (result.Head.length > 0) datasource = datasource + '<div id="row' + (contadorFila).toString() + '" class="row">' + celdas + '</div>';
            }
            $("#regMultimedia").html(cabecera + datasource);
            if ($("#btnFinalizar").is(":visible") == false) $("#AnadirRegistroMultimedia").show();
            else $("#AnadirRegistroMultimedia").show();
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUI();
        }
    });
}
function VerificarRegistroEsNuevaFila(indice) {
    var rta = true;
    var verificarPosibleFila = true;
    var j = 1;
    while (verificarPosibleFila == true) {
        if ((j - 1) * 3 == indice) {
            verificarPosibleFila = false;
            rta = true;
        }
        else if ((j - 1) * 3 > indice) {
            rta = false;
            verificarPosibleFila = false;
        }
        j++;
    }
    return rta;
}
//#endregion Lógica detalle tarea
//#region Lógica ventanas modales
function AnadirDescripcionTarea() {
    OcultarValidadoresDescripcionTarea();
    var f = new Date();
    var fecha = f.getFullYear() + "-" + (f.getMonth() + 1) + "-" + f.getDate(); // fechaActual.getDate() + '/' + (fechaActual.getMonth() + 1) + '/' + fechaActual.getFullYear();
    AsignarValoresDescripcionTarea(fecha, '');
    $("#myModalLabel").html("Ingresar Descripción");
    $("#myModalDescripcionTarea").modal();
}
function OcultarValidadoresDescripcionTarea() {
    $("#errorFechaDescripcionTarea").hide();
    $("#errorDescripcionTarea").hide();
    $("#errorDescripcionAsteriscos").hide();
}
function AsignarValoresDescripcionTarea(fechaTarea, descripcion) {
    $("#myModalDescripcionTarea").html(
                                                '<div class="modal-dialog" role="document">' +
                                                '<div class="modal-content">' +
                                                '<div class="modal-header">' +
                                                '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                                                '<h4 class="modal-title" id="myModalLabel">Nueva Descripción</h4>' +
                                                '</div>' +
                                                '<div class="modal-body">' +
                                                '<div class="form-group">' +
                                                '<label for="fecha_posterior_2" class="control-label">Fecha</label>' +
                                                '<div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_2" data-link-format="yyyy-mm-dd">' +
                                                '<input id="dtpFechaDescripcion" class="form-control" size="16" type="text" value="" readonly>' +
                                                '<span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>' +
                                                '<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>' +
                                                '</div>' +
                                                '<input type="hidden" id="fecha_posterior_2" value="" />' +
                                                '</div>' +
                                                '<div id="errorFechaDescripcionTarea" class="alert alert-danger alert-dismissible" hidden="hidden" >La fecha de la descripción no puede ser vacía.</div>' +
                                                '<textarea id="txtDescripcion" placeholder="Describa la tarea" class="form-control" rows="5" ></textarea>' +
                                                '<div id="errorDescripcionTarea" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede ser vacío.</div>' +
                                                '<div id="errorDescripcionAsteriscos" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede contener el caracter *.</div>' +
                                                 '</div>' +
                                                 '<div class="modal-footer">' +
                                                 '<button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                                                 '<button id="btnGuardar" onclick="GuardarRegistroDescripcionTarea()" type="button" class="btn btn-primary">Guardar</button>' +
                                                 '</div>' +
                                                 '</div>' +
                                                 '</div>' +
                                                 '<script type="text/javascript">' +
			                                        '$(".form_datetime").datetimepicker({' +
			                                            'language: "es",' +
			                                            'weekStart: 1,' +
			                                            'todayBtn: 1,' +
			                                            'autoclose: 1,' +
			                                            'todayHighlight: 1,' +
			                                            'startView: 2,' +
			                                            'forceParse: 0,' +
			                                            'showMeridian: 1' +
			                                        '});' +
			                                        '$(".form_date").datetimepicker({' +
			                                            'language: "es",' +
			                                            'weekStart: 1,' +
			                                            'todayBtn: 1,' +
			                                            'autoclose: 1,' +
			                                            'todayHighlight: 1,' +
			                                            'startView: 2,' +
			                                            'minView: 2,' +
			                                            'forceParse: 0' +
			                                        '});' +
			                                        '$(".form_time").datetimepicker({' +
			                                            'language: "es",' +
			                                            'weekStart: 1,' +
			                                            'todayBtn: 1,' +
			                                            'autoclose: 1,' +
			                                            'todayHighlight: 1,' +
			                                            'startView: 1,' +
			                                            'minView: 0,' +
			                                            'maxView: 1,' +
			                                            'forceParse: 0' +
			                                            '});' +
                                                   '</script>'
                                            );
    $("#txtDescripcion").val(descripcion);
    $('#dtpFechaDescripcion').val(fechaTarea);
}
function EditarDescripcionTarea() {
    OcultarValidadoresDescripcionTarea();
    var mensajeFecha = $("#fechaDescripcion")[0].innerText.split(':');
    if (mensajeFecha.length > 1) {
        AsignarValoresDescripcionTarea(mensajeFecha[1], $("#descripcionTarea")[0].innerText);
        $("#myModalLabel").html("Editar Descripción");
        $("#myModalDescripcionTarea").modal();
    }
}
function GuardarRegistroDescripcionTarea() {
    OcultarValidadoresDescripcionTarea();
    var guardarRegistro = ValidarFormatoDescripcionTarea($("#dtpFechaDescripcion").val(), $("#txtDescripcion").val());
    if (guardarRegistro == true) {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarDescripcionTarea: $("#hfidTarea").val() + '*' + $("#dtpFechaDescripcion").val() + '*' + $("#txtDescripcion").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamPlanTrabajo('Guardando datos observaciones tareas...');
            },
            success: function (result) {
                if (result == '<||>') {
                    CargarDetalleTarea();
                    $("#myModalDescripcionTarea").hidden = "hidden";
                    $("#myModalDescripcionTarea").modal('toggle');
                }
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
}
function ValidarFormatoDescripcionTarea(fecha, descripcion) {
    if (fecha == '') {
        $("#errorFechaDescripcionTarea").show();
        return false;
    }
    if (descripcion == '') {
        $("#errorDescripcionTarea").show();
        return false;
    }
    var descripcionTareaAsterisco = descripcion.split('*');
    if (descripcionTareaAsterisco.length > 1) {
        $("#errorDescripcionAsteriscos").show();
        return false;
    }
    return true;
}
function AnadirResultadoTarea() {
    OcultarValidadoresResultadoTarea();
    var fechaActual = new Date();
    var fecha = fechaActual.getFullYear() + '-' + (fechaActual.getMonth() + 1) + '-' + fechaActual.getDate(); // fechaActual.getDate() + '/' + (fechaActual.getMonth() + 1) + '/' + fechaActual.getFullYear();
    AsignarValoresResultadoTarea(fecha, '');
    $("#myModalLabelResultadoTarea").html("Ingresar Resultado");
    $("#myModalResultadoTarea").modal();
}
function OcultarValidadoresResultadoTarea() {
    $("#errorFechaResultadoTarea").hide();
    $("#errorResultadoTarea").hide();
    $("#errorResultadoTareaAsteriscos").hide();
}
function AsignarValoresResultadoTarea(fechaTarea, descripcion) {
    $("#myModalResultadoTarea").html(
                                                '<div class="modal-dialog" role="document">' +
                                                '<div class="modal-content">' +
                                                '<div class="modal-header">' +
                                                '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                                                '<h4 class="modal-title" id="myModalLabelResultadoTarea">Nueva Descripción</h4>' +
                                                '</div>' +
                                                '<div class="modal-body">' +
                                                '<div class="form-group">' +
                                                '<label for="fecha_posterior_2" class="control-label">Fecha</label>' +
                                                '<div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_2" data-link-format="yyyy-mm-dd">' +
                                                '<input id="dtpFechaResultadoTarea" class="form-control" size="16" type="text" value="" readonly>' +
                                                '<span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>' +
                                                '<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>' +
                                                '</div>' +
                                                '<input type="hidden" id="fecha_posterior_2" value="" />' +
                                                '</div>' +
                                                '<div id="errorFechaResultadoTarea" class="alert alert-danger alert-dismissible" hidden="hidden" >La fecha de la descripción no puede ser vacía.</div>' +
                                                '<textarea id="txtResultado" placeholder="Describa la tarea" class="form-control" rows="5" ></textarea>' +
                                                '<div id="errorResultadoTarea" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede ser vacío.</div>' +
                                                '<div id="errorResultadoTareaAsteriscos" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede contener el caracter *.</div>' +
                                                 '</div>' +
                                                 '<div class="modal-footer">' +
                                                 '<button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                                                 '<button id="btnGuardar" onclick="GuardarRegistroResultadoTarea()" type="button" class="btn btn-primary">Guardar</button>' +
                                                 '</div>' +
                                                 '</div>' +
                                                 '</div>' +
                                                 '<script type="text/javascript">' +
			                                        '$(".form_datetime").datetimepicker({' +
			                                            'language: "es",' +
			                                            'weekStart: 1,' +
			                                            'todayBtn: 1,' +
			                                            'autoclose: 1,' +
			                                            'todayHighlight: 1,' +
			                                            'startView: 2,' +
			                                            'forceParse: 0,' +
			                                            'showMeridian: 1' +
			                                        '});' +
			                                        '$(".form_date").datetimepicker({' +
			                                            'language: "es",' +
			                                            'weekStart: 1,' +
			                                            'todayBtn: 1,' +
			                                            'autoclose: 1,' +
			                                            'todayHighlight: 1,' +
			                                            'startView: 2,' +
			                                            'minView: 2,' +
			                                            'forceParse: 0' +
			                                        '});' +
			                                        '$(".form_time").datetimepicker({' +
			                                            'language: "es",' +
			                                            'weekStart: 1,' +
			                                            'todayBtn: 1,' +
			                                            'autoclose: 1,' +
			                                            'todayHighlight: 1,' +
			                                            'startView: 1,' +
			                                            'minView: 0,' +
			                                            'maxView: 1,' +
			                                            'forceParse: 0' +
			                                            '});' +
                                                   '</script>'
                                            );
    $("#txtResultado").val(descripcion);
    $('#dtpFechaResultadoTarea').val(fechaTarea)
}
function EditarResultadoTarea() {
    OcultarValidadoresResultadoTarea();
    var mensajeFecha = $("#fechaResultadoTarea")[0].innerText.split(':');
    if (mensajeFecha.length > 1) {
        AsignarValoresResultadoTarea(mensajeFecha[1], $("#resultadoTarea")[0].innerText);
        $("#myModalLabelResultadoTarea").html("Editar Resultado");
        $("#myModalResultadoTarea").modal();
    }
}
function GuardarRegistroResultadoTarea() {
    OcultarValidadoresResultadoTarea();
    var guardarRegistro = ValidarFormatoDescripcionTarea($("#dtpFechaResultadoTarea").val(), $("#txtResultado").val());
    if (guardarRegistro == true) {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarResultadoTarea: $("#hfidTarea").val() + '*' + $("#dtpFechaResultadoTarea").val() + '*' + $("#txtResultado").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamPlanTrabajo('Guardando datos resultados tareas...');
            },
            success: function (result) {
                if (result == '<||>') {
                    CargarDetalleTarea();
                    $("#myModalResultadoTarea").hidden = "hidden";
                    $("#myModalResultadoTarea").modal('toggle');
                }
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
}
function ValidarFormatoResultadoTarea(fecha, descripcion) {
    if (fecha == '') {
        $("#errorFechaResultadoTarea").show();
        return false;
    }
    if (descripcion == '') {
        $("#errorResultadoTarea").show();
        return false;
    }
    var descripcionTareaAsterisco = descripcion.split('*');
    if (descripcionTareaAsterisco.length > 1) {
        $("#errorResultadoTareaAsteriscos").show();
        return false;
    }
    return true;
}
function AnadirRecursoMultimediaTarea() {
    OcultarValidadoresRecursosMultimediaTarea();
    var fechaActual = new Date();
    var fecha = fechaActual.getDate() + '/' + (fechaActual.getMonth() + 1) + '/' + fechaActual.getFullYear();
    AsignarValoresRecursosMultimediaTarea(fecha, '');
    $("#myModalLabelRecursoTarea").html("Ingresar Recurso Multimedia");
    $("#nuevoRegistroMul").modal();
}
function OcultarValidadoresRecursosMultimediaTarea() {
    $("#errorRecursoMultimediaTarea").hide();
    $("#errorFechaRecursoMultimedia").hide();
    $("#errorDescripcionRecursoMultimedia").hide();
    $("#errorDescripcionRecursoMultimediaAsterisco").hide();
}
function AsignarValoresRecursosMultimediaTarea(fechaTarea, descripcion)
{
    $("#nuevoRegistroMul").html(
                                                   '<div class="modal-dialog" role="document">' +
                                                   '<div class="modal-content">' +
                                                   '<div class="modal-header">' +
                                                   '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                                                   '<h4 class="modal-title" id="myModalLabelRecursoTarea">Nueva Descripción</h4>' +
                                                   '</div>' +
                                                   '<div class="modal-body">' +
                                                   //'<div class="form-group">' +
                                                        '<label class="modal-title">Agregar Recurso</label><br/>' +
                                                        '<input id="recursoMultimediaTarea" class="file-loading" type="file">' +
                                                        '<div id="errorRecursoMultimediaTarea" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre del recurso no puede ser vacío.</div>' +
                                                        '<label for="fecha_posterior_2" class="control-label">Fecha</label>' +
                                                        '<div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_2" data-link-format="yyyy-mm-dd">' +
                                                            '<input id="dtpFechaRecursoMultimedia" class="form-control" size="16" type="text" value="" readonly>' +
                                                            '<span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>' +
                                                            '<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>' +
                                                        '</div>' +
                                                        '<input type="hidden" id="fecha_posterior_2" value="" />' +
                                                   //'</div>' +
                                                        '<div id="errorFechaRecursoMultimedia" class="alert alert-danger alert-dismissible" hidden="hidden" >La fecha de la descripción no puede ser vacía.</div>' +
                                                        '<textarea id="txtDescripcionRecursoMultimedia" placeholder="Describa el recurso que desea ingresar" class="form-control" rows="5" ></textarea>' +
                                                        '<div id="errorDescripcionRecursoMultimedia" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede ser vacío.</div>' +
                                                        '<div id="errorDescripcionRecursoMultimediaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede contener el caracter *.</div>' +
                                                    '</div>' +
                                                    '<div class="modal-footer">' +
                                                    '<button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                                                    '<button id="btnGuardar" onclick="GuardarRegistroRecursoMultimediaTarea()" type="button" class="btn btn-primary">Guardar</button>' +
                                                    '</div>' +
                                                    '</div>' +
                                                    '</div>' +
                                                    '<script type="text/javascript">' +
                                                       '$(".form_datetime").datetimepicker({' +
                                                           'language: "es",' +
                                                           'weekStart: 1,' +
                                                           'todayBtn: 1,' +
                                                           'autoclose: 1,' +
                                                           'todayHighlight: 1,' +
                                                           'startView: 2,' +
                                                           'forceParse: 0,' +
                                                           'showMeridian: 1' +
                                                       '});' +
                                                       '$(".form_date").datetimepicker({' +
                                                           'language: "es",' +
                                                           'weekStart: 1,' +
                                                           'todayBtn: 1,' +
                                                           'autoclose: 1,' +
                                                           'todayHighlight: 1,' +
                                                           'startView: 2,' +
                                                           'minView: 2,' +
                                                           'forceParse: 0' +
                                                       '});' +
                                                       '$(".form_time").datetimepicker({' +
                                                           'language: "es",' +
                                                           'weekStart: 1,' +
                                                           'todayBtn: 1,' +
                                                           'autoclose: 1,' +
                                                           'todayHighlight: 1,' +
                                                           'startView: 1,' +
                                                           'minView: 0,' +
                                                           'maxView: 1,' +
                                                           'forceParse: 0' +
                                                           '});' +
                                                      '</script>'
                                               );
    $("#txtDescripcionRecursoMultimedia").val(descripcion);
    $('#dtpFechaRecursoMultimedia').val(fechaTarea);
    var tipoArchivoACargar = AsignarArchivoSubir();
    $("#recursoMultimediaTarea").fileinput({
        language: 'es',
        uploadUrl: "../../Views/VerificacionAnalisis/DetallePlanTrabajoRecursoMultimedia_ajax", // server upload action
        uploadAsync: true,
        showUpload: false,
        minFileCount: 1,
        maxFileCount: 1,
        overwriteInitial: true,
        browseLabel: 'Cargar recurso...',
        initialPreview: [],
        initialPreviewAsData: true, // identify if you are sending preview data only and not the markup
        showPreview: true,
        showRemove: false, // hide remove button
        initialPreviewFileType: '[' + tipoArchivoACargar + ']'
    }).on('filepreupload', function (event, data, previewId, index, jqXHR) {
        var rutaImagen = $("#recursoMultimediaTarea").val().split("\\");
        data.form.append("idTarea", $("#hfidTarea").val());
        data.form.append("idTipoAdjunto", "1");
        data.form.append("FechaRecursoMultimedia", $("#dtpFechaRecursoMultimedia").val());
        data.form.append("DescripcionRecursoMultimedia", $("#txtDescripcionRecursoMultimedia").val());
        data.form.append("rutaImagen", rutaImagen[rutaImagen.length - 1]);
    }).on('fileuploaded', function (event, data, id, index) {
        $("#nuevoRegistroMul").modal('toggle');
        $("#nuevoRegistroMul").hidden = "hidden";
        $("#nuevoRegistroMul").hide();
        CargarDetalleTarea();
    });;
}
function AsignarArchivoSubir()
{
    switch ($("#hfTitulo").val().toUpperCase().trim())
    {
        case "DIARIO DE CAMPO CON REGISTRO FOTOGRÁFICO":
            return 'image', 'audio';
        case "VISITAS":
            return 'image';
        case "REUNIONES":
            return 'image';
        case "ENTREVISTA":
            return 'audio';
        case "COMPROMISOS POR PARTE DE TERCEROS":
            return 'image', 'html', 'text', 'video', 'audio', 'flash', 'object';
    }
    return 'image';
}
function GuardarRegistroRecursoMultimediaTarea()
{
    OcultarValidadoresRecursosMultimediaTarea();
    var rutaImagen = $("#recursoMultimediaTarea").val().split("\\");
    var guardarRegistro = ValidarFormatoRegistroRecursoMultimediaTarea($("#dtpFechaRecursoMultimedia").val(), $("#txtDescripcionRecursoMultimedia").val(), rutaImagen);
    if (guardarRegistro == true) $("#recursoMultimediaTarea").fileinput("upload");
}
function ValidarFormatoRegistroRecursoMultimediaTarea(fecha, descripcion, rutaImagen) {
    if (fecha == '')
    {
        $("#errorFechaRecursoMultimedia").show();
        return false;
    }
    if (descripcion == '')
    {
        $("#errorDescripcionRecursoMultimedia").show();
        return false;
    }
    var descripcionRecursoMultimediaAsterisco = descripcion.split('*');
    if (descripcionRecursoMultimediaAsterisco.length > 1)
    {
        $("#errorDescripcionRecursoMultimediaAsterisco").show();
        return false;
    }
    if (rutaImagen == '') {
        $("#errorRecursoMultimediaTarea").show();
        return false;
    }
    return true;
}
function AnadirTarea()
{
    if ($("#hfidUsuario").val() != '')
        ValidarUsuarioGrupoGac();
    else
        bootbox.alert("Lo sentimos.\nPor favor, inicie sesión en el sistema de lo contrario no podrá agregar tareas.");
}

function ValidarUsuarioGrupoGac()
{
    $.ajax({
        type: "POST",
        url: '../../Views/VerificacionAnalisis/PlanTrabajo_ajax', data: { ValidarUsuarioMiembroGac: $("#hfidUsuario").val() + "*" + $("#hfidGac").val() },
        traditional: true,
        cache: false,
        dataType: "text",
        beforeSend: function () {
            waitblockUIParamPlanTrabajo('Validando acceso crear tarea...');
        },
        success: function (result)
        {
            unblockUI();
            if (result != null && result == "true")
            {
                var fechaActual = new Date();
                var fecha = fechaActual.getFullYear() + '-' + (fechaActual.getMonth() + 1) + '-' + fechaActual.getDate(); // fechaActual.getDate() + '/' + (fechaActual.getMonth() + 1) + '/' + fechaActual.getFullYear();
                AsignarValoresTarea(fecha, $("#hfidUsuario").val(), $("#hfcodigoBPIN").val());
                OcultarValidadoresTarea();
                ObtenerTipoTareas();
                ObtenerMiembrosGac();
                $("#myModalLabel").html("Ingresar Tarea");
                $("#myModalIngresarTarea").modal();
            }
            else bootbox.alert("Lo sentimos.\nUd no pertenece a este grupo auditor por tanto, no podrá agregar tareas.");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            bootbox.alert("error");
            bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUI();
        }
    });


   
}

function AsignarValoresTarea(fechaTarea, idUsuario,codigoBPIN) {
    $("#myModalIngresarTarea").html(
                                                '<div class="modal-dialog" role="document">' +
                                                '<div class="modal-content">' +
                                                '<div class="modal-header">' +
                                                '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                                                '<h4 class="modal-title" id="myModalLabel">Añadir Tarea</h4>' +
                                                '</div>' +
                                                '<div class="modal-body">' +
                                                '<input type="hidden" id="hfcodigoBPINTarea" runat="server"/>'+
                                                '<input type="hidden" id="hfidUsuarioTarea" runat="server"/>'+
                                                '<div class="form-group">' +
                                                    '<label class="modal-title">Tipo de Tareas</label>' +
                                                    '<select id="selTiposTareas" class="form-control"></select>' +
                                                    '<div id="errorselTiposTareas" class="alert alert-danger alert-dismissible" hidden="hidden">El tipo de tarea no puede ser vacío.</div>' +
                                                    '<label class="modal-title">Responsable</label>' +
                                                    '<select id="selNombresApellidos" class="form-control"></select>' +
                                                    '<div id="errorselResponsable" class="alert alert-danger alert-dismissible" hidden="hidden">El responsable de la tarea no puede ser vacío.</div>' +
                                                    '<label for="fecha_posterior_2" class="control-label">Fecha</label>' +
                                                    '<div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_2" data-link-format="yyyy-mm-dd">' +
                                                        '<input id="dtpFechaTarea" class="form-control" size="16" type="text" value="" readonly>' +
                                                        '<span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>' +
                                                        '<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>' +
                                                    '</div>' +
                                                    '<input type="hidden" id="fecha_posterior_2" value="" />' +
                                                '</div>' +
                                                '<div id="errorFechaTarea" class="alert alert-danger alert-dismissible" hidden="hidden" >La fecha de la tarea no puede ser vacía.</div>' +
                                                '<textarea id="txtDetalleTarea" placeholder="Describa el detalle de la tarea ..." class="form-control" rows="5" ></textarea>' +
                                                '<div id="errorDetalleTarea" class="alert alert-danger alert-dismissible" hidden="hidden">El detalle de la tarea no puede ser vacío.</div>' +
                                                '<div id="errorDetalleTareaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El detalle de la tarea no puede contener el caracter *.</div>' +
                                                 '</div>' +
                                                 '<div class="modal-footer">' +
                                                 '<button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                                                 '<button id="btnGuardar" onclick="GuardarTarea()" type="button" class="btn btn-primary">Guardar</button>' +
                                                 '</div>' +
                                                 '</div>' +
                                                 '</div>' +
                                                 '<script type="text/javascript">' +
			                                        '$(".form_datetime").datetimepicker({' +
			                                            'language: "es",' +
			                                            'weekStart: 1,' +
			                                            'todayBtn: 1,' +
			                                            'autoclose: 1,' +
			                                            'todayHighlight: 1,' +
			                                            'startView: 2,' +
			                                            'forceParse: 0,' +
			                                            'showMeridian: 1' +
			                                        '});' +
			                                        '$(".form_date").datetimepicker({' +
			                                            'language: "es",' +
			                                            'weekStart: 1,' +
			                                            'todayBtn: 1,' +
			                                            'autoclose: 1,' +
			                                            'todayHighlight: 1,' +
			                                            'startView: 2,' +
			                                            'minView: 2,' +
			                                            'forceParse: 0' +
			                                        '});' +
			                                        '$(".form_time").datetimepicker({' +
			                                            'language: "es",' +
			                                            'weekStart: 1,' +
			                                            'todayBtn: 1,' +
			                                            'autoclose: 1,' +
			                                            'todayHighlight: 1,' +
			                                            'startView: 1,' +
			                                            'minView: 0,' +
			                                            'maxView: 1,' +
			                                            'forceParse: 0' +
			                                            '});' +
                                                   '</script>'
                                            );
    $('#dtpFechaTarea').val(fechaTarea);
    $('#fecha_posterior_2').val(fechaTarea);
    $('#hfcodigoBPINTarea').val(codigoBPIN);
    $('#hfidUsuarioTarea').val(idUsuario);
}
function OcultarValidadoresTarea() {
    $("#errorFechaTarea").hide();
    $("#errorDetalleTarea").hide();
    $("#errorDetalleTareaAsterisco").hide();
    $("#errorselTiposTareas").hide();
}
function ObtenerTipoTareas()
{
    $.ajax({
        type: "POST",
        url: '../../Views/VerificacionAnalisis/PlanTrabajo_ajax', data: { ObtenerTipoTareas: "ObtenerTipoTareas" },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParamPlanTrabajo('Cargando tipos de tareas...');
        },
        success: function (result)
        {
            if (result != null && result != "")
            {
                var datasource = '';
                for (var i = 0; i < result.Head.length; i++)
                    datasource = datasource + '<option value="'+ result.Head[i].idTipoTarea + '">' + result.Head[i].nombre + '</option>';
            }
            $("#selTiposTareas").html(datasource);
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUI();
        }
    });
}
function ObtenerMiembrosGac() {
    $.ajax({
        type: "POST",
        url: '../../Views/VerificacionAnalisis/PlanTrabajo_ajax', data: { ObtenerMiembrosGac: $("#hfidGac").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParamPlanTrabajo('Cargando tipos de tareas...');
        },
        success: function (result) {
            if (result != null && result != "") {
                var datasource = '';
                for (var i = 0; i < result.Head.length; i++)
                    datasource = datasource + '<option value="'+ result.Head[i].IdUsuario +'">' + result.Head[i].Nombre + '</option>';
            }
            $("#selNombresApellidos").html(datasource);
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUI();
        }
    });
}
function GuardarTarea() {
    OcultarValidadoresTarea();
    var guardarRegistro = ValidarTarea();
    if (guardarRegistro == true) {
        $.ajax({
            //type: "POST", url: '../../Views/VerificacionAnalisis/PlanTrabajo_ajax', data: { GuardarTarea: $("#txtDetalleTarea").val() + '*' + $("#selTiposTareas").val() + '*' + $("#selNombresApellidos").val() + '*' + $("#dtpFechaTarea").val() + '*' + $("#hfidtipoAudiencia").val() }, traditional: true,
            type: "POST", url: '../../Views/VerificacionAnalisis/PlanTrabajo_ajax', data: { GuardarTarea: $("#txtDetalleTarea").val() + '*' + $("#selTiposTareas").val() + '*' + $("#fecha_posterior_2").val() + '*' + $("#hfcodigoBPINTarea").val() + '*' + $("#selNombresApellidos").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamPlanTrabajo('Guardando tarea...');
            },
            success: function (result)
            {
                unblockUI();
                if (result == '<||>')
                {
                    CargarPlanesTrabajo();
                    $("#myModalIngresarTarea").hidden = "hidden";
                    $("#myModalIngresarTarea").modal('toggle');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
}
function ValidarTarea()
{
    if ($("#fecha_posterior_2").val() == '') {
        $("#errorFechaTarea").show();
        return false;
    }
    if ($("#txtDetalleTarea").val() == '') {
        $("#errorDetalleTarea").show();
        return false;
    }
    var descripcionTareaAsterisco = $("#txtDetalleTarea").val().split('*');
    if (descripcionTareaAsterisco.length > 1) {
        $("#errorDetalleTareaAsterisco").show();
        return false;
    }
    if ($("#selTiposTareas").val() == null)
    {
        $("#errorselTiposTareas").show();
        return false;
    }
    if ($("#selNombresApellidos").val() == null)
    {
        $("#errorselResponsable").show();
        return false;
    }
    return true;
}

//#endregion Lógica ventanas modales
function descargar_pdf(){
    //genPdfPlantilla("../../Views/VerificacionAnalisis/formatoAsistencia_ajax", "divPdfAsistencia", null);
    genPdfPlantilla("../Views/Audiencias/DescargaFormato_ajax", "divPdfAsistencia", null);
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
//#Region Funciones Generar reporte Excel Plan de Trabajo
function genExcelPlanTrabajo(codigoBPIN, idGac, idUsuario) {
    if ($('#ifrExcelPlanTrabajo').length == 0) {
        $('#divOtros').append('<iframe id="ifrExcelPlanTrabajo" name="ifrExcelPlanTrabajo" width="0" height="0" style="width:0px;height:0px;float:right;"></iframe><form id="frmExpExcel" name="frmExpExcel" style="display:none;float:right;" target="ifrExcelPlanTrabajo" method="POST" action="../Views/VerificacionAnalisis/PlanTrabajoGenererHojaCalculo_ajax"></form>');
    }
    $('#frmExpExcel').html('<input type="hidden" id="hfcodigoBPIN" name="hfcodigoBPIN" value="' + codigoBPIN + '" /><input type="hidden" id="hfidGac" name="hfidGac" value="' + idGac + '" /><input type="hidden" id="hfidUsuario" name="hfidUsuario" value="' + idUsuario + '" />');
    $('#frmExpExcel').submit();
}
function CargarPlanesTrabajoReporte() {
    genExcelPlanTrabajo($("#hfcodigoBPIN").val() ,$("#hfidGac").val() , $("#hfidUsuario").val())
    //$.ajax({
    //    type: "POST",
    //    url: '../../Views/VerificacionAnalisis/PlanTrabajo_ajax', data: { GENERARREPORTEPLANTRABAJO: $("#hfcodigoBPIN").val() + '*' + $("#hfidGac").val() + '*' + $("#hfidUsuario").val() },
    //    traditional: true,
    //    cache: false,
    //    //dataType: "json",
    //    beforeSend: function () {
    //        waitblockUIParamPlanTrabajo('Generando listado tareas...');
    //    },
    //    success: function (result) {
    //        var datasource = '';
    //        if (result != null && result != "") {
    //            for (var i = 0; i < result.Head.length; i++) {
    //                var observacionAuditor = '';
    //                if (result.Head[i].ObservacionAuditor != null) observacionAuditor = result.Head[i].ObservacionAuditor;
    //                var color = result.Head[i].semaforo;
    //                var estado = '';
    //                switch (color) {
    //                    case 'red':
    //                        estado = 'Vencido';
    //                        break;
    //                    case 'green':
    //                        estado = 'A tiempo';
    //                        break;
    //                    case 'orange':
    //                        estado = 'Por vencer';
    //                        break;
    //                    case 'gris':
    //                        estado = 'Bien';
    //                        break;
    //                    case 'blue':
    //                        estado = 'Finalizado';
    //                        break;
    //                    default:
    //                        estado = 'A tiempo';
    //                }
    //                datasource = datasource +
    //                         '<div class="list-group uppText">' +
    //                         '<div class="list-group-item">' +
    //                         '<div class="col-sm-2">' +
    //                         '<p class="list-group-item-text"><span class="glyphicon glyphicon-copy"></span>' + result.Head[i].Nombre + '</p>' +
    //                         '</div>' +
    //                         '<div class="col-sm-2"><span class="glyphicon glyphicon-user"></span><span>' + result.Head[i].NombreUsuario + '</span></div>' +
    //                         '<div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>' + result.Head[i].fecha + '</span></div>' +
    //                         '<div class="col-sm-2">' +
    //                         '<div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>' + result.Head[i].fechaCierreTarea + '</span></div>' +
    //                         ' </div>' +
    //                         '<div class="col-sm-2"><a role="button" onclick="ObtInfoTarea(\'' + result.Head[i].idTarea + '*' + result.Head[i].Nombre + '*' + result.Head[i].fecha + '*' + result.Head[i].IdUsuario + '*' + $("#hfidUsuario").val() + '\');"><span class="glyphicon glyphicon-calendar"></span> <span>Detalle</span></a></div>' +
    //                         '<div class="col-sm-2"><span class="badge ' + color + '">' + estado + '</span></div>' +
    //                         '</div>' +
    //                         '</div>';
    //            }
    //        }
    //        $("#datosPlanTrabajo").html(datasource);
    //        unblockUI();
    //    },
    //    error: function (XMLHttpRequest, textStatus, errorThrown) {
    //        alert("error");
    //        alert(textStatus + ": " + XMLHttpRequest.responseText);
    //        unblockUI();
    //    }
    //});
}
//#endRegion Funciones Generar reporte Excel Plan de Trabajo