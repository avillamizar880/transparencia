<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list_capacitacion.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.list_capacitacion" %>

<div class="container">
<input type="hidden" id="hdIdUsuario" runat="server" />
<input type="hidden" id="hdIdCap" runat="server" />
    	<!--BREADCRUMB-->
        <%--<div class="row mt20">
        	<ol class="breadcrumb col-md-12">
              <li><a href="#">Inicio</a></li>
              <li><a href="#">Capacitaciones</a></li>
              <li class="active">Nombre de la capacitación</li>
            </ol>
        </div>--%>
        
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
       </div>
<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/CapacitacionFunciones.js", function () {
                $.getScript("../../Scripts/CapacitacionAcciones.js", function () {
                     $('[href="#tab1"]').tab('show');
                       CargarDatosModulos();
            });
        });
    }));
</script>