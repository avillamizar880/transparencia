<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="envioEncuesta.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Valoracion.envioEncuesta" %>
<div id="divDatos">
    <input type="hidden" id="hdIdCuestionario" value="" runat="server" />
    <input type="hidden" id="hdIdUsuario" value="" runat="server" />
</div>
<div id="divListadoPreguntas" runat="server">
    <div id="divPreliminarVista" runat="server">
    </div>
</div>
<div>

</div>
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("../../Scripts/ConfigEncuestasFunciones.js", function () {
        $.getScript("../../Scripts/ConfigEncuestasAcciones.js", function () {
           	  var id_cuestionario = $("#hdIdCuestionario").val();
              var params = { id_cuestionario: id_cuestionario };
              envioPreguntas_ini(params);
    });
    })
        
    }));
</script>