app.controller('loginCtrl', ['$scope', 'ApiService', '$window', 
    function ($scope, ApiService, $window) {

        $scope.Login = function () {


            var loginInfo = {
                Name: $scope.name,
                Password: $scope.password,
            }
            var apiRoute = '/api/user/login';
            var loginRes = ApiService.post(apiRoute, loginInfo);
            loginRes.then(function (response) {
                if (response.data.success === true) {
                    $window.location.href= '/';
                } else {
                    alert(response.data.message);
                }

            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.Logout = function () {
            var apiRoute = '/api/user/logout';
            var logoutRes = ApiService.post(apiRoute, undefined);
            logoutRes.then(function (response) {
                if (response.data.success === true) {
                    $window.location.href = '/';

                } else {
                    alert(response.data.message);
                }
            });
        }

    }]);