<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list_capacitacion.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.list_capacitacion" %>

<div class="container">
    <input type="hidden" id="hdIdUsuario" runat="server" />
    <input type="hidden" id="hdIdCap" runat="server" />
    <!--BREADCRUMB-->
    <div class="row mt20">
        	<ol class="breadcrumb col-md-12">
              <li><a href="#">Inicio</a></li>
              <li><a id="btnCaptUsu">Capacitaciones</a></li>
              <li class="active" id="divNomCapt"> </li>
            </ol>
        </div>

    <div class="headSection">
        <div id="divCabeceraCapt">
        </div>
    </div>
    <div class="row">
        <div class="col-md-3 leftMenu">
            <div id="divModulos">
            </div>
        </div>
        <!--DESC TABS-->
        <div class="col-md-9">
            <div class="tab-content" id="divTabsModulos">
            </div>
        </div>
    </div>
</div>
<div class="modal fade bd-example-modal-lg" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
        <h4 class="modal-title" id="myModalLabel"></h4>
      </div>
      <div class="modal-body">
          <div id="img-modal">
          </div>
      </div>
     
    </div>
  </div>
</div>

<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/CapacitacionFunciones.js", function () {
                $.getScript("../../Scripts/CapacitacionAcciones.js", function () {

                       CargarDatosModulos();
            });
        });
    }));
</script>