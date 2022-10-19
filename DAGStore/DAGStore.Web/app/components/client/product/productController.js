// Register controller
var product = angular.module('DAGStoreHome.product');
product.controller('productController', productController);

// Controller
function productController($scope, apiService, $stateParams, $filter, notificationService,$state) {
    // Load Product Detail
    $scope.product = {
    }
    $scope.category =
    apiService.get("/product/getbyid/" + $stateParams.id, null, function (result) {
        $scope.product = result.data;
        $scope.product.CreateOn = $filter('formatJsonDate')($scope.product.CreateOn);
        apiService.get("/category/getbyid/" + $scope.product.CategoryID, null, function (resultCategory) {
            $scope.category = resultCategory.data;
        }, function (error) {
            console.log("Không thể tải dữ liệu");
            
        })
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