<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscadorProyectosAuditores.aspx.cs" Inherits="AuditoriasCiudadanas.Views.AccesoInformacion.BuscadorProyectosAuditores" %>

<script type="text/javascript">
			$(document).ready(function() {
			    CargarProyectosAuditores();
			});
</script>
<div class="container">
    	<h1 class="text-center" id="TituloPagina">Listado de proyectos</h1>
        <div id="letrerobusqueda"></div>
           <div class="well">
        	<div class="form-group">
        	    <div class="input-group">
                    <input id="txtPalabraClave" type="text" class="form-control" placeholder="Nueva búsqueda de proyecto">
                        <span class="input-group-btn">
                            <button class="btn btn-info" onclick="CargarProyectosAuditores()" type="button"><span class="glyphicon glyphicon-search"></span></button>
                        </span>
                </div>
            </div>
            <div class="form-group text-center">
                <form class="formulario">
                    <input type="hidden" id="hfOpcionBusqueda" runat="server"/>
				    <input type="radio" name="buscAuditProy" checked="checked" id="r_Proyectos">
				    <label for="r_Proyectos" onclick="ObtenerOpcionProyectosAuditores('Proyectos')"><span class="btn"><span class="glyphicon glyphicon-globe"> Proyectos</span></span></label>
                    <input type="radio" name="buscAuditProy" id="r_Auditores">
				    <label for="r_Auditores" onclick="ObtenerOpcionProyectosAuditores('Auditores')"><span class="btn"><span class="glyphicon glyphicon-user"> Auditores</span></span></label>
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


