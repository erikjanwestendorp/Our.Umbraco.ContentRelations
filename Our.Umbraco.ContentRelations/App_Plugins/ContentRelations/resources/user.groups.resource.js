(function () {
    'use strict';

    function contentRelationsUserGroupsResource($http, $q) {
        var service = {
            getAll: getAll
        };

        var baseUrl = Umbraco.Sys.ServerVariables.ourUmbracoContentRelations.userGroups;
        
        return service;

        function getAll() {
            

            return $http.get(baseUrl + "GetUserGroups").then(success, error);

            function success(result) {
                return result.data;
            }

            function error(result) {
                return $q.reject(result);
            }
        }
    }

    angular.module('umbraco.services').factory('contentRelationsUserGroupsResource', contentRelationsUserGroupsResource);
})();