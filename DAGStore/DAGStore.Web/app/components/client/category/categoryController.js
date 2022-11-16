// Register controller
var category = angular.module('DAGStoreHome.category');
category.controller('categoryController', categoryController);

// Controller
function categoryController($scope, apiService, $stateParams, $filter, $rootScope, $timeout) {
    //Load Page
    $rootScope.LoadPageSuccess = false;
    

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
    $scope.GetProductsOfCategory = GetProductsOfCategory;
    function GetProductsOfCategory() {
        apiService.get("/product/getall", null, function (result) {
            $scope.products = result.data;
            $scope.products = $filter('filter')($scope.products, { CategoryID: $stateParams.id })
            console.log($scope.products);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.GetProductsOfCategory();

    angular.element(function () {
        $timeout(function () {
            $rootScope.LoadPageSuccess = true;
        }, 300);
    });
}