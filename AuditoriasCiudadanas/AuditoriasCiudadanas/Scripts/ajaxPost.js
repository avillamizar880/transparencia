/*

Descripci�n de par�metros de la funci�n:
	ajaxPost(url, params, objDest, callbackFunc(txr,sta,ohx), errorFunc(ohx, txtsta));

	url: Cadena de caract�res que representa la p�gina a la cual se realiza la petici�n POST asincr�nica habitualmente localizada en el m�smo sitio Web donde reside el archivo de �sta funci�n.
	Ej: "guardar.aspx".

	params: Cadena de caract�res o objeto JSON que representan los par�metros que van a ser enviados asincr�nicamente.
	Ej1: "a=1&b=2&c=3"
	Ej2: {a:1,b:2,c:3}

	objDest: Representaci�n de(los) objeto(s) HTML destino donde se renderizar� la respuesta de la petici�n asincr�nica. La representaci�n de �stos objetos se puede dar en cuatro formas:
	  1. Cadena de caracter�s con el ID del objeto HTML destino. 
		 Ej: 'divDestino'.
	  2. Objeto(s) destino directamente referenciado(s) del DOM. 
		 Ej1: document.getElementById('divDestino')
		 Ej2: document.form1.divDestino
		 Ej3: document.getElementsByTagname('div')
	  3. Cadena de caract�res que representan un selector jQuery de(los) objeto(s) destino donde se renderizar� la respuesta de la petici�n asincr�nica.
		 Ej1: '#divDestino' (objeto con ID="divDestino").
		 Ej2: '.claseDivDestino' (objeto(s) con atributo class="claseDivDestino").
		 Ej3: 'DIV' (todos los objetos HTML DIV del documento).
	  4. Objeto jQuery que representa uno o m�s objetos destino donde se renderizar� la respuesta de la petici�n asincr�nica.
		 Ej1: $('#divDestino')
		 Ej2: $('.claseDivDestino')
		 Ej3: $('DIV')
	NOTA: Si la funci�n tiene un par�metro "objDest" nulo, la petici�n se realiza pero no se renderiza porque no tiene un objeto destino donde renderizarse.
		 
	callbackFunc: Representa una cadena de caract�res con c�digo o una funci�n de Javascript la cual se ejecuta en el momento en que la petici�n se termina de realizar y renderizar si es el caso. Si la funci�n ajaxPost detecta que el par�metro "callbackFunc" es una funci�n, se le incorporan tres par�metros a esa funci�n:
		callbackFunc(textoRespuesta, statusPeticion, objXmlHttpReq){};
			1. textoRespuesta: El texto de respuesta de la petici�n cuando finaliza.
			2. statusPeticion: El c�digo del estado de la petici�n cuando finaliza.
			3. objXmlHttpReq: El objeto XMLHTTPREQUEST que se emple� para realizar la petici�n.
	Ej1: ajaxPost('guardar.aspx', 'a=1&b=2&c=3', 'divDestino', 'alert(\'La petici�n finaliz�\');');
	Ej2: ajaxPost('guardar.aspx', {a:1,b:2,c:3}, $('#divDestino'), 
	              function(txr,sta,ohx){ 
					alert('La petici�n finaliz� con texto de respuesta:' + txr);
				  });
	Ej3: ajaxPost('guardar.aspx', {a:1,b:2,c:3}, $('#divDestino'), 
	              function(txr,sta,ohx){ 
					alert('La petici�n finaliz� con estado:' + sta);
				  });
	Ej4: ajaxPost('guardar.aspx', {a:1,b:2,c:3}, $('#divDestino'), 
	              function(txr,sta,ohx){ 
					alert('La petici�n finaliz� con texto de respuesta:' + ohx.responseText);
				  });
				  
	errorFunc: Representa una funci�n de Javascript la cual se ejecuta en el momento en que la petici�n termina y ocurre un error en su ejecuci�n. En el llamado a �sta funci�n, ajaxPost incorpora dos par�metros:
		errorFunc(ohx, txtsta);
			1. ohx: El objeto XMLHTTPREQUEST que se emple� para realizar la petici�n.
			2. txtsta: Breve descripci�n del error ocurrido.
			
Notas adicionales:
	1. id="ajax": En la p�gina a la cual se le realiza la petici�n (ej: guardar.aspx) se puede agregar un tag <script/> para que se ejecute c�digo javascript en el momento en que se renderize la p�gina, pero �ste tag <script> debe tener el atributo "id" igual a "ajax".
	Ej: 
	 1.1) Se realiza el llamado a la funci�n de �sta forma:
	 ajaxPost('guardar.aspx','guardar=ok','divDestino');
	 1.2) Dentro de la respuesta de �sta p�gina est� el siguiente c�digo HTML:
	 
		<div>Se guard� todo OK</div>
		<script id="ajax"> alert('hola mundo');</script>
		
	 1.3) En el momento en que se renderiza ese c�digo HTML, se ejecuta lo que est� dentro del tag <script/> (realiza una alerta con la cadena"hola mundo") y elimina el elemento <script/> del DOM.
	 
	 Es IMPORTANTE anotar que lo que se encuentre en la respuesta con id="ajax" se ejecutar� PRIMERO que lo que se defina en la funci�n "callbackFunc".	
	 
	 2. Variable "htmlMientrasCarga": Esta variable contiene el c�digo HTML que va a ir dentro del objeto HTML destino mientras la petici�n finaliza.
	
Informaci�n de la versi�n:
	Se corrigi� el bug que ocurr�a en Internet Explorer el cual se ten�a que colocar un objeto HTML (&nbsp;) antes del registro del objeto script con ID="ajax".
*/


//Funciones para bloqueo/Desbloqueo de pantalla
function APwaitblockUI() { $.blockUI({ message: "<h2>Cargando...</h2>" }); }
function APunblockUI() { $.unblockUI(); }

var ajaxPost = function (url, params, objDest, callbackFunc, errorFunc) {
    var isObject = function (v) {
        var esObj = v && typeof v == "object";
        if (esObj == null) {
            esObj = false;
        }
        return esObj;
    };
    if (callbackFunc == undefined || callbackFunc == null) { callbackFunc = ""; }
    var gObj = function (objId) {
        try {
            return document.getElementById(objId);
        } catch (e) {
            alert(e.ToString);
            return false;
        }
    }
    var isObject = function (v) {
        return v && typeof v == "object";
    }
    var isHTMLObject = false;
    if ($(objDest).length != 0) {
        isHTMLObject = true;
    } else if (isObject(objDest)) {
        isHTMLObject = true;
    } else if (isObject(document.getElementById(objDest))) {
        objDest = document.getElementById(objDest);
        isHTMLObject = true;
    }

    if (!isHTMLObject && objDest != undefined && objDest != null) {
        alert("[ERROR, URL Er]: " + url + '\n\n' +
              "[Par�metros Er]: " + params.toString() + '\n\n' +
              "[Id Obj. Dest.]: " + objDest.toString() + '\n\n' +
              "[Funci�n Final]: " + callbackFunc.toString() + '\n\n' +
              "[Descripci�n E]: Se hace referencia a un objeto destino \"" + objDest.toString() + '\" que no ex�ste.');
        //$("<div title='Error'><p>[ERROR, URL Er]: " + url +
        //  "[Par�metros Er]: " + params.toStr +
        //  "[Id Obj. Dest.]: " + objDest.toSt +
        //  "[Funci�n Final]: " + callbackFunc +
        //  "[C�digo Fuente]: " + callbackFunc +
        //  "[Descripci�n E]:Se hace referencia a un objeto destino \"" + objDest.toString() + '\" que no ex�ste.' + "</p></div>").dialog();
        return false;
    };
    //else {
    //    $(objDest).html(htmlMientrasCarga);
    //};
    $.ajax({
        url: url,
        global: false,
        type: "POST",
        data: params,
        dataType: "html",
        async: true,
        beforeSend: function () {
            APwaitblockUI();
        },
        complete: function (sxh, st) {
            if (sxh.status != "error") {
                var objetoDestino = new Object();
                objetoDestino = document.createElement("div");
                objetoDestino.innerHTML = "&nbsp;" + sxh.responseText;
                var elements = objetoDestino.getElementsByTagName('script');
                if (elements.length > 0) {
                    var code = '';
                    for (var i = 0; i < elements.length; i++) {
                        if (elements[i].id == "ajax") {
                            code += elements[i].innerHTML;
                        }
                    }
                    for (var j = 0; j < elements.length; j++) {
                        if (elements[j].id == "ajax") {
                            objetoDestino.removeChild(elements[j]);
                        }
                    }
                    if (isHTMLObject) {
                        $(objDest).html(objetoDestino.innerHTML.substring(6, objetoDestino.innerHTML.length));
                    };
                    try {
                        if (code != '') {
                            eval(code);
                        }
                    } catch (e) {
                        if (!jQuery.isFunction(callbackFunc)) {
                            callbackFunc = "";
                        };
                        if (objDest == null) {
                            objDest = "[null]";
                        } else if (objDest == undefined) {
                            objDest = "[undefined]";
                        }
                        alert("[ERROR, URL Er]: " + url + '\n\n' +
                                "[Par�metros Er]: " + params.toString() + '\n\n' +
                                "[Id Obj. Dest.]: " + objDest.toString() + '\n\n' +
                                "[Funci�n Final]: " + callbackFunc.toString() + '\n\n' +
                                "[C�digo Fuente]: " + code + '\n\n' +
                                "[Descripci�n E]: " + e.toString());

                        //$("<div title='Error'>[ERROR, URL Er]: " + url +
                        //"[Par�metros Er]: " + params.toStr +
                        //"[Id Obj. Dest.]: " + objDest.toSt +
                        //"[Funci�n Final]: " + callbackFunc +
                        //"[C�digo Fuente]: " + callbackFunc +
                        //"[Descripci�n E]: " + e.toString() + '\n\n' + "</div>").dialog();
                    }
                } else {
                    if (isHTMLObject) {
                        $(objDest).html(objetoDestino.innerHTML.substring(6, objetoDestino.innerHTML.length));
                    };
                }
                if (jQuery.isFunction(callbackFunc)) {
                    callbackFunc(sxh.responseText, st, sxh);
                } else {
                    try {
                        if (callbackFunc != '') {
                            eval(callbackFunc);
                        }
                    } catch (e) {
                        if (objDest == null) {
                            objDest = "[null]";
                        } else if (objDest == undefined) {
                            objDest = "[undefined]";
                        }
                        alert("[ERROR, URL Er]: " + url + '\n\n' +
                                "[Par�metros Er]: " + params.toString() + '\n\n' +
                                "[Id Obj. Dest.]: " + objDest.toString() + '\n\n' +
                                "[Funci�n Final]: " + callbackFunc.toString() + '\n\n' +
                                "[C�digo Fuente]: " + callbackFunc + '\n\n' +
                                "[Descripci�n E]: " + e.toString());

                        //$("<div title='Error'><p>[ERROR, URL Er]: " + url +
                        //          "[Par�metros Er]: " + params.toStr  +
                        //          "[Id Obj. Dest.]: " + objDest.toSt  +
                        //          "[Funci�n Final]: " + callbackFunc  +
                        //          "[C�digo Fuente]: " + callbackFunc  +
                        //          "[Descripci�n E]: " + e.toString() + '\n\n' + "</p></div>").dialog();






                    }
                };
            }
        },
        error: function (XMLHttpRequest, textStatus) {
            if (jQuery.isFunction(errorFunc)) {
                errorFunc(XMLHttpRequest, textStatus);
            } else {
                alert(textStatus + '\n' + XMLHttpRequest.responseText);
                if (isHTMLObject) {
                    $(objDest).html(XMLHttpRequest.responseText);
                }
            }
        },
        success: function (result) {
            APunblockUI();
        }
    });
}