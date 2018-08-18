<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegExperienciaLabor.aspx.cs" Inherits="AuditoriasCiudadanas.Views.GestionGAC.RegExperienciaLabor" %>
    <div class="container">
    <input type="hidden" id="hfIdGrupoGac" value="" runat="server"/>
    <input type="hidden" id="hdIdUsuario" value="" runat="server"/>
    <input type="hidden" id="hfIdProyecto" value="" runat="server" />
    <input type="hidden" id="hfErroresFileUpload" value="" runat="server"/>
    <h1 class="text-center">Registrar Experiencia</h1>
    	<div class="w60 center-block">
            	<div class="row">
                <div class="col-sm-12">
                <div class="form-group required">
               	<label for="txtDescripcion">Descripción</label>
                <span class="label label-default fr">0/300</span>
                <textarea class="form-control" rows="5" id="txtDescripcion"></textarea>
                <div id="error_txtDescripcion" class="alert alert-danger alert-dismissible" hidden="hidden">Descripción no puede ser vacía.</div>
                </div>
                <div>
                    <div>
                        <label class="modal-title" style="padding-bottom: 20px; padding-top: 20px;">Adjunte archivo multimedia</label>
                        <input id="recursoMultimediaExp" type="file">
                        <div id="error_recursoMultimediaExp" class="alert alert-danger alert-dismissible" hidden="hidden">Adjunto no puede ser vacío.</div>
                    </div>
                </div>
                </div>
                </div>
        <!--BOTONERA-->
             <div class="botonera text-center">
              	<div class="btn btn-primary"><a role="button" id="btnPostularExpGac"><span class="glyphicon glyphicon-ok-sign"></span>Guardar</a></div>
             </div>
        </div>
    </div>
<script>
    //ConsultarInformeHallazgo();     
    $("#hfErroresFileUpload").val("false");
    $("#recursoMultimediaExp").fileinput({
        theme: 'fa',
        language: 'es',
        uploadUrl: "../../Views/GestionGAC/RegExperienciaLabor_ajax", // server upload action
        maxFileCount: 1,
        showCaption: false,
        overwriteInitial: false,
        maxFileSize: 5120,
        showUpload: false,
        allowedFileExtensions: ['mp3','mp4', 'wav', 'wma','png','jpg'],
        browseLabel: "Audio o Video",
        showZoom: true,
        showRemove: true,
        showDrag: false,
        dropZoneEnabled: false,
        showPreview: true,
        validateInitialCount: true,
        uploadAsync: false,
        showCaption: true,

    }).on('fileremoved', function (event, id, index) {
        if ($("#hfErroresFileUpload").val() == "true") {
            bootbox.alert("Hemos detectado que al menos un archivo no cumple con las especificaciones requeridas. Por seguridad, se borrarán todas los archivos precargados por usted. Agradecemos corregir los errores para continuar", function () {
                $("#hfErroresFileUpload").val("false");
                $("#error_recursoMultimediaExp").html('');
                $("#error_recursoMultimediaExp").hide();
                $("#recursoMultimediaExp").fileinput('clear');
            });
            
        }
    }).on('filebatchpreupload', function (event, data, previewId, index, jqXHR) {
        data.form.append("descripcion", $("#txtDescripcion").val());
        data.form.append("grupoGacId", $("#hfIdGrupoGac").val());
        data.form.append("idUsuario", $("#hdIdUsuario").val());
        data.form.append("cod_bpin", $("#hfIdProyecto").val());
    }).on('filebatchuploaderror', function (event, data, msg) {
        $("#hfErroresFileUpload").val("true");
    }).on('filebatchuploadsuccess', function (event, data, id, index) {
        var respuesta = data.response;
        if (respuesta.Head.length > 0) {
            if (respuesta.Head[0].cod_error == "0") {
                bootbox.alert('La experiencia se subió al sistema con éxito.\nSerá redirigido a la pantalla de gestión.', function () {
                    volver_listado_gestion();
                });
            } else {
                if (respuesta.Head[0].msg_error != "") {
                    bootbox.alert("Se presentó un error al guardar la experiencia: " + respuesta.Head[0].msg_error);
                }
            }
        } else {
            bootbox.alert("Se presentó un error al guardar la experiencia");

        }
    });


    $("#btnPostularExpGac").bind('click', function () {
        guardar_experienciaGAC();
    });

</script>