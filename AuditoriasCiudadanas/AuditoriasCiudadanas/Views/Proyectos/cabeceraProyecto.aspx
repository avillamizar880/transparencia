<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cabeceraProyecto.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Proyectos.cabeceraProyecto" %>
<script src="../../Scripts/jquery-1.10.2.min.js"></script>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<script src="../../Scripts/bootstrap.min.js"></script>
<div id="divCabeceraProy" runat="server" class="panel panel-default">
    <div class="panel-body" >
        <div id="divNombreProy" runat="server" class="form-group">
            <label for="lblNombreProyecto">Nombre:</label>
            <div class="form-control" id="txtNombreProyecto" runat="server"></div>
        </div>
        <div id="divBtnUbicacion" runat="server">
             <img class="img-responsive" src="img_pin_ubicacion.jpg" alt="Ubicación">
             <div class="form-control" id="txtUbicaProyecto"></div>
        </div>
        <div id="divBtnContratista" runat="server" class="form-group">
            <label for="lblNombreProyecto">Contratista:</label>
            <div class="form-control" id="divInfoContratista" runat="server"></div>
        </div>
        <div id="divBtnSeguir" runat="server">
            <span>SEGUIR</span> &nbsp;&nbsp;&nbsp;
            <img class="img-responsive" src="img_seguir.jpg" alt="Seguir">
        </div>
    </div>
</div>
