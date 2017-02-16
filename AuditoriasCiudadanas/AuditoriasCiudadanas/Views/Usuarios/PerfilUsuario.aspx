<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.PerfilUsuario" %>
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
                        <h1>Mis Proyectos</h1>
                        <div id="divProyectosAud" runat="server"></div>
                    </div>      
                </div>

            </form>
        </div>
    </div>
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript('../../Scripts/UsuariosFunciones.js', function () {
           $.getScript('../../Scripts/UsuariosAcciones.js', function () {
          
        });
    });
}));
</script>