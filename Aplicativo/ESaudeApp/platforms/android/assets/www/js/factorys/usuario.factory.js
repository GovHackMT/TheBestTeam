(function () {
    'use strict';

    angular
        .module('appESaudeMT')
        .factory('usuarioFactory', usuarioFactory)

    //var provider = "http://172.16.14.74/";
    var provider = "http://appsaudemt.azurewebsites.net/";

    function usuarioFactory($http) {

        return {
            AuthorizationUser: AuthorizationUser,
            PostUsuario: PostUsuario,
            GetCurrentUser: GetCurrentUser,
            PutUsuario: PutUsuario,
            Logout: Logout
        }

        function AuthorizationUser(user, pas) {
            return $http.get(provider + "api/usuario/AuthorizationUser",
            {
                params: {
                    user: user,
                    password: pas
                }
            });
        }

        function PostUsuario(model) {
            return $http.post(provider + "api/usuario", model);
        }
        function GetCurrentUser() {
            return $http.get(provider + "api/usuario/GetCurrentUser");
        }

        function PutUsuario(model) {
            return $http.put(provider + "api/usuario", model);
        }

        function Logout() {
            return $http.get(provider + "api/usuario/Logout");
        }

    }
}());