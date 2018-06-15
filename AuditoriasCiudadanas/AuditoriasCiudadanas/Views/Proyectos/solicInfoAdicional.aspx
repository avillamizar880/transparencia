<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="solicInfoAdicional.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Proyectos.solicInfoAdicional" %>
<div class="container">
    <input type="hidden" id="hfIdGrupoGac" value="" runat="server"/>
    <input type="hidden" id="hdIdUsuario" value="" runat="server"/>
    <input type="hidden" id="hfIdProyecto" value="" runat="server" />
    <h1  class="text-center">Solicitud de información adicional</h1>
    <div class="center-block w70" id="divInfoSolic">
        <div class="form-group">
            <h4 class="text-center">En el siguiente recuadro redacte de manera detallada que información adicional requiere sobre el proyecto, está será transmitida al ente ejecutor del proyecto (Máximo: 1000 caracteres) </h4>
             <label for="txtDetalle" class="required">Detalle</label>
             <textarea rows="10" cols="110" id="txtDetalle"></textarea>
            <div id="error_txtDetalle" class="alert alert-danger alert-dismissible" hidden="hidden">Detalle no puede ser vacío</div>
        </div>
        <div class="botonera text-center">
            <div class="btn btn-primary">
            <a role="button" onclick="guardarSolicitudAdicional();">Enviar<span class="glyphicon glyphicon-chevron-right"></span></a>
        </div>
        </div>
    </div>
</div>

