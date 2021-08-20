(function () {
    'use strict';

    function contentRelationsController($scope, $routeParams, contentRelationsResource, editorState) {

        var vm = this;
        vm.navigate = navigate;

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

        function navigate(nodeId) {
            window.location = "/umbraco/#/content/content/edit/" + nodeId;
        }
    }

    angular.module('umbraco')
        .controller('contentRelationsController', contentRelationsController);
})();