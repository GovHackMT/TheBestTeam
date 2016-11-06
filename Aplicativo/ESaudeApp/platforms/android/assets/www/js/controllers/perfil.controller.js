(function () {
    'use strict';

    angular.module('appESaudeMT').controller('PerfilController', PerfilController)

    PerfilController.$inject = ['$scope', '$state', '$ionicModal', '$ionicPopup', 'usuarioFactory'];

    function PerfilController($scope, $state, $ionicModal, $ionicPopup, usuarioFactory) {
        var vm = $scope;

        vm.model = {};

        vm.PutUsuario = PutUsuario;
        vm.VoltarMapa = VoltarMapa;
        
        GetCurrentUser();

        function GetCurrentUser() {

            console.log('GetCurrentUser ');
            usuarioFactory.GetCurrentUser().then(function (response) {
                if (response.status !== 401) {
                    var data = response.data;

                    vm.model = {
                        IdUsuario: data.IdUsuario,
                        Nome: data.Nome,
                        SobreNome: data.SobreNome,
                        Email: data.Email,
                        DataNascimento: data.DataNascimento,
                        Cpf: data.Cpf,
                        Celular: data.Celular
                    }
                } else {
                    $state.go("index");
                }
              
                

            }, function errorCallback(response) {
    
            })
        }
        
        function PutUsuario()
        {
            usuarioFactory.PutUsuario(vm.model).then(function (response) {
                var confirmPopup = $ionicPopup.alert({
                    title: 'Parabéns!',
                    template: 'Seu perfil foi atualizado com sucesso!',
                    cancelText: '', // String (default: 'Cancel'). The text of the Cancel button.
                    cancelType: '', // String (default: 'button-default'). The type of the Cancel button.
                    okText: 'Ok', // String (default: 'OK'). The text of the OK button.
                    okType: 'button-positive', // String (default: 'button-positive'). The type of the OK button.

                });

                confirmPopup.then(function (res) {
                    if (res) {
                        $state.go("maps");
                    }
                });
            }, function errorCallBack(response) {
                var confirmPopup = $ionicPopup.alert({
                    title: 'Atenção!',
                    template: 'Falha ao tentar atualizar o perfil',
                    cancelText: '', // String (default: 'Cancel'). The text of the Cancel button.
                    cancelType: '', // String (default: 'button-default'). The type of the Cancel button.
                    okText: 'Ok', // String (default: 'OK'). The text of the OK button.
                    okType: 'button-positive', // String (default: 'button-positive'). The type of the OK button.

                });

                confirmPopup.then(function (res) {

                });
            })
        }

        function VoltarMapa() {
            $state.go("maps");
        }
    }
}());