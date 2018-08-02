<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanTrabajo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.VerificacionAnalisis.PlanTrabajo" %>
<div>
        <input type="hidden" id="hfcodigoBPIN" runat="server"/>
        <input type="hidden" id="hfidGac" runat="server"/>
        <input type="hidden" id="hfidUsuario" runat="server"/>
         <div class="form-group text-left">
                <form class="formulario">
                </form>
        </div>
        <div class="list-group-item">
                <div class="col-sm-2">
                    <strong>Tipo de Tarea</strong>
                </div>
                <div class="col-sm-2">
                    <strong>Responsable</strong>
                </div>
                 <div class="col-sm-2">
                    <strong>Fecha</strong>
                </div>
                <div class="col-sm-2">
                    <strong>Fecha Cierre</strong>
                </div>
                 <div class="col-sm-2">
                    <strong>Detalle</strong>
                </div>
        </div>
        <div id="datosPlanTrabajo" class="clearfix"></div>
    <div class="col-sm-10">
        <div id='AnadirTarea' onclick='AnadirTarea()' class='btn btn-info fr'><a data-toggle='modal' data-target='#myModal'><span class='glyphicon glyphicon-plus'></span>Agregar Tarea</a></div>
        
    </div>
    <div id='VerCalendario' onclick='OcultarPlanTrabajo()' class='btn btn-info fr'><a data-toggle='modal' data-target='#myModal'><span class='glyphicon glyphicon-calendar'></span>Ver Calendario</a></div>
        
 </div>
<%--MODAL PARA AÑADIR TIPO DE TAREA--%>
<div class="modal fade" id="myModalIngresarTarea" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>
<%--</body>--%>
<%--</html>--%>
<script type="text/javascript">
    if ($(document).ready(function () {
         $.getScript('../Scripts/PlanTrabajo.js', function () {
           CargarPlanesTrabajo();
    });
    }));
</script>

