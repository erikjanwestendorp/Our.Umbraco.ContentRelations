(function () {
    'use strict';

    function contentRelationsSettingsController($scope) {

        var vm = this;

        console.log("content relations settings");
        vm.loading = true;

        function init() {

            vm.loading = false;
        }

        init();

    }

    angular.module('umbraco')
        .controller('contentRelationsSettingsController', contentRelationsSettingsController);
})();