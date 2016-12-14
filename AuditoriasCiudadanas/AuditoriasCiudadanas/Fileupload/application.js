/* 
 * jQuery File Upload Plugin JS Example 5.0.2
 * https://github.com/blueimp/jQuery-File-Upload
 *
 * Copyright 2010, Sebastian Tschan
 * https://blueimp.net
 *
 * Licensed under the MIT license:
 * http://creativecommons.org/licenses/MIT/
 */

/*jslint nomen: true */
/*global $ */

$(function () {
    'use strict';

    // Initialize the jQuery File Upload widget:
    $(function () {
        $('#fileupload').fileupload({
            dataType: 'json',
            add: function (e, data) {
                data.context = $('#upload_button');
                $('#upload_button').click(function () {
                    data.submit();
                });
            },
            done: function (e, data) {
                data.context.text('Upload finished.');
            }
        });
    });


    // Load existing files:
    //    $.getJSON($('#fileupload form').prop('action'), function (files) {
    //        var fu = $('#fileupload').data('fileupload');
    //        fu._adjustMaxNumberOfFiles(-files.length);
    //        fu._renderDownload(files)
    //            .appendTo($('#fileupload .files'))
    //            .fadeIn(function () {
    //                // Fix for IE7 and lower:
    //                $(this).show();
    //            });
    //    });
    
    $('#fileupload').bind('fileuploaddone', function (e, data) {
        alert("@fileuploaddone");
        if (data.jqXHR.responseText || data.result) {
            var fu = $('#fileupload').data('fileupload');
            var JSONjQueryObject = (data.jqXHR.responseText) ? jQuery.parseJSON(data.jqXHR.responseText) : data.result;
            
            // Don't allow to add another file for each successfull File uploaded
            //fu._adjustMaxNumberOfFiles(JSONjQueryObject.List.length);
            
            //.files.length);
            //                debugger;
            fu._renderDownload(JSONjQueryObject.List)
                .appendTo($('#fileupload .files'))
                .fadeIn(function () {
                    // Fix for IE7 and lower:
                    $(this).show();
                });
        }
    });

    // Open download dialogs via iframes,
    // to prevent aborting current uploads:
    $('#fileupload .files a:not([target^=_blank])').live('click', function (e) {
        e.preventDefault();
        $('<iframe style="display:none;"></iframe>')
            .prop('src', this.href)
            .appendTo('body');
    });

});