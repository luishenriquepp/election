﻿(function (app) {
    app.controller('pollController', ['$scope', 'pollFactory','voteFactory', function ($scope, pollFactory, voteFactory) {
        $scope.title = 'Escolha aonde você quer almoçar hoje!';
        $scope.subtitle = 'Restaurantes disponíveis';
        $scope.btnValue = 'Selecione um restaurante';
        $scope.disabled = true;
        $scope.enabled = true;
        $scope.selected = '';
        $scope.vote = { 'Id': 0, 'RestaurantId': 0, 'UserToken': 0, 'Poll_Id': 0 };
        $scope.available = [];
        $scope.message = false;

        $scope.load = function () {
            pollFactory.init()
            .success(function (data) {
                $scope.enabled = showButton(data.Voted, data.WinnerId, canVote());
                $scope.available = data.ElectionVotes;
                if (data.WinnerId) {
                    $scope.title = 'Votação encerrada.';
                    $scope.available.forEach(function (el) {
                        if (el.Restaurant.Id == data.WinnerId) {
                            $scope.subtitle = 'Restaurante vencedor: ' + el.Restaurant.Name;
                            return;
                        }
                    })
                } else if (data.Voted) {
                    $scope.title = 'Aguarde o andamento da votação.';
                    $scope.subtitle = '';
                }
            });
        };
        $scope.click = function (restaurant) {
            $scope.btnValue = 'Votar em ' + restaurant.Name;
            $scope.disabled = false;
            $scope.selected = restaurant.Id;
            $scope.vote.RestaurantId = restaurant.Id;
        }
        $scope.votar = function() {
            $scope.message = false;
            voteFactory.create($scope.vote)
            .then(function (data) {
                $scope.enabled = false;
                $scope.available.forEach(function (el) {
                    if (el.Restaurant.Id == $scope.vote.RestaurantId) {
                        el.Votes++;
                    }
                })
            }, function (err) {
                console.log(err);
                $scope.message = true;
                $scope.response = err.data.ExceptionMessage;
            });
        }
        var canVote = function () {
            var date = new Date();
            if (date.getHours() >= 7 && date.getHours() < 12)
                return true;
        }
        var showButton = function (hasVoted, winnerId, canvote) {
            if (winnerId) {
                return false;
            } else if (hasVoted) {
                return false;
            } else if (canVote()) {
                return true;
            }
        }
    }]);
}(angular.module('electionApp')));