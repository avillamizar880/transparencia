<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_enlaces.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.admin_enlaces" %>
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
    <div class="form-group">
        <label for="txtEnlace" class="required">Link</label>
        <input type="text" class="form-control" id="txtEnlace">
        <div id="error_txtEnlace" class="alert alert-danger alert-dismissible" hidden="hidden">Link no puede ser vacío</div>
    </div>

      <!--BOTONERA-->
    <div class="botonera text-center">
        <div class="btn btn-primary"><a id="btnCrearEnlace" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
    </div>
</div>
<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/CapacitacionFunciones.js", function () {
                $.getScript("../../Scripts/CapacitacionAcciones.js", function () {
            });
        });
    }));
</script>
