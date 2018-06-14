<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_recursoscapacitacion.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.admin_recursoscapacitacion" %>
<div class="container" id="divInfoRecursos">
<input type="hidden" id="hdIdUsuario" runat="server" />
<input type="hidden" id="hdIdCap" runat="server" />
        <h1>Recursos de la Capacitación</h1>

    <div id="editarTCap">
    <div class="form-group">
        <label for="txtTituloCap" class="required">Título</label>
        <input type="text" class="form-control" id="txtTituloCap">
        <div id="error_txtTituloCap" class="alert alert-danger alert-dismissible" hidden="hidden">Título no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtDescripcionCap" class="required">Detalle</label>
        <input type="text" class="form-control" id="txtDescripcionCap">
        <div id="error_txtDescripcionCap" class="alert alert-danger alert-dismissible" hidden="hidden">Detalle no puede ser vacío</div>
    </div>
      <!--BOTONERA-->
    <div class="botonera text-center">
        <div class="btn btn-primary"><a id="btnEditarTemaCapacitacion" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>

    </div>
    </div>
     <div class="container" id="divDetalleRecursos">
        <div class="row" id="divListRecursos">
            <div id="datosRCap" class="list-group uppText clearfix"></div>
            
        </div>
        <div class="row">
            <div class="btn btn-info" id="btnAñadirRCap"><a href="#"> <span class="glyphicon glyphicon-plus"></span>Añadir Recurso</a></div>
            <div id="divAddEvaluacion" style="display:inline-block;padding-left:10px;"></div>
        </div> 

    <div id="crearRCap">
    <div class="form-group">
        <label for="txtTituloRCap" class="required">Título</label>
        <input type="text" class="form-control" id="txtTituloRCap">
        <div id="error_txtTituloRCap" class="alert alert-danger alert-dismissible" hidden="hidden">Título no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtModulo" class="required">Módulo</label>
        <input type="text" class="form-control" id="txtModulo">
        <div id="error_txtModulo" class="alert alert-danger alert-dismissible" hidden="hidden">El módulo no puede ser vacío</div>
    </div>
        <label for="txtTipoRCap" class="required">Tipo</label>
        <select class="form-control" id="txtTipoRCap">
            <option value="" selected>Seleccione una opción</option>
            <option value="2">Archivo PDF</option>
            <option value="3">Video</option>
            <option value="5">Enlace externo</option>
        </select>        
        <div id="error_txtTipoRCap" class="alert alert-danger alert-dismissible" hidden="hidden">Seleccione una opción</div>
    <div class="form-group" id="divUrl" hidden="hidden">
        <label for="txtURLRCap" class="required">URL</label>
        <input type="text" class="form-control" id="txtURLRCap">
        <div id="error_txtURLRCap" class="alert alert-danger alert-dismissible" hidden="hidden">URL no puede ser vacío</div>
    </div>
    <div class="panel panel-default" id="divPanel"  hidden="hidden">
        <div class="panel-heading">
            <h4>Documento (.pdf):</h4>
            <p>Agregue archivo pdf correspondiente al recurso</p>
        </div>
        <div class="panel-body">
            <div id="divAdjuntos">
                <input id="btnNewAdjuntoRecurso" name="btnNewAdjuntoRecurso[]" type="file" class="file-loading">
            </div>
        </div>
    </div>
      <!--BOTONERA-->
    <div class="botonera text-center">
        <div class="btn "><a id="btnVolverRCap" role="button">VOLVER<span class="glyphicon "></span></a></div>
        <div class="btn btn-primary"><a id="btnCrearRecursoCapacitacion" role="button">GUARDAR RECURSO<span class="glyphicon glyphicon-chevron-right"></span></a></div>

    </div>
    </div>
    </div>

</div>
       <div class="row hideObj" id="divPlantillasProy">
        <div class="plantillasHeader">
            <h5>
                <a id="btnVolverAdminRecursos" role="button" onclick="volver_listado_capacitacion();"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER A CAPACITACIÓN
                </a>
            </h5>
            </div>
        <div id="divCodPlantilla">

        </div>
    </div> 


<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/CapacitacionFunciones.js", function () {
                $.getScript("../../Scripts/CapacitacionAcciones.js", function () {
       $("#btnNewAdjuntoRecurso").fileinput({
       uploadUrl: "../../Views/Capacitacion/admin_recursoscapacitacion_ajax", // server upload action
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
                        $("#txtURLRCap").val("PDF");
                        var valida = validarCamposObligatorios("crearRCap");
                        if (valida == false) {
                            return {
       message: "Archivo no guardado, faltan campos obligatorios", // upload error message
       data: {} // any other data to send that can be referred in `filecustomerror`
   };
   }
   }).on('filepreupload', function (event, data, previewId, index, jqXHR) {
                        var opc = "ADD";
                        var id_usuario= $("#hdIdUsuario").val();
                        var titulo= $("#txtTituloRCap").val();
                        var modulo= $("#txtModulo").val();
                        var tipo= $("#txtTipoRCap").val();
                        var id_cap = $("#hdIdCap").val();
                       data.form.append("opc", opc);
                       data.form.append("id_usuario", id_usuario);
                       data.form.append("titulo", titulo);
                       data.form.append("modulo", modulo);
                       data.form.append("tipo", tipo);
                       data.form.append("id_cap", id_cap);
   }).on('fileuploaded', function (event, data, id, index) {
                          var result = data.response.Head[0];
                          var codigo_error = result.cod_error;
                          var mensaje = result.msg_error;
                           if (codigo_error == '0') {
                               bootbox.alert("Recurso de capacitación guardado exitosamente", function () {
                                //inhabilitar, recargar campos
                               volverRecursosCap();
                               });
                          } else {
                              bootbox.alert(mensaje);
                         }

           });
       });
  
       CargarDatosCapacitacion();
        });
    }));
</script>