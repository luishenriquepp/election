(function (app) {
    app.factory('restaurantFactory', ['$http', function ($http) {
        var getRestaurants = function () {
            return $http.get('api/restaurants');
        };
        var getRestaurantById = function (id) {
            return $http.get('api/restaurants/' + id);
        };
        var create = function (restaurant) {
            return $http.post('api/restaurants', restaurant);
        };
        var edit = function (restaurant) {
            return $http.put('api/restaurants' + restaurant.Id, restaurant);
        };
        var remove = function (restaurant) {
            return $http.delete('api/restaurants/' + restaurant.Id);
        };
        return {
            getRestaurants: getRestaurants,
            getRestaurantById: getRestaurantById,
            create: create,
            edit: edit,
            remove: remove
        };
    }]);
}(angular.module('electionApp')))