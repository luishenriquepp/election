(function (app) {
    var config = function ($routeProvider) {
        $routeProvider
        .when("/",
            { templateUrl: "/Views/asd.html" })
        .otherwise(
           { redirecTo: "/" });
    };
    app.config(config);
}(angular.module("electionApp")));