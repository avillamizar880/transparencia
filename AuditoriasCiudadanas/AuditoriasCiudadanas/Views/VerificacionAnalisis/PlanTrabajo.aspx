<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanTrabajo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.VerificacionAnalisis.PlanTrabajo" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Plan de trabajo</title>--%>
     <%-- Archivos CSS--%>
<%--        <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
        <link href="../../Content/logo-nav.css" rel="stylesheet" />
        <link href="../../Content/screenView.css" rel="stylesheet" />--%>
       
      <%-- Archivos JS--%>
<%--        <script src="../../Scripts/jquery-1.12.4.min.js" type="text/javascript" ></script>
        <script src="../../Scripts/jquery-ui-1.12.1.js" type="text/javascript" ></script>
        <script src="../../Scripts/jquery.blockUI.js" type="text/javascript" ></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <script src="../../Scripts/PlanTrabajo.js" type="text/javascript"></script>  --%>
<%--</head>--%>
<%--<body class="inside" onload="CargarPlanesTrabajo()">--%>

		<script type="text/javascript">
			$(document).ready(function() {
			    CargarPlanesTrabajo();
			});
		</script>

 <div class="container" onload="CargarPlanesTrabajo()" >
    	<h1 class="text-center">Plan de trabajo</h1>
        <div id="datosPlanTrabajo" class="clearfix"></div>
 </div>
<%--MODAL PARA AÑADIR TIPO DE TAREA--%>
<div class="modal fade" id="ingresarPlanProyecto" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="myModalLabel">Añadir Tipo de Tarea</h4>
          </div>
          <div class="modal-body">
              <label class="modal-title">Tipo de Tareas</label>
              <select id="selTiposTareas" class="form-control">
                                <option>Diario de campo con registro fotográfico</option>
                                <option>Visitas</option>
                                <option>Reuniones</option>
                                <option>Entrevista</option>
                                <option>Compromisos por parte de terceros</option>
                    </select>
                    <label class="modal-title">Nombres y apellidos</label>
                    <select id="selNombresApellidos" class="form-control">
                                <option>...</option>
                                <option>Fulano</option>
                                <option>Sultano</option>
                                <option>Mengano</option>
                                <option></option>
                    </select>
                    <label class="modal-title">Fecha</label><br />
                    <input type="datetime" />
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
            <button type="button" class="btn btn-primary" >Guardar</button>
          </div>
        </div>
      </div>
</div>

<%--</body>--%>
<%--</html>--%>
