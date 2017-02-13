<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEncuestaCaractGenerar.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.AdminEncuestaCaractGenerar" %>

<script type="text/javascript">
			$(document).ready(function() {
			    //CargarDetalleTarea();
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

<%--GENERAR NOTIFICACIÓN--%>
<%--<div class="container">
    <h1 class="text-center">Encuesta de Caracterización</h1>
    <h2 class="text-center">Generar notificación</h2>
    <div class="center-block w60">
        <div class="jumbotron">
          <div class="container">
                    <p>¿Está seguro de que desea enviar una notificación a todas las personas que no han realizado la encuesta de caracterización?</p>
                    <div class="botonera text-center">
                        <div class="btn btn-primary">Cancelar </div>
                        <div class="btn btn-primary">Generar Notificación </div>
                    </div>
          </div>
        </div>
    </div>
</div>--%>


<div class="container">
    <h1 class="text-center">Encuesta de Caracterización</h1>
    <h2 class="text-center">Generar corte</h2>
    <div class="center-block w60">
        <div class="jumbotron">
          <div class="container">
          <%--PENDIENTE ARREGLAR CORTE ENCUESTA. FECHA INICIO Y FECHA FIN DEL CORTE PARA GUARDAR DATOS.--%>
                    <p>¿Está seguro de que desea generar un corte de las encuestas de caracterización?</p>
                    <div class="botonera text-center">
                        <div class="btn btn-primary">Cancelar </div>
                        <div class="btn btn-primary">Generar corte </div>
                    </div>
          </div>
        </div>
    </div>
</div>

