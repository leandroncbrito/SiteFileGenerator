(function (angular) {
    'use strict';

    angular.module('appMain')
        .config(#pagename#Route);

    #pagename#Route.$inject = ['$routeProvider', 'PERMISSION'];

    function #pagename#Route($routeProvider, PERMISSION) {

        var templatePath = "/wwwroot/app/templates/#pagenamelowercase#/";

        $routeProvider
            .when('/', {
                templateUrl: templatePath + 'list.html',
                controller: '#pagename#Controller',
                controllerAs: 'vm',
                resolve: {
                    userPermission: ['AuthorizationService', function (AuthorizationService) {
                        return AuthorizationService.CheckPermission(PERMISSION.READ)
                    }]
                }
            })
            .otherwise({
                redirectTo: '/'
            });
    }

})(angular);