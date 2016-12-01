<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ingresoUsuario.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.ingresoUsuario" %>
<script type="text/javascript" src="../../../Scripts/jquery-1.10.2.min.js"></script>
<script src="../../Scripts/jquery.blockUI.js"></script>
<script type="text/javascript" src="../../Scripts/ajaxPost.js"></script>
<div>
    <table>
        <tr>
            <td>
                <input id="txtCorreo" type="text" class="txtgen" placeholder="Correo" />
            </td>
        </tr>
        <tr>
            <td>
                <input id="txtClave" type="password" class="txtgen" placeholder="Contraseña" />
            </td>
        </tr>
        <tr>
            <td>
                <a id="lnkPassword">Olvid&eacute; la contraseña</a>
            </td>
            <td>
                <input type="button" value="Ir" id="btnIngreso" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
               <a id="lnkRegistroUsu">REGISTRÁTE</a>
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript" src="../../../Scripts/UsuariosAcciones.js"></script>