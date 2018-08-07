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
            <span class="detailProfile">Sigue 11 proyectos</span>
            <span class="detailProfile">Es auditor ciudadano</span>
            <ul class="H">
                <li><span class="iconMedal">
                    <img src="/Content/img/ic_medalla.png" alt="medalla del auditor" /></span>
                    <span class="borderNumber">21</span></li>
                <li><a href="#" class="btn btn-default">Ranking</a></li>
                <li><a href="#">Cambiar contraseña</a></li>

            </ul>
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

                    <input type="text" class="form-control" placeholder="Buscar por municipio, nombre o tema...">
                    <span class="input-group-btn">
                        <button class="btn btn-info" type="button"><span class="glyphicon glyphicon-search"></span></button>
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
        notificaciones
    </p>

    <div class="list-group" runat="server" id="tbNotificaciones">
    </div>

</div>

<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/Usuarios/Notificaciones.js", function () {
        });
    }));
</script>
<%--</form>--%>
