<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluarExperiencia.aspx.cs" Inherits="AuditoriasCiudadanas.Views.AudienciasPublicas.EvaluarExperiencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Plan de trabajo</title>
     <%-- Archivos CSS--%>
        <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
        <link href="../../Content/logo-nav.css" rel="stylesheet" />
        <link href="../../Content/screenView.css" rel="stylesheet" />
        <link href="../../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css"/>
        <link href="../../Content/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css"/>
       
      <%-- Archivos JS--%>
        <script src="../../Scripts/jquery-1.12.4.min.js" type="text/javascript" ></script>
        <script src="../../Scripts/jquery-ui-1.12.1.js" type="text/javascript" ></script>
        <script src="../../Scripts/jquery.blockUI.js" type="text/javascript" ></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <script type="text/javascript" src="../../Scripts/bootstrap-datetimepicker.js" charset="UTF-8"></script>
        <script type="text/javascript" src="../../Scripts/bootstrap-datetimepicker.es.js" charset="UTF-8"></script>

        <%--<script type="text/javascript" src="../../Scripts/ajaxPost.js"></script>--%>
       <%-- <script src="../../Scripts/PlanTrabajo.js" type="text/javascript"></script>  --%>
</head>




<body class="inside">



<div class="container">
    <h1 class="text-center">Evaluación de Experiencia</h1>
    
    	<div class="w60 center-block">
        <div class="well">
        <p> Califique de 1 a 5 su experiencia en la audiencia. Recuerde que 1: es Muy Malo  y 5: es Excelente</p></div>
    	<form>
        	
            	<div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>¿Cree usted que la audiencia se desarrolló de manera organizada?</h4>
               <div class="btn-group" data-toggle="buttons">
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P1_op1" autocomplete="off" checked/> 1
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P1_op2" autocomplete="off"/> 2
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P1_op3" autocomplete="off"/> 3
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P1_op4" autocomplete="off"/> 4
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P1_op5" autocomplete="off"/> 5
                  </label>
                </div>
                <textarea class="form-control" rows="3" id="P1_rop3" placeholder="¿Porqué?"></textarea>
                </div>
                </div>
             	<div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>¿Cómo evalúa los temas tratados en la audiencia?</h4>
               <div class="btn-group" data-toggle="buttons">
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P2_op1" autocomplete="off" checked/> 1
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P2_op2" autocomplete="off"/> 2
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P2_op3" autocomplete="off"/> 3
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P2_op4" autocomplete="off"/> 4
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P2_op5" autocomplete="off"/> 5
                  </label>
                </div>
               <textarea class="form-control" rows="3" id="P2_rop3" placeholder="¿Porqué?"></textarea>
                </div>
                </div>
                <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>¿Tuvo algun problema?</h4>
               <div class="btn-group" data-toggle="buttons">
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P3_op1" autocomplete="off" checked/> 1
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P3_op2" autocomplete="off"/> 2
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P3_op3" autocomplete="off"/> 3
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P3_op4" autocomplete="off"/> 4
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P3_op5" autocomplete="off"/> 5
                  </label>
                </div>
                <textarea class="form-control" rows="3" id="P3_rop3" placeholder="Descríbalo"></textarea>
                </div>
                </div>
             <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>¿Como considera su participación  en el control de la gestión pública?</h4>
               <div class="btn-group" data-toggle="buttons">
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P4_op1" autocomplete="off" checked/> 1
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P4_op2" autocomplete="off"/> 2
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P4_op3" autocomplete="off"/> 3
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P4_op4" autocomplete="off"/> 4
                  </label>
                  <label class="btn btn-default">
                    <input type="radio" name="options" id="P4_op5" autocomplete="off"/> 5
                  </label>
                </div>
                <textarea class="form-control" rows="3" id="P4_rop3" placeholder="¿Porqué?"></textarea>
                </div>
                </div>
             
             
        
        </form>
        <!--BOTONERA-->
             <div class="botonera text-center">
              	<div class="btn btn-primary"><a href=""><span class="glyphicon glyphicon-ok-sign"></span> EVALUAR</a></div>
             </div>
        </div>
        
        
    </div>

</body>
</html>