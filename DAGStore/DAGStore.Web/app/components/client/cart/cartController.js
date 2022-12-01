// Register controller
var product = angular.module('DAGStoreHome.cart');
product.controller('cartController', cartController);

// Controller
function cartController($scope, apiService, $stateParams, $filter, $rootScope, notificationService) {
    //Load Page
    $rootScope.LoadPageSuccess = true;
    // Get Data
    $scope.cart = [];
    $scope.order = {
        OrderTotal: 0,
    }
    apiService.get("/cart/getall", null, function (result) {
        $scope.cart = result.data.data;
        LoadTotalOrder()
        console.log($scope.cart);

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
            LoadTotalOrder();
            console.log("Xóa thành công bản ghi")
        }, function (error) {
            console.log("Xóa không thành công!")
        })
    }

    $scope.ShippingAddress = "";

    $scope.form = {
        Customer: {
            Sex: "Nam",
            Andress: "",
            DeliveryAndress: "",
            Deleted: false,
        },
        Order: {
            ShippingFormat: "0",
            OrderStatus: "0",
            PaymentFormat: "0",
            PaymentStatus: "0",
            OrderDiscount: 0,
            OrderTotal: $scope.order.OrderTotal,
            CreateOn: "02-12-2022",
        }


        
    }

    $scope.ChangeQuantity = ChangeQuantity;
    function ChangeQuantity(item, activiti) {
        console.log(item)
        if (activiti === "+") {
            item.Quantity += 1;
        }
        if (activiti === "-") {
            item.Quantity -= 1;
            if (item.Quantity <= 0) {
                item.Quantity = 0;
            }
        }
        LoadTotalOrder()
        apiService.put("/cart/update", item, function (result) {
            notificationService.displaySuccess("Sản phẩm đã được thêm vào giỏ hàng!");
        }, function (error) {
        });
    }

    function LoadTotalOrder() {
        var total = 0;
        $scope.cart.map((item) => {
            total += item.Product.SellPriceActual * item.Quantity;
            console.log($scope.order)
        })
        $scope.order.OrderTotal = total;
    }

    $scope.SubmitForm = SubmitForm;
    function SubmitForm() {
        console.log($scope.form)
    }

    //Load Page
    //angular.element(function () {
    //    $timeout(function () {
    //        $rootScope.LoadPageSuccess = true;
    //    }, 600);
    //});
}