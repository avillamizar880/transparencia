<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notificaciones.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.notificaciones" %>

<form id="formNotificaciones" runat="server">
    <div class="container">
        <h1 class="text-center">Notificaciones</h1>
        <div class="well well-lg w70 " runat="server" id="divNoNotificaciones">
	       <p class="text-center">Actualmente NO tienes notificaciones</p>
        </div>
            <p class="text-center" runat="server" id="pNotificaciones">Actualmente tienes <asp:Label runat="server" id="lblCantNot" /> notificaciones</p>
            <div class="notificacionBox w70" runat="server" id="tbNotificaciones">

            </div>

    </div>
</form>
