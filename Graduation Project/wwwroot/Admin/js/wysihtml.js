!function ($) {
    "use strict";
    var editor = new wysihtml5.Editor("wysihtml5-editor", {
        toolbar: "wysihtml5-editor-toolbar",
        stylesheets: ["http://yui.yahooapis.com/2.9.0/build/reset/reset-min.css", "css/editor.css"],
        parserRules: wysihtml5ParserRules
    });

    editor.on("load", function () {
        var composer = editor.composer;
        composer.selection.selectNode(editor.composer.element.querySelector("h1"));
    });
}(window.jQuery);


