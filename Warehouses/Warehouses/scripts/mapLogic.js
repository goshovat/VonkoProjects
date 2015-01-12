//it is considered a good practice to wrap all the script in IIFE
(function () {
    //display instructions for the ap
    var instruction = "To use the AP simply click somewhere on the map and the truck "
        + "will be positioned. Then click on the truck and a prompt window will show up. " +
        "In this window input one of the availible commodities. The closest " +
        "warehouse with this commodity will be shown and the road leading to it.";
    alert(instruction);

    //implement the logic of the application based on the Google Maps Api v3
    var container;
    var map;
    /*With this array we make sure the map will be cleared of trucks
    before positioning the truck on another position*/
    var trucks = [];
    var controlAdded = false;

    window.addEventListener('load', initializeMap);

    function initializeMap() {
        var mapOptions = {
            center: { lat: 42.750, lng: 26.100 },
            zoom: 8,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        container = document.getElementById('map-div');
        map = new google.maps.Map(container, mapOptions);

        /*This function positions warehouses with different commodities
        across Bulgaria. They are stored in an array so they can be passed to
        the function that will draw the shortest route*/
        var wareHouses = putWareHouses();

        //put the marker where the user clicks
        google.maps.event.addListener(map, 'click', function (ev) {
            clearMarkers(trucks);

            var truckImg = new google.maps.MarkerImage(
                    'images/camion.png',
                    new google.maps.Size(50, 100),
                    new google.maps.Point(0, 0),
                    new google.maps.Point(20, 10)
            );

            var markerPos = ev.latLng;

            var marker = new google.maps.Marker({
                position: markerPos,
                map: map,
                icon: truckImg
            });

            //in this prompt window will be selected the commodity of the truck
            google.maps.event.addListener(marker, 'click', function () {
                var commodity = window.prompt("Choose a commodity: grain, meat or fish: ");

                if (commodity != "grain" && commodity != "meat" && commodity != "fish")
                    alert("Error! Invalid commodity.")
                else
                    makeRoute(commodity, wareHouses, markerPos);
            });

            trucks.push(marker);
        });
    }

    function putWareHouses() {
        /*Hardcoding of some coordinates for the warehouses. Depending of
        the requirements for the app they can be easily passed as parameters*/
        var varnaCoord = new google.maps.LatLng(43.2167, 27.9167);
        var sofiaCoord = new google.maps.LatLng(42.7000, 23.3333);
        var plovdivCoord = new google.maps.LatLng(42.1500, 24.7500);
        var burgasCoord = new google.maps.LatLng(42.4953, 27.4717);
        var ruseCoord = new google.maps.LatLng(43.8500, 25.9667);

        //create the objects of the warehouses
        var wareHouses = [];

        var varWareH = new WareHouse(varnaCoord, ["grain", "meat"]);
        wareHouses.push(varWareH);
        var sofWareH = new WareHouse(sofiaCoord, ["meat", "fish"]);
        wareHouses.push(sofWareH);
        var plWareH = new WareHouse(plovdivCoord, ["meat"]);
        wareHouses.push(plWareH);
        var bsWareH = new WareHouse(burgasCoord, ["grain", "fish"]);
        wareHouses.push(bsWareH);
        var rusWareH = new WareHouse(ruseCoord, ["fish"]);
        wareHouses.push(rusWareH);

        positionWareHouses(wareHouses);

        return wareHouses;
    }

    function positionWareHouses(wareHouses) {
        var wareHouseImg = new google.maps.MarkerImage(
                    'images/warehouse.png',
                    new google.maps.Size(50, 100),
                    new google.maps.Point(0, 0),
                    new google.maps.Point(20, 10)
            );

        for (var wareHouse in wareHouses) {
            var currentWareH = wareHouses[wareHouse];

            var infoWindow = new google.maps.InfoWindow();

            var marker = new google.maps.Marker({
                position: currentWareH.coordinates,
                map: map,
                title: "Warehouse",
                icon: wareHouseImg
            });

            //Attach an event so when a warehouse is clicked its commodities will be displayed
            google.maps.event.addListener(marker, 'click', (function (marker, content, infoWindow) {
                return function () {
                    infoWindow.setContent(content);
                    infoWindow.open(map, marker);
                }
            })(marker, currentWareH.commodities.join(), infoWindow));
        }
    }

    function clearMarkers(markers) {
        for (var i = 0; i < markers.length; i++) {
            markers[i].setMap(null);
        }
        markers = [];
    }

    /*This is the function that will determine the closest warehouse to 
     the truck and draw the route. Due to using different Google Maps Api
     services this function will call two nested asynchronous callbacks*/
    function makeRoute(commodity, wareHouses, markerPos) {
        var service = new google.maps.DistanceMatrixService();
        var wareHPositions = [];

        /*Get the array of warehouses positions to pass it to
         the distance matrix service*/
        for (var i = 0; i < wareHouses.length; i++) {
            if (wareHouses[i].commodities.indexOf(commodity) != -1)
                wareHPositions.push(wareHouses[i].coordinates);
        }

        service.getDistanceMatrix({
            origins: [markerPos],
            destinations: wareHPositions,
            travelMode: google.maps.TravelMode.DRIVING,
            unitSystem: google.maps.UnitSystem.METRIC,
            durationInTraffic: true,
            avoidHighways: false,
            avoidTolls: false
        }, distMatrCallback);

        function distMatrCallback(response, status) {
            if (status == google.maps.DistanceMatrixStatus.OK) {
                var origin = response.originAddresses[0];
                var destinations = response.destinationAddresses;
                var results = response.rows[0].elements;

                var minDistance = 9999999999;
                var closestWareH;

                for (var i = 0; i < destinations.length; i++) {
                    var result = results[i];
                    var routeLen = result.distance.value;

                    if (routeLen < minDistance) {
                        minDistance = routeLen;
                        closestWareH = destinations[i];
                    }
                }

                var directionsService = new google.maps.DirectionsService();

                /*The callback function will be implemented directly inside
                 because otherwise the application is not working on firefox, 
                 at lest on my machine*/
                directionsService.route({
                    origin: origin,
                    destination: closestWareH,
                    travelMode: google.maps.TravelMode.DRIVING
                }, function dirSerCallback(response, status) {
                    if (status == google.maps.DirectionsStatus.OK) {

                        var poly = new google.maps.Polyline({ map: map });
                        var path = new google.maps.MVCArray();

                        for (var i = 0, len = response.routes[0].overview_path.length;
                                  i < len; i++) {
                            path.push(response.routes[0].overview_path[i]);
                        }
                        //poly.setPath([]);

                        poly.setPath(path);
                    }
                });
            }
        }
    }

    //define the warehouse class
    function WareHouse(coordinates, commodities) {
        this.coordinates = coordinates;
        this.commodities = [];

        for (var commodity in commodities) {
            this.commodities.push(commodities[commodity]);
        }
    }
}());