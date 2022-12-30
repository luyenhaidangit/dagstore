// Register controller
var app = angular.module('DAGStore');
app.controller('homeController', homeController);

// Controller
function homeController(apiService, $scope) {
    $scope.products = []
    apiService.get("/product/getall", null, function (result) {
        $scope.products = result.data;
        console.log($scope.products)
    }, function (error) {
        console.log("Get data fail");
    })

    $scope.customers = []
    apiService.get("/customer/getall", null, function (result) {
        $scope.customers = result.data;
    }, function (error) {
        console.log("Get data fail");
    })


    $scope.total = {}
    apiService.get("/order/GetRevenue", null, function (result) {
        $scope.total = result.data;
    }, function (error) {
        console.log("Get data fail");
    })
}
