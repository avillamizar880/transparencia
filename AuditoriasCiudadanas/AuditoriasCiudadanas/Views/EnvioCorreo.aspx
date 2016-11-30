<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnvioCorreo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.EnvioCorreo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script id="ajax">tinymce.init({ selector:'textarea' });</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label for="txtArea">Cuerpo</label>
        <textarea id="txtArea"></textarea>
        <label for="txtAsunto">Cuerpo</label>
        <input type="text" id="txtAsunto" />
        <label for="txtDestinatario">Destinatario</label>
        <input type="text" id="txtDestinatario" />
    </div>
    </form>
</body>
</html>
