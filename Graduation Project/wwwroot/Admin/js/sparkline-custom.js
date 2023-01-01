!function ($) {
    "use strict";
    $(function () {
        $("#sparkline1").sparkline([52, 12, 44], {
            type: 'pie',
            height: '180px',
            sliceColors: ['#1fbef6', '#035673', '#1f6b86']});
        $("#sparkline2").sparkline([5, 6, 7, 2, 0, 4, 2, 4, 5, 7, 2, 4, 12, 14, 4, 2, 14, 12, 7], {
            type: 'bar',
            barWidth: 10,
            height: '180px',
            barColor: '#1fbef6',
            negBarColor: '#035673'});
        $("#sparkline3").sparkline([34, 43, 43, 35, 44, 32, 15, 22, 46, 33, 86, 54, 73, 53, 12, 53, 23, 65, 23, 63, 53, 42, 34, 56, 76, 15, 54, 23, 44], {
            type: 'line',
            lineWidth: 3,
            height: '180px',
            lineColor: '#1fbef6',
            fillColor: 'rgba(68, 70, 79, 0.0)'
        });
    });
}(window.jQuery);
