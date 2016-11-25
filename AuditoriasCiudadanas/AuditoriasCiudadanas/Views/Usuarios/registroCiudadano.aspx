<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registroCiudadano.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.registroCiudadano" %>
<script type="text/javascript" src="../../../Scripts/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-1.10.2.js"></script>
<script type="text/javascript" src="../../Scripts/principal.js"></script>
    <script type="text/javascript" >
        window.onerror = function (e) {
            alert("::ERROR DE SCRIPT::\n" + e);
        }
    </script>
<div id="dvInfoUsu" class="hijo_uno">
<span>Registro</span>
        <table id="tb_registro_usuario">
        <tr>
            <td colspan="2">
                <input id="txtNombre" type="text" class="txtgen" placeholder="Nombre Completo" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <input id="txtCorreo" type="email" class="txtgen" placeholder="Correo electrónico" />
            </td>
        </tr>
        <tr>
        <td colspan="2">
            <input id="txtPassword" type="password" class="txtgen" placeholder="Contraseña" />
        </td>
        </tr>
        <tr>
        <td colspan="2">
            <input id="txtPassword_2" type="password" class="txtgen" placeholder="Confirme contraseña" />
        </td>
        </tr>
        <tr>
            <td colspan="2">
                <input id="txtCelular" class="txtgen" placeholder="Celular" />
            </td>
        </tr>
        <tr>
            <td style="width:50%">
                <!-- departamento-->
                <asp:dropdownlist id="ddlDepartamento" runat="server" DataTextField="nom_departamento" DataValueField ="id_dep" tooltip="--Departamento--">
                </asp:dropdownlist>
            </td>
            <td>
                <!-- municipio-->
                 <asp:dropdownlist id="ddlMunicipio" runat="server" DataTextField="nom_municipio" DataValueField ="id_munic" tooltip="--Municipio--">
                 </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:checkbox id="chkCondiciones" runat="server"></asp:checkbox>&nbsp;&nbsp;<span id="lbl_Terminos">Acepto términos y condiciones</span>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="float: left;">
                    <input type="button" id="btnVolver" value="Volver al Proyecto" />
                </div>
                <div style="float: right;">
                    <input type="button" id="btnAvanzarReg" value="Siguiente" />
                </div>
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript" src="../../../Scripts/UsuariosAcciones.js"></script>
