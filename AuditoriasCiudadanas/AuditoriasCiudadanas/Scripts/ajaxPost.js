/*

Descripción de parámetros de la función:
	ajaxPost(url, params, objDest, callbackFunc(txr,sta,ohx), errorFunc(ohx, txtsta));

	url: Cadena de caractéres que representa la página a la cual se realiza la petición POST asincrónica habitualmente localizada en el mísmo sitio Web donde reside el archivo de ésta función.
	Ej: "guardar.aspx".

	params: Cadena de caractéres o objeto JSON que representan los parámetros que van a ser enviados asincrónicamente.
	Ej1: "a=1&b=2&c=3"
	Ej2: {a:1,b:2,c:3}

	objDest: Representación de(los) objeto(s) HTML destino donde se renderizará la respuesta de la petición asincrónica. La representación de éstos objetos se puede dar en cuatro formas:
	  1. Cadena de caracterés con el ID del objeto HTML destino. 
		 Ej: 'divDestino'.
	  2. Objeto(s) destino directamente referenciado(s) del DOM. 
		 Ej1: document.getElementById('divDestino')
		 Ej2: document.form1.divDestino
		 Ej3: document.getElementsByTagname('div')
	  3. Cadena de caractéres que representan un selector jQuery de(los) objeto(s) destino donde se renderizará la respuesta de la petición asincrónica.
		 Ej1: '#divDestino' (objeto con ID="divDestino").
		 Ej2: '.claseDivDestino' (objeto(s) con atributo class="claseDivDestino").
		 Ej3: 'DIV' (todos los objetos HTML DIV del documento).
	  4. Objeto jQuery que representa uno o más objetos destino donde se renderizará la respuesta de la petición asincrónica.
		 Ej1: $('#divDestino')
		 Ej2: $('.claseDivDestino')
		 Ej3: $('DIV')
	NOTA: Si la función tiene un parámetro "objDest" nulo, la petición se realiza pero no se renderiza porque no tiene un objeto destino donde renderizarse.
		 
	callbackFunc: Representa una cadena de caractéres con código o una función de Javascript la cual se ejecuta en el momento en que la petición se termina de realizar y renderizar si es el caso. Si la función ajaxPost detecta que el parámetro "callbackFunc" es una función, se le incorporan tres parámetros a esa función:
		callbackFunc(textoRespuesta, statusPeticion, objXmlHttpReq){};
			1. textoRespuesta: El texto de respuesta de la petición cuando finaliza.
			2. statusPeticion: El código del estado de la petición cuando finaliza.
			3. objXmlHttpReq: El objeto XMLHTTPREQUEST que se empleó para realizar la petición.
	Ej1: ajaxPost('guardar.aspx', 'a=1&b=2&c=3', 'divDestino', 'alert(\'La petición finalizó\');');
	Ej2: ajaxPost('guardar.aspx', {a:1,b:2,c:3}, $('#divDestino'), 
	              function(txr,sta,ohx){ 
					alert('La petición finalizó con texto de respuesta:' + txr);
				  });
	Ej3: ajaxPost('guardar.aspx', {a:1,b:2,c:3}, $('#divDestino'), 
	              function(txr,sta,ohx){ 
					alert('La petición finalizó con estado:' + sta);
				  });
	Ej4: ajaxPost('guardar.aspx', {a:1,b:2,c:3}, $('#divDestino'), 
	              function(txr,sta,ohx){ 
					alert('La petición finalizó con texto de respuesta:' + ohx.responseText);
				  });
				  
	errorFunc: Representa una función de Javascript la cual se ejecuta en el momento en que la petición termina y ocurre un error en su ejecución. En el llamado a ésta función, ajaxPost incorpora dos parámetros:
		errorFunc(ohx, txtsta);
			1. ohx: El objeto XMLHTTPREQUEST que se empleó para realizar la petición.
			2. txtsta: Breve descripción del error ocurrido.
			
Notas adicionales:
	1. id="ajax": En la página a la cual se le realiza la petición (ej: guardar.aspx) se puede agregar un tag <script/> para que se ejecute código javascript en el momento en que se renderize la página, pero éste tag <script> debe tener el atributo "id" igual a "ajax".
	Ej: 
	 1.1) Se realiza el llamado a la función de ésta forma:
	 ajaxPost('guardar.aspx','guardar=ok','divDestino');
	 1.2) Dentro de la respuesta de ésta página está el siguiente código HTML:
	 
		<div>Se guardó todo OK</div>
		<script id="ajax"> alert('hola mundo');</script>
		
	 1.3) En el momento en que se renderiza ese código HTML, se ejecuta lo que está dentro del tag <script/> (realiza una alerta con la cadena"hola mundo") y elimina el elemento <script/> del DOM.
	 
	 Es IMPORTANTE anotar que lo que se encuentre en la respuesta con id="ajax" se ejecutará PRIMERO que lo que se defina en la función "callbackFunc".	
	 
	 2. Variable "htmlMientrasCarga": Esta variable contiene el código HTML que va a ir dentro del objeto HTML destino mientras la petición finaliza.
	
Información de la versión:
	Se corrigió el bug que ocurría en Internet Explorer el cual se tenía que colocar un objeto HTML (&nbsp;) antes del registro del objeto script con ID="ajax".
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
              "[Parámetros Er]: " + params.toString() + '\n\n' +
              "[Id Obj. Dest.]: " + objDest.toString() + '\n\n' +
              "[Función Final]: " + callbackFunc.toString() + '\n\n' +
              "[Descripción E]: Se hace referencia a un objeto destino \"" + objDest.toString() + '\" que no exíste.');
        //$("<div title='Error'><p>[ERROR, URL Er]: " + url +
        //  "[Parámetros Er]: " + params.toStr +
        //  "[Id Obj. Dest.]: " + objDest.toSt +
        //  "[Función Final]: " + callbackFunc +
        //  "[Código Fuente]: " + callbackFunc +
        //  "[Descripción E]:Se hace referencia a un objeto destino \"" + objDest.toString() + '\" que no exíste.' + "</p></div>").dialog();
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
                                "[Parámetros Er]: " + params.toString() + '\n\n' +
                                "[Id Obj. Dest.]: " + objDest.toString() + '\n\n' +
                                "[Función Final]: " + callbackFunc.toString() + '\n\n' +
                                "[Código Fuente]: " + code + '\n\n' +
                                "[Descripción E]: " + e.toString());

                        //$("<div title='Error'>[ERROR, URL Er]: " + url +
                        //"[Parámetros Er]: " + params.toStr +
                        //"[Id Obj. Dest.]: " + objDest.toSt +
                        //"[Función Final]: " + callbackFunc +
                        //"[Código Fuente]: " + callbackFunc +
                        //"[Descripción E]: " + e.toString() + '\n\n' + "</div>").dialog();
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
                                "[Parámetros Er]: " + params.toString() + '\n\n' +
                                "[Id Obj. Dest.]: " + objDest.toString() + '\n\n' +
                                "[Función Final]: " + callbackFunc.toString() + '\n\n' +
                                "[Código Fuente]: " + callbackFunc + '\n\n' +
                                "[Descripción E]: " + e.toString());

                        //$("<div title='Error'><p>[ERROR, URL Er]: " + url +
                        //          "[Parámetros Er]: " + params.toStr  +
                        //          "[Id Obj. Dest.]: " + objDest.toSt  +
                        //          "[Función Final]: " + callbackFunc  +
                        //          "[Código Fuente]: " + callbackFunc  +
                        //          "[Descripción E]: " + e.toString() + '\n\n' + "</p></div>").dialog();






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