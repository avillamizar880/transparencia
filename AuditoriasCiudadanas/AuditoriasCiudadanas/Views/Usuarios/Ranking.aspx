<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ranking.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.Ranking" %>

<div class="container">
    	<h1>Ranking</h1>
        <div class="center-block ">
            <form>
                <input type="hidden" id="hdIdUsuario" value="" runat="server" />
                <div id="DivRankingUsu" runat="server"></div>
                <div id="DivRankingGac" runat="server"></div>

            </form>
        </div>
    </div>
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript('../../Scripts/UsuariosFunciones.js', function () {
           $.getScript('../../Scripts/UsuariosAcciones.js', function () {
          
        });
    });
}));
</script>