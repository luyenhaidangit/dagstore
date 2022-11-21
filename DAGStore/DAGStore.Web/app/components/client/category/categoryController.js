// Register controller
var category = angular.module('DAGStoreHome.category');
category.controller('categoryController', categoryController);

// Controller
function categoryController($scope, apiService, $stateParams, $filter, $rootScope, $timeout) {
    //Load Page
    $rootScope.LoadPageSuccess = false;
    var numberProduct = 2;

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
    $scope.products = [];
    apiService.get("/product/GetProductsByCategory/" + $stateParams.id, null, function (result) {
        $scope.products = result.data;
        $scope.productsShow = $scope.products.slice(0, numberProduct);
        console.log($scope.products)
    }, function (error) {
        console.log("Không thể tải dữ liệu");
    })

    //Load More Product
    $scope.LoadMoreProduct = LoadMoreProduct;
    function LoadMoreProduct() {
        numberProduct += 2;
        $scope.productsShow = $scope.products.slice(0, numberProduct);
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