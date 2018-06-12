<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicarCampanas.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.Campanas" %>
<div id="divPrincipalCampanas" class="container">
       <h1 class="text-center">Campañas</h1>
         <div class="well text-center">
         	<div id='AnadirCampana' onclick='AnadirCampana()' class="btn btn-info mb15"><a data-toggle='modal' data-target='#myModal'><span class="glyphicon glyphicon-plus"></span> Nueva Campaña</a></div>  
         </div>
        <div class="list-group">
          <h4 id="datosEncontradosCampanasPublicadas" class="text-center"></h4>
          </div>
         <div class="noticiasBox">
          <div id="datosCampanasPublicadas" class="list-group"></div>
         </div>
        <!--PAGINACIÓN-->
       <div class="col-md-12 text-center">
           <nav id="navegadorResultadosCampanasPublicadas" aria-label="Page navigation">
              <ul  id="paginadorCampanasPublicadas" class="pagination"></ul>
            </nav>
           <p id="paginaActualCampanasPublicadas" hidden="hidden">0</p>
           <p id="ultimaPaginaCampanasPublicadas" hidden="hidden">0</p>
       </div>
     <input type="hidden" id="hdIdUsuario" runat="server" />
</div> <%--Fin div Container--%>
<%--<div class="modal fade" id="myModalIngresarCampana" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>--%>
<div class="container hideObj" id="divPrincipalAnadirCampana">
       <div class="plantillasHeader">
            <h5>
                <a id="btnVolverListadoAdmin" role="button" onclick="volverListadoNoticiasCampanas('divPrincipalAnadirCampana','divPrincipalCampanas');"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER A NOTICIAS</a>
            </h5>
       </div>
       <h1 id="tituloAnadirCampana" class="text-center">Añadir Campaña</h1>
        <div class="modal-body">
        <input type="hidden" id="hfidCampanaModal" runat="server"/>
        <input type="hidden" id="hfidUsuarioCampanaModal" runat="server"/>
        <div class="form-group">
            <label class="modal-title">Título</label>
            <textarea id="txtTituloCampana" placeholder="Describa el título de la campaña ..." class="form-control" rows="5" ></textarea>
            <div id="errorTituloCampana" class="alert alert-danger alert-dismissible" hidden="hidden">El título de la campana no puede ser vacío.</div>
            <div id="errorTituloCampanaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El título de la campana no puede contener el caracter *.</div>
            <label for="fechaCampanaInput" class="control-label">Fecha</label>
            <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fechaCampanaInput" data-link-format="yyyy-mm-dd">
                <input id="dtpFechaCampana" class="form-control" size="16" type="text" value="" readonly>
                <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
            </div>
            <input type="hidden" id="fechaCampanaInput" value="" />
        </div>
        <div id="errorFechaCampana" class="alert alert-danger alert-dismissible" hidden="hidden" >La fecha de la campana no puede ser vacía.</div>
        <label class="modal-title">Resumen</label>
        <textarea id="txtResumenCampana" placeholder="Describa el detalle de la campaña ..." class="form-control" rows="5" ></textarea>
        <div id="errorResumenCampana" class="alert alert-danger alert-dismissible" hidden="hidden">El detalle de la campaña no puede ser vacío.</div>
        <div id="errorResumenCampanaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El detalle de la campaña no puede contener el caracter *.</div>
        <label class="modal-title">Enlace donde se encuentra la campaña</label>
        <textarea id="txtUrlCampana" placeholder="Ingrese el enlace (link) donde se encuentra la campaña ..." class="form-control" rows="5" ></textarea>
         </div>
         <div class="modal-footer">
         <button id="btnGuardar" onclick="GuardarCampana()" type="button" class="btn btn-primary">Guardar</button>
         </div>
       
</div> 
<div class="container hideObj" id="divPrincipalAnadirRecursoMultimediaCampanaEditar">
       <input type="hidden" id="hfIdDetalleRecursoMultCampanaEditar" runat="server"/>
       <input type="hidden" id="hfIdRecursoMultCampanaEditar" runat="server"/>
       <input type="hidden" id="hfidUsuarioRecursoMultiCampanaEditar" runat="server"/>
       <div class="plantillasHeader">
            <h5>
                <a id="btnVolverListadoCampanasAdmin" role="button" onclick="volverListadoNoticiasCampanas('divPrincipalAnadirRecursoMultimediaCampanaEditar','divPrincipalCampanas');"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER A CAMPAÑAS</a>
            </h5>
       </div>
       <h1 class="text-center">Añadir Imagen Campaña</h1>
        <div class="modal-body">
          <div>
           <label class="modal-title">Imagen anterior</label><br/>
           <img id="imgAnteriorCampana" width=100 height=100>
          </div>
          <div>
           <label class="modal-title">Agregar Recurso</label><br/>
           <input id="inpsubirFotoCampanaEditar" class="file-loading" type="file" accept="image/*">
        </div>
          <div id="errorRecursoMultimediaCampanaEditar" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre del recurso no puede ser vacío.</div>
          <div class="modal-footer">
               <button id="btnGuardarRegitroFotograficoCampanaEditar" onclick="GuardarRegistroFotograficoCampanaEditar()" type="button" class="btn btn-primary">Guardar</button>
          </div>
        </div>      
</div> 
<div class="container hideObj" id="divPrincipalAnadirRecursoMultimediaCampana">
    <input type="hidden" id="hfIdDetalleRecursoMultCampana" runat="server"/>
    <input type="hidden" id="hfIdRecursoMultCampana" runat="server"/>
    <input type="hidden" id="hfidUsuarioRecursoMultiCampana" runat="server"/>
       <div class="plantillasHeader">
            <h5>
                <a id="btnVolverListadoCampanas" role="button" onclick="volverListadoNoticiasCampanas('divPrincipalAnadirRecursoMultimediaCampana','divPrincipalCampanas');"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER A CAMPAÑAS</a>
            </h5>
       </div>
       <h1 class="text-center">Añadir Imagen Campaña</h1>
        <div class="modal-body">
          <div>
           <label class="modal-title">Agregar Recurso</label><br/>
           <input id="inpsubirCampanaFoto" class="file-loading" type="file" accept="image/*">
          </div>
          <div id="errorRecursoMultimediaCampana" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre del recurso no puede ser vacío.</div>
          <div class="modal-footer">
               <button id="btnGuardarRegitroFotograficoCampana" onclick="GuardarRegistroFotograficoCampana()" type="button" class="btn btn-primary">Guardar</button>
          </div>
        </div>      
</div> 
<script type="text/javascript">
			$(document).ready(function() {
			    BuscarTotalCampanasPublicadas();
			    $('[data-toggle="tooltip"]').tooltip();
			    $("#txtPalabraClaveCampanas").keypress(function (e) {
			        if (e.which == 13)
			        {
			            BuscarTotalCampanasPublicadas();
			        }
			    });
			});
</script>
<script type="text/javascript">
   $(".form_datetime").datetimepicker({
       language: "es",
       weekStart: 1,
       todayBtn: 1,
       autoclose: 1,
       todayHighlight: 1,
       startView: 2,
       forceParse: 0,
       showMeridian: 1
   });
   $(".form_date").datetimepicker({
       language: "es",
       weekStart: 1,
       todayBtn: 1,
       autoclose: 1,
       todayHighlight: 1,
       startView: 2,
       minView: 2,
       forceParse: 0
   });
   $(".form_time").datetimepicker({
       language: "es",
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
<script type="text/javascript">
  $("#inpsubirCampanaFoto").fileinput({
                               uploadUrl: "../../Views/Administracion/DetalleRecursoMultimedia_ajax",
                               showUpload: false,
                               maxFileCount: 1,
                               showCaption: false,
                               allowedFileExtensions: ["jpg", "png", "gif", "bmp"],
                               maxFileCount: 1,
                               browseLabel: "Subir Recurso",
                               showDrag: false,
                               dropZoneEnabled: false,
                               }).on("filepreupload", function (event, data, previewId, index, jqXHR) {
                               data.form.append("idDetalleRecurso", $("#hfIdDetalleRecursoMultCampana").val());
                               data.form.append("idRecurso", $("#hfIdRecursoMultCampana").val());
                               data.form.append("rutaImagen", $("#inpsubirCampanaFoto").val());
                               data.form.append("idUsuario", $("#hfidUsuarioRecursoMultiCampana").val());
                               }).on("fileuploaded", function (event, data, id, index) {
                                   $("#inpsubirCampanaFoto").val('');
                                   volverListadoNoticiasCampanas("divPrincipalAnadirRecursoMultimediaCampana", "divPrincipalCampanas");
                               bootbox.alert("Datos cargados con éxito.")
                               });
</script>
<script type="text/javascript">
$("#inpsubirFotoCampanaEditar").fileinput({
                               uploadUrl: "../../Views/Administracion/DetalleRecursoMultimedia_ajax",
                               showUpload: false,
                               maxFileCount: 1,
                               showCaption: false,
                               allowedFileExtensions: ["jpg", "png", "gif", "bmp"],
                               maxFileCount: 1,
                               browseLabel: "Subir Recurso",
                               showDrag: false,
                               dropZoneEnabled: false,
                               }).on("filepreupload", function (event, data, previewId, index, jqXHR) {
                               data.form.append("idDetalleRecurso", $("#hfIdDetalleRecursoMultCampanaEditar").val());
                               data.form.append("idRecurso", $("#hfIdRecursoMultCampanaEditar").val());
                               data.form.append("rutaImagen", $("#inpsubirFotoCampanaEditar").val());
                               data.form.append("idUsuario", $("#hfidUsuarioRecursoMultiCampanaEditar").val());
                               }).on("fileuploaded", function (event, data, id, index) {
                                   $("#inpsubirFotoCampanaEditar").val('');
                                   volverListadoNoticiasCampanas("divPrincipalAnadirRecursoMultimediaCampanaEditar", "divPrincipalCampanas");
                               bootbox.alert("Datos cargados con éxito.")
                               });
</script>

