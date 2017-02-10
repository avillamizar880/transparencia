function MostrarDetallePlanTrabajo()
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
                $("#tareaVisitaCampo").show();
                break;
            case "REGISTRO FOTOGRÁFICO":
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
function CargarInformacionActasReuniones()
{
    $("#btnFinalizarActaReunion").hide();
    $("#btnEliminarActaReunion").hide();
    if ($("#hfPermisoModificarFormato").val() == "true")
    {
        $("#btnFinalizarActaReunion").show();
        $("#btnEliminarActaReunion").show();
    }
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
                    $("#tareaTemasReuniones").html(result.Head[0].Temas);
                    $("#txtTemasReuniones").html(result.Head[0].Temas);
                }
            }
            else
            {
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
                volverPlanTrabajo();
                //if (result == '<||>')
                //{
                //    cargaMenu('VerificacionAnalisis/PlanTrabajo', 'dvPrincipal');
                //}
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
}
