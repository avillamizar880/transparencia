<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActaReuniones.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.ActaReuniones" %>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../../Content/logo-nav.css" rel="stylesheet">
<link href="../../Content/screenView.css" rel="stylesheet" type="text/css">
<link href="../../Content/jquery.fileupload.css" rel="stylesheet" />
	<link href="../../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css">
    <link href="../../Content/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css">
<!-- /.container -->
    <!-- Page Content -->
    <div class="container">
      <input type="text" class="hidden" id="hfTipoAudiencia" runat="server" />
    <h1 id="hTitulo" runat="server" class="text-center">Acta de Reuniones previas</h1>
        <div style="float:left;" role="button"><a id="btnDescargaFormato">Descargar formato</a></div>
        <div class="w60 center-block">
            <div class="form-group">
                <label for="txtAsunto">Tema a tratar</label>
                <textarea class="form-control" rows="3" id="txtTema" runat="server"></textarea>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="txtLugar">Lugar</label>
                        <input type="text" class="form-control aclugar" id="txtLugar" runat="server">
                        <input type="hidden" id="hdIdMunicipio" runat="server" />
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
            <div class="btn btn-info" >
                <span class="fileinput-button">
                    <i class="glyphicon glyphicon-camera"></i>
                    <span>SUBIR FOTO DE LA ASISTENCIA</span>
                    <input id="fileupload" type="file" name="files[]" multiple>
               </span>
            </div>
            <div id="progress" class="progress">
                <div class="progress-bar progress-bar-success"></div>
            </div>
            <div id="files" class="files">nombre archivos</div>
            <!--BOTONERA-->
            <div class="botonera text-center">
                <div class="btn btn-primary"><a id="btnGuardarActa"><span class="glyphicon glyphicon-camera"></span> GUARDAR</a></div>
            </div>
        </div>
        
        
    </div>
<div id="divPdf" class="hideObj">
<form id="loginForm" target="myFrame"  action="DescargaFormato_ajax" method="POST">
 <input type="submit">
</form>
<iframe name="myFrame" src="#">
</iframe>
</div>

<!-- /.container -->
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/jquery-ui-1.12.1.min.js"></script>
<script src="../../Scripts/jquery.iframe-transport.js"></script>
<script src="../../Scripts/jquery.fileupload.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<%--<script type="text/javascript" src="../../Scripts/bootstrap-datetimepicker.js" charset="UTF-8"></script>
<script type="text/javascript" src="../../Scripts/js/bootstrap-datetimepicker.es.js" charset="UTF-8"></script>--%>
<script src="../../Scripts/jquery.blockUI.js"></script>
<script src="../../Scripts/ajaxPost.js"></script>
<script src="../../Scripts/AudienciasFunciones.js"></script>
<script src="../../Scripts/AudienciasAcciones.js"></script>

<%--<script type="text/javascript">
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
</script>--%>
<%--<script>
    'use strict';
    $(function () {
        $('#fileupload').fileupload({
            dataType: 'json',
            url: 'UploadImages/',
            done: function (e, data) {
                $.each(data.result.files, function (index, file) {
                    $('<p/>').text(file.name).appendTo('#files');
                });
            },
            progressall: function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                $('#progress .progress-bar').css(
                    'width',
                    progress + '%'
                );
            }
        }).prop('disabled', !$.support.fileInput)
        .parent().addClass($.support.fileInput ? undefined : 'disabled');
        
    });
</script>--%>
<script>
    $(document).ready(function () {
            $('#fileupload').fileupload({
            url: 'ActaReuniones_ajax',
            formData: { tipo_audiencia:'inicio'},
            submit: function (e, data) { },
            done: function (e, data) {
                alert("hecho");
                //var rta = data.result;
                //$.each(data.result.files, function (index, file) {
                //    $('<p/>').text(file.name).appendTo('#files');
                //});
            },
            progressall: function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                $('#progress .progress-bar').css(
                    'width',
                    progress + '%'
                );
            },
            add: function (e, data) {
                var uploadErrors = [];
                var acceptFileTypes = /(\.|\/)(pdf)$/i;
                if (data.files[0]['size'] && data.files[0]['size'] / 1024 / 1024 > 10) {
                    uploadErrors.push('Tamaño de archivo excede el máximo permitido');

                }
                if (uploadErrors.length > 0) {
                    alert(uploadErrors.join("<br>"));
                } else {
                    data.submit();
                }
            }
            });

            //$("#fileupload").click();
    });

    
    $("#btnGuardarActa").click(function () {
        $("#fileupload").click();
    });
</script>


