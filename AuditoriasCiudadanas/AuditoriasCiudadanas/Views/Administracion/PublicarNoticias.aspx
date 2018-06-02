<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicarNoticias.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.PublicarNoticias" %>
<%--<script type="text/javascript">
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
</script>--%>
<div class="container">
    	<h1 class="text-center">Noticias</h1>
         <div class="well text-center">
         	<div class="btn btn-info mb15"><span class="glyphicon glyphicon-plus"></span> Nueva Noticia</div>  
         </div>
        <div class="list-group">
          <h4 id="datosEncontradosNoticias" class="text-center"></h4>
          </div>
         <div class="noticiasBox">
          <div id="dtgNoticias" class="list-group"></div>
         </div>
        <!--PAGINACIÓN-->
       <div class="col-md-12 text-center">
           <nav id="navegadorResultadosNoticias" aria-label="Page navigation">
              <ul  id="paginadorNoticias" class="pagination"></ul>
            </nav>
           <p id="paginaActualNoticias" hidden="hidden">0</p>
           <p id="ultimaPaginaNoticias" hidden="hidden">0</p>
       </div>
</div> <%--Fin div Container--%>