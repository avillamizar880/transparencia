<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invitacion.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.Invitacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
         <link href="../../Content/bootstrap.min.css" rel="stylesheet">
         <link href="../../Content/invitacion.css" rel="stylesheet">
    <title>Invitación</title>
</head>
<body>
    <form id="form1" runat="server">
          <div class="row-fluid">
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6" >

                <img src="../../Content/img/invitacion.jpg" id="imagen"  />
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                <div class="short-div" >Fecha de audiencia de <label id="lbltipo" runat="server"></label></div>
                <div class="short-div">El ente territorial, bajo el compromiso adquirido en la audiencia del <label id="lblfechcompromiso" runat="server"></label>, informa sobre la fecha de la audiencia de <label id="lbltipo1" runat="server"></label>.</div>
                <div class="short-div">Fecha de la audiencia <BR/> <label id="lblfecha" runat="server"></label><BR/>Hora<BR/><label id="lblhora" runat="server"></label><BR/>Lugar<BR/><label id="lbllugar" runat="server"></label></div>

            </div>
           
        </div>
    </form>
</body>
</html>
