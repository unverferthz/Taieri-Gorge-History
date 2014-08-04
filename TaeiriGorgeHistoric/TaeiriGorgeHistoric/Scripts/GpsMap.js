function init() {

    var mapCanvas = document.getElementById("mapArea");
                                        //Lat&Long for Dunedin
    var mapCentre = new google.maps.LatLng(-45.8667, 170.5000);
    var mapType = google.maps.MapTypeId.ROADMAP;
    var mapOptions = { center: mapCentre,
        zoom: 12,
        mapTypeId: mapType
    };

    mapObject = new google.maps.Map(mapCanvas, mapOptions);

    var latLangs = latLangArray;

    for(var i=0; i < latLangs.length; i++) {

        var splitLatLang = latLangs[i].split(",");
        var newMapMarker = new google.maps.LatLng(splitLatLang[0], splitLatLang[1])
        addMarker(newMapMarker, mapObject);
        
    }
}

function addMarker(latLng, map) {
    var toolTipText = "Testing";

    var markerOption = {
        position: latLng,
        title: toolTipText
    };
    var markerObject = new google.maps.Marker(markerOption);
    markerObject.setMap(map);
}


window.onload = init;