<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluarExperiencia.aspx.cs" Inherits="AuditoriasCiudadanas.Views.AudienciasPublicas.EvaluarExperiencia" %>

<div class="container">
    <h1 class="text-center">Evalúa tu experiencia</h1>
    	<div class="w60 center-block">

        <div class="well">
            <p>Esta evaluación está disponible en el aplicativo de la auditorías ciudadanas una vez se han finalizado cada una de las audiencias públicas del proyecto. Los ciudadanos son quienes deben evaluarla a partir de su experiencia.  </p>
        </div>
        <form id="form1" runat="server">
            <div class="well">
                <div class="row">
                    <div class="col-sm-12 singleChoise">
                    <input type="hidden" id="hfidAudiencia" runat="server" value=""/>
                    <input type="hidden" id="hfidUsuario" runat="server" value=""/>
                        <label for="lbTemasTratados"><h4>¿Los temas que fueron tratados en la audiencia (inicio, seguimiento, cierre) fueron los necesarios para cumplir con los objetivos trazados?</h4></label>
                        <select id="selTemasTratados" class="form-control">
                            <option>Si</option>
                            <option>No</option>
                        </select>
                        <input id="txtTemasTratados" type="text" class="form-control" onkeydown="CambioTextoExperiencia('errorTemasTratados')" placeholder="¿Por qué?"/>
                        <div id="errorTemasTratados" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese el porqué de su respuesta. Este campo es requerido.</div>
                    </div>
                </div>
            </div>
        <div class="well">
        <p> Evalúe las siguientes preguntas de 1 a 5, siendo cinco la mayor calificación y uno la menor:</p>
                <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>¿La convocatoria a la Audiencia Pública fue adecuada?</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="hfResPreg1" runat="server" value=""/>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p1', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="AsignarRespuesta('p1', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p1', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p1', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p1', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_p1" type="text" class="form-control" onkeydown="CambioTextoExperiencia('errResPreg1')" placeholder="¿Por qué?"  hidden="hidden" />
                <%--<textarea class="form-control" rows="3" id="txt_p1" style="display:none" onkeydown="CambioTextoExperiencia('errResPreg1')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errResPreg1" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
                <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>¿El acceso y actualización de la información se realizó de manera adecuada?</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="hfResPreg2" runat="server" value=""/>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p2', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="AsignarRespuesta('p2', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p2', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p2', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p2', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_p2" type="text" class="form-control" onkeydown="CambioTextoExperiencia('errResPreg2')" placeholder="¿Por qué?"  hidden="hidden" />
                <%--<textarea class="form-control" rows="3" id="txt_p2" style="display:none" onkeydown="CambioTextoExperiencia('errResPreg2')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errResPreg2" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
                <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>¿La Audiencia se desarrolló de manera adecuada?</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="hfResPreg3" runat="server" value=""/>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p3', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="AsignarRespuesta('p3', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p3', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p3', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p3', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_p3" type="text" class="form-control" onkeydown="CambioTextoExperiencia('errResPreg2')" placeholder="¿Por qué?"  hidden="hidden" />
                <%--<textarea class="form-control" rows="3" id="txt_p3" style="display:none" onkeydown="CambioTextoExperiencia('errResPreg3')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errResPreg3" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
               </div>

        <div class="well">
            <p> Cómo fue la relación entre la ciudadanía y los siguientes actores institucionales:</p>
            <div class="row">
                    <div class="col-sm-12 singleChoise">
                        <label for="lbEntidadEjecutora"><h4>Entidad Ejecutora:</h4></label>
                        <select id="selEntidadEjecutora" class="form-control">
                            <option>Excelente</option>
                            <option>Buena</option>
                            <option>Regular</option>
                            <option>Mala</option>
                        </select>
                    </div>
             </div>
            <div class="row">
                    <div class="col-sm-12 singleChoise">
                        <label for="lbSupervisor"><h4>Supervisor:</h4></label>
                        <select id="selSupervisor" class="form-control">
                            <option>Excelente</option>
                            <option>Buena</option>
                            <option>Regular</option>
                            <option>Mala</option>
                        </select>
                    </div>
             </div>
            <div class="row">
                    <div class="col-sm-12 singleChoise">
                        <label for="lbInterventor"><h4>Interventor:</h4></label>
                        <select id="selInterventor" class="form-control">
                            <option>Excelente</option>
                            <option>Buena</option>
                            <option>Regular</option>
                            <option>Mala</option>
                        </select>
                    </div>
             </div>
            <div class="row">
                    <div class="col-sm-12 singleChoise">
                        <label for="lbContratista"><h4>Contratista:</h4></label>
                        <select id="selContratista" class="form-control">
                            <option>Excelente</option>
                            <option>Buena</option>
                            <option>Regular</option>
                            <option>Mala</option>
                        </select>
                    </div>
             </div>
        </div>
        <div class="well">
            <div class="row">
                    <div class="col-sm-12 singleChoise">
                        <label for="lbDestacarAP"><h4>¿Qué aspectos le gustaría destacar de la audiencia pública?</h4></label>
                        <input id="txtDestacarAP" type="text" class="form-control" onkeydown="CambioTextoExperiencia('errorDestacarAP')" placeholder="Por favor ingrese su respuesta"/>
                        <div id="errorDestacarAP" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese su respuesta. Este campo es requerido.</div>
                    </div>
             </div>
        </div>
        <div class="well">
            <div class="row">
                    <div class="col-sm-12 singleChoise">
                        <label for="lbAccionesMejora"><h4>Cree que se deben mejorar aspectos en la realización de una próxima audiencia pública.</h4></label>
                        <select id="selAccionesMejora" class="form-control" onchange="SeleccionarItemExperiencia('AccionesMejora')">
                            <option>Si, ¿Cuáles?</option>
                            <option>No</option>
                        </select>
                        <input id="txtAccionesMejora" type="text" class="form-control" onkeydown="CambioTextoExperiencia('errorAccionesMejora')" placeholder="Por favor describa cuales"/>
                        <div id="errorAccionesMejora" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese su respuesta. Este campo es requerido.</div>
                    </div>
             </div>
        </div>
        </form>
        <!--BOTONERA-->
             <div class="botonera text-center">
              	<div class="btn btn-primary" onclick="GuardarExperiencia()"><a href="#"><span class="glyphicon glyphicon-ok-sign"></span> EVALUAR</a></div>
                <%--<div class="btn btn-primary" onclick="GuardarExperiencia()"><span class="glyphicon glyphicon-ok-sign"></span> EVALUAR</div>--%>
             </div>
        </div>
    </div>
    <script type="text/javascript">
    $(document).ready(function () {
        InicializarCajasTextoEvaluarExperiencia();
    });
</script>
