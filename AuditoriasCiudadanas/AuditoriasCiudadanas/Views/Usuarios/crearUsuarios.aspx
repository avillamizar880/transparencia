<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearUsuarios.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.crearUsuarios" %>
<script src="../../Scripts/UsuariosFunciones.js"></script>
<script src="../../Scripts/UsuariosAcciones.js"></script>
   <!-- Page Content -->
    <div class="container">
    	<h1>Creación de Usuarios</h1>
        <div class="center-block w60">
            <form>
                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="ddlPerfil">Perfil</label>
                            <asp:dropdownlist id="ddlPerfil" class="form-control" runat="server" datatextfield="nom_perfil" datavaluefield="id_perfil" tooltip="--Perfil--">
                                <asp:ListItem value="">--Perfil--</asp:ListItem>
                               <asp:ListItem value="1">Administrador</asp:ListItem>
                               <asp:ListItem value="2">Técnico DNP</asp:ListItem>
                            </asp:dropdownlist>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtNombre">Nombre Completo</label>
                    <input type="text" class="form-control" id="txtNombre">
                </div>
                <div class="form-group">
                    <label for="txtEmail">Correo Electrónico</label>
                    <input type="email" class="form-control" id="txtEmail">
                </div>
                <div class="form-group">
                    <label for="txtCelular">Numero de teléfono</label>
                    <input type="tel" class="form-control" id="txtCelular">
                </div>
                
                <!--BOTONERA-->
                <div class="botonera text-center">
                    <div class="btn btn-primary"><a id="btnCrearUsuPerfil" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
                </div>
                <input type="hidden" id="hdIdUsuario" value="" runat="server" />
            </form>
        </div>
    </div>

    
   