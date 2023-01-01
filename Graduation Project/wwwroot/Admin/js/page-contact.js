!function (map) {
    "use strict";
// Marker Map
    $(document).on("ready", function () {
        map = new GMaps({
            el: '#markermap',
            lat: 34.043333,
            lng: -78.028333

        });
        map.addMarker({
            lat: 34.042,
            lng: -78.028333,
            title: 'Marker with InfoWindow',
            infoWindow: {
                content: '<p>Your Content</p>'
            }
        });
    });
}(window.jQuery);