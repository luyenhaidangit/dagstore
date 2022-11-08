// Register controller
var index = angular.module('DAGStoreHome.index');
index.controller('indexController', indexController);

// Controller
function indexController($scope, apiService) {
    // Get Slider
    $scope.sliders = [];
    apiService.get("/index/showslider", null, function (result) {
        $scope.sliders = result.data;
        console.log($scope.sliders);
    }, function (error) {
        console.log("Get data fail");
    })

    // Get Product News
    $scope.productsNew = [];
    apiService.get("/index/GetProductsNewShowHomePage", null, function (result) {
        $scope.productsNew = result.data;
        console.log($scope.productsNew);
    }, function (error) {
        console.log("Get data fail");
    })
}
