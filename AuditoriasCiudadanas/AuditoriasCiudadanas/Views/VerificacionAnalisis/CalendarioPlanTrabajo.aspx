<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalendarioPlanTrabajo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.VerificacionAnalisis.CalendarioPlanTrabajo" %>

<div id="divCalendarioPlanTrabajoGrupo"class="container">
    <h1 class="text-center">Calendario</h1>
    <div id="wrap">
	    <div id="calendar"></div>
	</div>    	
</div>  

<script type="text/javascript">
    if ($(document).ready(function () {
         $.getScript('../Scripts/Calendario.js', function () {
           MostrarCalendario();
    });
    }));
</script>