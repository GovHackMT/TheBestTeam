(function(){
    'use strict';

    angular
        .module('appESaudeMT')
        .factory('denunciaTipoFactory', denunciaTipoFactory)

    function denunciaTipoFactory($http){

        return {
            Insert: Insert,
            Select: Select
        }

        function Insert(){
            
        }

        function Select(){
            return $http.get("http://appsaudemt.azurewebsites.net/api/DenunciaTipo");
        }
    }

}());