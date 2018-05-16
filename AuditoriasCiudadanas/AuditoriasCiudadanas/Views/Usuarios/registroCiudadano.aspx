<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registroCiudadano.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.registroCiudadano" %>
<div id="divInfoUsu" class="container">
    <h1>Registro de usuario</h1>
    <div class="center-block w60">
        <div class="formSteps">
            <div class="step currentStep"><span class="glyphicon glyphicon-edit" title="Registro"></span>Paso 1</div>
            <div class="step"><span class="glyphicon glyphicon-question-sign" title="Verificar Cuenta"></span>Paso 2</div>
            <div class="step"><span class="glyphicon glyphicon-user" title="Envio credenciales"></span>Paso 3</div>
            <div class="step"><span class="glyphicon glyphicon-equalizer" title="Encuesta Caracterización"></span>Paso 4</div>
            <%--<div class="step"><span class="glyphicon glyphicon-blackboard"></span>Paso 5</div>--%>
        </div>
            <div class="form-group">
                <label for="txtNombre" class="required">Nombre Completo</label>
                <input type="text" class="form-control" id="txtNombre">
                <div id="error_txtNombre" class="alert alert-danger alert-dismissible" hidden="hidden">Nombre no puede ser vacío</div>
            </div>
            <div class="form-group">
                <label for="txtEmail" class="required">Correo Electrónico</label>
                <input type="text" class="form-control" id="txtEmail">
                <div id="error_txtEmail" class="alert alert-danger alert-dismissible" hidden="hidden">Correo electrónico no puede ser vacío</div>
            </div>
            <div class="row" id="divInfoClave">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="txtPassword" class="required">Contraseña</label>
                        <input type="password" class="form-control" id="txtPassword">
                        <div id="error_txtPassword" class="alert alert-danger alert-dismissible" hidden="hidden">Contraseña no puede ser vacía</div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="txtPassword_2" class="required">Confirme contraseña</label>
                        <input type="password" class="form-control" id="txtPassword_2">
                        <div id="error_txtPassword_2" class="alert alert-danger alert-dismissible" hidden="hidden">Confirmación no puede ser vacía</div>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label for="txtCelular">Número de Celular</label>
                <input type="text" class="form-control" id="txtCelular">
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="ddlDepartamento" class="required">Departamento</label>
                        <!-- departamento-->
                        <asp:dropdownlist id="ddlDepartamento" class="form-control" runat="server" datatextfield="nom_departamento" datavaluefield="id_dep" tooltip="--Departamento--">
                        </asp:dropdownlist>
                        <div id="error_ddlDepartamento" class="alert alert-danger alert-dismissible" hidden="hidden">Departamento no puede ser vacío</div>
                    </div>

                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="ddlMunicipio" class="required">Municipio</label>
                        <!-- municipio-->
                        <asp:dropdownlist id="ddlMunicipio" class="form-control" runat="server" datatextfield="nom_municipio" datavaluefield="id_munic" tooltip="--Municipio--">
                        </asp:dropdownlist>
                        <div id="error_ddlMunicipio" class="alert alert-danger alert-dismissible" hidden="hidden">Municipio no puede ser vacío</div>
                    </div>
                </div>
            </div>
            <div class="form-check">
                <label class="form-check-label">
                    <input type="checkbox" class="form-check-input" id="cb_condiciones">
                    <a role="button" data-toggle="modal" data-target="#divModalTerminos">ACEPTAR TÉRMINOS Y CONDICIONES</a>
                </label>
            </div>
           <div class="botonera">
                <div class="btn btn-default"><a id="btnVolverProy">VOLVER AL PROYECTO</a></div>
                <div class="btn btn-primary fr"><a id="btnAvanzarReg">Siguiente <span class="glyphicon glyphicon-chevron-right"></span></a></div>

            </div>
    </div>
</div>
<div id="divModalTerminos" class="modal fade" role="dialog">
  <div class="modal-dialog">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Términos y Condiciones:</h4>
      </div>
      <div class="modal-body">
          <div class="embed-container">
              <iframe width="560" height="315" src="/../Views/General/TerminosCondiciones.aspx" style="border:0px;"></iframe>
          </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
      </div>
    </div>

  </div>
</div>
<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/UsuariosFunciones.js", function () {
                $.getScript("../../Scripts/UsuariosAcciones.js", function () {
            });
        });
    }));
</script>
