<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEncuestaCaractCorte.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.AdEncuestaCaract" %>
<%--CORTES DE INFORMACIÓN--%>
<div class="container">
    <h1 class="text-center">Encuesta de Caracterización</h1>
    <h2 class="text-center">Cortes de información</h2>  
</div>
<div class="container">
    <div class="center-block">
          <div class="container">
              <div class="row">
                <div class="col-sm-6">
                    <label for="fecha_posterior_2" class="control-label">Fecha Inicio:</label>
                    <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_2" data-link-format="yyyy-mm-dd">
                        <input id="dtpFechaInicio" class="form-control" size="16" type="text" value="" readonly>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>
                    <input type="hidden" id="fecha_posterior_2" value="" />
                </div>
                <div class="col-sm-6">
                    <label for="fecha_posterior_3" class="control-label">Fecha Fin:</label>
                    <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_3" data-link-format="yyyy-mm-dd">
                        <input id="dtpFechaFin" class="form-control" size="16" type="text" value="" readonly>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>
                    <input type="hidden" id="fecha_posterior_3" value="" />
                 </div>
              </div>
              <div class="row">
                  <div class="btn btn-primary" onclick="ObtenerResultadosFechaCorte()">Generar corte </div>
              </div>
          </div>
    </div>
    <div id="datosFechaCorte" class="list-group-item uppText"/>
</div>
<div id="divOtros">

</div>
 <script type="text/javascript">
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
			$(document).ready(function ()
			{
			    CargarDatosInicialReporte();
            });
</script>