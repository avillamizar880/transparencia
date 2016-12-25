function CargarPlanesTrabajo() {
    $.ajax({
        type: "POST",
        url: '../../Views/VerificacionAnalisis/PlanTrabajo_ajax', data: { BuscarPlanesTrabajo: "BuscarPlanesTrabajo" },
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
                    datasource = datasource +
                             '<div class="list-group uppText">' +
                             '<div class="list-group-item">' +
                             '<div class="col-sm-3">' +
                             '<p class="list-group-item-text"><a href="plandetrabajo_auditor69.html"><span class="glyphicon glyphicon-copy"></span>'+ result.Head[i].nombre + '</a></p>' +
                             '</div>' +
                             '<div class="col-sm-2"><span class="glyphicon glyphicon-user"></span><span>'+result.Head[i].NombreUsuario + '</span></div>' +
                             '<div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>' + result.Head[i].fecha + '</span></div>' +
                             '<div class="col-sm-4">' +
                             '<p><span class="glyphicon glyphicon-comment"></span>Opinión sobre lo visto.</p>' +
                             ' </div>' +
                             '<div class="col-sm-1"><a role="button" onclick="ObtInfoTarea(\'' + result.Head[i].idTarea + '\');"><span class="glyphicon glyphicon-calendar"></span> <span>Ver detalles</span></a></div>' +
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
function ObtInfoTarea(idTarea) {
    ajaxPost('../../Views/VerificacionAnalisis/DetallePlanTrabajo', { DetallePlanTrabajo: idTarea }, 'dvPrincipal', function (r) {
    }, function (e) {
        alert(e.responseText);
    });
}
function CargarDetalleTarea()
{
    $.ajax({
        type: "POST",
        url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { BuscarDetalleTarea: $("#hfidTarea").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParamPlanTrabajo('Cargando detalle tareas...');
        },
        success: function (result) {
            $("#btnAnadirDescripcion").show();
            $("#btnAnadirResultadoTarea").show();
            $("#btnEditarDescripcion").hide();
            $("#btnEditarResultadoTarea").hide();
            if (result != null && result != "") {
                for (var i = 0; i < result.Head.length; i++) {
                    $("#fechaTarea").html("<span class='glyphicon glyphicon-calendar'></span>Fecha:&nbsp;" + result.Head[i].Fecha);
                    $("#horaTarea").html("<span class='glyphicon glyphicon-time'></span>Hora:&nbsp;" + result.Head[i].Hora);
                    if (result.Head[i].fechaCreacion != null)
                    {
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
                    }
                    else
                    {
                        $("#btnFinalizar").hide();
                        $("#btnEliminar").hide();
                        $("#btnAnadirDescripcion").hide();
                        $("#btnAnadirResultadoTarea").hide();
                        $("#btnEditarDescripcion").hide();
                        $("#btnEditarResultadoTarea").hide();
                    }
                }
            }
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUI();
        }
    });
}
function waitblockUIParamPlanTrabajo(mensaje) { $.blockUI({ message: "<h2>" + mensaje + "</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }
function EditarDescripcionTarea() {
    OcultarValidadoresDescripcionTarea();
    var mensajeFecha = $("#fechaDescripcion")[0].innerText.split(':');
    if (mensajeFecha.length > 1)
    {
        AsignarValoresDescripcionTarea(mensajeFecha[1], $("#descripcionTarea")[0].innerText);
        $("#myModalLabel").html("Editar Descripción");
        $("#myModalDescripcionTarea").modal();
    }    
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
                                                 '</div>'+
                                                 '<script type="text/javascript">'+
			                                        '$(".form_datetime").datetimepicker({'+
			                                            'language: "es",'+
			                                            'weekStart: 1,'+
			                                            'todayBtn: 1,'+
			                                            'autoclose: 1,'+
			                                            'todayHighlight: 1,'+
			                                            'startView: 2,'+
			                                            'forceParse: 0,'+
			                                            'showMeridian: 1'+
			                                        '});'+
			                                        '$(".form_date").datetimepicker({'+
			                                            'language: "es",'+
			                                            'weekStart: 1,'+
			                                            'todayBtn: 1,'+
			                                            'autoclose: 1,'+
			                                            'todayHighlight: 1,'+
			                                            'startView: 2,'+
			                                            'minView: 2,'+
			                                            'forceParse: 0'+
			                                        '});'+
			                                        '$(".form_time").datetimepicker({'+
			                                            'language: "es",'+
			                                            'weekStart: 1,'+
			                                            'todayBtn: 1,'+
			                                            'autoclose: 1,'+
			                                            'todayHighlight: 1,'+
			                                            'startView: 1,'+
			                                            'minView: 0,'+
			                                            'maxView: 1,'+
			                                            'forceParse: 0'+
			                                            '});'+
                                                   '</script>'
                                            );
    $("#txtDescripcion").val(descripcion);
    $('#dtpFechaDescripcion').val(fechaTarea)
}
function AnadirDescripcionTarea()
{   
    OcultarValidadoresDescripcionTarea();
    var fechaActual = new Date();
    var fecha = fechaActual.getDate() + '/' + (fechaActual.getMonth() + 1) + '/' + fechaActual.getFullYear();
    AsignarValoresDescripcionTarea(fecha, '');
    $("#myModalLabel").html("Ingresar Descripción");
    $("#myModalDescripcionTarea").modal();
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
    if (fecha == '')
    {
        $("#errorFechaDescripcionTarea").show();
        return false;
    }
    if (descripcion == '')
    {
        $("#errorDescripcionTarea").show();
        return false;
    }
    var descripcionTareaAsterisco = descripcion.split('*');
    if (descripcionTareaAsterisco.length > 1)
    {
        $("#errorDescripcionAsteriscos").show();
        return false;
    }
    return true;
}
function EditarResultadoTarea()
{
    OcultarValidadoresResultadoTarea();
    var mensajeFecha = $("#fechaResultadoTarea")[0].innerText.split(':');
    if (mensajeFecha.length > 1)
    {
        AsignarValoresResultadoTarea(mensajeFecha[1], $("#resultadoTarea")[0].innerText);
        $("#myModalLabel").html("Editar Resultado");
        $("#myModalResultadoTarea").modal();
    }
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
                                                '<h4 class="modal-title" id="myModalLabel">Nueva Descripción</h4>' +
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
function GuardarRegistroResultadoTarea()
{
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
function AnadirResultadoTarea()
{
    OcultarValidadoresResultadoTarea();
    var fechaActual = new Date();
    var fecha = fechaActual.getDate() + '/' + (fechaActual.getMonth()+1) + '/' + fechaActual.getFullYear();
    AsignarValoresResultadoTarea(fecha, '');
    $("#myModalLabel").html("Ingresar Resultado");
    $("#myModalResultadoTarea").modal();
}
function EliminarTarea()
{
    if (confirm("¿Desea eliminar esta tarea?"))
    {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { EliminarTarea: $("#hfidTarea").val()}, traditional: true,
            beforeSend: function () {
                waitblockUIParamPlanTrabajo('Eliminando tareas...');
            },
            success: function (result) {
                if (result == '<||>') {
                    //$("#myModalResultadoTarea").hidden = "hidden";
                    //$("#myModalResultadoTarea").modal('toggle');
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