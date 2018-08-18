<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AprobacionExperienciasGAC.aspx.cs" Inherits="AuditoriasCiudadanas.Views.GestionGAC.AprobacionExperienciasGAC" %>
    <div class="container" id="divContEnlaces">
    <h1 class="text-center">Reconocer Experiencia</h1>
        <div id="divListadoExperiencias">
        </div>
        <!--PAGINACIÓN-->
        <div class="col-md-12 text-center">
            <nav id="divPagListado" aria-label="Page navigation">
                <ul id="paginadorListado" class="pagination">
                </ul>
            </nav>
        </div>
    </div>
<div class="container hideObj" id="divInfoEnlace">
    <div class="plantillasHeader">
        <h5>
            <a id="btnVolverListadoAdmin" role="button" onclick="volver_listado_admin('divInfoEnlace','divContEnlaces');"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER A LISTADO
            </a>
        </h5>
</div>
<input type="hidden" id="hdIdUsuario" runat="server" />
<input type="hidden" id="hdIdRecurso" runat="server" />
    <div id="divGeneral">
        <h1 class="text-center">Experiencia</h1>
        <div id="divFormulacion" class="tab-pane fade active in">
            <div class="col-sm-12">
                <h4>Proyecto</h4>
                <div id="divProyecto" style="font-weight:bold;"></div>
            </div>
            <div class="col-sm-12">
                <h4>Fecha creación</h4>
                <div id="divFecha"></div>
            </div>
            <div class="col-sm-12">
                <h4>Descripción</h4>
                <div id="divDescripcion"></div>
            </div>
             <div class="col-sm-12 mt20">
                <h4>Video o Audio</h4>
                 <input id="btnNewAdjuntoExperiencia" name="btnNewAdjuntoExperiencia[]" type="file" class="file-loading">
            </div>

        </div>
        
    </div>
</div>
<script type="text/javascript">
   if ($(document).ready(function () {
          reload_experienciasGac(1);
    }));
</script>
