﻿module.exports = function (callback, html) { 
    var jsreport = require('jsreport-core')(); 
 
    jsreport.init().then(function () { 
        return jsreport.render({ 
            template: { 
                content: html, 
                engine: 'jsrender', 
                recipe: 'phantom-pdf' 
            } 
        }).then(function (resp) { 
            callback(null, resp.content.toJSON().data); 
        }); 
    }).catch(function (e) { 
        callback(e, null); 
    }) 
}; 