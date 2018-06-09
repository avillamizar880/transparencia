<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicarCampanas.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.Campanas" %>

<script type="text/javascript">
			$(document).ready(function() {
			    BuscarTotalCampanasPublicadas();
			    $('[data-toggle="tooltip"]').tooltip();
			    $("#txtPalabraClaveCampanas").keypress(function (e) {
			        if (e.which == 13)
			        {
			            BuscarTotalCampanasPublicadas();
			        }
			    });
			});
</script>
<div class="container">
       <h1 class="text-center">Campañas</h1>
         <div class="well text-center">
         	<div id='AnadirCampana' onclick='AnadirCampana()' class="btn btn-info mb15"><a data-toggle='modal' data-target='#myModal'><span class="glyphicon glyphicon-plus"></span> Nueva Campaña</a></div>  
         </div>
        <div class="list-group">
          <h4 id="datosEncontradosCampanasPublicadas" class="text-center"></h4>
          </div>
         <div class="noticiasBox">
          <div id="datosCampanasPublicadas" class="list-group"></div>
         </div>
        <!--PAGINACIÓN-->
       <div class="col-md-12 text-center">
           <nav id="navegadorResultadosCampanasPublicadas" aria-label="Page navigation">
              <ul  id="paginadorCampanasPublicadas" class="pagination"></ul>
            </nav>
           <p id="paginaActualCampanasPublicadas" hidden="hidden">0</p>
           <p id="ultimaPaginaCampanasPublicadas" hidden="hidden">0</p>
       </div>
     <input type="hidden" id="hdIdUsuario" runat="server" />
</div> <%--Fin div Container--%>
<div class="modal fade" id="myModalIngresarCampana" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>
