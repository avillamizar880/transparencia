<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preg_frecuentes.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Proyectos.preg_frecuentes" %>
<div id="divDatos">
    <input type="hidden" id="hdIdCuestionario" value="" runat="server" />
    <input type="hidden" id="hdIdUsuario" value="" runat="server" />
</div>
<div id="divListadoPreguntas" runat="server">
    <div id="divPreliminarVista" runat="server">
    </div>
</div>
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("../../Scripts/ConfigEncuestasFunciones.js", function () {
        $.getScript("../../Scripts/ConfigEncuestasAcciones.js", function () {
              obtPreguntasAyuda();
    });
    });
        
    }));
</script>
