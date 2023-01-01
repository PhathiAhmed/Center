!function ($) {
    "use strict";
    $(function () {
        $('.easy-pie-chart-1').easyPieChart({
            easing: 'easeOutBounce',
            barColor: '#035673',
            lineWidth: 3,
            animate: 1000,
            lineCap: 'square',
            trackColor: '#e5e5e5',
            onStep: function (from, to, percent) {
                $(this.el).find('.percent').text(Math.round(percent));
            }
        });
        $('.easy-pie-chart-2').easyPieChart({
            easing: 'easeOutBounce',
            barColor: '#035673',
            lineWidth: 3,
            trackColor: false,
            lineCap: 'butt',
            scaleColor: false,
            onStep: function (from, to, percent) {
                $(this.el).find('.percent').text(Math.round(percent));
            }
        });
    });
}(window.jQuery);