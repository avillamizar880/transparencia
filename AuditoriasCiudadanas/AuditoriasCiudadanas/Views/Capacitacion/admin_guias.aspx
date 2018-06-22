<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_guias.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.admin_guias" %>
<div class="container" id="divContGuias">
    <h1 class="text-center">Guías y Manuales</h1>
    <div class="well text-center">
        <div class="btn btn-info mb15" id="btnNewGuiaManual"><span class="glyphicon glyphicon-plus"></span>Nuevo documento</div>
    </div>
    <div class="enlacesBox" id="divListadoGuias">
    </div>
    <!--PAGINACIÓN-->
    <div class="col-md-12 text-center">
        <nav id="divPagGuias" aria-label="Page navigation">
            <ul id="paginadorGuias" class="pagination">
            </ul>
        </nav>
    </div>
</div>
<div class="container hideObj" id="divInfoEnlace">
    <div class="plantillasHeader">
        <h5>
            <a id="btnVolverListadoAdmin" role="button" onclick="volver_listado_admin('divInfoEnlace','divContGuias');"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER A GUIAS/MANUALES
            </a>
        </h5>
    </div>

<input type="hidden" id="hdIdUsuario" runat="server" />
    <input type="hidden" id="hdIdRecurso" runat="server" />
    <h1 class="text-center">Guías y Manuales</h1>
    <div class="form-group">
        <label for="ddlTipoRecurso" class="required">Guía/Manual</label>
        <!-- departamento-->
        <select class="form-control" id="ddlTipoRecurso">
            <option value="" selected>Seleccione una opción</option>
            <option value="1">Guía</option>
            <option value="2">Manual</option>
        </select>
        <div id="error_ddlTipoRecurso" class="alert alert-danger alert-dismissible" hidden="hidden">Seleccione si es guía o manual</div>
    </div>
    <div class="form-group">
        <label for="txtTitulo" class="required">Título</label>
        <input type="text" class="form-control" id="txtTitulo">
        <div id="error_txtTitulo" class="alert alert-danger alert-dismissible" hidden="hidden">Título no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtDescripcion" class="required">Descripción</label>
        <input type="text" class="form-control" id="txtDescripcion">
        <div id="error_txtDescripcion" class="alert alert-danger alert-dismissible" hidden="hidden">Descripción no puede ser vacía</div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4>Guía o Manual (.pdf):</h4>
            <p>Agregue archivo pdf correspondiente a la guía o manual</p>
        </div>
        <div class="panel-body">
            <div id="divAdjuntosGuia">
                <input id="btnNewAdjuntoGuias" name="btnNewAdjuntoGuias[]" type="file" class="file-loading">
            </div>
        </div>
    </div>

      <!--BOTONERA-->
    <div class="botonera text-center">
          <button class="btn btn-info" id="btnCrearGuias"><span class="glyphicon glyphicon-save"></span>GUARDAR</button>
    </div>
</div>
<script type="text/javascript">
    if ($(document).ready(function () {
         $.getScript('../../Scripts/CapacitacionFunciones.js', function () {
             $.getScript('../../Scripts/CapacitacionAcciones.js', function () {
                 //reload_guias_manuales();
                 reload_guias_manuales(1, volver_listado_admin('divInfoEnlace', 'divContGuias'));
                    
             });
         });
     }));
</script>