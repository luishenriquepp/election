(function (app) {
    app.factory('voteFactory', ['$http', function ($http) {
        var getVotes = function () {
            return $http.get('api/votes');
        };
        var getVoteById = function (id) {
            return $http.get('api/votes/' + id);
        };
        var create = function (vote) {
            return $http.post('api/votes', vote);
        };
        var edit = function (vote) {
            return $http.put('api/votes' + vote.Id, vote);
        };
        var remove = function (vote) {
            return $http.delete('api/votes/' + vote.Id);
        };
        return {
            getVotes: getVotes,
            getVoteById: getVoteById,
            create: create,
            edit: edit,
            remove: remove
        };
    }]);
}(angular.module('electionApp')))