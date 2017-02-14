(function (angular) {
    'use strict';

    angular
        .module('appMain')
        .factory('#pagename#Model', #pagename#Model);

    #pagename#Model.$inject = ['$http'];

    function #pagename#Model($http) {

        var apiUrl = '/#pagename#/';

        var service = {
            'Save': Save,
            'Delete': Delete,
            'Get': Get
        };

        return service;

        function Save(params) {
            return $http.post(apiUrl + "Save", params);
        }

        function Delete(params) {
            return $http.post(apiUrl + "Delete", params)
        }

        function Get() {
            return $http.get(apiUrl + "Get");
        }
		
    }
})(angular);