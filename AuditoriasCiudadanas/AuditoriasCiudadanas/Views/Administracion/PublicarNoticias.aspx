<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicarNoticias.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.PublicarNoticias" %>

<div id="divPrincipalNoticias" class="container">
       <h1 class="text-center">Noticias</h1>
         <div class="well text-center">
         	<div id='AnadirNoticia' onclick='AnadirNoticia()' class="btn btn-info mb15"><a data-toggle='modal' data-target='#myModal'><span class="glyphicon glyphicon-plus"></span> Nueva Noticia</a></div>  
         </div>
        <div class="list-group">
          <h4 id="datosEncontradosNoticiasPublicadas" class="text-center"></h4>
          </div>
         <div class="noticiasBox">
          <div id="datosNoticiasPublicadas" class="list-group"></div>
         </div>
        <!--PAGINACIÓN-->
       <div class="col-md-12 text-center">
           <nav id="navegadorResultadosNoticiasPublicadas" aria-label="Page navigation">
              <ul  id="paginadorNoticiasPublicadas" class="pagination"></ul>
            </nav>
           <p id="paginaActualNoticiasPublicadas" hidden="hidden">0</p>
           <p id="ultimaPaginaNoticiasPublicadas" hidden="hidden">0</p>
       </div>
     <input type="hidden" id="hdIdUsuario" runat="server" />
</div> <%--Fin div Container--%>
<div class="container hideObj" id="divPrincipalAnadirNoticia">
       <div class="plantillasHeader">
            <h5>
                <a id="btnVolverListadoAdmin" role="button" onclick="volverListadoNoticiasCampanas('divPrincipalAnadirNoticia','divPrincipalNoticias');"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER A NOTICIAS</a>
            </h5>
       </div>
       <h1 class="text-center">Añadir Noticia</h1>
       <div class="modal-body">
			<input type="hidden" id="hfidNoticiaModal" runat="server"/>
			<input type="hidden" id="hfidUsuarioNoticiaModal" runat="server"/>
			<div class="form-group">
				<label class="modal-title">Título</label>
				<textarea id="txtTituloNoticia" placeholder="Describa el título de la noticia ..." class="form-control" rows="5" ></textarea>
				<div id="errorTituloNoticia" class="alert alert-danger alert-dismissible" hidden="hidden">El título de la noticia no puede ser vacío.</div>
				<div id="errorTituloNoticiaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El título de la noticia no puede contener el caracter *.</div>
				<label for="fechaNoticiaInput" class="control-label">Fecha</label>
				<div class="input-group date form_date datetimepicker" data-date="" data-date-format="yyyy-mm-dd" data-link-field="fechaNoticiaInput" data-link-format="yyyy-mm-dd">
					<input id="dtpFechaNoticia" class="form-control" size="16" type="text" value="" readonly>
					<span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
					<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
				</div>
				<input type="hidden" id="fechaNoticiaInput" value="" />
			</div>
			<div id="errorFechaNoticia" class="alert alert-danger alert-dismissible" hidden="hidden" >La fecha de la noticia no puede ser vacía.</div>
			    <label class="modal-title">Resumen</label>
			    <textarea id="txtResumenNoticia" placeholder="Describa el detalle de la noticia ..." class="form-control" rows="5" ></textarea>
			    <div id="errorResumenNoticia" class="alert alert-danger alert-dismissible" hidden="hidden">El detalle de la noticia no puede ser vacío.</div>
			    <div id="errorResumenNoticiaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El detalle de la noticia no puede contener el caracter *.</div>
			    <label class="modal-title">Enlace donde se encuentra la noticia</label>
			    <textarea id="txtUrlNoticia" placeholder="Ingrese el enlace (link) donde se encuentra la noticia ..." class="form-control" rows="5" ></textarea>
            </div>
            <div class="modal-footer">
				<button id="btnGuardar" onclick="GuardarNoticia()" type="button" class="btn btn-primary">Guardar</button>
            </div>
       
</div> 
<div class="container hideObj" id="divPrincipalAnadirRecursoMultimediaEditar">
       <input type="hidden" id="hfIdDetalleRecursoMultNoticiaEditar" runat="server"/>
       <input type="hidden" id="hfIdRecursoMultNoticiaEditar" runat="server"/>
       <input type="hidden" id="hfidUsuarioRecursoMultiEditar" runat="server"/>
       <div class="plantillasHeader">
            <h5>
                <a id="btnVolverListadoNoticiasAdmin" role="button" onclick="volverListadoNoticiasCampanas('divPrincipalAnadirRecursoMultimediaEditar','divPrincipalNoticias');"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER A NOTICIAS</a>
            </h5>
       </div>
       <h1 class="text-center">Añadir Imagen Noticia</h1>
        <div class="modal-body">
          <div>
           <label class="modal-title">Imagen anterior</label><br/>
           <img id="imgAnteriorNoticia" width=100 height=100>
          </div>
          <div>
           <label class="modal-title">Agregar Recurso</label><br/>
           <input id="inpsubirFotoNoticiaEditar" class="file-loading" type="file" accept="image/*">
        </div>
          <div id="errorRecursoMultimediaNoticiaEditar" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre del recurso no puede ser vacío.</div>
          <div class="modal-footer">
               <button id="btnGuardarRegitroFotograficoNoticiaEditar" onclick="GuardarRegistroFotograficoNoticiaEditar()" type="button" class="btn btn-primary">Guardar</button>
          </div>
        </div>      
</div> 
<div class="container hideObj" id="divPrincipalAnadirRecursoMultimedia">
    <input type="hidden" id="hfIdDetalleRecursoMultNoticia" runat="server"/>
    <input type="hidden" id="hfIdRecursoMultNoticia" runat="server"/>
    <input type="hidden" id="hfidUsuarioRecursoMulti" runat="server"/>
       <div class="plantillasHeader">
            <h5>
                <a id="btnVolverListadoNoticias" role="button" onclick="volverListadoNoticiasCampanas('divPrincipalAnadirRecursoMultimedia','divPrincipalNoticias');"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER A NOTICIAS</a>
            </h5>
       </div>
       <h1 class="text-center">Añadir Imagen Noticia</h1>
        <div class="modal-body">
          <div>
           <label class="modal-title">Agregar Recurso</label><br/>
           <input id="inpsubirNoticiaFoto" class="file-loading" type="file" accept="image/*">
          </div>
          <div id="errorRecursoMultimediaNoticia" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre del recurso no puede ser vacío.</div>
          <div class="modal-footer">
               <button id="btnGuardarRegitroFotograficoNoticia" onclick="GuardarRegistroFotograficoNoticia()" type="button" class="btn btn-primary">Guardar</button>
          </div>
        </div>      
</div> 
<%--<div class="modal fade" id="myModalIngresarNoticia" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>--%>
<script type="text/javascript">
			$(document).ready(function() {
			    BuscarTotalNoticiasPublicadas();
			    $('[data-toggle="tooltip"]').tooltip();
			    $("#txtPalabraClaveNoticias").keypress(function (e) {
			        if (e.which == 13)
			        {
			            BuscarTotalNoticiasPublicadas();
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
    $("#inpsubirNoticiaFoto").fileinput({
                               language: 'es',
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
                               data.form.append("idDetalleRecurso", $("#hfIdDetalleRecursoMultNoticia").val());
                               data.form.append("idRecurso", $("#hfIdRecursoMultNoticia").val());
                               data.form.append("rutaImagen", $("#inpsubirNoticiaFoto").val());
                               data.form.append("idUsuario", $("#hfidUsuarioRecursoMulti").val());
                               }).on("fileuploaded", function (event, data, id, index) {
                                   $("#inpsubirNoticiaFoto").val('');
                                   volverListadoNoticiasCampanas("divPrincipalAnadirRecursoMultimedia", "divPrincipalNoticias");
                               bootbox.alert("Datos cargados con éxito.")
                               });
</script>
<script type="text/javascript">
    $("#inpsubirFotoNoticiaEditar").fileinput({
                               language: 'es',
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
                               data.form.append("idDetalleRecurso", $("#hfIdDetalleRecursoMultNoticiaEditar").val());
                               data.form.append("idRecurso", $("#hfIdRecursoMultNoticiaEditar").val());
                               data.form.append("rutaImagen", $("#inpsubirFotoNoticiaEditar").val());
                               data.form.append("idUsuario", $("#hfidUsuarioRecursoMultiEditar").val());
                               }).on("fileuploaded", function (event, data, id, index) {
                                   $("#inpsubirFotoNoticiaEditar").val('');
                                   volverListadoNoticiasCampanas("divPrincipalAnadirRecursoMultimediaEditar", "divPrincipalNoticias");
                               bootbox.alert("Datos cargados con éxito.")
                               });
</script>
