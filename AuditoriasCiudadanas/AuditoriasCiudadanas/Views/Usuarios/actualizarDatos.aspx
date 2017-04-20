<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="actualizarDatos.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.actualizarDatos" %>
   <!-- Page Content -->
    <div class="container">
    	<h1>Perfil de Usuario</h1>
        <div class="center-block ">
                 <input type="hidden" id="hdIdUsuario" value="" runat="server" />
                <div class="col-sm-6"> 
                    <label for="txtNombre">Nombre Completo:</label>
                    <input type="text" id="txtNombre" />
                </div>
                <div class="col-sm-6">
                    <label for="txtEmail">Correo Electrónico:</label>
                    <input type="text" id="txtEmail" />
                </div>
                <div class="col-sm-6">
                    <label for="txtCelular">Número de teléfono:</label>
                    <input type="text" id="txtCelular" />
                    </div>
                <div class="col-sm-6">
                    <label for="txtEstado">Estado:</label>
                    <input type="text" id="txtEstado" />
                </div>
                <div class="col-sm-6">
                    <label for="txtDepto">Departamento:</label>
                     <input type="text" id="txtDepto"></input>
                </div>
                <div class="col-sm-6">
                  <label for="txtCiudad">Municipio:</label>
                     <input type="text" id="txtCiudad"></input>
                </div>                
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
