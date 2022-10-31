// Register controller
var product = angular.module('DAGStore.product');
product.controller('productEditController', productEditController);

// Controller
function productEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService,$filter) {
    //Config
    $scope.config = {
        nameManage: "Sản Phẩm",
        urlManage: "product",
        namePage: "Sửa Thông Tin",
    }

    //Load Product Detail
    $scope.product = {
    }
    apiService.get("/product/getbyid/" + $stateParams.id, null, function (result) {
        $scope.product = result.data;
    }, function (error) {
        notificationService.displaySuccess("Không thể tải dữ liệu");
    })

    //Load List Brand
    $scope.brand = {};
    $scope.brands = [];
    apiService.get("/brand/getdata", null, function (result) {
        $scope.brands = result.data;
        $scope.brand = $scope.brands.filter(x => x.ID === $scope.product.BrandID)[0];
    }, function (error) {
        console.log("Get data fail");
    })

    //Load List Category
    $scope.category = {};
    $scope.categorys = [];
    apiService.get("/category/getdata", null, function (result) {
        $scope.categorys = result.data;
        $scope.category = $scope.categorys.filter(x => x.ID === $scope.product.CategoryID)[0];
        console.log($scope.category)
    }, function (error) {
        console.log("Get data fail");
    })

    // Choose Avatar Product
    $scope.statusChooseAvatar = true;
    $scope.ChooseImage = ChooseImage;
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

    // Regster Ckeditor
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    // Submit Edit Product
    $scope.EditProduct = EditProduct;
    function EditProduct() {
        $scope.product.BrandID = document.getElementsByName("brandid")[0].value;
        $scope.product.CategoryID = document.getElementsByName("categoryid")[0].value;
        $scope.product.Content = CKEDITOR.instances['DAGStoreTextArea'].getData();

        apiService.put("/product/update", $scope.product, function (result) {
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("product");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
        });
    }
}