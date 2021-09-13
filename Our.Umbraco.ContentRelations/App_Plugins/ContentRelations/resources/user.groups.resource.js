(function () {
    'use strict';

    function userGroupsResource($http, $q) {
        var service = {
            getAll: getAll
        };

        

        return service;

        function getAll() {

            //TODO
        }


        
      
    }

    angular.module('umbraco.services').factory('userGroupsResource', userGroupsResource);
})();