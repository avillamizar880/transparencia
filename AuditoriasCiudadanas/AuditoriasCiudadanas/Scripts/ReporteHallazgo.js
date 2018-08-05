function ConsultarInformeHallazgo()
{
    $("#hfErroresFileUpload").val("false");
    $("#recursoMultimediaHallazgo").fileinput({
        theme: 'fa',
        language: 'es',
        uploadUrl: "../../Views/VerificacionAnalisis/InformeHallazgo_ajax", // server upload action
        maxFileCount: 3,
        showCaption: false,
        overwriteInitial: false,
        maxFileSize: 1024,
        showUpload: false,
        allowedFileExtensions: ['jpg', 'png', 'pdf'],
        browseLabel: "Subir Evidencia (pdf o imagen)",
        showZoom: true, 
        showRemove: true,
        showDrag: false,
        dropZoneEnabled: false,
        showPreview: true,
        validateInitialCount: true,
        uploadAsync: false,
        showCaption: false,

    }).on('fileremoved', function (event, id, index) {
        if ($("#hfErroresFileUpload").val() == "true") {
            bootbox.alert("Hemos detectado que al menos un archivo no cumple con las especificaciones requeridas. Por seguridad, se borrarán todas los archivos precargados por usted. Agradecemos corregir los errores para continuar");
            $("#hfErroresFileUpload").val("false");
            $("#errorRecursoMultimediaHallazgo").html('');
            $("#errorRecursoMultimediaHallazgo").hide();
            $("#recursoMultimediaHallazgo").fileinput('clear');
           // $("#recursoMultimediaHallazgo").fileupload('destroy');
        }
    }).on('filebatchpreupload', function (event, data, previewId, index, jqXHR) {
        var rutaImagen = $("#recursoMultimediaHallazgo").val().split("\\");
        data.form.append("hallazgo", $("#txtHallazgo").val());
        data.form.append("grupoGacId", $("#hfIdGrupoGac").val());
        data.form.append("idUsuario", $("#hfIdUsuario").val());
        data.form.append("rutaImagen", $("#hfIdUsuario").val() + '_' + rutaImagen[rutaImagen.length - 1]);
    }).on('fileuploaderror', function (event, data, msg) {
        $("#hfErroresFileUpload").val("true");
    }).on('filebatchuploadsuccess', function (event, data, id, index) {
     bootbox.alert('El reporte se subió al sistema con éxito.\nSerá redirigido a la pantalla de gestión.', function () {
                volver_listado_gestion();
            });

    });
}
function ValidarDatosInformeHallazgo()
{
    var archivosDisponiblesCarga = $("#recursoMultimediaHallazgo").val().split(',');
    $("#errorRecursoMultimediaHallazgo").hide();
    $("#errorHallazgo").hide();
    var mensajeAsterisco = $("#txtHallazgo").val().split('*');
   
    if (mensajeAsterisco.length > 1)
    {
        $("#errorHallazgo").html('No se permite el uso del caracter * en el nombre del hallazgo.');
        $("#errorHallazgo").show();
        return false;
    }
    if ($("#txtHallazgo").val() == '') {
        $("#errorHallazgo").html('Por favor ingrese una descripción del hallazgo.');
        $("#errorHallazgo").show();
        return false;
    }
    else {
        //cuenta palabras 200 maximo
        var cad_texto = $("#txtHallazgo").val();
        var contPalabras = PalabrasCaracteres(cad_texto);
        if (contPalabras > 200) {
            $("#errorHallazgo").html('La descripción del hallazgo no puede superar las 200 palabras.');
            $("#errorHallazgo").show();
            return false;
        }
    }
    if ($("#recursoMultimediaHallazgo").val() == '') {
        $("#errorRecursoMultimediaHallazgo").html('Por favor ingrese la evidencia (pdf o imagen) del hallazgo.');
        $("#errorRecursoMultimediaHallazgo").show();
        return false;
    }
    if ($("#hfErroresFileUpload").val() == "true")
    {
        $("#errorRecursoMultimediaHallazgo").html('Se presentaron errores al cargar el archivo.Por favor corríjalos antes de guardar el informe');
        $("#errorRecursoMultimediaHallazgo").show();
        return false;
    }
    return true;
}

function PalabrasCaracteres(cadena) {
    var res = cadena.split(/\b[\s,\.\-:;]*/);
    return res.length;
}

function guardarInformeHallazgo()
{
    var guardarDatos = ValidarDatosInformeHallazgo();
    if (guardarDatos == true) {
        $("#recursoMultimediaHallazgo").fileinput("upload");
    }
    else {
        bootbox.alert("Se presentaron inconsistencias al guardar este reporte.\nRevise los mensajes que aparecen en la pantalla.");
    }
}