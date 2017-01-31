(function (app) {
    app.factory('restaurantFactory', ['$http', function ($http) {
        var factory =  {
            getRestaurants: getRestaurants,
            getRestaurantById: getRestaurantById,
            create: create,
            edit: edit,
            remove: remove
        };
        return factory;
        function getRestaurants() {
            return $http.get('api/restaurants');
        };
        function getRestaurantById(id) {
            return $http.get('api/restaurants/' + id);
        };
        function create(restaurant) {
            return $http.post('api/restaurants', restaurant);
        };
        function edit(restaurant) {
            return $http.put('api/restaurants/' + restaurant.Id, restaurant);
        };
        function remove(restaurant) {
            return $http.delete('api/restaurants/' + restaurant.Id);
        };
    }]);
}(angular.module('electionApp')))