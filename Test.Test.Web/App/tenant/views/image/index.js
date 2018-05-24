(function () {
    appModule.controller('tenant.views.image.index', [
        '$scope', '$state', '$uibModal', 'abp.services.app.image', 'uiGridConstants',
        function ($scope, $state, $uibModal, imageService, uiGridConstants) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;
            vm.currentTenantId = abp.session.tenantId;

            vm.permissions = {
                create: abp.auth.hasPermission('Pages.Administration.Languages.Create'),
                edit: abp.auth.hasPermission('Pages.Administration.Languages.Edit'),
                changeTexts: abp.auth.hasPermission('Pages.Administration.Languages.ChangeTexts'),
                'delete': abp.auth.hasPermission('Pages.Administration.Languages.Delete')
            };

            vm.gridOptions = {
                rowHeight: 250,
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                appScopeProvider: vm,
                columnDefs: [
                    {
                        name: app.localize('Actions'),
                        width: 120,
                        enableSorting: false,
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents\">' +
                            '  <div ng-if="grid.appScope.permissions.changeTexts || row.entity.tenantId == grid.appScope.currentTenantId" class="btn-group dropdown" uib-dropdown="" dropdown-append-to-body>' +
                            '    <button class="btn btn-xs btn-primary blue" uib-dropdown-toggle="" aria-haspopup="true" aria-expanded="false"><i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span></button>' +
                            '    <ul uib-dropdown-menu>' +
                            '      <li><a ng-click="grid.appScope.editimage(row.entity)">' + app.localize('Edit') + '</a></li>' +
                            '      <li><a ng-click="grid.appScope.deleteImage(row.entity)">' + app.localize('Delete') + '</a></li>' +
                            '    </ul>' +
                            '  </div>' +
                            '</div>'
                    },
                    {
                        name: app.localize('FileName'),
                        field: 'fileName',
                        minWidth: 140
                    },
                    {
                        name: app.localize('Image') + '*',
                        field: 'imageString',
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents\">' +
                            '<img data-ng-src="data:image/png;base64,{{row.entity.imageString}}" data-err-src="images/png/avatar.png"/>'+
                            '</div>',
                        width: 300
                    },
                    {
                        name: app.localize('CreationTime'),
                        field: 'creationTime',
                        cellFilter: 'momentFormat: \'L\'',
                        minWidth: 140
                    }
                ],
                data: []
            };

            if (!vm.permissions.edit &&
                !vm.permissions.changeTexts && 
                !vm.permissions.delete) {
                vm.gridOptions.columnDefs.shift();
            }

            //No need to 'Default' field is this is a host user.
            if (!vm.currentTenantId) {
                vm.gridOptions.columnDefs.splice(vm.gridOptions.columnDefs.length - 2, 1);
            }

            vm.getImages = function () {
                vm.loading = true;
                imageService.listAllUserImages({}).then(function (result) {
                    vm.gridOptions.data = result.data.items;
                }).finally(function () {
                    vm.loading = false;
                });
            };

            vm.editimage = function (image) {
                openCreateOrEditimageModal(image.id);
            };

            vm.deleteimage = function (image) {
                abp.message.confirm(
                    app.localize('imageDeleteWarningMessage', image.displayName),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            imageService.deleteimage({
                                id: image.id
                            }).then(function () {
                                vm.getimages();
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                            });
                        }
                    }
                );
            };

            vm.insertImage = function () {
                openCreateOrEditimageModal(null);
            };

            function openCreateOrEditimageModal(id) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/common/views/profile/changePicture.cshtml',
                    controller: 'common.views.profile.changePicture as vm',
                    backdrop: 'static',
                    resolve: {
                        imageId: function () {
                            return id;
                        }
                    }
                });

                modalInstance.result.then(function (result) {
                    vm.getImages();
                });
            }

            vm.getImages();
        }
    ]);
})();