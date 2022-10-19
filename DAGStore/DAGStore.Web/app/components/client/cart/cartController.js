// Register controller
var product = angular.module('DAGStoreHome.cart');
product.controller('cartController', cartController);

// Controller
function cartController($scope, apiService, $stateParams, $filter, notificationService) {
    // Get Data
    $scope.cart = [];
    $scope.GetCart = GetCart;
    function GetCart() {
        apiService.get("/cart/getall", null, function (result) {

            $scope.cart = result.data.data;
           
            console.log($scope.cart);
        }, function (error) {
            console.log("Get data fail");
        })
    };
    $scope.GetCart();

    
}