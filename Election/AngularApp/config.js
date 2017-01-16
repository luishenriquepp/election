(function (app) {
    var config = function ($routeProvider) {
        $routeProvider
        .when("/",
            { templateUrl: "/client/html/index.html" })
        .when("/restaurantes",
            { templateUrl: "/client/html/restaurant/index.html", controller: "restaurantController" })
        .when("/restaurantes/create",
           { templateUrl: "/cliente/html/restaurant/create.html", controller: "restaurantController" })
        .when("/restaurantes/edit/:id",
           { templateUrl: "/cliente/html/restaurant/edit.html", controller: "restaurantController", })
        .otherwise(
           { redirecTo: "/" });
    };
    app.config(config);
}(angular.module("electionApp")));