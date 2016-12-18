<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarCompromisos.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.RegistrarCompromisos" %>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<!-- Custom CSS -->
<link href="../../Content/logo-nav.css" rel="stylesheet" />
<link href="../../Content/screenView.css" rel="stylesheet" />
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../../Scripts/jquery.blockUI.js"></script>
<script src="../../Scripts/ajaxPost.js"></script>
    <!-- Page Content -->
    <div class="container">
    	<h1>Registro Compromisos</h1>
        <div class="center-block">
            <div class="row">
                <div class="col-sm-2">
                    <div class="form-group">
                        <label for="txtNumAsistentes">Número de Asistentes</label>
                        <input type="text" class="form-control" id="txtNumAsistentes">
                    </div>
                </div>
            </div>
            <form>
                <div class="table-responsive" id="divPresupuestoDet">
                    <table id="tb_compromisos" class="table table-hover table-striped">
                        <thead>
                            <tr>
                                <th>Compromisos</th>
                                <th>Responsables</th>
                                <th>Fecha cumplimiento</th>
                            </tr>
                        </thead>
                        <tbody>
                               <tr>
                                <td>
                                    <input type="text" class="compromiso" id="compromiso1" /></td>
                                <td>
                                    <input class="responsable" id="responsable1" /></td>
                                <td>
                                    <input class="fecha" id="fechacumplimiento1" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </form>
            </div>
<div class="botonera text-center">
    <div class="btn btn-primary"><a id="btnRegCompromisos" runat="server" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
</div>
    </div>
</div>

<div>
    <input type="hidden" id="hdIdaudiencia" value="" runat="server" />
    <input type="hidden" id="hdIdUsuario" value="" runat="server" />
</div>

<script type="text/javascript">
    if ($(document).ready(function () {
         $.getScript("../../Scripts/AudienciasFunciones.js", function () {
                 $.getScript("../../Scripts/AudienciasAcciones.js", function () {
                });
        });
    }));
</script>
