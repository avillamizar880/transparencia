function ConsultarInformeHallazgo()
{
    //$("#recursoMultimediaHallazgo").fileinput({
    //    uploadUrl: "http://localhost/file-upload-single/1", // server upload action
    //    uploadAsync: true,
    //    maxFileCount: 5
    //});

    $("#recursoMultimediaHallazgo").fileinput({
        language: 'es',
        uploadUrl: "../../Views/VerificacionAnalisis/InformeHallazgo_ajax", // server upload action
        uploadAsync: true,
        showUpload: false,
        showCaption: false,
        minFileCount: 1,
        maxFileCount: 5,
        overwriteInitial: true,
        browseLabel: "Subir Evidencia",
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
    var mensajeAsterisco = $("#txtHallazgo").val().split('*');
    $("#errorRecursoMultimediaHallazgo").hide();
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
        var contPalabras = PalabrasCaracteres($("#txtHallazgo").val());
        if (contPalabras[0] > 200) {
            $("#errorHallazgo").html('La descripción del hallazgo no puede superar las 200 palabras.');
            $("#errorHallazgo").show();
            return false;
        }
    }
    if ($("#recursoMultimediaHallazgo").val() == '') {
        $("#errorRecursoMultimediaHallazgo").html('Por favor ingrese una descripción del hallazgo.');
        $("#errorRecursoMultimediaHallazgo").show();
        return false;
    }
    return true;
}

function PalabrasCaracteres(frase) {
var resultado = [0,0];
var palabras = 0;
var caracterestotales = 0;
for (var i = 0; i < frase.Length; i++)
{
    if (frase[i] == ' ' || frase[i] == '.')
    {
            palabras++;
    }
}
caracterestotales = frase.Length - palabras;
resultado[0] = palabras;
resultado[1] = caracterestotales ;
return resultado;
}

function guardarInformeHallazgo()
{
    var guardarDatos = ValidarDatosInformeHallazgo();
    if (guardarDatos == true)
    {
        $("#recursoMultimediaHallazgo").fileinput("upload");
    }
    else alert("Se presentaron inconsistencias al guardar este reporte.\nRevise los mensajes que aparecen en la pantalla.");
}