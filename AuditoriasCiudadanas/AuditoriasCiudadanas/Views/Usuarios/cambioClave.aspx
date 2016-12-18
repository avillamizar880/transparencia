<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cambioClave.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.cambioClave" %>
CAMBIO DE CLAVE
<table>
    <tr>
        <td>
            <span>Clave anterior</span>
        </td>
        <td>
            <input type="password" id="txtPassword_ant" runat="server" placeholder="Clave anterior" />
        </td>
    </tr>
    <tr>
        <td>
            <span>Nueva Clave</span>
        </td>
        <td>
            <input type="password" id="txtPassword" runat="server" placeholder="Nueva Clave" />
        </td>
    </tr>
    <tr>
        <td>
            <span>Confirma nueva Clave</span>
        </td>
        <td>
             <input type="password" id="txtPassword_2" runat="server" placeholder="Confirma Nueva Clave" />
        </td>
    </tr>
        <tr>
        <td colspan="2">
            <input type="button" id="btnCambiarClave" value="Cambiar Clave" />
        </td>
    </tr>
</table>