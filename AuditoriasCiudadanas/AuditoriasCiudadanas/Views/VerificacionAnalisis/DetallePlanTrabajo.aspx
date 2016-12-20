<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallePlanTrabajo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.VerificacionAnalisis.DetallePlanTrabajo" %>

<!DOCTYPE html>
<html lang="es">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Auditor69_Auditorias ciudadanas</title>

    <%-- Archivos CSS--%>
        <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
        <link href="../../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" />
        <link href="../../Content/logo-nav.css" rel="stylesheet" />
        <link href="../../Content/screenView.css" rel="stylesheet" />
       
      <%-- Archivos JS--%>
        <script src="../../Scripts/jquery-1.12.4.min.js" type="text/javascript" ></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
       <%-- <script type="text/javascript" src="../../Scripts/principal.js"></script>--%>
        <script type="text/javascript" src="../../Scripts/ajaxPost.js"></script>
        <%--<script src="../../Scripts/EncuestaCaracterizacion.js" type="text/javascript"></script>  --%>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<body class="inside">

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
                    <img src="../../Content/img/logo.png" alt="Auditorias ciudadanas"/>
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
            	<div class="LogIn"><button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
  INICIE SESIÓN
</button><br/>
                    <a href="nuevoUsuarioTCP.html" target="_self">¿Nuevo usuario? Ingrese Aquí</a></div>
                <!-- COLLAPSED logIn FORM-->
                <div class="logHiddenForm">
               <div class="collapse" id="collapseExample">
                  <div class="logForm">
                    <form>
                        <div class="form-group">
                            <label for="user" class="hidden">Nombre Completo</label>
                            <input type="text" class="form-control" id="userName" placeholder="Usuario" >
                         </div>
                         <div class="form-group">
                            <input type="password" class="form-control" id="pass" placeholder="Contraseña" >
                         </div>
                         <div class="btn btn-info "><a href="nuevoUsuarioTCP_p2.html">INGRESAR <span class="glyphicon glyphicon-log-in"></span></a></div>
                         <div class="">
                          <a href="" class="small">Olvidé mi contraseña</a>
                         </div>
             		</form>
                  </div>
                </div>
                </div>
            </div>
            </div>
            <div class="row">
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            	<div class="container">
                <ul class="nav navbar-nav">
                     <li>
                        <a href="index.html">Inicio</a>
                    </li>
                    <li class="active">
                        <a href="profileProject.html">Proyectos</a>
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
    <!-- MIGA DE PAN -->
    <div class="container">
    	<div class="row">
    	<ol class="breadcrumb">
          <li><a href="#">Inicio</a></li>
          <li><a href="#">Tareas</a></li>
          <li class="active">Nombre de la Tarea</li>
        </ol>
        </div>
    </div>
    <!-- Page Content -->
    <div class="container generalInfo">
    	<div class="row">
        	<div class="headSection">
            	<div class="col-sm-12 headTit">
                    <span>TAREA</span>
                </div>
              <div class="col-sm-9">
                <h3>Ut egestas ligula a lacus commodo, id fringilla massa malesuada. Nam laoreet odio rutrum ante gravida egestas. Phasellus nec gravida mauris. Interdum et malesuada fames ac ante ipsum primis in faucibus. Morbi id sem at erat blandit vehicula. Sed orci nisi, commodo eu pharetra id, iaculis ut sapien.</h3>
                <div class="row">
                    <div class=" col-sm-6"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;05/07/2020</div>
                   <div class=" col-sm-6"><span class="glyphicon glyphicon-time"></span> Hora:&nbsp; 00:00hrs </div>
               	</div>
               </div>
                <div class="col-sm-3 userActions">
            	<div class="btn btn-default btn-lg"><span class="glyphicon glyphicon-pencil"></span><span>Editar</span></div>
                <div class="btn btn-default  btn-lg"><span class="glyphicon glyphicon-trash"></span>Eliminar</div>
            </div>
              </div>
		</div>
        <div class="row">
        	<div class="col-sm-3">
            	<div class="leftMenu">
            <!--TABS-->
                <ul class="nav nav-tabs nav-stacked">
                  <li class="active"><a data-toggle="tab" href="#tab1">Descripción<span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab2">Actividades<span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab3">Opinión<span class="glyphicon glyphicon-menu-right"></span></a></li>
                  <li><a data-toggle="tab" href="#tab4">Registro Fotográfico<span class="glyphicon glyphicon-menu-right"></span></a></li>
                </ul>
                </div>
			</div>
            <div class="col-sm-9">
            	<div class="generalInfo">
                	<div class="tab-content">
                    	<!--CONTENT1 Descripción-->
                      <div id="tab1" class="tab-pane fade in active">
                      <h4>Descripción <div class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-plus"></span> Agregar nueva descripción</a></div></h4>
                      	<div class="well">
                        	<div class="wrap"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;05/07/2020</div>
                            <!--DESC-->
                            <p>Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. Praesent tristique urna sit amet libero ullamcorper vestibulum. Sed suscipit nulla mi, in feugiat arcu tempor eget. Suspendisse imperdiet sapien eget finibus congue. Proin tincidunt sem non dui condimentum rhoncus. Aenean eget condimentum est. Sed et massa id metus bibendum cursus sit amet vitae justo. Sed eros dui, finibus nec leo non, ornare sollicitudin leo.</p>
                            </div>
                        <div class="well">
                        	<div class="wrap"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;15/11/2021</div>
                            <!--DESC-->
                            <p>Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. Praesent tristique urna sit amet libero ullamcorper vestibulum. Sed suscipit nulla mi, in feugiat arcu tempor eget. Suspendisse imperdiet sapien eget finibus congue. Proin tincidunt sem non dui condimentum rhoncus. Aenean eget condimentum est. Sed et massa id metus bibendum cursus sit amet vitae justo. Sed eros dui, finibus nec leo non, ornare sollicitudin leo.</p>
                            </div>
                        
                      </div>
                      <!--CONTENT2 Actividades-->
                      <div id="tab2" class="tab-pane fade">
                         <h4>Actividades</h4>
                         <div class="checkbox">
                            <label><input type="checkbox">Etiam feugiat turpis justo, vitae placerat eros convallis ut,  Fusce tortor magna, vehicula laoreet mi vitae.</label>
                          </div>
                         <div class="checkbox">
                            <label><input type="checkbox">Phasellus non nisi at est interdum ultricies et eget velit.</label>
                          </div>
                         <div class="checkbox">
                            <label><input type="checkbox">Etiam feugiat turpis justo, vitae placerat eros convallis ut,  Fusce tortor magna, vehicula laoreet mi vitae.</label>
                          </div>
                         <div class="checkbox">
                            <label><input type="checkbox">Phasellus non nisi at est interdum ultricies et eget velit.</label>
                          </div>    
                      </div>
                       <!--CONTENT3 Opinion-->
                      <div id="tab3" class="tab-pane fade">
                        <h4>Opinión <div class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#nuevaOpinion"><span class="glyphicon glyphicon-plus"></span> Agregar Nueva Opinón</a></div></h4>
                        <div class="well">
                        	<div class="wrap"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;05/07/2020</div>
                            <!--DESC-->
                            <p>Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. Praesent tristique urna sit amet libero ullamcorper vestibulum. Sed suscipit nulla mi, in feugiat arcu tempor eget. Suspendisse imperdiet sapien eget finibus congue. Proin tincidunt sem non dui condimentum rhoncus. Aenean eget condimentum est. Sed et massa id metus bibendum cursus sit amet vitae justo. Sed eros dui, finibus nec leo non, ornare sollicitudin leo.</p>
                            </div>
                        <div class="well">
                        	<div class="wrap"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;15/11/2021</div>
                            <!--DESC-->
                            <p>Integer urna odio, sagittis vel augue in, tristique dictum nisi. Praesent sodales tellus at rutrum porttitor. Nulla facilisis interdum molestie. Nulla mattis faucibus interdum. Praesent tristique urna sit amet libero ullamcorper vestibulum. Sed suscipit nulla mi, in feugiat arcu tempor eget. Suspendisse imperdiet sapien eget finibus congue. Proin tincidunt sem non dui condimentum rhoncus. Aenean eget condimentum est. Sed et massa id metus bibendum cursus sit amet vitae justo. Sed eros dui, finibus nec leo non, ornare sollicitudin leo.</p>
                            </div>
                        
                      </div>
                       <!--CONTENT4 Reg. Fotográfico-->
                      <div id="tab4" class="tab-pane fade regMultimedia">
                        <h4>Registro Multimedia <div class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#nuevoRegistroMul" ><span class="glyphicon glyphicon-plus"></span> Agregar Nuevo Registro</a></div></h4>
                        
                        <div class="row">
                        	<div class="col-sm-4">
                                <div class="card">
                                  <img class="card-img-top" src="../../Content/img/defaultImg.gif" alt="Registro 1">
                                  <div class="card-block">
                                  	<ul class="list-group">
                                      <li class="list-group-item"><p class="card-text">Aliquam porta mauris velit, nec consectetur urna tristique vel. Suspendisse potenti</p></li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-user"></span>&nbsp; Fotógrafo: Chewbacca</li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: Chewbacca</li>
                                    </ul>

                                  </div>
                                </div>
                        	</div>
                            <div class="col-sm-4">
                            	<div class="card">
                                  <img class="card-img-top" src="../../Content/img/defaultImg.gif" alt="Registro 1">
                                  <div class="card-block">
                                  	<ul class="list-group">
                                      <li class="list-group-item"><p class="card-text">Aliquam porta mauris velit, nec consectetur urna tristique vel. Suspendisse potenti</p></li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-user"></span>&nbsp; Fotógrafo: Chewbacca</li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: Chewbacca</li>
                                    </ul>

                                  </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                            	<div class="card">
                                  <img class="card-img-top" src="../../Content/img/defaultVideo.gif" alt="Registro 1">
                                  <div class="card-block">
                                  	<ul class="list-group">
                                      <li class="list-group-item"><p class="card-text">Aliquam porta mauris velit, nec consectetur urna tristique vel. Suspendisse potenti</p></li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-user"></span>&nbsp; Fotógrafo: Chewbacca</li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: Chewbacca</li>
                                    </ul>

                                  </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                        	<div class="col-sm-4">
                                <div class="card">
                                  <img class="card-img-top" src="../../Content/img/defaultImg.gif" alt="Registro 1">
                                  <div class="card-block">
                                  	<ul class="list-group">
                                      <li class="list-group-item"><p class="card-text">Aliquam porta mauris velit, nec consectetur urna tristique vel. Suspendisse potenti</p></li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-user"></span>&nbsp; Fotógrafo: Chewbacca</li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: Chewbacca</li>
                                    </ul>

                                  </div>
                                </div>
                        	</div>
                            <div class="col-sm-4">
                            	<div class="card">
                                  <img class="card-img-top" src="../../Content/img/defaultImg.gif" alt="Registro 1">
                                  <div class="card-block">
                                  	<ul class="list-group">
                                      <li class="list-group-item"><p class="card-text">Aliquam porta mauris velit, nec consectetur urna tristique vel. Suspendisse potenti</p></li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-user"></span>&nbsp; Fotógrafo: Chewbacca</li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: Chewbacca</li>
                                    </ul>

                                  </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                            	<div class="card">
                                  <img class="card-img-top" src="../../Content/img/defaultVideo.gif" alt="Registro 1">
                                  <div class="card-block">
                                  	<ul class="list-group">
                                      <li class="list-group-item"><p class="card-text">Aliquam porta mauris velit, nec consectetur urna tristique vel. Suspendisse potenti</p></li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-user"></span>&nbsp; Fotógrafo: Chewbacca</li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: Chewbacca</li>
                                    </ul>

                                  </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                        	<div class="col-sm-4">
                                <div class="card">
                                  <img class="card-img-top" src="../../Content/img/defaultImg.gif" alt="Registro 1">
                                  <div class="card-block">
                                  	<ul class="list-group">
                                      <li class="list-group-item"><p class="card-text">Aliquam porta mauris velit, nec consectetur urna tristique vel. Suspendisse potenti</p></li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-user"></span>&nbsp; Fotógrafo: Chewbacca</li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: Chewbacca</li>
                                    </ul>

                                  </div>
                                </div>
                        	</div>
                            <div class="col-sm-4">
                            	<div class="card">
                                  <img class="card-img-top" src="../../Content/img/defaultImg.gif" alt="Registro 1">
                                  <div class="card-block">
                                  	<ul class="list-group">
                                      <li class="list-group-item"><p class="card-text">Aliquam porta mauris velit, nec consectetur urna tristique vel. Suspendisse potenti</p></li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-user"></span>&nbsp; Fotógrafo: Chewbacca</li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: Chewbacca</li>
                                    </ul>

                                  </div>
                                </div>
                            </div>
                            <div class="col-sm-4">
                            	<div class="card">
                                  <img class="card-img-top" src="../../Content/img/defaultVideo.gif" alt="Registro 1">
                                  <div class="card-block">
                                  	<ul class="list-group">
                                      <li class="list-group-item"><p class="card-text">Aliquam porta mauris velit, nec consectetur urna tristique vel. Suspendisse potenti</p></li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-user"></span>&nbsp; Fotógrafo: Chewbacca</li>
                                      <li class="list-group-item"><span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: Chewbacca</li>
                                    </ul>

                                  </div>
                                </div>
                            </div>
                        </div>
                        
                      </div>

                   	</div>
                </div>
            
            </div>
            
            
        </div>
        
        
    </div>
    <!-- /.container -->
	<!-- FOOTER -->
    <div class="clearfix"></div>
	<footer>
    <div class="container-fluid">
    	Todos los derechos Reservados
    </div>
    </footer>

    <!-- NUEVA DESCRIPCIÓN -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="myModalLabel">Nueva Descripción</h4>
          </div>
          <div class="modal-body">
			<textarea placeholder="Describa la tarea" class="form-control" rows="5" ></textarea>
            </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
            <button type="button" class="btn btn-primary">Guardar</button>
          </div>
        </div>
      </div>
    </div>
    <!-- NUEVA OPINIÓN -->
    <div class="modal fade" id="nuevaOpinion" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="nuevaOpinionLabel">Nueva Opinión</h4>
          </div>
          <div class="modal-body">
			<textarea placeholder="Describa su opinión" class="form-control" rows="5" ></textarea>
            </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
            <button type="button" class="btn btn-primary">Guardar</button>
          </div>
        </div>
      </div>
    </div>
    <!-- NUEVA REGISTRO MULTIMEDIA -->
    <div class="modal fade" id="nuevoRegistroMul" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="nuevaRegistroMulLabel">Nuevo Registro Multimedia</h4>
          </div>
          <div class="modal-body">
			<textarea placeholder="Descripción" class="form-control" rows="5" ></textarea>
            <input type="text" class="form-control" placeholder="Nombres y apellidos"/>
            <input type="date" class="form-control" />
            <input type="file" class="form-control" />
            </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
            <button type="button" class="btn btn-primary">Guardar</button>
          </div>
        </div>
      </div>
    </div>

</body>

</html>