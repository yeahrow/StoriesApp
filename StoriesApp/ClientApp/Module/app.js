var app;
(function () {
    'use strict';
    app = angular.module('storiesapp', ['ngRoute']);

    app.config(function ($routeProvider, $locationProvider) {
        $routeProvider
			.when('/stories', {
			    templateUrl: 'clientapp/views/stories.html',
			    controller: 'storiesCtrl'
			})
			.when('/groups', {
			    templateUrl: 'clientapp/views/groups.html',
			    controller: 'groupsCtrl'
			})
			.when('/login', {
			    templateUrl: 'clientapp/views/login.html',
			    controller: 'loginCtrl'
			})
			.when('/add', {
			    templateUrl: 'clientapp/views/story.html',
			    controller: 'storyCtrl'
			})
			.when('/update/:id', {
			    templateUrl: 'clientapp/views/story.html',
			    controller: 'storyCtrl'
			})
			.when('/view/:id', {
			    templateUrl: 'clientapp/views/storyview.html',
			    controller: 'storyCtrl'
			})
            .otherwise({ redirectTo: '/stories' });
        //$locationProvider.html5Mode({
        //    enabled: true,
        //    requireBase: false
        //});
    });

})();