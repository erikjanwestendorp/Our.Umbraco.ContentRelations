(function () {
    'use strict';

    function contentRelationsResource($http, $q) {
        var service = {
            getById: getById
        };

        var baseUrl = Umbraco.Sys.ServerVariables.ourUmbracoContentRelations.contentRelations;

        return service;

        function getById(id) {

            return $http.get(baseUrl + "GetRelationsByContentId?id=" + id).then(success, error);

            function success(result) {
                return result.data;
            }

            function error(result) {
                return $q.reject(result);
            }
        }
    }

    angular.module('umbraco.services').factory('contentRelationsResource', contentRelationsResource);
})();