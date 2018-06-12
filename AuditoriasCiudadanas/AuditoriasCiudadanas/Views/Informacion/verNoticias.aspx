<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verNoticias.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Informacion.verNoticias" %>
<div class="container" id="divPrincipalVerNoticia">
    	<h1 class="text-center" id="TituloPagina">Noticias</h1>
        <div id="letrerobusqueda"></div>
           <div class="well">
        	<div class="form-group">
        	    <div class="input-group">
                    <input id="txtPalabraClaveNoticias" type="text" class="form-control" placeholder="Nueva búsqueda de noticias">
                        <span class="input-group-btn">
                            <button class="btn btn-info" onclick="BuscarTotalNoticias()" type="button"><span class="glyphicon glyphicon-search"></span></button>
                        </span>
                </div>
            </div>
            </div>
      <div class="list-group">
      <h4 id="datosEncontradosNoticias" class="text-center"></h4>
      </div>
      <div id="datosNoticias" class="list-group uppText clearfix"></div>
      <nav id="navegadorResultadosNoticias" aria-label="Page navigation">
              <ul  id="paginadorNoticias" class="pagination"></ul>
       </nav>
       <p id="paginaActualNoticias" hidden="hidden">0</p>
       <p id="ultimaPaginaNoticias" hidden="hidden">0</p>
</div>
<div class="container hideObj" id="divPrincipalEnlaceNoticia">
       <div class="plantillasHeader">
            <h3>
                <a id="btnVolverListadoNoticias" role="button" onclick="volverListadoNoticiasCampanas('divPrincipalEnlaceNoticia','divPrincipalVerNoticia');"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER A NOTICIAS</a>
            </h3>
       </div>
       <h1 id="tituloEnlaceNoticia" class="text-center">Detalle de la noticia</h1>
        <div class="container">
            <iframe id="enlaceVisitar" style="width: 90%; height: 80%"></iframe>
        </div>       
</div> 

<script type="text/javascript">
			$(document).ready(function() {
			    BuscarTotalNoticias();
			    $('[data-toggle="tooltip"]').tooltip();

			    $("#txtPalabraClaveNoticias").keypress(function (e) {
			        if (e.which == 13)
			        {
			            BuscarTotalNoticias();
			        }
			    });

			});
</script>
