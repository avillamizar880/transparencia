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
<div id="divDetalleProyecto" runat="server">
    <div id="divPin" runat="server">
        <span id="spnPinProyecto" runat="server">201810010002</span>
    </div>
    <div id="divGeneral" runat="server">
        <div id="divObjetivoHead" runat="server" class="form-group">
            <label for="lblObjetivo">Objetivo:</label>
            <div class="form-control" id="divObjetivoDet" runat="server"></div>
        </div>
         <div id="divSectorHead" runat="server" class="form-group">
            <label for="lblSector">Sector al que apunta el proyecto:</label>
            <div class="form-control" id="divSectorDet" runat="server"></div>
        </div>
         <div id="divLocalizacionHead" runat="server" class="form-group">
            <label for="lblLocalizacion">Localización:</label>
            <div class="form-control" id="divLocalizacionDet" runat="server"></div>
        </div>
         <div id="divEntidadEjecHead" runat="server" class="form-group">
            <label for="lblEntidadEjecutora">Nombre entidad ejecutora de los recursos:</label>
            <div class="form-control" id="divEntidadEjecDet" runat="server"></div>
        </div>
        <div id="divProductosHead" runat="server" class="form-group">
            <label for="lblProductos">Productos del proyecto:</label>
            <div class="form-control" id="divProductosDet" runat="server"></div>
        </div>
        <div id="divCronogramaHead" runat="server" class="form-group">
            <label for="lblProductos">Cronograma de actividades:</label>
            <div class="form-control" id="divCronogramaDet" runat="server">
                <%--Grafica de cronograma, incluir boton para comparar ejecutado vs planeado--%>
            </div>
        </div>
    </div>
    <div id="divContratista" runat="server">
         <div id="divContratistaHead" runat="server" class="form-group">
            <label for="lblContratista">Nombre del Contratista Seleccionado:</label>
            <div class="form-control" id="divContratistaDet" runat="server"></div>
        </div>
         <div id="divInterventorHead" runat="server" class="form-group">
            <label for="lblInterventor">Nombre del Interventor Designado:</label>
            <div class="form-control" id="divInterventorDet" runat="server"></div>
        </div>
         <div id="divSupervisorHead" runat="server" class="form-group">
            <label for="lblSupervisor">Nombre del Supervisor:</label>
            <div class="form-control" id="divSupervisor" runat="server"></div>
        </div>
    </div>
    <div id="divPresupuesto" runat="server">

    </div>
    <div id="divFormulacion" runat="server">

    </div>
    <div id="divPlaneacion" runat="server">

    </div>
    <div id="divInfoTecnica" runat="server">

    </div>
    <div id="divGrupos" runat="server">
    </div>
</div>