
(function () {
    'use strict';

    angular.module('appESaudeMT').controller('MapsCtrl', MapsCtrl)

    function MapsCtrl($scope, $ionicSideMenuDelegate, $ionicModal, $cordovaCamera, $state, denunciaFactory, denunciaTipoFactory, usuarioFactory) {
        denunciaTipoFactory.Select().success(function (data) {
            console.log(data);
            $scope.lstTipoDenuncia = data;
        });

        $scope.LoadDenuncias = function () {
            denunciaFactory.Select().success(function (data) {
                var lstTipoDenuncia = data;
                if (lstTipoDenuncia.length > 0) {
                    lstTipoDenuncia.forEach(function (elem, k) {
                        var position = {
                            lat: parseFloat(elem.Latitude),
                            lng: parseFloat(elem.Longitude)
                        };
                        console.log(position);
                        addMarker(position, map);
                    })
                }
            });
        };

        $scope.iniciarMapa = function () {
            initMap();
            $scope.LoadDenuncias();
        };

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

        $scope.ConfirmarDenuncia = function (TipoDenuncia, Observacao) {
            var denuncia = {};
            denuncia.IdDenunciaTipo = TipoDenuncia.IdDenunciaTipo;
            denuncia.IdUsuario = 1;
            denuncia.Latitude = myPosition.lat;
            denuncia.Longitude = myPosition.lng;
            denuncia.Observacao = Observacao;
            denunciaFactory.Insert(denuncia).success(function (data) {
                console.log(data);
            });
            addMarker(myPosition, map);
            $scope.closeModalDenuncia();
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



        $scope.takePhoto = function ($cordovaCamera) {
            var options = {
                quality: 75,
                destinationType: Camera.DestinationType.DATA_URL,
                sourceType: Camera.PictureSourceType.CAMERA,
                allowEdit: true,
                encodingType: Camera.EncodingType.JPEG,
                targetWidth: 300,
                targetHeight: 300,
                popoverOptions: CameraPopoverOptions,
                saveToPhotoAlbum: false
            };

            $cordovaCamera.getPicture(options).then(function (imageData) {
                $scope.imgURI = "data:image/jpeg;base64," + imageData;
            }, function (err) {
                // An error occured. Show a message to the user
            });
        }

       
        

        $scope.Logout = function () {
            usuarioFactory.Logout().then(function (response) {
                $scope.closeModalOpcoes();
                $state.go("index");
            })
        }
    }

}());