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
            $scope.response = null;
            $scope.fail = null;

            if ($scope.form.$valid) {
                restaurantFactory.create($scope.restaurant)
                .then(function (data) {
                    $scope.response = "Restaurante inserido com sucesso.";
                }, (error) => {
                    $scope.fail = "Restaurante com nome duplicado.";
                });;
            }
        };
        $scope.load = function () {
            restaurantFactory.getRestaurants()
                .success(function (data) {
                    $scope.restaurants = data;
                });
        };
        $scope.edit = function () {
            $scope.response = null;
            $scope.fail = null;

            if ($scope.form.$valid) {
                restaurantFactory.edit($scope.restaurant)
                    .then(function (data) {
                        $scope.response = "Restaurante alterado com sucesso.";
                    }, (error) => {
                        $scope.fail = "Restaurante com nome duplicado.";
                    });;
            }
        };
        $scope.remove = function (restaurant) {
            restaurantFactory.remove(restaurant)
                .success(function (data) {
                    console.log(data);
                });
        };
    }]);
}(angular.module('electionApp')));