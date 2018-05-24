(function () {
    appModule.controller('common.views.profile.changePicture', [
        '$scope', 'appSession', '$uibModalInstance', 'FileUploader', 'abp.services.app.image', 'imageId',
        function ($scope, appSession, $uibModalInstance, fileUploader, imageService, imageId) {
            var vm = this;

            var $jcropImage = null;
            vm.uploadedFileName = null;
            vm.extension = null;
            if (imageId === null) {
                vm.imageId = 0;
            } else {
                vm.imageId = imageId;
            }
            vm.uploader = new fileUploader({
                url: abp.appPath + 'Image/UploadImage',
                headers: {
                    "X-XSRF-TOKEN": abp.security.antiForgery.getToken()
                },
                queueLimit: 1,
                autoUpload: true,
                removeAfterUpload: true,
                filters: [{
                    name: 'imageFilter',
                    fn: function (item, options) {
                        //File type check
                        var type = '|' + item.type.slice(item.type.lastIndexOf('/') + 1) + '|';
                        if ('|jpg|jpeg|png|gif|'.indexOf(type) === -1) {
                            abp.message.warn(app.localize('ProfilePicture_Warn_FileType'));
                            return false;
                        }

                        //File size check
                        if (item.size > 100048576) //100MB
                        {
                            abp.message.warn(app.localize('ProfilePicture_Warn_SizeLimit'));
                            return false;
                        }

                        return true;
                    }
                }]
            });

            vm.save = function () {
                if (!vm.uploadedFileName) {
                    return;
                }

                var resizeParams = {};
                if ($jcropImage) {
                    resizeParams = $jcropImage.data("Jcrop").tellSelect();
                }

                imageService.saveImage({
                    fileName: vm.uploadedFileName,
                    x: parseInt(resizeParams.x),
                    y: parseInt(resizeParams.y),
                    fileExtension: vm.extension,
                    imageId : vm.imageId,
                    width: parseInt(resizeParams.w),
                    height: parseInt(resizeParams.h)
                }).then(function () {
                    $jcropImage.data('Jcrop').destroy();
                    $jcropImage = null;
                    $('#HeaderProfilePicture').attr('src', app.getUserProfilePicturePath());

                    $uibModalInstance.close();
                });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };

            vm.uploader.onSuccessItem = function (fileItem, response, status, headers) {
                if (response.success) {
                    var $profilePictureResize = $('#ProfilePictureResize');

                    var newCanvasHeight = response.result.height * $profilePictureResize.width() / response.result.width;
                    $profilePictureResize.height(newCanvasHeight + 'px');

                    var profileFilePath = abp.appPath + 'Temp/Downloads/' + response.result.fileName + '?v=' + new Date().valueOf();
                    vm.uploadedFileName = response.result.fileName;
                    vm.extension = response.result.fileFormat;

                    if ($jcropImage) {
                        $jcropImage.data('Jcrop').destroy();
                    }

                    $profilePictureResize.attr('src', profileFilePath);
                    $jcropImage = $profilePictureResize.Jcrop({
                        trueSize: [response.result.width, response.result.height],
                        setSelect: [0, 0, 100, 100],
                        aspectRatio: 1
                    });
                } else {
                    abp.message.error(response.error.message);
                }
            };
        }
    ]);
})();