function initMap() {
    // Create a map object and specify the DOM element for display.
    document.getElementById('legend').innerHTML = "";
    var coordonnEe = { lat: -18.901813, lng: 47.521544 };
    var icons = {
        pv: {
            name: 'Point de vente',
            icon: 'http://localhost:50597/image/print/pv1.png'
        },
        pvRupture: {
            name: 'Point de vente en rupture de stock',
            icon: 'http://localhost:50597/image/print/pv2.png'
        }
    };
  var listMarker = [
      [-18.906635, 47.524615, 'http://localhost:50597/image/print/pv2.png'],
      [-18.906820, 47.523721, 'http://localhost:50597/image/print/pv2.png'],
      [-18.907733, 47.525237, 'http://localhost:50597/image/print/pv1.png'],
      [-18.905641, 47.521458, 'http://localhost:50597/image/print/pv2.png']
  ];
  var map = new google.maps.Map(document.getElementById('map'), {
    center: coordonnEe,
    scrollwheel: false,
    zoom: 15,
    mapTypeId: 'terrain'
  });

  var infowindow = new google.maps.InfoWindow;
  infowindow.setContent('<b>Point de vente 1</b><p>Gérer par: RAZAFIARISON Mickael</p><p>Stock actuel: 1000 cartes</p><p>Place: Behoririka</p>');

  var marker = new google.maps.Marker({
    position: coordonnEe,
    map: map,
    icon: 'http://localhost:50597/image/print/pv1.png'
  });
  marker.addListener('click', function () {
      infowindow.open(map, marker);
  });

  for(i=0; i<listMarker.length; i++){
    var position = new google.maps.LatLng(listMarker[i][0], listMarker[i][1]);
    var markers = new google.maps.Marker({
      position: position,
      map: map,
      icon: listMarker[i][2]
    });
  }
  for (var key in icons) {
      var type = icons[key];
      var name = type.name;
      var icon = type.icon;
      var div = document.createElement('div');
      div.innerHTML = '<img src="' + icon + '"> ' + name;
      legend.appendChild(div);
  }


}



$(".js-all").on('click', function () {
    initMap();
});

$(".js-stock").on('click', function () {
    var icons = {
        pvRupture: {
            name: 'Point de vente en rupture de stock',
            icon: 'http://localhost:50597/image/print/pv2.png'
        }
    };
    document.getElementById('legend').innerHTML = "";
    var coordonnEes = { lat: -18.901813, lng: 47.521544 };
    var listMarker = [
        [-18.906635, 47.524615, 'http://localhost:50597/image/print/pv2.png'],
        [-18.906820, 47.523721, 'http://localhost:50597/image/print/pv2.png'],
        [-18.905641, 47.521458, 'http://localhost:50597/image/print/pv2.png']
    ];
    var map = new google.maps.Map(document.getElementById('map'), {
        center: coordonnEes,
        scrollwheel: false,
        zoom: 15,
        mapTypeId: 'terrain'
    });

    for (i = 0; i < listMarker.length; i++) {
        var position = new google.maps.LatLng(listMarker[i][0], listMarker[i][1]);
        marker = new google.maps.Marker({
            position: position,
            map: map,
            icon: listMarker[i][2]
        });
    }

    var infowindow = new google.maps.InfoWindow;
    infowindow.setContent('<b>Point de vente 3</b><p>Gérer par: RAKOTO Jean</p><p>Stock actuel: 20 cartes</p><p>Place: Analakely</p>');
    
    marker.addListener('click', function () {
        infowindow.open(map, marker);
    });

    for (var key in icons) {
        var type = icons[key];
        var name = type.name;
        var icon = type.icon;
        var div = document.createElement('div');
        div.innerHTML = '<img src="' + icon + '"> ' + name;
        legend.appendChild(div);
    }
});

