<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preg_frecuentes.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Proyectos.preg_frecuentes" %>
<div id="divDatos">
    <input type="hidden" id="hdIdCuestionario" value="" runat="server" />
    <input type="hidden" id="hdIdUsuario" value="" runat="server" />
</div>
<div id="divListadoPreguntas" runat="server">
    <div id="divPreliminarVista" runat="server">
    </div>
    <div id="divAdicional" class="container encuestaview">
        <div class="center-block w60">
            <label>Fuente:</label>
            <br>
            <p>Preguntas Frecuentes SGR, Consultado el día 7 de marzo de 2017: <a role="button" onclick="javascript:fnVentanaEmergente('https://www.sgr.gov.co/Contacto/PreguntasFrecuentes.aspx','Preguntas frecuentes');">https://www.sgr.gov.co/Contacto/PreguntasFrecuentes.aspx</a></p>
        </div>
    </div>
</div>
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("../../Scripts/ConfigEncuestasFunciones.js", function () {
        $.getScript("../../Scripts/ConfigEncuestasAcciones.js", function () {
            ajaxPost('../Views/Proyectos/preg_frecuentes_ajax', null, null, function (r) {
            var datosEvalProyecto = htmlUnescape(r);
            eval((datosEvalProyecto));

            }, function (r) {
                bootbox.alert(r.responseText);
            });
    });
    });
        
    }));
</script>
