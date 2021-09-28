(function () {
    'use strict';

    function contentRelationsSettingsController($scope, contentRelationsUserGroupsResource, notificationsService, packageInformationResource) {

        var vm = this;

        
        vm.loading = true;
        vm.saving = false;
        
        vm.settings = {};

        vm.deleteGroups = [];
        
        vm.packageInfo = {};

        vm.toggleDeletePermission = toggleDeletePermission;
        vm.saveSettings = saveSettings;
        
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

                    contentRelationsUserGroupsResource.getConfiguration().then(function (data) {
                        vm.settings = data.content;
                        
                        applySelection(vm.settings.delete.usergroups, vm.deleteGroups);
                        
                    });
                }
                
            });

    

            vm.loading = false;
        }

        function applySelection(selectedGroups, allGroups) {
            for (var i = 0; i < allGroups.length; i++) {
                var isChecked = _.contains(selectedGroups, allGroups[i].alias);
                allGroups[i].checked = isChecked;
            }
        };

        function toggleValue(value) {
            return !value;
        }

        function toggleDeletePermission(index) {
            vm.deleteGroups[index].checked = toggleValue(vm.deleteGroups[index].checked);
        }

        function saveSettings() {
            vm.saving = true;

            // TODO SAVE Settings
            

        }

        init();

    }

    angular.module('umbraco')
        .controller('contentRelationsSettingsController', contentRelationsSettingsController);
})();