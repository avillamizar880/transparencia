<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscadorProyectosAuditores.aspx.cs" Inherits="AuditoriasCiudadanas.Views.AccesoInformacion.BuscadorProyectosAuditores" %>

<script type="text/javascript">
			$(document).ready(function() {
			    CargarProyectosAuditores();
			});
</script>

       <%-- Archivos CSS--%>
<%--        <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
        <link href="../../Content/logo-nav.css" rel="stylesheet" />
        <link href="../../Content/screenView.css" rel="stylesheet" />
        <link href="../../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css"/>
        <link href="../../Content/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css"/>
         <link href="../../Content/estilos_checkbox_sinradio.css" rel="stylesheet" type="text/css"/>--%>
       
      <%-- Archivos JS--%>
<%--        <script src="../../Scripts/jquery-1.12.4.min.js" type="text/javascript" ></script>
        <script src="../../Scripts/jquery-ui-1.12.1.js" type="text/javascript" ></script>
        <script src="../../Scripts/jquery.blockUI.js" type="text/javascript" ></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <script type="text/javascript" src="../../Scripts/bootstrap-datetimepicker.js" charset="UTF-8"></script>
        <script type="text/javascript" src="../../Scripts/bootstrap-datetimepicker.es.js" charset="UTF-8"></script>
        <script type="text/javascript" src="../../Scripts/BuscarProyectos.js" charset="UTF-8"></script>--%>


<div class="container">
    	<h1 class="text-center" id="TituloPagina">Listado de proyectos</h1>
        <div id="letrerobusqueda"></div>
           <div class="well">
        	<div class="form-group">
        	    <div class="input-group">
                    <input id="txtPalabraClave" type="text" class="form-control" placeholder="Nueva Búsqueda...">
                        <span class="input-group-btn">
                            <button class="btn btn-info" onclick="CargarProyectosAuditores()" type="button"><span class="glyphicon glyphicon-search"></span></button>
                        </span>
                </div>
            </div>
            <div class="form-group text-center">
                <form class="formulario">
				    <input type="radio" name="buscAuditProy" checked="checked" id="r_Proyectos">
				    <label for="r_Proyectos"><span class="btn"><span class="glyphicon glyphicon-globe"> Proyectos</span></span></label>

                    <input type="radio" name="buscAuditProy" id="r_Auditores">
				    <label for="r_Auditores"><span class="btn"><span class="glyphicon glyphicon-user"> Auditores</span></span></label>
                </form>
            </div>
            </div>
      <div class="list-group">
      <h4 id="datosEncontrados" class="text-center"></h4>
      </div>
      <div id="datos" class="list-group uppText clearfix"></div>
      <nav id="navegadorResultados" aria-label="Page navigation">
              <ul  id="paginador" class="pagination"></ul>
       </nav>
</div>


