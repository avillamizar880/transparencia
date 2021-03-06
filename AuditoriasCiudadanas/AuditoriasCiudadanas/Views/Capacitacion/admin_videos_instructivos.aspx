﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_videos_instructivos.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.admin_videos_instructivos" %>
<div class="container" id="divInfoEnlace">
<input type="hidden" id="hdIdUsuario" runat="server" />
    <h1>Creación de Videos</h1>
    <div class="form-group">
        <label for="txtTitulo" class="required">Título</label>
        <input type="text" class="form-control" id="txtTitulo">
        <div id="error_txtTitulo" class="alert alert-danger alert-dismissible" hidden="hidden">Títulol no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtEnlace" class="required">Link</label>
        <input type="text" class="form-control" id="txtEnlace">
        <div id="error_txtEnlace" class="alert alert-danger alert-dismissible" hidden="hidden">Link no puede ser vacío</div>
    </div>
      <!--BOTONERA-->
    <div class="botonera text-center">
        <div class="btn btn-primary"><a id="btnCrearVideoIns" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
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
