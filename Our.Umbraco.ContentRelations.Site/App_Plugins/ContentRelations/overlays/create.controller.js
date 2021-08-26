(function () {
    'use strict';

    function createRelationController($scope, $routeParams, contentRelationsResource) {

        var vm = this;
        vm.save = save;
        vm.close = close;

        vm.node = null;
        vm.comment = null;

        vm.dialogTreeApi = {};

        vm.onTreeInit = function () {
            vm.dialogTreeApi.callbacks.treeNodeSelect(nodeSelectHandler);
        };

        function nodeSelectHandler(args) {
            if (args && args.event) {
                args.event.preventDefault();
                args.event.stopPropagation();
            }

            if (vm.node) {
                //un-select if there's a current one selected
                vm.node.selected = false;
            }

            vm.node = args.node;
            vm.node.selected = true;
        };

        function save() {
            console.log(vm.node);
            console.log(vm.comment);
            

            var data = {
                parentId: $routeParams.id,
                childId: vm.node.id,
                comment: vm.comment
            }

            contentRelationsResource.save(data).then(function (response) {
                $scope.model.submit(response);
            });

        };

        function close() {
            $scope.model.close();
        };
    }

    angular.module('umbraco')
        .controller('ContentRelations.Overlays.CreateController', createRelationController);
})();