(function () {
    'use strict';

    angular
        .module('appESaudeMT')
        .factory('denunciaFactory', denunciaFactory)

    function denunciaFactory($http) {
        //var provider = "http://172.16.14.74/";
        var provider = "http://appsaudemt.azurewebsites.net/";
        return {
            Insert: Insert,
            Select: Select
        }

        function Insert(denuncia) {
            return $http.post(provider + "api/Denuncia", denuncia);
        }

        function Select() {
            return $http.get(provider + "api/Denuncia");
        }
    }

}());