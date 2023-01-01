!function ($) {
    "use strict";
    $(function () {
        $("#custom-sort").data("tablesaw-sort", function (ascending) {
            return function (a, b) {
                // a.cell
                // a.element
                // a.rowNum
                var yearA = a.cell.split("/"),
                        yearB = b.cell.split("/");

                if (ascending) {
                    return parseInt(yearA[ 1 ], 10) - parseInt(yearB[ 1 ], 10);
                } else {
                    // descending
                    return parseInt(yearB[ 1 ], 10) - parseInt(yearA[ 1 ], 10);
                }
            };
        });
    });
}(window.jQuery);