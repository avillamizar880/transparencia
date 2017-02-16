<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RedirCorreo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.RedirCorreo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Redirección</title>
        <script src="../Scripts/jquery-1.12.4.min.js" type="text/javascript"></script>
        <script src="../Scripts/ajaxPost.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <input type="hidden" id="hCodigoBPIN" runat="server" />
        <input type="hidden" id="hTipoCorreo" runat="server" />
        <input type="hidden" id="hUrl" runat="server" />
    </div>
    </form>

    <script type="text/javascript">

        if ($(document).ready(function () {
   $("#form1").submit();
         //window.location.href = $("#hUrl").val();
          //ajaxPost('../../Views/Proyectos/infoProyecto', { id_proyecto: $("#hCodigoBPIN").val() }, 'dvPrincipal', function (r) {
          //   $(".detalleEncabezadoProy").show();
          //      }, function (e) {
          //       bootbox.alert(e.responseText); $("#enlaceGrupos").click();
         //});
    }));

</script>

</body>
</html>
