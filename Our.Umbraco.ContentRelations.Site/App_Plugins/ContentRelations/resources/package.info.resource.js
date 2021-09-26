(function () {
    'use strict';

    function packageInformationResource($http, $q) {
        var service = {
            getInfo: getInfo
        };

        var baseUrl = Umbraco.Sys.ServerVariables.ourUmbracoContentRelations.package;

        return service;

        function getInfo() {
         
            return $http.get(baseUrl + "GetInformation").then(success, error);

            function success(result) {
                return result.data;
            }

            function error(result) {
                return $q.reject(result);
            }
        }
    }

    angular.module('umbraco.services').factory('packageInformationResource', packageInformationResource);
})();