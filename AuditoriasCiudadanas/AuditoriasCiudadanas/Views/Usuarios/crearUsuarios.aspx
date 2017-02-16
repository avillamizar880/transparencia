<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearUsuarios.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.crearUsuarios" %>
   <!-- Page Content -->
    <div class="container">
    	<h1>Creación de Usuarios</h1>
        <div class="center-block w60" id="divInfoUsuario">
            <form>
                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="ddlPerfil" class="required">Perfil</label>
                            <asp:dropdownlist id="ddlPerfil" class="form-control" runat="server" datatextfield="nom_perfil" datavaluefield="id_perfil" tooltip="[Seleccione Perfil]">
                                <asp:ListItem value="">[Seleccione Perfil]</asp:ListItem>
                               <asp:ListItem value="1">Administrador</asp:ListItem>
                               <asp:ListItem value="4">Técnico DNP</asp:ListItem>
                            </asp:dropdownlist>
                            <div id="error_ddlPerfil" class="alert alert-danger alert-dismissible" hidden="hidden">Tipo perfil no puede ser vacío</div>
                        </div>
                    </div>
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
                <div class="form-group">
                    <label for="txtCelular">Número de Celular</label>
                    <input type="text" class="form-control" id="txtCelular">
                </div>

                <!--BOTONERA-->
                <div class="botonera text-center">
                    <div class="btn btn-primary"><a id="btnCrearUsuPerfil" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
                </div>
                <input type="hidden" id="hdIdUsuario" value="" runat="server" />
            </form>
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
    
   