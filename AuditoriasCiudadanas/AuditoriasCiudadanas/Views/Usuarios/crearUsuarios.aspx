<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearUsuarios.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.crearUsuarios" %>
<table>
    <tr>
        <td>
            <!-- Roles-->
                 <asp:dropdownlist id="ddlRol" runat="server" DataTextField="nom_rol" DataValueField ="id_rol" tooltip="--Rol--">
                 </asp:dropdownlist>
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
        <td>
            <input id="txtCelular" type="text" class="txtgen" placeholder="Celular" />
        </td>
    </tr>
    <tr>
        <td>
            <input type="button" id="btnCrearUsuPerfil" value="Crear Usuario" />
        </td>
    </tr>
</table>