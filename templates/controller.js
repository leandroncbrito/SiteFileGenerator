(function (angular) {
    'use strict';

    angular
        .module('appMain')
        .controller('#pagename#Controller', #pagename#Controller);

    #pagename#Controller.$inject = ['$rootScope', '#pagename#Model', '$log', 'notification', 'util'];

    function #pagename#Controller($rootScope, #pagename#Model, $log, notification, util) {
        /* jshint validthis:true */
        var vm = this;
        
		//Objects        
        vm.#pagenamelowercase#s = [];
        vm.#pagenamelowercase# = {};
        vm.#pagenamelowercase#sFiltered = [];

        //Functions
        vm.remove = remove;
        vm.confirmDelete = confirmDelete;
        vm.updateFilteredList = updateFilteredList;
		
		$rootScope.breadcrumbs = [{ title: "#pagenameptbr#", active: true }];
		
		(function() {            
            get();
        })();
		
		function get() {
            vm.promise = #pagename#Model.Get().then(function (response) {

                vm.#pagenamelowercase#s = response.data;
                vm.#pagenamelowercase#sFiltered = response.data;

            }).catch(function (e) {
                notification.error("Erro ao carregar #pagenameptbr#s.");
                $log.error(e.data);
            });
        }

        function confirmDelete(item) {
            vm.#pagenamelowercase# = {};
            vm.#pagenamelowercase# = item;
        }

        function remove() {

            // Validar se existe repasse em uso
            vm.promise = #pagename#Model.Delete({ id: vm.#pagenamelowercase#.id }).then(function (response) {

                var index = vm.#pagenamelowercase#s.map(function (e) { return e.id; }).indexOf(vm.#pagenamelowercase#.id);

                if (index !== -1)
                    vm.#pagenamelowercase#s.splice(index, 1);

                notification.success(response.data);

                updateFilteredList();

            }).catch(function (e) {
                if (angular.isArray(e.data))
                    notification.alert(e.data[0].errorMessage);
                else
                    notification.error(e.data);
                $log.error(e.data);

            });
        }

        function updateFilteredList() {
            
            return vm.#pagenamelowercase#sFiltered = vm.#pagenamelowercase#s.filter(function (model) {

                if (typeof vm.resourceTypeId !== 'undefined' && vm.resourceTypeId !== null && typeof vm.#pagenamelowercase#Name !== 'undefined' && vm.#pagenamelowercase#Name !== null) {
                    return model.resourceTypeId === vm.resourceTypeId && _.includes(model.name.toLowerCase(), vm.#pagenamelowercase#Name.toLowerCase());
                }

                if (typeof vm.resourceTypeId !== 'undefined' && vm.resourceTypeId !== null) {
                    return model.resourceTypeId === vm.resourceTypeId;
                }
                if (typeof vm.#pagenamelowercase#Name !== 'undefined' && vm.#pagenamelowercase#Name !== null) {
                    return _.includes(model.name.toLowerCase(), vm.#pagenamelowercase#Name.toLowerCase());
                }
                return vm.#pagenamelowercase#s;
            });

        }
		
    }

})(angular);