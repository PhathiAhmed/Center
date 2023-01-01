!function($) {
    "use strict";
$(function () {

    //one line chart
    Morris.Line({
        element: 'morris-one-line-chart',
        data: [
            {year: '2008', value: 5},
            {year: '2009', value: 10},
            {year: '2010', value: 8},
            {year: '2011', value: 22},
            {year: '2012', value: 8},
            {year: '2014', value: 10},
            {year: '2015', value: 5}
        ],
        xkey: 'year',
        ykeys: ['value'],
        resize: true,
        lineWidth: 4,
          gridTextColor: '#fff',
        labels: ['Value'],
        lineColors: ['#1fbef6'],
        pointSize: 5
    });
    
    //line chart
     Morris.Line({
        element: 'morris-line-chart',
        data: [{ y: '2006', a: 100, b: 90 },
            { y: '2007', a: 75, b: 65 },
            { y: '2008', a: 50, b: 40 },
            { y: '2009', a: 75, b: 65 },
            { y: '2010', a: 50, b: 40 },
            { y: '2011', a: 75, b: 65 },
            { y: '2012', a: 100, b: 90 } ],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Series A', 'Series B'],
        hideHover: 'auto',
        resize: true,
          gridTextColor: '#fff',
        lineColors: ['#1fbef6','#035673']
    });
    
    //bar charts
     Morris.Bar({
        element: 'morris-bar-chart',
        data: [{ y: '2006', a: 60, b: 50 },
            { y: '2007', a: 75, b: 65 },
            { y: '2008', a: 50, b: 40 },
            { y: '2009', a: 75, b: 65 },
            { y: '2010', a: 50, b: 40 },
            { y: '2011', a: 75, b: 65 },
            { y: '2012', a: 100, b: 90 } ],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Series A', 'Series B'],
        hideHover: 'auto',
        resize: true,
          gridTextColor: '#fff',
        barColors: ['#1fbef6', '#035673']
        
    });
});

}(window.jQuery);