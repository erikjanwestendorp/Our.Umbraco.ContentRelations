(function () {
    'use strict';

    function contentRelationsSettingsController($scope, contentRelationsUserGroupsResource) {

        var vm = this;

        
        vm.loading = true;
        vm.deleteGroups = [];
        
        function init() {

            contentRelationsUserGroupsResource.getAll().then(function (data) {
                vm.deleteGroups = data;
            });

            vm.loading = false;
        }

        init();

    }

    angular.module('umbraco')
        .controller('contentRelationsSettingsController', contentRelationsSettingsController);
})();