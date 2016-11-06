(function () {
    'use strict';

    angular
        .module('appESaudeMT')
        .controller('MapsCtrl', MapsCtrl)

    function MapsCtrl($scope, $ionicSideMenuDelegate, $ionicModal) {
        $scope.toggleLeftSideMenu = function () {
            $ionicSideMenuDelegate.toggleLeft();
        };

        $scope.Opcoes = function () {
            $scope.openModalOpcoes();
        }

        $scope.DenunciarFoco = function () {
            $scope.openModalDenuncia();
        }

        $scope.MeuLocal = function () {
            map.setCenter(myPosition);
            $scope.toggleLeftSideMenu();
        }

        $scope.ConfirmarDenuncia = function () {
            addMarker(myPosition, map);
            $scope.closeModal();
            $scope.toggleLeftSideMenu();
        }

        $scope.openModalDenuncia = function () {
            $scope.modalDenuncia.show();
        };

        $scope.openModalOpcoes = function () {
            $scope.modalOpcoes.show();
        };

        $scope.closeModalDenuncia = function () {
            $scope.modalDenuncia.hide();
        };

        $scope.closeModalOpcoes = function () {
            $scope.modalOpcoes.hide();
        };

        $ionicModal.fromTemplateUrl('modalDenuncia.html', {
            scope: $scope,
            animation: 'slide-in-up'
        }).then(function (modal) {
            $scope.modalDenuncia = modal;
        });

        $ionicModal.fromTemplateUrl('modalOpcoes.html', {
            scope: $scope,
            animation: 'slide-in-up'
        }).then(function (modal) {
            $scope.modalOpcoes = modal;
        });
    }

} ());