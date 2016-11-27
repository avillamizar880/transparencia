<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearUsuarios.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.crearUsuarios" %>
<table>
    <tr>
        <td>
            <asp:dropdownlist runat="server" id="ddlPerfil" runat="server"></asp:dropdownlist>
        </td>
    </tr>
    <tr>
        <td>
            <input id="txtNombre" type="text" class="txtgen" placeholder="Nombre Completo" />
        </td>
    </tr>
    <tr>
        <td>
             <input id="txtCorreo" type="email" class="txtgen" placeholder="Correo electrónico" />
        </td>
    </tr>
    <tr>
        <input id="txtCelular" class="txtgen" placeholder="Celular" />
    </tr>
    <tr>
        <td>
            <input type="button" id="btnCrear" value="Crear" />
        </td>
    </tr>
</table>