<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscadorProyectosAuditores.aspx.cs" Inherits="AuditoriasCiudadanas.Views.AccesoInformacion.BuscadorProyectosAuditores" %>

<script type="text/javascript">
			$(document).ready(function() {
			    CargarProyectosAuditores();
			});
</script>

<div class="container">
    	<h1 class="text-center">Listado de proyectos</h1>
      <div class="input-group">
        <input id="txtPalabraClave" type="text" class="form-control" placeholder="Buscar Proyectos..."/>
        <span class="input-group-btn"><button class="btn btn-info" type="button" onclick="CargarProyectosAuditores()"><span class="glyphicon glyphicon-search"></span></button></span>
      </div>
      <div class="list-group">
      <div class="botonera text-center">
       <div class="wrap">
			<form class="formulario">
			<div class="radio">
				<input type="radio" name="buscAuditProy" checked="checked" id="r_Proyectos">
				<label for="r_Proyectos">Proyectos</label>

                <input type="radio" name="buscAuditProy" id="r_Auditores">
				<label for="r_Auditores">Auditores</label>
			</div>
            </form>
        </div>
      </div>
      <h4 id="datosEncontrados" class="text-center"></h4>
      </div>
      <div id="datos" class="list-group uppText clearfix"></div>
      <nav id="navegadorResultados" aria-label="Page navigation">
              <ul  id="paginador" class="pagination"></ul>
       </nav>
</div>

<%--    	<h1 class="text-center">Listado de proyectos</h1>
      <div class="input-group">
        <input id="txtPalabraClave" type="text" class="form-control" placeholder="Buscar Proyectos..."/>
        <span class="input-group-btn"><button class="btn btn-info" type="button" onclick="CargarProyectosAuditores()"><span class="glyphicon glyphicon-search"></span></button></span>
      </div>
      <div class="list-group">
      <div class="botonera text-center">
       <div class="wrap">
			<form action="" class="formulario">
			<div class="radio">
				<input type="radio" name="sexo" checked="checked" id="r_Proyectos">
				<label for="r_Proyectos">Proyectos</label>

                <input type="radio" name="sexo" id="r_Auditores">
				<label for="r_Auditores">Auditores</label>
			</div>
            </form>
      </div>
      </div>
      </div>
      <div id="datos"  class="list-group uppText clearfix"></div>
      <nav aria-label="Page navigation">
              <ul class="pagination">
                <li>
                  <a href="#" aria-label="Previous">
                    <span aria-hidden="true">&laquo;</span>
                  </a>
                </li>
                <li><a href="#">1</a></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">5</a></li>
                <li>
                  <a href="#" aria-label="Next">
                    <span aria-hidden="true">&raquo;</span>
                  </a>
                </li>
              </ul>
            </nav>--%>
