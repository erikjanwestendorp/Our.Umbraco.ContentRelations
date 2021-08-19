(function () {
    'use strict';

    function contentRelationsController($scope, $routeParams, contentRelationsResource) {

        var vm = this;

        vm.isLoading = true;
        
        getRelations();

        vm.relations = [];

        function getRelations() {

            contentRelationsResource.getById($routeParams.id).then(function (data) {
                vm.relations = data;
                console.log(data);
                vm.isLoading = false;
            });
        }
    }

    angular.module('umbraco')
        .controller('contentRelationsController', contentRelationsController);
})();