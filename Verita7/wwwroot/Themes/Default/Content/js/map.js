// Themes begin
am4core.useTheme(am4themes_animated);
//am4core.options.autoSetClassName = true;
// Create map instance
var chart = am4core.create("chartdiv", am4maps.MapChart);

var chartEvents = [];

// Set map definition
chart.geodata = am4geodata_worldLow;

// Set projection
chart.projection = new am4maps.projections.Mercator();

function HaritayiYukle(destinationCities, originCities, urunler) {
    // Export
    // chart.exporting.menu = new am4core.ExportMenu();

    // Zoom control
    // chart.zoomControl = new am4maps.ZoomControl();

    // Default to London view
    chart.homeGeoPoint = {
        "longitude": originCities[0].zoomLongitude,
        "latitude": originCities[0].zoomLatitude
    };
    chart.homeZoomLevel = originCities[0].zoomLevel;
    chart.seriesContainer.draggable = false;
    chart.seriesContainer.resizable = true;
    chart.maxZoomLevel = 1;
    chart.chartContainer.wheelable = false;



    var lineSeriesClass = 'MapSplineSeries'; // for temp workaround

    // Texts
    var labelContainer = chart.createChild(am4core.Container);
    labelContainer.isMeasured = false;
    labelContainer.x = 40;
    labelContainer.y = 27;
    labelContainer.zIndex = 10;

    var label = labelContainer.createChild(am4core.Label);
    label.valign = "top";
    label.verticalCenter = "top";
    label.config = {
        cursorOverStyle: [{
            "property": "cursor",
            "value": "pointer",
        }]
    };
    label.events.on("hit", function () {
        mainSeries.mapImages.each(function (originCity) {
            if (currentView && currentView !== originCity.id) {
                originCity.dispatch("hit");
            }
        });
    });

    // The world
    var worldSeries = chart.series.push(new am4maps.MapPolygonSeries());
    worldSeries.useGeodata = true;
    worldSeries.mapPolygons.template.fill = "#dddad7";
    worldSeries.mapPolygons.template.strokeWidth = 0;
    worldSeries.fillOpacity = 1;
    worldSeries.exclude = ["AQ"];

    // Create a circle image in image series template so it gets replicated to all new images
    var mainSeries = chart.series.push(new am4maps.MapImageSeries());
    mainSeries.name = "Origin cities";
    mainSeries.tooltip.background.cornerRadius = 0;

/* 

chartEvents.push({
            "ulke" : data.gorunecekIsim,
            "event" : event,
            "callback" : event.target.events._listeners[2].callback
        });

*/

    var mainSeriesTemplate = mainSeries.mapImages.template;
    mainSeriesTemplate.config = {
        cursorOverStyle: [{
            "property": "cursor",
            "value": "pointer"
        }]
    };
    //mainSeriesTemplate.add
    mainSeriesTemplate.nonScaling = false;
    mainSeriesTemplate.tooltipText = "{gorunecekIsim}";
    mainSeriesTemplate.stroke = "#4D534C";
    mainSeriesTemplate.strokeWidth = 0;
    mainSeriesTemplate.fill = "#4D534C"; 
    mainSeriesTemplate.setStateOnChildren = true;
    mainSeriesTemplate.states.create("hover");

    var mainCircle = mainSeriesTemplate.createChild(am4core.Circle);
    // mainCircle.fill = chart.colors.getIndex(1);
    // mainCircle.strokeWidth = 0;
    //    mainCircle.scale = 1.3;
    //  mainCircle.path = targetSVG;
    mainCircle.radius =  4
 
    mainCircle.fill = am4core.color("#4C8C2B"); // NOKTA Point Color
    mainCircle.nonScaling = false;

    var mainHover = mainCircle.states.create("hover");
    //mainHover.properties.fill = mainCircle.fill;

    mainSeriesTemplate.propertyFields.id = "id";
    mainSeriesTemplate.propertyFields.latitude = "latitude";
    mainSeriesTemplate.propertyFields.longitude = "longitude";

    var currentView;
    mainSeriesTemplate.events.on("hit", function (event) {
        // console.log("event -->",event);
        
        var data = event.target.dataItem.dataContext;
        if (currentView === data.id) return;
        
        
        
        
         showElement(urunler.find((a) => {
            return a.id == data.id
        }));
        sendDestinations(originCities.find((a) => {
            return a.gorunecekIsim == data.gorunecekIsim;
        }));
        
        showSource(data.gorunecekIsim)


        chart.series._values[2]._dataItems._values.forEach((data) => { data.mapImage.visible = false }); // sıfırlamak için
        data.destinations.forEach((dest) => {
            chart.series.values[2]._dataItems.values.forEach((noktalar) => {
                if (noktalar._dataContext.gorunecekIsim == dest) {
                    // console.log("chart ddest-->",dest);
                    
                    noktalar.mapImage.visible = true;
                }
            });
        });
        //chart.series._values[2]._dataItems._values[2]._dataContext.id
        //chart.series._values[2]._dataItems._values.

        currentView = data.id;
        chart.homeGeoPoint = {
            "longitude": data.zoomLongitude,
            "latitude": data.zoomLatitude
        };
        chart.homeZoomLevel = data.zoomLevel;
        chart.zoomToGeoPoint({
            "longitude": data.zoomLongitude,
            "latitude": data.zoomLatitude
        },

            data.zoomLevel, true);
        chart.series.each(function (series) {
            if (series.mapLines !== undefined) {
                series.mapLines.each(function (line) {
                    line.hide();
                });
            }
            if (series.className === lineSeriesClass && series.name !== data.title) {
                series.mapLines.each(function (line) {
                    line.hide();
                });
            }
        });
        event.target.lineSeries.mapLines.each(function (line) {
            line.show();
        });
    });


    // BOŞLUĞA TIKLANDIĞINDA ANLAŞILMASI İÇİN YAZDIĞIM KOD

    worldSeries.events.on("hit", function (event) {
        $("#urunListesi").hide();
        $("#destinations").hide();
        chart.series._values[2]._dataItems._values.forEach((data) => { data.mapImage.visible = false });
        chart.series.each(function (series) {
            if (series.mapLines !== undefined) {
                series.mapLines.each(function (line) {
                    line.hide();
                });
                currentView = "";
            }
        });
        $("ul#location").html("")
    });


    // Create a circle image in image series template so it gets replicated to all new mainS
    var imageSeries = chart.series.push(new am4maps.MapImageSeries());
    imageSeries.name = "Destination cities";
    imageSeries.tooltip.background.cornerRadius = 0;

    var imageSeriesTemplate = imageSeries.mapImages.template;
    imageSeriesTemplate.nonScaling = false;
    imageSeriesTemplate.tooltipText = "{gorunecekIsim}";
    imageSeriesTemplate.fill = "#4D534C"; //f3f2f1
    imageSeriesTemplate.setStateOnChildren = true;
    imageSeriesTemplate.states.create("hover");
    imageSeriesTemplate.visible = false; // ----> destinations visibility !!!!!!! 
    imageSeriesTemplate.propertyFields.id = "id";
    imageSeriesTemplate.propertyFields.latitude = "latitude";
    imageSeriesTemplate.propertyFields.longitude = "longitude";


    var circle = imageSeriesTemplate.createChild(am4core.Circle);
    // circle.scale = 8 / 9; // from 18 to 16... (18 - (18-16))/18 = 16/18 = 8/9
    // circle.path = targetSVG; 
    circle.radius = 3;
    circle.visible = true;
    circle.fill = am4core.color("#4C8C2B"); // 4C8C2B
    circle.nonScaling = false;

    var merkezUlkeler = [];
    imageSeries.events.once("inited", function () {
        mainSeries.mapImages.each(function (originCity) {
            var lineSeries = chart.series.push(new am4maps.MapArcSeries());
            originCity.lineSeries = lineSeries;
            var merkez = originCities.find((a) => { return a.id == originCity.id }).merkez;
            var newcontrolPointDistance = -0.15;
            if (merkez) {
                //console.log(merkez);
                //originCity.fill = am4core.color("#ff0000");
                originCity.children.values[0].fill = am4core.color("#ff0000");
            }
            //lineSeries.id = "id";
            lineSeries.name = originCity.dataItem.dataContext.title;
            lineSeries.autoDispose = true;
            lineSeries.appeared = true;
            lineSeries.mapLines.template.shortestDistance = false; // keep the lines straight
            lineSeries.mapLines.template.stroke = "#4C8C2B"; // ---> çizgilerin rengi
            lineSeries.mapLines.template.strokeWidth = 1.5;
            lineSeries.mapLines.template.visible = false;
            lineSeries.mapLines.template.line.controlPointDistance = (newcontrolPointDistance + newcontrolPointDistance) * -1; //if (newcontrolPointDistance != 0) { (newcontrolPointDistance + newcontrolPointDistance) / -1 } else { newcontrolPointDistance + newcontrolPointDistance};
            lineSeries.mapLines.template.line.controlPointPosition = 0.5;

            originCity.dataItem.dataContext.destinations.forEach(function (destinationCityId) {
                /*
                lineSeries.mapLines.create().imagesToConnect = [originCity.id, destinationCityId];
                */
                var destinationId = destinationCities.find((a)=>{
                    return a.gorunecekIsim == destinationCityId
                })
                if(destinationId == undefined){
                    destinationId = originCities.find((a)=>{
                        return a.gorunecekIsim == destinationCityId
                    })
                };
                if(destinationId != undefined){
                    // console.log("yeni eklendi");
                    destinationId = destinationId.id
                }
                
               //  console.log("__init data : ",originCity.id,destinationId)
                lineSeries.mapLines.create().imagesToConnect = [originCity.id, destinationId];
                // console.log(lineSeries.mapLines);
            });

        });
    });
    mainSeries.data = JSON.parse(JSON.stringify(originCities));
    imageSeries.data = JSON.parse(JSON.stringify(destinationCities));
}


function showSource(str){
    $("ul#location").html("<li>" + str + "</li>");
}

function showElement(object) {
    // console.log(object);
    if (object.urunler.length > 0) {
        $("#urunListesi").css("display", "inherit");
        $("#urunListesi").html("");
        object.urunler.forEach(function (data) {
            if(data.length > 0){
                $("#urunListesi").append("<li>" + data + "</li>");
            }
        })
    }
}

function sendDestinations(object) {
    if (object.destinations.length > 0) {
        // console.log(object);
        $("#destinations").css("display", "inherit");
        $("#destinations").html("");
        object.destinations.forEach(function (data) {
            //destinationCities,originCities
           // console.log("data" + data);
            // console.log(destinations);
            // console.log(originCtx);
            var donecekveri = destinations.find((a) => { return a.gorunecekIsim == data });
            if (donecekveri == undefined) {
                donecekveri = originCtx.find((a) => { return a.gorunecekIsim == data })
            }
            $("#destinations").append("<li>" + donecekveri.gorunecekIsim + "</li>");
        })
    }
}
$(document).ready(function(){ 
    if ($(window).width() < 992) { 
        const rects3=document.getElementsByTagName("rect")
        rects3[rects3.length-1].parentElement.parentElement.style.display="none"
    }
    else{
        const rects3=document.getElementsByTagName("rect")
        rects3[rects3.length-1].parentElement.parentElement.style.display="none"
    }
});

