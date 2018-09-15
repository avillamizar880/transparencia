<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForoDetalle.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Comunicacion.ForoDetalle" %>

<div class="container" id="NoSession" runat="server">
    <h1 class="text-center">Foro</h1>
    <div class="alert alert-danger">
        <strong>Error:</strong> Debes iniciar sesión para usar el espacio virtual.
    </div>
</div>

<input type="hidden" id="hdIdUsuario" runat="server" value="" />
<input type="hidden" id="hdIdForoConfig" runat="server" value="" />
<input type="hidden" id="hdFA" runat="server" value="" />
<div class="container">
    <h1 class="text-center" runat="server" id="h1Titulo">Foro</h1>
    <div class="btnBack">
        <div class="btn btn-default" onclick="cargaMenu('Comunicacion/adminForo?config=<%= ForoConfig %>','dvPrincipal')">Volver al Listado</div>
    </div>
    <div class="container" id="divInfoForoDetalle" runat="server">
    </div>
</div>

<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("/Scripts/ComunicacionFunciones.js", function () {
            verRespuestasCompletas(<%= idDelForo %>);
        });
    }));
</script>
