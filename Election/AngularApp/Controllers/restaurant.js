(function (app) {
    app.controller('restaurantController', ['$scope', '$routeParams', 'restaurantFactory', function ($scope, $routeParams, restaurantFactory) {
        var id = $routeParams.id;
        if (id) {
            restaurantFactory.getRestaurantById(id)
            .success(function (data) {
                $scope.restaurant = data;
            });
        }

        $scope.restaurant = {};
        $scope.restaurants = [];
        $scope.save = function () {
            restaurantFactory.create($scope.restaurant)
                .success(function (data) {
                    console.log(data);
                });
        };
        $scope.load = function () {
            restaurantFactory.getRestaurants()
                .success(function (data) {
                    $scope.restaurants = data;
                });
        };
        $scope.edit = function () {
            restaurantFactory.edit($scope.restaurant)
                .success(function (data) {
                    console.log(data);
                });
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