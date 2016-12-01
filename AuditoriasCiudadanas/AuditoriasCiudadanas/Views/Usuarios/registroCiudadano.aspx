<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registroCiudadano.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.registroCiudadano" %>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../../Content/logo-nav.css" rel="stylesheet" />
<link href="../../Content/screenView.css" rel="stylesheet" />

<div class="container">
    <h1>Nuevo Usuario</h1>
    <div class="center-block w60">
        <div class="formSteps">
            <div class="step currentStep"><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
            <div class="step"><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
            <div class="step"><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            <div class="step"><span class="glyphicon glyphicon-equalizer"></span>Paso 4</div>
            <div class="step"><span class="glyphicon glyphicon-blackboard"></span>Paso 5</div>
        </div>
        <form>
            <div class="form-group">
                <label for="txtNombre">Nombre Completo</label>
                <input type="text" class="form-control" id="txtNombre">
            </div>
            <div class="form-group">
                <label for="email">Correo Electrónico</label>
                <input type="email" class="form-control" id="email">
            </div>
            <div class="form-group">
                <label for="txtCelular">Numero de teléfono</label>
                <input type="tel" class="form-control" id="txtCelular">
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="ddlDepartamento">Departamento</label>
                        <!-- departamento-->
                        <asp:dropdownlist id="ddlDepartamento" class="form-control" runat="server" datatextfield="nom_departamento" datavaluefield="id_dep" tooltip="--Departamento--">
                        </asp:dropdownlist>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="municipio">Municipio</label>
                        <!-- municipio-->
                        <asp:dropdownlist id="ddlMunicipio" class="form-control" runat="server" datatextfield="nom_municipio" datavaluefield="id_munic" tooltip="--Municipio--">
                        </asp:dropdownlist>
                    </div>
                </div>
            </div>
            <div class="form-check">
                <label class="form-check-label">
                    <input type="checkbox" class="form-check-input">
                    <a>ACEPTAR TÉRMINOS Y CONDICIONES</a>
                </label>
            </div>
            <div class="botonera">
                <div class="btn btn-default"><a>VOLVER AL PROYECTO</a></div>
                <div class="btn btn-primary fr"><a href="nuevoUsuarioTCP_p2.html">Siguiente <span class="glyphicon glyphicon-chevron-right"></span></a></div>

            </div>
        </form>
    </div>
</div>


<%--<div id="dvInfoUsu">
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
</div>--%>
<script type="text/javascript" src="../../../Scripts/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/principal.js"></script>
<script type="text/javascript" src="../../Scripts/ajaxPost.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script type="text/javascript" src="../../../Scripts/UsuariosAcciones.js"></script>
