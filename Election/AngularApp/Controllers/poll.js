(function (app) {
    app.controller('pollController', ['$scope', 'pollFactory','voteFactory', function ($scope, pollFactory, voteFactory) {
        $scope.title = "Selecione um restaurante";
        $scope.disabled = true;
        $scope.enabled = true;
        $scope.selected = '';
        $scope.vote = { 'Id': 0, 'RestaurantId': 0, 'UserToken': 0, 'Poll_Id': 0 };
        $scope.available = [];

        $scope.availableRestaurants = [];
        $scope.load = function () {
            pollFactory.init()
            .success(function (data) {
                $scope.enabled = !data.Voted && canVote();
                $scope.available = data.ElectionVotes;
            });
        };
        $scope.click = function (restaurant) {
            $scope.title = "Votar em " + restaurant.Name;
            $scope.disabled = false;
            $scope.selected = restaurant.Id;
            $scope.vote.RestaurantId = restaurant.Id;
        }
        $scope.votar = function() {
            console.log($scope.vote);
            voteFactory.create($scope.vote)
            .success(function (data) {
                $scope.voted = true;
                $scope.available.forEach(function (el) {
                    if (el.Restaurant.Id == $scope.vote.RestaurantId) {
                        el.Votes++;
                    }
                })
            });
        }
        var canVote = function () {
            var date = new Date();
            if (date.getHours() >= 7 && date.getHours() < 12)
                return true;
        }
    }]);
}(angular.module('electionApp')));