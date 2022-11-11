// Register controller
var product = angular.module('DAGStoreHome.cart');
product.controller('cartController', cartController);

// Controller
function cartController($scope, apiService, $stateParams, $filter, notificationService) {
    // Get Data
    $scope.cart = [];
    apiService.get("/cart/getall", null, function (result) {
        $scope.cart = result.data.data;
        console.log($scope.cart == []);

    }, function (error) {
        console.log("Get data fail");
    })

    $scope.DeteteCartItem = DeteteCartItem;
    function DeteteCartItem(item) {
        console.log(item)
        var config = {
            params: {
                id: item
            }
        }
        apiService.del("/cart/delete", config, function (success) {
            $scope.cart = $scope.cart.filter((item) => {
                return item.ProductID !== config.params.id;
            })
            console.log("Xóa thành công bản ghi")
        }, function (error) {
            console.log("Xóa không thành công!")
        })
    }
}