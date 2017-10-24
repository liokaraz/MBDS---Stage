function initMap() {
  // Create a map object and specify the DOM element for display.
  var coordonnEe = {lat: -18.901813, lng: 47.521544};
  var listMarker = [
      [-18.906635, 47.524615],[-18.906820, 47.523721],[-18.907733, 47.525237]
  ];
  var map = new google.maps.Map(document.getElementById('map'), {
    center: coordonnEe,
    scrollwheel: false,
    zoom: 15,
    mapTypeId: 'satellite'
  });
  var marker = new google.maps.Marker({
    position: coordonnEe,
    map: map
  });

  for(i=0; i<listMarker.length; i++){
    var position = new google.maps.LatLng(listMarker[i][0], listMarker[i][1]);
    marker = new google.maps.Marker({
      position: position,
      map: map
    });
  }

  function toggleBounce() {
    if (marker.getAnimation() !== null) {
      marker.setAnimation(null);
    } else {
      marker.setAnimation(google.maps.Animation.BOUNCE);
    }
  }
}

$(".js-stock").on('click', function () {
  document.getElementById('map').innerHTML= "";
});