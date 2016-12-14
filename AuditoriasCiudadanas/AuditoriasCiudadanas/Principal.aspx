<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="AuditoriasCiudadanas.Principal" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Auditorias Ciudadanas</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="Content/logo-nav.css" rel="stylesheet" />
    <link href="Content/screenView.css" rel="stylesheet" type="text/css" />
    <!-- Custom js -->
    <script src="Scripts/jquery-1.12.4.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.12.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="Scripts/jquery.smartmenus.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/responsive-tabs.js"></script>
    <script src="Scripts/tinymce/tinymce.min.js" type="text/javascript"></script>
    <script src="Scripts/ajaxPost.js" type="text/javascript"></script>
    <script src="Scripts/Principal.js" type="text/javascript"></script>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
                <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
                <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
            <![endif]-->
</head>
<body>
    <div class="container-fluid">
        <!-- Navigation -->
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            <div class="container">

                <div class="col-sm-6">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                            <span class="sr-only">Desplegar</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#">
                            <img src="Content/img/logo.png" alt="Auditorias ciudadanas" />
                        </a>
                        <!-- SEARCH PROJECTS -->
                        <div class="input-group">
                            <input type="text" class="form-control" placeholder="Buscar Proyectos...">
                            <span class="input-group-btn">
                                <button class="btn btn-info" type="button"><span class="glyphicon glyphicon-search"></span></button>
                            </span>

                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="LogIn">
                        <a href="" class="btn btn-primary"><span class="glyphicon glyphicon-user"></span>Inicie Sesión</a><br />
                        <a href="nuevoUsuarioTCP.html">¿Nuevo usuario? Ingrese Aquí</a>
                    </div>

                </div>
            </div>
            <div class="row">
                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <div class="container">
                        <ul class="nav navbar-nav">
                            <li>
                                <a href="" onclick="cargaMenu('EnvioCorreo','dvPrincipal')">Inicio</a>
                            </li>
                            <li class="active">
                                <a role="button" onclick="cargaMenu('AccesoInformacion/BuscadorProyectosAuditores','dvPrincipal')">Proyectos</a>
                            </li>
                            <li>
                                <a href="projectInfo.html" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información<span class="glyphicon glyphicon-menu-down"></span></a>
                                <ul class="dropdown-menu">
                                    <li><a href="">Guías y manuales</a></li>
                                    <li><a href="">Enlaces de interés</a></li>
                                    <li><a href="">Videos Instructivos</a></li>
                                    <li><a href="">Capacitaciones</a></li>
                                </ul>
                            </li>
                            <li>
                                <a href="espacioVirtual.html">Espacio virtual</a>
                            </li>

                        </ul>
                    </div>
                </div>

            </div>
            <!-- /.navbar-collapse -->

        </nav>
    </div>

    <!-- /.container -->
    <!-- Page Content -->
    <div class="container" id="dvPrincipal" runat="server">
        <div class="row">
            <h2 class="text-center">Listado de Proyectos</h2>
            <div class="list-group uppText">
                <div class="list-group-item">

                    <div class="col-sm-5">
                        <p class="list-group-item-text"><span class="label label-info">Nuevo</span><a href="">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis nunc et dapibus imperdiet. Curabitur in iaculis leo, vel semper augue.</a></p>

                    </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Páramo de San Turbán</span> </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-user"></span><span>Umbrella Corp.</span></div>
                    <div class="col-sm-3 opcionesList">
                        <a href="#">
                            <span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span>
                        </a>
                        <a href="#">
                            <span>
                                <img src="Content/img/iconHand.png" /></span>
                        </a>
                        <a href="#">
                            <span class="glyphicon glyphicon-info-sign"></span><span>Información</span>
                        </a>
                    </div>
                </div>
                <div class="list-group-item">

                    <div class="col-sm-5">
                        <p class="list-group-item-text"><a href="">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis nunc et dapibus imperdiet. Curabitur in iaculis leo, vel semper augue.</a></p>

                    </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Páramo de San Turbán</span> </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>Umbrella Corp.</div>
                    <div class="col-sm-3 opcionesList">
                        <a href="#">
                            <span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span>
                        </a>
                        <a href="#">
                            <span>
                                <img src="Content/img/iconHand.png" /></span>
                        </a>
                        <a href="#">
                            <span class="glyphicon glyphicon-info-sign"></span><span>Información</span>
                        </a>
                    </div>
                </div>
                <div class="list-group-item">

                    <div class="col-sm-5">
                        <p class="list-group-item-text"><a href="">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis nunc et dapibus imperdiet. Curabitur in iaculis leo, vel semper augue.</a></p>

                    </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Páramo de San Turbán</span> </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>Umbrella Corp.</div>
                    <div class="col-sm-3 opcionesList">
                        <a href="#">
                            <span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span>
                        </a>
                        <a href="#">
                            <span>
                                <img src="Content/img/iconHand.png" /></span>
                        </a>
                        <a href="#">
                            <span class="glyphicon glyphicon-info-sign"></span><span>Información</span>
                        </a>
                    </div>
                </div>
                <div class="list-group-item">

                    <div class="col-sm-5">
                        <p class="list-group-item-text"><a href="">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis nunc et dapibus imperdiet. Curabitur in iaculis leo, vel semper augue.</a></p>

                    </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Páramo de San Turbán</span> </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>Umbrella Corp.</div>
                    <div class="col-sm-3 opcionesList">
                        <a href="#">
                            <span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span>
                        </a>
                        <a href="#">
                            <span>
                                <img src="Content/img/iconHand.png" /></span>
                        </a>
                        <a href="#">
                            <span class="glyphicon glyphicon-info-sign"></span><span>Información</span>
                        </a>
                    </div>
                </div>
                <div class="list-group-item">

                    <div class="col-sm-5">
                        <p class="list-group-item-text"><a href="">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis nunc et dapibus imperdiet. Curabitur in iaculis leo, vel semper augue.</a></p>

                    </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Páramo de San Turbán</span> </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>Umbrella Corp.</div>
                    <div class="col-sm-3 opcionesList">
                        <a href="#">
                            <span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span>
                        </a>
                        <a href="#">
                            <span>
                                <img src="Content/img/iconHand.png" /></span>
                        </a>
                        <a href="#">
                            <span class="glyphicon glyphicon-info-sign"></span><span>Información</span>
                        </a>
                    </div>
                </div>
                <div class="list-group-item">

                    <div class="col-sm-5">
                        <p class="list-group-item-text"><a href="">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis nunc et dapibus imperdiet. Curabitur in iaculis leo, vel semper augue.</a></p>

                    </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Páramo de San Turbán</span> </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>Umbrella Corp.</div>
                    <div class="col-sm-3 opcionesList">
                        <a href="#">
                            <span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span>
                        </a>
                        <a href="#">
                            <span>
                                <img src="Content/img/iconHand.png" /></span>
                        </a>
                        <a href="#">
                            <span class="glyphicon glyphicon-info-sign"></span><span>Información</span>
                        </a>
                    </div>
                </div>
                <div class="list-group-item">

                    <div class="col-sm-5">
                        <p class="list-group-item-text"><a href="">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis nunc et dapibus imperdiet. Curabitur in iaculis leo, vel semper augue.</a></p>

                    </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Páramo de San Turbán</span> </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>Umbrella Corp.</div>
                    <div class="col-sm-3 opcionesList">
                        <a href="#">
                            <span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span>
                        </a>
                        <a href="#">
                            <span>
                                <img src="Content/img/iconHand.png" /></span>
                        </a>
                        <a href="#">
                            <span class="glyphicon glyphicon-info-sign"></span><span>Información</span>
                        </a>
                    </div>
                </div>
                <div class="list-group-item">

                    <div class="col-sm-5">
                        <p class="list-group-item-text"><a href="">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis nunc et dapibus imperdiet. Curabitur in iaculis leo, vel semper augue.</a></p>

                    </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Páramo de San Turbán</span> </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>Umbrella Corp.</div>
                    <div class="col-sm-3 opcionesList">
                        <a href="#">
                            <span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span>
                        </a>
                        <a href="#">
                            <span>
                                <img src="Content/img/iconHand.png" /></span>
                        </a>
                        <a href="#">
                            <span class="glyphicon glyphicon-info-sign"></span><span>Información</span>
                        </a>
                    </div>
                </div>
                <div class="list-group-item">

                    <div class="col-sm-5">
                        <p class="list-group-item-text"><a href="">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis nunc et dapibus imperdiet. Curabitur in iaculis leo, vel semper augue.</a></p>

                    </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Páramo de San Turbán</span> </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>Umbrella Corp.</div>
                    <div class="col-sm-3 opcionesList">
                        <a href="#">
                            <span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span>
                        </a>
                        <a href="#">
                            <span>
                                <img src="Content/img/iconHand.png" /></span>
                        </a>
                        <a href="#">
                            <span class="glyphicon glyphicon-info-sign"></span><span>Información</span>
                        </a>
                    </div>
                </div>
                <div class="list-group-item">

                    <div class="col-sm-5">
                        <p class="list-group-item-text"><a href="">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis nunc et dapibus imperdiet. Curabitur in iaculis leo, vel semper augue.</a></p>

                    </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Páramo de San Turbán</span> </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>Umbrella Corp.</div>
                    <div class="col-sm-3 opcionesList">
                        <a href="#">
                            <span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span>
                        </a>
                        <a href="#">
                            <span>
                                <img src="Content/img/iconHand.png" /></span>
                        </a>
                        <a href="#">
                            <span class="glyphicon glyphicon-info-sign"></span><span>Información</span>
                        </a>
                    </div>
                </div>
                <div class="list-group-item">

                    <div class="col-sm-5">
                        <p class="list-group-item-text"><a href="">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis nunc et dapibus imperdiet. Curabitur in iaculis leo, vel semper augue.</a></p>

                    </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Páramo de San Turbán</span> </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>Umbrella Corp.</div>
                    <div class="col-sm-3 opcionesList">
                        <a href="#">
                            <span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span>
                        </a>
                        <a href="#">
                            <span>
                                <img src="Content/img/iconHand.png" /></span>
                        </a>
                        <a href="#">
                            <span class="glyphicon glyphicon-info-sign"></span><span>Información</span>
                        </a>
                    </div>
                </div>
                <div class="list-group-item">

                    <div class="col-sm-5">
                        <p class="list-group-item-text"><a href="">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam venenatis nunc et dapibus imperdiet. Curabitur in iaculis leo, vel semper augue.</a></p>

                    </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Páramo de San Turbán</span> </div>
                    <div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>Umbrella Corp.</div>
                    <div class="col-sm-3 opcionesList">
                        <a href="#">
                            <span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span>
                        </a>
                        <a href="#">
                            <span>
                                <img src="Content/img/iconHand.png" /></span>
                        </a>
                        <a href="#">
                            <span class="glyphicon glyphicon-info-sign"></span><span>Información</span>
                        </a>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
            <!--PAGINATION-->
            <nav aria-label="Page navigation">
                <ul class="pagination">
                    <li>
                        <a href="#" aria-label="Previous">
                            <span aria-hidden="true">&laquo;</span>
                        </a>
                    </li>
                    <li><a href="#">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">5</a></li>
                    <li>
                        <a href="#" aria-label="Next">
                            <span aria-hidden="true">&raquo;</span>
                        </a>
                    </li>
                </ul>
            </nav>
        </div>
    </div>
    <!-- /.container -->
    <!-- FOOTER -->
    <footer>
        <div class="container-fluid">
            Todos los derechos Reservados
    
        </div>
    </footer>
    <div id='dialog' title=''></div>
</body>
</html>
