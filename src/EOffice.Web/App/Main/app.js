(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',
        'ngMaterial',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: abp.appPath + '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in EOfficeNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: abp.appPath + '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in EOfficeNavigationProvider
                })
                .state('questions', {
                    url: '/questions',
                    templateUrl: abp.appPath + 'App/Main/views/questions/index.cshtml',
                    menu: 'Questions' //Matches to name of 'Questions' menu in EOfficeNavigationProvider
                })
                .state('questionDetail', {
                    url: '/questions/:id',
                    templateUrl: abp.appPath + 'App/Main/views/questions/detail.cshtml',
                    menu: 'Questions' //Matches to name of 'Questions' menu in EOfficeNavigationProvider
                })
                .state('users', {
                    url: '/users',
                    templateUrl: abp.appPath + 'App/Main/views/users/index.cshtml',
                    menu: 'Users' //Matches to name of 'Users' menu in EOfficeNavigationProvider
                });
        }
    ]);
})();