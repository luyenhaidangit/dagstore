// Register controller
var category = angular.module('DAGStoreHome.category');
category.controller('categoryController', categoryController);

// Controller
function categoryController($scope, apiService, $stateParams, $filter, $rootScope, $timeout) {
    //Load Page
    $rootScope.LoadPageSuccess = false;
    var numberProduct = 10;
    // Load Category Detail
    $scope.category = {
    }
    $scope.LoadCategoryDetail = LoadCategoryDetail;
    function LoadCategoryDetail() {
        apiService.get("/category/getbyid/" + $stateParams.id, null, function (result) {
            $scope.category = result.data;
        }, function (error) {
            notificationService.displaySuccess("Không thể tải dữ liệu");
        })
    }
    $scope.LoadCategoryDetail();

    
    // Load List Product Of Category
    $scope.brands = [];
    $scope.products = [];
    apiService.get("/product/GetProductsByCategory/" + $stateParams.id, null, function (result) {
        $scope.products = result.data;
        $scope.productsShow = $scope.products.slice(0, $scope.numberProduct);
        $scope.brands = result.data.map((item) => {
            return item.BrandProduct;
        }).filter((v, i, a) => a.findIndex(v2 => (v2.ID === v.ID)) === i);
        console.log($scope.brands)
    }, function (error) {
        console.log("Không thể tải dữ liệu");
    })

    //Load More Product
    $scope.LoadMoreProduct = LoadMoreProduct;
    $scope.numberProduct = 10;
    function LoadMoreProduct() {
        $scope.numberProduct += 10;
        FilterProduct();
    }

    $scope.FilterProductByBrand = FilterProductByBrand;
    $scope.brand = {
    }
    $scope.brand.Name = "Hãng";
    $scope.brandFilter = true;
    function FilterProductByBrand(item) {
        $scope.brandFilter = item.ID;
        $scope.brand = item;
        FilterProduct();
    }

    $scope.FilterProduct = FilterProduct;
    function FilterProduct() {
        $scope.productsShow = $scope.products.filter(x => x.BrandProduct.ID == $scope.brandFilter).slice(0, $scope.numberProduct);;
        console.log($scope.products)
        console.log("vcl")
    }

    //$scope.GetProductsOfCategory = GetProductsOfCategory;
    //function GetProductsOfCategory() {
    //    apiService.get("/product/getall", null, function (result) {
    //        $scope.products = result.data;
    //        $scope.products = $filter('filter')($scope.products, { CategoryID: $stateParams.id })
    //        console.log($scope.products);
    //    }, function (error) {
    //        console.log("Get data fail");
    //    })
    //};
    //$scope.GetProductsOfCategory();

    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 300);
    });
}