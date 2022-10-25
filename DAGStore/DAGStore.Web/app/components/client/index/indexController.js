// Register controller
var index = angular.module('DAGStoreHome.index');
index.controller('indexController', indexController);

// Controller
function indexController($scope, apiService){
    // Get Product News
    $scope.productsNew = [];
    apiService.get("/index/GetProductsNewShowHomePage", null, function (result) {
        $scope.productsNew = result.data;
        console.log($scope.productsNew);
    }, function (error) {
        console.log("Get data fail");
    })
}
