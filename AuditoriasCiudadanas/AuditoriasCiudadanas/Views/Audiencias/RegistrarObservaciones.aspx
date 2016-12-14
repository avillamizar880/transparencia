<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarObservaciones.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.RegistrarObservaciones" %>
<!-- Custom CSS -->
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../../Content/logo-nav.css" rel="stylesheet" />
<link href="../../Content/screenView.css" rel="stylesheet" />
<link href="../../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" />
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../../Scripts/bootstrap-datetimepicker.js"></script>
<script src="../../Scripts/bootstrap-datetimepicker.es.js"></script>
<script src="../../Scripts/jquery.blockUI.js"></script>
<script src="../../Scripts/ajaxPost.js"></script>
<div class="container">
    <h1>Informe con observaciones</h1>
    <div class="w60 center-block">
        <div class="form-group">
            <label for="txtInfoCompleta">¿El proyecto tiene la información completa cargada al aplicativo?</label>
            <input type="text" class="form-control" id="txtInfoCompleta">
        </div>
        <div class="form-group">
            <label for="txtInfoClara">¿La información NO es clara y debe haber una explicación en la Audiencia de Inicio?</label>
            <input type="text" class="form-control" id="txtInfoClara">
        </div>
        <div class="form-group">
            <label for="txtComunidad">¿La comunidad beneficiaria tiene alguna duda importante sobre el proyecto y su alcance?</label>
            <input type="text" class="form-control" id="txtComunidad">
        </div>
        <div class="form-group">
            <label for="txtDudas">¿Qué dudas deben ser resueltas en la Audiencia de Inicio para que su trabajo de control social tenga herramientas suficientes para continuar?</label>
            <input type="text" class="form-control" id="txtDudas">
        </div>
        <div class="row">
            <div class="col-sm-12">
                <h4>Propuestas de Fechas sobre Audiencias posteriores</h4>
                <p>Como resultado de este primer y conociendo el detalle del proyecto, se podrían por parte del Grupo Auditor Ciudadano las fechas posteriores de las audiencias de seguimiento(s) y de cierre.</p>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label for="tipo_audiencia_1">Audiencia</label>
                    <select class="form-control" id="tipo_audiencia_1">
                        <option>Seleccione el tipo de Audiencia</option>
                        <option>Seguimiento</option>
                        <option>Cierre</option>
                    </select>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label for="tipo_audiencia_2">Audiencia</label>
                    <select class="form-control" id="tipo_audiencia_2">
                        <option>Seleccione el tipo de Audiencia</option>
                        <option>Seguimiento</option>
                        <option>Cierre</option>
                    </select>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <div class="form-group">
                    <label for="fecha_posterior_1" class="control-label">Fecha</label>
                    <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_1" data-link-format="yyyy-mm-dd">
                        <input class="form-control" size="16" type="text" value="" readonly>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>
                    <input type="hidden" id="fecha_posterior_1" value="" /><br />
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label for="fecha_posterior_2" class="control-label">Fecha</label>
                    <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_2" data-link-format="yyyy-mm-dd">
                        <input class="form-control" size="16" type="text" value="" readonly>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>
                    <input type="hidden" id="fecha_posterior_2" value="" /><br />
                </div>
            </div>
        </div>
        <!--BOTONERA-->
        <div class="botonera text-center">
            <div class="btn btn-primary"><a id="btnRegObservaciones" runat="server" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
        </div>
    </div>
</div>
<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/AudienciasFunciones.js", function () {
                $.getScript("../../Scripts/AudienciasAcciones.js", function () {
            });
        });
    }));
</script>
<script type="text/javascript">
        $('.form_datetime').datetimepicker({
            language:  'es',
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

