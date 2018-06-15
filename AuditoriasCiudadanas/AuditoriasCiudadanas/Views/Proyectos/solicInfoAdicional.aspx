<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="solicInfoAdicional.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Proyectos.solicInfoAdicional" %>
<div class="container">
    <input type="hidden" id="hfIdGrupoGac" value="" runat="server"/>
    <input type="hidden" id="hfIdUsuario" value="" runat="server"/>
    <input type="hidden" id="hfIdProyecto" value="" runat="server" />
    <h1  class="text-center">Solicitud de información adicional</h1>
    <div class="center-block w70">
        <div class="form-group">
            <h4 class="text-center">En el siguiente recuadro redacte de manera detallada que información adicional requiere sobre el proyecto, está será transmitida al ente ejecutor del proyecto (Máximo: 1000 caracteres) </h4>
            <textarea rows="10" cols="110" id="txtDetalle"></textarea>
        </div>
        <div class="botonera text-center">
            <div class="btn btn-primary">
            <a href="#" onclick="guardarSolicitud()">Enviar<span class="glyphicon glyphicon-chevron-right"></span></a>
        </div>
        </div>
    </div>
</div>

