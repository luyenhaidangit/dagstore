// Register controller
var product = angular.module('DAGStoreHome.product');
product.controller('productController', productController);

// Controller
function productController($scope, apiService, $stateParams, $filter, notificationService, $state, $sce) {
    // Load Product Detail
    $scope.product = {
    }
    $scope.category =
    apiService.get("/product/getproductdetail/" + $stateParams.id, null, function (result) {
        $scope.product = result.data;
        $scope.Message = $sce.trustAsHtml($scope.product.FullDescription);
    }, function (error) {
        console.log("Không thể tải dữ liệu");
    })

    // Add Session Product Cart
    $scope.AddSessionProductCart = AddSessionProductCart;
    function AddSessionProductCart(id) {
        
        var config = {
            params: {
                id: id
            }
        }
        console.log(config.params)
        apiService.post("/cart/create", config.params, function (result) {
            console.log(config);
            notificationService.displaySuccess("Sản phẩm đã được thêm vào giỏ hàng!");
            $state.go("cart");
           /* $state.go("category");*/
        }, function (error) {
           /* notificationService.displaySuccess("Thêm mới không thành công!");*/
           /* console.log($scope.category);*/
        });
    }
    
    
}