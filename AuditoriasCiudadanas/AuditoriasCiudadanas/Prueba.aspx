<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Prueba.Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.10.2.min.js" type="text/javascript" ></script>
        <script src="Scripts/jquery.blockUI.js" type="text/javascript" ></script>

    <script  type="text/javascript">

             function datos(rowid) {
                var strPARAM = "rowid=" + rowid;
                var rutaASP = 'Views/PruebasConsulta.aspx';
                $.ajax({
                    type: "POST", url: rutaASP, data: strPARAM, traditional: true,
                    beforeSend: function () {
                        waitblockUI();
                    },
                    success: function (result) {
                        // respuesta ajax
                        //$("#regSolRecla_" + rowid).html(result);
                        // ---------
                        alert(result);
                        unblockUI();
                    }
                });
            }


            //Funciones para bloqueo/Desbloqueo de pantalla
            function waitblockUI() { $.blockUI({ message: "<h2>Cargando...</h2>" }); }
            function blockUI() { $.blockUI(); }
            function unblockUI() { $.unblockUI(); }

            //Funcion para instanciar el componente calendario a una caja de texto
            function llamarCalendario(inputName, buttonName) {
                if ($("#" + inputName).length > 0) {
                    Calendar.setup({
                        trigger: buttonName,
                        inputField: inputName,
                        dateFormat: "%d/%m/%Y",
                        onSelect: function () { this.hide() }
                    });
                }
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" onclick="datos(1)" />
    </div>
    </form>
</body>
</html>
