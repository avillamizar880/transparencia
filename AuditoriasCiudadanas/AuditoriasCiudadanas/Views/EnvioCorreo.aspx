<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnvioCorreo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.EnvioCorreo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   

                <link href="Content/bootstrap.min.css" rel="stylesheet">
            <link href="Content/logo-nav.css" rel="stylesheet">
            <link href="Content/screenView.css" rel="stylesheet" type="text/css">
</head>
<body>

    <div>
        <label for="txtArea">Cuerpo</label>
        <textarea id="txtArea" name="txtArea"></textarea>
        <label for="txtAsunto">Asunto</label>
        <input type="text" id="txtAsunto" />
        <label for="txtDestinatario">Destinatario</label>
        <input type="text" id="txtDestinatario" />
    </div>
        <input type="button" id="btnEnviar" value="enviar" onclick="fnEnviarCorreo();" />

</body>
     <script src="../../Scripts/tinymce/tinymce.min.js" id="ajax" type="text/javascript" ></script>
    <script id="ajax" type="text/javascript" >tinymce.init({ selector:'textarea' });</script>
        <script src="../../Scripts/ajaxPost.js"  id="ajax" type="text/javascript" ></script>
    <script src="../../Scripts/Principal.js" id="ajax" type="text/javascript" ></script>

</html>
