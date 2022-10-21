// Register controller
var product = angular.module('DAGStore.product');
product.controller('productAddController', productAddController);

// Controller
function productAddController($scope, apiService, notificationService, $state, ckeditorService) {
    // Init
    $scope.product = {
        ShowOnHomePage: true,
        AllowCustomerReviews: true,
        IsShipEnabled: true,
        Published: true,
        HasDiscountsApplied: true,
        DisplayOrder: -1,
        CreateOn: new Date().toJSON().slice(0, 10),
        UpdateOn: new Date().toJSON().slice(0, 10),
    }

    // Load List Brand
    $scope.brands = [];
    $scope.GetBrands = GetBrands;
    function GetBrands() {
        apiService.get("/brand/getall", null, function (result) {
            $scope.brands = result.data;
            console.log($scope.brands[0].ID);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.GetBrands();

    // Load List Category
    $scope.categorys = [];
    $scope.GetCategorys = GetCategorys;
    function GetCategorys() {
        apiService.get("/category/getall", null, function (result) {
            $scope.categorys = result.data;
            console.log($scope.categorys);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.GetCategorys();

    // Choose Image Product
    $scope.statusChooseAvatar = false;
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

    // Resiger Ckeditor
    ckeditorService.createDefaultCkeditor("DAGStoreTextArea");

    // Submit Add Product
    $scope.AddProduct = AddProduct;
    function AddProduct() {
        $scope.product.BrandID = document.getElementsByName("brandid")[0].value;
        $scope.product.CategoryID = document.getElementsByName("categoryid")[0].value;
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