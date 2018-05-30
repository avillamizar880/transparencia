<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminForo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Comunicacion.adminForo" %>

<!-- Page Content -->
<div class="container" id="NoSession" runat="server">
    <h1 class="text-center">Foro</h1>
    <div class="alert alert-danger">
        <strong>Error:</strong> Debes iniciar sesión para usar el espacio virtual.
    </div>
</div>
<div class="container" id="divInfoForo" runat="server">
    <h1 class="text-center">Foro</h1>
    <div class="sendBox well">
        <div class="form-group">
            <div class="row">
                <div class="col-md-8">
                    <input type="text" class="form-control" placeholder="Buscar por municipio Nombre o tema">
                </div>
                <div class="col-md-2"><a class="btn btn-primary" role="button"><span class="glyphicon glyphicon-search"></span> Buscar</a></div>
                <div class="col-md-2"><a class="btn btn-default" role="button" id="btnNuevoTema"><span class="glyphicon glyphicon-plus"></span> Nuevo Tema</a></div>
            </div>

        </div>
    </div>
    <div class="sendBox well" style="display:none;" id="divNuevoTema">
        <form>
            <div class="form-group">
                <div class="row">
                    <div class="col-md-10">
                        <input type="text" class="form-control" placeholder="Añade un nuevo tema">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <textarea class="form-control" rows="4" placeholder="Comparte un comentario"></textarea>
            </div>
            <div class="form-group">
                <button type="submit" class="btn btn-primary"><span class="glyphicon glyphicon-send"></span> COMENTAR</button>
            </div>
        </form>
    </div>

    <!--PREGUNTA-->
    <div class="questionsBox row">
        <div class="col-md-1">
            <div class="imgUser">
                <img class="img-responsive" src="Content/img/imagUser.jpg" />
            </div>
            <div class="text-center">Luke Skywalker</div>
        </div>
        <div class="col-md-11">
            <div class="label simple-label">02-03-2018</div>
            <div class="label simple-label">Categoria/Tema </div>
            <a href="">
                <h3 class="titQuestion">¿Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin accumsan in libero eu fermentum. ?</h3>
            </a>

            <p class="descQuestion">Vivamus mollis luctus diam non efficitur. Proin et ultrices tortor, eu dictum tellus. Pellentesque aliquam vestibulum erat, sed lacinia lorem tempus quis. Curabitur eget turpis eget neque dignissim faucibus. Nullam tincidunt sagittis ligula, at mattis magna tempor a. In vitae metus hendrerit, blandit neque id, mollis arcu. Sed sed diam ut dolor aliquam posuere eget ut mi.</p>
            <div class="optionsBtn">
                <button class="btn btn-primary" data-toggle="collapse" data-target="#newComent"><span class="glyphicon glyphicon-share-alt"></span>Responder</button>
                <!--<div class="btn btn-default"> <span class="glyphicon glyphicon-minus"></span> Ocultar Respuestas</div> -->
            </div>
            <!--NUEVO COMENTARIO-->
            <div class="collapse" id="newComent">
                <div class="comentBox">
                    <label>Escriba aqui su respuesta</label>
                    <textarea rows="4" class="form-control"></textarea>
                    <button type="submit" class="btn btn-primary"><span class="glyphicon glyphicon-send"></span>Enviar</button>
                </div>
            </div>

            <!--RESPUESTA-->
            <div class="answerBox">
                <div class="col-md-1 text-center">
                    <div class="imgUser">
                        <img class="img-responsive" src="Content/img/imagUser.jpg" />
                    </div>
                </div>
                <div class="col-md-11">
                    <div class="label simple-label">Por: Chewbacca</div>
                    <div class="label simple-label">02-03-2018</div>
                    <p class="descQuestion">Vivamus mollis luctus diam non efficitur. Proin et ultrices tortor, eu dictum tellus. Pellentesque aliquam vestibulum erat, sed lacinia lorem tempus quis. Donec tincidunt mi nec urna gravida, non placerat metus porttitor. Vestibulum ultricies, ex vitae facilisis mollis, ex felis tempus mi, vitae aliquam est risus ut eros. Donec placerat neque ante, id pretium ex vulputate eu.</p>

                </div>

            </div>
            <div class="answerBox">
                <div class="col-md-1 text-center">
                    <div class="imgUser">
                        <img class="img-responsive" src="Content/img/imagUser.jpg" />
                    </div>
                </div>
                <div class="col-md-11">
                    <div class="label simple-label">Por: Chewbacca</div>
                    <div class="label simple-label">02-03-2018</div>
                    <p class="descQuestion">Vivamus mollis luctus diam non efficitur. Proin et ultrices tortor, eu dictum tellus. Pellentesque aliquam vestibulum erat, sed lacinia lorem tempus quis. Donec tincidunt mi nec urna gravida, non placerat metus porttitor. Vestibulum ultricies, ex vitae facilisis mollis, ex felis tempus mi, vitae aliquam est risus ut eros. Donec placerat neque ante, id pretium ex vulputate eu.</p>

                </div>

            </div>
            <div class="answerBox">
                <div class="col-md-1 text-center">
                    <div class="imgUser">
                        <img class="img-responsive" src="Content/img/imagUser.jpg" />
                    </div>
                </div>
                <div class="col-md-11">
                    <div class="label simple-label">Por: Chewbacca</div>
                    <div class="label simple-label">02-03-2018</div>
                    <p class="descQuestion">Vivamus mollis luctus diam non efficitur. Proin et ultrices tortor, eu dictum tellus. Pellentesque aliquam vestibulum erat, sed lacinia lorem tempus quis. Donec tincidunt mi nec urna gravida, non placerat metus porttitor. Vestibulum ultricies, ex vitae facilisis mollis, ex felis tempus mi, vitae aliquam est risus ut eros. Donec placerat neque ante, id pretium ex vulputate eu.</p>

                </div>

            </div>
            <div class="col-md-12 text-center">
                <div class="btn btn-default"><a href="foro_auditor54_B.html"><span class="glyphicon glyphicon-plus"></span>Ver Respuestas</a></div>
            </div>
        </div>
    </div>


    <!--PREGUNTA-->
    <div class="questionsBox row">
        <div class="col-md-1">
            <div class="imgUser">
                <img class="img-responsive" src="Content/img/imagUser.jpg" />
            </div>
            <div class="text-center">Luke Skywalker</div>
        </div>
        <div class="col-md-11">
            <div class="label simple-label">02-03-2018</div>
            <div class="label simple-label">Categoria/Tema </div>
            <a href="">
                <h3 class="titQuestion">¿Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin accumsan in libero eu fermentum. ?</h3>
            </a>

            <p class="descQuestion">Vivamus mollis luctus diam non efficitur. Proin et ultrices tortor, eu dictum tellus. Pellentesque aliquam vestibulum erat, sed lacinia lorem tempus quis.</p>
            <div class="optionsBtn">
                <div class="btn btn-primary"><span class="glyphicon glyphicon-share-alt"></span>Responder</div>
                <div class="btn btn-default"><span class="glyphicon glyphicon-plus"></span>Ver Respuestas</div>
            </div>

        </div>
    </div>
    <!--PREGUNTA-->
    <div class="questionsBox row">
        <div class="col-md-1">
            <div class="imgUser">
                <img class="img-responsive" src="Content/img/imagUser.jpg" />
            </div>
            <div class="text-center">Luke Skywalker</div>
        </div>
        <div class="col-md-11">
            <div class="label simple-label">02-03-2018</div>
            <div class="label simple-label">Categoria/Tema </div>
            <a href="">
                <h3 class="titQuestion">¿Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin accumsan in libero eu fermentum. ?</h3>
            </a>

            <p class="descQuestion">Vivamus mollis luctus diam non efficitur. Proin et ultrices tortor, eu dictum tellus. Pellentesque aliquam vestibulum erat, sed lacinia lorem tempus quis.</p>
            <div class="optionsBtn">
                <div class="btn btn-primary"><span class="glyphicon glyphicon-share-alt"></span>Responder</div>
                <div class="btn btn-default"><span class="glyphicon glyphicon-plus"></span>Ver Respuestas</div>
            </div>

        </div>
    </div>
    <!--PREGUNTA-->
    <div class="questionsBox row">
        <div class="col-md-1">
            <div class="imgUser">
                <img class="img-responsive" src="Content/img/imagUser.jpg" />
            </div>
            <div class="text-center">Luke Skywalker</div>
        </div>
        <div class="col-md-11">
            <div class="label simple-label">02-03-2018</div>
            <div class="label simple-label">Categoria/Tema </div>
            <a href="">
                <h3 class="titQuestion">¿Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin accumsan in libero eu fermentum. ?</h3>
            </a>

            <p class="descQuestion">Vivamus mollis luctus diam non efficitur. Proin et ultrices tortor, eu dictum tellus. Pellentesque aliquam vestibulum erat, sed lacinia lorem tempus quis.</p>
            <div class="optionsBtn">
                <div class="btn btn-primary"><span class="glyphicon glyphicon-share-alt"></span>Responder</div>
                <div class="btn btn-default"><span class="glyphicon glyphicon-plus"></span>Ver Respuestas</div>
            </div>

        </div>
    </div>
</div>


<div class="container">
    <input type="hidden" id="hdIdUsuario" runat="server" value="" />
    <h1>Creación de Foro</h1>
    <div class="form-group">
        <label for="txtTema" class="required">Tema</label>
        <input type="text" class="form-control" id="txtTema">
        <div id="error_txtTema" class="alert alert-danger alert-dismissible" hidden="hidden">Tema no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtDescripcion" class="required">Descripción</label>
        <input type="text" class="form-control" id="txtDescripcion">
        <div id="error_txtDescripcion" class="alert alert-danger alert-dismissible" hidden="hidden">Descripción no puede ser vacía</div>
    </div>
    <div class="form-group">
        <label for="txtMensaje" class="required">Mensaje</label>
        <input type="text" class="form-control" id="txtMensaje">
        <div id="error_txtMensaje" class="alert alert-danger alert-dismissible" hidden="hidden">Mensaje no puede ser vacío</div>
    </div>

    <!--BOTONERA-->
    <div class="botonera text-center">
        <div class="btn btn-primary"><a id="btnCrearForo" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
    </div>
</div>
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("../../Scripts/ComunicacionFunciones.js", function () {
            $.getScript("../../Scripts/ComunicacionAcciones.js", function () {
            });
        });
    }));
</script>
