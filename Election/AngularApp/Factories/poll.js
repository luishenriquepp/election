(function (app) {
    app.factory('pollFactory', ['$http', function ($http) {
        var getPoll = function () {
            return $http.get('api/polls');
        };
        var getPollById = function (id) {
            return $http.get('api/polls/' + id);
        };
        var create = function () {
            return $http.post('api/polls');
        };
        var init = function () {
            return $http.get("api/polls");
        }
        return {
            getPoll: getPoll,
            getPollById: getPollById,
            create: create,
            init: init
        };
    }]);
}(angular.module('electionApp')))