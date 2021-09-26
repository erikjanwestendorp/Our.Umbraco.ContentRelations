(function () {
    'use strict';

    function contentRelationsResource($http, $q) {
        var service = {
            getById: getById,
            save: save,
            remove: remove
        };

        var baseUrl = Umbraco.Sys.ServerVariables.ourUmbracoContentRelations.relations;

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

        function save(relation) {

            return $http.post(baseUrl + "AddRelation", relation).then(success, error);

            function success(result) {
                return result.data;
            }

            function error(result) {
                return $q.reject(result);
            }
        }

        function remove(relation) {
            var req = {
                method: "DELETE",
                url: baseUrl + "DeleteRelation?id=" + relation.id,
                headers: {
                    'Content-Type': "application/json" 
                },
                data: relation
            }

            return $http(req).then(success, error);

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