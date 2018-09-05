<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notificaciones.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.notificaciones" %>

<%--<form id="formNotificaciones" runat="server">--%>
<div class="container">
    <!--USER PROFILE DETAILS-->
    <div class="row userSection">
        <!--upload Pic-->
        <div class="col-md-2">
            <div class="imgContainer">
                <img src="/Content/img/icon_User-02.svg" />
            </div>
        </div>
        <!-- user data -->

        <div class="col-md-8">
            <h2>
                <asp:label runat="server" id="NombreUsuario" />
            </h2>
            <asp:label class="detailProfile" runat="server" id="lblSigue" />
            <asp:label class="detailProfile" runat="server" id="LblEsAC" />
            <ul class="H">
                <li><span class="iconMedal">
                    <img src="/Content/img/ic_medalla.png" alt="medalla del auditor" /></span>
                    <asp:label class="borderNumber" runat="server" id="lblRanking" /></li>
                <li><span class="iconMedal">
                    <img src="/Content/img/ic_diamond.png" alt="5 proyectos exitosos" /></span>
                    <asp:label class="borderNumber" runat="server" id="lblDiamonds" /></li>
                <li><span class="iconMedal">
                    <img src="/Content/img/ic_star.png" alt="1 proyecto exitoso" /></span>
                    <asp:label class="borderNumber" runat="server" id="lblStars" /></li>
                <li><a href="#" onclick="cargaMenu('Usuarios/Ranking','dvPrincipal')" class="btn btn-default">Ranking</a></li>
                <li><a href="#" onclick="cambioClave();">Cambiar contraseña</a></li>

            </ul>
            <div class="col-md-12">
                <div class="pull-left"><a href="#" id="btnGenerateCertificate" class="btn btn-info">Mi Certificado &nbsp;&nbsp;<span class="glyphicon glyphicon-download-alt"></span></a></div>
            </div>
            
        </div>
           
        <div class="col-md-2">
            <img src="/Content/img/icon_msg-01.svg" />
        </div>

    </div>
    <!--SEARCH BAR-->
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <div class="input-group">

                    <input type="text" id="txtBuscarNotificacion" class="form-control" placeholder="Buscar por tipo, descripción o fecha...">
                    <span class="input-group-btn" onclick="ObtenerNotificaciones(<%=idUsuario%>, 1);">
                        <button class="btn btn-info" type="button"><span class="glyphicon glyphicon-search" id="btnBuscarNotificacion"></span></button>
                    </span>

                </div>
            </div>

        </div>
    </div>



    <div class="well well-lg w70 " runat="server" id="divNoNotificaciones">
        <p class="text-center">Actualmente NO tienes notificaciones</p>
    </div>
    <p class="text-center" runat="server" id="pNotificaciones">
        Actualmente tienes
            <asp:label runat="server" id="lblCantNot" />
        notificaciones.
        <asp:label runat="server" id="lblFiltradas" />
    </p>

    <div class="list-group" runat="server" id="tbNotificaciones">
    </div>

    <!--PAGINACIÓN-->
    <div class="col-md-12 text-center">
        <nav id="divPagNotificaciones" aria-label="Page navigation">
            <ul id="paginadorNotificaciones" class="pagination">
            </ul>
        </nav>
    </div>

</div>

<script type="text/javascript">
   if ($(document).ready(function () {
       $.getScript("../../Scripts/Usuarios/Notificaciones.js", function () {
           ObtenerNotificaciones(<%=idUsuario%>, 1);
       });
       $("<link/>", {
           rel: "stylesheet",
           type: "text/css",
           href: "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"
        }).appendTo("head");
    }));
</script>
<%--</form>--%>
