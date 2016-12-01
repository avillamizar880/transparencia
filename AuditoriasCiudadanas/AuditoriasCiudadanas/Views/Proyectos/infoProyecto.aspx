<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="infoProyecto.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Proyectos.infoProyecto" %>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../../Content/logo-nav.css" rel="stylesheet" />
<link href="../../Content/screenView.css" rel="stylesheet" />
   <!-- Page Content -->
    <div class="container">
    	<div class="row">
        	<div class="headSection">
            	<div id="divPin" class="col-sm-12 headTit">
                    <span>PROYECTO</span>
                    <label id="lblPin" runat="server">BPIN:</label>
                    <span class="badge" id="spnPinProyecto"></span>
                </div>
                <div class="row col-sm-9">
                     <div class="col-sm-5">
                        <div id="divNombreProy" runat="server" class="form-group">
                            <label for="lblNombreProyecto">Nombre:</label>
                            <div id="txtNombreProyecto" runat="server">
                                <p>Ut egestas ligula a lacus commodo, id fringilla massa malesuada. Nam laoreet odio rutrum ante gravida egestas. Phasellus nec gravida mauris. Interdum et malesuada fames ac ante ipsum primis in faucibus. Morbi id sem at erat blandit vehicula. Sed orci nisi, commodo eu pharetra id, iaculis ut sapien.</p>
                            </div>
                        </div>
                     </div>
                     <div class="col-sm-3">
                        <div id="divBtnUbicacion" runat="server">
                            <img class="img-responsive" src="img_pin_ubicacion.jpg" alt="Ubicación">
                            <div id="txtUbicaProyecto"></div>
                        </div>
                       </div>
                    <div class="col-sm-3">
                         <div id="divBtnContratista" runat="server" class="form-group">
                            <label for="lblNombreProyecto">Contratista:</label>
                            <div id="divInfoContratista" runat="server"></div>
                        </div>
                    </div>
              </div>
                    <div class="col-sm-3 userActions">
                        <div class="btn btn-default btn-lg"><span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span></div>
                        <div class="btn btn-default"><span>
                            <img src="img/iconHand.png" /></span>
                        </div>
                    </div>
    
		</div>
          </div>  
        <div class="row">
        	<div class="col-sm-3">
            	<div class="leftMenu">
            <!--TABS-->
                <ul class="nav nav-tabs nav-stacked">
                  <li class="active"><a data-toggle="tab" href="#tab1">Información General <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab2">Contratista y Vigilancia <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab3">Financiación y Presupuesto <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab4">Formulación y Aprobación <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab5">Planeación y Aprobación <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab6">Información Técnica y Calidad <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab7">Grupo de Auditores <span class="glyphicon glyphicon-menu-right"></span></a></li>
                </ul>
                </div>
			</div>
            <div class="col-sm-9">
            	<div class="generalInfo">
                	<div class="tab-content">
                    	<!--CONTENT1 GENERAL INFO-->
                      <div id="tab1" class="tab-pane fade in active">
                        <h2>Información General</h2>
                            <!--OBJETIVO-->
                            <div class="col-sm-12">
                                <h4>Objetivo</h4>
                                <p>Aliquam erat volutpat. Nulla pretium vel lacus a posuere. Suspendisse vehicula pharetra diam, ut sodales risus pretium ut. Sed eu nisi eros. Donec feugiat nulla ac massa ornare, ac tempor velit mollis.</p>
                            </div>
                            <div class="col-sm-12">
                                <h4>Presupuesto Total</h4>
                                <p>$850.056.675</p>
                            </div>
                            <!--sector al que apunta-->
                            <div class="col-sm-4">
                                <h4>Sector al que apunta</h4>
                                <p>Aliquam erat volutpat. </p>
                            </div>
                            <!--LOCALIZACION-->
                            <div class="col-sm-4">
                                <h4>Localización</h4>
                                <p>Vetas, Santander</p>
                            </div>
                            <!--ENTIDAD-->
                            <div class="col-sm-4">
                                <h4>Nombre de la Entidad Ejecutora de los recursos</h4>
                                <p>Umbrella Corp.</p>
                            </div>
                            <!--PRODUCTOS DEL PROYECTO-->
                            <div class="col-sm-12">
                                <h4>Productos del Proyecto</h4>
                                <ul>
                                    <li>Estructura de la Malla Vial</li>
                                    <li>Enlace de Puentes entre municipios</li>
                                    <li>Andenes</li>
                                    <li>Muros de Contención</li>
                                </ul>
                            </div>
                            <!--CRONOGRAMA-->
                            <div class="col-sm-12">
                                <h4>Cronograma de Actividades</h4>
                                <div class="row">
                                <div class="col-sm-6">
                                    <h5>PLANEADO</h5>
                                    <div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>
                                    <div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>
                                    <div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>
                                    <div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>
                                    <div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>
                                    <div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>
                                    
                                
                                </div>
                                <div class="col-sm-6">
                                    <h5>EJECUTADO</h5>
                                    <div class="cronoEjecutado">
                                    <div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>
                                    <div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>
                                    <div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>
                                    <div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>
                                    <div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>
                                    <div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>
                                    </div>
                                </div>
                                </div>
                            </div>
                      </div>
                      <!--CONTENT2 Contratista y Vigilancia-->
                      <div id="tab2" class="tab-pane fade">
                         <h2>Contratista y Vigilancia</h2>
                        <!--NOMBRE DEL CONTRATISTA-->
                            <div class="col-sm-12">
                                <h4>Contratista Seleccionado</h4>
                                <p>Umbrela Corp.</p>
                            </div>
                            <!--NOMBRE DEL INTERVENTOR DESIGNADO-->
                            <div class="col-sm-6">
                                <h4>Interventor Designado</h4>
                                <p>LUKE Skywalker</p>
                            </div>
                            <!--NOMBRE DEL supervisor-->
                            <div class="col-sm-6">
                                <h4>Supervisor</h4>
                                <p>Darth Vader</p>
                            </div>
                           
                            <!--INFORMACIÓN GENERAL DE POLIZAS Y GARANTIAS-->
                            <div class="col-sm-12">
                                <h4>Información general de Pólizas y Garantías</h4>
                                <p>Praesent aliquet, dui non posuere aliquet, ante purus condimentum enim, et egestas erat nibh nec nisl. Proin rutrum sapien at urna fringilla sodales. Vestibulum convallis convallis odio, vel iaculis ipsum sodales eget. Nunc blandit tempus urna, ut interdum nunc sagittis nec. Sed mollis fermentum erat, rutrum eleifend arcu tempor sit amet. Donec tincidunt quis augue in maximus. Duis metus nulla, iaculis ac ultrices at, ultricies eu tortor. Morbi nec fringilla justo, in mattis odio.</p>
                                <div class="btn btn-default"><span class="glyphicon glyphicon-save-file"></span>VER DOCUMENTO</div>
                            </div>
                      </div>
                       <!--CONTENT3 Financiación y Presupuesto-->
                      <div id="tab3" class="tab-pane fade">
                        <h2>Financiación y Presupuesto</h2>
                        <!--MONTOS DE COFINANCIACIÓN-->
                        <div class="col-sm-12">
                            <h4>Montos de Cofinanciación en el proyecto con su respectiva fuente de orígen</h4>
                           
                            <div class="table-responsive">
                            <table class="table table-hover table-striped">
                            	<thead>
                            	<tr><th>Entidad</th><th>Valor</th></tr>
                                </thead>
                                <tbody>
                                <tr><td>Valor del SGR</td><td>$3'035.000.000</td></tr>
                                <tr><td>Valor Nación</td><td>$0</td></tr>
                                <tr><td>Valor Otros</td><td>$5'000.000.000</td></tr>
                                </tbody>
                            </table>
                            </div>
                            </div>
                            <!--MODIFICACIONES AL PRESUPUESTO-->
                        	<div class="col-sm-12">
                            <h4>Modificaciones al Presupuesto</h4>
                            <p><span class="glyphicon glyphicon-ok-sign"></span> No hay Modificaciones al presupuesto en el OCAD donde fue aprobado el presupuesto</p>
                        </div>
                            <!--Costo por productos/Actividad-->
                        <div class="col-sm-12">
                            <h4>Costos por Productos y/o Actividad</h4>
                            <div class="table-responsive">
                            <table class="table table-hover table-striped">
                            	<thead>
                            	<tr><th>Entidad</th><th>Valor</th></tr>
                                </thead>
                                <tbody>
                                <tr><td>Socialización del proyecto con los beneficiarios directos</td><td>$35.000.000</td></tr>
                                <tr><td>Acondicionamiento del Terreno par fijar la estructura</td><td>$800.987.790</td></tr>
                                <tr><td>Fijar de la gravilla en el terreno</td><td>$5'000.000.000</td></tr>
                                <tr><td>Alisar La Preparación y Compatactión del suelo en bruto es un paso vital  para reparar y allanar el camino</td><td>$15'000.000.000</td></tr>
                                <tr><td>Agregar y alisar el aglutinante y asfalto</td><td>$300.000.000</td></tr>
                                </tbody>
                            </table>
                            </div>
                            
                        </div>
                      </div>
                       <!--CONTENT4 Formulación y Aprobación-->
                      <div id="tab4" class="tab-pane fade">
                        <h2>Formulación y Aprobación</h2>
                        <!--fecha y OCAD-->
                        <div class="col-sm-12">
                                <h4>Fecha y OCAD donde se aprobó el proyecto</h4>
                                <p>15 de Feb de 2012 - OCAD Municipal</p>
                            </div>
                        <!--Acta OCAD-->
                        <div class="col-sm-6">
                                <h4>Acta del OCAD mediante la cual se aprueba el proyecto</h4>
                                <div class="btn btn-default"><a href=""><span class="glyphicon glyphicon-save-file"></span>Ver Documento</a></div>
                            </div>
                        <!--Criterios-->
                        <div class="col-sm-6">
                                <h4>Criterios de Priorización del proyecto por encima de otros</h4>
                                <div class="btn btn-default"><a href=""><span class="glyphicon glyphicon-save-file"></span>Ver Documento</a></div>
                            </div>
                        <!--proyectos Presentados al OCAD-->
                        <div class="col-sm-12">
                            <h4>Proyectos presentados al OCAD</h4>
                            <ul>
                            <li>Praesent egestas ornare dui non consectetur. Mauris ut facilisis odio.</li>
                            <li>Donec tincidunt quis augue in maximus. Duis metus nulla, iaculis ac ultrices at, ultricies eu tortor.</li>
                            <li>Phasellus accumsan, neque sit amet maximus varius</li>
                            <li>Ut nunc diam, sodales in dignissim a, volutpat sed magna. Vestibulum eget mi iaculis, auctor libero eu, cursus sapien. Nam sit amet congue quam. </li>
                            <li>Vestibulum ullamcorper, mi ut lacinia congue, dolor nisi finibus lectus, et varius velit ligula et ex.</li>
                            </ul>
                         </div>
                         <!--proyectos Presentados al OCAD-->
                        <div class="col-sm-12">
                            <h4>Datos de quien formuló y estructuró el proyecto</h4>
                            <ul class="list-group">
                            <li class="list-group-item"><span class="glyphicon glyphicon-user"></span>Nombre: Andrea Natali Caballero</li>
                            <li class="list-group-item"><span class="glyphicon glyphicon-credit-card"></span>CC: 10086546</li>
                            <li class="list-group-item"><span class="glyphicon glyphicon-envelope"></span>Email: natis.caballero@hotmail.com</li>
                            <li class="list-group-item"><span class="glyphicon glyphicon-earphone"></span>Numero de contacto:3134567890</li>
                            </ul>

                         </div>
                      </div>
                       <!--CONTENT5 Planeación y Aprobación-->
                      <div id="tab5" class="tab-pane fade">
                        <h2>Planeación y Aprobación</h2>
                        <!--Descripción-->
                        <div class="col-sm-8">
                          <h4>Descricpión</h4>
                          <p>Phasellus nec gravida mauris. Interdum et malesuada fames ac ante ipsum primis in faucibus. Morbi id sem at erat blandit vehicula. Sed orci nisi, commodo eu pharetra id, iaculis ut sapien. Quisque leo turpis, hendrerit a pulvinar eu, interdum non ipsum. Donec vitae lectus quis nisi blandit accumsan. </p>
                         
                         </div>
                         <!--Documento de planeación-->
                         <div class="col-sm-4">
                         	 <h4>Documento de Planeación</h4>
                          	<div class="btn btn-default"><a href=""><span class="glyphicon glyphicon-save-file"></span> Ver Documento</a></div>
                         </div>
                         <!--Especificaciones Técnicas-->
                         <div class="col-sm-12">
                         	 <h4>Especificaciones Técnicas</h4>
                             <p>
                             Nulla accumsan nunc non orci ultrices faucibus. Donec blandit ante dui, ac consectetur nisl mollis at. Donec vitae cursus felis. Morbi varius dolor dolor, ut malesuada enim euismod sed. Curabitur semper iaculis nibh sed vestibulum. Quisque facilisis, turpis vitae pulvinar maximus, lectus mi pellentesque diam, et accumsan diam metus vel ex. Pellentesque ligula libero, sagittis vel convallis eget, commodo sit amet odio. Fusce sit amet laoreet ligula, et efficitur diam.
                             </p>
                              <p>
                             Onec blandit ante dui, ac consectetur nisl mollis at. Donec vitae cursus felis. Morbi varius dolor dolor, ut malesuada enim euismod sed. Curabitur semper iaculis nibh sed vestibulum. Quisque facilisis, turpis vitae pulvinar maximus, lectus mi pellentesque diam, et accumsan diam metus vel ex. Pellentesque ligula libero, sagittis vel convallis eget, commodo sit amet odio. Fusce sit amet laoreet ligula, et efficitur diam.
                             </p>
                             <p>
                             Onec blandit ante dui, ac consectetur nisl mollis at. Donec vitae cursus felis. Morbi varius dolor dolor, ut malesuada enim euismod sed. Curabitur semper iaculis nibh sed vestibulum. Quisque facilisis, turpis vitae pulvinar maximus, lectus mi pellentesque diam, et accumsan diam metus vel ex. Pellentesque ligula libero, sagittis vel convallis eget, commodo sit amet odio. Fusce sit amet laoreet ligula, et efficitur diam.
                             </p>
                          	
                         </div>
                      </div>
                       <!--CONTENT Información Técnica y Calidad-->
                      <div id="tab6" class="tab-pane fade">
                        <h2>Información Técnica y Calidad</h2>
                        
                         <!--Informe Semanal-->
                         <div class="col-sm-12">
                         	 <h4>Informe semanal de los avances de la obra</h4>
                             <p>
                             Onec blandit ante dui, ac consectetur nisl mollis at. Donec vitae cursus felis. Morbi varius dolor dolor, ut malesuada enim euismod sed. Curabitur semper iaculis nibh sed vestibulum. Quisque facilisis, turpis vitae pulvinar maximus, lectus mi pellentesque diam, et accumsan diam metus vel ex. Pellentesque ligula libero, sagittis vel convallis eget, commodo sit amet odio. Fusce sit amet laoreet ligula, et efficitur diam.
                             </p>
                             <div class="btn btn-default"><a href=""><span class="glyphicon glyphicon-comment"></span>Interventor:Luke Skywalker</a></div>
                          	<div class="btn btn-default"><a href=""><span class="glyphicon glyphicon-save-file"></span> Ver Documento</a></div>
                         </div>
                         
                      </div>
                       <!--CONTENT Grupo de Auditores-->
                      <div id="tab7" class="tab-pane fade">
                        <h2>Grupo de Auditores</h2>
                        <p>Some content in menu 2.</p>
                      </div>
                      
                    </div>
                
                	
                
                </div>
            
            </div>
            
            
        </div>
    </div>
    <!-- /.container -->
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../../Scripts/responsive-tabs.js"></script>
<script type="text/javascript" src="../../Scripts/Principal.js"></script>
<script src="../../Scripts/jquery.blockUI.js"></script>
<script type="text/javascript" src="../../Scripts/ajaxPost.js"></script>
<script type="text/javascript" src="../../Scripts/ProyectoAcciones.js"></script>

<script type="text/javascript">
    $('ul.nav.nav-tabs  a').click(function (e) {
        e.preventDefault();
        $(this).tab('show');
    });

    (function ($) {
        // Test for making sure event are maintained
        $('.js-alert-test').click(function () {
            alert('Button Clicked: Event was maintained');
        });
        fakewaffle.responsiveTabs(['xs', 'sm']);
    })(jQuery);

    </script>