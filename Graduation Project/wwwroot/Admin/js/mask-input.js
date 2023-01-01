!function ($) {
    "use strict";
    $("#product").mask("99/99/9999", {placeholder: " "});
    $("#date").mask("99/99/9999", {placeholder: "mm/dd/yyyy"});
    $("#phone").mask("(999) 999-9999");
    $("#tin").mask("99-9999999");
    $("#ssn").mask("999-99-9999");
    $('#phoneext').mask("(999) 999-9999? x99999");

    $.mask.definitions['~'] = '[+-]';
    $("#eyescript").mask("~9.99 ~9.99 999");
}(window.jQuery);