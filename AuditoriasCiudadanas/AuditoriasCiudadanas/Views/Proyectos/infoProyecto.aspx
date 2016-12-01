<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="infoProyecto.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Proyectos.infoProyecto" %>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<script src="../../Scripts/jquery-1.10.2.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../../Scripts/responsive-tabs.js"></script>
<ul class="nav nav-tabs responsive" id="opcionesInfo">
        <li class="test-class active"><a class="deco-none red-class" href="#divGeneral"><span class="glyphicon"></span> Información General</a></li>
        <li class="test-class"><a href="#divContratista"><span class="glyphicon"></span> Contratista y Vigilancia</a></li>
        <li><a class="deco-none" href="#divPresupuesto"><span class="glyphicon"></span>Financiación y Presupusto </a></li>
        <li><a class="deco-none" href="#divFormulacion"><span class="glyphicon"></span>Formulación y Aprobación </a></li>
        <li><a class="deco-none" href="#divPlaneacion"><span class="glyphicon"></span>Planeación y Aprobación </a></li>
        <li><a class="deco-none" href="#divInfoTecnica"><span class="glyphicon"></span>Información Técnica y Calidad </a></li>
        <li><a class="deco-none" href="#divGrupos"><span class="glyphicon"></span>Grupos Auditores </a></li>
      </ul>
<div id="divDetalleProyecto" class="tab-content responsive" runat="server">
    <div id="divPin" runat="server">
        <label id="lblPin" runat="server">BPIN:</label>
        <span id="spnPinProyecto" runat="server"></span>
    </div>
    <br />
    <div id="divGeneral" class="tab-pane active" runat="server">
        <div id="divObjetivoHead" runat="server" class="tab-pane active form-group">
            <label for="divObjetivoDet">Objetivo:</label>
            <div class="form-control" id="divObjetivoDet" runat="server"></div>
        </div>
         <div id="divSectorHead" runat="server" class="form-group">
            <label for="divSectorDet">Sector al que apunta el proyecto:</label>
            <div class="form-control" id="divSectorDet" runat="server"></div>
        </div>
         <div id="divLocalizacionHead" runat="server" class="form-group">
            <label for="divLocalizacionDet">Localización:</label>
            <div class="form-control" id="divLocalizacionDet" runat="server"></div>
        </div>
         <div id="divEntidadEjecHead" runat="server" class="form-group">
            <label for="divEntidadEjecDet">Nombre entidad ejecutora de los recursos:</label>
            <div class="form-control" id="divEntidadEjecDet" runat="server"></div>
        </div>
        <div id="divProductosHead" runat="server" class="form-group">
            <label for="divProductosDet">Productos del proyecto:</label>
            <div class="form-control" id="divProductosDet" runat="server"></div>
        </div>
        <div id="divCronogramaHead" runat="server" class="form-group">
            <label for="divCronogramaDet">Cronograma de actividades:</label>
            <div class="form-control" id="divCronogramaDet" runat="server">
                <%--Grafica de cronograma, incluir boton para comparar ejecutado vs planeado--%>
            </div>
        </div>
    </div>
    <div id="divContratista" class="tab-pane" runat="server">
        <div id="divContratistaHead" runat="server" class="form-group">
            <label for="divContratistaDet">Nombre del Contratista Seleccionado:</label>
            <div class="form-control" id="divContratistaDet" runat="server"></div>
        </div>
        <div id="divInterventorHead" runat="server" class="form-group">
            <label for="divInterventorDet">Nombre del Interventor Designado:</label>
            <div class="form-control" id="divInterventorDet" runat="server"></div>
        </div>
        <div id="divSupervisorHead" runat="server" class="form-group">
            <label for="divSupervisorDet">Nombre del Supervisor:</label>
            <div class="form-control" id="divSupervisorDet" runat="server"></div>
        </div>
        <div id="divPolizasHead" runat="server" class="form-group">
            <label for="divPolizasDet">Información General de Pólizas y Garantías:</label>
            <div class="form-control" id="divPolizasDet" runat="server">
                <div id="divImgPoliza"></div>
                <div id="divTextoPoliza"></div>
            </div>
        </div>
    </div>
    <div id="divPresupuesto" class="tab-pane" runat="server">
        <div id="divPresupuestoHead" runat="server" class="form-group">
            <label for="divPresupuestoDet">Montos de cofinanciación en el proyecto con su respectiva fuente u origen :</label>
            <div class="form-control" id="divPresupuestoDet" runat="server">
                <%--Insertar Tabla--%>
            </div>
        </div>
        <div id="divModifPresupHead" runat="server" class="form-group">
            <label for="divModifPresupDet">Modificaciones al presupuesto del proyecto :</label>
            <div class="form-control" id="divModifPresupDet" runat="server">
                <%--Insertar Tabla--%>
            </div>
        </div>
        <div id="divCostoActividadHead" runat="server" class="form-group">
            <label for="divCostoActividadDet">Costo por producto y/o actividad :</label>
            <div class="form-control" id="divCostoActividadDet" runat="server">
                <%--Insertar Tabla--%>
            </div>
        </div>
    </div>
    <div id="divFormulacion" class="tab-pane" runat="server">
        <div id="divFechaOcadHead" runat="server" class="form-group">
            <label for="divFechaOcadDet">Fecha y OCAD donde se aprobó el proyecto:</label>
            <div class="form-control" id="divFechaOcadDet" runat="server">
            </div>
        </div>
        <div id="divActaOcadHead" runat="server" class="form-group">
            <label for="divActaOcadDet">Acta del OCAD mediante la cual se aprobueba el proyecto:</label>
            <div class="form-control" id="divActaOcadDet" runat="server">
            </div>
        </div>
        <div id="divCriteriosHead" runat="server" class="form-group">
            <label for="divCriteriosDet">Criterios de priorización del proyecto por encima de otros:</label>
            <div class="form-control" id="divCriteriosDet" runat="server">
            </div>
        </div>
        <div id="divPresOcadHead" runat="server" class="form-group">
            <label for="divPresOcadDet">Proyectos presentados al OCAD:</label>
            <div class="form-control" id="divPresOcadDet" runat="server">
            </div>
        </div>
        <div id="divPersonaHead" runat="server" class="form-group">
            <label for="divPersonaDet">Datos de quien formuló/estructuró el proyecto:</label>
            <div class="form-control" id="divPersonaDet" runat="server">
            </div>
        </div>
    </div>
    <div id="divPlaneacion" class="tab-pane" runat="server">
        <div id="divDescripHead" runat="server" class="form-group">
            <label for="divDescripDet">Descripción:</label>
            <div class="form-control" id="divDescripDet" runat="server">
            </div>
        </div>
        <div id="divDocPlaHead" runat="server" class="form-group">
            <label for="divDocPlaDet">Documento de planeación:</label>
            <div class="form-control" id="divDocPlaDet" runat="server">
            </div>
        </div>
        <div id="divEspecifHead" runat="server" class="form-group">
            <label for="divEspecifDet">Especificaciones técnicas:</label>
            <div class="form-control" id="divEspecifDet" runat="server">
            </div>
        </div>
    </div>
    <div id="divInfoTecnica" class="tab-pane" runat="server">
        <div id="divTitulo" runat="server" class="form-group">
            <label for="divTitulo">Titulo de la publicación:</label>
            <input type="text" class="form-control" id="txtTituloInfo" runat="server" />
        </div>
        <div class="row">
            <div class="form-group">
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Comparte nueva información del proyecto">
                    <span class="input-group-btn">
                        <button class="btn btn-secondary" type="button"><i class="glyphicon glyphicon-camera"></i></button>
                    </span>
                    <span class="input-group-btn">
                        <button class="btn btn-secondary" type="button"><i class="glyphicon glyphicon-paperclip"></i></button>
                    </span>
                </div>
            </div>
        </div>
        <div>
            <button id="btnCompInfoTecnica" type="button" class="btn btn-default btn-sm">Comparte</button>
        </div>
    </div>
    <div id="divGruposAud" class="tab-pane" runat="server">
    </div>
</div>
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