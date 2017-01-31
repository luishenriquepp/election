(function (app) {
    app.factory('voteFactory', ['$http', function ($http) {
        var factory =  {
            getVotes: getVotes,
            getVoteById: getVoteById,
            create: create,
            edit: edit,
            remove: remove
        };
        return factory;
        function getVotes() {
            return $http.get('api/votes');
        };
        function getVoteById(id) {
            return $http.get('api/votes/' + id);
        };
        function create(vote) {
            return $http.post('api/votes', vote);
        };
        function edit(vote) {
            return $http.put('api/votes' + vote.Id, vote);
        };
        function remove(vote) {
            return $http.delete('api/votes/' + vote.Id);
        };
    }]);
}(angular.module('electionApp')))