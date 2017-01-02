<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEncuestaCaractCorte.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.AdEncuestaCaract" %>
<%--CORTES DE INFORMACIÓN--%>
<div class="container">
    <h1 class="text-center">Encuesta de Caracterización</h1>
    <h2 class="text-center">Cortes de información</h2>  
</div>
<div class="container">
    <div id="datosFechaCorte" class="list-group-item uppText"/>
</div>
<div id="divOtros">

</div>
 <script type="text/javascript">
        $(document).ready(function () {
            ObtenerResultadosFechaCorte();
        });
</script>