(function (app) {
    var config = function ($routeProvider) {
        $routeProvider
        .when("/",
            { templateUrl: "/client/html/index.html", controller: "pollController" })
        .when("/restaurantes",
            { templateUrl: "/client/html/restaurant/index.html", controller: "restaurantController" })
        .when("/restaurantes/create",
           { templateUrl: "/client/html/restaurant/create.html", controller: "restaurantController" })
        .when("/restaurantes/edit/:id",
           { templateUrl: "/client/html/restaurant/edit.html", controller: "restaurantController", })
        .otherwise(
           { redirecTo: "/" });
    };
    app.config(config);
}(angular.module("electionApp")));