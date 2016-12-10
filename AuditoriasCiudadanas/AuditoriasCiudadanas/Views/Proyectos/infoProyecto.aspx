<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="infoProyecto.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Proyectos.infoProyecto" %>
<%--<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
   <!-- Custom CSS -->
<link href="../../Content/logo-nav.css" rel="stylesheet">
<link href="../../Content/screenView.css" rel="stylesheet" type="text/css">
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../../Scripts/responsive-tabs.js"></script>
<script type="text/javascript" src="../../Scripts/Principal.js"></script>
<script src="../../Scripts/jquery.blockUI.js"></script>
<script type="text/javascript" src="../../Scripts/ajaxPost.js"></script>--%>
 <!-- MIGA DE PAN -->
    <div class="container">
    	<div class="row">
    	<ol class="breadcrumb">
          <li><a href="#">Inicio</a></li>
          <li><a href="#">Proyectos</a></li>
          <li class="active">Nombre del proyecto</li>
        </ol>
        </div>
    </div>
 <!-- Page Content -->
    <div class="container">
        <input type="hidden" id="hfidproyecto" runat="server" class="hideObj" />
    	<div class="row">
            <div class="headSection">
                <div id="divPin" class="col-sm-12 headTit">
                    <span>PROYECTO</span>
                    <span class="badge" id="spnPinProyecto"></span>
                </div>
                <div class="row">
                    <div class="col-sm-9">
                        <div class="row">
                            <div id="divNombreProy" runat="server" class="form-group col-sm-12">
<%--                               <label for="txtNombreProyecto">Nombre:</label>--%>
                                 <div id="txtNombreProyecto" runat="server">
<%--                                     <h3>AQUI VA EL NOMBRE DEL PROYECTO Y EL OBJETO</h3>--%>
                                   </div>
                            </div>
                        </div>
                        <div class="row form-horizontal">
                            <div class="col-sm-6">
                                <div id="divBtnUbicacion" runat="server" class="form-group">
                                    <label class="control-label col-sm-2" for="txtUbicaProyecto">Ubicación:</label>
                                     <div class="col-sm-10">
                                        <%--<img class="img-responsive" src="img_pin_ubicacion.jpg" alt="Ubicación">--%>
                                        <p class="form-control-static" id="txtUbicaProyecto">UBICACION</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div id="divInfoContratista" runat="server" class="form-group">
                                    <label class="control-label col-sm-2" for="txtNomContratista">Contratista:</label>
                                    <div class="col-sm-10">
                                     <p class="form-control-static" id="txtNomContratista">NOM CONTRATISTA</p>
                                    </div>
                                </div>
                            </div>

                            
                        </div>
                    </div>
                    <div class="col-sm-3 userActions">
                        <div class="row center-block">
                            <div class="col-sm-12">
                                <div class="btn btn-default btn-lg"><span class="glyphicon glyphicon-pushpin"></span>&nbsp;<span>Seguir</span></div>
                            </div>
                        </div>
                        <div class="row center-block">
                            <div class="col-sm-12">
                                <div class="btn btn-default btnActions"><span>
                                    <img src="../../Content/img/iconHand.png" /></span>&nbsp;<span>Auditar</span></div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
          </div>  
        <div class="row">
        	<div class="col-sm-3">
            	<div class="leftMenu">
            <!--TABS-->
                <ul class="nav nav-tabs nav-stacked" id="opcionesInfo">
                  <li class="active"><a data-toggle="tab" href="#divGeneral">Información General <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#divContratista">Contratista y Vigilancia <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#divPresupuesto">Financiación y Presupuesto <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#divFormulacion">Formulación y Aprobación <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#divPlaneacion">Planeación y Aprobación <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#divInfoTecnica">Información Técnica y Calidad <span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#divGrupos">Grupo de Auditores <span class="glyphicon glyphicon-menu-right"></span></a></li>
                </ul>
                </div>
			</div>
            <div class="col-sm-9">
            	<div class="generalInfo">
                	<div id="divDetalleProyecto" class="tab-content responsive" runat="server">
                    	<!--CONTENT1 GENERAL INFO-->
                       <div id="divGeneral" class="tab-pane fade in active">
                        <h2>Información General</h2>
                            
                            <div class="col-sm-12">
                                <h4>Presupuesto Total</h4>
                                <div id="divPresupuestoTotal" runat="server"></div>
                            </div>
                            <!--sector al que apunta-->
                            <div class="col-sm-4">
                                <h4>Sector al que apunta</h4>
                                <div id="divSectorDet" runat="server"></div>
                            </div>
                            <!--LOCALIZACION-->
                            <div class="col-sm-4">
                                <h4>Localización</h4>
                                 <div id="divLocalizacionDet" runat="server"></div>
                            </div>
                            <!--ENTIDAD-->
                            <div class="col-sm-4">
                                <h4>Nombre de la Entidad Ejecutora de los recursos</h4>
                                <div id="divEntidadEjecDet" runat="server"></div>
                            </div>
                           <!--BENEFICIARIOS-->
                            <div class="col-sm-12">
                                <h4>Beneficiarios</h4>
                                <div id="divBeneficiarios" runat="server">
                                </div>
                                
                            </div>
                            <!--PRODUCTOS DEL PROYECTO-->
                            <div class="col-sm-12">
                                <h4>Productos del Proyecto</h4>
                                 <div id="divProductosDet" runat="server">
                                    <%-- <ul>
                                    <li>Estructura de la Malla Vial</li>
                                    <li>Enlace de Puentes entre municipios</li>
                                    <li>Andenes</li>
                                    <li>Muros de Contención</li>
                                </ul>--%>
                                 </div>
                            </div>
                            <!--CRONOGRAMA-->
                            <div class="col-sm-12">
                                <h4>Cronograma de Actividades</h4>
                                <div class="row">
                                <div class="col-sm-6 hideObj" id="divCronogramaPlan" > 
                                    <h5>PLANEADO</h5>
                                    <div runat="server" id="divCronogramaDet">
                                       <%--<div class="cronoItem">
                                            <span class="glyphicon glyphicon-flag"></span>
                                            <span class="dataHito">25 de Febrero 2016</span>
                                            <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                        </div>--%>
                                    </div>
                                
                                </div>
                                <div class="col-sm-6 hideObj" id="divCronoEjec">
                                    <h5>EJECUTADO</h5>
                                    <div class="cronoEjecutado" id="divCronoEjecDet">
                                    <%--<div class="cronoItem">
                                        <span class="glyphicon glyphicon-flag"></span>
                                        <span class="dataHito">25 de Febrero 2016</span>
                                        <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                    </div>--%>
                                    </div>
                                </div>
                                </div>
                            </div>
                      </div>
                      <!--CONTENT2 Contratista y Vigilancia-->
                        <div id="divContratista" class="tab-pane fade">
                            <h2>Contratista y Vigilancia</h2>
                            <!--NOMBRE DEL CONTRATISTA-->
                            <div class="col-sm-12">
                                <h4>Contratista Seleccionado</h4>
                                <div id="divContratistaDet" runat="server"></div>
                            </div>
                            <!--NOMBRE DEL INTERVENTOR DESIGNADO-->
                            <div class="col-sm-6">
                                <h4>Interventor Designado</h4>
                                <div id="divInterventorDet" runat="server"></div>
                            </div>
                            <!--NOMBRE DEL supervisor-->
                            <div class="col-sm-6">
                                <h4>Supervisor</h4>
                                <div id="divSupervisorDet" runat="server"></div>
                            </div>
                            <!--INFORMACIÓN GENERAL DE POLIZAS Y GARANTIAS-->
                            <div class="col-sm-12">
                                <h4>Información general de Pólizas y Garantías</h4>
                                <div id="divTextoPoliza" runat="server">
                                </div>
                                <div id="divPolizaDet" class="btn btn-default hideObj">
                                    <a role="button" id="divPolizaDocumento">
                                        <span class="glyphicon glyphicon-save-file"></span>VER DOCUMENTO
                                    </a>
                                </div>
                            </div>
                        </div>
                       <!--CONTENT3 Financiación y Presupuesto-->
                      <div id="divPresupuesto" class="tab-pane fade">
                        <h2>Financiación y Presupuesto</h2>
                        <!--MONTOS DE COFINANCIACIÓN-->
                        <div class="col-sm-12">
                            <h4>Montos de Cofinanciación en el proyecto con su respectiva fuente u origen</h4>
                             <div class="table-responsive" id="divPresupuestoDet">
                            <%--<table class="table table-hover table-striped">
                            	<thead>
                            	<tr><th>Entidad</th><th>Valor</th></tr>
                                </thead>
                                <tbody>
                                <tr><td>Valor del SGR</td><td>$3'035.000.000</td></tr>
                                </tbody>
                            </table>--%>
                            </div>
                            </div>
                            <!--MODIFICACIONES AL PRESUPUESTO-->
                        	<div class="col-sm-12">
                            <h4>Modificaciones al Presupuesto</h4>
                            <div class="table-responsive" id="divModifPresupDet" runat="server">
                        </div>
                                </div>
                            <!--Costo por productos/Actividad-->
                                <div class="col-sm-12">
                                    <h4>Costo por producto y/o actividad :</h4>
                                    <div class="table-responsive" id="divCostoActividadDet">
                                        <%--<table class="table table-hover table-striped">
                            	        <thead>
                            	        <tr><th>Entidad</th><th>Valor</th></tr>
                                        </thead>
                                        <tbody>
                                        <tr><td>Socialización del proyecto con los beneficiarios directos</td><td>$35.000.000</td></tr>
                                        </tbody>
                                        </table>--%>
                                    </div>
                                </div>
                          <!--Pagos del contrato -->
                                <div class="col-sm-12">
                                    <h4>Pagos del contrato :</h4>
                                    <div class="table-responsive" id="divPagosContrato">
                                        <%--<table class="table table-hover table-striped">
                            	        <thead>
                            	        <tr><th>Entidad</th><th>Valor</th></tr>
                                        </thead>
                                        <tbody>
                                        <tr><td>Socialización del proyecto con los beneficiarios directos</td><td>$35.000.000</td></tr>
                                        </tbody>
                                        </table>--%>
                                    </div>
                                </div>
                          </div>
                        <!--CONTENT4 Formulación y Aprobación-->
                      <div id="divFormulacion" class="tab-pane fade">
                        <h2>Formulación y Aprobación</h2>
                        <!--fecha y OCAD-->
                        <div class="col-sm-12">
                                <h4>Fecha y OCAD donde se aprobó el proyecto</h4>
                                <div id="divFechaOcadDet" runat="server"> </div>
                            </div>
                        <!--Acta OCAD-->
                            <div class="col-sm-6">
                                <h4>Acta del OCAD mediante la cual se aprueba el proyecto</h4>
                                <div id="divNumActaOcad" runat="server"></div>
                                <div id="divActaOcadDocumento" runat="server" class="btn btn-default hideObj">
                                    <a role="button" id="divActaOcadDet">
                                        <span class="glyphicon glyphicon-save-file"></span>
                                        Ver Documento
                                    </a>
                                </div>
                            </div>
                        <!--Criterios-->
                        <div class="col-sm-6">
                            <h4>Criterios de Priorización del proyecto por encima de otros</h4>
                            <div id="divCriteriosDetTexto" runat="server"></div>
                            <div id="divCriteriosDocumento" class="btn btn-default hideObj">
                                <a role="button" id="divCriteriosDet">
                                    <span class="glyphicon glyphicon-save-file"></span>Ver Documento
                                </a>
                            </div>
                            </div>
                        <!--proyectos Presentados al OCAD-->
                          <div class="col-sm-12">
                              <h4>Proyectos presentados al OCAD</h4>
                              <div id="divPresOcadDet" runat="server">
                                  <%--<ul>
                            <li>Praesent egestas ornare dui non consectetur. Mauris ut facilisis odio.</li>
                            </ul>--%>
                              </div>
                              </div>
                              <!--proyectos Presentados al OCAD-->
                              <div class="col-sm-12">
                                  <h4>Datos de quien formuló/estructuró el proyecto</h4>
                                  <div id="divPersonaDet" runat="server">
                                      <ul class="list-group">
                                          <li class="list-group-item"><span class="glyphicon glyphicon-user"></span><span id="spnNomFormula"></span></li>
                                          <li class="list-group-item"><span class="glyphicon glyphicon-credit-card"></span><span id="spnIdentifFormula"></span></li>
                                          <li class="list-group-item"><span class="glyphicon glyphicon-envelope"></span><span id="spnEmailFormula"></span></li>
                                          <li class="list-group-item"><span class="glyphicon glyphicon-earphone"></span><span id="contactoFormula"></span></li>
                                      </ul>
                                  </div>
                              </div>
                          </div>
                              <!--CONTENT5 Planeación y Aprobación-->
                        <div id="divPlaneacion" class="tab-pane fade">
                            <h2>Planeación y Aprobación</h2>
                            <!--Descripción-->
                            <div class="col-sm-8">
                                <h4>Descripción:</h4>
                                <div id="divDescripDet" runat="server">
                                </div>
                            </div>
                            <!--Documento de planeación-->
                            <div class="col-sm-4">
                                <div id="divDocPlaneacion" class="hideObj">
                                    <h4>Documento de Planeación</h4>
                                    <div class="btn btn-default">
                                        <a role="button" id="divDocPlaDet"><span class="glyphicon glyphicon-save-file"></span>
                                            Ver Documento</a>
                                    </div>
                                </div>
                                
                            </div>
                            <!--Especificaciones Técnicas-->
                            <div class="col-sm-12">
                                <h4>Especificaciones Técnicas</h4>
                                <div id="divEspecifDet" runat="server">
                                </div>
                            </div>
                        </div>
                                  <!--CONTENT Información Técnica y Calidad-->
                        <div id="divInfoTecnica" class="tab-pane fade">
                            <h2>Información Técnica y Calidad</h2>
                            <!--Informe Semanal-->
                            <button class="btn btn-info" type="button" data-toggle="collapse" data-target="#collapseNewInfo" aria-expanded="false" aria-controls="collapseExample"><span class="glyphicon glyphicon-plus"></span>NUEVO INFORME</button>

                            <!-- COLLAPSED NEW DOCUMENT-->
                            <div class="newInfoForm" id="NewInfoTecnicaProyecto" runat="server">
                                <div class="collapse" id="collapseNewInfo">
                                    <div class="logForm">
                                        <form>
                                            <div class="form-group">
                                                <label for="user" class="hidden">Título del informe</label>
                                                <input type="text" class="form-control" id="txtNewTituloTecnica" placeholder="Titulo de la publicación">
                                            </div>
                                            <div class="form-group">
                                                <label for="descTxt" class="hidden">Descripción</label>
                                                <span class="label label-default fr">0/300</span>
                                                <textarea class="form-control" rows="3" id="txtNewDescTecnica" placeholder="Descripción"></textarea>
                                            </div>
                                            <div class="btn-group btn-group-justified" role="group" aria-label="...">
                                                <div class="btn-group" role="group">
                                                    <button id="btnNewAuditoTecnica" runat="server" type="button" class="btn btn-default"><span class="glyphicon glyphicon-volume-up"></span>Audio</button>
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <button id="btnNewImagenTecnica" runat="server" type="button" class="btn btn-default"><span class="glyphicon glyphicon-camera"></span>Imagen</button>
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <button id="btnNewVideoTecnica" runat="server" type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span>Video</button>
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <button id="btnNewDocTecnica" runat="server" type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span>Documento</button>
                                                </div>
                                            </div>
                                            <br />
                                            <button id="btnGuardarNewInfoTecnica" runat="server" class="btn btn-info"><span class="glyphicon glyphicon-cloud-upload"></span>PUBLICAR INFORME</button>

                                        </form>
                                    </div>
                                </div>
                            </div>
                            <div id="divInfoTecnicaDet" runat="server" class="list-group">
                                <%--<div class="list-group-item">
                                    <h4>Informe semanal de los avances de la obra</h4>
                                    <div class="col-sm-2 mediaItem">
                                        <img src="img/imgTest.jpg" /></div>
                                    <div class="col-sm-10">
                                        <p>
                                            Onec blandit ante dui, ac consectetur nisl mollis at. Donec vitae cursus felis. Morbi varius dolor dolor, ut malesuada enim euismod sed. Curabitur semper iaculis nibh sed vestibulum. Quisque facilisis, turpis vitae pulvinar maximus, lectus mi pellentesque diam, et accumsan diam metus vel ex. Pellentesque ligula libero, sagittis vel convallis eget, commodo sit amet odio. Fusce sit amet laoreet ligula, et efficitur diam.
                                        </p>
                                        <div class="btn btn-default">
                                            <a href="profileProject_DetailedDoc.html"><span class="glyphicon glyphicon-comment"></span>Ver Detalles</a>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                     <!--CONTENT Grupo de Auditores-->
                      <div id="divGrupos" class="tab-pane fade">
                        <h2>Grupo de Auditores</h2>
                        <div id="accordion" role="tablist" aria-multiselectable="true">
                        <!--LISTADO DE AUDITORES-->
                          <div class="card">
                            <div class="card-header" role="tab" id="headingOne">
                              <h5 class="mb-0">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                    Listado de Auditores <span class="glyphicon glyphicon-chevron-right"></span> </a>
                              </h5>
                            </div>
                              <div id="collapseOne" class="collapse in" role="tabpanel" aria-labelledby="headingOne">
                                  <div id="divListadoAudit" class="card-block auditoresList">
                                     <%-- <div class="row">
                                          <div class="col-sm-4">
                                              <div class="well well-sm">
                                                  <h4>Grupo 1</h4>
                                                  <ul>
                                                      <li>Nombre Auditor 1</li>
                                                      <li>Nombre Auditor 2</li>
                                                      <li>Nombre Auditor 3</li>
                                                      <li>Nombre Auditor 4</li>
                                                  </ul>
                                              </div>
                                          </div>
                                          <div class="col-sm-4">
                                              <div class="btn btn-info"><a href="">Plan de Trabajo</a></div>
                                              <div class="btn btn-info"><a href="">Gestión</a></div>
                                          </div>--%>
                                      </div>
                                  </div>
                              </div>
                          </div>
                          <!--GESTIÓN-->
                          <div class="card">
                            <div class="card-header" role="tab" id="headingTwo">
                              <h5 class="mb-0">
                                <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo"><span class="glyphicon glyphicon-chevron-right"></span>  Gestión
                                </a>
                              </h5>
                            </div>
                            <div id="collapseTwo" class="collapse" role="tabpanel" aria-labelledby="headingTwo">
                              <div class="card-block row">
                              	<div class="col-sm-3">
                                <!--CONVENCIONES-->
                                <div class="well well-sm convenciones">
                                	<div class="col-sm-12">
                                    	<div class="opcional"><span class="gestionIc"></span>Tareas Opcionales</div>
                                    </div>
                                	<div class="col-sm-12">
                                    	<div class="realizada"><span class="gestionIc"></span>Tareas Realizadas</div>
                                    </div>
                                    <div class="col-sm-12">
                                    	<div class="pendiente"><span class="gestionIc"></span>Tareas Pendientes</div>
                                    </div>
                                    <div class="col-sm-12">
                                    	<div class="deshabilitada"><span class="gestionIc"></span>Tareas Deshabilitadas</div>
                                    </div>
                                    
                                </div>
								<div class="buttonsHelp">
                                <a href="" role="button" class="btn btn-info">Postular Buenas Prácticas</a><br/>
                                <a href="" role="button" class="btn btn-default"><span class="glyphicon glyphicon-question-sign"></span>Ayuda</a></div>
                                </div>
                                <div class="col-sm-9 hitosBox">
                                	 <!--HITO 1-->
                                <div class="row itemGAC opcional">
                                	<div class="col-sm-7"><span class="gestionIc"><img src="img/icon_gestion_1.jpg"/></span><span>Inicio de Audiencias</span></div>
                                    <div class="col-sm-5"><a href="" role="button" class="btn btn-default"><span class="glyphicon glyphicon-eye-open"></span> VER ACTA</a>
                                    <a href=""><img src="img/FB-f-Logo__blue_29.png"/></a>
                                    <a href=""><img src="img/iconEmail.png"/></a>
                                    </div>
                                    <!--<div class="col-sm-2"></div>-->
                                </div>
                                 <div class="row itemGAC">
                                	<div class="col-sm-7"><span class="gestionIc"></span><span>Plan de Trabajo</span></div>
                                    <div class="col-sm-5"><a href="" role="button" class="btn btn-default"><span class="glyphicon glyphicon-eye-open"></span> VER ACTA</a></div>
                                    <!--<div class="col-sm-2"></div>-->
                                </div>
                                <div class="row itemGAC">
                                	<div class="col-sm-7"><span class="gestionIc"></span><span>Acta de la Audiencia</span></div>
                                    <div class="col-sm-5"><a href="" role="button" class="btn btn-default"><span class="glyphicon glyphicon-eye-open"></span> VER ACTA</a></div>
                                    <!--<div class="col-sm-2"></div>-->
                                </div>
                                <!--HITO 2-->
                                
                                <div class="row itemGAC">
                                	<div class="col-sm-7"><span class="gestionIc"></span><span>Informe del proceso</span></div>
                                    <div class="col-sm-5"><a href="" role="button" class="btn btn-default"><span class="glyphicon glyphicon-eye-open"></span> VER INFORME</a></div>
                                    <!--<div class="col-sm-2"></div>-->
                                </div>
                                 <!--HITO 1-->
                                <div class="row itemGAC realizada">
                                	<div class="col-sm-7"><span class="gestionIc"><img src="img/icon_gestion_2.jpg"/></span><span>Inicio de Audiencias</span></div>
                                    <div class="col-sm-5"><a href="" role="button" class="btn btn-default"><span class="glyphicon glyphicon-eye-open"></span> VER ACTA</a></div>
                                    <!--<div class="col-sm-2"></div>-->
                                </div>
                                 <div class="row itemGAC">
                                	<div class="col-sm-7"><span class="gestionIc"></span><span>Plan de Trabajo</span></div>
                                    <div class="col-sm-5"><a href="" role="button" class="btn btn-default"><span class="glyphicon glyphicon-eye-open"></span> VER ACTA</a></div>
                                    <!--<div class="col-sm-2"></div>-->
                                </div>
                                <div class="row itemGAC">
                                	<div class="col-sm-7"><span class="gestionIc"></span><span>Acta de la Audiencia</span></div>
                                    <div class="col-sm-5"><a href="" role="button" class="btn btn-default"><span class="glyphicon glyphicon-eye-open"></span> VER ACTA</a></div>
                                   <!-- <div class="col-sm-2"></div>-->
                                </div>
                                 <!--HITO 1-->
                                <div class="row itemGAC">
                                	<div class="col-sm-7"><span class="gestionIc blueBG"></span><span>Inicio de Audiencias</span></div>
                                    <div class="col-sm-5"><a href="" role="button" class="btn btn-default"><span class="glyphicon glyphicon-file"></span> GENERAR INFORME</a></div>
                                    <!--<div class="col-sm-2"></div>-->
                                </div>
                                <div class="row itemGAC">
                                	<div class="col-sm-7"><span class="gestionIc blueBG"></span><span>Evaluación Posterior</span></div>
                                    <div class="col-sm-5"><a href="" role="button" class="btn btn-default"><span class="glyphicon glyphicon-file"></span> VER INFORME</a> <a href="" role="button" class="btn btn-default"><span class="glyphicon glyphicon-file"></span>REGISTRAR EXPERIENCIAS</a></div>
                                    <!--<div class="col-sm-2"></div>-->
                                </div>
                                </div>
                              	
                               
                              </div>
                            </div>
                          </div>
                          
                        </div>
                      </div>


            </div>
    </div>
    <!-- /.container -->
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript('../../Scripts/ProyectosFunciones.js', function () {
        var id_proyecto = $("#hfidproyecto").val();
            verDetalleProyecto(id_proyecto);
        });
    }));
</script>
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