<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="infoProyecto.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Proyectos.infoProyecto" %>
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
    <input type="hidden" id="hfidproyecto" runat="server"/>
     <input type="hidden" id="hdIdUsuario" runat="server" />
    <div id="divEncabezadoProy" class="row">
        <div class="headSection">
            <div id="divPin" class="col-sm-12 headTit">
                <span>PROYECTO</span>
                <span class="badge" id="spnPinProyecto"></span>
            </div>
            <div class="col-sm-9" id="divDatosProyecto">
                <div id="txtNombreProyecto" runat="server"></div>
                <div id="divDetalleDatos" class="row detailInfo detalleEncabezadoProy">
                    <div id="divBtnUbicacion" class=" col-sm-6"><span class="glyphicon glyphicon-map-marker"></span>Ubicación:&nbsp;<span id="txtUbicaProyecto"></span> </div>
                    <div id="divBtnInfoEjec" class=" col-sm-6"><span class="glyphicon glyphicon-user"></span>Entidad Ejecutora:&nbsp; <span id="txtNomContratista"></span></div>
                </div>
            </div>
            <div id="divBotonesActions" class="col-sm-3 userActions detalleEncabezadoProy">
                <div class="btn btn-info btn-lg" id="btnSeguirProy"><span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span></div>
                <div class="btn btn-default" id="btnUnirseGAC" runat="server">
                    <span>
                        <img src="../../Content/img/iconHand.png" /></span><span>Crear G.A.C.</span>
                </div>
            </div>
        </div>
    </div>
    <div id="divCuerpoProy" class="row">
        <div class="col-sm-3">
            <div class="leftMenu" id="divOpcionesInfo">
                <!--TABS-->
                <ul class="nav nav-tabs nav-stacked" id="opcionesInfo">
                    <li id="itemGeneral" class="active"><a data-toggle="tab" href="#divGeneral">Información general <span class="glyphicon glyphicon-menu-right"></span></a></li>
                    <li id="itemFormulacion"><a data-toggle="tab" href="#divFormulacion">Formulación y aprobación <span class="glyphicon glyphicon-menu-right"></span></a></li>
                    <li id="itemContratista"><a data-toggle="tab" href="#divContratista">Contratista y vigilancia <span class="glyphicon glyphicon-menu-right"></span></a></li>
                    <li id="itemPresupuesto"><a data-toggle="tab" href="#divPresupuesto">Financiación y presupuesto <span class="glyphicon glyphicon-menu-right"></span></a></li>
                    <%--                  <li><a data-toggle="tab" href="#divPlaneacion">Planeación y Aprobación <span class="glyphicon glyphicon-menu-right"></span></a></li>--%>
                    <li id="itemInfoTecnica"><a data-toggle="tab" href="#divInfoTecnica">Información técnica y calidad <span class="glyphicon glyphicon-menu-right"></span></a></li>
                    <li id="itemGrupos"><a data-toggle="tab" href="#divGrupos">Grupos auditores ciudadanos <span class="glyphicon glyphicon-menu-right"></span></a></li>
                </ul>
            </div>
        </div>
        <div class="col-sm-9">
            <div class="generalInfo">
                <div id="divDetalleProyecto" class="tab-content responsive" runat="server">
                    <!--CONTENT1 GENERAL INFO-->
                    <div id="divGeneral" class="tab-pane fade in active">
                        <h2>Información general</h2>

                        <div class="col-sm-12">
                            <h4>Presupuesto total</h4>
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
                        <!--BENEFICIARIOS-->
                        <div class="col-sm-4">
                            <h4>Beneficiarios</h4>
                            <div id="divBeneficiarios" runat="server"></div>
                        </div>
                        <!--ENTIDAD-->

                        <div class="col-sm-12">
                            <h4>Entidad ejecutora de los recursos</h4>
                            <div id="divEntidadEjecDet" runat="server">
                            </div>

                        </div>
                        <!--PRODUCTOS DEL PROYECTO-->
                        <div class="col-sm-12">
                            <h4>Productos del proyecto</h4>
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
                            <h4>Cronograma de actividades</h4>
                            <div class="row">
                                <div class="col-sm-6 hideObj" id="divCronogramaPlan">
                                    <h5>Planeado</h5>
                                    <div runat="server" id="divCronogramaDet">
                                        <%--<div class="cronoItem">
                                            <span class="glyphicon glyphicon-flag"></span>
                                            <span class="dataHito">25 de Febrero 2016</span>
                                            <p>Duis sit amet gravida neque, eget aliquam sapien. Donec convallis enim urna, vitae malesuada orci volutpat id</p>
                                        </div>--%>
                                    </div>

                                </div>
                                <div class="col-sm-6 hideObj" id="divCronoEjec">
                                    <h5>Ejecutado</h5>
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
                        <!--INDICADORES DEL PROYECTO-->
                        <div class="col-sm-12">
                            <h4>Indicadores del proyecto</h4>
                            <div id="divIndicadores" runat="server">
                            </div>
                        </div>
                    </div>
                    <!--CONTENT4 Formulación y Aprobación-->
                    <div id="divFormulacion" class="tab-pane fade">
                        <h2>Formulación y aprobación</h2>
                        <!--fecha y OCAD-->
                        <p>Esta sección presenta información acerca de la fase en la que el proyecto fue diseñado y posteriormente aprobado en sesión del Órgano Colegiado de Administración y Decisión (OCAD) respectivo.
                            <br />Para conocer información adicional sobre la formulación y aprobación del proyecto, dirija su consulta a la secretaría técnica del OCAD donde se aprobó.
                            <br />Puede acceder a la explicación de qué es y qué tipos de OCAD existen en el siguiente enlace: (modulo de capacitación que tendremos sobre SGR).
                            </p>
                        <div class="col-sm-12">
                            <h4>Fecha y OCAD donde se aprobó el proyecto</h4>
                            <div id="divFechaOcadDet" runat="server"></div>
                        </div>
                        <!--Acta OCAD-->
                        <div class="col-sm-6">
                            <h4>Acta del OCAD mediante la cual se aprueba el proyecto</h4>
                            <div id="divNumActaOcad" runat="server"></div>
                            <div id="divActaOcadDocumento" runat="server" class="btn btn-default hideObj">
                                <a role="button" id="divActaOcadDet">
                                    <span class="glyphicon glyphicon-save-file"></span>
                                    Ver documento
                                </a>
                            </div>
                        </div>
                        <!--Criterios-->
                        <div class="col-sm-6">
                            <h4>Criterios de priorización del proyecto por encima de otros</h4>
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
                                <%--<ul class="list-group">
                                    <li class="list-group-item"><span class="glyphicon glyphicon-user"></span><span id="spnNomFormula"></span></li>
                                    <li class="list-group-item"><span class="glyphicon glyphicon-credit-card"></span><span id="spnIdentifFormula"></span></li>
                                    <li class="list-group-item"><span class="glyphicon glyphicon-envelope"></span><span id="spnEmailFormula"></span></li>
                                    <li class="list-group-item"><span class="glyphicon glyphicon-earphone"></span><span id="contactoFormula"></span></li>
                                </ul>--%>
                            </div>
                        </div>
                        <!--Ajustes-->
                        <div class="col-sm-12">
                            <h4>Acuerdos de aprobación de ajustes al proyecto</h4>
                            <div id="divAjustes" runat="server">
                            </div>
                        </div>
                        <!--Requisitos-->
                        <div class="col-sm-12">
                            <h4>Requisitos revisados para la ejecución del proyecto</h4>
                            <div id="divRequisitos" runat="server">
                            </div>
                        </div>
                    </div>
                    <!--CONTENT2 Contratista y Vigilancia-->
                    <div id="divContratista" class="tab-pane fade">
                            <div id="divContrato" runat="server"></div>
                         
                        <div id="divDetalleContrato" class="hideObj">
                            <input type="hidden" id="Hidden1" runat="server" />
                            <h2>Detalle del contrato </h2>
                            <div class="btn btn-default mtB15">
                                <a role="button"   onclick="volverListadoContrato();" id="btnVolverListadoContrato"><span class="glyphicon glyphicon-menu-left"></span>Volver al Listado</a>
                        </div>
                        <div class="card-block row">
                            <div id="divDetContrato">
                            </div>
                            </div>
                        </div>
                    </div>
                           
                    <!--CONTENT3 Financiación y Presupuesto-->
                    <div id="divPresupuesto" class="tab-pane fade">
                        <h2>Financiación y presupuesto</h2>
                        <p>En esta sección encontrará información sobre los recursos (de dinero y en especie) destinados para la ejecución del proyecto.</p>
                        <!--MONTOS DE COFINANCIACIÓN-->
                        <div class="col-sm-12">
                            <h4>Fuentes de financiación del proyecto</h4>
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
                            <h4>Modificaciones al presupuesto</h4>
                            <div class="table-responsive" id="divModifPresupDet" runat="server">
                            </div>
                        </div>
                        <!--Costo por productos/Actividad-->
                        <div class="col-sm-12">
                            <h4>Costo por producto y/o actividad</h4>
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
                            <h4>Pagos del contrato</h4>
                            <div class="table-responsive" id="divPagosContrato">
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
                                <h4>Documento de planeación</h4>
                                <div class="btn btn-default">
                                    <a role="button" id="divDocPlaDet"><span class="glyphicon glyphicon-save-file"></span>
                                        Ver documento</a>
                                </div>
                            </div>

                        </div>
                        <!--Especificaciones Técnicas-->
                        <div class="col-sm-12">
                            <h4>Especificaciones técnicas</h4>
                            <div id="divEspecifDet" runat="server">
                            </div>
                        </div>
                    </div>
                    <!--CONTENT Información Técnica y Calidad-->
                    <div id="divInfoTecnica" class="tab-pane fade">
                        <h2>Información técnica y calidad</h2>
                        <p>Aquí encontrará detalles de la información técnica y de calidad del proyecto. Esta información es diligenciada directamente por el interventor, quien inicialmente describirá las características generales del proyecto y posteriormente, reportará los informes y avances en su gestión. Podrá realizarle consultas directas y mantener comunicación con la persona designada para esta labor en la pestaña de “Espacio Virtual”, que está disponible en el menú principal.</p>
                        <div id="divInformacionCalidad" class="hideObj">
                            <!--Descripcion de informacion tecnica-->
                            <button class="btn btn-info" type="button" data-toggle="collapse" data-target="#collapseDescInfoTecncia" aria-expanded="false" aria-controls="collapseExample"><span class="glyphicon glyphicon-plus"></span>AGREGAR DESCRIPCIÓN</button>
                            <!-- COLLAPSED NEW DESC-->
                            <div class="newInfoForm" id="NewInformacionCalidad" runat="server">
                                <div class="collapse" id="collapseDescInfoTecncia">
                                    <div class="logForm">
                                        <div class="form-group required">
                                            <label for="user" class="hidden">Título</label>
                                            <input type="text" class="form-control" id="txtTituloInfoTecnica" placeholder="Titulo">
                                            <div id="error_txtTituloInfoTecnica" class="alert alert-danger alert-dismissible" hidden="hidden">Título no puede ser vacía</div>
                                        </div>
                                        <div class="form-group required">
                                            <label for="descTxt" class="hidden">Descripción</label>
                                            <span class="label label-default fr">0/300</span>
                                            <textarea class="form-control" rows="3" id="txtDescInfoTecnica" placeholder="Descripción"></textarea>
                                            <div id="error_txtDescInfoTecnica" class="alert alert-danger alert-dismissible" hidden="hidden">Descripción no puede ser vacía</div>
                                        </div>
                                        <br />
                                        <button id="btnAgregarDescInfoTecnica" runat="server" class="btn btn-info"><span class="glyphicon glyphicon-cloud-upload"></span>AGREGAR</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divItemsCalidad" class="hideObj">
                            <!--Informe Semanal-->
                            <button class="btn btn-info" type="button" data-toggle="collapse" data-target="#collapseNewInfo" aria-expanded="false" aria-controls="collapseExample"><span class="glyphicon glyphicon-plus"></span>NUEVO INFORME</button>
                            <!-- COLLAPSED NEW DOCUMENT-->
                            <div class="newInfoForm" id="NewInfoTecnicaProyecto" runat="server">
                                <div class="collapse" id="collapseNewInfo">
                                     <div class="logForm">
                                            <div class="form-group">
                                                <label for="user" class="hidden">Título del informe</label>
                                                <input type="text" class="form-control" id="txtNewTituloTecnica" placeholder="Titulo de la publicación">
                                                <div id="error_txtNewTituloTecnica" class="alert alert-danger alert-dismissible" hidden="hidden">Título no puede ser vacía</div>
                                            </div>
                                            <div class="form-group">
                                                <label for="descTxt" class="hidden">Descripción</label>
                                                <span class="label label-default fr">0/300</span>
                                                <textarea class="form-control" rows="3" id="txtNewDescTecnica" placeholder="Descripción"></textarea>
                                                <div id="error_txtNewDescTecnica" class="alert alert-danger alert-dismissible" hidden="hidden">Descripción no puede ser vacía</div>
                                            </div>
                                            <div class="btn-group btn-group-justified" role="group" aria-label="...">
                                                <%--                                                <div class="btn-group" role="group">
                                                    <button id="btnNewAuditoTecnica" runat="server" type="button" class="btn btn-default"><span class="glyphicon glyphicon-volume-up"></span>Audio</button>
                                                </div>--%>
                                                <div class="btn-group" role="group">
                                                    <%--<button id="btnNewImagenTecnica" runat="server" type="button" class="btn btn-default"><span class="glyphicon glyphicon-camera"></span>Imagen</button>--%>
                                                        <input id="btnNewImagenTecnica" name="btnNewImagenTecnica[]" type="file" multiple class="file-loading">
                                                     <div id="kv-error-1" style="margin-top:10px;display:none"></div>
                                                    <div id="kv-success-1" class="alert alert-success fade in" style="margin-top:10px;display:none"></div>
                                                </div>
                                                <%--                                                <div class="btn-group" role="group">
                                                    <button id="btnNewVideoTecnica" runat="server" type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span>Video</button>
                                                </div>--%>
                                               <%-- <div class="btn-group" role="group">
                                                    <button id="btnNewDocTecnica" runat="server" type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span>Documento</button>
                                                </div>--%>
                                            </div>
                                            <br />
                                            <button id="btnGuardarNewInfoTecnica" runat="server" class="btn btn-info"><span class="glyphicon glyphicon-cloud-upload"></span> PUBLICAR INFORME </button>
                                    </div>
                                               </div>
                            </div>
                            <div id="divInfoTecnicaDet" runat="server" class="list-group">
                            </div>
                        </div>
                        <!--CONTENT Información DETALLADA Técnica y Calidad-->
                        <div id="divDetalleFormCalidad" class="hideObj">
                            <input type="hidden" id="hd_infoTecnica" runat="server" />
                            <h2>Información técnica y calidad </h2>
                            <div class="btn btn-default mtB15">
                                <a role="button" id="btnVolverListadoCalidad"><span class="glyphicon glyphicon-menu-left"></span>Volver al Listado</a>
                            </div>
                            <div class="list-group-item">
                                <button id="btnEditarContenidoCalidad" class="btn btn-default fr"><span class="glyphicon glyphicon-edit"></span>Editar Contenido</button>
                                <h4>
                                    <div id="divTituloDetCalidad"></div>
                                </h4>
                                <div class="row">
                                    <div class="col-sm-12" id="divTextoDetCalidad">
                                        <%--<p>
                                                    texto_detallado
                                                </p>--%>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="row">
                                    <div class="col-sm-12" id="divImagenesCarousel" runat="server">
                                        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                                            <!-- Indicators -->
                                            <ol class="carousel-indicators">
                                                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                                                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                                                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                                            </ol>
                                            <!-- Wrapper for slides -->
                                            <div class="carousel-inner" role="listbox">
                                                <div class="item active">
                                                    <img src="../../Content/img/imgTest.jpg" alt="...">
                                                </div>
                                                <div class="item">
                                                    <img src="../../Content/img/imgTest2.jpg" alt="...">
                                                </div>
                                                <div class="item">
                                                    <img src="../../Content/img/imgTest3.jpg" alt="...">
                                                </div>
                                            </div>

                                            <!-- Controls -->
                                            <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                                                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                                <span class="sr-only">Anterior</span>
                                            </a>
                                            <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                                                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                                <span class="sr-only">Siguiente</span>
                                            </a>
                                        </div>
                                    </div>
                                    <div class="col-sm-2 hideObj" id="divBtnDescargaDocInfoDet">
                                        <div class="btn btn-default">
                                            <a id="btnDescargarDocDetalle"><span class="glyphicon glyphicon-save-file"></span>Descargar Documento</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divInfoDescCalidad" class="list-group-item">
                            <%--<h2><div id="divTituloInfoDescCalidad"></div></h2>
                                <div class="row">
                                    <div class="col-sm-12" id="divTextoIfoDescCalidad">
                                       
                                    </div>
                                </div>--%>
                        </div>
                        <!--  /. CONTENT Información DETALLADA Técnica y Calidad-->
                    </div>
                    <!--CONTENT Grupo de Auditores-->
                    <div id="divGrupos" class="tab-pane fade">
                        <h2>Grupo(s) auditor(es) ciudadano(s) registrados</h2>
                        <div id="accordion" role="tablist" aria-multiselectable="true">
                            <!--LISTADO DE AUDITORES-->
                            <div id="divCardGrupos" class="card">

                                <div class="card-block auditoresList">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <!--GRUPO DE AUDITORES-->
                                            <div id="divListadoAudit">
                                                <%-- <div class="card card-block">
                                  <div class="card-title">
                                  <h4>Grupo de Auditores A <a href="#" class="fr" title="Unirse al GAC"><img src="img/iconHand.png"/></a><a href="#" class="fr"><img src="img/FB-f-Logo__blue_29.png"/></a>
                                  <a href="#" class="fr"><img src="img/iconEmail.png"/></a></h4>
                                  <div class="card-block clearfix">
                                  <div class="btn btn-info"><a href="">Plan de Trabajo</a>
                                  </div>
                                  <div class="btn btn-info"><a href="profileProject_DetailedDoc.html">Gestión</a></div>
                                  
                                  </div>
                                  </div>
                                  <div class="list-group uppText">
                                    <div class="list-group-item">
                                
                                    <div class="col-sm-6"><span class="glyphicon glyphicon-user"></span> Luke Sky Walker
                                   </div>
                                    <div class="col-sm-2"><span class="glyphicon glyphicon-earphone"></span> <span>304 6579876</span> </div>
                                    <div class="col-sm-4"><span class="glyphicon glyphicon-envelope"></span> <span><a href="mailto:#">luke@gac1.com</a></span></div>
                                    
                                    </div>
                                   
                                  </div>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--GESTIÓN-->
                            <div id="divDetalleGestion" class="hideObj">
                                <div id="" class="btn btn-default mtB15">
                                    <a role="button" onclick="volverListadoGrupos();"><span class="glyphicon glyphicon-menu-left"></span>Volver al Listado</a>
                                </div>
                                <div class="card" id="divArbol">
                                    <h5>Gestión</h5>
                                    <div id="divArbol_1" class="card-block row">
                                        <div class="col-sm-3">
                                            <!--CONVENCIONES-->
                                            <div class="well well-sm convenciones">
                                                <div class="col-sm-12">
                                                    <div class="opcional"><span class="gestionIc"></span>Pasos Opcionales</div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div class="realizada"><span class="gestionIc"></span>Pasos Realizados</div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div class="pendiente"><span class="gestionIc"></span>Pasos Pendientes</div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div class="deshabilitada"><span class="gestionIc"></span>Pasos Deshabilitados</div>
                                                </div>

                                            </div>
                                            <div class="buttonsHelp">
                                                <a href="#" role="button" onclick="generarReporteHallazgos()" class="btn btn-info">Reportar hallazgos</a><br />
                                                <a href="" role="button" class="btn btn-default"><span class="glyphicon glyphicon-question-sign"></span>Ayuda</a>
                                            </div>
                                        </div>
                                        <div class="col-sm-9">
                                         <p> Aquí se reportan las actividades que realizan los Auditores Ciudadanos de acuerdo a los momentos considerados para este ejercicio de control social.Aparecerán cada uno de los pasos que deberán ser superados con los soportes correspondientes. Esto permitirá que el ejercicio de control social quede sistematizado y permita ser utilizado para la toma de decisiones de los actores institucionales involucrados.<br />
                                             Esta gestión está relacionada con el Plan de Trabajo, ya que en cada paso se consolidan los informes de reporte de las actividades realizadas, las observaciones identificadas y las sugerencias que se proponen desde la ciudadanía para lograr una adecuada ejecución de los proyectos financiados con recursos de regalías.Una vez los pasos sean abordados cambiarán de color, para indicar los avances que tiene el grupo frente a las labores propuestas para el Auditor Ciudadano.</p>

                                        <div class="col-sm-9 hitosBox" id="divGestion">
                                            </div>
                                        </div>
                                    </div>


                                </div>


                            </div>

                            <div id="divReporteHallazgos" class="hideObj">
                                
                               <%-- <div class="card">
                                    <h5>Hallazgos</h5>
                                    <div class="card-block row">
                                        <div class="col-sm-9" id="divInformeHallazgos">
                                        </div>
                                    </div>
                                </div>--%>
                            </div>



                            <div id="divDetallePlanTrabajo" class="hideObj">
                                <div id="" class="btn btn-default mtB15">
                                    <a role="button" class="volver_listado" onclick="volverListadoGrupos();"><span class="glyphicon glyphicon-menu-left"></span>Volver al Listado</a>
                                </div>
                                <div class="card">
                                    <h5>Plan de Trabajo Will</h5>
                                    <div class="card-block row">
                                        <div class="col-sm-9" id="divPlanTrabajoGrupo">
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
        <div class="row hideObj" id="divPlantillasProy">
          <div class="plantillasHeader">
              <h5>
                  <a id="btnVolverMenusProy" role="button" onclick="volverListadoMenuProy();"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER AL LISTADO
                  </a>
              </h5>
              </div>
            <div id="divCodPlantilla">

            </div>
        </div>                          
    <div id="divModalAviso">
        <button id="btnOpenModal" type="button" class="btn btn-info btn-lg hideObj" data-toggle="modal" data-target="#myModal"></button>
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">DETALLE PROYECTO</h4>
                    </div>
                    <div class="modal-body">
                        <p>Recuerde que si desea unirse a un grupo auditor o seguir este proyecto, debe estar registrado en el Sistema. Si ya lo está, ingrese con sus credenciales.</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Aceptar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
                            
    <!-- /.container -->
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript('../../Scripts/ProyectosFunciones.js', function () {
           $.getScript('../../Scripts/ProyectosAcciones.js', function () {
            var id_proyecto = $("#hfidproyecto").val();
            var id_usuario = $("#hdIdUsuario").val();
            if (id_usuario == "") {
              $("#btnOpenModal").trigger("click");
            }
            verDetalleProyecto(id_proyecto, id_usuario);
        });
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