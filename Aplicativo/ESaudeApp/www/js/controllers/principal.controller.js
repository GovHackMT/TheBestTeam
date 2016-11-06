(function () {
    'use strict';

    angular.module('appESaudeMT').controller('PrincipalController', PrincipalController)

    PrincipalController.$inject = ['$scope', '$state', '$ionicModal', '$ionicPopup', 'usuarioFactory'];

    function PrincipalController($scope, $state, $ionicModal, $ionicPopup, usuarioFactory) {

        $scope.login = {};
        $scope.model = {};


        $ionicModal.fromTemplateUrl('my-modal.html', {
            scope: $scope,
            animation: 'slide-in-up'
        }).then(function (modal) {
            $scope.modal = modal;
        });


        $scope.openModal = function () {
            $scope.model = {};
            $scope.modal.show();
        };

        $scope.closeModal = function () {
            $scope.modal.hide();
        };

        $scope.AuthorizationUser = function () {

            usuarioFactory.AuthorizationUser($scope.login.User, $scope.login.Password).then(function (response) {
                $scope.login = {};
                $state.go("maps");
            }, function errorCallback(response) {

                var confirmPopup = $ionicPopup.alert({
                    title: 'Atenção!',
                    template: 'Usuário ou senha não encontrado!',
                    cancelText: '', // String (default: 'Cancel'). The text of the Cancel button.
                    cancelType: '', // String (default: 'button-default'). The type of the Cancel button.
                    okText: 'Ok', // String (default: 'OK'). The text of the OK button.
                    okType: 'button-positive', // String (default: 'button-positive'). The type of the OK button.

                });

                confirmPopup.then(function (res) {
          
                });
            });
           


        };


        $scope.CreateAccount = function () {
            usuarioFactory.PostUsuario($scope.model).then(function (response) {
                console.log(response);
                var confirmPopup = $ionicPopup.alert({
                    title: 'Parabéns!',
                    template: 'Sua conta de usuário foi cadastrada com sucesso.',
                    cancelText: '', // String (default: 'Cancel'). The text of the Cancel button.
                    cancelType: '', // String (default: 'button-default'). The type of the Cancel button.
                    okText: 'Ok', // String (default: 'OK'). The text of the OK button.
                    okType: 'button-positive', // String (default: 'button-positive'). The type of the OK button.

                });

                confirmPopup.then(function (res) {
                    if (res) {
                        $scope.closeModal();
                    }
                });

            }, function errorCallback(response) {

                var confirmPopup = $ionicPopup.alert({
                    title: 'Ops!',
                    template: 'Ocorreu algum erro ao realizar o cadastro. Tente novamente!',
                    cancelText: '', // String (default: 'Cancel'). The text of the Cancel button.
                    cancelType: '', // String (default: 'button-default'). The type of the Cancel button.
                    okText: 'Ok', // String (default: 'OK'). The text of the OK button.
                    okType: 'button-positive', // String (default: 'button-positive'). The type of the OK button.

                });

                confirmPopup.then(function (res) {
                    if (res) {
                        //$scope.closeModal();
                    }
                });


            });
        };

        $scope.GetCurrentUser = function()
        {
            usuarioFactory.GetCurrentUser().then(function (response) {
                if (response.status !== 401) {
                    $state.go("maps");
                }
            });
        }

        $scope.GetCurrentUser();
    }
}());