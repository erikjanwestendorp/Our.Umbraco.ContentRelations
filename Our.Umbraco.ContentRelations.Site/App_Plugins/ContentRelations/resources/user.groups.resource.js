(function () {
    'use strict';

    function userGroupsResource($http, $q) {
        var service = {
            getAll: getAll
        };

        var baseUrl = Umbraco.Sys.ServerVariables.ourUmbracoContentRelations.userGroups;

        return service;

        function getAll() {
            console.log(baseUrl);

            return $http.get(baseUrl + "GetUserGroups").then(success, error);

            function success(result) {
                return result.data;
            }

            function error(result) {
                return $q.reject(result);
            }
            //TODO
        }


        
      
    }

    angular.module('umbraco.services').factory('userGroupsResource', userGroupsResource);
})();