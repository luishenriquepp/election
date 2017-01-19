(function (app) {
    app.controller('loginController', ['$scope', 'localStorageService', 'loginFactory', function ($scope, localStorageService, loginFactory) {
        $scope.authenticateExternalProvider = function(provider) {
            var externalProviderUrl = '/api/Account/ExternalLogin?provider=' + provider + '&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A50924%2F&state=9pTqtZoX71z9oEp37K10zcIXbrPxdVPf4NyW7Yg8scc1';
            window.location.href = externalProviderUrl;
        }

        $scope.logout = function () {
            loginFactory.Logout()
                .then(function () {
                    alert('logout');
                });
        }

        $scope.CheckLocationHash = function () {
            if (location.hash && location.hash.length > 2) {
                if (location.hash.split('access_token=')) {
                    $scope.accessToken = location.hash.split('access_token=')[1].split('&')[0];
                    if ($scope.accessToken) {
                        loginFactory.CheckRegistration($scope.accessToken).then(function (response) {
                            if (response.data.HasRegistered) {
                                localStorageService.set('authorizationData', { token: $scope.accessToken, userName: response.userName });
                                location.href = '/';
                            } else {
                                loginFactory.SignupExternal($scope.accessToken).then(function (response) {
                                    localStorageService.set('authorizationData', { token: $scope.accessToken, userName: response.userName });
                                    location.href = '/';
                                }, function(err) {
                                    alert(err.data.Message);
                                })
                            }
                        })
                    }
                }
            }
        }
        $scope.CheckLocationHash();
    }]);
}(angular.module('electionApp')));