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
            <div class="form-control" id="divSupervisorDet" runat="server"></div>
        </div>
         <div id="divPolizasHead" runat="server" class="form-group">
            <label for="lblSupervisor">Información General de Pólizas y Garantías:</label>
            <div class="form-control" id="divPolizasDet" runat="server">
                <div id="divImgPoliza"></div>
                <div id="divTextoPoliza"></div>
            </div>
        </div>
    </div>
    <div id="divPresupuesto" runat="server">
         <div id="divPresupuestoHead" runat="server" class="form-group">
            <label for="lblPresupuesto">Montos de cofinanciación en el proyecto con su respectiva fuente u origen :</label>
            <div class="form-control" id="divPresupuestoDet" runat="server">
                <%--Insertar Tabla--%>
            </div>
        </div>
        <div id="divModifPresupHead" runat="server" class="form-group">
            <label for="lblPresupuesto">Modificaciones al presupuesto del proyecto :</label>
            <div class="form-control" id="divModifPresupDet" runat="server">
                <%--Insertar Tabla--%>
            </div>
        </div>
        <div id="divCostoActividadHead" runat="server" class="form-group">
            <label for="lblPresupuesto">Costo por producto y/o actividad :</label>
            <div class="form-control" id="divCostoActividadDet" runat="server">
                <%--Insertar Tabla Actividad Valor--%>
            </div>
        </div>
    </div>
    <div id="divFormulacion" runat="server">
        <div id="div1" runat="server" class="form-group">
            <label for="lblPresupuesto">Fecha y OCAD donde se aprobó el proyecto:</label>
            <div class="form-control" id="div2" runat="server">
                <%--Insertar Tabla Actividad Valor--%>
            </div>
        </div>
         <div id="div3" runat="server" class="form-group">
            <label for="lblPresupuesto">Acta del OCAD mediante la cual se aprobueba el proyecto:</label>
            <div class="form-control" id="div4" runat="server">
                <%--Insertar Tabla Actividad Valor--%>
            </div>
        </div>
         <div id="div5" runat="server" class="form-group">
            <label for="lblPresupuesto">Criterios de priorización del proyecto por encima de otros:</label>
            <div class="form-control" id="div6" runat="server">
                <%--Insertar Tabla Actividad Valor--%>
            </div>
        </div>
         <div id="div7" runat="server" class="form-group">
            <label for="lblPresupuesto">Proyectos presentados al OCAD:</label>
            <div class="form-control" id="div8" runat="server">
                <%--Insertar Tabla Actividad Valor--%>
            </div>
        </div>
        <div id="div9" runat="server" class="form-group">
            <label for="lblPresupuesto">Proyectos presentados al OCAD:</label>
            <div class="form-control" id="div10" runat="server">
                <%--Insertar Tabla Actividad Valor--%>
            </div>
        </div>
    </div>
    <div id="divPlaneacion" runat="server">

    </div>
    <div id="divInfoTecnica" runat="server">

    </div>
    <div id="divGrupos" runat="server">
    </div>
</div>