<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="configuraEncuestas.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Valoracion.configuraEncuestas" %>
<div class="container" id="divGeneralPag">
    <input type="hidden" id="hdIdCuestionario" value="" runat="server" />
    <input type="hidden" id="hdIdUsuario" value="" runat="server" />
    <input type="hidden" id="hdIdPregunta" value="" runat="server" />
    <input type="hidden" id="hdTipoCuestionario" value="" runat="server" />
    <input type="hidden" id="hdOpcion" value="" runat="server" />
    <div id="divEncabezado" runat="server">
        <h1 id="hTitulo" class="text-center"></h1>
        <p>Mediante este formulario configure Encabezado y preguntas del Cuestionario</p>
    </div>
    
    <div class="center-block w60" id="divContenedorTitulo">
        <div class="well">
            <div class="form-group hideObj">
                <label for="ddlTipoCuestionario" class="required">Tipo Cuestionario</label>
                <asp:dropdownlist id="ddlTipoCuestionario" class="form-control" runat="server" datatextfield="nomTipoCuestionario" datavaluefield="idTipoCuestionario" tooltip="[--Tipo Cuestionario--]">
                 </asp:dropdownlist>
                <div id="error_ddlTipoCuestionario" class="alert alert-danger alert-dismissible" hidden="hidden">Tipo cuestionario no puede ser vacío</div>
            </div>
            <div class="form-group">
                <label for="txtTitulo" class="required">Título Cuestionario</label>
                <input type="text" class="form-control" id="txtTitulo">
                <div id="help_txtTitulo" class="explica alert-warning">Este será el título del cuestionario</div>
                <div id="error_txtTitulo" class="alert alert-danger alert-dismissible" hidden="hidden">Título no puede ser vacío</div>
            </div>
            <div class="form-group">
                <label for="txtDescripcion" class="required">Descripción</label>
                <input type="text" class="form-control" id="txtDescripcion" />
                <div id="error_txtDescripcion" class="alert alert-danger alert-dismissible" hidden="hidden">Descripción no puede ser vacía</div>
                <div id="help_txtDescripcion" class="explica alert-warning">Escriba una breve descripción que oriente a quien responderá, sobre el contenido del cuestionario</div>
            </div>
        </div>
        <div class="botonera text-right">
            <div class="btn btn-primary" id="divCrearCuestionario"><a id="btnCrearCuestionario"><span class="glyphicon glyphicon-open-file"></span> Crear</a></div>
            <div class="btn btn-primary" id="divEditarCuestionario"><a id="btnEditarCuestionario"><span class="glyphicon glyphicon-edit"></span> Editar</a></div>
            <div class="btn btn-primary" id="divModificarCuestionario"><a id="btnModificarCuestionario"><span class="glyphicon glyphicon-edit"></span> Guardar</a></div>
            <div class="btn btn-primary" id="divObtCuestionario"><a id="btnObtCuestionario"><span class="glyphicon glyphicon-eye-open"></span> Ver</a></div>
            <div class="btn btn-primary" id="divGenAyuda"><a id="btnGenAyuda"><span class="glyphicon glyphicon-check"></span> Responder</a></div>
        </div>
        <div id="divNuevaPregunta" class="hideObj">
            <a class="btn btn-default" role="button" id="btnAddPregunta"><span class="glyphicon glyphicon-plus"></span>Nueva Pregunta</a>
        </div>
    </div>
    <div class="container encuestaView">
        <div class="center-block hideObj" id="divContenedorPreguntas">
            <div class="card">
                <div class="card-block">
                    <h2 class="card-title">Configure la pregunta</h2>
                </div>
                <div class="card-block">
                    <div class="form-group">
                        <label for="txtTituloPreg" class="required">Texto de pregunta</label>
                        <div id="help_txtTituloPreg" class="explica alert-warning">Escriba aquí la pregunta</div>
                        <input type="text" class="form-control" id="txtTituloPreg">
                        <div id="error_txtTituloPreg" class="alert alert-danger alert-dismissible" hidden="hidden">Título pregunta no puede ser vacío</div>
                    </div>
                    <div class="form-group">
                        <label for="txtAyuda">Texto de Ayuda</label>
                        <div id="help_txtAyuda" class="explica alert-warning">Este texto aparecerá al usuario como guía u orientación al momento de responder la pregunta, es opcional</div>
                        <input type="text" class="form-control" id="txtAyuda">
                        <div id="error_txtAyuda" class="alert alert-danger alert-dismissible" hidden="hidden">Texto de ayuda no puede ser vacío</div>
                    </div>
                    <div class="form-check">
                        <label class="form-check-label">
                            <input type="checkbox" class="form-check-input" id="chkObligatoria">
                            <span>¿Pregunta Obligatoria?</span>
                        </label>
                         <div id="help_chkObligatoria" class="explica alert-warning">Chequee esta opción cuando desee que la pregunta sea obligatoria para quien responderá el cuestionario</div>
                    </div>
                    <div class="form-group">
                        <label for="ddlTipoPregunta" class="required">Tipo de Respuesta</label>
                        <div id="help_ddlTipoPregunta" class="explica alert-warning">Seleccione el tipo de respuesta que espera para su pregunta</div>
                        <select class="form-control" id="ddlTipoPregunta">
                            <option value="">[Seleccione un tipo de Respuesta]</option>
                            <option value="1">Única Respuesta</option>
                            <option value="2">Única Selección</option>
                            <option value="3">Seleccion Multiple</option>
                            <option value="4">Párrafo</option>
                            <option value="5">Escala</option>
                            <option value="6">Fecha</option>
                            <option value="7">Tiempo</option>
                        </select>
                        <div id="error_ddlTipoPregunta" class="alert alert-danger alert-dismissible" hidden="hidden">Tipo pregunta no puede ser vacía</div>
                        <div id="help_ddlTipoPregunta_aux" class="explica alert-warning"></div>

                    </div>
                    <!--AQUI SE LISTARÁN TODAS LAS POSIBLES OPCIONES DE rESPUESTA-->
                    <!--TIPO 1 - SIMPLE TEXT-->

                    <div class="form-group well hideObj" id="divPregTexto">
                        <div class="w60 left-block">
                            <label for="txtRespuestaCorta"></label>
                            <input type="text" id="txtRespuestaCorta" class="form-control" placeholder="Texto respuesta" readonly />
                        </div>
                        <h3>Configuración Avanzada</h3>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" id="chkValidaDatosTexto" class="form-check-input">
                                <span>Validar Datos</span>
                            </label>
                            <div id="help_chkValidaDatosTexto" class="explica alert-warning">Seleccione si desea que la respuesta tenga alguna validación, por ejemplo que solo puedan escribir números, etc.</div>
                        </div>
                        <!--OPCIONES DE CONFIGURACIÓN T1-->
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-2">
                                    <label for="ddlTipo_validacion_dato" class="hidden">Tipo Validación</label>
                                    <select class="form-control" id="ddlTipo_validacion_dato">
                                        <option value="">[Tipo Validación]</option>
                                        <option value="1">Número</option>
                                        <option value="2">Alfabético</option>
                                        <option value="3">Alfanumérico</option>
                                        <option value="4">Número Positivo</option>
                                        <option value="5">Número Negativo</option>
                                    </select>
                                    <div id="error_ddlTipo_validacion_dato" class="alert alert-danger alert-dismissible" hidden="hidden">Tipo validación no puede ser vacío</div>
                                </div>
                                <div class="col-sm-2">
                                    <label for="ddlTextoLimite" class="hidden">Numero</label>
                                    <select class="form-control" id="ddlTextoLimite">
                                        <option value="">[Tipo Límite]</option>
                                        <option value="6">Menor que</option>
                                        <option value="7">Menor o igual que</option>
                                        <option value="8">Mayor que</option>
                                        <option value="9">Mayor o igual que</option>
                                        <option value="10">Diferente a</option>
                                        <option value="11">Entre _ y _</option>
                                        <option value="12">No esté entre _ y _</option>
                                    </select>
                                    <div id="help_ddlTextoLimite" class="explica alert-warning">En caso que la respuesta solo sea número, puede agregar una validación más avanzada.</div>
                                </div>
                                <div class="col-sm-1">
                                    <input type="text" class="form-control" id="txtLimiteValor" placeholder="Valor" />
                                    <div id="error_txtLimiteValor" class="alert alert-danger alert-dismissible" hidden="hidden">Valor límite no puede ser vacío</div>
                                </div>
                                <div class="col-sm-1 hideObj" id="divLimiteFinal">
                                    <input type="text" class="form-control" id="txtLimiteValor_final" placeholder="Valor" />
                                    <div id="error_txtLimiteValor_final" class="alert alert-danger alert-dismissible" hidden="hidden">Valor límite final no puede ser vacío</div>
                                </div>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control" id="txtCampoEquivocado" placeholder="Texto para campo no válido">
                                     <div id="help_txtCampoEquivocado" class="explica alert-warning">Escriba aquí el texto que desea mostrar al usuario cuando responda con un dato no permitido</div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- TIPO 2 - RADIO-->
                    <div class="form-group well hideObj" id="divPregRadio">
                        <div class="w60 center-block">
                            <div id="divPregUnicaRespuesta">
                                <div class="row preg_radio">
                                    <div class="col-sm-1">
                                        <label class="form-check-label">
                                            <input type="radio" class="form-check-input"></label>
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="form-group required">
                                            <input type="text" class="form-control" id="r_respuesta_1" placeholder="Opcion de Respuesta 1">
                                        </div>
                                    </div>

                                </div>
                                <div class="row preg_radio">
                                    <div class="col-sm-1">
                                        <label class="form-check-label">
                                            <input type="radio" class="form-check-input"></label>
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="form-group required">
                                            <input type="text" class="form-control" id="r_respuesta_2" placeholder="Opcion de Respuesta 2">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="error_divPregUnicaRespuesta" class="alert alert-danger alert-dismissible" hidden="hidden">Opciones de respuesta no pueden ser vacías</div>
                            <div class="row text-center mb15">
                                <a role="button" id="btnAgregarRadio" class="btn btn-default"><span class="glyphicon glyphicon-plus"></span>Agregar opción</a>
                            </div>
                        </div>
                        <!--OPCIONES DE CONFIGURACIÓN T2-->
                        <%--<h3>Configuración</h3>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" class="form-check-input">
                                Alternar orden
                            </label>
                        </div>--%>
                    </div>
                    <!--TIPO 3 - CHECKBOXES-->
                    <div class="well hideObj" id="divPregCheckbox">
                        <div class="w60 center-block">
                            <div id="divPregMultipleRespuesta">
                                <div class="row preg_check">
                                    <div class="col-sm-1">
                                        <label class="form-check-label">
                                            <input type="checkbox" class="form-check-input"></label>
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="form-group required">
                                            <input type="text" class="form-control" id="chk_respuesta_1" placeholder="Opcion de Respuesta 1">
                                        </div>
                                    </div>
                                </div>
                                <div class="row preg_check">
                                    <div class="col-sm-1">
                                        <label class="form-check-label">
                                            <input type="checkbox" class="form-check-input"></label>
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="form-group required">
                                            <input type="text" class="form-control" id="chk_respuesta_2" placeholder="Opcion de Respuesta 2">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="error_divPregMultipleRespuesta" class="alert alert-danger alert-dismissible" hidden="hidden">Opciones de respuesta no pueden ser vacías</div>
                            <div class="row text-center mb15">
                                <a role="button" id="btnAgregarCheck" class="btn btn-default"><span class="glyphicon glyphicon-plus"></span>Agregar opción</a>
                            </div>
                        </div>
                        <!--OPCIONES DE CONFIGURACIÓN T3-->
                        <h3>Configuración</h3>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" id="chkValidaDatosCheck" class="form-check-input">
                                <span>Validar Datos</span>
                            </label>
                            <div id="help_chkValidaDatosCheck" class="explica alert-warning">Seleccione si desea validar la cantidad de respuestas dadas por el usuario</div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-2">
                                    <label for="ddlCantidadCheckValida" class="hidden">Cantidad</label>
                                    <select class="form-control" id="ddlCantidadCheckValida">
                                        <option value="">[Tipo Validación]</option>
                                        <option value="13">Seleccionar al menos</option>
                                        <option value="14">Seleccionar máximo</option>
                                    </select>
                                    <div id="error_ddlCantidadCheckValida" class="alert alert-danger alert-dismissible" hidden="hidden">Tipo validación no puede ser vacío</div>
                                     <div id="help_ddlCantidadCheckValida" class="explica alert-warning">En caso que la respuesta se desee validar, puede condicionar la cantidad de respuestas</div>
                                </div>
                                <div class="col-sm-2">
                                    <input type="text" class="form-control" id="txtLimiteCheck" placeholder="Número límite" />
                                    <div id="error_txtLimiteCheck" class="alert alert-danger alert-dismissible" hidden="hidden">Valor límite no puede ser vacío</div>
                                </div>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control" id="txtCampoEquivocadoCheck" placeholder="Texto para campo equivocado">
                                    <div id="help_txtCampoEquivocadoCheck" class="explica alert-warning">Escriba aquí el texto que desea mostrar al usuario cuando responda con un dato no permitido</div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--TIPO 4 - TEXTAREA-->
                    <div class="well hideObj" id="divPregTextArea">
                        <div class="w60 center-block">
                            <label for="longAnswer"></label>
                            <textarea rows="5" id="longAnswer" class="form-control" placeholder="Texto respuesta" readonly></textarea>
                        </div>

                        <!--OPCIONES DE CONFIGURACIÓN T4-->
                        <h3>Configuración</h3>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" class="form-check-input" id="chkValidaDatosParrafo">
                                <span>Validar Datos</span>
                            </label>
                            <div id="help_chkValidaDatosParrafo" class="explica alert-warning">En caso que la respuesta se desee validar, puede condicionar la cantidad de letras permitidas</div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-2">
                                    <label for="ddlValidaLongitud" class="hidden">Longitud</label>
                                    <select class="form-control" id="ddlValidaLongitud">
                                        <option value="">[Tipo validación]</option>
                                        <option value="15">Longitud mínima</option>
                                        <option value="16">Longitud máxima</option>
                                    </select>
                                    <div id="error_ddlValidaLongitud" class="alert alert-danger alert-dismissible" hidden="hidden">Tipo validación no puede ser vacía</div>
                                </div>
                                <div class="col-sm-2">
                                    <input type="text" class="form-control" id="txtLimiteParrafo" placeholder="Número límite" />
                                    <div id="error_txtLimiteParrafo" class="alert alert-danger alert-dismissible" hidden="hidden">Valor límite no puede ser vacío</div>
                                </div>
                                <div class="col-sm-6">
                                    <input type="text" class="form-control" id="txtCampoEquivocadoParrafo" placeholder="Texto para campo equivocado">
                                    <div id="help_txtCampoEquivocadoParrafo" class="explica alert-warning">Escriba aquí el texto que desea mostrar al usuario cuando responda con un dato no permitido</div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--TIPO 5 - ESCALA-->
                    <div class="well hideObj" id="divPregEscala">
                        <div class="w60 center-block">
                            <div class="row">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label for="ddlEscalaInicial" class="hidden">Valor inicial</label>
                                        <select class="form-control" id="ddlEscalaInicial" runat="server">
                                        </select>
                                    </div>
                                    <div id="help_ddlEscalaInicial" class="explica alert-warning">Valor inicial del rango</div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label for="ddlEscalaFinal" class="hidden">Valor final</label>
                                        <select class="form-control" id="ddlEscalaFinal" runat="server">
                                        </select>
                                    </div>
                                    <div id="help_ddlEscalaFinal" class="explica alert-warning">Valor máximo del rango</div>
                                </div>
                            </div>
                            <h4>Etiquetas opcionales</h4>
                            <div class="input-group mb15">
                                <span class="input-group-addon" id="spnEscalaInicial">1</span>
                                <input type="text" class="form-control" aria-label="Etiqueta opcional 1" id="txtEscalaInicial">
                            </div>
                            <div id="help_txtEscalaInicial" class="explica alert-warning">Texto que se mostrará para explicar que significa el valor inicial</div>
                            <div class="input-group">
                                <span class="input-group-addon" id="spnEscalaFinal">5</span>
                                <input type="text" class="form-control" aria-label="Etiqueta opcional 5" id="txtEscalaFinal">
                            </div>
                            <div id="help_txtEscalaFinal" class="explica alert-warning">Texto que se mostrará para explicar que significa el valor final</div>
                        </div>
                        <div id="error_divPregEscala" class="alert alert-danger alert-dismissible" hidden="hidden">Valor final debe ser mayor a valor inicial</div>
                    </div>
                    <!--TIPO 6 - FECHA-->
                    <div class="well hideObj" id="divPregFecha">
                        <div class="w60 center-block">
                        </div>
                        <!--OPCIONES DE CONFIGURACIÓN T5-->
                        <h3>Configuración</h3>
                        <div class="row">
                            <div class="form-check col-sm-2">
                                <label class="form-check-label">
                                    <input type="checkbox" class="form-check-input" id="chkIncluirAnyo">
                                    <span>Incluir Año</span>
                                </label>
                                <div id="help_chkIncluirAnyo" class="explica alert-warning">Seleccione si desea que la respuesta incluya formato de año [ejemplo:2017]</div>
                            </div>
                            <div class="form-check col-sm-2">
                                <label class="form-check-label">
                                    <input type="checkbox" class="form-check-input" id="chkIncluirHora">
                                    <span>Incluir Hora</span>
                                </label>
                                <div id="help_chkIncluirHora" class="explica alert-warning">Seleccione si desea que la respuesta incluya formato de hora [ejemplo: 09:35]</div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="txtFechaEjemplo" class="col-xs-2 col-form-label">Fecha</label>
                                        <div class="col-xs-12">
                                            <input class="form-control" type="date" value="08-01" id="txtFechaEjemplo" readonly>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 hideObj" id="divHoraPregFecha">
                                    <div class="form-group row">
                                        <label for="example-time-input" class="col-xs-2 col-form-label">Hora</label>
                                        <div class="col-xs-12">
                                            <input class="form-control" type="time" value="13:45" id="txtHora" readonly>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <!--TIPO 7 - HORA-->
                    <div class="well hideObj" id="divPregTiempo">
                        <div class="w60 center-block">
                        </div>

                        <!--OPCIONES DE CONFIGURACIÓN T5-->
                        <h3>Configuración</h3>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" class="form-check-input" id="chkTiempoDuracion">
                                <span>Duración</span>
                            </label>
                            <div id="help_textHoraDuracion" class="explica alert-warning">Seleccione si desea que la respuesta incluya hora minutos y segundos [ ejemplo 08:10:30 08 horas 10 minutos 30 segundos]</div>
                        </div>
                        <div class="form-group">
                            <div class="row">

                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="example-time-input" class="col-xs-2 col-form-label">Hora</label>
                                        <div class="col-xs-12">
                                            <input id="textHoraDuracion" class="form-control" type="time" value="12:05" readonly>

                                        </div>
                                        
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="botonera text-center">
                    <div class="btn btn-primary" id="divBtnCrearPregunta"><a role="button" id="btnCrearPregunta"><span class="glyphicon glyphicon-check"></span>Registrar</a></div>
                    <div class="btn btn-primary" id="divBtnModificarPregunta"><a role="button" id="btnModificarPregunta"><span class="glyphicon glyphicon-check"></span>Guardar</a></div>
                </div>
            </div>

        </div>
    </div>
</div>
<div id="divListadoPreguntas" runat="server" class="hideObj">
    <div class="btn btn-default mtB15">
        <a role="button" onclick="volverCuestionario();"><span class="glyphicon glyphicon-menu-left"></span>Volver al Cuestionario</a>
    </div>
    <div id="divPreliminarVista" runat="server">


    </div>
</div>

<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("../../Scripts/ConfigEncuestasFunciones.js", function () {
        $.getScript("../../Scripts/ConfigEncuestasAcciones.js", function () {
           $("#divEditarCuestionario").hide();
           $("#divModificarCuestionario").hide();
           $("#divBtnModificarPregunta").hide();
           $("#divGenAyuda").hide();
           $("#divObtCuestionario").show();
           inhabilitar_campos();
           var opcion_tipo = $("#hdOpcion").val();
           if (opcion_tipo == "2") {
              $("#hTitulo").html("Configuración Ayuda");
    } else if (opcion_tipo == "1") {
            $("#hTitulo").html("Evaluación posterior");
    } else {
         $("#hTitulo").html("Configuración Cuestionario");
    }
           if ($("#hdOpcion").val() != "") {
               $("#ddlTipoCuestionario").val(opcion_tipo);
               $("#ddlTipoCuestionario").attr("disabled", "disabled");
           }
    });
    })
        
    }));
</script>
