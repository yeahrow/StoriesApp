app.controller('groupsCtrl', ['$scope', 'ApiService',
    function ($scope, ApiService) {
        $scope.btnText = "Save";
        $scope.Groups = [];
        var groups = ApiService.getAll('/api/group').then(function (response) {
            if (response.data !== '') {

                for (var i = 0; i < response.data.length; i++) {
                    $scope.Groups.push({
                        id: response.data[i].Id,
                        name: response.data[i].Name,
                        description: response.data[i].Description,
                        usersCount: response.data[i].UsersCount,
                        storiesCount: response.data[i].StoriesCount
                    });
                }

            } else {
                //alert(response.data.message);
            }

        }, function (error) {
            if (error.status == 401) {
                $window.location.href = '#/login';
            }
        });
        
    }]);