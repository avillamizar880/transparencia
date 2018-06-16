<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verDetalleNoticia.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Informacion.verDetalleNoticia" %>
<div class="container hideObj" id="divPrincipalEnlaceNoticia">
       <div class="plantillasHeader">
            <h3>
                <a id="btnVolverListadoNoticias" role="button" onclick="volverListadoNoticiasCampanas('divPrincipalEnlaceNoticia','divPrincipalVerNoticia');"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER A NOTICIAS</a>
            </h3>
       </div>
        <div class="form-group">
            <input type="hidden" id="hfIdDetalleNoticia" runat="server"/>
            <input type="hidden" id="hfUrlDetalleNoticia" runat="server"/>
		    <label for="TituloNoticia" class="control-label">Titulo</label>
			<textarea id="txtTituloNoticia" placeholder="Por ejemplo: Hoy la visita se realizó al lote donde se ha comenzado a construir la estructura del hospital. Se puede ver el material, como cemento, ladrillos, varillas de acero y alrededor de 20 trabajadores todos con implementos de protección. " class="form-control" rows="5" ></textarea>
			<img id="imgDetalleNoticia" width="250" height="120"><br />
            <label for="ResumenNoticia" class="control-label">Resumen</label>
			<textarea id="txtResumenNoticia" placeholder="Por ejemplo: La programación presentada por el contratista en la Audiencia de Inicio en la cual plantea el comienzo de la construcción de cimientos del hospital está al día y se evidencia de manera adecuada.    " class="form-control" rows="5" ></textarea>
			<label class="control-label">Fecha</label>
			<textarea id="fechaDetalleNoticia" class="form-control"></textarea>
            <a role="button" hidden="hidden" id="btnVerMasNoticia" onclick="MasInformacionNoticia()" class="btn btn-primary external"><span class="glyphicon glyphicon-download"></span>Más información</a>
		</div>
</div> 
<script type="text/javascript">
    $(document).ready(function () {
       
        VerDetalleNoticia();

			});
</script>
