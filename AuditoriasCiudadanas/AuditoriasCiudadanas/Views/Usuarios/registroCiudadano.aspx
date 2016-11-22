<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registroCiudadano.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.registroCiudadano" %>
<script src="../../Scripts/UsuariosFunciones.js"></script>
<div id="dvInfoUsu" runat="server" class="dv_datos">
<span>Registro</span>
    <form id="fo_usuarios" runat="server">
    <table id="tb_registro_usuario">
        <tr>
            <td>
                <input id="txt_nombre" class="txtgen" placeholder="Nombre Completo" />
            </td>
        </tr>
        <tr>
            <td>
                <input id="txt_correo" class="txtgen" placeholder="Correo electrónico" />
            </td>
        </tr>
        <tr>
        <td>
            <input id="txt_contrasena" class="txtgen" placeholder="Contraseña" />
        </td>
        </tr>
        <tr>
        <td>
            <input id="txt_contrasena_2" class="txtgen" placeholder="Confirme contraseña" />
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
                <asp:checkbox id="cb_condiciones" runat="server"></asp:checkbox>&nbsp;&nbsp;<span id="lbl_Terminos">Acepto términos y condiciones</span>
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
