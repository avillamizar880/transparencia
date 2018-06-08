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
            	<div class="tab-content">
                    <!--CONTENT1 Modulo 1-->
                      <div id="tab1" class="tab-pane fade in active">
                     	<div class="row">
                            <div class="col-md-4">
                            	<div class="panel panel-default">
                                 <div class="label label-info">100%</div>
                                  <div class="panel-body">
                                    Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                  </div>
                                  <div class="panel-footer"><a href="#" class="btn btn-primary"> Ver video</a></div>
                                </div>
                            </div>
                            <div class="col-md-4">
                            	<div class="panel panel-default">
                                <div class="label label-default">30%</div>
                                  <div class="panel-body">
                                    Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                  </div>
                                  <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                                </div>
                            </div>
                            <div class="col-md-4">
                            	<div class="panel panel-default">
                                <div class="label label-default">0%</div>
                                  <div class="panel-body">
                                    Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                  </div>
                                  <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                                </div>
                            </div>
                        </div>                        
                      </div>
                     <!--CONTENT2 Modulo 2-->
                    <div id="tab2" class="tab-pane">
                    <h4>Título Módulo 2</h4>
                    <p>Ut cursus sodales tellus vitae volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nam venenatis est non mauris vulputate, laoreet elementum diam dignissim. Etiam sagittis tempus molestie. Mauris turpis lectus, luctus at fringilla vitae, blandit at augue. Praesent placerat, odio ut hendrerit blandit, massa lectus condimentum nunc, eu finibus enim ligula efficitur tortor. Mauris vestibulum eget nulla eget efficitur. </p>
                    
                      <div class="row">
                          <div class="col-md-4">
                              <div class="panel panel-default">
                              <div class="label label-default">0%</div>
                                <div class="panel-body">
                                  Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"> Ver video</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                              <div class="label label-default">0%</div>
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                  <div class="label label-default">0%</div>
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"> Ver video</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"> Ver video</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                      </div>                        
                    </div>
                    <!--CONTENT3 Modulo 3-->
                    <div id="tab3" class="tab-pane">
                    <h4>Título Módulo 3</h4>
                    <p>Ut cursus sodales tellus vitae volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nam venenatis est non mauris vulputate, laoreet elementum diam dignissim. Etiam sagittis tempus molestie. Mauris turpis lectus, luctus at fringilla vitae, blandit at augue. Praesent placerat, odio ut hendrerit blandit, massa lectus condimentum nunc, eu finibus enim ligula efficitur tortor. Mauris vestibulum eget nulla eget efficitur. </p>
                    
                      <div class="row">
                          <div class="col-md-4">
                              <div class="panel panel-default">
                              <div class="label label-default">0%</div>
                                <div class="panel-body">
                                  Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"> Ver video</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                              <div class="label label-default">0%</div>
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                  <div class="label label-default">0%</div>
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"> Ver video</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"> Ver video</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                      </div>                        
                    </div>
                    <!--CONTENT4 Modulo 4-->
                    <div id="tab4" class="tab-pane">
                    <h4>Título Módulo 4</h4>
                    <p>Ut cursus sodales tellus vitae volutpat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nam venenatis est non mauris vulputate, laoreet elementum diam dignissim. Etiam sagittis tempus molestie. Mauris turpis lectus, luctus at fringilla vitae, blandit at augue. Praesent placerat, odio ut hendrerit blandit, massa lectus condimentum nunc, eu finibus enim ligula efficitur tortor. Mauris vestibulum eget nulla eget efficitur. </p>
                    
                      <div class="row">
                          <div class="col-md-4">
                              <div class="panel panel-default">
                              <div class="label label-default">0%</div>
                                <div class="panel-body">
                                  Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"> Ver video</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                              <div class="label label-default">0%</div>
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                  <div class="label label-default">0%</div>
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"> Ver video</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                      </div>
                      <div class="row">
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"> Ver video</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
                              </div>
                          </div>
                          <div class="col-md-4">
                              <div class="panel panel-default">
                                <div class="panel-body">
                                  Tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. 
                                </div>
                                <div class="panel-footer"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-download"></span> Descargar PDF</a></div>
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
                       CargarDatosModulos();
            });
        });
    }));
</script>