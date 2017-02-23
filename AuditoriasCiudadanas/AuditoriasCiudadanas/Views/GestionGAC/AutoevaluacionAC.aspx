<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutoevaluacionAC.aspx.cs" Inherits="AuditoriasCiudadanas.Views.GestionGAC.AutoevaluacionAC" %>

<div class="container">
    <h1 class="text-center">Autoevaluación de auditores ciudadanos</h1>
    	<div class="w60 center-block">
        <div class="well">
            <h4>Para tener en cuenta:</h4>
            <p>La autoevaluación está dirigida únicamente a auditores ciudadanos que estén ejerciendo su derecho a realizar control social a proyectos financiados por regalías. </p>
        </div>
    	<%--<form>--%>
        <div class="well">
        <p> Evalué de 1 a 5, siendo cinco la mayor calificación y uno la menor, su participación en el Grupo Auditor Ciudadano:</p>
                <div class="row">
                <div class="col-sm-12 singleChoise">
               <%-- <input type="hidden" id="AutoidAudiencia" runat="server" value=""/>--%>
                <input type="hidden" id="hfCodigoBPIN" runat="server" value=""/>
                <input type="hidden" id="hfidUsuario" runat="server" value=""/>
                <h4>A. Ha revisado de manera constante la información de su proyecto con el objetivo de actualizarse.</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="AcResPreg1" runat="server" value=""/>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p1', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="RespuestaAutoevaluacion('p1', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p1', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p1', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p1', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_Acp1" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errAcResPreg1')" placeholder="¿Porqué?" />
                <%--<textarea class="form-control" rows="3" id="txt_Acp1" style="display:none"  onkeydown="CambioTextoAutoevaluacion('errAcResPreg1')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errAcResPreg1" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
                <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>B. Ha sido respetuoso en el tratamiento con sus compañeros de Grupo Auditor y otros actores.</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="AcResPreg2" runat="server" value=""/>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p2', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="RespuestaAutoevaluacion('p2', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p2', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p2', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p2', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_Acp2" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errAcResPreg2')" placeholder="¿Porqué?" />
                <%--<textarea class="form-control" rows="3" id="txt_Acp2" style="display:none" onkeydown="CambioTextoAutoevaluacion('errAcResPreg2')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errAcResPreg2" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
                <div class="row">
                <div class="col-sm-12 singleChoise">
                <input type="hidden" id="AcResPreg3" runat="server" value=""/>
                <h4>C. Ha realizado sus tareas y compromisos con el fin de realizar su labor de control social adecuadamente.</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="Hidden4" runat="server" value=""/>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p3', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="RespuestaAutoevaluacion('p3', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p3', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p3', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p3', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_Acp3" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errAcResPreg3')" placeholder="¿Porqué?" />
                <%--<textarea class="form-control" rows="3" id="txt_Acp3" style="display:none" onkeydown="CambioTextoAutoevaluacion('errAcResPreg3')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errAcResPreg3" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
                  <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>D. Se capacita constantemente para tener las herramientas prácticas y enfrentar me mejor manera los desafíos.</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="AcResPreg4" runat="server" value=""/>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p4', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="RespuestaAutoevaluacion('p4', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p4', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p4', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p4', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_Acp4" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errAcResPreg4')" placeholder="¿Porqué?" />
                <%--<textarea class="form-control" rows="3" id="txt_Acp4" style="display:none" onkeydown="CambioTextoAutoevaluacion('errAcResPreg4')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errAcResPreg4" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
               </div>

        <div class="well">
        <p>Evalué de 1 a 5, siendo cinco la mayor calificación y uno la menor, la relación con actores del proyecto:</p>
                <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>i.	Fue pertinente y completa la información del proyecto.</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="AcResPreg5" runat="server" value=""/>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p5', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="RespuestaAutoevaluacion('p5', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p5', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p5', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p5', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_Acp5" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errAcResPreg5')" placeholder="¿Porqué?" />
                <%--<textarea class="form-control" rows="3" id="txt_Acp5" style="display:none" onkeydown="CambioTextoAutoevaluacion('errAcResPreg5')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errAcResPreg5" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
                <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>ii.	El trato y respuesta de la entidad ejecutora del proyecto.</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="AcResPreg6" runat="server" value=""/>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p6', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="RespuestaAutoevaluacion('p6', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p6', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p6', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p6', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_Acp6" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errAcResPreg6')" placeholder="¿Porqué?" />
                <%--<textarea class="form-control" rows="3" id="txt_Acp6" style="display:none" onkeydown="CambioTextoAutoevaluacion('errAcResPreg6')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errAcResPreg6" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
                <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>iii.	La comunicación y respuesta con el interventor.</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="AcResPreg7" runat="server" value=""/>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p7', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="RespuestaAutoevaluacion('p7', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p7', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p7', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p7', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_Acp7" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errAcResPreg7')" placeholder="¿Porqué?" />
                <%--<textarea class="form-control" rows="3" id="txt_Acp7" style="display:none" onkeydown="CambioTextoAutoevaluacion('errAcResPreg7')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errAcResPreg7" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
                  <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>iv.	El trato y respuesta del contratista ante las solicitudes presentadas.</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="AcResPreg8" runat="server" value=""/>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p8', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="RespuestaAutoevaluacion('p8', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p8', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p8', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p8', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_Acp8" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errAcResPreg8')" placeholder="¿Porqué?" />
                <%--<textarea class="form-control" rows="3" id="txt_Acp8" style="display:none" onkeydown="CambioTextoAutoevaluacion('errAcResPreg8')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errAcResPreg8" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
                 <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>v.	La convocatoria y realización de las Audiencia públicas.</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="AcResPreg9" runat="server" value=""/>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p9', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="RespuestaAutoevaluacion('p9', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p9', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p9', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p9', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_Acp9" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errAcResPreg9')" placeholder="¿Porqué?" />
                <%--<textarea class="form-control" rows="3" id="txt_Acp9" style="display:none" onkeydown="CambioTextoAutoevaluacion('errAcResPreg9')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errAcResPreg9" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
                  <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>vi.	Ánimo de la ciudadanía a participar en ejercicios de control social.</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="AcResPreg10" runat="server" value=""/>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p10', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="RespuestaAutoevaluacion('p10', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p10', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p10', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p10', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_Acp10" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errAcResPreg10')" placeholder="¿Porqué?" />
                <%--<textarea class="form-control" rows="3" id="txt_Acp10" style="display:none" onkeydown="CambioTextoAutoevaluacion('errAcResPreg10')" placeholder="¿Porqué?"></textarea>--%>
                <div id="errAcResPreg10" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>

                 <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>vii.	Contó con las condiciones de seguridad adecuadas para ejercer su labor veedora.</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="AcResPreg11" runat="server" value=""/>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p11', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="RespuestaAutoevaluacion('p11', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p11', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p11', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="RespuestaAutoevaluacion('p11', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <input id="txt_Acp11" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errAcResPreg11')" placeholder="¿Porqué?" />
               <%-- <textarea class="form-control" rows="3" id="txt_Acp11" style="display:none" onkeydown="CambioTextoAutoevaluacion('errAcResPreg11')" placeholder="Si identifica riesgos en materia de seguridad, indique cuáles:"></textarea>--%>
               <div id="errAcResPreg11" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
               </div>
                     <%--<div class="well">
                        <div class="row">
                            <div class="col-sm-12 singleChoise">
                                <label for="lbRiesgosSeguridad"><h4>Si identifica riesgos en materia de seguridad, indique cuáles:</h4></label>
                                <input id="txtRiesgosSeguridad" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errorRiesgosSeguridad')" placeholder="Por favor indique cuáles..."/>
                                <div id="errorRiesgosSeguridad" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese su respuesta. Este campo es requerido.</div>
                            </div>
                        </div>
                    </div>--%>
        <div class="well">
                <div class="row">
                    <div class="col-sm-12 singleChoise">
                        <label for="lbReunionGA"><h4>¿Ha estado presente en los espacios de reunión de su Grupo Auditor y ha participado activamente en las reuniones con otros actores?</h4></label>
                        <select id="selReunionGA" class="form-control" onchange="SeleccionarItemAutoevaluacion('ReunionGA')">
                            <option>Si</option>
                            <option>No</option>
                        </select>
                        <input id="txtReunionGA" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errorReunionGA')" placeholder="¿Porqué?"/>
                        <div id="errorReunionGA" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese el porqué de su respuesta. Este campo es requerido.</div>
                    </div>
                </div>
            </div>

            <div class="well">
                 <div class="row">
                    <div class="col-sm-12 singleChoise">
                        <label for="lbLogroMetas"><h4>En su labor de Auditor Ciudadano ha logrado las metas que se propuso alcanzar en su plan de trabajo. </h4></label>
                        <select id="selLogroMetas" class="form-control" >
                            <option>Si</option>
                            <option>No</option>
                        </select>
                        <input id="txtLogroMetas" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errorLogroMetas')" placeholder="¿Porqué?"/>
                        <div id="errorLogroMetas" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese el porqué de su respuesta. Este campo es requerido.</div>
                    </div>
                </div>
            </div>

            <div class="well">
               <div class="row">
                    <div class="col-sm-12 singleChoise">
                        <label for="lbAprendizajeAC"><h4>¿Cuál ha sido el mayor aprendizaje de su experiencia hasta el momento?</h4></label>
                        <input id="txtAprendizajeAC" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errorAprendizajeAC')" placeholder="Por favor ingrese su respuesta"/>
                        <div id="errorAprendizajeAC" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese su respuesta. Este campo es requerido.</div>
                    </div>
             </div>
            </div>

             <div class="well">
               <div class="row">
                    <div class="col-sm-12 singleChoise">
                        <label for="lbDificultadAC"><h4>¿Cuál ha sido la mayor dificultad que enfrentó durante su experiencia como Auditor Ciudadano?</h4></label>
                        <input id="txtDificultadAC" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errorDificultadAC')" placeholder="Por favor ingrese su respuesta"/>
                        <div id="errorDificultadAC" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese su respuesta. Este campo es requerido.</div>
                    </div>
             </div>
            </div>

             <div class="well">
               <div class="row">
                    <div class="col-sm-12 singleChoise">
                        <label for="lbSugerencias"><h4>¿Considera que hay algún aspecto por mejorar?, cuéntenos su sugerencias:</h4></label>
                        <input id="txtSugerencias" type="text" class="form-control" onkeydown="CambioTextoAutoevaluacion('errorSugerencias')" placeholder="Por favor ingrese su respuesta"/>
                        <div id="errorSugerencias" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese su respuesta. Este campo es requerido.</div>
                    </div>
             </div>
            </div>

         </div>
            
        <%--</form>--%>
        <!--BOTONERA-->
             <div class="botonera text-center">
              	<div class="btn btn-primary" onclick="GuardarAutoevaluacion()"><a href="#"><span class="glyphicon glyphicon-ok-sign"></span> ENVIAR AUTOEVALUACIÓN</a></div>
             </div>
        </div>
 <script type="text/javascript">
    $(document).ready(function () {
        InicializarCajasTextoAutoevaluacion();
    });
</script>



