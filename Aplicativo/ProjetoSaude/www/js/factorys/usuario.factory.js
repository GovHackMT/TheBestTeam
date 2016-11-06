(function(){
    'use strict';

    angular
        .module('appESaudeMT')
        .factory('usuarioFactory', usuarioFactory)

    function usuarioFactory($http){

        return {
            Insert: Insert,
            Select: Select
        }

        function Insert(){
            
        }

        function Select(){
            
        }
    }

}());