<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AprobacionBuenasPracticas.aspx.cs" Inherits="AuditoriasCiudadanas.Views.GestionGAC.AprobacionBuenasPracticas" %>
    <div class="container">
    <h1 class="text-center">Reconocer Buena Práctica</h1>
    	<div class="w60 center-block">
            <div id="divListadoPracticas">

            </div>
        <!--BOTONERA-->
             <div class="botonera text-center">
              	<div class="btn btn-primary"><a href=""><span class="glyphicon glyphicon-ok-sign"></span> Publicar</a></div>
             </div>
        </div>
    </div>
<script type="text/javascript">
   if ($(document).ready(function () {
          obtBuenasPracticas();
    }));
</script>