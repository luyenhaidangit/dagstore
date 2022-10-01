// Register controller
var product = angular.module('DAGStore.product');
product.controller('productAddController', productAddController);

// Controller
function productAddController($scope, apiService, notificationService, $state, ckeditorService) {
    $scope.statusChooseAvatar = false;
    $scope.ChooseImage = ChooseImage;
    $scope.product = {
        CreateOn: new Date().toJSON().slice(0, 10),
        UpdateOn: new Date().toJSON().slice(0, 10),
    }

    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

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

    $scope.AddProduct = AddProduct;
    function AddProduct() {
        console.log("ok")
        $scope.product.Content = CKEDITOR.instances['DAGStoreTextArea'].getData();
        apiService.post("/product/create", $scope.product, function (result) {

            notificationService.displaySuccess("Thêm thông tin thành công!");


            $state.go("product");
        }, function (error) {
            notificationService.displaySuccess("Thêm mới không thành công!");
            console.log($scope.product.Name);
        });
    }


}