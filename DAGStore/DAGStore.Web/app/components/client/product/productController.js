// Register controller
var product = angular.module('DAGStoreHome.product');
product.controller('productController', productController);

// Controller
function productController($scope, apiService, $stateParams, $filter) {
    // Load Product Detail
    $scope.product = {
    }
    $scope.category = {
    }

    apiService.get("/product/getbyid/" + $stateParams.id, null, function (result) {
        $scope.product = result.data;
        $scope.product.CreateOn = $filter('formatJsonDate')($scope.product.CreateOn);
        apiService.get("/category/getbyid/" + $scope.product.CategoryID, null, function (resultCategory) {
            $scope.category = resultCategory.data;
            console.log($scope.category);
        }, function (error) {
            console.log("Không thể tải dữ liệu");
            
        })
    }, function (error) {
        console.log("Không thể tải dữ liệu");
    })

   
    

    
}