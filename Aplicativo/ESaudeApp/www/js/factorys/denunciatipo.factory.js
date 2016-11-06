(function () {
    'use strict';

    angular
        .module('appESaudeMT')
        .factory('denunciaTipoFactory', denunciaTipoFactory)

    function denunciaTipoFactory($http) {
        //var provider = "http://172.16.14.74/";
        var provider = "http://appsaudemt.azurewebsites.net/";
        return {
            Insert: Insert,
            Select: Select
        }

        function Insert() {

        }

        function Select() {
            return $http.get(provider + "api/DenunciaTipo");
        }
    }

}());