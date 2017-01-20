<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnvioCorreo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.General.EnvioCorreo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<%--     <script src="../../Scripts/tinymce/tinymce.min.js" id="ajax" type="text/javascript" ></script>
    <script id="ajax" type="text/javascript" >tinyMCE.init({
    selector: 'textarea',
    setup: function (editor) {
        editor.on('change', function () {
            tinyMCE.triggerSave();
            alert();
        });
    }
});</script>--%>

<%--            <link href="Content/bootstrap.min.css" rel="stylesheet">
            <link href="Content/logo-nav.css" rel="stylesheet">
            <link href="Content/screenView.css" rel="stylesheet" type="text/css">--%>

    <style type="text/css">
        #txtDestinatario {
            width: 250px;
        }
    </style>

</head>
<body>


   
    <h3 class="text-center" id="TituloPagina" runat="server" >Invitar a:</h3>
    <div id="letrerobusqueda"></div>
    <div class="well">
        <asp:HiddenField ID="CodigoBPIN" runat="server" />
        <asp:HiddenField ID="idTipoAudiencia" runat="server" />
        <asp:HiddenField ID="asunto" runat="server" />
        <asp:HiddenField ID="numeroGrupo" runat="server" />

        <label for="txtDestinatario">Para:</label>
        <input type="text" id="txtDestinatario" />
         <input type="button" id="btnEnviar" class="btn btn-primary" value="enviar" onclick="fnEnviarCorreo(escape($('#CodigoBPIN').val()), $('#idTipoAudiencia').val(), $('#asunto').val(), $('#numeroGrupo').val(), $('#txtDestinatario').val());" />
    </div>
       

</body>


</html>
