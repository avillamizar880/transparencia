<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.PerfilUsuario" %>
<script src="../../Scripts/UsuariosFunciones.js"></script>
<script src="../../Scripts/UsuariosAcciones.js"></script>
   <!-- Page Content -->
    <div class="container">
    	<h1>Perfil de Usuario</h1>
        <div class="center-block ">
            <form>
                 <input type="hidden" id="hdIdUsuario" value="" runat="server" />
                <div class="col-sm-6"> 
                    <label for="txtNombre">Nombre Completo:</label>
                    <div id="divtxtNombre"></div>
                </div>
                <div class="col-sm-6">
                    <label for="txtEmail">Correo Electrónico:</label>
                     <div id="divtxtEmail"></div>

                </div>
                <div class="col-sm-6">
                    <label for="txtCelular">Número de teléfono:</label>
                     <div id="divtxtCelular"></div>
                </div>
                <div class="col-sm-6">
                    <label for="txtEstado">Estado:</label>
                     <div id="divtxtEstado"></div>
                </div>
                <div class="col-sm-6">
                    <label for="txtDepto">Departamento:</label>
                     <div id="divtxtDepto"></div>
                </div>
                <div class="col-sm-6">
                    <label for="txtCiudad">Municipio:</label>
                     <div id="divtxtCiudad"></div>
                </div>                
                <div id="divOtrosDatos"></div>
                <div class="col-sm-12">
                    <div class="form-group">
                        <h3>Mis Proyectos</h3>
                        <div id="divProyectosAud" runat="server"></div>
                    </div>      
                </div>

            </form>
        </div>
    </div>