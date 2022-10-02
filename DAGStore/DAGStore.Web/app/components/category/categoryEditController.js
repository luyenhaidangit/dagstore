// Register controller
var category = angular.module('DAGStore.category');
category.controller('categoryEditController', categoryEditController);

// Controller
function categoryEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService) {
    $scope.category = {

    }
    $scope.statusChooseAvatar = true;
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    $scope.ChooseImage = ChooseImage;
    // Choose Image Avatar
    function ChooseImage(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.category.PicturePath = fileUrl;
                $("img[name=picturepath]").attr("src", $scope.category.PicturePath);
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            $scope.category.PicturePath = "";
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    function LoadCategoryDetail() {
        console.log("ok")
        apiService.get("/category/getbyid/" + $stateParams.id, null, function (result) {
            $scope.category = result.data;
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }

    $scope.UpdateCategory = UpdateCategory;
    function UpdateCategory() {
        
        apiService.put("/category/update", $scope.category, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("category");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
            console.log($scope.category)
        });
    }

    LoadCategoryDetail();
}