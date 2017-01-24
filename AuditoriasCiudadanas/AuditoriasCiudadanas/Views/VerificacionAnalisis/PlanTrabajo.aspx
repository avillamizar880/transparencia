<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanTrabajo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.VerificacionAnalisis.PlanTrabajo" %>
<div class="container" >
        <input type="hidden" id="hfcodigoBPIN" runat="server"/>
        <input type="hidden" id="hftipoAudiencia" runat="server"/>
        <input type="hidden" id="hfidUsuario" runat="server"/>
        <div class="alert alert-info">
             <span class="glyphicon glyphicon-info-sign XLtext"></span>
             <span>En este plan se registran las actividades que se propone realizar el grupo auditor a partir del análisis de la información del proyecto. Debería definir actividades, responsables y tiempos.</span>
         </div>
         <div class="form-group text-left">
                <form class="formulario">
				    <input type="radio" name="opcPlanTrabajo" checked="checked" id="r_ReunionPrevia">
				    <label for="r_ReunionPrevia" onclick="CargarPlanTrabajoXOpcion('REUNION PREVIA')"><span class="btn"><span class="glyphicon glyphicon-bullhorn"> Reunión Previa</span></span></label>

                    <input type="radio" name="opcPlanTrabajo" id="r_Inicio">
				    <label for="r_Inicio" onclick="CargarPlanTrabajoXOpcion('INICIO')"><span class="btn"><span class="glyphicon glyphicon-dashboard"> Inicio</span></span></label>

                     <input type="radio" name="opcPlanTrabajo" id="r_Seguimiento">
				    <label for="r_Seguimiento" onclick="CargarPlanTrabajoXOpcion('SEGUIMIENTO')"><span class="btn"><span class="glyphicon glyphicon-tasks"> Seguimiento</span></span></label>

                    <input type="radio" name="opcPlanTrabajo" id="r_Cierre">
				    <label for="r_Cierre" onclick="CargarPlanTrabajoXOpcion('CIERRE')"><span class="btn"><span class="glyphicon glyphicon-ok-circle"> Cierre</span></span></label>
                </form>
            </div>
        <div id="datosPlanTrabajo" class="clearfix"></div>
    <div class="col-sm-9">
        <div id='AnadirTarea' onclick='AnadirTarea()' class='btn btn-info fr'><a data-toggle='modal' data-target='#myModal'><span class='glyphicon glyphicon-plus'></span>Agregar Tarea</a></div>
    </div>
        
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

