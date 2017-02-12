﻿function MostrarDetallePlanTrabajo()
{
    if ($("#hfTitulo").val() != null)
    {
        $("#tareaActaReuniones").hide();
        $("#tareaDiarioNotas").hide();
        $("#tareaVisitaCampo").hide();
        switch ($("#hfTitulo").val().toUpperCase().trim())
        {
            case "VISITA DE CAMPO":
                $("#tareaVisitaCampo").show();
                break;
            case "ACTAS REUNIONES":
                $("#tareaActaReuniones").show();
                CargarInformacionActasReuniones();
                break;
            case "DIARIO DE NOTAS":
                $("#tareaDiarioNotas").show();
                CargarInformacionDiarioNotas();
                break;
            case "REGISTRO FOTOGRÁFICO":
                $("#tareaSeguimientoProyecto").show();
                break;
        }
    }
}
function GuardarCompromisoTarea()
{
    var guardarRegistro = ValidarCompromisoTareaGuardar();
    if (guardarRegistro == true)
    {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarCompromisoActaReunionTarea: $("#hfidTarea").val() + '*' + $("#txtCompromiso").val() + '*' + $("#txtResponsable").val() + '*' + $("#dtpFechaCumplimiento").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamDetalleTarea('Guardando compromiso reunión...');
            },
            success: function (result)
            {
                unblockUIDetalleTarea();
                if (result == '<||>')
                {
                    CargarInformacionActasReuniones();
                    $("#myModalCompromisos").hidden = "hidden";
                    $("#myModalCompromisos").modal('toggle');
                }
            }
        }); 
    }
}
function ValidarCompromisoTareaGuardar()
{
    $("#errorCompromisosActa").hide();
    $("#errorCompromisosActaAsterisco").hide();
    $("#errorResponsable").hide();
    $("#errorResponsableAsterisco").hide();
    $("#errorFechaCumplimiento").hide();
    var caracteresEspeciales = $("#txtCompromiso").val().split('*');
    if ($("#txtCompromiso").val() == '') {
        $("#errorCompromisosActa").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorCompromisosActaAsterisco").show();
        return false;
    }
    caracteresEspeciales = $("#txtResponsable").val().split('*');
    if ($("#txtResponsable").val() == '') {
        $("#errorResponsable").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorResponsableAsterisco").show();
        return false;
    }
    if ($("#dtpFechaCumplimiento").val() == '')
    {
        $("#errorFechaCumplimiento").show();
        return false;
    }
    return true;
}
function GuardarDiarioNotasTarea() {
    var guardarRegistro = ValidarDiarioNotasTareas();
    if (guardarRegistro == true)
    {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarDiarioNotasTarea: $("#hfidTarea").val() + '*' + $("#txtDescripcionNota").val() + '*' + $("#txtOpinion").val() + '*' + $("#dtpFechaDiarionNotas").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamDetalleTarea('Guardando diario de notas...');
            },
            success: function (result)
            {
                unblockUIDetalleTarea();
                if (result == '<||>')
                {
                    CargarInformacionDiarioNotas();
                    $("#myModalDiarioNotas").hidden = "hidden";
                    $("#myModalDiarioNotas").modal('toggle');
                }
            }
        });
    }
}
function ValidarDiarioNotasTareas()
{
    $("#errorDescripcionNota").hide();
    $("#errorDescripcionAsteriscos").hide();
    $("#errorOpinionNota").hide();
    $("#errorOpinionNotas").hide();
    $("#errorfechaDiarioNotas").hide();
    var caracteresEspeciales = $("#txtDescripcionNota").val().split('*');
    if ($("#txtDescripcionNota").val() == '') {
        $("#errorDescripcionNota").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorDescripcionAsteriscos").show();
        return false;
    }
    caracteresEspeciales = $("#txtOpinion").val().split('*');
    if ($("#txtOpinion").val() == '') {
        $("#errorOpinionNota").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorOpinionNotas").show();
        return false;
    }
    if ($("#dtpFechaDiarionNotas").val() == '')
    {
        $("#errorfechaDiarioNotas").show();
        return false;
    }
    return true;
}
function GuardarTemasActaReunionTarea()
{
    var guardarRegistro = ValidarTemasActaReunionTarea();
    if (guardarRegistro == true)
    {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarTemaActaReunionTarea: $("#hfidTarea").val() + '*' + $("#txtTemasReuniones").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamDetalleTarea('Guardando temas acta reunión...');
            },
            success: function (result)
            {
                unblockUIDetalleTarea();
                if (result == '<||>')
                {
                    CargarInformacionActasReuniones();
                    $("#myModalTemasReunion").hidden = "hidden";
                    $("#myModalTemasReunion").modal('toggle');
                }
            }
        });
    }
}
function ValidarTemasActaReunionTarea()
{
    $("#errorTemasReuniones").hide();
    $("#errorTemasReunionesAsteriscos").hide();
    var caracteresEspeciales = $("#txtTemasReuniones").val().split('*');
    if ($("#txtTemasReuniones").val() == '')
    {
        $("#errorTemasReuniones").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1)
    {
        $("#errorTemasReunionesAsteriscos").show();
        return false;
    }
    return true;
}
function CargarInformacionDiarioNotas()
{
    $("#btnFinalizarDiarioNotas").hide();
    $("#btnEliminarDiarioNotas").hide();
    $("#btnAgregarNotas").hide();
    $.ajax(
    {
        type: "POST",
        url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { Buscardetalletareadiarionotas: $("#hfidTarea").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParamDetalleTarea('Cargando detalle diario de notas...');
        },
        success: function (result)
        {
            $("#fechaTareaDiarioNotas").html('<span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: ' + $("#hfFechaTarea").val());
            $("#horaTareaDiarioNotas").html('<span class="glyphicon glyphicon-calendar"></span>&nbsp; Hora:' + $("#hfHoraTarea").val());
            if (result.Head.length > 0)
            {
                var datasource = '';
                for (var i = 0; i < result.Head.length; i++)
                {
                    datasource= datasource +
                    '<div class="list-group-item">' +
                        '<div class="col-sm-5">' +
                            '<p class="list-group-item-text">' + result.Head[i].descripcion + '</p>' +
                        '</div>' +
                        '<div class="col-sm-5">' +
                            '<p class="list-group-item-text">' + result.Head[i].reflexion + '</p>' +
                        '</div>' +
                        '<div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>' + result.Head[i].fecha + '</span></div>' +
                     '</div>';
                }
                $("#dtgDiarioNotas").html(datasource);
                if ((result.Head[0].estado == null || result.Head[0].estado == 0) && $("#hfPermisoModificarFormato").val() == "true")
                {
                    $("#btnFinalizarDiarioNotas").show();
                    $("#btnEliminarDiarioNotas").show();
                    $("#btnAgregarNotas").show();
                }
            }
            else
            {
                if ($("#hfPermisoModificarFormato").val() == "true")
                {
                    $("#btnFinalizarDiarioNotas").show();
                    $("#btnEliminarDiarioNotas").show();
                    $("#btnAgregarNotas").show();
                }
                $("#dtgDiarioNotas").html('');
            }
            unblockUIDetalleTarea();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUIDetalleTarea();
        }
    });
}
function CargarInformacionActasReuniones()
{
    $("#btnFinalizarActaReunion").hide();
    $("#btnEliminarActaReunion").hide();
    $("#btnTemas").hide();
    $("#btnAsistentes").hide();
    $("#btnCompromisos").hide();
    $.ajax(
    {
        type: "POST",
        url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { Buscardetalletareaactasreuniones: $("#hfidTarea").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function ()
        {
            waitblockUIParamDetalleTarea('Cargando detalle actas reuniones...');
        },
        success: function (result)
        {
            $("#fechaTareaActaReuniones").html('<span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: ' + $("#hfFechaTarea").val());
            $("#horaTareaActaReuniones").html('<span class="glyphicon glyphicon-calendar"></span>&nbsp; Hora:' + $("#hfHoraTarea").val());
            if (result.Head.length > 0) {
                for (var i = 0; i < result.Head.length; i++)
                {
                    $("#tareaTemasReuniones").html(result.Head[i].Temas);
                    $("#txtTemasReuniones").html(result.Head[i].Temas);
                    if ((result.Head[i].estado == null || result.Head[i].estado == 0) && $("#hfPermisoModificarFormato").val() == "true")
                    {
                        $("#btnFinalizarActaReunion").show();
                        $("#btnEliminarActaReunion").show();
                        $("#btnTemas").show();
                        $("#btnAsistentes").show();
                        $("#btnCompromisos").show();
                    }
                }
            }
            else
            {
                if ($("#hfPermisoModificarFormato").val() == "true")
                {
                    $("#btnFinalizarActaReunion").show();
                    $("#btnEliminarActaReunion").show();
                    $("#btnTemas").show();
                    $("#btnAsistentes").show();
                    $("#btnCompromisos").show();
                }
                $("#txtTemasReuniones").html('');
                $("#tareaTemasReuniones").html('<p></p>');
                $("#inpListadoAsistencia").hide();
                $("#tareaCompromisos").html('');
                $("#tareaAsistentes").html('<p>Documento o imagen</p>');
            }
            CargarListadoAsistencia();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUIDetalleTarea();
        }
    });
}
function CargarListadoAsistencia()
{
    $.ajax(
       {
           type: "POST",
           url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { Buscardetalletareaactareunioneslistadoasistencia: $("#hfidTarea").val() },
           traditional: true,
           cache: false,
           dataType: "text",
           beforeSend: function () {
               waitblockUIParamDetalleTarea('Obteniendo listado de asistencia...');
           },
           success: function (result)
           {
               $("#inpListadoAsistencia").hide();
               if (result != "")
               {
                   $("#inpListadoAsistencia").fileinput({
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
                       initialPreview: [result],
                       initialPreviewAsData: true // identify if you are sending preview data only and not the raw markup
                   });
                   $("#inpListadoAsistencia").show();
               }
               CargarCompromisosActaReunion();
           },
           error: function (XMLHttpRequest, textStatus, errorThrown) {
               alert("error");
               alert(textStatus + ": " + XMLHttpRequest.responseText);
               unblockUIDetalleTarea();
           }
       });
}
function CargarCompromisosActaReunion()
{
    $.ajax(
        {
            type: "POST",
            url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { Buscardetalletareaactasreunionescompromisos: $("#hfidTarea").val() },
            traditional: true,
            cache: false,
            dataType: "json",
            beforeSend: function () {
                waitblockUIParamDetalleTarea('Cargando detalle actas reuniones...');
            },
            success: function (result)
            {
                var dataSource = '';

                for (var i = 0; i < result.Head.length; i++)
                {
                    dataSource= dataSource + 
                    '<div class="list-group-item">'+
                        '<div class="col-sm-5">'+
                            '<p class="list-group-item-text">' + result.Head[i].nombre + '</p>'+
                        '</div>'+
                        '<div class="col-sm-5">'+
                            '<p class="list-group-item-text">' + result.Head[i].responsable + '</p>'+
                        '</div>'+
                        '<div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>' + result.Head[i].fecha + '</span>'+ 
                        '</div>'+
                     '</div>'
                }
                $("#tareaCompromisos").html(dataSource);
                unblockUIDetalleTarea();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
                unblockUIDetalleTarea();
            }
        });
}
function GuardarAsistenciaActaReunion()
{
    if (ValidarRegistroImagenActaReunion() == true) $("#inpListaAsistentes").fileinput("upload")
}
function AgregarNotas()
{
    $("#errordtgDiarioNotas").hide();
    var f = new Date();
    var fechaActual = f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
    CrearModalDiarioNotas('', '', fechaActual);
}
function CrearModalDiarioNotas(descripcion,reflexion,fecha)
{
    $("#myModalDiarioNotas").html(  '<div class="modal-dialog" role="document">' +
                                          '<div class="modal-content">' +
                                            '<div class="modal-header">' +
                                                '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                                                '<h4 class="modal-title" id="myModalLabelDiarioNotas">Nueva nota</h4>' +
                                             '</div>' +
                                             '<div class="modal-body">' +
                                                '<div class="form-group">' +
                                                    '<label for="DescripcionNota" class="control-label">Descripción</label>' +
                                                    '<textarea id="txtDescripcionNota" placeholder="Por ejemplo: Hoy la visita se realizó al lote donde se ha comenzado a construir la estructura del hospital. Se puede ver el material, como cemento, ladrillos, varillas de acero y alrededor de 20 trabajadores todos con implementos de protección. " class="form-control" rows="5" ></textarea>' +
                                                    '<div id="errorDescripcionNota" class="alert alert-danger alert-dismissible" hidden="hidden" >La descripción no puede ser vacía.</div>' +
                                                    '<div id="errorDescripcionAsteriscos" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede contener el caracter *.</div>' +
                                                    '<label for="OpinionNota" class="control-label">Reflexión u opinión</label>' +
                                                    '<textarea id="txtOpinion" placeholder="Por ejemplo: La programación presentada por el contratista en la Audiencia de Inicio en la cual plantea el comienzo de la construcción de cimientos del hospital está al día y se evidencia de manera adecuada.    " class="form-control" rows="5" ></textarea>' +
                                                    '<div id="errorOpinionNota" class="alert alert-danger alert-dismissible" hidden="hidden" >La descripción no puede ser vacía.</div>' +
                                                    '<div id="errorOpinionNotas" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede contener el caracter *.</div>' +
                                                    '<label for="fechaDiarioNotas" class="control-label">Fecha</label>' +
                                                    '<div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fechaDiarioNotas" data-link-format="yyyy-mm-dd">' +
                                                        '<input id="dtpFechaDiarionNotas" class="form-control" size="16" type="text" value="" readonly>' +
                                                        '<span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>' +
                                                        '<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>' +
                                                    '</div>' +
                                                    '<div id="errorfechaDiarioNotas" class="alert alert-danger alert-dismissible" hidden="hidden" >El valor de la fecha no puede ser vacía.</div>' +
                                                    '<input type="hidden" id="fechaDiarioNotas" value="" />' +
                                                 '</div>' +
                                                 '<div class="modal-footer">' +
                                                    '<button id="btnCancelarDiarioNotas" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                                                    '<button id="btnGuardarDiarioNotas" onclick="GuardarDiarioNotasTarea()" type="button" class="btn btn-primary">Guardar</button>' +
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
                                           '</script>' +
                                     '</div>'
                                    );
    $("#txtDescripcionNota").val(descripcion);
    $("#txtOpinion").val(reflexion);
    $('#dtpFechaDiarionNotas').val(fecha);
}
function ValidarRegistroImagenActaReunion()
{
    $("#errorAsistentes").hide();
    if ($("#inpListaAsistentes").val()=='')
    {
        $("#errorAsistentes").show();
        return false;
    }
    return true;
}
function waitblockUIParamDetalleTarea(mensaje) { $.blockUI({ message: "<h2>" + mensaje + "</h2>" }); }
function unblockUIDetalleTarea() { $.unblockUI(); }
function EliminarDetalleTarea()
{
    if (confirm("¿Desea eliminar esta tarea?"))
    {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { EliminarTarea: $("#hfidTarea").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamPlanTrabajo('Eliminando tareas...');
            },
            success: function (result)
            {
                CargarPlanesTrabajo();
                volverPlanTrabajo();
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
}
function EliminarDiarioNotasTarea() {
    if (confirm("¿Desea eliminar esta tarea?")) {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { EliminarDiarioNotasTarea: $("#hfidTarea").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamPlanTrabajo('Eliminando tareas...');
            },
            success: function (result)
            {
                CargarPlanesTrabajo();
                volverPlanTrabajo();
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
}
function FinalizarDetalleTarea() {
    if (confirm("¿Desea finalizar esta tarea?"))
    {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { FinalizarTarea: $("#hfidTarea").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamPlanTrabajo('Finalizar tareas...');
            },
            success: function (result)
            {
                alert("La tarea se finalizó con éxito.");
                unblockUI();
                CargarInformacionActasReuniones();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
}

function FinalizarDiarioNotasTarea()
{
    if (confirm("¿Desea finalizar esta tarea?"))
    {
        var finalizarDiarioNotasTarea = ValidarFinalizarDiarioNotas();
        if (finalizarDiarioNotasTarea == true) {
            $.ajax({
                type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { FinalizarTarea: $("#hfidTarea").val() }, traditional: true,
                beforeSend: function () {
                    waitblockUIParamPlanTrabajo('Finalizar tareas...');
                },
                success: function (result) {
                    alert("La tarea se finalizó con éxito.");
                    unblockUI();
                    CargarInformacionDiarioNotas();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("error");
                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                }
            });
        }
        else alert("No fue posible finalizar la tarea.\nPor favor revise los mensajes de error señalados en rojo que aparecen en el formato.");
    }
}
function ValidarFinalizarDiarioNotas()
{
    $("#errordtgDiarioNotas").hide();
    if ($("#dtgDiarioNotas").html() == "")
    {
        $("#errordtgDiarioNotas").show();
        return false;
    }
    return true;
}