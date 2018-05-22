<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list_informacion.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.list_informacion" %>
<link href="../../Content/screenView.css" rel="stylesheet" />
 <div class="container">
    	<h1>Información</h1>
        <div class="row">
        	<div class="col-sm-3">
            	<div class="leftMenu" id="tabs">
            <!--TABS-->
                <ul class="nav nav-tabs nav-stacked">
                  <li><a data-toggle="tab" href="#tab1">Guías y Manuales <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab2">Enlaces de interés <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab3">Videos institucionales <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab4">Capacitaciones<span class="glyphicon glyphicon-menu-right"></span></a></li>

                </ul>
                    
                </div>
			</div>
            <div class="col-sm-9">
            	<div class="generalInfo">
                	
                	<div class="tab-content">
                    	<!--CONTENT1 Guías y Manuales-->
                      <div id="tab1" class="tab-pane fade in">
                          <div id="tab_guias">
                          </div>
                          <nav id="divPagGuias" aria-label="Page navigation">
                              <ul id="paginadorGuias" class="pagination"></ul>
                          </nav>
                      </div>
                      <!--CONTENT2 Enlaces de interés-->
                      <div id="tab2" class="tab-pane fade">
                          <div id="tab_enlaces">
                          </div>
                          <nav id="divPagFichas" aria-label="Page navigation">
                              <ul id="paginador" class="pagination"></ul>
                          </nav>
                      </div>
                       <!--CONTENT3 Videos Institucionales-->
                      <div id="tab3" class="tab-pane fade">
                          <div id="tab_videos">
                          </div>
                          <nav id="divPagVideos" aria-label="Page navigation">
                              <ul id="paginadorVideos" class="pagination"></ul>
                          </nav>
                      </div>
                       <!--CONTENT4 Capacitaciones-->
                      <div id="tab4" class="tab-pane fade">

                      </div>
                    </div>
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
                     $('[href="#tab1"]').tab('show');

            });
        });
    }));
</script>
