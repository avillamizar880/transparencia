<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registroCiudadano.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.registroCiudadano" %>
<script src="../../Scripts/UsuariosFunciones.js"></script>
<div id="dvInfoUsu" runat="server" class="dv_datos">
<span>Registro</span>
    <form id="fo_usuarios" runat="server">
    <table id="tb_registro_usuario">
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
            <input id="txtPassword" type="password" class="txtgen" placeholder="Contraseña" />
        </td>
        </tr>
        <tr>
        <td>
            <input id="txtPassword_2" type="password" class="txtgen" placeholder="Confirme contraseña" />
        </td>
        </tr>
        <tr>
            <td>
                <input id="txtCelular" type="text" class="txtgen" placeholder="Celular" />
            </td>
        </tr>
        <tr>
            <td>
                <!-- departamento-->
                <asp:dropdownlist id="ddlDepartamento" runat="server"></asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td>
                <!-- municipio-->
                 <asp:dropdownlist id="ddlMunicipio" runat="server"></asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td>
                <asp:checkbox id="chkCondiciones" runat="server"></asp:checkbox>&nbsp;&nbsp;<span id="lbl_Terminos">Acepto términos y condiciones</span>
            </td>
        </tr>
        <tr>
            <td>
                <div style="float: left;">
                    <input type="button" onclick="ver_proyecto()" id="btnVolver" value="Volver al Proyecto"></input>
                </div>
                <div style="float: left;">
                    <input type="button" onclick="avanzar_registro('2')" id="btnAvanzarReg" value="Siguiente"></input>
                </div>
            </td>
        </tr>
    </table>
  </form>
</div>
