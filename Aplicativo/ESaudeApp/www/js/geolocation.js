// In the following example, markers appear when the user clicks on the map.
// Each marker is labeled with a single alphabetical character.
var labels = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
var labelIndex = 0;
myPosition = undefined;
map = undefined;
infoWindow = undefined;

//window.onload = function () {
//    initMap()
//};
//initMap();

function initMap() {
    console.log(1);
    //if (map == undefined) {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -34.397, lng: 150.644 },
        zoom: 15
    });

    infoWindow = new google.maps.InfoWindow({ map: map });
    //myPosition = {
    //    lat: 15.565710600000001,
    //    lng: 56.1067919
    //};
    //infoWindow.setPosition(myPosition);
    //infoWindow.setContent('Estou aqui!');
    //map.setCenter(myPosition);

    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            myPosition = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            //alert(myPosition.lat + " - " + myPosition.lng);
            infoWindow.setPosition(myPosition);
            infoWindow.setContent('Estou aqui!');
            map.setCenter(myPosition);
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }
    
    // This event listener calls addMarker() when the map is clicked.
    google.maps.event.addListener(map, 'click', function (event) {
        //addMarker(event.latLng, map);
        //console.log(event.latLng);
        
    });

    // Add a marker at the center of the map.
    //addMarker(myPosition, map);

    //google.maps.event.addDomListener(window, 'load', initMap);
}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
}


var image = 'img/mosquitoIcon.png';
// Adds a marker to the map.
function addMarker(location, map) {
    // Add the marker at the clicked location, and add the next-available label
    // from the array of alphabetical characters.
    var marker = new google.maps.Marker({
        position: location,
        //label: labels[labelIndex++ % labels.length],
        map: map,
        icon: image
    });
}

//google.maps.event.addDomListener(window, 'load', initMap);