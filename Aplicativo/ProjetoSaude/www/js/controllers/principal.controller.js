(function () {
    'use strict';

    angular
        .module('appESaudeMT')
        .controller('ControllerCtrl', ControllerCtrl)

    function ControllerCtrl($scope, $http, $ionicModal, $window) {
        $ionicModal.fromTemplateUrl('my-modal.html', {
            scope: $scope,
            animation: 'slide-in-up'
        }).then(function (modal) {
            $scope.modal = modal;
        });
        $scope.openModal = function () {
            $scope.modal.show();
        };
        $scope.closeModal = function () {
            $scope.modal.hide();
        };
        $scope.Open = function (url) {
            $window.open(url, '_system');
        }

    }

} ());