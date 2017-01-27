(function (app) {
    app.controller('loginController', ['$scope', 'localStorageService', 'loginFactory', function ($scope, localStorageService, loginFactory) {
        $scope.auth = false;

        $scope.authenticateExternalProvider = function (provider) {
            var externalProviderUrl = '/api/Account/ExternalLogin?provider=' + provider + '&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A50924%2F&state=9pTqtZoX71z9oEp37K10zcIXbrPxdVPf4NyW7Yg8scc1';
            window.location.href = externalProviderUrl;
        }

        $scope.logout = function () {
            loginFactory.Logout()
                .then(function () {
                    localStorageService.cookie.clearAll();
                    $scope.auth = false;
                });
        }

        $scope.CheckLocationHash = function () {
            if (location.hash && location.hash.length > 2) {
                if (location.hash.split('access_token=')) {
                    $scope.accessToken = location.hash.split('access_token=')[1].split('&')[0];
                    if ($scope.accessToken) {
                        loginFactory.CheckRegistration($scope.accessToken).then(function (response) {
                            if (response.data.HasRegistered) {
                                console.log(response);
                                localStorageService.set('authorizationData', { token: $scope.accessToken, userName: response.data.Email });
                                $scope.GetAuth();
                                window.location = '/';
                            } else {
                                loginFactory.SignupExternal($scope.accessToken).then(function (response) {
                                    console.log(response);
                                    localStorageService.set('authorizationData', { token: $scope.accessToken, userName: response.data.Email });
                                    $scope.GetAuth();
                                    window.location = '/';
                                }, function(err) {
                                    alert(err.data.Message);
                                })
                            }
                        })
                    }
                }
            }
        }

        $scope.GetAuth = function () {
            var cookie = localStorageService.get('authorizationData');
            if (cookie) {
                console.log(cookie);
                $scope.auth = true;
                $scope.email = cookie.userName;
            }
        }   
        $scope.CheckLocationHash();
        $scope.GetAuth();
    }]);
}(angular.module('electionApp')));