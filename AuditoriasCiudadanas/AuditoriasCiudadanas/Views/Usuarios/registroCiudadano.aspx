<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registroCiudadano.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.registroCiudadano" %>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../../Content/logo-nav.css" rel="stylesheet" />
<link href="../../Content/screenView.css" rel="stylesheet" />
<div id="divInfoUsu" class="container">
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
                <label for="txtEmail">Correo Electrónico</label>
                <input type="email" class="form-control" id="txtEmail">
            </div>
            <div class="row" id="divInfoClave">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="txtPassword">Contraseña</label>
                        <input type="password" class="form-control" id="txtPassword">
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="txtPassword_2">Confirme contraseña</label>
                        <input type="password" class="form-control" id="txtPassword_2">
                    </div>
                </div>
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
                    <input type="checkbox" class="form-check-input" id="cb_condiciones">
                    <a>ACEPTAR TÉRMINOS Y CONDICIONES</a>
                </label>
            </div>
            <div class="botonera">
                <div class="btn btn-default"><a id="btnVolverProy">VOLVER AL PROYECTO</a></div>
                <div class="btn btn-primary fr"><a id="btnAvanzarReg">Siguiente <span class="glyphicon glyphicon-chevron-right"></span></a></div>

            </div>
        </form>
    </div>
</div>
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script type="text/javascript" src="../../Scripts/Principal.js"></script>
<script src="../../Scripts/jquery.blockUI.js"></script>
<script type="text/javascript" src="../../Scripts/ajaxPost.js"></script>
<script type="text/javascript" src="../../Scripts/UsuariosAcciones.js"></script>
