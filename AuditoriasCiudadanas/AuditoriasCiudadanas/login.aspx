<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AuditoriasCiudadanas.login" %>

<!DOCTYPE html>

<html>
<head>
    <title>Redireccionando...</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/screenView.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="Scripts/jquery-1.12.4.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="Scripts/ajaxPost.js" type="text/javascript"></script>
    <script src="Scripts/Principal.js" type="text/javascript"></script>
    <script src="Scripts/bootbox.min.js"></script>
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        form {
            border: 3px solid #f1f1f1;
            background-color: #4CAF50;
        }

        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        button {
            background-color: #00B5C6;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: 1px solid #f1f1f1;
            cursor: pointer;
            width: 100%;
        }

            button:hover {
                color: #fff;
                background-color: #269abc;
                border-color: #1b6d85;
            }

        .cancelbtn {
            width: auto;
            padding: 10px 18px;
            background-color: #f44336;
        }

        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }

        img.avatar {
            width: 40%;
            border-radius: 50%;
        }

        span.psw {
            float: right;
            padding-top: 16px;
        }

        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }

            .cancelbtn {
                width: 100%;
            }
        }

        .cont {
            width: 400px;
            display: block;
            margin-left: auto;
            margin-right: auto;
        }
        label {
            color:white;
        }
    </style>

</head>
<body>
    <div class="container-fluid">
        <div class="container headBar" style="width:500px;">
            <div>
            <a class="navbar-brand" href="#">
                <img src="Content/img/logo_link0.png" alt="Departamento Nacional de Planeacion">
            </a>
            <a class="navbar-brand" href="#">
                <img src="Content/img/logo.png" alt="Auditorías ciudadanas">
            </a>
            </div>
        </div>


        <div class="container">
            <div class="logForm cont img-rounded">
                <div class="imgcontainer">
                    <i class="fa fa-user-circle-o" style="font-size:100px; color:white;"></i>
                </div>
                <label for="userName"><b>Usuario</b></label>
                <input type="text" placeholder="Ingrese el usuario" id="userName">

                <label for="pass"><b>Contraseña</b></label>
                <input type="password" placeholder="Ingrese la contraseña" id="pass">

                <button onclick="validaLoginRed('<%= strParam %>');">INGRESAR <span class="glyphicon glyphicon-log-in"></span></button>
            </div>
        </div>

    </div>

</body>
</html>
