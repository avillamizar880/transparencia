<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEncuestaCaractCorte.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.AdEncuestaCaract" %>
<%--CORTES DE INFORMACIÓN--%>
<div class="container">
    <h1 class="text-center">Encuesta de Caracterización</h1>
    <h2 class="text-center">Cortes de información</h2>
    <%--<div class="center-block w60">
        <div class="jumbotron">
          <div class="container">
                    <p>¿Está seguro de que desea terminar la encuesta de caracterización?</p>
                    <p> Tenga en cuenta que esto impedirá que se diligencie la encuesta.</p>
                    <div class="botonera text-center">
                        <div class="btn btn-primary">Cancelar </div>
                        <div class="btn btn-primary">Terminar encuesta </div>
                    </div>
          </div>
        </div>
    </div>--%>
</div>
<div class="container">
    <div class="list-group-item uppText">
        <div class="col-sm-1" hidden="hidden"><p class="list-group-item-text"><a href="#">tere</a></p></div>
        <div class="col-sm-2"><a href="#"><span class="glyphicon glyphicon-download-alt"></span></a></div>
        <div class="col-sm-8"><p class="list-group-item-text"><span class="label label-info">Respuesta del fecha inicial al fecha final</span><br /><span>Encontramos en este documento la respuesta a la encuesta de caracterización realizada durantes las fechas específicas.</span></p></div>
        <div class="col-sm-1"><span>#</span><br /><span>Encuestados</span></div>
    </div>
    <div class="list-group-item uppText">
        <div class="col-sm-1" hidden="hidden"><p class="list-group-item-text"><a href="#">tere</a></p></div>
        <div class="col-sm-2"><a href="#"><span class="glyphicon glyphicon-download-alt"></span></a></div>
        <div class="col-sm-8"><p class="list-group-item-text"><span class="label label-info">Respuesta del fecha inicial al fecha final</span><br /><span>Encontramos en este documento la respuesta a la encuesta de caracterización realizada durantes las fechas específicas.</span></p></div>
        <div class="col-sm-1"><span>#</span><br /><span>Encuestados</span></div>
    </div>
    <div class="list-group-item uppText">
        <div class="col-sm-1" hidden="hidden"><p class="list-group-item-text"><a href="#">tere</a></p></div>
        <div class="col-sm-2"><a href="#"><span class="glyphicon glyphicon-download-alt"></span></a></div>
        <div class="col-sm-8"><p class="list-group-item-text"><span class="label label-info">Respuesta del fecha inicial al fecha final</span><br /><span>Encontramos en este documento la respuesta a la encuesta de caracterización realizada durantes las fechas específicas.</span></p></div>
        <div class="col-sm-1"><span>#</span><br /><span>Encuestados</span></div>
    </div>
</div>

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

<%--TERMINAR ENCUESTA--%>
<%--<div class="container">
    <h1 class="text-center">Encuesta de Caracterización</h1>
    <h2 class="text-center">Terminar encuesta</h2>
    <div class="center-block w60">
        <div class="jumbotron">
          <div class="container">
                    <p>¿Está seguro de que desea terminar la encuesta de caracterización?</p>
                    <p> Tenga en cuenta que esto impedirá que se diligencie la encuesta.</p>
                    <div class="botonera text-center">
                        <div class="btn btn-primary">Cancelar </div>
                        <div class="btn btn-primary">Terminar encuesta </div>
                    </div>
          </div>
        </div>
    </div>
</div>--%>
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("../../Scripts/EncuestaCaracterizacion.js", function () {
          
        });
    }));
</script>
