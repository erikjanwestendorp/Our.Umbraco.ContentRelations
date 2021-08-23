(function () {
    'use strict';

    function contentRelationsController($scope, $routeParams, contentRelationsResource, editorState, currentUserResource, userService) {

        var vm = this;

        vm.navigate = navigate;
        vm.navigateToRelationType = navigateToRelationType;

        vm.isLoading = true;

        vm.permissions = {
            canBrowseSettingsSection: false
        };

        
        init();

        vm.relations = [];

      

        function init() {
            getRelations();
            setPermissions();
        }


        function getRelations() {

            contentRelationsResource.getById($routeParams.id).then(function (data) {
                vm.relations = data;
                console.log(data);
                vm.isLoading = false;
            });

        }

        function setPermissions() {

            userService.getCurrentUser().then(function(user) {
                if (user.allowedSections.includes("settings")) {
                    vm.permissions.canBrowseSettingsSection = true;
                }
            });

        }

        function navigate(nodeId) {
            window.location = "/umbraco/#/content/content/edit/" + nodeId;
        }

        function navigateToRelationType(relationTypeId) {
            window.location = "/umbraco/#/settings/relationTypes/edit/" + relationTypeId;
        }
    }

    angular.module('umbraco')
        .controller('contentRelationsController', contentRelationsController);
})();