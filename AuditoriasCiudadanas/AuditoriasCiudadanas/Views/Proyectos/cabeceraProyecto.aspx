<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cabeceraProyecto.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Proyectos.cabeceraProyecto" %>
<script src="../../Scripts/jquery-1.10.2.min.js"></script>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<script src="../../Scripts/bootstrap.min.js"></script>
<div id="divCabeceraProy" runat="server" class="panel panel-default">
    <div class="row">
        <div class="col-sm-3">
            <div id="divNombreProy" runat="server" class="form-group">
                <label for="lblNombreProyecto">Nombre:</label>
                <div id="txtNombreProyecto" runat="server"></div>
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
        <div class="col-sm-3">
            <a href="#" class="btn btn-success">
                <span class="glyphicon glyphicon-hand-up"></span> SEGUIR
            </a>
        </div>
    </div>
</div>
