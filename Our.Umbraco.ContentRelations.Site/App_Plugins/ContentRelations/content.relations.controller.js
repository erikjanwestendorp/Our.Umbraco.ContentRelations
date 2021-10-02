(function () {
    'use strict';

    function contentRelationsController($scope, $routeParams, contentRelationsResource, userService, editorService, overlayService, localizationService, notificationsService, contentRelationsUserGroupsResource) {

        var vm = this;

        vm.navigate = navigate;
        vm.navigateToRelationType = navigateToRelationType;
        vm.addRelation = addRelation;
        vm.deleteRelation = deleteRelation;

        vm.isAdmin = false;
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
                vm.isLoading = false;
            });

        }

        function setPermissions() {
            
            userService.getCurrentUser().then(function (user) {
                
                if (user.allowedSections.includes("settings")) {
                    vm.permissions.canBrowseSettingsSection = true;
                }

                if (user.allowedSections.includes("content")) {
                    vm.permissions.canAddRelations = true;
                }

                contentRelationsUserGroupsResource.getConfiguration().then(function(config) {
                    var currentUserGroups = user.userGroups;
                    var configurationDeleteGroups = config.content.delete.userGroups;

                    for (var i = 0; i < currentUserGroups.length; i++) {
                        vm.permissions.canDeleteRelations = configurationDeleteGroups.includes(currentUserGroups[i]);

                        if (vm.permissions.canDeleteRelations) {
                            break;
                        }
                    }
                });


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
                    
                    if (model && !model.succeeded) {
                        notificationsService.error(model.message.category, model.message.message);
                    }

                    if (model && model.succeeded) {
                        notificationsService.success(model.message.category, model.message.message);
                        vm.relations.push(model.content);
                    }
                    
                    editorService.close();
                },
                close: function () {
                    editorService.close();
                }
            };

            editorService.open(dialog);

        }

        function deleteRelation(relation, event) {

            var dialog = {
                view: "/App_Plugins/ContentRelations/overlays/delete.html",
                relation: relation,
                submitButtonLabelKey: "contentTypeEditor_yesDelete",
                submitButtonStyle: "danger",
                submit: function (model) {
                    contentRelationsResource.remove(relation);
                    var index = vm.relations.indexOf(relation);
                    vm.relations.splice(index, 1);
                    overlayService.close();
                },
                close: function () {
                    overlayService.close();
                }

            };

            localizationService.localize("general_delete").then(value => {
                dialog.title = value;
                overlayService.open(dialog);
            });
        }
    }

    angular.module('umbraco')
        .controller('contentRelationsController', contentRelationsController);
})();