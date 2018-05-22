<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notificaciones.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.notificaciones" %>

<form id="formNotificaciones" runat="server">
    <div class="container">
        <h1>Notificaciones</h1>
        <div class="alert alert-danger" id="NoSession" runat="server">
            <strong>Error:</strong> Debes iniciar sesión para usar el espacio virtual.
        </div>
        <div class="well" align="center" runat="server" id="contentDiv">
            <div class="form-group">
                <h4>Revise aquí las últimas notificaciones recibidas.
                </h4>
            </div>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th  onclick="console.log({'hola':'f'});">Notificación</th>
                        <th>Fecha</th>
                        <th>Acción</th>
                    </tr>
                </thead>
                <tbody runat="server" id="tbNotificaciones"> 
                    <tr>
                        <td>Nuevo mensaje de Victor Julio Ramirez</td>
                        <td>2019/05/10</td>
                        <td><a class="btn btn-info btn-sm">Ver</a></td>
                    </tr>
                    <tr>
                        <td>Nuevo mensaje de Diana Rosalva Villamizar</td>
                        <td>2019/05/10</td>
                        <td><a class="btn btn-info btn-sm">Ver</a></td>
                    </tr>
                    <tr>
                        <td>Nuevo mensaje de Carlos Triana</td>
                        <td>2019/05/10</td>
                        <td><a class="btn btn-info btn-sm">Ver</a></td>
                    </tr>
                </tbody>
            </table>
        </div>

    </div>
</form>
