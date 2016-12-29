<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallePlanTrabajo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.VerificacionAnalisis.DetallePlanTrabajo" %>

<script type="text/javascript">
			$(document).ready(function() {
			    CargarDetalleTarea();
			});
			$('.form_datetime').datetimepicker({
			    language: 'es',
			    weekStart: 1,
			    todayBtn: 1,
			    autoclose: 1,
			    todayHighlight: 1,
			    startView: 2,
			    forceParse: 0,
			    showMeridian: 1
			});
			$('.form_date').datetimepicker({
			    language: 'es',
			    weekStart: 1,
			    todayBtn: 1,
			    autoclose: 1,
			    todayHighlight: 1,
			    startView: 2,
			    minView: 2,
			    forceParse: 0
			});
			$('.form_time').datetimepicker({
			    language: 'es',
			    weekStart: 1,
			    todayBtn: 1,
			    autoclose: 1,
			    todayHighlight: 1,
			    startView: 1,
			    minView: 0,
			    maxView: 1,
			    forceParse: 0
			});
</script>

    <!-- MIGA DE PAN -->
    <div class="container">
    	<div class="row">
    	<ol class="breadcrumb">
          <li><a href="#">Inicio</a></li>
          <li><a href="" onclick="cargaMenu('VerificacionAnalisis/PlanTrabajo','dvPrincipal')">Tareas</a></li>
          <li class="active">Nombre de la Tarea</li>
        </ol>
        </div>
    </div>
    <!-- Page Content -->
    <div class="container generalInfo">
        <input type="hidden" id="hfidTarea" runat="server"/>
    	<div class="row">
        	<div class="headSection">
            	<div class="col-sm-12 headTit">
                    <span>TAREA</span>
                </div>
              <div class="col-sm-9">
                <h3 id="txtDetalleTarea">Visita con registro fotográfico</h3>
                <div class="row">
                    <div id="fechaTarea" class=" col-sm-6"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;05/07/2020</div>
                   <div id="horaTarea" class=" col-sm-6"><span class="glyphicon glyphicon-time"></span> Hora:&nbsp; 00:00hrs </div>
               	</div>
               </div>
                <div class="col-sm-3 userActions">
            	<div id="btnFinalizar" onclick="FinalizarTarea()" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-ok"></span><span>Finalizar</span></div>
                <div id="btnEliminar" onclick="EliminarTarea()" class="btn btn-default  btn-lg"><span class="glyphicon glyphicon-trash"></span>Eliminar</div>
            </div>
              </div>
		</div>
        <div class="row">
        	<div class="col-sm-3">
            	<div class="leftMenu">
            <!--TABS-->
                <ul class="nav nav-tabs nav-stacked">
                  <li class="active"><a data-toggle="tab" href="#tab1">Descripción<span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab3">Resultado de la Tarea<span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#regMultimedia">Registro Multimedia<span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <%--<li><a data-toggle="tab" href="#tab2">Observación Tarea<span class="glyphicon glyphicon-menu-right"></span></a></li>--%>
                </ul>
                </div>
			</div>
            <div class="col-sm-9">
            	<div class="generalInfo">
                	<div class="tab-content">
                    	<!--CONTENT1 Descripción-->
                      <div id="tab1" class="tab-pane fade in active">
                      <h4>Descripción 
                      <div id="btnAnadirDescripcion" onclick="AnadirDescripcionTarea()" class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-plus"></span> Agregar descripción</a></div> &nbsp;
                      <div id="btnEditarDescripcion" onclick="EditarDescripcionTarea()" class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-pencil"></span> Editar descripción</a></div>
                      </h4>
                      	<div class="well">
                        	<div id="fechaDescripcion" class="wrap"><span class="glyphicon glyphicon-calendar"></span></div>
                            <!--DESC-->
                            <p id="descripcionTarea"></p>
                            </div>
                      </div>
                       <!--CONTENT3 Opinion-->
                      <div id="tab3" class="tab-pane fade">
                        <h4>Resultado de la Tarea 
                        <div id="btnAnadirResultadoTarea" onclick="AnadirResultadoTarea()" class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-plus"></span> Agregar Resultado de la Tarea</a></div>
                        <div id="btnEditarResultadoTarea" onclick="EditarResultadoTarea()" class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-plus"></span> Editar  Resultado de la Tarea</a></div>
                        </h4>
                        <div class="well">
                        	<div class="wrap" id="fechaResultadoTarea"><span class="glyphicon glyphicon-calendar"></span></div>
                            <!--DESC-->
                            <p id="resultadoTarea"></p>
                            </div>
                      </div>
                       <!--CONTENT4 Reg. Fotográfico-->
                      <div id="regMultimedia" class="tab-pane fade regMultimedia"></div>
                   	</div>
                </div>
            </div>
        </div>
    </div>
    <!-- NUEVA DESCRIPCIÓN -->
    <div class="modal fade" id="myModalDescripcionTarea" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>
    <!-- NUEVA OPINIÓN -->
    <div class="modal fade" id="myModalResultadoTarea" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>
    <!-- NUEVA REGISTRO MULTIMEDIA -->
    <div class="modal fade" id="nuevoRegistroMul" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>
<%--</body>--%>
<%--</html>--%>