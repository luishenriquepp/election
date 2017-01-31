(function (app) {
    app.controller('restaurantController', ['$scope', '$routeParams', 'restaurantFactory', function ($scope, $routeParams, restaurantFactory) {
        var id = $routeParams.id;
        $scope.form = {};
        if (id) {
            restaurantFactory.getRestaurantById(id)
            .success(function (data) {
                $scope.restaurant = data;
            });
        }
        $scope.restaurant = {};
        $scope.restaurants = [];
        $scope.save = function () {
            if ($scope.form.$valid) {
                restaurantFactory.create($scope.restaurant)
                .success(function (data) {
                    console.log(data);
                    $scope.response = "Restaurante inserido com sucesso";
                });
            }
        };
        $scope.load = function () {
            restaurantFactory.getRestaurants()
                .success(function (data) {
                    $scope.restaurants = data;
                });
        };
        $scope.edit = function () {
            if ($scope.form.$valid) {
                restaurantFactory.edit($scope.restaurant)
                    .success(function (data) {
                        console.log(data);
                        $scope.response = "Restaurante alterado com sucesso";
                    });
            }
        };
        $scope.remove = function (restaurant) {
            console.log(restaurant);
            restaurantFactory.remove(restaurant)
                .success(function (data) {
                    console.log(data);
                });
        };
    }]);
}(angular.module('electionApp')));