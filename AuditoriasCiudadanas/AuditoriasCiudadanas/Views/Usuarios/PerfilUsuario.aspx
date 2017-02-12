<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.PerfilUsuario" %>
<script src="../../Scripts/UsuariosFunciones.js"></script>
<script src="../../Scripts/UsuariosAcciones.js"></script>
   <!-- Page Content -->
    <div class="container">
    	<h1>Perfil de Usuario</h1>
        <div class="center-block w60">
            <form>
                 <input type="hidden" id="hdIdUsuario" value="" runat="server" />

                <div class="form-group">
                    <label for="txtNombre">Nombre Completo</label>
                    <input type="text" class="form-control" id="txtNombre" readonly>
                </div>
                <div class="form-group">
                    <label for="txtEmail">Correo Electrónico</label>
                    <input type="email" class="form-control" id="txtEmail" readonly>
                </div>
                <div class="form-group">
                    <label for="txtCelular">Numero de teléfono</label>
                    <input type="tel" class="form-control" id="txtCelular" readonly>
                </div>
                         
                <div class="form-group">
                    <label for="txtProyectos">Mis Proyectos</label>
                    <div id="divproyectosperfil" runat="server"></div>
                </div>      
            </form>
        </div>
    </div>