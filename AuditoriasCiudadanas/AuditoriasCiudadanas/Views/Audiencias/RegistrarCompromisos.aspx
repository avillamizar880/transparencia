<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarCompromisos.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.RegistrarCompromisos" %>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../../Content/logo-nav.css" rel="stylesheet" />
<link href="../../Content/screenView.css" rel="stylesheet" />
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../../Scripts/jquery.blockUI.js"></script>
<script src="../../Scripts/ajaxPost.js"></script>

<table id="tb_compromisos" runat="server">
    <thead></thead>
    <tbody>
        <tr>
            <td>
                <input type="text" class="compromiso" id="compromiso1" /></td>
            <td>
                <input class="responsable" id="responsable1" /></td>
            <td>
                <input class="fecha" id="fechacumplimiento1" /></td>
        </tr>
        <tr>
            <td>
                <input class="compromiso" id="compromiso2" /></td>
            <td>
                <input class="responsable" id="responsable2" /></td>
            <td>
                <input class="fecha" id="fechacumplimiento2" /></td>
        </tr>
        <tr>
            <td>
                <input class="compromiso" id="compromiso3" /></td>
            <td>
                <input class="responsable" id="responsable3" /></td>
            <td>
                <input class="fecha" id="fechacumplimiento3" /></td>
        </tr>
    </tbody>
</table>
<div>
    <input type="hidden" id="hdIdaudiencia" value="" runat="server" />
    <input type="hidden" id="hdIdUsuario" value="" runat="server" />

</div>
<div class="botonera text-center">
    <div class="btn btn-primary"><a id="btnRegCompromisos" runat="server" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
</div>
<script type="text/javascript">
    if ($(document).ready(function () {
         $.getScript("../../Scripts/AudienciasFunciones.js", function () {
                 $.getScript("../../Scripts/AudienciasAcciones.js", function () {
                });
        });
    }));
</script>
