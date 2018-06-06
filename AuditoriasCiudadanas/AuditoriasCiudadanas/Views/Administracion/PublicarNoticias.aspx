<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicarNoticias.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.PublicarNoticias" %>
<script type="text/javascript">
			$(document).ready(function() {
			    BuscarTotalNoticiasPublicadas();
			    $('[data-toggle="tooltip"]').tooltip();
			    $("#txtPalabraClaveNoticias").keypress(function (e) {
			        if (e.which == 13)
			        {
			            BuscarTotalNoticiasPublicadas();
			        }
			    });
			});
</script>
<div class="container">
       <h1 class="text-center">Noticias</h1>
         <div class="well text-center">
         	<div id='AnadirNoticia' onclick='AnadirNoticia()' class="btn btn-info mb15"><a data-toggle='modal' data-target='#myModal'><span class="glyphicon glyphicon-plus"></span> Nueva Noticia</a></div>  
         </div>
        <div class="list-group">
          <h4 id="datosEncontradosNoticiasPublicadas" class="text-center"></h4>
          </div>
         <div class="noticiasBox">
          <div id="datosNoticiasPublicadas" class="list-group"></div>
         </div>
        <!--PAGINACIÓN-->
       <div class="col-md-12 text-center">
           <nav id="navegadorResultadosNoticiasPublicadas" aria-label="Page navigation">
              <ul  id="paginadorNoticiasPublicadas" class="pagination"></ul>
            </nav>
           <p id="paginaActualNoticiasPublicadas" hidden="hidden">0</p>
           <p id="ultimaPaginaNoticiasPublicadas" hidden="hidden">0</p>
       </div>
     <input type="hidden" id="hdIdUsuario" runat="server" />
</div> <%--Fin div Container--%>
<div class="modal fade" id="myModalIngresarNoticia" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>