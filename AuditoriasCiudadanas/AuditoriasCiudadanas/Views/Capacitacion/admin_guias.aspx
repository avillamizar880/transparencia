<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_guias.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.admin_guias" %>
<div class="container" id="divInfoEnlace">
<input type="hidden" id="hdIdUsuario" runat="server" />
    <h1>Creación de Guías y manuales</h1>
    <div class="form-group">
        <label for="ddlTipoRecurso" class="required">Guía/Manual</label>
        <!-- departamento-->
        <select class="form-control" id="ddlTipoRecurso">
            <option value="" selected>Seleccione una opción</option>
            <option value="1">Guía</option>
            <option value="2">Manual</option>
        </select>
        <div id="error_ddlTipoRecurso" class="alert alert-danger alert-dismissible" hidden="hidden">Seleccione si es guía o manual</div>
    </div>
    <div class="form-group">
        <label for="txtTitulo" class="required">Título</label>
        <input type="text" class="form-control" id="txtTitulo">
        <div id="error_txtTitulo" class="alert alert-danger alert-dismissible" hidden="hidden">Títulol no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtDescripcion" class="required">Descripción</label>
        <input type="text" class="form-control" id="txtDescripcion">
        <div id="error_txtDescripcion" class="alert alert-danger alert-dismissible" hidden="hidden">Descripción no puede ser vacío</div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4>Guía o Manual (.pdf):</h4>
            <p>Agregue archivo pdf correspondiente a la guía o manual</p>
        </div>
        <div class="panel-body">
            <div id="divAdjuntos">
                <input id="btnNewAdjuntoCompromiso-1" name="btnNewAdjuntoCompromiso[]" type="file" class="file-loading">
            </div>
        </div>
    </div>

      <!--BOTONERA-->
    <div class="botonera text-center">
        <%--<div class="btn btn-primary"><a id="btnCrearEnlace" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>--%>
         <button class="btn btn-info" id="btnCrearGuias"><span class="glyphicon glyphicon-save"></span>GUARDAR</button>
    </div>
</div>
<script type="text/javascript">
    if ($(document).ready(function () {
         $.getScript('../../Scripts/CapacitacionFunciones.js', function () {
             $.getScript('../../Scripts/CapacitacionAcciones.js', function () {
            $("#btnNewAdjuntoCompromiso-1").fileinput({
                    uploadUrl: "../../Views/Capacitacion/admin_guias_ajax", // server upload action
                    showUpload: false,
                    maxFileCount: 1,
                    showCaption: false,
                    allowedFileExtensions: ['pdf'],
                    browseLabel: "Adjunto (archivo pdf)",
                    showDrag: false,
                    dropZoneEnabled: false,
                    showPreview: true,
                    
                }).on('filebatchpreupload', function (event, data) {
                        //validar campos obligatorios

                        var valida = validarCamposObligatorios("divInfoEnlace");
                        if (valida == false) {
                            return {
                            message: "Archivo no guardadado, faltan campos obligatorios", // upload error message
                            data: {} // any other data to send that can be referred in `filecustomerror`
                        };
                    }
                }).on('filepreupload', function (event, data, previewId, index, jqXHR) {
                        var titulo = $("#txtTitulo").val();
                        var descripcion = $("#txtDescripcion").val();
                        var id_usuario = $("#hdIdUsuario").val();
                         var tipo = $("#ddlTipoRecurso option:selected").val();
                         data.form.append("tipo", tipo);
                         data.form.append("titulo", titulo);
                         data.form.append("desc", descripcion);
                         data.form.append("id_usuario", id_usuario);

                        }).on('fileuploaded', function (event, data, id, index) {
                          var result = data.response.Head[0];
                          var codigo_error = result.cod_error;
                          var mensaje = result.msg_error;
                           if (codigo_error == '0') {
                               bootbox.alert("Guia/manual guardado exitosamente", function () {
                                    //inhabilitar, recargar campos
                                });
                           } else {
                                bootbox.alert(mensaje);
                           }
                    });

                 $("#btnCrearGuias").bind('click', function () {
                    crear_guias();
                });
             
                    
             });
         });
     }));
</script>