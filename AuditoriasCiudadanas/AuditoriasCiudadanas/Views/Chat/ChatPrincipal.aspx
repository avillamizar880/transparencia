<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatPrincipal.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Chat.Principal" %>


<div class="container">
    <h1 class="text-center">Mensajes</h1>
    <div class="alert alert-danger" id="NoSessionP" runat="server">
        <strong>Error:</strong> Debes iniciar sesión para usar el espacio virtual.
    </div>

    <div class="center-block w60" runat="server" id="contentDivP">
        <div class="userWritting">
            <div class="nav-pills">
                <%--<a role="button" onclick="cargaMenu('Chat/ListarUsuarios','dvPrincipal');" title="Volver" class="pull-left">
                    <span class="glyphicon glyphicon-circle-arrow-left" style="font-size: 1.5em;"></span>
                </a>--%>
                <span class="glyphicon glyphicon-user"></span>
                <asp:label id="lblDestinatario" runat="server" style="font-weight: bold;"></asp:label>
            </div>
        </div>
        <div class="chatBox" id="divMessageHistory" runat="server">
            <div class="msgContainer">
                <div class="media">
                    <div class="media-left media-middle">
                        <a href="#">
                            <span class="glyphicon glyphicon-user"></span>
                        </a>
                    </div>
                    <div class="media-body">
                        <small>05-23-2018</small>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas at vestibulum est. Phasellus vehicula tellus id ante cursus bibendum. Aenean justo magna, gravida et accumsan a, efficitur rutrum ligula.</p>
                    </div>
                </div>
            </div>
            <div class="msgContainer dirLrtl usermsg">
                <div class="media">
                    <div class="media-right media-middle">
                        <a href="#">
                            <span class="glyphicon glyphicon-user"></span>
                        </a>
                    </div>
                    <div class="media-body">
                        <small>05-24-2018</small>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas at vestibulum est. Phasellus vehicula tellus id ante cursus bibendum. Aenean justo magna, gravida et accumsan a, efficitur rutrum ligula.</p>
                    </div>
                </div>
            </div>
            <div class="msgContainer">
                <div class="media">
                    <div class="media-left media-middle">
                        <a href="#">
                            <span class="glyphicon glyphicon-user"></span>
                        </a>
                    </div>
                    <div class="media-body">
                        <small>05-23-2018</small>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas at vestibulum est. Phasellus vehicula tellus id ante cursus bibendum. Aenean justo magna, gravida et accumsan a, efficitur rutrum ligula.</p>
                    </div>
                </div>
            </div>
            <div class="msgContainer">
                <div class="media">
                    <div class="media-left media-middle">
                        <a href="#">
                            <span class="glyphicon glyphicon-user"></span>
                        </a>
                    </div>
                    <div class="media-body">
                        <small>05-23-2018</small>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas at vestibulum est. Phasellus vehicula tellus id ante cursus bibendum. Aenean justo magna, gravida et accumsan a, efficitur rutrum ligula.</p>
                    </div>
                </div>
            </div>
            <div class="msgContainer dirLrtl usermsg">
                <div class="media">
                    <div class="media-right media-middle">
                        <a href="#">
                            <span class="glyphicon glyphicon-user"></span>
                        </a>
                    </div>
                    <div class="media-body">
                        <small>05-24-2018</small>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas at vestibulum est. Phasellus vehicula tellus id ante cursus bibendum. Aenean justo magna, gravida et accumsan a, efficitur rutrum ligula.</p>
                    </div>
                </div>
            </div>
            <div class="msgContainer">
                <div class="media">
                    <div class="media-left media-middle">
                        <a href="#">
                            <span class="glyphicon glyphicon-user"></span>
                        </a>
                    </div>
                    <div class="media-body">
                        <small>05-23-2018</small>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas at vestibulum est. Phasellus vehicula tellus id ante cursus bibendum. Aenean justo magna, gravida et accumsan a, efficitur rutrum ligula.</p>
                    </div>
                </div>
            </div>
        </div>


        <!--<div class="form-group text-center">
            <button class="btn btn-info"><span class="glyphicon glyphicon-user"></span> Auditores</button>
            <button class="btn btn-default"><span class="glyphicon glyphicon-globe"></span> Proyectos</button>
            
            </div>-->
        <div class="clearfix"></div>

        <div class="sendBox well">
            <form class="form-inline" id="formChatPrincipal" runat="server">
                <asp:hiddenfield id="hdnIdRemitente"
                    value=""
                    runat="server" />
                <asp:hiddenfield id="hdnIdDestinatario"
                    value=""
                    runat="server" />
                <div class="form-group col-md-10">
                    <input type="text" class="form-control" placeholder="Digite su mensaje" id="txtMensaje">
                </div>
                <button id="btnEnviarMensaje" class="btn btn-primary"><span class="glyphicon glyphicon-send"></span> ENVIAR</button>
            </form>
        </div>

    </div>

</div>
