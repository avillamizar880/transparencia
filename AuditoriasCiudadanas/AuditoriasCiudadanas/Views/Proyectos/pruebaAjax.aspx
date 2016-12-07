<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pruebaAjax.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Proyectos.pruebaAjax" %>
<link href="../../Content/logo-nav.css" rel="stylesheet" />
<link href="../../Content/screenView.css" rel="stylesheet" />
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/jquery.blockUI.js"></script>
<script src="../../Scripts/ajaxPost.js"></script>
<script src="../../Scripts/ProyectosFunciones.js"></script>
<div id="divBoton" style="display:table-cell;margin-top:0px;">
    <input type="button" id="btnVerProyecto" value="Ir proyecto" onclick="obtDetProyecto_3('3');" />
</div>
<div id="divContenedor" runat="server" style="background-color:aquamarine;display:inline;">

</div>
<script id="ajax"></script>

