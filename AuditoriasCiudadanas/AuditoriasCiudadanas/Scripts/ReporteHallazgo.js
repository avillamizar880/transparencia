function ConsultarInformeHallazgo()
{
    $("#recursoMultimediaHallazgo").fileinput({
        language: 'es',
        uploadUrl: "../../Views/VerificacionAnalisis/InformeHallazgo_ajax", // server upload action
        //uploadAsync: true,
        showUpload: false,
        showCaption: false,
        minFileCount: 1,
        maxFileCount: 5,
        overwriteInitial: true,
        browseLabel: "Subir Evidencia (pdf o imagen)",
        initialPreview: [],
        initialPreviewAsData: true, // identify if you are sending preview data only and not the raw markup
        initialPreviewFileType: ['image', 'html', 'text', 'video', 'audio', 'flash', 'object'] // image is the default and can be overridden in config below
    }).on('filepreupload', function (event, data, previewId, index, jqXHR) {
        var rutaImagen = $("#recursoMultimediaHallazgo").val().split("\\");
        data.form.append("hallazgo", $("#txtHallazgo").val());
        data.form.append("grupoGacId", $("#hfIdGrupoGac").val());
        data.form.append("idUsuario", $("#hfIdUsuario").val());
        data.form.append("rutaImagen", $("#hfIdUsuario").val() + '_' + rutaImagen[rutaImagen.length - 1]);
    }).on('fileuploaded', function (event, data, id, index) {
        bootbox.alert('El reporte se subió al sistema con éxito.\nSerá redirigido a la pantalla de gestión.', function () {
                volver_listado_gestion();
        });
    });
}
function ValidarDatosInformeHallazgo()
{
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
        debugger
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
    return true;
}

function PalabrasCaracteres(cadena) {
    debugger
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