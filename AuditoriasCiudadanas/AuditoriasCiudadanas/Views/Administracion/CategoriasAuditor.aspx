<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoriasAuditor.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.CategoriasAuditor" %>
<link href="../../Content/fileinput.css" rel="stylesheet" />
<script src="../../Scripts/fileinput.js" type="text/javascript" ></script>
<%--<body onload="CargarTiposAuditor()">--%>
    <div class="container">
        <div class="row">
        	<h2 class="text-center">Categorías Auditor</h2>
            <div class="list-group-item">
                <div class="col-sm-2">
                    <strong>Icono</strong>
                </div>
                <div class="col-sm-2">
                    <strong>Nombre de la categoría</strong>
                </div>
                 <div class="col-sm-2">
                    <strong>Rango de puntuación</strong>
                </div>
                 <div class="col-sm-3">
                    <strong>Descripción categoría</strong>
                </div>
                 <div class="col-sm-2">
                    <strong>Opciones</strong>
                </div>
            </div>
            <div id="datos" class="list-group uppText"></div>

            <div class="btn btn-info" onclick="AnadirRegistro()"><a href="#"> <span class="glyphicon glyphicon-plus"></span>Añadir</a></div>
        </div>
    </div>
<%--VENTANA MODAL PARA AÑADIR FOTOGRAFÍA--%>
<div class="modal fade" id="ingresarActualizarRegistro" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("../../Scripts/CategoriaAuditor.js", function () {
            CargarTiposAuditor();
        });
    }));
</script>
