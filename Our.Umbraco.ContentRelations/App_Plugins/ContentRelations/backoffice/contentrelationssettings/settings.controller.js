(function () {
    'use strict';

    function contentRelationsSettingsController($scope, userGroupsResource) {

        var vm = this;

        console.log("content relations settings");
        vm.loading = true;

        function init() {

            userGroupsResource.getAll().then(function (data) {
                console.log(data);
            });

            vm.loading = false;
        }

        init();

    }

    angular.module('umbraco')
        .controller('contentRelationsSettingsController', contentRelationsSettingsController);
})();