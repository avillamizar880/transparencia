<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Llamados.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Pruebas.Llamados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../../Content/logo-nav.css" rel="stylesheet" />
    <link href="../../Content/screenView.css" rel="stylesheet" type="text/css" />
        <script src="../../Scripts/jquery-1.12.4.min.js" type="text/javascript" ></script>
            <script src="../../Scripts/jquery-ui-1.12.1.js" type="text/javascript" ></script>
            <script src="../../Scripts/jquery.blockUI.js" type="text/javascript" ></script>
            <script src="../../Scripts/jquery.smartmenus.min.js" type="text/javascript" ></script>
            <script src="../../Scripts/bootstrap.min.js"></script>
            <script src="../../Scripts/tinymce/tinymce.min.js" type="text/javascript" ></script>
            <script src="../../Scripts/ajaxPost.js" type="text/javascript" ></script>
            <script src="../../Scripts/Principal.js" type="text/javascript" ></script>
 
    <link href="../../Content/themes/base/jquery-ui.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <button type="button" class="btn btn-primary" onclick="fnFacebook(<%="'http://www.facebook.com/sharer.php?u=http://" + HttpContext.Current.Request.Url.Host +":"+Request.Url.Port+ "/views/audiencias/invitacion?tipo=inicio&fecha=26/10/2016 3:00 pm&fechacompromiso=20/09/2016&lugar=colegio de la comunidad'" %>)">Facebook</button>
        <button type="button" class="btn btn-primary" onclick="fnVentanaSimple(<%="'http://" + HttpContext.Current.Request.Url.Host +":"+Request.Url.Port+ "/views/General/EnvioCorreo'" %>)">Correo</button>
        <button type="button" class="btn btn-primary" >Excel</button>
         <button type="button" class="btn btn-primary" onclick="fnVentanaPdf('/prueba.pdf')">Pdf</button>
        <a target="_blank" href="http://www.facebook.com/sharer.php?u=http://localhost:54391/views/audiencias/invitacion?tipo=inicio&fecha=26/10/2016%203:00%20pm&fechacompromiso=20/09/2016&lugar=colegio%20de%20la%20comunidad">Compartir FB</a> 
    </div>
    </form>

     <div id='dialog' title=''></div>
</body>
</html>
