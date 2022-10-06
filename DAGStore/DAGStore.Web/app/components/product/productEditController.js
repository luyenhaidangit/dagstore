// Register controller
var product = angular.module('DAGStore.product');
product.controller('productEditController', productEditController);

// Controller
function productEditController($scope, apiService, notificationService, $state, $stateParams, ckeditorService,$filter) {
    // Init
    $scope.product = {
        
    }

    // Load Product Detail
    $scope.LoadProductDetail = LoadProductDetail;
    function LoadProductDetail() {
        apiService.get("/product/getbyid/" + $stateParams.id, null, function (result) {
            $scope.product = result.data;
            $scope.product.CreateOn = $filter('formatJsonDate')($scope.product.CreateOn);
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }
    $scope.LoadProductDetail();

    // Load List Category
    $scope.category = {};
    $scope.categorys = [];
    $scope.GetCategorys = GetCategorys;
    function GetCategorys() {
        apiService.get("/category/getall", null, function (result) {
            $scope.categorys = result.data;
            $scope.category = $scope.categorys.filter(x => x.ID === $scope.product.CategoryID)[0];
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.GetCategorys();

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
    $scope.UpdateProduct = UpdateProduct;
    function UpdateProduct() {
        $scope.product.CategoryID = document.getElementsByName("categoryid")[0].value;
        $scope.product.Content = CKEDITOR.instances['DAGStoreTextArea'].getData();
        $scope.product.UpdateOn = new Date().toJSON().slice(0, 10);
        console.log($scope.product);
        apiService.put("/product/update", $scope.product, function (result) {
            console.log($scope.product)
            notificationService.displaySuccess("Cập nhật thông tin thành công!");
            $state.go("product");
        }, function (error) {
            notificationService.displaySuccess("Cập nhật thông tin không thành công!");
        });
    }
}