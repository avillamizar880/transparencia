<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminForo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Interaccion.adminForo" %>
<div class="container" id="divInfoForo">
<input type="hidden" id="hdIdUsuario" runat="server" />
    <h1>Creación de Foro</h1>
    <div class="form-group">
        <label for="txtTema" class="required">Tema</label>
        <input type="text" class="form-control" id="txtTema">
        <div id="error_txtTema" class="alert alert-danger alert-dismissible" hidden="hidden">Tema no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtDescripcion" class="required">Descripción</label>
        <input type="text" class="form-control" id="txtDescripcion">
        <div id="error_txtDescripcion" class="alert alert-danger alert-dismissible" hidden="hidden">Descripción no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtMensaje" class="required">Mensaje</label>
        <input type="text" class="form-control" id="txtMensaje">
        <div id="error_txtMensaje" class="alert alert-danger alert-dismissible" hidden="hidden">Mensaje no puede ser vacío</div>
    </div>

      <!--BOTONERA-->
    <div class="botonera text-center">
        <div class="btn btn-primary"><a id="btnCrearForo" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
    </div>
</div>
<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/ComunicacionFunciones.js", function () {
                $.getScript("../../Scripts/ComunicacionAcciones.js", function () {
            });
        });
    }));
</script>