<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForoDetalle.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Comunicacion.ForoDetalle" %>

<div class="container" id="NoSession" runat="server">
    <h1 class="text-center">Foro</h1>
    <div class="alert alert-danger">
        <strong>Error:</strong> Debes iniciar sesión para usar el espacio virtual.
    </div>
</div>

<input type="hidden" id="hdIdUsuario" runat="server" value="" />
<div class="container" id="divInfoForoDetalle" runat="server">
    <h1 class="text-center">Foro</h1>
    <div class="btnBack">
        <div class="btn btn-default" onclick="cargaMenu('Comunicacion/adminForo','dvPrincipal')">Volver al Listado</div>
    </div>

</div>

<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("/Scripts/ComunicacionFunciones.js", function () {
            verRespuestasCompletas(<%= idDelForo %>);
        });
    }));
</script>
