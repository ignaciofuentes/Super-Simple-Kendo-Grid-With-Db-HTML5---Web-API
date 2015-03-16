(function (global) {
    var app = global.app = global.app || {};
    document.addEventListener('deviceready', function () {
        navigator.splashscreen.hide();
        $(document.body).height(window.innerHeight);
    }, false);

    app.application = new kendo.mobile.Application(document.body, { skin: "flat", initial: "list.html", useNativeScrolling: true });

    app.gamesDataSource = {};

})(window);

var myVm = new kendo.observable({
    car: {
        Id: 0,
        Name: ""
    },
    saveCar: function () {
        app.gamesDataSource.add(this.car);
        app.gamesDataSource.sync();
        app.application.navigate("list.html");
    }

});


function mobileListViewFiltering() {
    var url = "/api";
    app.gamesDataSource = new kendo.data.DataSource({
        transport: {
            read: { url: url + "/Cars", type: "GET" },
            update: {
                url: function (options) {
                    return url + "/Cars/" + options.Id;
                },
                type: "PUT"
            },
            create: { url: url + "/Cars", type: "POST" },
            destroy: {
                url: function (options) {
                    return url + "/Cars/" + options.Id;
                }, type: "DELETE"
            }

        },
        schema: {
            model: {
                id: "Id",
                fields: {
                    Id: { type: "number", editable: false },
                    Name: { type: "string" }
                }
            }
        }
    });




    $("#listview").kendoMobileListView({
        dataSource: app.gamesDataSource,
        template: $("#mobile-listview-filtering-template").text()
    });
}
$("#form").submit(function () {
    return false;

});

function deleteGame(e) {
    console.log("A game is about to be deleted!!!");
    var gameToDelete = app.gamesDataSource.get(e.context);
    app.gamesDataSource.remove(gameToDelete);
    app.gamesDataSource.sync();
}