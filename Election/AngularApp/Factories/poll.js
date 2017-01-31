(function (app) {
    app.factory('pollFactory', ['$http', function ($http) {
        var factory =  {
            getPoll: getPoll,
            getPollById: getPollById,
            create: create,
            init: init
        };
        return factory;
        function getPoll() {
            return $http.get('api/polls');
        };
        function getPollById(id) {
            return $http.get('api/polls/' + id);
        };
        function create() {
            return $http.post('api/polls');
        };
        function init() {
            return $http.get("api/polls");
        }
    }]);
}(angular.module('electionApp')))