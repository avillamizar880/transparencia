<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Chat.ListarUsuarios" %>



<div class="container">
    <h1 class="text-center">Comunicación Virtual</h1>
    <div class="alert alert-danger" id="NoSession" runat="server">
        <strong>Error:</strong> Debes iniciar sesión para usar el espacio virtual.
    </div>
    <div class="center-block w60" runat="server" id="contentDiv">
        <p class="text-center">Si tienes alguna duda puedes comunicarte por este medio con un integrante de nuestra comunidad y él te responderá en un plazo de 15 días.</p>
        <div class="well searchBox">
            <form class="form-inline" id="formListarUsuarios" runat="server">

                <input type="hidden" id="hfIdDestinatario" />
                <div class="form-group col-md-10">
                    <input class="form-control" name="query" placeholder="Digite los términos de busqueda..." type="text" id="txtBuscarUsuario">
                </div>
                <button id="btnIrAChat" class="btn btn-primary"><span class="glyphicon glyphicon-search"></span> BUSCAR</button>
            </form>
        </div>


        <!--<div class="form-group text-center">
            <button class="btn btn-info"><span class="glyphicon glyphicon-user"></span> Auditores</button>
            <button class="btn btn-default"><span class="glyphicon glyphicon-globe"></span> Proyectos</button>
            
            </div>-->
        <div class="clearfix"></div>


    </div>

</div>
