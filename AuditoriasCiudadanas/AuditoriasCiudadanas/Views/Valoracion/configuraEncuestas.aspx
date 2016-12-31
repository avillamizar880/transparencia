<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="configuraEncuestas.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Valoracion.configuraEncuestas" %>
   <div class="container encuestaView">
       <h1 class="text-center">Generar Evaluación Posterior</h1>
       <p>Aenean nunc nunc, tempus in arcu consequat, finibus tempor lectus. Nam interdum pharetra nisl, in eleifend sem mollis eu. Aliquam congue sagittis velit ut finibus. Aliquam velit purus, dictum a laoreet vitae, aliquet ut eros. Nullam laoreet, erat nec rutrum hendrerit, metus ante finibus justo, ac maximus velit arcu sed nibh.</p>
       <div class="center-block w60">
           <form>
               <div class="well">
                   <div class="form-group">
                       <label for="txtTitulo">Título Cuestionario</label>
                       <input type="text" class="form-control" id="txtTitulo">
                   </div>
                   <div class="form-group">
                       <label for="txtDescripcion">Descripción</label>
                       <input type="text" class="form-control" id="txtDescripcion">
                   </div>
               </div>
               <a class="btn btn-default" id="btnAddPregunta" role="button"><span class="glyphicon glyphicon-plus"></span>Nueva Pregunta</a>
           </form>
        </div>
        <div class="center-block hideObj" id="divContenedorPreguntas">
        <div class="card">
            <div class="card-block">
                <h2 class="card-title">Opciones de Respuestas</h2>
            </div>
            <div class="card-block">
                <div class="form-group">
                    <label for="nombre1">Título de pregunta</label>
                    <input type="text" class="form-control" id="txtTituloPreg">
                    <div class="form-group">
                        <label for="q2">Texto de Ayuda</label>
                        <input type="text" class="form-control" id="txtAyuda">
                    </div>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input type="checkbox" class="form-check-input" id="chkObligatoria">
                            <span>¿Pregunta Obligatoria?</span>
                        </label>
                    </div>
                    <div class="form-group">
                        <label for="ddlTipoPregunta">Tipo de Pregunta</label>
                        <select class="form-control" id="ddlTipoPregunta">
                            <option value="">[Seleccione un tipo de Pregunta]</option>
                            <option value="1">Única Respuesta</option>
                            <option value="2">Única Selección</option>
                            <option value="3">Seleccion Multiple</option>
                            <option value="4">Párrafo</option>
                            <option value="5">Escala</option>
                            <option value="6">Fecha</option>
                            <option value="7">Tiempo</option>
                        </select>
                    </div>
                    <!--AQUI SE LISTARÁN TODAS LAS POSIBLES OPCIONES DE rESPUESTA-->
                    <!--TIPO 1 - SIMPLE TEXT-->
                    <div class="form-group well hideObj" id="divPregTexto">
                        <div class="form-group">
                            <input type="text" class="form-control" id="texto" placeholder="su respuesta">
                        </div>
                        <h3>Configuración</h3>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" class="form-check-input">
                                <span>Validar Datos</span>
                            </label>
                        </div>
                        <!--OPCIONES DE CONFIGURACIÓN T1-->
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-2">
                                    <label for="q4" class="hidden">Numero</label>
                                    <select class="form-control" id="q4">
                                        <option>Numero</option>
                                        <option>Opcion 2</option>
                                        <option>Opcion 3</option>
                                    </select>
                                </div>
                                <div class="col-sm-2">
                                    <label for="q4" class="hidden">Mayor que</label>
                                    <select class="form-control" id="q4">
                                        <option>Numero</option>
                                        <option>Opcion 2</option>
                                        <option>Opcion 3</option>
                                    </select>
                                </div>
                                <div class="col-sm-2">
                                    <label for="q4" class="hidden">Numero</label>
                                    <select class="form-control" id="q4">
                                        <option>Numero</option>
                                        <option>Opcion 2</option>
                                        <option>Opcion 3</option>
                                    </select>
                                </div>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control" id="texto" placeholder="Texto para campo equivocado">
                                </div>

                            </div>
                        </div>
                    </div>
                    <!-- TIPO 2 - RADIO-->
                    <div class="form-group well hideObj" id="divPregRadio">
                        <form>
                            <div class="w60 center-block">
                                <div class="row">
                                    <div class="col-sm-1">
                                        <label class="form-check-label">
                                            <input type="radio" class="form-check-input"></label></div>
                                    <div class="col-sm-11">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="texto" placeholder="Opcion de Respuesta 1"></div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-1">
                                        <label class="form-check-label">
                                            <input type="radio" class="form-check-input"></label></div>
                                    <div class="col-sm-11">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="texto" placeholder="Opcion de Respuesta 1"></div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-1">
                                        <label class="form-check-label">
                                            <input type="radio" class="form-check-input"></label></div>
                                    <div class="col-sm-11">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="texto" placeholder="Otro"></div>
                                    </div>
                                </div>
                                <div class="row text-center mb15">
                                    <a role="button" class="btn btn-default"><span class="glyphicon glyphicon-plus"></span>Agregar opción</a>
                                </div>
                            </div>
                        </form>
                        <!--OPCIONES DE CONFIGURACIÓN T2-->
                        <h3>Configuración</h3>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" class="form-check-input">
                                Alternar orden
                            </label>
                        </div>
                    </div>
                    <!--TIPO 3 - CHECKBOXES-->
                    <div class="well hideObj" id="divPregCheckbox">
                        <form>
                            <div class="w60 center-block">
                                <div class="row">
                                    <div class="col-sm-1">
                                        <label class="form-check-label">
                                            <input type="checkbox" class="form-check-input"></label>
                                    </div>
                                    <div class="col-sm-11">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="texto" placeholder="Opcion de Respuesta 1">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-1">
                                        <label class="form-check-label">
                                            <input type="checkbox" class="form-check-input"></label>
                                    </div>
                                    <div class="col-sm-11">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="texto" placeholder="Opcion de Respuesta 1">
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-1">
                                        <label class="form-check-label">
                                            <input type="checkbox" class="form-check-input"></label>
                                    </div>
                                    <div class="col-sm-11">
                                        <div class="form-group">
                                            <input type="text" class="form-control" id="texto" placeholder="Otro">
                                        </div>
                                    </div>
                                </div>
                                <div class="row text-center mb15">
                                    <a role="button" class="btn btn-default"><span class="glyphicon glyphicon-plus"></span>Agregar opción</a>
                                </div>
                            </div>
                        </form>
                        <!--OPCIONES DE CONFIGURACIÓN T3-->
                        <h3>Configuración</h3>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" class="form-check-input">
                                <span>Validar Datos</span>
                            </label>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-2">
                                    <label for="q4" class="hidden">Numero</label>
                                    <select class="form-control" id="q4">
                                        <option>Numero</option>
                                        <option>Opcion 2</option>
                                        <option>Opcion 3</option>
                                    </select>
                                </div>
                                <div class="col-sm-2">
                                    <label for="q4" class="hidden">Mayor que</label>
                                    <select class="form-control" id="q4">
                                        <option>Numero</option>
                                        <option>Opcion 2</option>
                                        <option>Opcion 3</option>
                                    </select>
                                </div>
                                <div class="col-sm-2">
                                    <label for="q4" class="hidden">Numero</label>
                                    <select class="form-control" id="q4">
                                        <option>Numero</option>
                                        <option>Opcion 2</option>
                                        <option>Opcion 3</option>
                                    </select>
                                </div>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control" id="texto" placeholder="Texto para campo equivocado">
                                </div>

                            </div>
                        </div>
                    </div>
                    <!--TIPO 4 - TEXTAREA-->
                    <div class="well hideObj" id="divPregTextArea">
                        <form>
                            <div class="w60 center-block">
                                <label for="longAnswer"></label>
                                <textarea rows="5" id="longAnswer" class="form-control"></textarea>
                            </div>
                        </form>
                        <!--OPCIONES DE CONFIGURACIÓN T4-->
                        <h3>Configuración</h3>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" class="form-check-input">
                                <span>Validar Datos</span>
                            </label>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-2">
                                    <label for="q4" class="hidden">Largo</label>
                                    <select class="form-control" id="q4">
                                        <option>Largo</option>
                                        <option>Opcion 2</option>
                                        <option>Opcion 3</option>
                                    </select>
                                </div>
                                <div class="col-sm-2">
                                    <label for="q4" class="hidden">Numero mínimo de caracteres</label>
                                    <select class="form-control" id="q4">
                                        <option>Numero Mínimo de caracteres</option>
                                        <option>Opcion 2</option>
                                        <option>Opcion 3</option>
                                    </select>
                                </div>
                                <div class="col-sm-2">
                                    <label for="q4" class="hidden">Numero</label>
                                    <select class="form-control" id="q4">
                                        <option>Numero</option>
                                        <option>Opcion 2</option>
                                        <option>Opcion 3</option>
                                    </select>
                                </div>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control" id="texto" placeholder="Texto para campo equivocado">
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--TIPO 5 - ESCALA-->
                    <div class="well hideObj" id="divPregEscala">
                        <form>
                            <div class="w60 center-block">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label for="q10" class="hidden">Valor inicial</label>
                                            <select class="form-control" id="q10">
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label for="q10" class="hidden">Valor inicial</label>
                                            <select class="form-control" id="q10">
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <h4>Etiquetas opcionales</h4>

                                <div class="input-group mb15">
                                    <span class="input-group-addon">1</span>
                                    <input type="text" class="form-control" aria-label="Etiqueta opcional 1">
                                </div>


                                <div class="input-group">
                                    <span class="input-group-addon">5</span>
                                    <input type="text" class="form-control" aria-label="Etiqueta opcional 5">
                                </div>

                            </div>
                        </form>
                        <!--OPCIONES DE CONFIGURACIÓN T5-->
                        <h3>Configuración</h3>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" class="form-check-input">
                                <span>Validar Datos</span>
                            </label>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-2">
                                    <label for="q4" class="hidden">Largo</label>
                                    <select class="form-control" id="q4">
                                        <option>Largo</option>
                                        <option>Opcion 2</option>
                                        <option>Opcion 3</option>
                                    </select>
                                </div>
                                <div class="col-sm-2">
                                    <label for="q4" class="hidden">Numero mínimo de caracteres</label>
                                    <select class="form-control" id="q4">
                                        <option>Numero Mínimo de caracteres</option>
                                        <option>Opcion 2</option>
                                        <option>Opcion 3</option>
                                    </select>
                                </div>
                                <div class="col-sm-2">
                                    <label for="q4" class="hidden">Numero</label>
                                    <select class="form-control" id="q4">
                                        <option>Numero</option>
                                        <option>Opcion 2</option>
                                        <option>Opcion 3</option>
                                    </select>
                                </div>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control" id="texto" placeholder="Texto para campo equivocado">
                                </div>

                            </div>
                        </div>
                    </div>

                    <!--TIPO 6 - FECHA-->
                    <div class="well hideObj" id="divPregFecha">
                        <form>
                            <div class="w60 center-block">
                            </div>
                        </form>
                        <!--OPCIONES DE CONFIGURACIÓN T5-->
                        <h3>Configuración</h3>
                        <div class="row">
                            <div class="form-check col-sm-2">
                                <label class="form-check-label">
                                    <input type="checkbox" class="form-check-input">
                                    <span>Incluir Año</span>
                                </label>
                            </div>
                            <div class="form-check col-sm-2">
                                <label class="form-check-label">
                                    <input type="checkbox" class="form-check-input">
                                    <span>Incluir Hora</span>
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="example-date-input" class="col-xs-2 col-form-label">Fecha</label>
                                        <div class="col-xs-12">
                                            <input class="form-control" type="date" value="2011-08-19" id="example-date-input">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="example-time-input" class="col-xs-2 col-form-label">Hora</label>
                                        <div class="col-xs-12">
                                            <input class="form-control" type="time" value="13:45:00" id="example-time-input">
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <!--TIPO 7 - FECHA-->
                    <div class="well hideObj" id="divPregTiempo">
                        <form>
                            <div class="w60 center-block">
                            </div>
                        </form>
                        <!--OPCIONES DE CONFIGURACIÓN T5-->
                        <h3>Configuración</h3>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" class="form-check-input">
                                <span>Duración</span>
                            </label>
                        </div>
                        <div class="form-group">
                            <div class="row">

                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="example-time-input" class="col-xs-2 col-form-label">Hora</label>
                                        <div class="col-xs-12">
                                            <input class="form-control" type="time" value="13:45:00" id="example-time-input">
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
             <div class="botonera text-center">
                <div class="btn btn-primary"><a href=""><span class="glyphicon glyphicon-check"></span>Registrar</a></div>
            </div>
         </div>

        </div>
    </div>
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("../../Scripts/ConfigEncuestasFunciones.js", function () {
        $.getScript("../../Scripts/ConfigEncuestasAcciones.js", function () {

    });
    });
    }));
</script>
