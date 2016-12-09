<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActaReuniones.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.ActaReuniones" %>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../../Content/logo-nav.css" rel="stylesheet">
<link href="../../Content/screenView.css" rel="stylesheet" type="text/css">
	<link href="../../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css">
    <link href="../../Content/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css">
<!-- /.container -->
    <!-- Page Content -->
    <div class="container">
    <h1 id="hTitulo" runat="server" class="text-center"></h1>
        <div class="w60 center-block">
            <div class="form-group">
                <label for="txtAsunto">Tema a tratar</label>
                <textarea class="form-control" rows="3" id="txtAsunto"></textarea>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="txtLugar">Lugar</label>
                        <input type="text" class="form-control" id="txtLugar">
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="dtp_fecha_acta" class="control-label">Fecha</label>
                        <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_fecha_acta" data-link-format="yyyy-mm-dd">
                            <input class="form-control" size="16" type="text" value="" readonly>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                        </div>
                        <input type="hidden" id="dtp_fecha_acta" value="" /><br />
                    </div>
                </div>
            </div>
            <div class="btn btn-info"><a id="btnSubirFotoActa"><span class="glyphicon glyphicon-camera"></span> SUBIR FOTO DE LA ASISTENCIA</a></div>
            <!--BOTONERA-->
            <div class="botonera text-center">
                <div class="btn btn-primary"><a id="btnGuardarActa"><span class="glyphicon glyphicon-camera"></span> GUARDAR</a></div>
            </div>
        </div>
        
        
    </div>
<!-- /.container -->
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script type="text/javascript" src="../../Scripts/bootstrap-datetimepicker.js" charset="UTF-8"></script>
<script type="text/javascript" src="../../Scripts/js/bootstrap-datetimepicker.es.js" charset="UTF-8"></script>
<script type="text/javascript">
	$('.form_date').datetimepicker({
        language:  'es',
        weekStart: 1,
        todayBtn:  1,
		autoclose: 1,
		todayHighlight: 1,
		startView: 2,
		minView: 2,
		forceParse: 0
    });
	
</script>

