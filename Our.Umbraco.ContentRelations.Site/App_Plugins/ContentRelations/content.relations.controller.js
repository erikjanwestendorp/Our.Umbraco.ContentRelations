(function () {
    'use strict';

    function contentRelationsController($scope, $routeParams, contentRelationsResource, userService, editorService) {

        var vm = this;

        vm.navigate = navigate;
        vm.navigateToRelationType = navigateToRelationType;
        vm.addRelation = addRelation;
        vm.deleteRelation = deleteRelation;

        vm.isLoading = true;

        vm.permissions = {
            canBrowseSettingsSection: false,
            canAddRelations: false,
            canDeleteRelations: false
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

            userService.getCurrentUser().then(function (user) {

                console.log(user);
                if (user.allowedSections.includes("settings")) {
                    vm.permissions.canBrowseSettingsSection = true;
                }

                if (user.allowedSections.includes("content")) {
                    vm.permissions.canAddRelations = true;
                }

                if (user.userGroups.includes("admin")) {
                    vm.permissions.canDeleteRelations = true;
                }
            });

        }

        function navigate(nodeId) {
            window.location = "/umbraco/#/content/content/edit/" + nodeId;
        }

        function navigateToRelationType(relationTypeId) {
            window.location = "/umbraco/#/settings/relationTypes/edit/" + relationTypeId;
        }

        function addRelation() {

            var dialog = {
                view: "/App_Plugins/ContentRelations/overlays/create.html",
                size: "small",
                submit: function (model) {
                    editorService.close();
                },
                close: function () {
                    editorService.close();
                }
            };

            editorService.open(dialog);

        }

        function deleteRelation(relation, event) {
            contentRelationsResource.remove(relation);
        }
    }

    angular.module('umbraco')
        .controller('contentRelationsController', contentRelationsController);
})();