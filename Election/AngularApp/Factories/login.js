(function (app) {
    app.factory('loginFactory', ['localStorageService', '$http', '$q', function (localStorageService,$http, $q) {
        var fac = {};
        fac.CheckRegistration = function (token) {
            var deferred = $q.defer();
            var request = {
                method: 'get',
                url: '/api/Account/UserInfo',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + token
                }
            }
            return $http(request);
        }
        fac.SignupExternal = function (token) {
            var request = {
                method: 'post',
                url: '/api/Account/RegisterExternal',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + token
                },
                data: {}
            }
            return $http(request);
        }
        fac.Logout = function () {
            var request = {
                method: 'post',
                url: '/api/Account/Logout'
            }
            return $http(request);
        }
        return fac;
    }]);
}(angular.module('electionApp')))