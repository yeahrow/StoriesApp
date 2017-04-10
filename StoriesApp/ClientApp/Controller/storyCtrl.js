app.controller('storyCtrl', ['$scope', 'ApiService', '$routeParams', '$window',
    function ($scope, ApiService, $routeParams, $window) {
        
        $scope.Groups = [];
        var groups = ApiService.getAll('/api/group').then(function (response) {
            if (response.data !== '') {

                for (var i = 0; i < response.data.length; i++) {
                    $scope.Groups.push({
                        id: response.data[i].Id,
                        name: response.data[i].Name,
                        selected: false
                    });
                }
                if ($routeParams.id != undefined) {
                    ApiService.getAll('/api/story/' + $routeParams.id).then(function (response) {
                        if (response.data !== '') {
                            $scope.id = response.data.Id;
                            $scope.title = response.data.Title;
                            $scope.description = response.data.Description;
                            $scope.content = response.data.Content;

                            for (var i = 0; i < response.data.Groups.length; i++) {
                                for (var j = 0; j < $scope.Groups.length; j++) {
                                    if ($scope.Groups[j].id == response.data.Groups[i].Id) {
                                        $scope.Groups[j].selected = true;
                                    }
                                }
                            }
                        }

                    }, function (error) {
                        console.log("Error: " + error);
                    });
                }

            } else {
            }

        }, function (error) {
            $window.location.href = '/';
        });

        

        $scope.SaveUpdate = function () {
            var selectedGroups = [];

            for (var i = 0; i < $scope.Groups.length; i++) {
                if ($scope.Groups[i].selected) {
                    selectedGroups.push($scope.Groups[i].id);
                }
            }

            var story = {
                Id: $scope.id,
                Title: $scope.title,
                Description: $scope.description,
                Content: $scope.content,
                GroupIds: selectedGroups
            }

            var apiRoute = '/api/story';

            if (story.Id !== undefined) {
                var saveStory = ApiService.patch(apiRoute, story);
                saveStory.then(function (response) {
                    if (response.data.success === true) {
                        $window.location.href = '/';
                    } else {
                        alert(response.data.message);
                    }
                });
            }
            else {
                var saveStory = ApiService.post(apiRoute, story);
                saveStory.then(function (response) {
                    if (response.data.success === true) {
                        $window.location.href = '/';

                    } else {
                        alert(response.data.message);
                    }
                });
            }
            
        }

        $scope.Clear = function () {
            $scope.title = "";
            $scope.description = "";
            $scope.content = "";
        }

        $scope.go = function (path) {
            $location.path(path);
        };

    }]);