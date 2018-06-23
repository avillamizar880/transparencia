﻿function MostrarDetallePlanTrabajo()
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
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarCompromisoActaReunionTarea: $("#hfidTarea").val() + '*' + $("#txtCompromiso").val() + '*' + $("#txtResponsable").val() + '*' + $("#fechaCompromisos").val() + '*' + $("#hfidCompromisosActaReuniones").val() }, traditional: true,
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
            type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { GuardarDiarioNotasTarea: $("#hfidTarea").val() + '*' + $("#txtDescripcionNota").val() + '*' + $("#txtOpinion").val() + '*' + $("#fechaDiarioNotas").val() + '*' + $("#hfidDiarioNotas").val() }, traditional: true,
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
                        '<div class="col-sm-4">' +
                            '<p class="list-group-item-text">' + result.Head[i].reflexion + '</p>' +
                        '</div>' +
                        '<div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>' + result.Head[i].fecha + '</span></div>' +
                        '<div class="col-sm-1"><a data-toggle="modal" data-target="#myModalDiarioNotas" role="button" title="Esta opción le permitirá editar una nota." onclick="EditarInformacionDiarioNotas(' + result.Head[i].diarioNotasTareaId + ",\'" + result.Head[i].descripcion + "\',\'" + result.Head[i].reflexion + "\',\'" + result.Head[i].fecha + '\');"><span class="glyphicon glyphicon-edit"></span></a><a role="button" title="Esta opción le permitirá eliminar una nota." onclick="EliminarInformacionDiarioNotas(' + result.Head[i].diarioNotasTareaId + ');"><span class="glyphicon glyphicon-trash"></span></a></div>' +
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
function EliminarInformacionDiarioNotas(idDiarioNotas) {
    var params = {
        id_DiarioNotasTarea: idDiarioNotas,
    };
    bootbox.confirm({
        title: "Confirmar Eliminación",
        message: "Esta seguro de eliminar el registro del diario de notas?",
        buttons: {
            confirm: {
                label: 'Eliminar'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                $.ajax({
                    type: "POST",
                    url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { EliminarRegistroDiarioNotasTarea: params.id_DiarioNotasTarea },
                    traditional: true,
                    cache: false,
                    //dataType: "json",
                    beforeSend: function () {
                        waitblockUIParam('Eliminando registro Diario de notas ...');
                    },
                    success: function (result) {
                        CargarInformacionDiarioNotas();
                        unblockUI();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("error");
                        alert(textStatus + ": " + XMLHttpRequest.responseText);
                    }

                });
            }
        }
    });
}
function EditarInformacionDiarioNotas(idDiarioNotas,descripcion,reflexion,fechaDiarioNoticias)
{
    $("#errordtgDiarioNotas").hide();
    CrearModalDiarioNotas(descripcion, reflexion, fechaDiarioNoticias, idDiarioNotas);
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
                   var archivosMostrar = new Array();
                   var titulosMostrar = new Array();
                   archivosMostrar = result.split("*_*");
                   for (var j = 0; j < archivosMostrar.length; j++)
                   {
                       var nombreImagen=archivosMostrar[j].split("/");
                       titulosMostrar.push({ caption: nombreImagen[nombreImagen.length - 1], width: "100 px", url: "/site/file-delete", key: j })
                   }
                   $("#inpListadoAsistencia").fileinput({
                                                        theme: 'fa',
                                                        language:'es',
                                                        uploadUrl: "../../Adjuntos/Tareas/ActaReunion/",
                                                        uploadAsync: false,
                                                        minFileCount: 2,
                                                        maxFileCount: 5,
                                                        overwriteInitial: false,
                                                        initialPreview: archivosMostrar,
                                                        initialPreviewAsData: true, // identify if you are sending preview data only and not the raw markup
                                                        initialPreviewFileType: 'object', // image is the default and can be overridden in config below
                                                        allowedFileExtensions: ['jpg', 'png', 'pdf'],
                                                        browseLabel: "Subir Asistencia",
                                                        initialPreviewConfig: archivosMostrar,
                                                        //initialPreviewConfig: [
                                                        //    {caption: "People-1.jpg", size: 576237, width: "120px", url: "/site/file-delete", key: 1},
                                                        //    {caption: "People-2.jpg", size: 932882, width: "120px", url: "/site/file-delete", key: 2}, 
                                                        //],
                                                        //uploadExtraData: {
                                                        //    img_key: "1000",
                                                        //    img_keywords: "happy, places",
                                                        //}
                                                    }).on('filesorted', function(e, params) {
                                                        console.log('file sorted', e, params);
                                                    }).on('fileuploaded', function(e, params) {
                                                        console.log('file uploaded', e, params);
                                                    });


                   //$("#inpListadoAsistencia").fileinput({
                   //    language: 'es',
                   //    uploadAsync: false,
                   //    minFileCount: 2,
                   //    maxFileCount: 5,
                   //    overwriteInitial: false,
                   //    initialPreview: [
                   //                    "../../Adjuntos/Tareas/ActaReunion/2018616213224_144_pp.jpg",
                   //                     "../../Adjuntos/Tareas/ActaReunion/2018616213357_144_1.png",
                   //                     "../../Adjuntos/Tareas/ActaReunion/2018616214234_144_IMG_20170607_082245 - copia.jpg",
                   //                     "../../Adjuntos/Tareas/ActaReunion/2018616215016_144_IMG_20170707_074151 - copia.jpg",
                   //                     "../../Adjuntos/Tareas/ActaReunion/2018616215246_144_IMG_20170707_074156 - copia.jpg",
                   //                     "../../Adjuntos/Tareas/ActaReunion/201861623137_144_20170708_164410.jpg"
                   //                    ],
                   //    //initialPreview: [
                   //    //    // IMAGE DATA
                   //    //    "http://kartik-v.github.io/bootstrap-fileinput-samples/samples/Desert.jpg",
                   //    //    // IMAGE DATA
                   //    //    "http://kartik-v.github.io/bootstrap-fileinput-samples/samples/Lighthouse.jpg",
                   //    //    // PDF DATA
                   //    //    'http://kartik-v.github.io/bootstrap-fileinput-samples/samples/pdf-sample.pdf'
                   //    //],
                   //    initialPreviewAsData: true, // identify if you are sending preview data only and not the raw markup
                   //    initialPreviewFileType: 'image', // image is the default and can be overridden in config below
                   //    //initialPreviewConfig: [
                   //    //    { caption: "Desert.jpg", size: 827000, width: "120px", url: "/file-upload-batch/2", key: 1 },
                   //    //    { caption: "Lighthouse.jpg", size: 549000, width: "120px", url: "/file-upload-batch/2", key: 2 },
                   //    //    {
                   //    //        type: "video",
                   //    //        size: 375000,
                   //    //        filetype: "video/mp4",
                   //    //        caption: "KrajeeSample.mp4",
                   //    //        url: "/file-upload-batch/2",
                   //    //        key: 3,
                   //    //        downloadUrl: 'http://kartik-v.github.io/bootstrap-fileinput-samples/samples/small.mp4', // override url
                   //    //        filename: 'KrajeeSample.mp4' // override download filename
                   //    //    },
                   //    //    { type: "office", size: 102400, caption: "SampleDOCFile_100kb.doc", url: "/file-upload-batch/2", key: 4 },
                   //    //    { type: "office", size: 45056, caption: "SampleXLSFile_38kb.xls", url: "/file-upload-batch/2", key: 5 },
                   //    //    { type: "office", size: 512000, caption: "SamplePPTFile_500kb.ppt", url: "/file-upload-batch/2", key: 6 },
                   //    //    { type: "gdocs", size: 811008, caption: "multipage_tiff_example.tif", url: "/file-upload-batch/2", key: 7 },
                   //    //    { type: "gdocs", size: 375808, caption: "sample_ai.ai", url: "/file-upload-batch/2", key: 8 },
                   //    //    { type: "gdocs", size: 40960, caption: "sample_eps.eps", url: "/file-upload-batch/2", key: 9 },
                   //    //    { type: "pdf", size: 8000, caption: "About.pdf", url: "/file-upload-batch/2", key: 10, downloadUrl: false }, // disable download
                   //    //    { type: "text", size: 1430, caption: "LoremIpsum.txt", url: "/file-upload-batch/2", key: 11, downloadUrl: false },  // disable download
                   //    //    { type: "html", size: 3550, caption: "LoremIpsum.html", url: "/file-upload-batch/2", key: 12, downloadUrl: false }  // disable download
                   //    //],
                   //    purifyHtml: true, // this by default purifies HTML data for preview
                   //    uploadExtraData: {
                   //        img_key: "1000",
                   //        img_keywords: "happy, places"
                   //    }
                   //});

                   //$('#inpListadoAsistencia').fileinput({ initialPreview: file_preview_html });
                   //$("#inpListadoAsistencia").fileinput({
                   //    uploadAsync: true,
                   //    //minFileCount: 1,
                   //    //maxFileCount: 100,
                   //    overwriteInitial: true,
                   //    showBrowse: false,
                   //    showUpload: true,
                   //    showCancel: false,
                   //    showClose: false,
                   //    showCaption: false,
                   //    showRemove: false,
                   //    showZoom: true,
                   //    removeFromPreviewOnError: false,
                   //    browseLabel: "",
                   //    initialPreview: [file_preview_html],
                   //    initialPreviewAsData: true // identify if you are sending preview data only and not the raw markup
                   //});
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
                        '<div class="col-sm-4">'+
                            '<p class="list-group-item-text">' + result.Head[i].responsable + '</p>'+
                        '</div>'+
                        '<div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>' + result.Head[i].fecha + '</span>' + '</div>' +
                        '<div class="col-sm-1"><a data-toggle="modal" data-target="#myModalCompromisos" role="button" title="Esta opción le permitirá editar los compromisos de una reunión." onclick="EditarInformacionCompromisosActaReuniones(' + result.Head[i].compromisoTareaId + ",\'" + result.Head[i].nombre + "\',\'" + result.Head[i].responsable + "\',\'" + result.Head[i].fecha + '\');"><span class="glyphicon glyphicon-edit"></span></a><a role="button" title="Esta opción le permitirá eliminar un compromiso de una reunión." onclick="EliminarInformacionCompromisosActaReuniones(' + result.Head[i].compromisoTareaId + ');"><span class="glyphicon glyphicon-trash"></span></a></div>' +
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
function EditarInformacionCompromisosActaReuniones(compromisoTareaId, compromiso, responsable, fecha)
{
    $("#errortareaTemasReuniones").hide();
    CrearModalCompromisos(compromiso, responsable, fecha, compromisoTareaId);
}
function CrearModalCompromisos(compromiso, responsable, fecha, compromisoTareaId) {
    $("#myModalCompromisos").html('<div class="modal-dialog" role="document">' +
                                        '<div class="modal-content">' +
                                            '<div class="modal-header">' +
                                                '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                                                '<h4 class="modal-title" id="myModalLabelCompromisos">Nuevo Compromiso</h4>' +
                                            '</div>' +
                                            '<div class="modal-body">' +
                                                '<input type="hidden" id="hfidCompromisosActaReuniones" runat="server"/>' +
                                                '<div class="form-group">' +
                                                    '<label for="lblcompromisos" class="control-label">Compromiso</label>' +
                                                    '<div id="errorCompromisosActa" class="alert alert-danger alert-dismissible" hidden="hidden" >El compromiso no puede ser vacío.</div>' +
                                                    '<div id="errorCompromisosActaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">La descripción del compromiso no puede contener el caracter *.</div>' +
                                                    '<textarea id="txtCompromiso" placeholder="Por favor describa el compromiso aquí... " class="form-control" rows="5" ></textarea>' +
                                                    '<label for="lblResponsable" class="control-label">Responsables</label>' +
                                                    '<div id="errorResponsable" class="alert alert-danger alert-dismissible" hidden="hidden" >El responsable no puede ser vacío.</div>' +
                                                    '<div id="errorResponsableAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre del responsable no puede contener el caracter *.</div>' +
                                                    '<textarea id="txtResponsable" placeholder="Por favor escriba los responsables aquí... " class="form-control" rows="5" ></textarea>' +
                                                    '<label for="fechaCompromisos" class="control-label">Fecha de cumplimiento</label>' +
                                                    '<div class="input-group date form_date datetimepicker" data-date="" data-date-format="yyyy-MM-dd" data-link-field="fechaCompromisos" data-link-format="yyyy-mm-dd">' +
                                                        '<input id="dtpFechaCumplimiento" class="form-control" size="16" type="text" value="" readonly>' +
                                                        '<span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>' +
                                                        '<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>' +
                                                    '</div>' +
                                                    '<div id="errorFechaCumplimiento" class="alert alert-danger alert-dismissible" hidden="hidden" >La fecha no puede ser vacío.</div>' +
                                                    '<input type="hidden" id="fechaCompromisos" value="" />' +
                                                 '</div>' +
                                                 '<div class="modal-footer">' +
                                                 '<button id="btnCancelarCompromisos" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                                                 '<button id="btnGuardarCompromisos" onclick="GuardarCompromisoTarea()" type="button" class="btn btn-primary">Guardar</button>' +
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
                            '</div>');
    $("#txtCompromiso").val(compromiso);
    $("#txtResponsable").val(responsable);
    $('#dtpFechaCumplimiento').val(fecha);
    $('#fechaCompromisos').val(fecha);
    $('#hfidCompromisosActaReuniones').val(compromisoTareaId);
}
function GuardarAsistenciaActaReunion()
{
    if (ValidarRegistroImagenActaReunion() == true) $("#inpListaAsistentes").fileinput("upload")
}
function AgregarNotas()
{
    $("#errordtgDiarioNotas").hide();
    var f = new Date();
    var fechaActual = f.getFullYear() + "-" + (f.getMonth() + 1) + "-" + f.getDate(); // f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
    CrearModalDiarioNotas('', '', fechaActual,0);
}
function CrearModalDiarioNotas(descripcion,reflexion,fecha,idDiarioNotas)
{
    $("#myModalDiarioNotas").html(  '<div class="modal-dialog" role="document">' +
                                          '<div class="modal-content">' +
                                            '<div class="modal-header">' +
                                                '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                                                '<h4 class="modal-title" id="myModalLabelDiarioNotas">Nueva nota</h4>' +
                                             '</div>' +
                                             '<div class="modal-body">' +
                                                '<input type="hidden" id="hfidDiarioNotas" runat="server"/>'+
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
    $('#hfidDiarioNotas').val(idDiarioNotas);
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
    bootbox.confirm({
        title: "Atención",
        message: "¿Desea eliminar esta tarea?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Si'
            }
        },
        callback: function (result) {
            if (result == true)
            {
                $.ajax({
                    type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { EliminarTarea: $("#hfidTarea").val() }, traditional: true,
                    beforeSend: function () {
                        waitblockUIParamPlanTrabajo('Eliminando tareas...');
                    },
                    success: function (result) {
                        CargarPlanesTrabajo();
                        volverPlanTrabajo();
                        unblockUI();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        bootbox.alert("error");
                        bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
                    }
                });
            }
        }
    });
}
function EliminarDiarioNotasTarea()
{
    bootbox.confirm({
        title: "Atención",
        message: "¿Desea eliminar esta tarea?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Si'
            }
        },
        callback: function (result)
        {
            if (result == true)
            {
                $.ajax({
                    type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { EliminarDiarioNotasTarea: $("#hfidTarea").val() }, traditional: true,
                    beforeSend: function () {
                        waitblockUIParamPlanTrabajo('Eliminando tareas...');
                    },
                    success: function (result) {
                        CargarPlanesTrabajo();
                        volverPlanTrabajo();
                        unblockUI();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        bootbox.alert("error");
                        bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
                    }
                });
            }
        }
    });
}
function FinalizarDetalleTarea()
{
    bootbox.confirm({
        title: "Atención",
        message: "¿Desea finalizar esta tarea?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Si'
            }
        },
        callback: function (result)
        {
            if (result == true)
            {
                var finalizarActaReunionesTarea = ValidarFinalizarActaReunionesTarea();
                if (finalizarActaReunionesTarea == true) {
                    $.ajax({
                        type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { FinalizarTarea: $("#hfidTarea").val() }, traditional: true,
                        beforeSend: function () {
                            waitblockUIParamPlanTrabajo('Finalizar tareas...');
                        },
                        success: function (result) {
                            bootbox.alert("La tarea se finalizó con éxito.");
                            unblockUI();
                            CargarInformacionActasReuniones();
                            CargarPlanesTrabajo();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            bootbox.alert("error");
                            bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
                        }
                    });
                }
                else bootbox.alert("No fue posible finalizar la tarea.\nPor favor revise los mensajes de error señalados en rojo que aparecen en el formato.");
            }
        }
    });



    //if (confirm("¿Desea finalizar esta tarea?"))
    //{
       
    //}
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
    bootbox.confirm({
        title: "Atención",
        message: "¿Desea finalizar esta tarea?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Si'
            }
        },
        callback: function (result)
        {
            if (result == true)
            {
                var finalizarDiarioNotasTarea = ValidarFinalizarDiarioNotas();
                if (finalizarDiarioNotasTarea == true) {
                    $.ajax({
                        type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { FinalizarTarea: $("#hfidTarea").val() }, traditional: true,
                        beforeSend: function () {
                            waitblockUIParamPlanTrabajo('Finalizar tareas...');
                        },
                        success: function (result) {
                            bootbox.alert("La tarea se finalizó con éxito.");
                            unblockUI();
                            CargarInformacionDiarioNotas();
                            CargarPlanesTrabajo();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            bootbox.alert("error");
                            bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
                        }
                    });
                }
                else bootbox.alert("No fue posible finalizar la tarea.\nPor favor revise los mensajes de error señalados en rojo que aparecen en el formato.");
            }
        }
    });
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
    var fechaActual = f.getFullYear() + "-" + (f.getMonth() + 1) + "-" + f.getDate(); // f.getFullYear() + "-" + (f.getMonth() + 1) + "-" + f.getDate();
    CrearModalCompromisos('', '', fechaActual);
}
function EliminarInformacionCompromisosActaReuniones(idCompromisoTarea) {
    bootbox.confirm({
        title: "Atención",
        message: "¿Desea eliminar este compromiso del acta de reunión?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Si'
            }
        },
        callback: function (result) {
            if (result == true) {
                $.ajax({
                    type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { EliminarCompromisoActaReuniones: idCompromisoTarea }, traditional: true,
                    beforeSend: function () {
                        waitblockUIParamPlanTrabajo('Eliminando tareas...');
                    },
                    success: function (result) {
                        CargarInformacionActasReuniones();
                        unblockUI();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        bootbox.alert("error");
                        bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
                    }
                });
            }
        }
    });
}
function AgregarRegistroFotografico()
{
    var f = new Date();
    var fechaActual = f.getFullYear() + "-" + (f.getMonth() + 1) + "-" + f.getDate(); //f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
    CrearModalRegistroFotografico('','', '', fechaActual);
}
function CrearModalRegistroFotografico(descripcion,lugar,responsable,fecha)
{
    $("#myModalAgregarRegistro").html('<div class="modal-dialog" role="document">' +
                                        '<div class="modal-content">'+
                                            '<div class="modal-header">'+
                                                '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>'+
                                                '<h4 class="modal-title" id="myModalLabelRecursoTarea">Agregar información y fotografía</h4>'+
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
                                                                                    'showUpload: false,' +
                                                                                    'language: "es",' +
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
    bootbox.confirm({
        title: "Atención",
        message: "¿Desea finalizar esta tarea?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Si'
            }
        },
        callback: function (result) {
            if (result == true)
            {
                if (ValidarFinalizarTareaRegistroFotografico() == true) {
                    $.ajax({
                        type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { FinalizarTarea: $("#hfidTarea").val() }, traditional: true,
                        beforeSend: function () {
                            waitblockUIParamPlanTrabajo('Finalizar tareas...');
                        },
                        success: function (result) {
                            bootbox.alert("La tarea se finalizó con éxito.");
                            unblockUI();
                            CargarInformacionDetalleTareaRecursosFotografico();
                            CargarPlanesTrabajo();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            bootbox.alert("error");
                            bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
                        }
                    });
                }
                else bootbox.alert("No fue posible finalizar la tarea.\nPor favor revise los mensajes de error señalados en rojo que aparecen en el formato.");
            }
        }
    });
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
    bootbox.confirm({
        title: "Atención",
        message: "¿Desea eliminar esta tarea?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Si'
            }
        },
        callback: function (result) {
            if (result == true)
            {
                $.ajax({
                    type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { EliminarTareaRegistroFotografico: $("#hfidTarea").val() }, traditional: true,
                    beforeSend: function () {
                        waitblockUIParamPlanTrabajo('Eliminando tarea...');
                    },
                    success: function (result) {
                        CargarPlanesTrabajo();
                        volverPlanTrabajo();
                        unblockUI();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        bootbox.alert("error");
                        bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
                    }
                });
            }
        }
    });
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
    bootbox.confirm({
        title: "Atención",
        message: "¿Desea eliminar esta tarea?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Si'
            }
        },
        callback: function (result)
        {
            if (result == true)
            {
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
                        bootbox.alert("error");
                        bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
                    }
                });
            }
        }
    });
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
                                                                                    'uploadUrl: "../../Views/VerificacionAnalisis/DetallePlanTrabajoRecursoMultimediaVisitaCampo_ajax",' +
                                                                                    'language: "es",' +
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
    bootbox.confirm({
        title: "Atención",
        message: "¿Desea finalizar esta tarea?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Si'
            }
        },
        callback: function (result)
        {
            if (result == true)
            {
                if (ValidarFinalizarVisitaCampoTarea() == true) {
                    $.ajax({
                        type: "POST", url: '../../Views/VerificacionAnalisis/DetallePlanTrabajo_ajax', data: { FinalizarTarea: $("#hfidTarea").val() }, traditional: true,
                        beforeSend: function () {
                            waitblockUIParamPlanTrabajo('Finalizar tareas...');
                        },
                        success: function (result) {
                            bootbox.alert("La tarea se finalizó con éxito.");
                            unblockUI();
                            CargarInformacionVisitaCampoTarea();
                            CargarPlanesTrabajo();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            bootbox.alert("error");
                            bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
                        }
                    });
                }
                else bootbox.alert("No fue posible finalizar la tarea.\nPor favor revise los mensajes de error señalados en rojo que aparecen en el formato.");
            }
        }
    });
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
