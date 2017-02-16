<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="infoProyecto.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Proyectos.infoProyecto" %>
 <!-- MIGA DE PAN -->
    <div class="container">
    	<div class="row">
    	<ol class="breadcrumb">
          <li><a href="#">Inicio</a></li>
          <li><a role="button" onclick="cargaMenu('AccesoInformacion/BuscadorProyectosAuditores','dvPrincipal');">Proyectos</a></li>
          <li class="active">Información del proyecto</li>
        </ol>
        </div>
    </div>
 <!-- Page Content -->
<div class="container">
     <input type="hidden" id="hfidproyecto" runat="server"/>
     <input type="hidden" id="hdIdUsuario" runat="server" />
     <input type="hidden" id="hdCantGrupos" runat="server" />
     <input type="hidden" id="hdAccion" runat="server" />
     <input type="hidden" id="hdAuditorProy" runat="server" />
    <div id="divEncabezadoProy" class="row">
        <div class="headSection">
            <div id="divPin" class="col-sm-12 headTit">
                <span>PROYECTO</span>
                <span class="badge bpinTexto" role="button" title="Si busca mayor información de este proyecto este número facilitará la búsqueda de mayor información. Este número es asignado después de la aprobación en el OCAD" id="spnPinProyecto"></span>
            </div>
            <div class="col-sm-9" id="divDatosProyecto">
                <div id="txtNombreProyecto" runat="server"></div>
                <div id="divDetalleDatos" class="row detailInfo detalleEncabezadoProy">
                    <div id="divBtnUbicacion" class=" col-sm-6"><span class="glyphicon glyphicon-map-marker"></span>Ubicación:&nbsp;<span id="txtUbicaProyecto"></span> </div>
                    <div id="divBtnInfoEjec" class=" col-sm-6"><span class="glyphicon glyphicon-user"></span>Entidad Ejecutora:&nbsp; <span id="txtNomContratista"></span></div>
                </div>
            </div>
            <div id="divBotonesActions" class="col-sm-3 userActions detalleEncabezadoProy">
                <div class="btn btn-info btn-lg hideObj" id="btnSeguirProy"><span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span></div>
                <%--<div class="btn btn-default" id="btnUnirseGAC" runat="server">
                    <span>
                        <img src="../../Content/img/iconHand.png" /></span><span>Crear G.A.C.</span>
                </div>--%>
            </div>
        </div>
    </div>
    <div class="row hideObj" id="divTextoGrupos"><h4>Para unirse a un Grupo Auditor Ciudadano, por favor seleccione la mano correspondiente <img src="../../Content/img/iconHand.png"></h4></div>
    <div id="divCuerpoProy" class="row">
        <div class="col-sm-3">
            <div class="row form-group">
                <div class="leftMenu" id="divOpcionesInfo">
                        <!--TABS-->
                        <ul class="nav nav-tabs nav-stacked" id="opcionesInfo">
                            <li id="itemGeneral" class="active"><a id="enlaceGeneral" data-toggle="tab" href="#divGeneral">Información general <span class="glyphicon glyphicon-menu-right"></span></a></li>
                            <li id="itemFormulacion"><a id="enlaceFormulacion" data-toggle="tab" href="#divFormulacion">Formulación y aprobación <span class="glyphicon glyphicon-menu-right"></span></a></li>
                            <li id="itemPresupuesto"><a id="enlacePresupuesto" data-toggle="tab" href="#divPresupuesto">Financiación y presupuesto <span class="glyphicon glyphicon-menu-right"></span></a></li>
                            <li id="itemContratista"><a id="enlaceContratista" data-toggle="tab" href="#divContratista">Contratistas y supervisión <span class="glyphicon glyphicon-menu-right"></span></a></li>
                            <%--<li><a data-toggle="tab" href="#divPlaneacion">Planeación y Aprobación <span class="glyphicon glyphicon-menu-right"></span></a></li>--%>
                            <li id="itemInfoTecnica"><a id="enlaceTecnica" data-toggle="tab" href="#divInfoTecnica">Información técnica y calidad <span class="glyphicon glyphicon-menu-right"></span></a></li>
                            <li id="itemGrupos"><a id="enlaceGrupos" data-toggle="tab" href="#divGrupos">Grupos auditores ciudadanos <span class="glyphicon glyphicon-menu-right"></span></a></li>
                        </ul>
                 </div>
            </div>
            <div class="row form-group text-left" id="divCrearGAC">
                <div class="btn btn-default" id="btnUnirseGAC" runat="server">
                    <span>
                        <img src="../../Content/img/iconHand.png" /></span><span>Crear G.A.C.</span>
                </div>
            </div>
            <div id="divInformativo" class="row form-group text-justify" runat="server">
                <p>Esta información es reportada por el ejecutor del proyecto a través de los sistemas de información del DNP, para información adicional consultar a la entidad ejecutora del proyecto</p>
            </div>
            
        </div>
        <div class="col-sm-9">
            <div class="generalInfo">
                <div id="divDetalleProyecto" class="tab-content responsive" runat="server">
                    <!--CONTENT1 GENERAL INFO-->
                    <div id="divGeneral" class="tab-pane fade in active">
                        <h2>Información general</h2>
                        <div class="col-sm-7">
                            <h4>Presupuesto total</h4>
                            
                            <div id="divPresupuestoTotal" runat="server" class="alert alert-info"></div>
                            <div id="divPresupuestoTotal_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Es el valor de los recursos asignados para la ejecución del proyecto. Puede incluir recursos de regalías y otras fuentes.</span>
                            </div>
                        </div>
                        <div class="col-sm-5">
                            <h4>Estado</h4>
                            
                            <div id="divEstado" runat="server" class="alert alert-info"></div>
                            <div id="divEstado_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>La condición en la que un proyecto se encuentra según su avance físico, financiero o contractual.</span>
                            </div>
                            <br /><br />
                        </div>
                        <!--sector al que apunta-->
                        <div class="col-sm-4">
                            <h4>Sector al que apunta</h4>
                             
                            <div id="divSectorDet" runat="server" class="alert alert-info"></div>
                            <div id="divSectorDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Clasificación de la inversión a partir de su principal objeto, por ejemplo: educación, salud, transporte, entre otros. Para regalías no hay ninguna restricción de inversión.</span>
                            </div>
                        </div>
                        <!--LOCALIZACION-->
                        <div class="col-sm-4">
                            <h4>Localización</h4> 
                             
                            <div id="divLocalizacionDet" runat="server" class="alert alert-info"></div>
                            <div id="divLocalizacionDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Lugar en cual se ubica la ejecución del proyecto, por ejemplo: Vereda, municipio, departamento.</span>
                            </div>
                        </div>
                        <!--BENEFICIARIOS-->
                        <div class="col-sm-4">
                            <h4>Beneficiarios</h4>
                             
                            <div id="divBeneficiarios" runat="server" class="alert alert-info"></div>
                            <div id="divBeneficiarios_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>En la formulación del proyecto se identifica quiénes harán uso del proyecto después de su ejecución. Los beneficiarios pueden ser, por ejemplo: número de personas, familia, estudiantes, entre otros.</span>
                            </div>
                        </div>
                        <!--ENTIDAD-->

                        <div class="col-sm-12">
                            <h4>Entidad ejecutora de los recursos</h4>
                            
                            <div id="divEntidadEjecDet" runat="server" class="alert alert-info"></div>
                            <div id="divEntidadEjecDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Entidad responsable de la contratación de los recursos y de la entrega de los bienes y servicios, producto de la ejecución proyectos.</span>
                            </div>

                        </div>
                        <!--PRODUCTOS DEL PROYECTO-->
                        <div class="col-sm-12">
                            <h4>Productos del proyecto</h4>
                             
                            <div id="divProductosDet" runat="server" class="alert alert-info"></div>
                            <div id="divProductosDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Bienes y servicios generados a partir de la ejecución del proyecto, por ejemplo: Kilometros de carretera construidas, número de aulas construidas, etc.</span>
                            </div>
                        </div>
                         <!--INDICADORES DEL PROYECTO-->
                        <div class="col-sm-12">
                            <h4>Indicadores del proyecto</h4>
                            
                            <div id="divIndicadores" runat="server"></div>
                            <div id="divIndicadores_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Los indicadores son información cuantitativa o cualitativa que expresa un resultado. En este sentido, los indicadores de los proyectos miden los productos y resultados obtenidos al ejecutar el proyecto.</span>
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
                            <div id="divCronograma_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Listado de las actividades que se deben realizar durante la ejecución del proyecto. Encontrará la información inicialmente planeada y el cumplimiento real durante la ejecución.</span>
                            </div>
                        </div>
                         <div class="col-sm-12">
                            <h4>Requisitos de Cierre</h4>
                            <div id="divRequisitos" runat="server"></div>
                            <div id="divRequisitosCierre_help" class="form-group"><span class="glyphicon glyphicon-info-sign XLtext"></span><span>Son requerimientos mínimos que valida el Sistema de Monitoreo para habilitar el cierre del proyecto en el Gesproy SGR.</span></div>
                            
                        </div>
                       
                    </div>
                    <!--CONTENT4 Formulación y Aprobación-->
                    <div id="divFormulacion" class="tab-pane fade">
                        <h2>Formulación y aprobación</h2>
                        <!--fecha y OCAD-->
                        <div id="divFormulacion_help" class="form-group">
                           <p>Esta pestaña resume la información relacionada con la aprobación del proyecto por el Órgano Colegiado de Administración y Decisión (OCAD) respectivo. A continuación, encontrará referencias sobre fecha de aprobación en el OCAD, los datos del acuerdo con el cual fue aprobado, entre otros aspectos.
                            </p><p>En el caso de que la información no esté completa o requiera información complementaria, dirija su consulta a la Secretaría Técnica del OCAD respectivo.
                            </p>
                        </div>
                       
                        <div class="col-sm-12">
                            <h4>Fecha y OCAD donde se aprobó el proyecto</h4>
                            <div id="divFechaOcadDet" runat="server" class="alert alert-info"></div>
                            <div id="divFechaOcadDet_help" class="form-group"><span class="glyphicon glyphicon-info-sign XLtext"></span><span>Los OCAD viabilizan*, priorizan, aprueban y designan ejecutor de los proyectos presentados por su secretaría técnica, que serán financiados con recursos del Sistema General de Regalías. *Para proyectos que no tengan financiación del presupuesto general de la nación.</span></div>

                        </div>
                        <!--Acta OCAD-->
                        <div class="col-sm-12">
                            <h4>Número y fecha del acuerdo con el que se aprueba el proyecto</h4>
                            <div id="divNumActaOcad" runat="server" class="alert alert-info"></div>
                            <div id="divNumActaOcad_help" class="form-group"><span class="glyphicon glyphicon-info-sign XLtext"></span><span>Documento a través del cual se oficializa la decisión de aprobar el proyecto por parte del OCAD.</span></div>
                            <div id="divActaOcadDocumento" runat="server" class="btn btn-default hideObj">
                                <a role="button" id="divActaOcadDet">
                                    <span class="glyphicon glyphicon-save-file"></span>
                                    Ver documento
                                </a>
                            </div>
                        </div>
                        <!--Criterios-->
                        <%--<div class="col-sm-6">
                            <h4>Criterios de priorización del proyecto por encima de otros</h4>
                            <div id="divCriteriosDetTexto_help" class="form-group"><span class="glyphicon glyphicon-info-sign XLtext"></span><span>Se espera que los miembros del OCAD expresen y comuniquen las razones por las cuales un proyecto es aprobado frente a los demás analizados en la sesión.</span></div>
                            <div id="divCriteriosDetTexto" runat="server" class="alert alert-info"></div>
                            <div id="divCriteriosDocumento" class="btn btn-default hideObj"><a>
                                    <span class="glyphicon glyphicon-save-file"></span>Ver Documento</a>
                            </div>
                        </div>--%>
                        <!--proyectos Presentados al OCAD-->
                        <%--<div class="col-sm-12">
                            <h4>Proyectos presentados al OCAD</h4>
                            <div id="divPresOcadDet_help" class="form-group"><span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>A partir de la información reportada por la secretaría técnica, el siguiente ítem presenta la información sobre todos los proyectos que fueron presentados ante el OCAD para su evaluación.</span></div>
                            <div id="divPresOcadDet" runat="server" class="alert alert-info">
                            
                            </div>
                        </div>--%>
                        <!--Datos de quien formuló-->
                        <%--<div class="col-sm-12">
                            <h4>Datos de quien formuló/estructuró el proyecto</h4>
                            <div id="divPersonaDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>La siguiente ficha incluye la información de contacto de quién formuló y presentó el proyecto frente a la secretaría técnica del OCAD.</span>
                            </div>
                            <div id="divPersonaDet" runat="server" class="alert alert-info">
                                <ul class="list-group">
                                    <li class="list-group-item"><span class="glyphicon glyphicon-user"></span><span id="spnNomFormula"></span></li>
                                    <li class="list-group-item"><span class="glyphicon glyphicon-credit-card"></span><span id="spnIdentifFormula"></span></li>
                                    <li class="list-group-item"><span class="glyphicon glyphicon-envelope"></span><span id="spnEmailFormula"></span></li>
                                    <li class="list-group-item"><span class="glyphicon glyphicon-earphone"></span><span id="contactoFormula"></span></li>
                                </ul>
                            </div>
                        </div>--%>
                        <!--Ajustes-->
                        <div class="col-sm-12">
                            <h4>Acuerdos de aprobación de ajustes al proyecto</h4>
                            
                            <div id="divAjustes" runat="server">
                            </div>
                            <div id="divAjustes_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Documento a través del cual se oficializa la decisión de ajustar el proyecto por parte del OCAD.</span>
                            </div>
                        </div>
                        <!--Requisitos-->
                        <div class="col-sm-12">
                            <h4>Fecha de cumplimiento de los requisitos previos a la ejecución</h4>
                            <div id="divFechaRequisitos" runat="server"></div>
                            <div id="divRequisitos_help" class="form-group"><span class="glyphicon glyphicon-info-sign XLtext"></span><span>Previo al inicio del proceso de contratación, la entidad ejecutora debe cumplir unos requisitos técnicos y legales que son verificados por la secretaría técnica. Para mayor información contactarse con la entidad ejecutora.</span></div>
                            
                        </div>
                        
                       
                        <div class="col-sm-12">
                            <div id="divOCAD_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>En el caso de que quiera profundizar en la información de formulación, priorización, viabilización y aprobación dirija su consulta a la Secretaría Técnica del OCAD correspondiente.</span>
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
                        <p>En esta sección se encuentra información sobre los recursos (en dinero o en especie) destinados para la ejecución del proyecto.</p>
                        <!--MONTOS DE COFINANCIACIÓN-->
                        <div class="col-sm-12">
                            <h4>Fuentes de financiación del proyecto</h4>
                            <div class="table-responsive" id="divPresupuestoDet"> </div>
                            <div id="divPresupuestoDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Contiene información de todas las fuentes que financian el proyecto.</span>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <h4>Ejecución física y financiera</h4>
                            <div class="table-responsive" id="divEjecucionDet"> </div>
                            <div id="divEjecucionDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>•	Ejecución Financiera: Indicador que calcula la proporción del valor ejecutado y pagado frente a los bienes y/o servicios contemplados en el proyecto.</span>
                                <span><br />     •	Ejecución Física: Indicador que calcula la proporción de productos (bienes y/o servicios) realizados en el desarrollo del proyecto</span>
                            </div>
                        </div>
                        <!--MODIFICACIONES AL PRESUPUESTO-->
                       <%-- <div class="col-sm-12">
                            <h4>Modificaciones al presupuesto</h4>
                             <div id="divModifPresupDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Se reportan los posibles cambios que se pueden darse al presupuesto inicial del proyecto</span>
                            </div>
                            <div class="table-responsive" id="divModifPresupDet" runat="server">
                            </div>
                        </div>--%>
                        <!--Costo por productos/Actividad-->
                      <%--  <div class="col-sm-12">
                            <h4>Costo por producto y/o actividad</h4>
                             <div id="divCostoActividadDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Cálculo que promedia el valor de los productos o actividades contempladas en el proyecto</span>
                            </div>
                            <div class="table-responsive" id="divCostoActividadDet">
                               
                            </div>
                        </div>--%>
                        <!--Pagos del contrato -->
                        <div class="col-sm-12">
                            <h4>Pagos del contrato</h4>
                            <div class="table-responsive" id="divPagosContrato">
                            </div>
                             <div id="divPagosContrato_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Pagos que se han efectuado a los contratistas (sea Contratos de bienes y/o servicios o del Interventor) destacando la fuente de financiación de la cual se hace el desembolso.</span>
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
        <div id="divInformacionCalidad_help">
            <p>Aquí encontrará detalles de la información técnica y de calidad del proyecto. Esta información es diligenciada directamente por el interventor, quien inicialmente describirá las características generales del proyecto y posteriormente, reportará los informes y avances en su gestión.</p>
        </div>
        <div id="divInformacionCalidad" class="hideObj">
            <!--Descripcion de informacion tecnica-->
            <button class="btn btn-info" type="button" data-toggle="collapse" data-target="#collapseDescInfoTecncia" aria-expanded="false" aria-controls="collapseExample"><span class="glyphicon glyphicon-plus"></span>AGREGAR DESCRIPCIÓN</button>
            <!-- COLLAPSED NEW DESC-->
            <div class="newInfoForm" id="NewInformacionCalidad" runat="server">
                <div class="collapse" id="collapseDescInfoTecncia">
                    <div class="logForm">
                        <div class="form-group">
                            <label for="txtTituloInfoTecnica" class="hidden required">Título</label>
                            <input type="text" class="form-control" id="txtTituloInfoTecnica" placeholder="Titulo">
                            <div id="error_txtTituloInfoTecnica" class="alert alert-danger alert-dismissible" hidden="hidden">Título no puede ser vacío</div>
                        </div>
                        <div class="form-group required">
                            <label for="txtDescInfoTecnica" class="hidden required">Descripción</label>
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
            <button id="btnNuevoInforme" class="btn btn-info hideObj" type="button" data-toggle="collapse" data-target="#collapseNewInfo" aria-expanded="false" aria-controls="collapseExample"><span class="glyphicon glyphicon-plus"></span>NUEVO INFORME</button>
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
                                <div id="kv-error-1" style="margin-top: 10px; display: none"></div>
                                <div id="kv-success-1" class="alert alert-success fade in" style="margin-top: 10px; display: none"></div>
                            </div>
                            <%--                                                <div class="btn-group" role="group">
                                                    <button id="btnNewVideoTecnica" runat="server" type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span>Video</button>
                                                </div>--%>
                            <%-- <div class="btn-group" role="group">
                                                    <button id="btnNewDocTecnica" runat="server" type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span>Documento</button>
                                                </div>--%>
                        </div>
                        <br/>
                        <div id="divBotonesInfo">
                        <button id="btnGuardarNewInfoTecnica" runat="server" class="btn btn-info"><span class="glyphicon glyphicon-cloud-upload"></span>PUBLICAR INFORME </button>
                        <button id="btnEditarNewInfoTecnica" runat="server" class="btn btn-info hideObj"><span class="glyphicon glyphicon-cloud-upload"></span>GUARDAR </button>
                        </div>
                        
                    </div>
                </div>
            </div>
            <div id="divInfoTecnicaDet" runat="server" class="list-group">
            </div>
        </div>
        <!--CONTENT Información DETALLADA Técnica y Calidad-->
        <div id="divDetalleFormCalidad" class="hideObj">
            <input type="hidden" id="hd_infoTecnica" runat="server" value="" />
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
                    </div>
                </div>
                <div class="clearfix"></div>
                <div class="row">
                    <div class="col-sm-12" id="divImagenesCarousel" runat="server">

                    </div>
                    <div class="col-sm-2 hideObj" id="divBtnDescargaDocInfoDet">
                        <div class="btn btn-default">
                            <a id="btnDescargarDocDetalle"><span class="glyphicon glyphicon-save-file"></span>Descargar Documento</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="divInfoDescCalidad" class="list-group-item hideObj">
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
                                                <div id="divBtnHallazgos" runat="server"></div>
                                                <a role="button" onclick="generarAyuda();" class="btn btn-default"><span class="glyphicon glyphicon-question-sign"></span>Ayuda</a>
                                            </div>
                                        </div>
                                        <div class="col-sm-9">
                                            <div id="divGestion_help">
                                                <p> Aquí se reportan las actividades que realizan los Auditores Ciudadanos de acuerdo a los momentos considerados para este ejercicio de control social.Aparecerán cada uno de los pasos que deberán ser superados con los soportes correspondientes. Esto permitirá que el ejercicio de control social quede sistematizado y permita ser utilizado para la toma de decisiones de los actores institucionales involucrados.<br />
                                             Esta gestión está relacionada con el Plan de Trabajo, ya que en cada paso se consolidan los informes de reporte de las actividades realizadas, las observaciones identificadas y las sugerencias que se proponen desde la ciudadanía para lograr una adecuada ejecución de los proyectos financiados con recursos de regalías.Una vez los pasos sean abordados cambiarán de color, para indicar los avances que tiene el grupo frente a las labores propuestas para el Auditor Ciudadano.</p>
                                            </div>
                                        <div class="col-sm-12 hitosBox" id="divGestion">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--<div id="divReporteHallazgos">
                                <div id="" class="btn btn-default mtB15">
                                    <a role="button" class="volver_listado" onclick="volverDetalleGestion();"><span class="glyphicon glyphicon-menu-left"></span>Volver al Detalle de Gestión</a>
                                </div>
                                <div class="card">
                                    <h5>Hallazgos</h5>
                                    <div class="card-block row">
                                        <div class="col-sm-9" id="divInformeHallazgos">
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                            <div id="divDetallePlanTrabajo" class="hideObj">
                                <div id="" class="btn btn-default mtB15">
                                    <a role="button" class="volver_listado" onclick="volverListadoGrupos();"><span class="glyphicon glyphicon-menu-left"></span>Volver al Listado</a>
                                </div>
                                <div class="card">
                                    <h5>Plan de Trabajo</h5>
                                    <div id="divPlanTrabajoGrupo_help" class="form-group">
                                    <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                    <span>En este plan se registran las actividades que se propone realizar el grupo auditor a partir del análisis de la información del proyecto. Debería definir actividades, responsables y tiempos.</span>
                                </div>
                                    <div class="card-block row">
                                        <div class="col-sm-12" id="divPlanTrabajoGrupo">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="divDetalleTarea" class="hideObj">
                                <div id="" class="btn btn-default mtB15">
                                    <a role="button" class="volver_listado" onclick="volverPlanTrabajo();"><span class="glyphicon glyphicon-menu-left"></span>Volver al plan de trabajo</a>
                                </div>
                                <div class="card">
                                    <div class="card-block row">
                                        <div class="col-sm-10" id="divDetalleTareaPlanTrabajoGrupo">
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
        <button id="btnOpenModal" type="button" class="btn btn-info btn-lg hideObj" data-toggle="modal" data-target="#myModalGAC"></button>
        <div class="modal fade" id="myModalGAC" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">PARTICIPAR EN UN GAC</h4>
                    </div>
                    <div class="modal-body">
                        <p>Participar en un Grupo Auditor Ciudadano (GAC) le permite interactuar y colaborar en el trabajo de otros auditores ciudadanos que están vigilando el proyecto de su interés.</p>
                        <p>Además, como miembro de un GAC, tendrá acceso a información del proyecto y a herramientas y formatos para realizar un ejercicio efectivo de control social.</p>
                        <p>En esta sección usted podrá crear o unirse a un GAC que actualmente vigile este proyecto</p>
                        <p>Para mayor información sobre qué hace un GAC,  puede remitirse a la Cartilla Auditorías Ciudadanas una forma de vigilar las Regalías<a role="button" onclick="javascript:fnVentanaEmergente('https://www.sgr.gov.co/LinkClick.aspx?fileticket=-L4WW6TYPRY%3D&tabid=407');"> (Ver) </a></p>
                        
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Aceptar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divAdicionalPdf">

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