app.controller('storiesCtrl', ['$scope', 'ApiService', '$window',
    function ($scope, ApiService, $window) {
        $scope.Stories = [];
        var groups = ApiService.getAll('/api/story/mystories').then(function (response) {
            if (response.data !== '') {
                for (var i = 0; i < response.data.length; i++)
                {
                    var date = new Date(response.data[i].PostedOn);


                    $scope.Stories.push({
                        id: response.data[i].Id,
                        title: response.data[i].Title,
                        content: response.data[i].Content,
                        description: response.data[i].Description,
                        title: response.data[i].Title,
                        postedOn: date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear() + " " + date.getHours() + ":" + date.getMinutes()
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