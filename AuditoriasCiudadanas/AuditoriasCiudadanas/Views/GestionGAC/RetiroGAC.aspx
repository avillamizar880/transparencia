<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetiroGAC.aspx.cs" Inherits="AuditoriasCiudadanas.Views.GestionGAC.RetiroGAC" %>
<div class="container">
    	<h1 class="text-center" id="TituloPagina">Listado de grupos auditoría ciudadana</h1>
        <div id="letrerobusqueda"></div>
           <div class="well">
        	<div class="form-group">
        	    <div class="input-group">
                    <input id="txtPalabraClaveGac" type="text" class="form-control" placeholder="Nueva Búsqueda...">
                        <span class="input-group-btn">
                            <button class="btn btn-info" onclick="BuscarGruposAuditorCiudadano()" type="button"><span class="glyphicon glyphicon-search"></span></button>
                        </span>
                </div>
            </div>
            </div>
      <div class="list-group">
      <h4 id="datosEncontradosGac" class="text-center"></h4>
      </div>
      <div id="datosGac" class="list-group uppText clearfix"></div>
      <nav id="navegadorResultadosGac" aria-label="Page navigation">
              <ul  id="paginadorGac" class="pagination"></ul>
       </nav>
</div>
<script type="text/javascript">
    if ($(document).ready(function ()
    {
      BuscarGruposAuditorCiudadano();
    }));
</script>

