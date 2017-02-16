function MostrarDetallePlanTrabajo()
{
    if ($("#hfTitulo").val() != null)
    {
        $("#tareaActaReuniones").hide();
        $("#tareaDiarioNotas").hide();
        $("#tareaVisitaCampo").hide();
        $("#tareaRegistroFotograficoProyecto").hide();
        switch ($("#hfTitulo").val().toUpperCase().trim())
        {
            case "VISITA DE CAMPO":
                $("#tareaVisitaCampo").show();
                CargarInformacionVisitaCampoTarea();
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
                $("#tareaRegistroFotograficoProyecto").show();
                CargarInformacionDetalleTareaRecursosFotografico();
                break;
        }
    }
}
function CargarInformacionDetalleTareaRecursosFotografico()
{
    $("#btnFinalizarRegistroFotografico").hide();
    $("#btnEliminarRegistroFotografico").hide();
    $("#btnAgregarRegistroFotografico").hide();
    $.ajax(
    {
        type: "POST",
        url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { Buscardetalletarearegistrofotografico: $("#hfidTarea").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParamDetalleTarea('Cargando registro fotográfico...');
        },
        success: function (result) {
            $("#fechaRegistroFotografico").html('<span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: ' + $("#hfFechaTarea").val());
            $("#horaRegistroFotografico").html('<span class="glyphicon glyphicon-calendar"></span>&nbsp; Hora:' + $("#hfHoraTarea").val());
            if (result.Head.length > 0) {
                var datasource = '';
                for (var i = 0; i < result.Head.length; i++)
                {
                    datasource = datasource +
                                            '<img class="card-img-top" src=' + result.Head[i].url + ' width="200" align="middle" alt="Registro">' +
                                            '<div class="card-block">'+
                                                '<ul class="list-group">'+
                                                '<li class="list-group-item"><p class="card-text">'+ result.Head[i].descripcion + '</p></li>'+
                                                '<li class="list-group-item"><span class="glyphicon glyphicon-user"></span>&nbsp; Reportado por:'+ result.Head[i].responsable+ '</li>'+
                                                '<li class="list-group-item"><span class="glyphicon glyphicon-map-marker"></span>&nbsp; Lugar:' + result.Head[i].lugar + '</li>' +
                                                '<li class="list-group-item"><span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha:'+ result.Head[i].fechaCreacion+  '</li>'+
                                                '</ul>'+
                                             '</div>';
                }
                $("#lstRecursosFotograficosTarea").html(datasource);
                if ((result.Head[0].estado == null || result.Head[0].estado == 0) && $("#hfPermisoModificarFormato").val() == "true")
                {
                    $("#btnFinalizarRegistroFotografico").show();
                    $("#btnEliminarRegistroFotografico").show();
                    $("#btnAgregarRegistroFotografico").show();
                }
            }
            else {
                if ($("#hfPermisoModificarFormato").val() == "true") {
                    $("#btnFinalizarRegistroFotografico").show();
                    $("#btnEliminarRegistroFotografico").show();
                    $("#btnAgregarRegistroFotografico").show();
                }
                $("#lstRecursosFotograficosTarea").html('');
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
function GuardarCompromisoTarea()
{
    var guardarRegistro = ValidarCompromisoTareaGuardar();
    if (guardarRegistro == true)
    {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarCompromisoActaReunionTarea: $("#hfidTarea").val() + '*' + $("#txtCompromiso").val() + '*' + $("#txtResponsable").val() + '*' + $("#fechaCompromisos").val() }, traditional: true,
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
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarDiarioNotasTarea: $("#hfidTarea").val() + '*' + $("#txtDescripcionNota").val() + '*' + $("#txtOpinion").val() + '*' + $("#fechaDiarioNotas").val() }, traditional: true,
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
        $("#errortareaTemasReuniones").hide();//Se oculta el validador de error para finalizar tarea
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
                       overwriteInitial: false,
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
    $('#fechaDiarioNotas').val(fecha);
}
function ValidarRegistroImagenActaReunion()
{
    $("#errorAsistentes").hide();
    $("#errortareaAsistentes").hide();
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
        var finalizarActaReunionesTarea = ValidarFinalizarActaReunionesTarea();
        if (finalizarActaReunionesTarea==true)
        {
            $.ajax({
                type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { FinalizarTarea: $("#hfidTarea").val() }, traditional: true,
                beforeSend: function () {
                    waitblockUIParamPlanTrabajo('Finalizar tareas...');
                },
                success: function (result) {
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
        else alert("No fue posible finalizar la tarea.\nPor favor revise los mensajes de error señalados en rojo que aparecen en el formato.");
    }
}
function ValidarFinalizarActaReunionesTarea() {
    $("#errortareaAsistentes").hide();
    $("#errortareaTemasReuniones").hide();
    if ($("#tareaTemasReuniones").html() == "<p></p>")
    {
        $("#errortareaTemasReuniones").show();
        return false;
    }
    if ($("#inpListadoAsistencia").length==0)
    {
        $("#errortareaAsistentes").show();
        return false;
    }
    return true;
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
function AgregarCompromisos()
{
    var f = new Date();
    var fechaActual = f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
    CrearModalCompromisos('', '', fechaActual);
}
function CrearModalCompromisos(compromiso, responsable, fecha)
{
    $("#myModalCompromisos").html('<div class="modal-dialog" role="document">'+
                                        '<div class="modal-content">'+
                                            '<div class="modal-header">'+
                                                '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>'+
                                                '<h4 class="modal-title" id="myModalLabelCompromisos">Nuevo Compromiso</h4>'+
                                            '</div>'+
                                            '<div class="modal-body">'+
                                                '<div class="form-group">'+
                                                    '<label for="lblcompromisos" class="control-label">Compromiso</label>'+
                                                    '<div id="errorCompromisosActa" class="alert alert-danger alert-dismissible" hidden="hidden" >El compromiso no puede ser vacío.</div>'+
                                                    '<div id="errorCompromisosActaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">La descripción del compromiso no puede contener el caracter *.</div>'+
                                                    '<textarea id="txtCompromiso" placeholder="Por favor describa el compromiso aquí... " class="form-control" rows="5" ></textarea>'+            
                                                    '<label for="lblResponsable" class="control-label">Responsables</label>'+    
                                                    '<div id="errorResponsable" class="alert alert-danger alert-dismissible" hidden="hidden" >El responsable no puede ser vacío.</div>'+
                                                    '<div id="errorResponsableAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre del responsable no puede contener el caracter *.</div>'+
                                                    '<textarea id="txtResponsable" placeholder="Por favor escriba los responsables aquí... " class="form-control" rows="5" ></textarea>'+
                                                    '<label for="fechaCompromisos" class="control-label">Fecha de cumplimiento</label>'+
                                                    '<div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fechaCompromisos" data-link-format="yyyy-mm-dd">'+
                                                        '<input id="dtpFechaCumplimiento" class="form-control" size="16" type="text" value="" readonly>'+
                                                        '<span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>'+
                                                        '<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>'+
                                                    '</div>'+
                                                    '<div id="errorFechaCumplimiento" class="alert alert-danger alert-dismissible" hidden="hidden" >La fecha no puede ser vacío.</div>'+
                                                    '<input type="hidden" id="fechaCompromisos" value="" />'+
                                                 '</div>'+
                                                 '<div class="modal-footer">'+
                                                 '<button id="btnCancelarCompromisos" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>'+
                                                 '<button id="btnGuardarCompromisos" onclick="GuardarCompromisoTarea()" type="button" class="btn btn-primary">Guardar</button>'+
                                            '</div>'+
                                       '</div>'+
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
                                   '</script>'+
                            '</div>');
    $("#txtCompromiso").val(compromiso);
    $("#txtResponsable").val(responsable);
    $('#dtpFechaCumplimiento').val(fecha);
    $('#fechaCompromisos').val(fecha);
}
function AgregarRegistroFotografico()
{
    var f = new Date();
    var fechaActual = f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
    CrearModalRegistroFotografico('','', '', fechaActual);
}
function CrearModalRegistroFotografico(descripcion,lugar,responsable,fecha)
{
    $("#myModalAgregarRegistro").html('<div class="modal-dialog" role="document">' +
                                        '<div class="modal-content">'+
                                            '<div class="modal-header">'+
                                                '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>'+
                                                '<h4 class="modal-title" id="myModalLabelRecursoTarea">Nueva Descripción</h4>'+
                                            '</div>'+
                                            '<div class="modal-body">'+
                                                '<div class="form-group">'+
                                                    '<label class="modal-title">Agregar Recurso</label><br/>'+
                                                    '<input id="inpRecursoTarea" class="file-loading" type="file">'+
                                                    '<div id="errorRecursoTareaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre del recurso no puede ser vacío.</div>'+
                                                    '<label for="fechaposteriorRegFoto" class="control-label">Fecha</label>' +
                                                    '<div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fechaposteriorRegFoto" data-link-format="yyyy-mm-dd">' +
                                                        '<input id="dtpFechaRecursoMultimedia" class="form-control" size="16" type="text" value="" readonly>'+
                                                        '<span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>'+
                                                        '<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>'+
                                                    '</div>'+
                                                    '<input type="hidden" id="fechaposteriorRegFoto" value="" />'+
                                                    '<div id="errorFechaRecursoMultimedia" class="alert alert-danger alert-dismissible" hidden="hidden" >La fecha de la descripción no puede ser vacía.</div>'+
                                                    '<label class="modal-title">Descripción</label><br/>'+
                                                    '<textarea id="txtDescripcionRecursoMultimedia" placeholder="Describa el recurso que desea ingresar" class="form-control" rows="5"></textarea>'+
                                                    '<div id="errorDescripcionRecursoMultimedia" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede ser vacío.</div>'+
                                                    '<div id="errorDescripcionRecursoMultimediaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede contener el caracter *.</div>'+
                                                    '<label class="modal-title">Lugar</label><br/>'+
                                                    '<input type="text" id="txtLugar" placeholder="Escriba el lugar donde fue tomada la fotografía..." class="form-control" />'+
                                                    '<div id="errorLugar" class="alert alert-danger alert-dismissible" hidden="hidden">El lugar no puede ser vacío.</div>'+
                                                    '<div id="errorLugarAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El lugar no puede contener el caracter *.</div>'+
                                                    '<label class="modal-title">Responsable</label><br/>'+
                                                    '<input type="text" id="txtResponsable" placeholder="Escriba el responsable que toma la fotografía..." class="form-control" />'+
                                                    '<div id="errorResponsable" class="alert alert-danger alert-dismissible" hidden="hidden">El lugar no puede ser vacío.</div>'+
                                                    '<div id="errorResponsableAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El lugar no puede contener el caracter *.</div>'+
                                                '</div>'+
                                           '</div>'+
                                           '<div class="modal-footer">'+
                                                '<button id="btnCancelarRecursoFotografico" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>'+
                                                '<button id="btnGuardarRecursoFotografico" onclick="GuardarRegistroRecursoFotograficoTarea()" type="button" class="btn btn-primary">Guardar</button>' +
                                           '</div>'+
                                        '</div>'+
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
                                                '$("#inpRecursoTarea").fileinput({'+
                                                                                    'uploadUrl: "../../Views/VerificacionAnalisis/DetallePlanTrabajoRecursoMultimedia_ajax",'+
                                                                                    'showUpload: false,'+
                                                                                    'maxFileCount: 1,'+
                                                                                    'showCaption: false,'+
                                                                                    'allowedFileExtensions: ["jpg", "png", "gif", "bmp"],'+
                                                                                    'maxFileCount: 1,'+
                                                                                    'browseLabel: "Subir Recurso",'+
                                                                                    'showDrag: false,'+
                                                                                    'dropZoneEnabled: false,'+
                                                                                    '}).on("filepreupload", function (event, data, previewId, index, jqXHR) {'+
                                                                                    //'var rutaImagen = $("#inpRecursoTarea").val().split("\\");'+
                                                                                    'data.form.append("idTarea", $("#hfidTarea").val());'+
                                                                                    'data.form.append("url",  $("#inpRecursoTarea").val());' +
                                                                                    'data.form.append("fecha", $("#fechaposteriorRegFoto").val());' +
                                                                                    'data.form.append("DescripcionRecursoMultimedia", $("#txtDescripcionRecursoMultimedia").val());' +
                                                                                    'data.form.append("lugar", $("#txtLugar").val());' +
                                                                                    'data.form.append("responsable", $("#txtResponsable").val());' +
                                                                                    '}).on("fileuploaded", function (event, data, id, index) {'+
                                                                                    'CargarInformacionDetalleTareaRecursosFotografico();'+
                                                                                    '$("#myModalAgregarRegistro").hidden = "hidden";'+
                                                                                    '$("#myModalAgregarRegistro").modal("toggle");'+
                                                                                    '});'+
                                     '</script>'+
                                     '</div>');
    $("#txtResponsable").val(responsable);
    $("#txtLugar").val(lugar);
    $('#dtpFechaRecursoMultimedia').val(fecha);
    $('#fechaposteriorRegFoto').val(fecha);
    $('#txtDescripcionRecursoMultimedia').val(descripcion);
}
function GuardarRegistroRecursoFotograficoTarea()
{
    if (ValidarGuardarRecursoMultimediaTarea() == true) $("#inpRecursoTarea").fileinput("upload");
    else alert("No fue posible guardar el registro fotográfico.\nPor favor revise los mensajes de error señalados en rojo que aparecen en el formato.");
}
function ValidarGuardarRecursoMultimediaTarea()
{
    $("#errorRecursoTareaAsterisco").hide();
    $("#errorFechaRecursoMultimedia").hide();
    $("#errorDescripcionRecursoMultimedia").hide();
    $("#errorDescripcionRecursoMultimediaAsterisco").hide();
    $("#errorLugar").hide();
    $("#errorLugarAsterisco").hide();
    $("#errorResponsable").hide();
    $("#errorResponsableAsterisco").hide();

    var caracteresEspeciales = $("#txtResponsable").val().split('*');
    if ($("#txtResponsable").val() == '') {
        $("#errorResponsable").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorResponsableAsterisco").show();
        return false;
    }
    caracteresEspeciales = $("#txtLugar").val().split('*');
    if ($("#txtLugar").val() == '') {
        $("#errorLugar").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorLugarAsterisco").show();
        return false;
    }
    caracteresEspeciales = $("#txtDescripcionRecursoMultimedia").val().split('*');
    if ($("#txtDescripcionRecursoMultimedia").val() == '') {
        $("#errorDescripcionRecursoMultimedia").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorDescripcionRecursoMultimediaAsterisco").show();
        return false;
    }
    if ($("#dtpFechaRecursoMultimedia").val() == '') {
        $("#errorFechaRecursoMultimedia").show();
        return false;
    }
    if ($("#inpRecursoTarea").val() == '')
    {
        $("#errorRecursoTareaAsterisco").show();
        return false;
    }
    return true;
}
function FinalizarTareaRegistroFotografico()
{
    if (confirm("¿Desea finalizar esta tarea?"))
    {
        if (ValidarFinalizarTareaRegistroFotografico() == true)
        {
            $.ajax({
                type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { FinalizarTarea: $("#hfidTarea").val() }, traditional: true,
                beforeSend: function () {
                    waitblockUIParamPlanTrabajo('Finalizar tareas...');
                },
                success: function (result) {
                    alert("La tarea se finalizó con éxito.");
                    unblockUI();
                    CargarInformacionDetalleTareaRecursosFotografico();
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
function ValidarFinalizarTareaRegistroFotografico() {
    $("#errorRecursosFotograficosTarea").hide();
    if ($("#lstRecursosFotograficosTarea").html() == '') {
        $("#errorRecursosFotograficosTarea").show();
        return false;
    }
    return true;
}
function EliminarTareaRegistroFotografico()
{
    if (confirm("¿Desea eliminar esta tarea?")) {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { EliminarTareaRegistroFotografico: $("#hfidTarea").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamPlanTrabajo('Eliminando tareas...');
            },
            success: function (result) {
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
function GuardarFuncionarioAcompanaVisitaTarea()
{
    if (ValidarFuncionarioAcompanaVisitaTarea() == true)
    {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarFuncionarioPublicoAcompanoVisitaTarea: $("#hfidTarea").val() + '*' + $("#txtFuncionarioAcompanaVisita").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamDetalleTarea('Guardando funcionario público acompañó visita...');
            },
            success: function (result) {
                unblockUIDetalleTarea();
                if (result == '<||>') {
                    CargarInformacionVisitaCampoTarea();
                    $("#myModalNombreCargo").hidden = "hidden";
                    $("#myModalNombreCargo").modal('toggle');
                }
            }
        });
    }
}
function ValidarFuncionarioAcompanaVisitaTarea() {
    $("#errorFuncionarioAcompanaVisita").hide();
    $("#errorFuncionarioAcompanaVisitaAsterisco").hide();
    var caracteresEspeciales = $("#txtFuncionarioAcompanaVisita").val().split('*');
    if ($("#txtFuncionarioAcompanaVisita").val() == '') {
        $("#errorFuncionarioAcompanaVisita").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorFuncionarioAcompanaVisitaAsterisco").show();
        return false;
    }
    return true;
}
function CargarInformacionVisitaCampoTarea() {
    $("#btnFinalizarVisitaCampo").hide();
    $("#btnEliminarVisitaCampo").hide();
    $("#btnAgregarCargoFuncionarioVisita").hide();
    $("#btnAgregarActividadesVisitaCampo").hide();
    $("#btnAgregarObservacionesRegistroFotografico").hide();
    $("#errordtgListadoRegistroFotograficoVisitaCampo").hide();
    $("#errorFuncionarioAcompanaVisitaCampo").hide();
    $("#errorActividadesVisitaCampo").hide();
    $.ajax(
    {
        type: "POST",
        url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { BuscarInformacionVisitaCampo: $("#hfidTarea").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParamDetalleTarea('Cargando visita de campo...');
        },
        success: function (result) {
            $("#fechaVisitaCampo").html('<span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: ' + $("#hfFechaTarea").val());
            $("#horaVisitaCampo").html('<span class="glyphicon glyphicon-calendar"></span>&nbsp; Hora:' + $("#hfHoraTarea").val());
            if (result.Head.length > 0) {
                for (var i = 0; i < result.Head.length; i++)
                {
                    if (result.Head[i].funcionarioAcompanaVisita !=null) $("#txtFuncionarioAcompanaVisitaCampo").html("<p>" + result.Head[i].funcionarioAcompanaVisita + "</p>");
                    if (result.Head[i].actividadesVisitaCampo != null) $("#txtActividadesVisitaCampo").html("<p>" + result.Head[i].actividadesVisitaCampo + "</p>");
                }
                if ((result.Head[0].estado == null || result.Head[0].estado == 0) && $("#hfPermisoModificarFormato").val() == "true") {
                    $("#btnFinalizarVisitaCampo").show();
                    $("#btnEliminarVisitaCampo").show();
                    $("#btnAgregarCargoFuncionarioVisita").show();
                    $("#btnAgregarActividadesVisitaCampo").show();
                    $("#btnAgregarObservacionesRegistroFotografico").show();
                }
            }
            else
            {
                if ($("#hfPermisoModificarFormato").val() == "true") {
                    $("#btnFinalizarVisitaCampo").show();
                    $("#btnEliminarVisitaCampo").show();
                    $("#btnAgregarCargoFuncionarioVisita").show();
                    $("#btnAgregarActividadesVisitaCampo").show();
                    $("#btnAgregarObservacionesRegistroFotografico").show();
                }
                $("#txtFuncionarioAcompanaVisitaCampo").html("");
                $("#txtActividadesVisitaCampo").html("");
            }
            CargarRecursosFotograficoVisitaCampoTarea();
            //unblockUIDetalleTarea();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUIDetalleTarea();
        }
    });
}
function CargarRecursosFotograficoVisitaCampoTarea() {
    $("#btnFinalizarRegistroFotografico").hide();
    $("#btnEliminarRegistroFotografico").hide();
    $("#btnAgregarRegistroFotografico").hide();
    $.ajax(
    {
        type: "POST",
        url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { Buscardetalletarearegistrofotograficovisitacampo: $("#hfidTarea").val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParamDetalleTarea('Cargando registro fotográfico visita campo...');
        },
        success: function (result) {
            if (result.Head.length > 0) {
                var datasource = '';
                for (var i = 0; i < result.Head.length; i++) {
                    datasource = datasource +
                                                '<div class="col-sm-6">' +
                                                   '<p>' + result.Head[i].descripcion + '</p>' +
                                                 '</div>' +
                                                  '<div class="col-sm-6">' +
                                                    '<div class="row">' +
                                                       '<div class="card">' +
                                                           '<img class="card-img-top" src="' + result.Head[i].url + '" width="200" align="middle">' +
                                                               '<div class="card-block"></div>' +
                                                       '</div>' +
                                                    '</div>' +
                                                  '</div>' +
                                                 '</div>';

                }
                $("#dtgListadoRegistroFotograficoVisitaCampo").html(datasource);
                if ((result.Head[0].estado == null || result.Head[0].estado == 0) && $("#hfPermisoModificarFormato").val() == "true") {
                    $("#btnFinalizarRegistroFotografico").show();
                    $("#btnEliminarRegistroFotografico").show();
                    $("#btnAgregarRegistroFotografico").show();
                }
            }
            else {
                if ($("#hfPermisoModificarFormato").val() == "true") {
                    $("#btnFinalizarRegistroFotografico").show();
                    $("#btnEliminarRegistroFotografico").show();
                    $("#btnAgregarRegistroFotografico").show();
                }
                $("#dtgListadoRegistroFotograficoVisitaCampo").html('');
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
function GuardarFuncionarioAcompanaVisitaTarea() {
    if (ValidarFuncionarioAcompanaVisitaTarea() == true) {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarFuncionarioPublicoAcompanoVisitaTarea: $("#hfidTarea").val() + '*' + $("#txtFuncionarioAcompanaVisita").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamDetalleTarea('Guardando funcionario público acompañó visita...');
            },
            success: function (result) {
                unblockUIDetalleTarea();
                if (result == '<||>') {
                    CargarInformacionVisitaCampoTarea();
                    $("#myModalNombreCargo").hidden = "hidden";
                    $("#myModalNombreCargo").modal('toggle');
                }
            }
        });
    }
}
function ValidarFuncionarioAcompanaVisitaTarea() {
    $("#errorFuncionarioAcompanaVisita").hide();
    $("#errorFuncionarioAcompanaVisitaAsterisco").hide();
    var caracteresEspeciales = $("#txtFuncionarioAcompanaVisita").val().split('*');
    if ($("#txtFuncionarioAcompanaVisita").val() == '') {
        $("#errorFuncionarioAcompanaVisita").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorFuncionarioAcompanaVisitaAsterisco").show();
        return false;
    }
    return true;
}
function GuardarActividadesVisitaCampoTarea() {
    if (ValidarActividadesVisitaCampoTarea() == true) {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarActividadesVisitaCampoTarea: $("#hfidTarea").val() + '*' + $("#txtActividades").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamDetalleTarea('Guardando actividades visita campo...');
            },
            success: function (result) {
                unblockUIDetalleTarea();
                if (result == '<||>') {
                    CargarInformacionVisitaCampoTarea();
                    $("#myModalActividadesVisita").hidden = "hidden";
                    $("#myModalActividadesVisita").modal('toggle');
                }
            }
        });
    }
}
function ValidarActividadesVisitaCampoTarea() {
    $("#errorActividades").hide();
    $("#errorActividadesAsteriscos").hide();
    var caracteresEspeciales = $("#txtActividades").val().split('*');
    if ($("#txtActividades").val() == '') {
        $("#errorActividades").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorActividadesAsteriscos").show();
        return false;
    }
    return true;
}
function EliminarVisitaCampoTarea()
{
    if (confirm("¿Desea eliminar esta tarea?")) {
        $.ajax({
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { EliminarTareaRegistroFotografico: $("#hfidTarea").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamPlanTrabajo('Eliminando tareas...');
            },
            success: function (result) {
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
function AgregarRegistroFotograficoVisitaCampo()
{
    CrearModalRegistroFotograficoVisitaCampo('');
}
function CrearModalRegistroFotograficoVisitaCampo(observacion)
{
    $("#mymodalObservacionesFotos").html('<div class="modal-dialog" role="document">' +
                                        '<div class="modal-content">'+
                                            '<div class="modal-header">'+
                                              '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>'+
                                              '<h4 class="modal-title" id="myModalLabelObservacionesFotos">Agregar Observaciones y registro fotográfico</h4>'+
                                            '</div>'+
                                            '<div class="modal-body">'+
                                                '<div class="form-group">'+
                                                    '<label for="ObservacionesFotos" class="control-label">Observaciones</label>'+
                                                    '<div id="errorObservacionesFotos" class="alert alert-danger alert-dismissible" hidden="hidden" >Este campo no puede estar vacío.</div>'+
                                                    '<div id="errorObservacionesFotosAsteriscos" class="alert alert-danger alert-dismissible" hidden="hidden">Las observaciones no pueden contener el caracter *.</div>'+
                                                    '<textarea id="txtObservacionesFotos" placeholder="Por ejemplo: Revisión de calidad de materiales con el interventor" class="form-control" rows="5" ></textarea>'+            
                                                '</div>'+
                                                '<label class="modal-title">Agregar Recurso</label><br/>'+
                                                '<input id="inpsubirFoto" class="file-loading" type="file">'+
                                                '<div id="errorRecursoMultimediaVisitaTarea" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre del recurso no puede ser vacío.</div>'+
                                                  '<div class="modal-footer">'+
                                                    '<button id="btnCancelarObservacionesFotos" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>'+
                                                    '<button id="btnGuardarObservacionesFotos" onclick="GuardarRegistroFotograficoVisitaCampo()" type="button" class="btn btn-primary">Guardar</button>' +
                                                  '</div>'+
                                                '</div>'+
                                             '</div>'+
                                        '</div>'+
                                        '<script type="text/javascript">'+
                                                      '$("#inpsubirFoto").fileinput({' +
                                                                                    'uploadUrl: "../../Views/VerificacionAnalisis/DetallePlanTrabajoRecursoMultimediaVisitaCampo_ajax",'+
                                                                                    'showUpload: false,'+
                                                                                    'maxFileCount: 1,'+
                                                                                    'showCaption: false,'+
                                                                                    'allowedFileExtensions: ["jpg", "png", "gif", "bmp"],'+
                                                                                    'maxFileCount: 1,'+
                                                                                    'browseLabel: "Subir Recurso",'+
                                                                                    'showDrag: false,'+
                                                                                    'dropZoneEnabled: false,'+
                                                                                    '}).on("filepreupload", function (event, data, previewId, index, jqXHR) {'+
                                                                                    'data.form.append("idTarea", $("#hfidTarea").val());'+
                                                                                    'data.form.append("url",  $("#inpsubirFoto").val());' +
                                                                                    'data.form.append("DescripcionRecursoMultimedia", $("#txtObservacionesFotos").val());' +
                                                                                    '}).on("fileuploaded", function (event, data, id, index) {'+
                                                                                    'CargarInformacionVisitaCampoTarea();' +
                                                                                    '$("#mymodalObservacionesFotos").hidden = "hidden";' +
                                                                                    '$("#mymodalObservacionesFotos").modal("toggle");' +
                                                                                    '});'+
                                     '</script>'+
                                     '</div>');
}
function GuardarRegistroFotograficoVisitaCampo()
{
    if (ValidarGuardarRegistroFotograficoVisitaCampo() == true) $("#inpsubirFoto").fileinput("upload");
    else alert("No fue posible guardar el registro fotográfico.\nPor favor revise los mensajes de error señalados en rojo que aparecen en el formato.");
}
function FinalizarVisitaCampoTarea()
{
    if (confirm("¿Desea finalizar esta tarea?"))
    {
        if (ValidarFinalizarVisitaCampoTarea() == true)
        {
            $.ajax({
                type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { FinalizarTarea: $("#hfidTarea").val() }, traditional: true,
                beforeSend: function () {
                    waitblockUIParamPlanTrabajo('Finalizar tareas...');
                },
                success: function (result) {
                    alert("La tarea se finalizó con éxito.");
                    unblockUI();
                    CargarInformacionVisitaCampoTarea();
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
function ValidarFinalizarVisitaCampoTarea() {
    $("#errordtgListadoRegistroFotograficoVisitaCampo").hide();
    $("#errorFuncionarioAcompanaVisitaCampo").hide();
    $("#errorActividadesVisitaCampo").hide();
    if ($("#dtgListadoRegistroFotograficoVisitaCampo").html() == '') {
        $("#errordtgListadoRegistroFotograficoVisitaCampo").show();
        return false;
    }
    if ($("#txtActividadesVisitaCampo").html() == '') {
        $("#errorActividadesVisitaCampo").show();
        return false;
    }
    if ($("#txtFuncionarioAcompanaVisitaCampo").html() == '') {
        $("#errorFuncionarioAcompanaVisitaCampo").show();
        return false;
    }
    return true;
}
function ValidarGuardarRegistroFotograficoVisitaCampo() {
    $("#errorObservacionesFotos").hide();
    $("#errorObservacionesFotosAsteriscos").hide();
    $("#errorRecursoMultimediaVisitaTarea").hide();
    var caracteresEspeciales = $("#txtObservacionesFotos").val().split('*');
    if ($("#txtObservacionesFotos").val() == '') {
        $("#errorObservacionesFotos").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorObservacionesFotosAsteriscos").show();
        return false;
    }
    if ($("#inpsubirFoto").val() == '') {
        $("#errorRecursoMultimediaVisitaTarea").show();
        return false;
    }
    return true;
}
