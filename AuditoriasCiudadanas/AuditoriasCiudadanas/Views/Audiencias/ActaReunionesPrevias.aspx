<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActaReunionesPrevias.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.ActaReuniones" %>
<div class="container">
    <h1 id="hTitulo" runat="server" class="text-center">Acta de Reuniones previas</h1>
    <div id="divInfoReunionPrevia">
        <input type="hidden" id="hfidproyecto" runat="server" />
        <input type="hidden" id="hdIdUsuario" runat="server" />
         <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Para tener en cuenta:</h4>
                    <p>Las fases previas a la Audiencia de inicio pueden considerarse alistamiento ciudadano, por esta razón, las reuniones previas a la Audiencia de inicio son espacios para que la ciudadanía y las autoridades locales puedan aclarar la información sobre el proyecto que ha sido consultada anticipadamente por el Grupo Auditor Ciudadano, esto con el propósito de definir inquietudes y observaciones para que el diálogo durante la Audiencia de inicio sea más fluido.</p>
                </div>
            </div>

        <div class=" center-block">
           <div class="panel panel-default">
                <div class="panel-heading">
                        <h4>Tema a Tratar:</h4>
                        <p>Es importante reportar el por qué se realiza la reunión y cómo aporta esta al seguimiento del proyecto.</p>
                </div>
               <div class="panel-body">
                    <div class="form-group">
                        <label for="txtAsunto">Tema</label>
                        <textarea class="form-control" rows="3" id="txtTema" runat="server"></textarea>
                    </div>
               </div>
            </div>
            <div class="panel panel-default">
                 <div class="panel-heading">
                        <h4>Lugar y fecha:</h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="txtLugar">Lugar</label>
                                <asp:textbox id="txtMunicipio" class="form-control" data-items="20" runat="server" autocomplete="on" />
                                <asp:hiddenfield id="hdIdMunicipio" runat="server" />
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="dtp_fecha_acta" class="control-label">Fecha</label>
                                <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_fecha_acta" data-link-format="yyyy-mm-dd">
                                    <input class="form-control" size="16" type="text" value="" readonly>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                </div>
                                <input type="hidden" id="dtp_fecha_acta" value="" /><br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Formato de Asistencia:</h4>
                    <a role="button" id="btnDescargaFormato">[Descargar formato]</a>
                </div>
                <div class="panel-body">
                    <input id="btnUploadImg" name="btnUploadImg[]" type="file" multiple class="file-loading">
                </div>
            </div>
        </div>
        <!--BOTONERA-->
        <div class="botonera text-center">
            <div class="btn btn-primary"><a id="btnGuardarActa"><span class="glyphicon glyphicon-camera"></span>GUARDAR</a></div>
       </div>
        <div id="divPdfAsistencia"></div>
    </div>

</div>
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("../../Scripts/AudienciasFunciones.js", function () {
        $.getScript("../../Scripts/AudienciasAcciones.js", function () {
        $("#btnUploadImg").fileinput({
        uploadUrl: "../Views/Audiencias/ActaReunionesPrevias_ajax", // server upload action
        showUpload: false,
        maxFileCount: 1,
        showCaption: false,
        allowedFileExtensions: ['jpg', 'png'],
        maxFileCount: 1,
        browseLabel: "SUBIR FOTO DE ASISTENCIA",
        showDrag: false,
        dropZoneEnabled: false,
    }).on('filepreupload', function (event, data, previewId, index, jqXHR) {
                                data.form.append("id_lugar", $("#hdIdMunicipio").val());
                                data.form.append("tema", $("#txtTema").val());
                                data.form.append("fecha", $("#dtp_fecha_acta").val());
                                data.form.append("cod_bpin", $("#hfidproyecto").val());
                                data.form.append("id_usuario", $("#hdIdUsuario").val());
    }).on('fileuploaded', function (event, data, id, index) {
        bootbox.alert("Información cargada con exito", function () {
        //recarga boton gestion
        volver_listado_gestion();
    });
    });

            $("#btnGuardarActa").click(function () {
                $("#btnUploadImg").fileinput("upload");
    });
    });
    });
    }));
</script>



    










