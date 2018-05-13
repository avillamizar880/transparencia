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
                        <h2>Videos institucionales</h2>
                        <!--MONTOS DE COFINANCIACIÓN-->
                        <div class="row">
                          <!--Video 1-->
                          <div class="col-sm-6">
                            <div class="thumbnail">
                              <img src="img/thumbVideo.jpg" alt="..."/>
                              <div class="caption">
                                <h3><a href="#" role="button" data-toggle="modal" data-target="#myModal">Video 1</a></h3>
                                <p>Curabitur fringilla erat sed mauris ullamcorper, eu volutpat nisl rutrum. Nullam lacus ligula, euismod sed mauris ac, fermentum porta nisl.</p>
                                
                              </div>
                            </div>
                          </div>
                          <!--Video 2-->
                          <div class="col-sm-6">
                            <div class="thumbnail">
                              <img src="img/thumbVideo.jpg" alt="..."/>
                              <div class="caption">
                                <h3><a href="#" role="button" data-toggle="modal" data-target="#myModal">Video 1</a></h3>
                                <p>Curabitur fringilla erat sed mauris ullamcorper, eu volutpat nisl rutrum. Nullam lacus ligula, euismod sed mauris ac, fermentum porta nisl.</p>
                                
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                       <!--CONTENT4 Capacitaciones-->
                      <div id="tab4" class="tab-pane fade">
                        <h2>Capacitaciones</h2>
                        <div class="row">
                            <!--capacitacion 1-->
                              <div class="col-sm-4">
                                <div class="thumbnail">
                                  <img src="img/thumbVideo.jpg" alt="..."/>
                                  <div class="caption">
                                    <h3><a href="#">Trabajo en equipo</a></h3>
                                    <p>Curabitur fringilla erat sed mauris ullamcorper, eu volutpat nisl rutrum. Nullam lacus ligula, euismod sed mauris ac, fermentum porta nisl.</p>
                                    <div class="btn btn-default"><a href=""><span class="glyphicon glyphicon-log-in"></span> Cursar</a></div>
                                    
                                  </div>
                                </div>
                              </div>
                              <!--capacitacion 2-->
                              <div class="col-sm-4">
                                <div class="thumbnail">
                                  <img src="img/thumbVideo.jpg" alt="..."/>
                                  <div class="caption">
                                    <h3><a href="#">Trabajo en equipo</a></h3>
                                    <p>Curabitur fringilla erat sed mauris ullamcorper, eu volutpat nisl rutrum. Nullam lacus ligula, euismod sed mauris ac, fermentum porta nisl.</p>
                                    <div class="btn btn-default"><a href=""><span class="glyphicon glyphicon-log-in"></span> Cursar</a></div>
                                    
                                  </div>
                                </div>
                              </div>
                              <!--capacitacion 3-->
                              <div class="col-sm-4">
                                <div class="thumbnail">
                                  <img src="img/thumbVideo.jpg" alt="..."/>
                                  <div class="caption">
                                    <h3><a href="#">Trabajo en equipo</a></h3>
                                    <p>Curabitur fringilla erat sed mauris ullamcorper, eu volutpat nisl rutrum. Nullam lacus ligula, euismod sed mauris ac, fermentum porta nisl.</p>
                                    <div class="btn btn-default"><a href=""><span class="glyphicon glyphicon-log-in"></span> Cursar</a></div>
                                    
                                  </div>
                                </div>
                              </div>
                          </div>
                          <div class="row">
                            <!--capacitacion 1-->
                              <div class="col-sm-4">
                                <div class="thumbnail">
                                  <img src="img/thumbVideo.jpg" alt="..."/>
                                  <div class="caption">
                                    <h3><a href="#">Trabajo en equipo</a></h3>
                                    <p>Curabitur fringilla erat sed mauris ullamcorper, eu volutpat nisl rutrum. Nullam lacus ligula, euismod sed mauris ac, fermentum porta nisl.</p>
                                    <div class="btn btn-default"><a href=""><span class="glyphicon glyphicon-log-in"></span> Cursar</a></div>
                                    
                                  </div>
                                </div>
                              </div>
                              <!--capacitacion 2-->
                              <div class="col-sm-4">
                                <div class="thumbnail">
                                  <img src="img/thumbVideo.jpg" alt="..."/>
                                  <div class="caption">
                                    <h3><a href="#">Trabajo en equipo</a></h3>
                                    <p>Curabitur fringilla erat sed mauris ullamcorper, eu volutpat nisl rutrum. Nullam lacus ligula, euismod sed mauris ac, fermentum porta nisl.</p>
                                    <div class="btn btn-default"><a href=""><span class="glyphicon glyphicon-log-in"></span> Cursar</a></div>
                                    
                                  </div>
                                </div>
                              </div>
                              <!--capacitacion 3-->
                              <div class="col-sm-4">
                                <div class="thumbnail">
                                  <img src="img/thumbVideo.jpg" alt="..."/>
                                  <div class="caption">
                                    <h3><a href="#">Trabajo en equipo</a></h3>
                                    <p>Curabitur fringilla erat sed mauris ullamcorper, eu volutpat nisl rutrum. Nullam lacus ligula, euismod sed mauris ac, fermentum porta nisl.</p>
                                    <div class="btn btn-default"><a href=""><span class="glyphicon glyphicon-log-in"></span> Cursar</a></div>
                                    
                                  </div>
                                </div>
                              </div>
                          </div>
                      </div>
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
