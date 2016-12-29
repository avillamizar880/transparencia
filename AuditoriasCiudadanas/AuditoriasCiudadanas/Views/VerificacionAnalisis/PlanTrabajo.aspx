<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanTrabajo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.VerificacionAnalisis.PlanTrabajo" %>

<script type="text/javascript">
			$(document).ready(function() {
			    CargarPlanesTrabajo();
			});
</script>
 <div class="container" >
        <input type="hidden" id="hfcodigoBPIN" runat="server"/>
        <input type="hidden" id="hftipoAudiencia" runat="server"/>
        <input type="hidden" id="hfidAudiencia" runat="server"/>
    	<h1 class="text-center">Plan de trabajo</h1>
        <div id="datosPlanTrabajo" class="clearfix"></div>
        <div id='AnadirTarea' onclick='AnadirTarea()' class='btn btn-info fr'><a href='' data-toggle='modal' data-target='#myModal' ><span class='glyphicon glyphicon-plus'></span>Agregar Tarea</a></div>
 </div>
<%--MODAL PARA AÑADIR TIPO DE TAREA--%>
<div class="modal fade" id="myModalIngresarTarea" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>
<%--</body>--%>
<%--</html>--%>
