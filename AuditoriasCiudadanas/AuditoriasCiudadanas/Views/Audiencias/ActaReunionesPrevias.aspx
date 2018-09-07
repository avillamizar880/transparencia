<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActaReunionesPrevias.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.ActaReuniones" %>
<div class="container">
    <h1 id="hTitulo" runat="server" class="text-center">Acta de Reuniones previas</h1>
    <div id="divInfoReunionPrevia">
        <input type="hidden" id="hfidproyecto" runat="server" />
        <input type="hidden" id="hdIdUsuario" runat="server" />
        <input type="hidden" id="hdIdGac" runat="server" />
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
                        <label for="txtTema" class="required">Tema</label>
                        <textarea class="form-control" rows="3" id="txtTema" runat="server"></textarea>
                        <div id="error_txtTema" class="alert alert-danger alert-dismissible" hidden="hidden">Tema no puede ser vacío</div>
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
                                <label class="required">Lugar</label>
                                <asp:textbox id="txtMunicipio" class="form-control" data-items="20" runat="server" autocomplete="on" />
                                <asp:hiddenfield id="hdIdMunicipio" runat="server" />
                                <div id="error_hdIdMunicipio" class="alert alert-danger alert-dismissible" hidden="hidden">Lugar no encontrado en el sistema</div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="dtp_fecha_acta" class="control-label required">Fecha</label>
                                <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_fecha_acta" data-link-format="yyyy-mm-dd">
                                    <input class="form-control" size="16" type="text" value="" readonly>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                </div>
                                <input type="hidden" id="dtp_fecha_acta" value="" /><br />
                                <div id="error_dtp_fecha_acta" class="alert alert-danger alert-dismissible" hidden="hidden">Fecha no puede ser vacía</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="required">Formato de Asistencia:</h4>
                    <a role="button" id="btnDescargaFormato">[Descargar formato]</a>
                </div>
                <div class="panel-body">
                    <input id="btnUploadImg" name="btnUploadImg[]" type="file" accept=".png,.jpg" multiple class="file-loading">
                </div>
            </div>
        </div>
        <div id="divErrores">
            <div id="error_usuario" class="alert alert-danger alert-dismissible" hidden="hidden">Acción para usuarios registrados</div>
            <div id="error_bpin" class="alert alert-danger alert-dismissible" hidden="hidden">BPIN no asociado</div>
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
        language: 'es',
        uploadUrl: "../Views/Audiencias/ActaReunionesPrevias_ajax", 
        showUpload: false,
        maxFileCount: 1,
        showCaption: false,
        allowedFileExtensions: ['jpg', 'png'],
        maxFileCount: 1,
        browseLabel: "SUBIR FOTO DE ASISTENCIA (png/jpg)",
        showDrag: false,
        dropZoneEnabled: false,
    }).on('filebatchpreupload', function (event, data) {
    }).on('filepreupload', function (event, data, previewId, index, jqXHR) {
            data.form.append("id_lugar", $("#hdIdMunicipio").val());
            data.form.append("tema", $("#txtTema").val());
            data.form.append("fecha", $("#dtp_fecha_acta").val());
            data.form.append("cod_bpin", $("#hfidproyecto").val());
            data.form.append("id_usuario", $("#hdIdUsuario").val());
            data.form.append("id_gac", $("#hdIdGac").val());
            }).on('fileuploaded', function (event, data, id, index) {
        bootbox.alert("Información cargada con exito", function () {
        //recarga boton gestion
        volver_listado_gestion();
    });
    });

        $("#btnGuardarActa").click(function () {
            //$("#btnUploadImg").fileinput("upload");
                guardar_actaReunionesPrevias();
        });
    });
    });
    }));
</script>



    










