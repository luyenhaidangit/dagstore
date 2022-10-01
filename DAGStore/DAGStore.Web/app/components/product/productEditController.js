// Register controller
var product = angular.module('DAGStore.product');
product.controller('productEditController', productEditController);

// Controller
function productEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService) {
    $scope.product = {

    }
    $scope.statusChooseAvatar = true;
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    $scope.ChooseImage = ChooseImage;
    // Choose Image Avatar
    function ChooseImage(status) {
        if (status === true) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.PicturePath = fileUrl;
                $("img[name=picturepath]").attr("src", $scope.product.PicturePath);
                $scope.statusChooseAvatar = true;
                $scope.$apply();
            }

            finder.popup();
        }
        if (status === false) {
            $scope.product.PicturePath = "";
            $scope.statusChooseAvatar = false;
            $scope.$apply();
        }
    }

    function loadProductDetail() {
        
        apiService.get("/product/getbyid/" + $stateParams.id, null, function (result) {
            $scope.product = result.data;
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }

    $scope.UpdateProduct = UpdateProduct;
    function UpdateProduct() {
        apiService.put("/product/update", $scope.product, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("product");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
        });
    }

    loadProductDetail();
}