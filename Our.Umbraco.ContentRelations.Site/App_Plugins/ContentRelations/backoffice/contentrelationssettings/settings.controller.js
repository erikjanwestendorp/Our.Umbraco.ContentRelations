﻿(function () {
    'use strict';

    function contentRelationsSettingsController($scope, contentRelationsUserGroupsResource, notificationsService, packageInformationResource) {

        var vm = this;

        
        vm.loading = true;
        vm.deleteGroups = [];

        vm.packageInfo = {};
        
        function init() {
            packageInformationResource.getInfo().then(function(data) {
                vm.packageInfo = data.content;
            });

            contentRelationsUserGroupsResource.getAll().then(function (data) {
                
                if (!data.succeeded) {
                    notificationsService.error(data.message.category, data.message.message);
                }

                if (data.succeeded) {
                    vm.deleteGroups = data.content;
                }
                
            });

            vm.loading = false;
        }

        init();

    }

    angular.module('umbraco')
        .controller('contentRelationsSettingsController', contentRelationsSettingsController);
})();