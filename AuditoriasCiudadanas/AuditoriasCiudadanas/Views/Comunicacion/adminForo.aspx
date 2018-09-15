<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminForo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Comunicacion.adminForo" %>

<!-- Page Content -->
<div class="container" id="NoSession" runat="server">
    <h1 class="text-center">Foro</h1>
    <div class="alert alert-danger">
        <strong>Error:</strong> Debes iniciar sesión para usar el espacio virtual.
    </div>
</div>

<input type="hidden" id="hdIdUsuario" runat="server" value="" />
<input type="hidden" id="hdIdForoConfig" runat="server" value="" />
<input type="hidden" id="hdFA" runat="server" value="" />
<h1 class="text-center" runat="server" id="h1Titulo">Foro</h1>
<div class="container" id="divInfoForo" runat="server">
    

</div>


<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("/Scripts/ComunicacionFunciones.js", function () {
            $.getScript("/Scripts/ComunicacionAcciones.js", function () {
            });
        });
    }));
</script>
