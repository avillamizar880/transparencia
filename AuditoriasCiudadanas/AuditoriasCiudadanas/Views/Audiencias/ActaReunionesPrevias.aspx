<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActaReunionesPrevias.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.ActaReuniones" %>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../../Content/logo-nav.css" rel="stylesheet" />
<link href="../../Content/screenView.css" rel="stylesheet" />
<link href="../../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" />
<link href="../../Content/fileinput.css" rel="stylesheet" />

<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../../Scripts/bootstrap-datetimepicker.js"></script>
<script src="../../Scripts/bootstrap-datetimepicker.es.js"></script>
<script src="../../Scripts/jquery.blockUI.js"></script>
<script src="../../Scripts/ajaxPost.js"></script>
<script src="../../Scripts/fileinput.js" type="text/javascript" ></script>
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
           <%-- <div class="btn btn-info"><a href=""><span class="glyphicon glyphicon-camera"></span> SUBIR FOTO DE LA ASISTENCIA</a></div>--%>
            <div><input id="btnUploadImg" name="btnUploadImg[]" type="file" multiple class="file-loading"></div>
        </div>
         <!--BOTONERA-->
  <!--BOTONERA-->
             <div class="botonera text-center">
              
              <div class="btn btn-primary"><a id="btnGuardarActa"><span class="glyphicon glyphicon-camera"></span> GUARDAR</a></div>
             
             </div>
        </div>

        <div id="divPdf" class="hideObj">
        <form id="loginForm" target="myFrame"  action="DescargaFormato_ajax" method="POST">
         <input type="submit">
        </form>
        <iframe name="myFrame" src="#">
        </iframe>
        </div>
<script type="text/javascript">
    if ($(document).ready(function () {
         $.getScript("../../Scripts/AudienciasFunciones.js", function () {
                 $.getScript("../../Scripts/AudienciasAcciones.js", function () { });
    });
    }));
</script>
<script type="text/javascript">
    var $input = $("#btnUploadImg");
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
    
    $input.fileinput({
        //uploadUrl: "ActaReunionesPrevias_ajax", // server upload action
        showUpload: false,
        maxFileCount: 1,
        mainClass: "btnLink",
        uploadIcon: '<i class="glyphicon glyphicon-upload text-info"></i>',
        uploadTitle: 'Upload file',
        uploadClass: 'btn btn-xs btn-default',
        browseLabel: "Cargar Imagen",

      });
    $("#btnGuardarActa").click(function () {
        $input.fileinput("upload");
    });
</script>

<%-- <script type="text/javascript">

     $(document).ready(function () {
         $('#fileupload').fileupload({
             dataType: 'json',
             maxNumberOfFiles: 1,
             autoUpload: false,
             add: function (e, data) {
                 $("#btnGuardarActa").on("click", function () {
                     data.submit();
                 })
             }
         }).on('fileuploadsubmit', function (e, data) {
             console.log(data);
         });


     });
</script>--%>






