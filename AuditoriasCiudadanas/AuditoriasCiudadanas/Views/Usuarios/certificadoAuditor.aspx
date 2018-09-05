<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="certificadoAuditor.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.certificadoAuditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <style>
        .contenido {
            width: 900px;
            margin: 0 auto;
        }

        .page-header, .main {
            text-align: center;
        }

        .container{
            margin-top: 50px;
        }

        .absolute{
            position: absolute; 
        }
    </style>

    <script src="/Scripts/jquery-1.12.4.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <img src="/Content/img/ribbon.png" alt="Auditorías ciudadanas" height="200" class="absolute"/>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-lg-12">
                            <img src="/Content/img/logo_link0.png" alt="Departamento Nacional de Planeacion" class="navbar-right" />
                            <img src="/Content/img/logo.png" alt="Auditorías ciudadanas" class="navbar-right" />
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="main">

                        <div class="page-header">
                            <h2>&nbsp;&nbsp;&nbsp;El Departamento Nacional de planeación DNP</h2>
                        </div>
                        <h4>Certifica que:</h4>
                        <h3><u>Juan Camilo Perez Duarte</u></h3>
                        <h4>es</h4>
                        <h3>Auditor Experto</h3>
                        <br />
                        <h4>En la metodología de auditorías ciudadanas y ha participado como auditor en los siguientes proyectos:</h4>
                    </div>
                    <br />

                    <div class="contenido">
                        <table class="table">
                            <tr>
                                <th>CodigoBPIN</th>
                                <th>Nombre</th>
                                <th>Municipio</th>
                                <th>Puntaje</th>
                            </tr>
                            <tr>
                                <td>AX111111</td>
                                <td>Proyecto alfa</td>
                                <td>Sandunga</td>
                                <td>15</td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="row">

                        <div class="col-lg-4">
                        </div>

                        <div class="col-lg-6">
                            <b>2018 - Dirección de Vigilancia a las Regalías</b>
                        </div>

                        <div class="col-lg-2">
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
